using OfficeInvent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageStock : System.Web.UI.Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindVendor();
            BindCategory();
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

    public void SaveStock()
    {
        try
        {
            if (Session["CompanyId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            int companyId = int.Parse(Session["CompanyId"].ToString());
            var stockList = _db.Stocks.Where(m => m.Name.ToLower().Trim().Equals(txtName.Value.ToLower().Trim()) && m.CompanyId==companyId);
            
            if (stockList.Any())
            {
                ErrorControl1.ShowError("Stock with the same name already exist");
                return;
            }
            var stockObj = new Stock
            {
                Name = txtName.Value,
                CategoryId=int.Parse(ddlCategory.SelectedValue),
                CompanyId=companyId,
                DateCreated=DateTime.Now,
                Description=txtDescription.Text,
                Code= txtBarcode.Text,
               

            };
            if (int.Parse(ddlVendor.SelectedValue) > 0)
            {
                stockObj.VendourId = int.Parse(ddlVendor.SelectedValue);
            }
            if (filImage.HasFile)
            {
                stockObj.FilePath = UploadPicture();
            }
            _db.Stocks.Add(stockObj);
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
        SaveStock();
    }
}