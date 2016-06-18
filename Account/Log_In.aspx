<%@ Page Title="" enableEventValidation="false" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Log_In.aspx.vb" Inherits="Account_Log_In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <section id="about" class="container login">
        <%=custom.getH1()%>
        <input id="Username" name="username" type="text" placeholder="Username" /><br />
        <input id="Password" name="password" type="password" placeholder="Password"/><br />
        <asp:CheckBox ID="stayLoggedIn" runat="server" Text="Stay logged in"/><br />
        <asp:Button ID="Loginbtn" CssClass="button" runat="server" Text="Login" OnClick="Loginbtn_Click"/>
        <asp:Literal ID="successmsg" runat="server"></asp:Literal>
        <asp:Literal ID="msg" runat="server"></asp:Literal>
    </section>
</asp:Content>