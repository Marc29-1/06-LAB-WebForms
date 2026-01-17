<%@ Page Title="Shop" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Shop.aspx.cs"
    Inherits="WebForms.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Shop</h2>

    <br />

    Naziv proizvoda:&nbsp;
    <asp:TextBox ID="tbNaziv" runat="server" />
    <br />
    <br /><br />

    Opis proizvoda:&nbsp;
    <asp:TextBox ID="tbOpis" runat="server" />
    <br /><br />

    <asp:Button ID="btnSpremi" runat="server"
        Text="Spremi" OnClick="btnSpremi_Click" />

    <hr />

    <asp:GridView ID="gvProizvodi" runat="server"
    AutoGenerateColumns="False">

    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Name" HeaderText="Naziv" />
        <asp:BoundField DataField="Description" HeaderText="Opis" />
    </Columns>

</asp:GridView>


</asp:Content>