﻿using Microsoft.AspNet.Identity;
using OfficeInvent3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // Validate the user password
            var manager = new UserManager();
            ApplicationUser user = manager.Find(Email.Text, Password.Text);
            if (user != null)
            {
                Session["LogedinuserId"] = user.Id;
                IdentityHelper.SignIn(manager, user, RememberMe.Checked);
               Response.Redirect("Admin/Dashboard.aspx");
            }
            else
            {
                FailureText.Text = "Invalid username or password.";
                ErrorMessage.Visible = true;
            }
        }
    }
}