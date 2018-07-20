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

        
    }


    private bool ValidateControl()
    {
        if (string.IsNullOrEmpty(txtFullName.Text))
        {
            ErrorControl2.ShowError("Name is Required");
            return false;
        }
        else if (string.IsNullOrEmpty(txtFullName.Text))
        {
            ErrorControl2.ShowError("Company is Required");
            return false;
        }
        else if (string.IsNullOrEmpty(txtAddress.Text))
        {
            ErrorControl2.ShowError("Address is required");
            return false;
        }
        else if (string.IsNullOrEmpty(txtPhone.Text))
        {
            ErrorControl2.ShowError("Phone is required");
            return false;
        }
        else if (string.IsNullOrEmpty(txtEmail.Text))
        {
            ErrorControl2.ShowError("Email is required");
            return false;
        }


        return true;
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
                CompanyName = txtCompany.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
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
            instituionObj.FullName = txtFullName.Text.Trim();
            instituionObj.CompanyName = txtCompany.Text.Trim();
            instituionObj.Address = txtAddress.Text.Trim();
            instituionObj.Phone = txtPhone.Text.Trim();
            instituionObj.Email = txtEmail.Text.Trim();
            instituionObj.Website = txtAccountNo.Text.Trim();
            instituionObj.AccountNumber = txtAccountNo.Text.Trim();
            instituionObj.AccountName = txtAccountName.Text.Trim();
            instituionObj.BankName = txtBankName.Text.Trim();
            instituionObj.AccountType = int.Parse(ddlAccountType.SelectedValue);
            _db.SaveChanges();

            ErrorControl1.ShowSuccess("Vendour Updated successfully");
            divFormVend.Visible = false;
            divList.Visible = true;
            LoadVendour();
        }
        catch (Exception ex)
        {
            ErrorControl2.ShowError("An error occurred, please contact administrator");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton viewLinkBtn = (LinkButton)sender;
            var vendourId = int.Parse(viewLinkBtn.CommandArgument);
            ErrorControl1.ClearError();
            ErrorControl2.ClearError();
            var insObj = _db.Vendours.FirstOrDefault(m => m.VendourId == vendourId);

            if (insObj != null)
            {
                _db.Vendours.Remove(insObj);
                _db.SaveChanges();
                LoadVendour();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton viewLinkBtn = (LinkButton)sender;
        lblInstitution.Visible = true;
        BtnSave.CommandArgument = "2";
        lblInstitution.Text = "Update Vendour";
        BtnSave.Text = "Update Vendour";
        var vendourId = int.Parse(viewLinkBtn.CommandArgument);
        ViewState["VendourId"] = vendourId;
        var vendourObj = _db.Vendours.FirstOrDefault(m => m.VendourId == vendourId);
        if (vendourObj != null)
        {
            txtFullName.Text = vendourObj.FullName.Trim();
            txtCompany.Text = vendourObj.CompanyName.Trim();
            txtAddress.Text = vendourObj.Address.Trim();
            txtPhone.Text = vendourObj.Phone.Trim();
            txtEmail.Text = vendourObj.Email.Trim();
            txtWebsite.Text = vendourObj.Website.Trim();
            txtAccountNo.Text = vendourObj.AccountNumber.Trim();
            txtAccountName.Text = vendourObj.AccountName.Trim();
            txtBankName.Text = vendourObj.BankName.Trim();
            ddlAccountType.Text = vendourObj.AccountType.ToString();
        }
        divList.Visible = false;
        divFormVend.Visible = true;

        BtnSave.Visible = true;
        BtnCancel.Visible = true;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        divFormVend.Visible = false;
        divList.Visible = true;
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ErrorControl1.ClearControls(divFormVend);
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateControl())
        { return; }

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