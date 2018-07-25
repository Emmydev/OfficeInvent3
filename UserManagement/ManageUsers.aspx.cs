using OfficeInvent.EF;
using OfficeInvent3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManagement_ManageUsers : System.Web.UI.Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUsers();
          
        }

    }

    protected void GetUsers()
    {
        try
        {
            var context = new ApplicationDbContext();
            var Pandas = context.Users.ToList();
            gvPandas.DataSource = Pandas;
            gvPandas.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

   

   
    //        protected void btnDelete_Click(object sender, EventArgs e)
    //        {
    //            try
    //            {
    //                LinkButton deleteLinkBtn = (LinkButton)sender;
    //                var userId = deleteLinkBtn.CommandArgument;
    //                var userObj = _db.AspNetUsers.FirstOrDefault(m => m.Id == userId);
    //                if (userObj != null)
    //                {
    //                    _db.AspNetUsers.Remove(userObj);
    //                    _db.SaveChanges();
    //                    GetUsers();
    //                }
    //            }
    //            catch (Exception ex)
    //            {

    //            }
    //}

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton viewLinkBtn = (LinkButton)sender;
        lbluseredit.Visible = true;
        BtnSave.CommandArgument = "2";
        lbluseredit.Text = "Update User";
        BtnSave.Text = "Update User";
        var userId = viewLinkBtn.CommandArgument;
        ViewState["UserId"] = userId;
        var userobj = _db.AspNetUsers.FirstOrDefault(m => m.Id == userId);
        if (userobj != null)
        {
            txtFullname.Value = userobj.FullName;
            txtPhone.Value = userobj.PhoneNumber;
          

        }

        gvPandas.Visible = false;
        divForm.Visible = true;

        UpdateUser();
    }

    public void UpdateUser()
    {
        try
        {
            if (ViewState["UserId"] == null)
            {
                Response.Redirect("~/login.aspx");
            }

            if (string.IsNullOrEmpty(txtFullname.Value))
            {
              ErrorControl1.ShowError("Kindly input Full Name; Field cannot be empty");
            }
            if (string.IsNullOrEmpty(txtPhone.Value))
            {
               ErrorControl1.ShowError("Kindly input Phone Number; Field cannot be empty");
            }
            
            var userId = ViewState["UserId"].ToString();
            var userObj = _db.AspNetUsers.FirstOrDefault(m => m.Id == userId);
            userObj.FullName = txtFullname.Value;
           
           
            userObj.PhoneNumber = txtPhone.Value;
         //   var userRoleObj=_db.
         //   userObj.InstitutionId = ddlInstitution.SelectedIndex;

            _db.SaveChanges();
        }
        catch (Exception ex)
        {

        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        divForm.Visible = false;
        gvPandas.Visible = true;
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave.CommandArgument == "2")
        {
            UpdateUser();
        }
        ErrorControl1.ClearError();

        GetUsers();
        gvPandas.DataBind();
        gvPandas.Visible = true;
        divForm.Visible = false;

        //txtFirstName.Value = "";
        //txtLastName.Value = "";
        //txtEmail.Value = "";
        //txtPhone.Value = "";
        //ddlInstitution.SelectedIndex = 0;
    }
}
