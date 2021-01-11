<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="se_kurv.aspx.cs" Inherits="MettesPlanteskole.se_kurv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-6">
        <asp:GridView ID="GridView1" CssClass="Grid table" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="varenavn" HeaderText="Navn" SortExpression="navn"></asp:BoundField>
                <asp:BoundField DataField="varenummer" HeaderText="VareNummer" SortExpression="nummer"></asp:BoundField>
                <asp:BoundField DataField="pris" HeaderText="Pris" SortExpression="pris"></asp:BoundField>
                <asp:BoundField DataField="antal" HeaderText="Antal" SortExpression="antal"></asp:BoundField>
                <asp:TemplateField HeaderText="AntalNy">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" Style="color: #000;" runat="server" Text='<%#Bind("antal") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField SelectText="&lt;i class=&quot;fa fa-refresh&quot; aria-hidden=&quot;true&quot;&gt;&lt;/i&gt;" ShowSelectButton="True" HeaderText="Opdater Kurv"></asp:CommandField>
            </Columns>
            <EmptyDataTemplate>
                Der er ingen vare i kurven
            </EmptyDataTemplate>
        </asp:GridView>
        <div style="background-color: #8ab512; padding-top: 5px;">
            <p style="color:#fff;">
                Pris i alt:
                <asp:Label ID="Label_PrisIAlt" runat="server" Text=""></asp:Label>,-
            </p>
        </div>
        <asp:LinkButton ID="LinkButton_Bestil" runat="server" class="btn btn-success" OnClick="LinkButton_Bestil_Click">Betal <i class="fa fa-cc-visa" aria-hidden="true"></i></asp:LinkButton>
    </div>
</asp:Content>
