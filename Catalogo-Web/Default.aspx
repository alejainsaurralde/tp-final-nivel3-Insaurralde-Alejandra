<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>HOLA!</h1>
    <p>"Descubre Tu Próximo Favorito: Catálogo de Productos Exclusivos"</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">


        <%--  LISTAR CON FOREACH--%>
        <%--        <%
            foreach (Dominio.Articulo Art in ListaArticulo)
            {
        %>

        <div class="col">
            <div class="card h-100">
                <img src="<%: Art.ImagenUrl %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: Art.Nombre %></h5>
                    <p class="card-text"><%: Art.Descripcion %></p>
                    <a href="DetalleArticulo.aspx?id=<%: Art.Id %>">Ver detalles</a>
                </div>
                <div class="card-footer">
                    <small class="text-body-secondary">Last updated 3 mins ago</small>
                </div>
            </div>
        </div>

        <%  } %>--%>

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("ImagenUrl")%>" style="width: 150px;" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("id") %>">Ver detalles</a>
                            <%--<asp:Button CssClass="btn btn-primary" runat="server" ID="btnEjemplo" Text="Ejemplo" CommandArgument= '<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEjemplo_Click" />--%>
                        </div>
                        <div class="card-footer">
                            <small class="text-body-secondary">Última actualización hace 3 días</small>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
