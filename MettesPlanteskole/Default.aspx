<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MettesPlanteskole.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="main_center" class="col-lg-6">
        <div class="col-lg-12">
            <h3>Kassen</h3>
            <hr class="hr" />
            <asp:Repeater ID="RepeaterWelcome" runat="server" DataSourceID="SqlDataSourceWelcome">
                <ItemTemplate>
                    <h1>Velkommen til Mettes planteskole</h1>
                    <img src='images/frontpage/<%#Eval ("page_images") %>' />
                    <h3><%#Eval ("page_headings") %></h3>
                    <p><%#Eval ("page_text") %></p>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSourceWelcome" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [pages]"></asp:SqlDataSource>
        </div>

        <div style="margin:0px; padding:0px;" class="col-lg-6">
            <h3>Mettes Planteskole</h3>
            <asp:Literal ID="LiteralContactInfo" runat="server"></asp:Literal>
        </div>

        <div style="margin:0px; padding:0px;" class="col-lg-6">
            <h3>Åbningstider</h3>
            <asp:Literal ID="LiteralOpeningHours" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
