<%@ Page Title="" EnableEventValidation="false" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Template.aspx.vb" Inherits="Template" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <section id="about" class="container">
        <%=custom.getH1()%>
        <%=custom.getContent()%>
    </section>
</asp:Content>

