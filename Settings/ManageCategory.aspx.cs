using OfficeInvent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings_ManageCategory : System.Web.UI.Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCategory();
        }
    }

    private void LoadCategory()
    {
        try
        {

            var institutionList = _db.Categories.ToList();
            if (!institutionList.Any())
            {
                grdInstitution.DataSource = new List<Category>();
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
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        LinkButton viewLinkBtn = (LinkButton)sender;
        lblInstitution.Visible = true;
        BtnSave.CommandArgument = "2";
        lblInstitution.Text = "Update Category";
        BtnSave.Text = "Update Category";
        var categoryId = int.Parse(viewLinkBtn.CommandArgument);
        ViewState["CategoryId"] = categoryId;
        var categoryObj = _db.Categories.FirstOrDefault(m => m.CategoryId == categoryId);
        if (categoryObj != null)
        {
            txtName.Text = categoryObj.Name;
   
        }
        divList.Visible = false;
        divForm.Visible = true;

        BtnSave.Visible = true;
        BtnCancel.Visible = true;
    }







    private bool ValidateControl()
    {
        if (string.IsNullOrEmpty(txtName.Text))
        {
            ErrorControl2.ShowError("Name is required");
            return false;
        }
        

        return true;
    }

    public void SaveCategory()
    {
        try
        {
            var categoryList = _db.Categories.Where(m => m.Name.ToLower().Trim().Equals(txtName.Text.ToLower().Trim()));

            if (categoryList.Any())
            {
                ErrorControl1.ShowError("Category name already exist");
                return;
            }
            var categoryObj = new Category
            {
                Name = txtName.Text,
               
            };
            _db.Categories.Add(categoryObj);
            _db.SaveChanges();
            ErrorControl1.ShowSuccess("Category saved successfully");
            divForm.Visible = false;
            divList.Visible = true;
            LoadCategory();
        }
        catch (Exception ex)
        {
            ErrorControl1.ShowError("An error occurred, Please contact administrator");
        }
    }

    public void UpdateCategory()
    {
        try
        {
            if (ViewState["CategoryId"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            var categoryId = int.Parse(ViewState["CategoryId"].ToString());
            var instituionObj = _db.Categories.FirstOrDefault(m => m.CategoryId == categoryId);
            instituionObj.Name = txtName.Text;
          
            _db.SaveChanges();

            ErrorControl1.ShowSuccess("Category Updated successfully");
            divForm.Visible = false;
            divList.Visible = true;
            LoadCategory();
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

        if (BtnSave.CommandArgument == "1")
        {
            SaveCategory();
        }
        else
        {
            UpdateCategory();
        }


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
            var categoryId = int.Parse(viewLinkBtn.CommandArgument);
            ErrorControl1.ClearError();
            ErrorControl2.ClearError();
            var insObj = _db.Categories.FirstOrDefault(m => m.CategoryId == categoryId);
           
            if (insObj != null)
            {
                _db.Categories.Remove(insObj);
                _db.SaveChanges();
                LoadCategory();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        ErrorControl1.ClearError();
        ErrorControl2.ClearError();
        ErrorControl1.ClearControls(divForm);

        divForm.Visible = true;
        divList.Visible = false;

        lblInstitution.Text = "Add Category";
        BtnSave.Text = "Add Category";
        BtnCancel.Visible = true;
        BtnSave.Visible = true;
        BtnSave.CommandArgument = "1";
    }
}
