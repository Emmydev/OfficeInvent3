<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Open+Sans|Candal|Alegreya+Sans">
  <link rel="stylesheet" type="text/css" href="css/font-awesome.min.css">
  <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
  <link rel="stylesheet" type="text/css" href="css/imagehover.min.css">
  <link rel="stylesheet" type="text/css" href="css/style.css">
</head>
<body>
    <!--Navigation bar-->
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="default.aspx">Office<span>Invent3</span></a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav navbar-right">
                   
                    
                </ul>
            </div>
        </div>
    </nav>
    <!--/ Navigation bar-->
     <div class="row">
            <div class="col-md-4 col-md-offset-4" style="">
                
                
                 <div class="modal-dialog modal-sm">

            <div class="modal-content">
                <div class="modal-header">
                   
                    <h4 class="modal-title text-center form-title">Login</h4>
                </div>
                <div class="modal-body padtrbl">

                    <div class="login-box-body">
                        <p class="login-box-msg">Sign in to start your session</p>
						 <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                        <div class="form-group">
                            <form name="" id="loginForm" runat="server">

                                <div class="form-group has-feedback">
                                    <!----- username -------------->
                                     <asp:TextBox ID="Email" runat="server" CssClass="form-control" placeholder="E-mail or phone number" name="email"  autofocus="autofocus"></asp:TextBox>
                                    <span style="display:none;font-weight:bold; position:absolute;color: red;position: absolute;padding:4px;font-size: 11px;background-color:rgba(128, 128, 128, 0.26);z-index: 17;  right: 27px; top: 5px;" "></span>
                                    <!---Alredy exists  ! -->
                                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                                </div>
                                <div class="form-group has-feedback">
                                    <!----- password -------------->
                                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="Password" name="password" type="password"></asp:TextBox>
                                    <span style="display:none;font-weight:bold; position:absolute;color: grey;position: absolute;padding:4px;font-size: 11px;background-color:rgba(128, 128, 128, 0.26);z-index: 17;  right: 27px; top: 5px;" id="span_loginpsw"></span>
                                    <!---Alredy exists  ! -->
                                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="checkbox icheck">
                                            <label>
                                                <input type="checkbox" id="RememberMe" runat="server"> Remember Me
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-xs-12">
                                        <asp:Button Text="Sign In" runat="server" CssClass="btn btn-green btn-block btn-flat" OnClick="LogIn" />
                                     
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

      
</div>
            

            </div>
</div>
</body>
</html>
