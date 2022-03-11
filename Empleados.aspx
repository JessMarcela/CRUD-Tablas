﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="ProyectoFinal.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Blog Start -->
            <div class="blog">
                <div class="container">
                     <center>
                    <div class="section-header">
                        <h2>Empleados por empresa</h2>
                    </div>
                    
                    <div class="row blog-page">
                       
                  </div>
                          </center> 
                    <div class="blog-item">
                            <center>

                                 <div class="col-lg-4 col-md-6 blog-item">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNit" runat="server"  class="form-control" placeholder="Identificación"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn" Text="CONSULTAR" Font-Bold="True" Font-Names="Lucida Handwriting" ForeColor="#FF9900"/> 
                                    </div>
 
                              
                        </div>

                                <asp:GridView ID="datos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                      </asp:GridView>
                            </center> 
                                 <div class="section-header">
                                     <h2>Tabla Empleados</h2>
                                 </div>   
                        </div>
                     <div class="row blog-page">
                        <div class="col-lg-4 col-md-6 blog-item">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtIdentificacion" runat="server"  class="form-control" placeholder="Identificación"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNombre" runat="server"  class="form-control" placeholder="Nombre" ></asp:TextBox>
                                    </div>
                                   
                                    <div class="form-group">
                                         <asp:TextBox ID="txtApellido" runat="server"  class="form-control" placeholder="Apellido" ></asp:TextBox>
                                    </div>
                                <div class="form-group">
                                     <asp:TextBox ID="txtEdad" runat="server"  class="form-control" placeholder="Edad" ></asp:TextBox>
                                    </div>
                             <div class="form-group">
                                     <asp:TextBox ID="txtEmpresa" runat="server"  class="form-control" placeholder="Nit Empresa" ></asp:TextBox>
                                    </div>
                        </div>
                        <div class="col-lg-4 col-md-6 blog-item">
                             
                                  
                            <div class="form-group">
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" class="btn" Text="CONSULTAR" Font-Bold="True" Font-Names="Lucida Handwriting" ForeColor="#FF9900"/> 
                             </div>
                            <div class="form-group">    
                                <asp:Button ID="Button4" runat="server" OnClick="Button3_Click" class="btn" Text="ELIMINAR" Font-Bold="True" Font-Names="Lucida Handwriting" ForeColor="#FF9900"/> 
                            </div>
                         <div class="form-group">     
                              <asp:Button ID="Button5" runat="server" OnClick="Button4_Click" class="btn" Text="ACTUALIZAR" Font-Bold="True" Font-Names="Lucida Handwriting" ForeColor="#FF9900"/>
                            </div>
                         <div class="form-group">     
                            <asp:Button ID="Button6" runat="server" OnClick="Button5_Click" class="btn" Text="AGREGAR" Font-Bold="True" Font-Names="Lucida Handwriting" ForeColor="#FF9900"/>
                                    </div>
                       
                                
                        </div>
                  </div>
            </div>
                
           </div>
            <!-- Blog End -->
        

</asp:Content>
