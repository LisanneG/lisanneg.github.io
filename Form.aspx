<%@ Page enableEventValidation="false" Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Form.aspx.vb" Inherits="Form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <section id="about" class="container">
        <%=custom.getH1()%>
    <h2>Question List</h2>
    <p>If one of the statements are true to u, select the checkbox.</p>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="list1">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" /> 
        </Triggers>
        <ContentTemplate>
            <asp:CheckBoxList ID="CheckBoxList1" RepeatLayout="table" runat="server" Visible="true">
                <asp:ListItem Value="18">I am older than 18 years old</asp:ListItem>
                <asp:ListItem Value="civ">I like the game CIV 5</asp:ListItem>
                <asp:ListItem Value="dishonored">I like the game Dishonored</asp:ListItem>
                <asp:ListItem Value="gta">I like the game GTA V</asp:ListItem>
                <asp:ListItem Value="zelda">I like the game Zelda</asp:ListItem>
                <asp:ListItem Value="conker">I like the game Conker's bad fur day</asp:ListItem>
            </asp:CheckBoxList>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="button" Visible="true" />
            <asp:Literal ID="answers" runat="server"></asp:Literal>
        </ContentTemplate>
    </asp:UpdatePanel>
    </section>
</asp:Content>