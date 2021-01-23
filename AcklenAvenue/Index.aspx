<%@ Page Title="Iniciar Sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AcklenAvenue.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/EstilosFormulario.css" rel="stylesheet" type="text/css" />
    <link href="css/EstilosLogin.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="img/Logotipo.png"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<%--INICIAR SESION--%>
<form runat="server">

<div id="IniciarSesion">
    <div class="imgcontainer">
    <img src="img/Logotipo.png" class="avatar">
    </div>

    <div class="container">
    <label for="Usuario"><b>Usuario</b></label>
    <asp:TextBox ID="txtUsuario" runat="server" placeholder="Ingresar usuario" required autocomplete="off"></asp:TextBox>

    <label for="Contraseña"><b>Contraseña</b></label>
    <asp:TextBox ID="txtContraseña" type="password" runat="server" placeholder="Ingresar contraseña" required></asp:TextBox>

    <button type="submit" id="btnIiniciar">Iniciar Sesión</button>

        <%--<a id="CrearCuenta" href="#">Crear cuenta</a>--%>
        <%--<asp:LinkButton Text="text" href="#" id="CrearCuenta" runat="server">Crear cuenta</asp:LinkButton>--%>
        <button type="button" id="CrearCuenta" class="btn btn-secondary">Crear cuenta</button>

    </div>
</div>

<%--FORMULARIO DE REGISTRO--%>
<div id="FormularioRegistro">
   <div class="imgcontainer">
    <img src="img/Logotipo.png" class="avatar">
    </div>

    <div class="form-group">
      <label for="Nombre">Nombre:</label>
      <asp:TextBox ID="txtNombre" runat="server" placeholder="Ingresar nombre" required autocomplete="off"></asp:TextBox>
    </div>

    <div class="form-group">
      <label for="Apellidos">Apellidos:</label>
      <asp:TextBox ID="txtApellidos" runat="server" placeholder="Ingresar apellidos" required autocomplete="off"></asp:TextBox>
    </div>
    
   <div class="form-group">
      <label for="Usuario">Usuario:</label>
      <asp:TextBox ID="txtNuevoUsuario" runat="server" placeholder="Ingresar usuario" required autocomplete="off"></asp:TextBox>
    </div>

    <div class="form-group">
      <label for="Contraseña">Contraseña:</label>
      <asp:TextBox ID="txtNuevaContraseña" type="password" runat="server" placeholder="Ingresar contraseña" required autocomplete="off"></asp:TextBox>
    </div>

    <%--<asp:Button ID="btnRegistrar" type="submit" class="btn btn-success" runat="server" Text="Registrar" />--%>
    <button type="submit" id="btnRegistrar" class="btn btn-success">Registrar</button>
    <button type="submit" id="btnRegresar" class="btn btn-danger">Regresar</button>
</div>
</form>

<script src="js/jquery-1.9.1.js" type="text/javascript"></script>
<script src="js/InicioSesion.js" type="text/javascript"></script>
<script src="js/messi.js" type="text/javascript"></script>
<link href="css/messi.css" rel="stylesheet" type="text/css" />

</asp:Content>
