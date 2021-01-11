<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Opret.aspx.cs" Inherits="MettesPlanteskole.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-0"></div>
    <div class="Opret_Form col-lg-6">
        <h1>Opret din bruger her</h1>
        <asp:TextBox ID="TextBox_Username_Create" runat="server" placeholder="Brugernavn" class="form-control" ValidationGroup="opret"></asp:TextBox><br />
        <asp:TextBox ID="TextBox_Email_Create" runat="server" placeholder="Email" class="form-control" ValidationGroup="opret"></asp:TextBox><br />
        <asp:TextBox ID="TextBox_Password_Create1" runat="server" placeholder="Password" class="form-control" ValidationGroup="opret"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Koderne stemmer ikke over ens" ControlToCompare="TextBox_Password_Create2" ControlToValidate="TextBox_Password_Create1" ValidationGroup="opret"></asp:CompareValidator><br />
        <asp:TextBox ID="TextBox_Password_Create2" runat="server" placeholder="Gentag Password" class="form-control" ValidationGroup="opret"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Koderne stemmer ikke over ens" ControlToCompare="TextBox_Password_Create1" ControlToValidate="TextBox_Password_Create2" ValidationGroup="opret"></asp:CompareValidator><br />
        <asp:TextBox ID="TextBox_Firstname_Create" placeholder="Fornavn" class="form-control" ValidationGroup="opret" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBox_Lastname_Create" placeholder="Efternavn" class="form-control" ValidationGroup="opret" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBox_Address_Create" placeholder="Addresse" class="form-control" ValidationGroup="opret" runat="server"></asp:TextBox><br />
        <asp:Button ID="button_opret_bruger" runat="server" Text="Opret bruger" OnClick="button_opret_bruger_Click" class="btn btn-default" ValidationGroup="opret" /><br /><br />
    </div>
    <div class="col-lg-0"></div>
</asp:Content>
