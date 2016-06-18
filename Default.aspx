<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="menu" ContentPlaceHolderID="menu" runat="server">
    <%=custom.generateMenu()%>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="content" runat="server">
    <section id="about" class="container flex">
    <img src="/images/logoAbout.png">
    <div>
        <h1>OUR STORY</h1>
        <p id="aboutP">This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem nibh id elit. Duis sed odio sit amet nibh vulputate cursus
        <br><br>
        Morbi accumsan ipsum velit. Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non  mauris vitae erat consequat auctor eu in elit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.</p>
        <button class="button">LEARN MORE</button>
        </div>
        </section>
</asp:Content>