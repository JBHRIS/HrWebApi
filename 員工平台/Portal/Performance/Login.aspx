<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Performance.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div>
        <h1 class="logo-name">JB</h1>
    </div>
    <h3>績效獎金平台</h3>
    <p>
        請使用最新版本的瀏覽器 以得到最佳的操作體驗
    </p>
    <p>請定期更換密碼 以確保資料安全</p>
    <div id="form1" class="m-t" role="form">
        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="form-group">
                <telerik:RadTextBox ID="txtUserId" runat="server" EmptyMessage="工號或帳號" CssClass="form-control" Width="100%" />
            </div>
            <div class="form-group">
                <telerik:RadTextBox ID="txtUserPw" runat="server" TextMode="Password" CssClass="form-control" Width="100%" />
            </div>
            <telerik:RadLabel ID="lblMsg" runat="server" CssClass="badge badge-warning" />
            <telerik:RadButton ID="btnSubmit" runat="server" Text="登入" OnClick="btnSubmit_Click" CssClass="btn btn-primary block full-width m-b" />
            <a href="LoginFirst.aspx"><small>第一次登入？</small></a>
            <a href="LoginForgotPassword.aspx"><small>忘記密碼？</small></a>
        </telerik:RadAjaxPanel>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <!-- Mainly scripts -->
    <script src="Templates/Inspinia/js/jquery-3.1.1.min.js"></script>
    <script src="Templates/Inspinia/js/popper.min.js"></script>
    <script src="Templates/Inspinia/js/bootstrap.js"></script>
</asp:Content>
