<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="UserManagement_ManageUsers" %>

<%@ Register src="../ErrorHandler/ErrorControl.ascx" tagname="ErrorControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    
     <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <asp:Panel ID="responsePanel" runat="server" Visible="false" CssClass="alert alert-info alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <asp:Literal runat="server" ID="responseLabel"></asp:Literal>
            </asp:Panel>

            <asp:ValidationSummary ID="pageValidationSummary" runat="server" CssClass="errormsg" ShowMessageBox="True" ShowSummary="False" />

                  <div class="box">
                <div class="box-header">
                    <h2><i class="fa fa-list"></i>Manage Users</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>
                <div class="box-content">
                              

                                   
                  
        <div class="row">
            <uc1:ErrorControl ID="ErrorControl1" runat="server" />
                                   
            <div class="col-md-12 col-lg-12">
         
                       
                                <asp:HiddenField ID="hfPandaID" runat="server" />
                                <div class="table-responsive">
                                    <asp:GridView
                                        ID="gvPandas"
                                        runat="server"
                                        GridLines="None" 
                                        EmptyDataText="This space is empty there is nothing here !!"
                                        EmptyDataRowStyle-CssClass="alert alert-danger text-center"
                                        CssClass="table table-condensed table-responsive table-hover table-striped table-bordered medium-font"
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Full Name</HeaderTemplate>
                                                <ItemTemplate><%# Eval("FullName") %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                            <asp:BoundField DataField="PhoneNumber" HeaderText="Telephone" SortExpression="PhoneNumber" />

                                           <%-- <asp:BoundField DataField="CreatedDate" HeaderText="Date Created" DataFormatString="{0:dd/MM/yy}" ItemStyle-CssClass="text-right" HeaderStyle-CssClass="text-right" SortExpression="CreatedDate" />--%>

                                             <asp:TemplateField HeaderText="Action" >
                                                        <ItemStyle CssClass="text-center"  />
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    
                                                                      <td>
                                                                        <asp:LinkButton ID="btnEdit" CommandArgument='<%#Eval("Id") %>'  ClientIDMode="Static" CausesValidation="False"   OnClick="btnEdit_Click" CssClass="btn btn-xs btn-primary" runat="server"><i class="fa fa-edit"></i>Edit</asp:LinkButton> 
                                                                    </td>
                                                                    <%--<td>
                                                            
                                                              <asp:LinkButton ID="btnDelete"  OnClick="btnDelete_Click" CommandArgument='<%#Eval("Id") %>'   OnClientClick="javascript:return confirm('Are you sure you want to delete this user from the list?');" AlternateText="Delete User" CssClass="btn btn-xs btn-danger" runat="server"><i class="fa fa-trash-o"></i> Delete</asp:LinkButton> 
                          
                                                              </td>--%>
                                                                </tr>
                                                            </table>
                                               
                                                        </ItemTemplate>
                                                      </asp:TemplateField>
                                            
                                        </Columns>
                                        <EmptyDataRowStyle CssClass="alert alert-danger text-center" />
                                    </asp:GridView>
                                </div>
                            </div>

              <div class="col-sm-12" runat="server" visible="false" id="divForm">
                   <div class="col-md-12">
                                       <%--<uc1:ErrorDisplay runat="server" ID="ErrorDisplay2" />--%>
                                        <div class="form-horizontal" role="form" runat="server" id="detailView" >
                     
                                            <div class="form-group" runat="server" >
                                   
                                    <div class="col-sm-10 text-center">
                                           <h2><strong>
                                               <asp:Label ID="lbluseredit" runat="server" Text="Edit User Details"></asp:Label>
                                        </strong>
                                        </h2>
                                    </div>
                                    </div> 
                                <div class="form-group" runat="server" >
                                    <label for="txtFirstName" class="col-sm-3 control-label">Full Name: </label>
                                    <div class="col-sm-5">
                                        <input id="txtFullname"  type="text" class="form-control " ClientIDMode="Static"  runat="server"/>
                                             
                                    </div>  
                                 </div>
                                <div class="form-group" runat="server" >
                                    <label for="txtPhone" class="col-sm-3 control-label">Phone: </label>
                                    <div class="col-sm-5">
                                        <input id="txtPhone"  type="text" class="form-control " ClientIDMode="Static"  runat="server"/>
                                             
                                    </div>  
                                 </div>
                                           
                                           

                                          
                                            <div class="form-group" runat="server" >

                             <div class="form-group" >
                            <div class="col-sm-8 text-right">
                          <asp:Button ID="btnBack" CssClass="btn btn-sm btn-success" runat="server"  Text="<<Back" OnClick="btnBack_Click" />
                           
         
                                 <asp:Button ID="BtnSave" CommandName="Save" CssClass="btn btn-sm btn-success" runat="server"  Text="Submit"  OnClick="BtnSave_Click" CommandArgument="1" />
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
     </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptsContentPlaceHolder" Runat="Server">
</asp:Content>

