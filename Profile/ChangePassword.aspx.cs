using Microsoft.AspNet.Identity;
using OfficeInvent3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profile_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["action"]))
            {
                if (Request.QueryString["action"] == "successful")
                {
                    mvChangePassword.ActiveViewIndex = 1;
                }
            }
        }
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                var manager = new UserManager();

              
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserId(), txtCurrentPassword.Value, txtNewPassword.Value);
                if (result.Succeeded)
                {
                    var user = manager.FindById(User.Identity.GetUserId());
                    user.EmailConfirmed = true;
                    
                    IdentityResult updateResult = manager.Update(user);
                    Response.Redirect("~/Profile/ChangePassword.aspx?action=successful");
                }
                else
                {

                    ErrorControl1.ShowError(result.Errors.FirstOrDefault());

                }
            }
        }
        catch (Exception ex)
        {
            ErrorControl1.ShowError(ex.Message);

        }

    }

}
