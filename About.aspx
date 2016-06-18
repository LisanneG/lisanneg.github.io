<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="About.aspx.vb" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <section id="about" class="container">
        <%=custom.getH1()%>
        <asp:Repeater id="content" runat="server">
            <ItemTemplate>
                <p><%#Container.DataItem("contentText")%></p>
            </ItemTemplate>
        </asp:Repeater>
    </section>
</asp:Content>