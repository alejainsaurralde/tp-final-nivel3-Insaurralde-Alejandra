<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="Catalogo_Web.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Articulos</h1>
    <asp:GridView ID="dgvArticulos" CssClass="table" runat="server"></asp:GridView>
</asp:Content>
