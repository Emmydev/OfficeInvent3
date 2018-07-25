<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="CreateInventory.aspx.cs" Inherits="Admin_CreateInventory" %>

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
                    <h2><i class="fa fa-list"></i>Create Inventory</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>
                <div class="box-content">
                               <div class="row">
                                  
                                         
                                          
                 <div class="col-sm-12" runat="server"  id="divForm">
                   <div class="col-md-12">
                                       
                                        <div class="form-horizontal" role="form" runat="server" id="detailView" >
                     
                                            <div class="form-group" runat="server" >
                                   
                                    <div class="col-sm-10 text-center">
                                         
                                           <uc1:ErrorControl ID="ErrorControl1" runat="server" />
                                    </div>
                                    </div> 
                                  <div class="form-group">
                                <label runat="server" id="Label2" class="col-sm-3 control-label" >Stock *</label>
                                  <div class="col-sm-5">
                                <asp:DropDownList runat="server" ID="ddlStock" CssClass="form-control" ></asp:DropDownList>
                                 </div>
                            </div>
                                            
                            <div class="form-group">
                                 <label for="txtCostPrice" class="col-sm-3 control-label">Cost Price </label>
                               <div class="col-sm-5">
                                  <asp:TextBox ID="txtCostPrice" CssClass="form-control "  runat="server">
                                   </asp:TextBox>
                                
                               </div>
                            </div>
                       
                            <div class="form-group">
                                <label for="txtQuantity" runat="server" id="Label1" class="col-sm-3 control-label" >Quantity *</label>
                                      <div class="col-sm-5">
                                <asp:TextBox ID="txtQuantity" CssClass="form-control "  runat="server">
                                   </asp:TextBox>
                                </div>
                            </div>
                              
                            <div class="form-group">
                                 <label for="txtReoderLevel" class="col-sm-3 control-label">Reorder Level </label>
                                  <div class="col-sm-5">
                                  <asp:TextBox ID="txtReoderLevel" CssClass="form-control "  runat="server">
                                   </asp:TextBox>
                                
                                   </div>
                                 </div>
                                            <div class="form-group">
                                 <label for="txtRequired" class="col-sm-3 control-label">Require Permission? </label>
                                  <div class="col-sm-5">
                                <asp:CheckBox ID="chkRequired" runat="server" />
                                   </div>
                                 </div>
                                   
                                
                             <div class="form-group">
                            <div class="col-sm-8 text-right">
                        
                           
                          
                                <asp:Button ID="BtnCancel" CssClass=" btn btn-sm btn-danger" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                                 <asp:Button ID="BtnSave" CommandName="Save" CssClass="btn btn-sm btn-success" runat="server"  Text="Create Inventory" OnClick="BtnSave_Click"   CommandArgument="1"/>
                            </div>
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

