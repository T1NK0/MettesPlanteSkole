<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.Master" AutoEventWireup="true" CodeBehind="Produkter.aspx.cs" Inherits="MettesPlanteskole.Produkter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-10" style="float: right;">
        <div class="col-lg-6">
            <asp:TextBox ID="TextBox_Name" placeholder="Navn" class="form-control" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="TextBox_Price" placeholder="Pris" class="form-control" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="TextBox_Storage" placeholder="Lager" class="form-control" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="TextBox_Min_Storage" placeholder="Minimum Lager" class="form-control" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="TextBox_Max_Storage" placeholder="Maksimum Lager" class="form-control" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="TextBox_Dirt" placeholder="Jord Typer" class="form-control" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="TextBox_Time" placeholder="Dyrknings Tid" class="form-control" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="TextBox_Productnumber" placeholder="Varenummer" class="form-control" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="TextBox_Description" Style="overflow-y: scroll; max-width: 750px; max-height: 200px; min-height: 200px; min-width: 750px;" runat="server" TextMode="MultiLine" CssClass="TextBoxDescription" class="form-control"></asp:TextBox><br />
            <asp:DropDownList ID="DropDownList_Categorys" runat="server"></asp:DropDownList><br />
            <br />
            <asp:Image ID="Image_Ret1" runat="server" Style="width: 50px; height: 50px;" Visible="false" />
            <asp:Image ID="Image_Ret2" runat="server" Style="width: 50px; height: 50px;" Visible="false" />
            <asp:Image ID="Image_Ret3" runat="server" Style="width: 50px; height: 50px;" Visible="false" />
            <asp:HiddenField ID="HiddenField_oldImage1" runat="server" />
            <asp:HiddenField ID="HiddenField_oldImage2" runat="server" />
            <asp:HiddenField ID="HiddenField_oldImage3" runat="server" />
            <asp:FileUpload ID="FileUpload_Img1" runat="server" /><asp:FileUpload ID="FileUpload_Img2" runat="server" /><asp:FileUpload ID="FileUpload_Img3" runat="server" /><br />

            <asp:Button ID="Button_Opret" runat="server" class="btn btn-success" Text="Opret Vare" OnClick="Button_Opret_Click" />
            <asp:Button ID="Button_Gem_Ret" Visible="false" runat="server" CssClass="btn btn-success" Text="Gem" OnClick="Button_Gem_Ret_Click" />
        </div>
    </div>

    <div class="col-lg-10" style="float: right;">
        <hr />
        <table class="table">
            <thead>
                <tr>
                    <th class="col-lg-1">Navn</th>
                    <th class="col-lg-1">Varenummer</th>
                    <th class="col-lg-1">Kategori</th>
                    <th class="col-lg-1">Beskrivelse</th>
                    <th class="col-lg-1">Pris</th>
                    <th class="col-lg-1">Lager</th>
                    <th class="col-lg-1">minimum lager</th>
                    <th class="col-lg-1">maximum lager</th>
                    <th class="col-lg-1">Jordtype</th>
                    <th class="col-lg-1">Sæson</th>
                    <th class="col-lg-1">ret</th>
                    <th class="col-lg-1">slet</th>
                </tr>
            </thead>
        </table>
        <asp:Repeater ID="Repeater_Vis_Vare" runat="server" DataSourceID="SqlDataSource_Vis_Vare" OnItemCommand="Repeater_Vis_Vare_ItemCommand">
            <ItemTemplate>
                <table class="table table-hover">
                    <tr>
                        <td class="col-lg-1"><%#Eval ("product_name") %></td>
                        <td class="col-lg-1"><%#Eval ("product_number") %></td>
                        <td class="col-lg-1"><%#Eval ("category_name") %></td>
                        <td class="col-lg-1"><%#Eval ("product_description") %></td>
                        <td class="col-lg-1"><%#Eval ("product_price") %></td>
                        <td class="col-lg-1"><%#Eval ("product_storage") %></td>
                        <td class="col-lg-1"><%#Eval ("product_min_storage") %></td>
                        <td class="col-lg-1"><%#Eval ("product_max_storage") %></td>
                        <td class="col-lg-1"><%#Eval ("product_recomended_dirt") %></td>
                        <td class="col-lg-1"><%#Eval ("product_growthtime") %></td>
                        <asp:HiddenField ID="HiddenField_img_slet1" runat="server" Value='<%#Eval ("product_image_1") %>' />
                        <asp:HiddenField ID="HiddenField_img_slet2" runat="server" Value='<%#Eval ("product_image_2") %>' />
                        <asp:HiddenField ID="HiddenField_img_slet3" runat="server" Value='<%#Eval ("product_image_3") %>' />
                        <td>
                            <asp:LinkButton ID="LinkButton_ret" class="btn btn-success" runat="server" CommandArgument='<%#Eval ("product_id") %>' CommandName="Ret"><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton></td>
                        <td>
                            <asp:LinkButton ID="LinkButton_slet" class="btn btn-danger" runat="server" CommandArgument='<%#Eval ("product_id") %>' CommandName="Slet"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource_Vis_Vare" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT products.*, category.* FROM category INNER JOIN products ON category.category_id = products.FK_category_id"></asp:SqlDataSource>
    </div>
</asp:Content>
