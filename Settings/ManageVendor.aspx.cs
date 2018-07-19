using OfficeInvent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings_ManageVendor : System.Web.UI.Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadVendour();
        }

        if (!IsPostBack)
        {
            BindCompany();
        }
    }

    private void BindCompany()
    {
        try
        {
            var CompanyList = _db.Companies.ToList();
            ddlCompany.DataSource = CompanyList;
            ddlCompany.DataTextField = "Name";
            ddlCompany.DataValueField = "CompanyId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("--Select Company--", "0"));
        }
        catch (Exception ex)
        {

        }
    }

    private void LoadVendour()
    {
        try
        {

            var institutionList = _db.Vendours.ToList();
            if (!institutionList.Any())
            {
                grdInstitution.DataSource = new List<Vendour>();
                grdInstitution.DataBind();
                return;
            }
            grdInstitution.DataSource = institutionList;
            grdInstitution.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    public void SaveVendour()
    {
        try
        {
            if (Session["CompanyId"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            int companyId = int.Parse(Session["CompanyId"].ToString());
            var vendourList = _db.Vendours.Where(m => m.FullName.ToLower().Trim().Equals(txtFullName.Text.ToLower().Trim()));

            if (vendourList.Any())
            {
                ErrorControl1.ShowError("Vendour name already exist");
                return;
            }
            var vendourObj = new Vendour
            {
                FullName = txtFullName.Text,
                CompanyName = ddlCompany.SelectedValue,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Website = txtWebsite.Text,
                AccountNumber = txtFullName.Text,
                AccountName = txtAccountName.Text,
                BankName = txtBankName.Text,
                AccountType = int.Parse(ddlAccountType.SelectedValue),
                CompanyId = companyId

            };
            _db.Vendours.Add(vendourObj);
            _db.SaveChanges();
            ErrorControl1.ShowSuccess("Vendour saved successfully");
            divFormVend.Visible = false;
            divList.Visible = true;
            LoadVendour();
        }
        catch (Exception ex)
        {
            ErrorControl1.ShowError("An error occurred, Please contact administrator");
        }
    }

    public void UpdateVendour()
    {
        try
        {
            if (ViewState["VendourId"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            var vendourId = int.Parse(ViewState["VendourId"].ToString());
            var instituionObj = _db.Vendours.FirstOrDefault(m => m.VendourId == vendourId);
            instituionObj.FullName = txtFullName.Text;

            _db.SaveChanges();

            ErrorControl1.ShowSuccess("Category Updated successfully");
            divFormVend.Visible = false;
            divList.Visible = true;
            LoadVendour();
        }
        catch (Exception ex)
        {
            ErrorControl2.ShowError("An error occurred, please contact administrator");
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (BtnSave.CommandArgument == "1")
        {
            SaveVendour();
        }
        else
        {
            UpdateVendour();
        }
    }
    protected void btnAddVendour_Click(object sender, EventArgs e)
    {
        ErrorControl1.ClearError();
        ErrorControl2.ClearError();
        ErrorControl1.ClearControls(divFormVend);

        divFormVend.Visible = true;
        divList.Visible = false;

        lblInstitution.Text = "Add Vendour";
        BtnSave.Text = "Add Vendour";
        BtnCancel.Visible = true;
        BtnSave.Visible = true;
        BtnSave.CommandArgument = "1";
    }



 
}