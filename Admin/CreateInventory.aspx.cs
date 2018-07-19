using OfficeInvent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreateInventory : System.Web.UI.Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStock();
         
        }
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
  

   

    private bool ValidateControl()
    {
        if (int.Parse(ddlStock.SelectedValue) < 0)
        {
            ErrorControl1.ShowError("Please select stock");
            return false;
        }
        else if (string.IsNullOrEmpty(txtQuantity.Text))
        {
            ErrorControl1.ShowError("Quantity field is required");
            return false;
        }
        

        return true;

    }

    public void SaveInventory()
    {
        try
        {
            if (Session["CompanyId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            int companyId = int.Parse(Session["CompanyId"].ToString());
            int stockId = int.Parse(ddlStock.SelectedValue);
            var inventories = _db.Inventories.Where(m => m.StockId == stockId);
            

            if (inventories.Any())
            {
                ErrorControl1.ShowError("Stock with the same name already exist");
                return;
            }
            var inventObj = new Inventory
            {
                //    Name = txtName.Value,
                //    CategoryId = int.Parse(ddlCategory.SelectedValue),
                //    CompanyId = companyId,
                //    DateCreated = DateTime.Now,
                //    Description = txtDescription.Text,
                //    Code = txtBarcode.Text,


                //};
                //if (int.Parse(ddlVendor.SelectedValue) > 0)
                //{
                //    stockObj.VendourId = int.Parse(ddlVendor.SelectedValue);
                //}
                //if (filImage.HasFile)
                //{
                //    stockObj.FilePath = UploadPicture();
            };
            //_db.Stocks.Add(stockObj);
            _db.SaveChanges();
            ErrorControl1.ShowSuccess("Stock saved successfully");
            ErrorControl1.ClearControls(divForm);

        }
        catch (Exception ex)
        {
            ErrorControl1.ShowError("An error occurred, Please contact administrator");
        }
    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateControl())
        {
            return;
        }
        SaveInventory();
    }
}