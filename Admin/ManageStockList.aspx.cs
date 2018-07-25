using OfficeInvent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageStockList : System.Web.UI.Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindVendor();
            BindCategory();
            LoadStock();
        }
    }
    private void BindVendor()
    {
        try
        {
            var vendorList = _db.Vendours.ToList();
            ddlVendor.DataSource = vendorList;
            ddlVendor.DataTextField = "CompanyName";
            ddlVendor.DataValueField = "VendourId";
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem("--Select Vendor--", "0"));
        }
        catch (Exception ex)
        {

        }
    }
    private void BindCategory()
    {
        try
        {
            var categoryList = _db.Categories.ToList();
            ddlCategory.DataSource = categoryList;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
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
            var stockList = _db.Stocks.Where(m=>m.CompanyId==companyId).ToList();
            if (!stockList.Any())
            {
                grdStock.DataSource = new List<Category>();
                grdStock.DataBind();
                return;
            }
            grdStock.DataSource = stockList;
            grdStock.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton viewLinkBtn = (LinkButton)sender;
        ErrorControl1.EnableControls(divForm);
        BtnSave.CommandArgument = "2";
       // lblInstitution.Text = "Update Stock";
        BtnSave.Text = "Update Stock";
        var stockId = int.Parse(viewLinkBtn.CommandArgument);
        ViewState["StockId"] = stockId;
        var stockObj = _db.Stocks.FirstOrDefault(m => m.StockID == stockId);
        
        if (stockObj != null)
        {
            txtName.Value = stockObj.Name.Trim();
            txtBarcode.Text = stockObj.Code.Trim();
            txtDescription.Text = stockObj.Description.Trim();
            ddlCategory.SelectedValue = stockObj.CategoryId.ToString();
            ddlVendor.SelectedValue = stockObj.VendourId.ToString();
            //string savePath = Server.MapPath("~/StockImages/");
            if (!string.IsNullOrEmpty(stockObj.FilePath))
            {  lblLogo.InnerText = "";
            }
            UpLoadedPhoto.ImageUrl = "~/StockImages/" + stockObj.FilePath;
           

        }
        divList.Visible = false;
        divForm.Visible = true;

        BtnSave.Visible = true;
        BtnCancel.Visible = true;
    }







    private bool ValidateControl()
    {
        if (string.IsNullOrEmpty(txtName.Value))
        {
            ErrorControl1.ShowError("Name field is required");
            return false;
        }
        else if (int.Parse(ddlCategory.SelectedValue) < 0)
        {
            ErrorControl1.ShowError("Category field is required");
            return false;
        }

        return true;

    }

    private string UploadPicture()
    {
        try
        {
            if (filImage.PostedFile.ContentLength > 102400)
            {
                ErrorControl1.ShowError("Picture size limit is 100kb!");
                return "";
            }

            string savePath = Server.MapPath("~/StockImages/");
            string ext = System.IO.Path.GetExtension(this.filImage.PostedFile.FileName);
            var fileName = txtName.Value + "_" + Guid.NewGuid().ToString("N") + ext;
            savePath += fileName;

            filImage.SaveAs(savePath);

            return fileName;
        }
        catch (Exception ex)
        {
            return "";

        }
    }

    public void UpdateStock()
    {
        try
        {
            if (ViewState["StockId"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            var stockId = int.Parse(ViewState["StockId"].ToString());
            var stockObj = _db.Stocks.FirstOrDefault(m => m.StockID == stockId);
            var stockList = _db.Stocks.Where(m => m.Name.ToLower().Trim().Equals(txtName.Value.ToLower().Trim()) && m.StockID == stockId);
            stockObj.Name = txtName.Value;
            if (int.Parse(ddlVendor.SelectedValue) > 0)
            {
                stockObj.VendourId = int.Parse(ddlVendor.SelectedValue);
            }
            stockObj.CategoryId = int.Parse(ddlCategory.SelectedValue);
            stockObj.Description = txtDescription.Text.Trim();
            stockObj.Code = txtBarcode.Text.Trim();
            stockObj.FilePath = UploadPicture();
          
            _db.SaveChanges();

            ErrorControl1.ShowSuccess("Stock Updated successfully");
            divForm.Visible = false;
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
          UpdateStock();
        


    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ErrorControl1.ClearControls(divForm);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        divForm.Visible = false;
        divList.Visible = true;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton viewLinkBtn = (LinkButton)sender;
            var stockId = int.Parse(viewLinkBtn.CommandArgument);
            ErrorControl1.ClearError();
            ErrorControl2.ClearError();
            var insObj = _db.Stocks.FirstOrDefault(m => m.StockID == stockId);

            if (insObj != null)
            {
                _db.Stocks.Remove(insObj);
                _db.SaveChanges();
                LoadStock();
            }
        }
        catch (Exception ex)
        {

        }
    }

   

    protected void btnView_Click(object sender, EventArgs e)
    {
        LinkButton viewLinkBtn = (LinkButton)sender;
        ErrorControl1.DisableControls(divForm);
        BtnSave.CommandArgument = "2";
        // lblInstitution.Text = "Update Stock";
        //  BtnSave.Text = "Update Stock";
        var stockId = int.Parse(viewLinkBtn.CommandArgument);
        ViewState["StockId"] = stockId;
        var stockObj = _db.Stocks.FirstOrDefault(m => m.StockID == stockId);
        if (stockObj != null)
        {
            txtName.Value = stockObj.Name;
            txtBarcode.Text = stockObj.Code;
            txtDescription.Text = stockObj.Description;
            ddlCategory.SelectedValue = stockObj.CategoryId.ToString();
            ddlVendor.SelectedValue = stockObj.VendourId.ToString();
            //string savePath = Server.MapPath("~/StockImages/");
            if (!string.IsNullOrEmpty(stockObj.FilePath))
            {
                lblLogo.InnerText = "";
            }
            UpLoadedPhoto.ImageUrl = "~/StockImages/" + stockObj.FilePath;


        }
        BtnCancel.Visible = false;
        BtnSave.Visible = false;
        divList.Visible = false;
        divForm.Visible = true;

     
    }
}
