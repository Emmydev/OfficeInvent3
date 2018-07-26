using OfficeInvent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewInventory : System.Web.UI.Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadStock();
        BindStock();
    }

    private bool ValidateControl()
    {
        if (int.Parse(ddlStock.SelectedValue) < 0)
        {
            ErrorControl1.ShowError("Stock field is required");
            return false;
        }
        else if (string.IsNullOrEmpty(txtCostPrice.Text))
        {
            ErrorControl1.ShowError("Cost Price field is required");
            return false;
        }
        else if (string.IsNullOrEmpty(txtQuantity.Text))
        {
            ErrorControl1.ShowError("Quantity field is required");
            return false;
        }
        else if (string.IsNullOrEmpty(txtReoderLevel.Text))
        {
            ErrorControl1.ShowError("Reorder Level field is required");
            return false;
        }


        return true;

    }

    private void BindStock()
    {
        try
        {
            var stockList = _db.Stocks.ToList();
            ddlStock.DataSource = stockList;
            ddlStock.DataTextField = "Name";
            ddlStock.DataValueField = "StockID";
            ddlStock.DataBind();
            ddlStock.Items.Insert(0, new ListItem("--Select Stock--", "0"));
        }
        catch (Exception ex)
        {

        }
    }

    private void LoadStock()
    {
        try
        {
            if (Session["CompanyId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            int companyId = int.Parse(Session["CompanyId"].ToString());
            var inventoryList = _db.Inventories.Where(m => m.CompanyId == companyId).ToList();
            if (!inventoryList.Any())
            {
                grdInventory.DataSource = new List<Inventory>();
                grdInventory.DataBind();
                return;
            }
            grdInventory.DataSource = inventoryList;
            grdInventory.DataBind();

            //var inventoryList = _db.Inventories.ToList();
            //if (!inventoryList.Any())
            //{
            //    grdInventory.DataSource = new List<Inventory>();
            //    grdInventory.DataBind();
            //    return;
            //}
            //grdInventory.DataSource = inventoryList;
            //grdInventory.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    public void UpdateInventory()
    {
        try
        {
            if (ViewState["InventoryId"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            var inventoryId = int.Parse(ViewState["InventoryId"].ToString());
            var inventoryObj = _db.Inventories.FirstOrDefault(m => m.InventoryId == inventoryId);
            if (int.Parse(ddlStock.SelectedValue) > 0)
            {
                inventoryObj.StockId = (int.Parse(ddlStock.SelectedValue));
                
            }
            inventoryObj.CostPrice = decimal.Parse(txtCostPrice.Text);
            inventoryObj.ReorderLevel = int.Parse(txtReoderLevel.Text);
            inventoryObj.Quantity = int.Parse(txtQuantity.Text);
            inventoryObj.DateCreated = DateTime.Now;
            if (chkRequired.Checked)
            {
                inventoryObj.Permision = true;
            }
            else
            {
                inventoryObj.Permision = false;
            }


            _db.SaveChanges();

            ErrorControl1.ShowSuccess("Stock Updated successfully");
            divFormIv.Visible = false;
            divList.Visible = true;
            LoadStock();
        }
        catch (Exception ex)
        {
            ErrorControl2.ShowError("An error occurred, please contact administrator");
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateControl())
        { return; }
        UpdateInventory();



    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton viewLinkBtn = (LinkButton)sender;
            var inventoryId = int.Parse(viewLinkBtn.CommandArgument);
            ErrorControl1.ClearError();
            ErrorControl2.ClearError();
            var insObj = _db.Inventories.FirstOrDefault(m => m.InventoryId == inventoryId);

            if (insObj != null)
            {
                _db.Inventories.Remove(insObj);
                _db.SaveChanges();
                LoadStock();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        ErrorControl1.ClearError();
        BindStock();
        LinkButton viewLinkBtn = (LinkButton)sender;
       
        BtnSave.CommandArgument = "2";
        // lblInstitution.Text = "Update Stock";
        BtnSave.Text = "Update Stock";
        var inventoryId = int.Parse(viewLinkBtn.CommandArgument);
        //int stockId = int.Parse(ddlStock.SelectedValue);
        ViewState["InventoryId"] = inventoryId;
        var inventoryObj = _db.Inventories.FirstOrDefault(m => m.InventoryId == inventoryId);
        if (inventoryObj != null)
        {

            ddlStock.Text =(inventoryObj.StockId).ToString();
            txtCostPrice.Text = inventoryObj.CostPrice.ToString().Trim();
            txtQuantity.Text = inventoryObj.Quantity.ToString();
            txtReoderLevel.Text = inventoryObj.ReorderLevel.ToString().Trim();
            if(inventoryObj.Permision== true)
            {
                chkRequired.Checked = true;
            }
            else
            {
                chkRequired.Checked=false;
            }
        }
       
            divList.Visible = false;
        divFormIv.Visible = true;

        BtnSave.Visible = true;
        BtnCancel.Visible = true;
        BtnSave.Text = "Update Inventory";
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        LinkButton viewLinkBtn = (LinkButton)sender;
        ErrorControl1.DisableControls(divFormIv);
        BtnSave.CommandArgument = "2";
        // lblInstitution.Text = "Update Stock";
        //  BtnSave.Text = "Update Stock";
        var inventoryId = int.Parse(viewLinkBtn.CommandArgument);
        ViewState["InventoryId"] = inventoryId;
        var inventoryObj = _db.Inventories.FirstOrDefault(m => m.InventoryId == inventoryId);
        if (inventoryObj != null)
        {
            ddlStock.Text = (inventoryObj.StockId).ToString();
            txtCostPrice.Text = inventoryObj.CostPrice.ToString().Trim();
            txtQuantity.Text = inventoryObj.Quantity.ToString();
            txtReoderLevel.Text = inventoryObj.ReorderLevel.ToString().Trim();
            if (inventoryObj.Permision == true)
            {
                chkRequired.Checked = true;
            }
            else
            {
                chkRequired.Checked = false;
            }

        }
        BtnCancel.Visible = false;
        BtnSave.Visible = false;
        divList.Visible = false;
        divFormIv.Visible = true;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        divFormIv.Visible = false;
        divList.Visible = true;
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ErrorControl1.ClearControls(divFormIv);
    }
}

