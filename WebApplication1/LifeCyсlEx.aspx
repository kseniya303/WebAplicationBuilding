<%@ Page Title="LifeCykl" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LifeCyklEx.aspx.cs" Inherits="WebApplication1.LifeCyklEx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %>.</h2>
    <div class="row-fluid">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="MyTxtEmptyValidator" Text="Ошибка, пусто" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <div>
     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
    <asp:Button ID="Button1" runat="server" Text="Кнопка" OnClick="Button1_Click" CssClass="btn btn-primary"/>
    <script>
</script>
</asp:Content>
