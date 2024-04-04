<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Catalogo_Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="row">
      <div class="col-4">
          <h2>Registrate ya! 😊</h2>
          <div class="mb-3">
              <label class="form-label">Email</label>
              <asp:TextBox CssClass="form-control" placeholder="User Mail" ID="txtEmail" runat="server"></asp:TextBox>
          </div>
          <div class="mb-3">
              <label class="form-label">Password</label>
              <asp:TextBox CssClass="form-control" ID="txtPassword" placeholder="******" TextMode="Password" runat="server"></asp:TextBox>
          </div>
          <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" runat="server" Text="Registrarse" />
          <a href="/">Cancelar</a>
      </div>
  </div>

</asp:Content>
