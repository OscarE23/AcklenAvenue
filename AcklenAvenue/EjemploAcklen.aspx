<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EjemploAcklen.aspx.cs" Inherits="AcklenAvenue.EjemploAcklen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="shortcut icon" href="img/Logotipo.png"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet">
<link href="css/EstilosAbc.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<form id="Form1" runat="server">

<div id="ContenedorPrincipal">
    
    
        <%--GRID VIEW--%>
    <div id="viewGrid" runat="server">
        <h3>Registrar producto</h3><br />
         <div class="row">
            <div class="col-lg-2">
                <asp:Label ID="lblAgregar" runat="server" Text="Agregar"></asp:Label><br />
                <%--<button type="button" id="btnAgregar" class="btn btn- btn-primary">Agregar</button>--%>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                    class="btn btn- btn-primary" onclick="btnAgregar_Click"/>
            </div>

             <div class="col-lg-10">
                <asp:Label ID="lblbuscar" runat="server" Text="Buscar"></asp:Label>
                 <input type="type" name="Buscar" placeholder="Escribir" value="" id="Buscar" class="form-control" />
            </div>
             </div><br />
            
            <div class="row">
                <div  class="divGrid">
                    <asp:GridView ID="dgvProductos" runat="server" CssClass="table"
                       AutoGenerateColumns="False" onrowcommand="dgvProductos_RowCommand">
                       <Columns>
                          <asp:BoundField DataField="Id" HeaderText="ID">
                          </asp:BoundField>
                          <asp:BoundField DataField="Nombre" HeaderText="NOMBRE">
                          </asp:BoundField>
                          <asp:BoundField DataField="Precio" HeaderText="PRECIO">
                          </asp:BoundField>
                          <asp:BoundField DataField="Existencia" HeaderText="EXISTENCIA">
                          </asp:BoundField>
                          <%--<asp:ButtonField ButtonType="Button" HeaderText="EDITAR" CommandName="Update" Text="Editar">
                             <ControlStyle CssClass="btn btn-primary" Width="90px"  />
                          </asp:ButtonField>
                          <asp:ButtonField ButtonType="Button" HeaderText="ELIMINAR" CommandName="Delete" Text="Eliminar">
                             <ControlStyle CssClass="btn btn-danger" Width="90px"  />
                          </asp:ButtonField>--%>
                          <asp:TemplateField HeaderText="EDITAR">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditar" runat="server" ToolTip="Editar" class="btn btn-primary" Height="35px" Width="90px" CommandName="Editar" CommandArgument="<% # Container.DataItemIndex%>" >
                                    <i class="glyphicon glyphicon-trash" style="color:#FFFFFF">Editar</i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" Height="25px" />
                                <ItemStyle Width="15%" Height="35px"  />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="¿ELIMINAR?">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEliminar" runat="server" ToolTip="Editar" class="btn btn-danger" Height="35px" Width="90px" CommandName="Eliminar" OnClientClick="return confirm('¿Desea eliminar?');" CommandArgument="<% # Container.DataItemIndex%>" >
                                    <i class="glyphicon glyphicon-trash" style="color:#FFFFFF">Eliminar</i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" Height="25px" />
                                <ItemStyle Width="15%" Height="35px"  />
                        </asp:TemplateField>

                       </Columns>
                    </asp:GridView>
                    </div>
                </div>
            </div>


        <%--CAMPOS--%>
        <div id="viewCampos" runat="server">
        <h3>Registrar producto</h3><br />
            <div class="container well">
                <div class="row">
                    <div class="col-lg-2">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" MaxLength="50" autocomplete="off" ></asp:TextBox>

                    </div>
                    <div class="col-lg-2">
                        <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtPrecio" runat="server" class="form-control" MaxLength="50" autocomplete="off" ></asp:TextBox>
                    </div>
                </div><br />
                
                <div class="row">
                    <div class="col-lg-2">
                        <asp:Label ID="lblExistencia" runat="server" Text="Existencia"></asp:Label>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtExistencia" runat="server" class="form-control" MaxLength="50" autocomplete="off" ></asp:TextBox>

                    </div>
                    <div class="col-lg-2">
                        
                    </div>
                    <div class="col-lg-4">
                    </div>
                </div><br />
                
                
                <div class="row">
                    <div class="col-lg-7">
                    </div>
                    <div class="col-md-2">
                        <%--<button type="button" id="btnRegresar" class="btn btn- btn-danger">Regresar</button>--%>
                        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" 
                            class="btn btn- btn-danger" onclick="btnRegresar_Click"/>
                    </div>
                    <div class="col-md-2">
                        <button type="button" id="btnGuardar" class="btn btn- btn-success">Guardar</button>
                    </div>
                </div><br /><br />
            </div>
        </div>
        
    </div>

    </form>

    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="js/EjemploABC.js" type="text/javascript"></script>
    <script src="js/messi.js" type="text/javascript"></script>
    <link href="css/messi.css" rel="stylesheet" type="text/css"/>
    <script src="js/BuscarProducto.js" type="text/javascript"></script>
</asp:Content>
