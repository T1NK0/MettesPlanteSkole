<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="MettesPlanteskole.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-10" style="float: right;">
        <div class="col-lg-12">
            <div class="col-lg-3">
                <asp:Panel ID="Panel_Opret" runat="server" Class="col-lg-12" Visible="true">
                    <h1>Opret en ny kategori</h1>
                    <asp:TextBox ID="TextBox_Create_Category" placeholder="Kategori Navn" CssClass="form-control col-lg-4" runat="server"></asp:TextBox><br />
                    <br />
                    <asp:LinkButton ID="LinkButton_Create" runat="server" class="btn btn-success" OnClick="LinkButton_Create_Click"><i class="fa fa-plus" aria-hidden="true"></i> Ny Kategori</asp:LinkButton>
                </asp:Panel>

                <asp:Panel ID="Panel_ret" runat="server" Class="col-lg-12" Visible="false">
                    <h2>Rediger Genrer</h2>
                    <asp:TextBox ID="TextBox_Genrer_Ret" runat="server" placeholder="Genrer Navn" class="form-control" ValidationGroup="Ret"></asp:TextBox><br />
                    <asp:Button ID="Button_Gem" runat="server" Text="Gem" OnClick="Button_Gem_Click" class="btn btn-success" />
                </asp:Panel>
            </div>
        </div>

        <div class="col-lg-12">
            <div style="clear: both;">
                <hr />
            </div>

            <br />

            <asp:Panel ID="Panel_Ret_Slet" runat="server" class="col-lg-12">
                <div>
                    <table class="table table-hover col-lg-4" style="margin-bottom: 0px;">
                        <thead>
                            <tr>
                                <th class="col-lg-3">Kategori id</th>
                                <th class="col-lg-3">Kategori navn</th>
                                <th class="col-lg-3">Ret</th>
                                <th class="col-lg-3">Slet</th>
                            </tr>
                        </thead>
                    </table>
                    <asp:Repeater ID="Repeater_ret_slet" runat="server" DataSourceID="SqlDataSource_Category_Ret_Slet" OnItemCommand="Repeater_ret_slet_ItemCommand">
                        <ItemTemplate>
                            <div>
                                <table class="table table-hover col-lg-4" style="margin-bottom: 0px;">
                                    <tbody>
                                        <tr>
                                            <td class="col-lg-3"><%#Eval ("category_id") %></td>
                                            <td class="col-lg-3"><%#Eval ("category_name") %></td>
                                            <td class="col-lg-3">
                                                <asp:Button ID="Button_ret" runat="server" Text="Ret" CommandArgument='<%#Eval ("category_id") %>' CommandName="Ret" class="btn btn-success" /></td>
                                            <td class="col-lg-3">
                                                <asp:Button ID="Button_Slet" runat="server" Text="Slet" CommandArgument='<%#Eval ("category_id") %>' CommandName="Slet" OnClientClick="return confirm('Er du sikker på du vil slette denne kategori?')" class="btn btn-danger" /></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:SqlDataSource ID="SqlDataSource_Category_Ret_Slet" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
