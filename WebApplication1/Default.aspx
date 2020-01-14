<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="login-div">
  <div class="logo"></div>
  <div class="title">Building</div>
  <div class="sub-title">Beta</div>
  <div class="fields">
    <div class="username"><input type="username" class="user-input" placeholder="Username" /></div>
    <div class="password"><input type="password" class="pass-input" placeholder="Password" /></div>
  </div>
  <button class="signin-button">LOG IN</button>
  <div class="link"><a href="#">Forgot password?</a></div>
</div>

</asp:Content>
