using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ErrorHandler_ErrorControl : System.Web.UI.UserControl
{
    private string _errorMsg = string.Empty;
    private string _plainMsg = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            tbError.Visible = false;
            tbMessage.Visible = false;
            tbWarning.Visible = false;
        }
    }
    #region

    public string LoadErrorMessage()
    {
        return _errorMsg;
    }
    public string LoadPlainMessage()
    {
        return _plainMsg;
    }
    public void ClearError()
    {
        _errorMsg = string.Empty;
        tbError.Visible = false;
        _plainMsg = string.Empty;
        tbMessage.Visible = false;
    }
    public void ShowError(string errMsg)
    {
        if (errMsg.Length > 0)
        {
            _plainMsg = "";
            tbMessage.Visible = false;
            _errorMsg = errMsg;
            LoadErrorMessage();
            tbError.Visible = true;

        }

    }
    public void ShowWarning(string msg)
    {
        if (msg.Length > 0)
        {
            _errorMsg = "";
            tbWarning.Visible = true;
            tbError.Visible = false;
            _plainMsg = msg;
            LoadPlainMessage();
            tbMessage.Visible = false;

        }

    }
    public void ShowSuccess(string msg)
    {
        if (msg.Length > 0)
        {
            _errorMsg = "";
            tbError.Visible = false;
            _plainMsg = msg;
            LoadPlainMessage();
            tbMessage.Visible = true;

        }

    }

    public void ClearControls(Control parent)
    {
        if (parent == null)
        {
            return;
        }
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(HtmlInputText))
            {
                ((HtmlInputText)c).Value = "";
            }
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)c).Text = "";
            }
            else if (c.GetType() == typeof(DropDownList))
            {
                if (((DropDownList)c).Items.Count > 0)
                {
                    ((DropDownList)c).SelectedIndex = 0;
                }
            }
            else if (c.GetType() == typeof(ListBox))
            {
                if (((ListBox)c).Items.Count > 0)
                {
                    ((ListBox)c).Items.Clear();
                }
            }
            //else if (c.GetType() == typeof(CheckBoxList))
            //{
            //    if (((CheckBoxList)c).Items.Count > 0)
            //    {
            //        ((CheckBoxList)c).Items.Clear();
            //    }
            //}
            else if (c.GetType() == typeof(CheckBox))
            {
                if (((CheckBox)c).Checked)
                {
                    ((CheckBox)c).Checked = false;
                }
            }
            else
            {
                if (c.HasControls())
                {
                    ClearControls(c);
                }
            }
        }
    }
    public void DisableControls(Control parent)
    {
        if (parent == null)
        {
            return;
        }
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(HtmlInputText))
            {
                ((HtmlInputText)c).Disabled = true;
            }
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)c).Enabled = false;
            }
            else if (c.GetType() == typeof(DropDownList))
            {

                ((DropDownList)c).Enabled = false;

            }
            else if (c.GetType() == typeof(ListBox))
            {
                ((ListBox)c).Enabled = false;


            }
            else if (c.GetType() == typeof(FileUpload))
            {
                ((FileUpload)c).Enabled = false;


            }
            else if (c.GetType() == typeof(CheckBox))
            {
                ((CheckBox)c).Enabled = false;
            }
            else
            {
                if (c.HasControls())
                {
                    DisableControls(c);
                }
            }
        }
    }

    public void EnableControls(Control parent)
    {
        if (parent == null)
        {
            return;
        }
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(HtmlInputText))
            {
                ((HtmlInputText)c).Disabled = false;
            }
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)c).Enabled = true;
            }
            else if (c.GetType() == typeof(DropDownList))
            {

                ((DropDownList)c).Enabled = true;

            }
            else if (c.GetType() == typeof(ListBox))
            {
                ((ListBox)c).Enabled = true;


            }
            else if (c.GetType() == typeof(FileUpload))
            {
                ((FileUpload)c).Enabled = true;


            }
            else if (c.GetType() == typeof(CheckBox))
            {
                ((CheckBox)c).Enabled = true;
            }
            else
            {
                if (c.HasControls())
                {
                    EnableControls(c);
                }
            }
        }
    }
    public void HideShowControl(Control conrolToHide, Control controlToShow)
    {
        conrolToHide.Visible = false;
        controlToShow.Visible = true;
    }
    #endregion
}
