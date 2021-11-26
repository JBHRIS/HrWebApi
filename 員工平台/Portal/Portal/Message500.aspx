<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="Message500.aspx.cs" Inherits="Portal.Message500" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>500</h1>
        <h3 class="font-bold">網路伺服器錯誤</h3>

        <div class="error-desc">
            伺服器發生意外狀況，暫時無法使用。 非常抱歉！<br />
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
