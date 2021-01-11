<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Samlede_ordrer.aspx.cs" Inherits="MettesPlanteskole.Samlede_ordrer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="col-lg-6">
        <asp:GridView ID="GridView_VisVare" CssClass="Grid table" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="GridView_VisVare_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="varenavn" HeaderText="Navn" SortExpression="navn"></asp:BoundField>
                <asp:BoundField DataField="antal" HeaderText="Antal" SortExpression="antal"></asp:BoundField>
                <asp:BoundField DataField="pris" HeaderText="Pris" SortExpression="pris"></asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                Der er ingen vare i kurven
            </EmptyDataTemplate>
        </asp:GridView>

        <div>
            <h3>Moms:
                    <asp:Label ID="Label_Moms" runat="server" Text=""></asp:Label>Kr.</h3>
            <h3>Fragt:</h3>
            <div class="dropdown">
                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">Vælg fragt metode
                <span class="caret"></span>
                </asp:LinkButton>
                <ul class="dropdown-menu">
                    <li><a href="#">PostDanmark</a></li>
                    <li><a href="#">GLS</a></li>
                    <li class="divider"></li>
                    <li><a href="#">Hen på det lokale posthus</a></li>
                </ul>
            </div>
            <h3>Pris i alt:
                    <asp:Label ID="Label_PrisIAlt" runat="server" Text=""></asp:Label>Kr.</h3>
        </div>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton_CheckUd" runat="server" class="btn btn-success" OnClick="LinkButton_CheckUd_Click">Check Ud <i class="fa fa-shopping-cart" aria-hidden="true"></i></asp:LinkButton>
        <asp:LinkButton ID="LinkButton_PDF" runat="server" CssClass="btn btn-primary" OnClick="LinkButton_PDF_Click">Print Pdf </asp:LinkButton>
        <asp:SqlDataSource ID="SqlDataSource_alt" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT products.*, OrdreLinjer.*, Ordrer.*, users.* FROM users INNER JOIN Ordrer ON users.user_id = Ordrer.FK_kunde_id INNER JOIN Produkter INNER JOIN OrdreLinjer ON products.product_id = OrdreLinjer.FK_produkt_id ON Ordrer.ordre_id = OrdreLinjer.FK_ordre_id"></asp:SqlDataSource>
    </div>
</asp:Content>
