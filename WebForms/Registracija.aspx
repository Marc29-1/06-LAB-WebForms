<%@ Page Title="Registracija" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Registracija.aspx.cs"
    Inherits="WebForms.Registracija" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registracija </h2>

    <br />

    Korisničko ime:&nbsp;
    <asp:TextBox ID="tbKorisnickoIme" runat="server" />
    <br /><br />

    Puno ime:
    <asp:TextBox ID="tbPunoIme" runat="server" />
    <br /><br />

    Lozinka:&nbsp;
    <asp:TextBox ID="tbLozinka" runat="server" TextMode="Password" />
    <br /><br />

    Potvrda lozinke:&nbsp;
    <asp:TextBox ID="tbLozinkaPotvrda" runat="server" TextMode="Password" />
    <br />
<br />
<br />

    <asp:Button ID="btnRegistriraj" runat="server"
        Text="Registriraj" OnClick="btnRegistriraj_Click" />

    <br /><br />

    <asp:Label ID="lblPoruka" runat="server" ForeColor="Red" />

</asp:Content>