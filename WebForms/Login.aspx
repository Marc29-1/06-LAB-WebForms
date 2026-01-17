<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    Inherits="WebForms.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Prijava</h2>

    <br />

    Korisničko ime:&nbsp;
    <asp:TextBox ID="tbKorisnickoIme" runat="server" />
    <br /><br />

    Lozinka:&nbsp;
    <asp:TextBox ID="tbLozinka" runat="server" TextMode="Password" />
    <br />
<br />
<br />

    <asp:Button ID="btnPrijava" runat="server"
        Text="Prijava" OnClick="btnPrijava_Click" />

    <br /><br />

    <asp:Label ID="lblPoruka" runat="server" ForeColor="Red" />

</asp:Content>