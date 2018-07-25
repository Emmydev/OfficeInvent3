using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using OfficeInvent3;
using OfficeInvent.EF;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

public partial class Account_Register : Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           BindIndustry();
        }

    }

    private void BindIndustry()
    {
        try
        {
            var industryList = _db.Industries.ToList();
            ddlIndustry.DataSource = industryList;
            ddlIndustry.DataTextField = "Name";
            ddlIndustry.DataValueField = "IndustryId";
            ddlIndustry.DataBind();
            ddlIndustry.Items.Insert(0, new ListItem("--Select Industry--", "0"));
        }
        catch(Exception ex)
        {

        }
    }
    private bool ValidateControl()
    {
        if (string.IsNullOrEmpty(txtFullName.Text))
        {
            ErrorControl1.ShowError("Full Name is required");
            return false;
        }
        else if (int.Parse(ddlIndustry.SelectedValue) < 1)
        {
            ErrorControl1.ShowError("Please select industry");
            return false;
        }
        return true;
    }
    private int AddCompany()
    {
        try
        {
            var compObj = new Company
            {
              Name=txtCompanyName.Text,
              Size=int.Parse(ddlCompSizes.SelectedValue),
              IndustryId=int.Parse(ddlIndustry.SelectedValue),
              AdvertMedium=int.Parse(ddlAdvertSource.SelectedValue),
              Challenge=txtProblemtosolve.Text
              
            };
            _db.Companies.Add(compObj);
            _db.SaveChanges();
            return compObj.CompanyId;
        }
        catch(Exception ex)
        {
            ErrorControl1.ShowError("An error occurred, Please contact administrator");
            return 0;
        }
        
    }

 




    protected async void CreateUser_Click(object sender, EventArgs e)
    {
        if (!ValidateControl())
        {
            return;
        }
        int companyId = AddCompany();
        if (companyId > 0)
        {
            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = txtEmail.Text,Email=txtEmail.Text, CompanyId = companyId, FullName = txtFullName.Text, PhoneNumber = txtPhone.Value };
            IdentityResult result = await manager.CreateAsync(user, txtPassword.Text);
            if (result.Succeeded)
            {
                await Util.SendEmail(txtPassword.Text, txtEmail.Text,txtFullName.Text);
                Session["LogedinuserId"] = user.Id;
               // IdentityHelper.SignIn(manager, user, isPersistent: false);
                Response.Redirect("Success.aspx?em=" + txtEmail.Text + "&" + "nm=" + txtFullName.Text);
               // IdentityHelper.RedirectToReturnUrl("Login.aspx?em="+txtEmail.Text+"&"+"nm="+txtFullName.Text, Response);
            }
            else
            {
                ErrorControl1.ShowError(result.Errors.FirstOrDefault());

            }
        }
    }
}