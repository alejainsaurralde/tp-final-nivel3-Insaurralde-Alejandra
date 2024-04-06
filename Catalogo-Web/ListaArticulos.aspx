<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="Catalogo_Web.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Articulos</h1>

    <%--    //HACER FUNCIONAR EL UPDATE PANEL//--%>
    <%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div class="row">
        <div class="col-6">
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <div class="mb-3">
                <asp:Label runat="server" Text="Filtrar"></asp:Label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" runat="server"></asp:TextBox>
            </div>
            <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>

    <%--    HACER BOTON DE LIMPIAR FILTRO--%>

    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox Text="FiltroAvanzado" runat="server"
                CssClass="" ID="chkAvanzado"
                AutoPostBack="true"
                OnCheckedChanged="chkAvanzado_CheckedChanged" />
        </div>
    </div>


    <% if (chkAvanzado.Checked)
        {%>
    <div class="row">

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                <asp:DropDownList ID="ddlCampo" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Criterio"></asp:Label>
                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Filtro"></asp:Label>
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>

    </div>

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Filtro" OnClick="btnLimpiar_Click"  CssClass="btn btn-outline-success" />
            </div>
        </div>
    </div>
    <%} %>



    <asp:GridView ID="dgvArticulos" CssClass="table" AutoGenerateColumns="false" runat="server"
        DataKeyNames="Id"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging"
        AllowPaging="true" PageSize="5">

        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
