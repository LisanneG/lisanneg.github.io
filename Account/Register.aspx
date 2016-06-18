<%@ Page Title="Register" EnableEventValidation="false" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.vb" Inherits="Account_Register" %>

<asp:Content runat="server" ID="menu" ContentPlaceHolderID="menu"><%=custom.generateMenu()%></asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="content">
    <section id="about" class="container register">
        <%=custom.getH1()%>
        <asp:Literal ID="msg" runat="server"></asp:Literal>
        <p>Register here:</p>
        <label>Username *</label><br /><input name="username" type="text" placeholder="Username" required /><br />
        <label>First Name *</label><br /><input name="firstName" type="text" placeholder="First Name" required/><br />
        <label>Last Name *</label><br /><input name="lastName" type="text" placeholder="Last Name" required/><br />
        <label>Email *</label><br /><input name="email" type="text" placeholder="Email" required/><br />
        <label>Password *</label><br /><input name="password" type="password" placeholder="Password" required/><br />
        <asp:CheckBox ID="termsAndConditions" runat="server" Text=" I agree with the Terms & Conditions"/><br />
        <asp:Button ID="submit" runat="server" Text="Register" CssClass="button" OnClick="submit_Click" />
    </section>
</asp:Content>