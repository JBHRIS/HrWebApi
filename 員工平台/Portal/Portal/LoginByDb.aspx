<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="LoginByDb.aspx.cs" Inherits="Portal.LoginByDb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        img {
            max-width: 100%;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Image runat="server" ID="LoginIcon" alt="Image" ImageUrl="images/jb2.png" />
    </div>
    <h3>員工入口平台</h3>
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
            <%--<telerik:RadButton ID="btnSpeedLogin" runat="server" Text="直接登入admin" CommandName ="admin" CommandArgument="1qaz2wsx" OnClick="btnSpeedLogin_Click" 
CssClass="btn btn-primary block full-width m-b" />
            <%--<a href="LoginForgotPassword.aspx"><small>忘記密碼？</small></a>--%>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Mainly scripts -->
    <script src="Templates/Inspinia/js/jquery-3.1.1.min.js"></script>
    <script src="Templates/Inspinia/js/popper.min.js"></script>
    <script src="Templates/Inspinia/js/bootstrap.js"></script>
</asp:Content>
