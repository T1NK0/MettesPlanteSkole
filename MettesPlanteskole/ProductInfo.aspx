<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="ProductInfo.aspx.cs" Inherits="MettesPlanteskole.ProductInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-6">
        <h3>Kurven</h3>
        <hr class="hr" />

        <div class="col-lg-12">
            <asp:Repeater ID="Repeater_VisVare" runat="server" OnItemCommand="Repeater_VisVare_ItemCommand">
                <ItemTemplate>
                    <h1><%#Eval ("product_name") %></h1>
                    <asp:HiddenField ID="HiddenField_Name" runat="server" Value='<%#Eval ("product_name") %>'/>
                    <img src='images/resizer/Croppede/<%#Eval ("product_image_1") %>' /><img style="margin-left:25px;" src='images/resizer/Croppede/<%#Eval ("product_image_2") %>' /><img style="margin-left:25px;" src='images/resizer/Croppede/<%#Eval ("product_image_3") %>' />
                    <p><%#Eval ("product_description") %></p>
                    <div class="col-lg-6">
                        <h4 class="info_overskrift">Jordtype:</h4>
                        <p><%#Eval ("product_recomended_dirt") %></p>
                        <h4 class="info_overskrift">Dyrkningstid:</h4>
                        <p><%#Eval ("product_growthtime") %></p>
                        <h4 class="info_overskrift">Varenummer:</h4>
                        <p><%#Eval ("product_number") %></p>
                        <asp:HiddenField ID="HiddenField_Id" runat="server" Value='<%#Eval ("product_id") %>'/>
                        <a href="Shoppingcart.aspx?category_id=<%#Eval("category_id") %>" class="btn btn-success">Tilbage</a>
                    </div>
                    <div id="buy_now" class="col-lg-6">
                        <div class="col-lg-6" id="Buy_box">
                            <div id="header" class="col-lg-12">
                                <p>Køb Nu</p>
                            </div>
                            <p>Pris: <%#Eval ("product_price") %>,-</p>
                            <asp:HiddenField ID="HiddenField_Pris" runat="server" Value='<%#Eval ("product_price") %>'/>
                            <p>Antal:</p>
                            <asp:TextBox ID="TextBox_Antal" runat="server"></asp:TextBox>
                            <asp:Button ID="Button_AddToBasket" CssClass="btn_AddToBasket" CommandName="AddToBasket" CommandArgument='<%#Eval ("product_number") %>' runat="server" Text="Tilføj Til Kurv"/>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_Repeater_Tilbage_Knap" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT category.*, products.* FROM category INNER JOIN products ON category.category_id = products.FK_category_id"></asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
