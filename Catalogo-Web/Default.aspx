<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>HOLA!</h1>
    <p>"Descubre Tu Próximo Favorito: Catálogo de Productos Exclusivos"</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%
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

        <%  } %>
    </div>
</asp:Content>
