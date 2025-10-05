<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="Persona.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:TextBox ID="txt_nombre" placeholder="Nombre" runat="server" ></asp:TextBox>
    <asp:TextBox ID="txt_apellido" placeholder="Apellido" runat="server"></asp:TextBox>
    <asp:TextBox ID="txt_edad" placeholder="Edad" runat="server"></asp:TextBox>
    <asp:Button ID="btn_guardar" CssClass="btn btn-primary" runat="server" Text="Button" OnClick="btn_guardar_Click" />
    <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

    <asp:GridView ID="GV_personas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
            <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ll-46ConnectionString %>" SelectCommand="SELECT * FROM [Personas]"></asp:SqlDataSource>
</asp:Content>
