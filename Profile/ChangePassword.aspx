<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Profile_ChangePassword" %>

<%@ Register src="../ErrorHandler/ErrorControl.ascx" tagname="ErrorControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" Runat="Server">

      <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <asp:Panel ID="responsePanel" runat="server" Visible="false" CssClass="alert alert-info alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <asp:Literal runat="server" ID="responseLabel"></asp:Literal>
               
            </asp:Panel>

            <asp:ValidationSummary ID="pageValidationSummary" runat="server" CssClass="errormsg" ShowMessageBox="True" ShowSummary="False" />

                  <div class="box">
                <div class="box-header">
                    <h2><i class="fa fa-list"></i>Change Password</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>
               
                             <section id="main-content" class="animated fadeInUp">
        <div class="row">

             <p>

             <uc1:ErrorControl ID="ErrorControl1" runat="server" />
             <p>
            <asp:MultiView ID="mvChangePassword" runat="server" ActiveViewIndex="0">
                
                <asp:View ID="vwDefault" runat="server">
                    <div class="col-md-12 col-lg-12">
                        
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-3">
                                        <div role="form" id="changeForm" class="form-horizontal">
                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <input type="password" class="form-control" id="txtCurrentPassword" runat="server" placeholder="Current Password" required="required" />
                                                </div>
                                                <asp:RequiredFieldValidator
                                                    runat="server"
                                                    ControlToValidate="txtCurrentPassword"
                                                    ValidationGroup="reset"
                                                    Display="None"
                                                    ErrorMessage="Please enter your current password." />
                                            </div>

                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <input type="password" class="form-control" id="txtNewPassword" runat="server" placeholder="New Password" required="required" />
                                                </div>
                                                <asp:RequiredFieldValidator
                                                    runat="server"
                                                    ControlToValidate="txtNewPassword"
                                                    ValidationGroup="reset"
                                                    Display="None"
                                                    ErrorMessage="Please enter your new password." />
                                            </div>

                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <input type="password" class="form-control" id="txtConfirmNewPassword" runat="server" placeholder="Confirm New Password" required="required" />
                                                </div>
                                                <asp:RequiredFieldValidator
                                                    runat="server"
                                                    ControlToValidate="txtConfirmNewPassword"
                                                    ValidationGroup="reset"
                                                    Display="None"
                                                    ErrorMessage="Please confirm your new password." />
                                                <asp:CompareValidator
                                                    runat="server"
                                                    ControlToCompare="txtNewPassword"
                                                    ControlToValidate="txtConfirmNewPassword"
                                                    ValidationGroup="reset"
                                                    Display="None"
                                                    ErrorMessage="The new password and confirmation password do not match." />
                                            </div>

                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <asp:LinkButton ID="btnChangePassword" runat="server" ValidationGroup="reset" OnClick="btnChangePassword_Click" CssClass="btn btn-group btn-default btn-animated pull-right">Change Password <i class="fa fa-key"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                   
                </asp:View>

                <asp:View ID="vwSuccess" runat="server">
                    <div class="col-md-12 col-lg-12">
                       
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-3">
                                        <div role="form">
                                            <div class="form-group alert alert-success">
                                                You password was successfully changed. Kindly head to the login page to login with your new password.
                                            </div>

                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <asp:LinkButton ID="btnGotoLogin" runat="server" PostBackUrl="~/login.aspx"  CssClass="btn btn-group btn-default btn-animated"> Goto Login <i class="fa fa-key"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                  
                </asp:View>
            </asp:MultiView>


        </div>

    </section>
    <div class="modal fade" id="validationModal" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Oops! We think you ommited something.</h4>
                </div>
                <div class="modal-body">
                    <asp:ValidationSummary CssClass="alert alert-danger" ValidationGroup="reset" runat="server" DisplayMode="List" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
   </div>
            </div>
          </div>
    
</asp:Content>
<asp:Content ID="scriptContainer" ContentPlaceHolderID="scriptsContentPlaceHolder" runat="Server">
    <script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                $('#validationModal').modal();
                $(window).scrollTop($('#changeForm').offset().top);
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
