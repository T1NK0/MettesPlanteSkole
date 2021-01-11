<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Shoppingcart.aspx.cs" Inherits="MettesPlanteskole.Shoppingcart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-6">
        <h3>Kurven</h3>
        <hr />
        <div class="col-lg-12" id="del_2">
            <h3>Produkter</h3>
            <table class="table" style="margin-bottom: 0px;">
                <thead>
                    <tr>
                        <th class="col-lg-2">ProduktNummer</th>
                        <th class="col-lg-2">ProduktNavn</th>
                        <th class="col-lg-2">Pris</th>
                        <th class="col-lg-2">Antal</th>
                        <th class="col-lg-2">Køb</th>
                        <th class="col-lg-2">Info</th>
                    </tr>
                </thead>
            </table>
            <asp:Repeater ID="Repeater_vare" runat="server" OnItemCommand="Repeater_vare_ItemCommand">
                <ItemTemplate>
                    <table class="table" style="margin-bottom: 0px;">
                        <tbody>
                            <tr>
                                <td class="col-lg-2">
                                    <asp:HiddenField ID="HiddenField_produktid" runat="server" Value='<%#Eval("product_id") %>' />
                                    <%#Eval("product_number") %></td>
                                <td class="col-lg-2">
                                    <asp:HiddenField ID="HiddenField_navn" runat="server" Value='<%#Eval("product_name") %>' />
                                    <%#Eval("product_name") %></td>
                                <td class="col-lg-2">
                                    <asp:HiddenField ID="HiddenField_pris" runat="server" Value='<%#Eval("product_price") %>' />
                                    <%#Eval("product_price") %></td>
                                <td class="col-lg-2"><%#Eval("product_storage") %></td>
                                <td class="col-lg-2">
                                    <asp:LinkButton ID="LinkButton_Buy" runat="server" class="btn btn-success" CommandArgument='<%#Eval("product_number") %>' CommandName="PutIKurv"><i class="fa fa-shopping-bag" aria-hidden="true"></i></asp:LinkButton></td>
                                <td class="col-lg-2">
                                    <a href="ProductInfo.aspx?product_id=<%#Eval("product_id") %>" class="btn btn-success"><i class="fa fa-info" aria-hidden="true"></i></td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
