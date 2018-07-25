using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OfficeInvent.EF;
using OfficeInvent3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManagement_CreateUser : System.Web.UI.Page
{
    private OfficeInvent3Entities _db = new OfficeInvent3Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
           
        }

    }

  


  
    protected async void registerUser(object sender, EventArgs e)
    {
        try
        {
            if (Session["CompanyId"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            int companyId = int.Parse(Session["CompanyId"].ToString());
            var manager = new UserManager();
            manager.PasswordValidator = new PasswordValidator
            {
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            var user = new ApplicationUser() { FullName = txtFullname.Value, Email = txtEmail.Value, PhoneNumber = txtPhone.Value, UserName = txtEmail.Value, EmailConfirmed = true,CompanyId=companyId};
            IdentityResult result = manager.Create(user, txtPassword.Value.Trim());
            if (result.Succeeded)
            {
                
                manager.AddToRole(user.Id, "Staff");

               
                await Util.SendEmail(txtPassword.Value, txtEmail.Value, txtFullname.Value);
                ErrorControl1.ShowSuccess("User added successfully");

                txtFullname.Value = "";
                txtEmail.Value = "";
                
                txtPhone.Value = "";

            }
            else
            {

                ErrorControl1.ShowError(result.Errors.FirstOrDefault());

            }
        }
        catch (Exception ex)
        {

            ErrorControl1.ShowError(ex.Message);

        }

    }

    
}
