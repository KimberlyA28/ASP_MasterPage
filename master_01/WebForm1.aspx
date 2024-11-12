<%@ Page Title="" Language="C#" MasterPageFile="~/Modelo_01.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="master_01.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Estilos/Style1.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ejemplo 1 de Página Maestra - Manteniminto de Tabla de Almacen</h1>
    <!-- Slider -->
    <div class="slider">
        <div class="slides">
            <div class="slide">
                <img src="img/archivos.png" alt="Proyecto 1" class="slider-img" />
                <p>Proyecto 1 - Compartir Archivos</p>
            </div>
            <div class="slide">
                <img src="img/formulario-pc.png" alt="Proyecto 2" class="slider-img" />
                <p>Proyecto 2 - Mandar Email</p>
            </div>
            <div class="slide">
                <img src="img/crud.jpg" alt="Proyecto 3" class="slider-img" />
                <p>Proyecto 3 - CRUD con ASP</p>
            </div>
        </div>
    </div>

    <!-- Mantenimiento de tabla -->
    <div class="mantenimiento">
        <h2>Administrar Registros</h2>

        <!-- Tabla para mostrar los registros de la base de datos -->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
    OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
    OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" 
    DataKeyNames="ID"
    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
        
        <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
                <%# Eval("Nombre") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtNombreEdit" runat="server" Text='<%# Eval("Nombre") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Descripcion">
            <ItemTemplate>
                <%# Eval("Descripcion") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDescripcionEdit" runat="server" Text='<%# Eval("Descripcion") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>



        <!-- Formulario para agregar o editar registros -->
        <div>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" />
            <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripción" />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </div>
</asp:Content>
