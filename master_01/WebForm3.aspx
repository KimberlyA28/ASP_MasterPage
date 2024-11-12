<%@ Page Title="" Language="C#" MasterPageFile="~/Modelo_01.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="master_01.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <PackageReference Include="itext7.bouncy-castle-adapter" Version="8.0.5" />
    <PackageReference Include="BouncyCastle.Cryptography" Version="2.2.1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Vista Previa y Exportación de Datos</h1>

    <!-- Dropdown para seleccionar la tabla -->
    <div class="mb-3">
        <label for="ddlTablas" class="form-label">Seleccionar Tabla</label>
        <asp:DropDownList ID="ddlTablas" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTablas_SelectedIndexChanged">
            <asp:ListItem Text="Usuarios" Value="Usuarios" />
            <asp:ListItem Text="Mantenimiento" Value="Mantenimiento" />
        </asp:DropDownList>
    </div>

    <!-- GridView para mostrar los datos -->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" CssClass="table table-striped mt-4" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" Visible="False" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" Visible="False" />
            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" SortExpression="FechaRegistro" Visible="False" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="False" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" Visible="False" />
        </Columns>
    </asp:GridView>

    <!-- Botones para exportar -->
    <asp:Button ID="btnExportarUsuarios" runat="server" Text="Exportar Usuarios" OnClick="btnExportar_Click" CssClass="btn btn-success mt-3" Visible="False" />
    <asp:Button ID="btnExportarMantenimiento" runat="server" Text="Exportar Mantenimiento" OnClick="btnExportarMantenimiento_Click" CssClass="btn btn-success mt-3" Visible="False" />
</asp:Content>
