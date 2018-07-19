<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ManageStockList.aspx.cs" Inherits="Admin_ManageStockList" %>
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
                    <h2><i class="fa fa-list"></i>Stock List</h2>
                    <div class="box-icon">
                        <a href="#" class="btn-minimize"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>
                <div class="box-content">
                               <div class="row">

                                   
                                          <div class="col-sm-12" runat="server" id="divList">
										
                                               <div class="form-horizontal" role="form" runat="server" id="Div1">
                                              <div class="form-group">
                                                     <div class="col-sm-12 text-right">
                                                 
                                                         <uc1:ErrorControl ID="ErrorControl1" runat="server" />
                                              </div>
                                              </div>
                                               
                                          
                                           <asp:GridView ID="grdStock" ShowHeaderWhenEmpty="true"  EmptyDataRowStyle-CssClass="text-center" EmptyDataText="No record to display" CssClass="table table-condensed table-responsive table-hover table-striped table-bordered medium-font" AutoGenerateColumns="False" runat="server" >
                                                  <Columns>
                                                     
                                                       <asp:TemplateField HeaderText="Sn">
                                                         <ItemTemplate>
                                                             <%# Container.DataItemIndex + 1 %>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                      
                                                      <asp:BoundField DataField="Name" HeaderText=" Name" />
                                                       <asp:BoundField DataField="Code" HeaderText=" Barcode" />
                                                       <asp:TemplateField HeaderText="Company Name">
                                                        <HeaderStyle CssClass="text-left" />
                                                        <ItemStyle CssClass="text-left" />
                                                        <ItemTemplate>
                                                         <%# DataBinder.Eval(Container.DataItem,"Vendour.CompanyName")%>
                                                       
                                                        </ItemTemplate>
                                                       </asp:TemplateField>

                                                      <asp:TemplateField HeaderText="Category">
                                                        <HeaderStyle CssClass="text-left" />
                                                        <ItemStyle CssClass="text-left" />
                                                        <ItemTemplate>
                                                         <%# DataBinder.Eval(Container.DataItem,"Category.Name")%>
                                                       
                                                        </ItemTemplate>
                                                       </asp:TemplateField>
                                                      <asp:BoundField DataField="Description" HeaderText=" Description" />
                                                      
                                                    
                                                        <asp:TemplateField HeaderText="Action" >
                                                        <ItemStyle CssClass="text-center"  />
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                   
                                                                      <td>
                                                                        <asp:LinkButton ID="btnEdit" CommandArgument='<%#Eval("StockId") %>'  ClientIDMode="Static" CausesValidation="False"   OnClick="btnEdit_Click" CssClass="btn btn-xs btn-primary" runat="server"><i class="fa fa-edit"></i>Edit</asp:LinkButton> 
                                                                    </td>
                                                                      <td>
                                                                        <asp:LinkButton ID="btnView" CommandArgument='<%#Eval("StockId") %>'  ClientIDMode="Static" CausesValidation="False" OnClick="btnView_Click" CssClass="btn btn-xs btn-info" runat="server"><i class="fa fa-edit"></i>Edit</asp:LinkButton> 
                                                                    </td>
                                                                    <td>
                                                            
                                                              <asp:LinkButton ID="btnDelete"  OnClick="btnDelete_Click" CommandArgument='<%#Eval("StockId") %>'   OnClientClick="javascript:return confirm('Are you sure you want to delete this student from the list?');" AlternateText="Delete Student" CssClass="btn btn-xs btn-danger" runat="server"><i class="fa fa-trash-o"></i> Delete</asp:LinkButton> 
                          
                                                              </td>
                                                                </tr>
                                                            </table>
                                               
                                                        </ItemTemplate>
                                                      </asp:TemplateField>
                                                     
                                                  </Columns>
                                              </asp:GridView>
                                           </div>
                                               </div> 
                                          
                 <div class="col-sm-12" runat="server" visible="false" id="divForm">
                   <div class="col-md-12">
                                       <uc1:ErrorControl ID="ErrorControl2" runat="server" />
                                      
                                                                        <div class="form-horizontal" role="form" runat="server" id="detailView" >
                     
                                            <div class="form-group" runat="server" >
                                   
                                    <div class="col-sm-10 text-center">
                                           <h2><strong>
                                               <asp:Label  runat="server" Text="Update Stocks"></asp:Label>
                                        </strong>
                                        </h2>
                                           <uc1:ErrorControl ID="ErrorControl3" runat="server" />
                                    </div>
                                    </div> 
                                   <div class="form-group" runat="server" >
                                    <label for="txtDrugs" class="col-sm-3 control-label">Name *</label>
                                    <div class="col-sm-5">
                                        <input id="txtName"  type="text" class="form-control "  runat="server"/>
                                        
                                       
                           
                                    </div>
                                    </div>  
                            <div class="form-group">
                                <label runat="server" id="Label1" class="col-sm-3 control-label" >Category *</label>
                                      <div class="col-sm-5">
                                <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control" ></asp:DropDownList>
                                          </div>
                            </div>
                                 <div class="form-group">
                                 <label for="txtBarcode" class="col-sm-3 control-label">Barcode </label>
                                  <div class="col-sm-5">
                                  <asp:TextBox ID="txtBarcode" CssClass="form-control "  runat="server">
                                   </asp:TextBox>
                                
                                   </div>
                                 </div>
                                   <div class="form-group">
                                 <label for="txtDescription" class="col-sm-3 control-label">Description </label>
                                  <div class="col-sm-5">
                                  <asp:TextBox ID="txtDescription" CssClass="form-control " TextMode="MultiLine" runat="server">
                                   </asp:TextBox>
                                
                                   </div>
                                 </div>
                                       
                          
                            <div class="form-group">
                                <label runat="server" class="col-sm-3 control-label"  id="lblBank" >Vendor</label>
                                 <div class="col-sm-5">
                                <asp:DropDownList runat="server" ID="ddlVendor" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                                   <div class="form-group" style="margin-left:auto;margin-right:auto;" >
                               
                                <div class="col-sm-4">
                                    &nbsp;
                                    </div>
                                 <div class="col-sm-8">
                                    <label for="filImage">
                                        
                                       
                                       <span id="lblLogo" runat="server">
                                            Click to upload image
                                        </span>  
                                       <asp:Image style="display:block"    ImageUrl="../assets/img/upload.png" id="UpLoadedPhoto" width="150" height="150" runat="server" clientidmode="Static" />
                                     
                                    
                                    </label>
                                     
                                 </div>
                                 
                                    <div style="display:none;" >
                                        <asp:FileUpload runat="server" ID="filImage" ClientIDMode="Static" onchange="ShowImagePreview(this);" ></asp:FileUpload>
                                    </div>
                         </div> 
                                
                             <div class="form-group">
                            <div class="col-sm-8 text-right">
                          <asp:Button ID="btnBack" CommandName="Save" CssClass="btn btn-sm btn-success" runat="server" OnClick="btnBack_Click"  Text="<<Back"  CommandArgument="1"/>
                           
                          
                                <asp:Button ID="BtnCancel" CssClass=" btn btn-sm btn-danger" runat="server" Text="Cancel" />
                                 <asp:Button ID="BtnSave" CommandName="Save" CssClass="btn btn-sm btn-success" runat="server"  Text="Add Stock" OnClick="BtnSave_Click"   CommandArgument="1"/>
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
       <script>

          function ShowImagePreview(input) {
              if (input.files && input.files[0]) {


                  if (!(/\.(gif|GIF|jpg|JPG|jpeg|JPEG|png|PNG|bmp|BMP)$/i).test(input.value)) {

                      if ($.browser.msie) {
                          $('#filImage').replaceWith($('#filImage').clone());
                      } else {
                          $('#filImage').val('');
                      }

                      alert('Invalid Image ');
                      return;
                  }


                  var reader = new FileReader();
                  reader.onload = function (e) {
                      $("#UpLoadedPhoto").show();
                      $("#lblLogo").hide();

                      $("#UpLoadedPhoto").attr('src', e.target.result);


                  };

                  reader.readAsDataURL(input.files[0]);
              }
          }

 </script>
</asp:Content>

