<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Catalogo_Web.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <div class="row">
    <div class="col-4">
        <h2>Login 🌞</h2>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox CssClass="form-control" placeholder="User Mail" ID="txtEmail" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox CssClass="form-control" ID="txtPassword" placeholder="******" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnLogin" CssClass="btn btn-primary" OnClick="btnLogin_Click" runat="server" Text="Ingresar" />
        <a href="/">Cancelar</a>
    </div>
</div>

</asp:Content>
