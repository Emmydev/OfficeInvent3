<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" Async="true" CodeFile="CreateUser.aspx.cs" Inherits="UserManagement_CreateUser" %>

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
                    <h2><i class="fa fa-list"></i>Create New User</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>
                <div class="box-content">
                               <div class="row">
                                   <uc1:ErrorControl ID="ErrorControl1" runat="server" />
                                   
                                   <div class="col-md-6 col-md-offset-3">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <div class="col-sm-12">
                                            <asp:ValidationSummary ID="vsLogin" ValidationGroup="register" CssClass="alert alert-danger" runat="server" />
                                            
                                        </div>
                                    </div>
                                    <div class="form-group ">

                                        
                                        <div class="col-sm-12">
                                            <input type="text" class="form-control" runat="server" id="txtFullname" placeholder="Full Name" />
                                            <asp:RequiredFieldValidator
                                                runat="server"
                                                Display="None"
                                                ValidationGroup="register"
                                                ControlToValidate="txtFullname"
                                                ErrorMessage="Full name is required"> </asp:RequiredFieldValidator>
                                        </div>
                                      
                                    </div>
                                    <div class="form-group ">
                                        <div class="col-sm-12">
                                            <input type="email" class="form-control" runat="server" id="txtEmail" placeholder="Email Address" />
                                            <asp:RequiredFieldValidator
                                                runat="server"
                                                Display="None"
                                                ValidationGroup="register"
                                                ControlToValidate="txtEmail"
                                                ErrorMessage="Email is required"> </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                runat="server"
                                                Display="None"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="register"
                                                ControlToValidate="txtEmail"
                                                ErrorMessage="Email address you entered is not properly formed"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <div class="col-sm-12">
                                            <input type="text" class="form-control" runat="server" id="txtPhone" placeholder="Telephone Number" />
                                            <asp:RequiredFieldValidator
                                                runat="server"
                                                Display="None"
                                                ValidationGroup="register"
                                                ControlToValidate="txtPhone"
                                                ErrorMessage="Phone number is required"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <div class="col-sm-12">
                                            <input type="password" class="form-control" runat="server" id="txtPassword" placeholder="Password" />
                                            <asp:RequiredFieldValidator
                                                runat="server"
                                                ControlToValidate="txtPassword"
                                                ValidationGroup="register"
                                                Display="None"
                                                ErrorMessage="Password is required." />
                                        </div>
                                    </div>
                                    <div class="form-group ">
                                        <div class="col-sm-12">
                                            <input type="password" class="form-control" runat="server" id="txtConfirmPassword" placeholder="Confirm Password" />
                                            <asp:RequiredFieldValidator
                                                runat="server"
                                                ControlToValidate="txtConfirmPassword"
                                                ValidationGroup="register"
                                                Display="None"
                                                ErrorMessage="Please confirm your password." />
                                            <asp:CompareValidator
                                                runat="server"
                                                ControlToCompare="txtPassword"
                                                ControlToValidate="txtConfirmPassword"
                                                ValidationGroup="register"
                                                Display="None"
                                                ErrorMessage="The password and confirmation password do not match." />
                                        </div>
                                        </div>
                              
                                    
                                    <div class="form-group">
                                        <div class="col-sm-12">
                                            <asp:LinkButton ID="btnRegister" runat="server" ValidationGroup="register" CssClass="btn btn-group btn-success btn-animated pull-right" OnClick="registerUser"> Create User <i class="fa fa-user"></i></asp:LinkButton>
                                        </div>
                                    </div>
                               
                            </div>
                                   </div>
                    </div>
                      </div>
            </div>
         </div>
    
    
     </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" Runat="Server">
</asp:Content>

