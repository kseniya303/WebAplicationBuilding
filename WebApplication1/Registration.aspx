<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication1.Registration" %>
 

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <h2><%:Title %>.</h2>
           
          <asp:TextBox ID="TextName" Text="Введите имя" runat="server"></asp:TextBox>
     <div>

     </div>
          <asp:TextBox ID="TextPass1" Text="Введите пароль" runat="server"></asp:TextBox>
    <div>

     </div>
          <asp:TextBox ID="TextPass2" Text="Введите пароль повторно" runat="server"></asp:TextBox>
     <div>

     </div>
          <asp:Button runat="server" OnClick="Registr_Click" Text="Зарегистрировать" />
    

  </asp:Content>