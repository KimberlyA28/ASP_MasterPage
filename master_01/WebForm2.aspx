<%@ Page Title="" Language="C#" MasterPageFile="~/Modelo_01.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="master_01.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="text-center mb-4">Consulta de Usuarios</h1>

        <!-- Formulario de búsqueda -->
        <div class="mb-3">
            <label for="txtBuscar" class="form-label">Buscar por Nombre o Apellido:</label>
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Escriba un nombre o apellido" />
        </div>

        <div class="mb-3">
            <label for="fechaBuscar" class="form-label">Buscar por Fecha de Registro:</label>
            <input type="date" class="form-control" id="fechaBuscar" runat="server" />
        </div>

        <!-- Botón de búsqueda -->
        <asp:Button ID="btn" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click"/>

        <!-- Mensaje de error -->
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

        <!-- GridView para mostrar los usuarios -->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped mt-4" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" SortExpression="FechaRegistro" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>