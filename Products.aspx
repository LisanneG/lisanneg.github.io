<%@ Page Title="" enableEventValidation="false" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Products.aspx.vb" Inherits="Products" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menu" Runat="Server"><%=custom.generateMenu()%></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <section id="about" class="container">
        <%=custom.getH1() %>
                 <asp:ScriptManager runat="server"></asp:ScriptManager>
                 <asp:UpdatePanel runat="server" ID="selectedChange">
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="CheckBoxList2" EventName="SelectedIndexChanged" />
                         <asp:AsyncPostBackTrigger ControlID="buyNowButton" EventName="Click" />
                     </Triggers>
                    <ContentTemplate>
                            <div class="flex products">
                                <asp:PlaceHolder ID="buyProducts" runat="server" Visible="true">
                                <div>
                                    <h2>Items</h2>
                                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" OnSelectedIndexChanged="products_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="10">Monitor</asp:ListItem>
                                        <asp:ListItem Value="5">Phone</asp:ListItem>
                                        <asp:ListItem Value="60">Laptop</asp:ListItem>
                                        <asp:ListItem Value="84">Computer</asp:ListItem>
                                        <asp:ListItem Value="24">Mouse</asp:ListItem>
                                        <asp:ListItem Value="52">Keyboard</asp:ListItem>
                                        <asp:ListItem Value="51">USB</asp:ListItem>
                                        <asp:ListItem Value="3">HD TV</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                                </asp:PlaceHolder>
                                <asp:PlaceHolder ID="thankYouMail" runat="server" Visible="false">
                                    <div id="thankYouForm">
                                        <input name="sendEmail" type="text" placeholder="Email" /><br />
                                        <input type="tel" placeholder="Phone Number"/><br />
                                        <textarea name="comment" placeholder="Your Message ..."></textarea><br />
                                        <asp:CheckBox ID="updateMail" runat="server" Text=" Keep me updated of the latest products" Checked="true"/><br />
                                        <asp:CheckBox ID="termsAndConditions" runat="server" Text=" I agree with the Terms & Conditions"/><br />
                                        <asp:Button ID="sendMail" runat="server" CssClass="button" Text="Send"/>
                                        <asp:Literal ID="errorMail" runat="server"></asp:Literal>
                                    </div>
                                </asp:PlaceHolder>
                                <div>
                                    <h2>Selected Items</h2>
                                    <ul>
                                        <asp:Literal ID="testAnswers" runat="server">None</asp:Literal>
                                    </ul>
                                    <p>Total: <asp:Literal ID="total" runat="server">0</asp:Literal></p>
                                    <asp:Button ID="buyNowButton" CssClass="button" runat="server" Text="Buy Now" Visible="false" OnClick="BuyNow"/>
                                </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
    </section>
</asp:Content>