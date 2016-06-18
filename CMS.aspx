<%@ Page Title="" enableEventValidation="false" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CMS.aspx.vb" Inherits="CMS" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <section id="about" class="container CMS">
        <%=custom.getH1()%>
        <%If Session("login") = True Then %>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="list1">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" /> 
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" /> 
                </Triggers>
                <ContentTemplate>
                    <asp:Literal ID="msg" runat="server"></asp:Literal>
                    <input type="text" name="newPageName" placeholder="Insert Page Name" />
                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="Create New Page" OnClick="createPage_Click"/><br />
                    <asp:Literal ID="invisiblePageName" Visible="false" runat="server"></asp:Literal>
                    <asp:DropDownList ID="PageName" runat="server"></asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="Load Text" OnClick="loadPageContent"/>
                    <asp:Button ID="Button4" runat="server" CssClass="button" Text="Delete Page" OnClick="DeletePage_Click"/>
                    <asp:Button ID="Button2" runat="server" CssClass="button" Text="Update Text" OnClick="updatePageContent"/>
                    <div>
                        <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        <%Else %>
            <p>If you are not logged in you may not use the CMS.</p>
            <p>Login <a href="/Account/log_in">here</a></p>
        <%End If %>
    </section>
</asp:Content>