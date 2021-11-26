<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="Message404.aspx.cs" Inherits="Portal.Message404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>404</h1>
    <h3 class="font-bold">找不到網頁</h3>

    <div class="error-desc">
        抱歉！找不到您要瀏覽的頁面。 嘗試檢查網址是否有錯誤，然後點重新整理頁面，或稍後再嘗試。<br />
        <br />
        <a href="Login.aspx?param=Logout" class="btn btn-primary m-t">回登入頁</a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Mainly scripts -->
    <script src="Templates/Inspinia/js/jquery-3.1.1.min.js"></script>
    <script src="Templates/Inspinia/js/popper.min.js"></script>
    <script src="Templates/Inspinia/js/bootstrap.js"></script>
</asp:Content>
