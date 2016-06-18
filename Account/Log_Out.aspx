<%@ Page Title="" EnableEventValidation="false" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Log_Out.aspx.vb" Inherits="Account_Log_Out" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <section id="about" class="container logout">
        <%=custom.getH1()%>
        <p>Would you like to log out?</p>
        <asp:Button ID="logout" CssClass="button" runat="server" Text="Logout" OnClick="logout_Click"/>
        <asp:Literal ID="msg" runat="server"></asp:Literal>
    </section>
</asp:Content>