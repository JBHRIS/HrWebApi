<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Portal.Login" %>

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
        <%--<h1 class="logo-name">JB</h1>--%>
        <asp:Image runat="server" ID="LoginIcon" alt="Image" ImageUrl="images/jb2.png" />
    </div>

    <h3 class="m-md">員工入口平台</h3>
    <p>請使用最新版本的瀏覽器，以得到最佳的操作體驗請定期更換密碼，以確保資料安全</p>
    
    <div id="form1" class="m-t" role="form">
        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="form-group">
                <telerik:RadTextBox ID="txtCompanyId" runat="server" EmptyMessage="公司代碼(統編)" CssClass="form-control" Width="100%" />
            </div>
            <div class="form-group">
                <telerik:RadTextBox ID="txtUserId" runat="server" EmptyMessage="工號或帳號" CssClass="form-control" Width="100%" />
            </div>
            <div class="form-group">
                <telerik:RadTextBox ID="txtUserPw" runat="server" TextMode="Password" CssClass="form-control" Width="100%" />
            </div>
            <%--<div class="form-group">
                我不是機器人放在這個位置
            </div>--%>
            <telerik:RadLabel ID="lblMsg" runat="server" />
            <telerik:RadButton ID="btnSubmit" runat="server" Text="登入" OnClick="btnSubmit_Click" CssClass="btn btn-primary block full-width m-b" />
            <telerik:RadButton runat="server" Text="直接登入A0550(Admin)" OnClick="btnSpeedLogin_Click" CommandName="A0550" CommandArgument="FAYA0550" CssClass="btn btn-primary block full-width m-b" />
            <telerik:RadButton runat="server" Text="直接登入A0902(HR)" OnClick="btnSpeedLogin_Click" CommandName="A0902" CommandArgument="0000" CssClass="btn btn-primary block full-width m-b" />
            <telerik:RadButton runat="server" Text="直接登入A1357(Emp)" OnClick="btnSpeedLogin_Click" CommandName="A1357" CommandArgument="0000" CssClass="btn btn-primary block full-width m-b" />
            <telerik:RadButton runat="server" Text="直接登入A0521" OnClick="btnSpeedLogin_Click" CommandName="A0521" CommandArgument="0000" CssClass="btn btn-primary block full-width m-b" />
            <a href="LoginForgotPassword.aspx"><small>忘記密碼？</small></a>
            <%--<button
                class="g-recaptcha btn-primary"
                data-sitekey="6Lf1LpMbAAAAAFqf8N6G6nGV2Wed2IYqUqmnHQQ0"
                data-action="verify1"
                data-callback="verifyCallback">
                送出</button>--%>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Mainly scripts -->
    <script src="Templates/Inspinia/js/jquery-3.1.1.min.js"></script>
    <script src="Templates/Inspinia/js/popper.min.js"></script>
    <script src="Templates/Inspinia/js/bootstrap.js"></script>
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
</asp:Content>
