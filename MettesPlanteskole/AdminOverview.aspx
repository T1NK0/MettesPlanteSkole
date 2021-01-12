<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.Master" AutoEventWireup="true" CodeBehind="AdminOverview.aspx.cs" Inherits="MettesPlanteskole.AdminOverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-10" style="float: right;">
        <h1 id="overskrift">Dashboard</h1>
        <div class="col-lg-4">
            <div id="header_item_film" class="col-lg-12 box-shadow-overview">
                <a href="Produkter.aspx" class="film_antal">
                    <h1 class="overskrift_overview">Antal Produkter</h1>
                </a>
                <asp:Label ID="Label_Different_Products" runat="server" Text="" CssClass="film_antal antal_style"></asp:Label>
            </div>
        </div>

        <div class="col-lg-4">
            <div id="header_item_genrer" class="col-lg-12 box-shadow-overview">
                <a href="Category.aspx" class="genre_antal">
                    <h1 class="overskrift_overview">Antal Kategorier</h1>
                </a>
                <asp:Label ID="Label_Categorys" runat="server" Text="" CssClass="genre_antal antal_style"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
