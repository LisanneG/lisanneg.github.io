<%@ Page Title="" enableEventValidation="false" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Accounts.aspx.vb" Inherits="Accounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <%@ Import Namespace="System.Data.OleDb" %>
    <section id="about" class="container">
        <%=custom.getH1() %>
        <asp:DropDownList ID="idlist" runat="server">
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="editbtn" CssClass="button" runat="server" Text="Edit" OnClick="editbtn_Click" />
        <asp:Button ID="removebtn" CssClass="button" runat="server" Text="Remove" OnClick="removebtn_Click" />
        <p>All accounts:</p>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="editbtn" EventName="Click"/>
                <asp:AsyncPostBackTrigger ControlID="removebtn" EventName="click"/>
            </Triggers>
            <ContentTemplate>
                <asp:Literal ID="test" runat="server"></asp:Literal>
                <asp:Repeater id="customers" runat="server">
                    <HeaderTemplate>
                        <table class="table table-striped">
                            <tr>
                                <th>Id</th>
                                <th>Username</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Password</th>
                                <th>Email</th>
                                <th>Orders Made</th>
                                <th>Account Date</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Container.DataItem("Id")%></td>
                            <td><%#Container.DataItem("Username")%></td>
                            <td><%#Container.DataItem("FirstName")%></td>
                            <td><%#Container.DataItem("LastName")%></td>
                            <td><%#Container.DataItem("AccountPass")%></td>
                            <td><%#Container.DataItem("Email")%></td>
                            <td><%#Container.DataItem("OrdersMade")%></td>
                            <td><%#Container.DataItem("AccountDate")%></td>
                            <td></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                <asp:Repeater id="orders" runat="server">
                    <HeaderTemplate>
                        <table class="table table-striped">
                            <tr>
                                <th>Id</th>
                                <th>Person Id</th>
                                <th>Products</th>
                                <th>Order Date</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Container.DataItem("Id")%></td>
                            <td><%#Container.DataItem("Person")%></td>
                            <td><%#Container.DataItem("Products")%></td>
                            <td><%#Container.DataItem("OrderDate")%></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>