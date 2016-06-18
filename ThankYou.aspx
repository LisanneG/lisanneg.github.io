<%@ Page Title="" enableEventValidation="false" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ThankYou.aspx.vb" Inherits="ThankYou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <script runat="server">
    </script>
    <section id="about" class="container">
        <h1 class="contentH1">Thank You</h1>
        <h2>Thank you for your order!</h2>
        <p>We will send a confirm letter to your email</p>
        <asp:Button ID="ButtonMail" CssClass="button" runat="server" Text="Button"/>
    </section>
</asp:Content>