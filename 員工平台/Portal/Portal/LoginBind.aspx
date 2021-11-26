<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="LoginBind.aspx.cs" Inherits="Portal.LoginBind" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <%--<h1 class="logo-name">JB</h1>--%>
        <img alt="Image" src="images/jb2.png" />
    </div>
    <h3>員工入口平台</h3>
    <p>
        請使用最新版本的瀏覽器 以得到最佳的操作體驗
    </p>
    <p>請定期更換密碼 以確保資料安全</p>
    <div id="form1" class="m-t" role="form">
        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="row margin-bottom-1x">
                <div class="col-xl-4 col-md-6 col-sm-4">
                    <telerik:RadButton ID="btnAuthFacebook" runat="server" Text="Facebook login" CssClass="btn btn-sm btn-block facebook-btn socicon-facebook" CommandName="Facebook" ToolTip="Facebook login" OnClick="btnOAuth2Login_Click">
                        <ContentTemplate>
                            <div>
                                <img src="images/LoginFacebook.png" alt="Facebook login" height="50" />
                            </div>
                        </ContentTemplate>
                    </telerik:RadButton>
                </div>
                <div class="col-xl-4 col-md-6 col-sm-4">
                    <telerik:RadButton ID="btnAuthGoogle" runat="server" Text="Google login" CssClass="btn btn-sm btn-block google-btn socicon-googleplus" CommandName="Google" ToolTip="Google login" OnClick="btnOAuth2Login_Click">
                        <ContentTemplate>
                            <div>
                                <img src="images/LoginGoogle.png" alt="Google login" height="50" />
                            </div>
                        </ContentTemplate>
                    </telerik:RadButton>
                </div>
                <div class="col-xl-4 col-md-6 col-sm-4">
                    <telerik:RadButton ID="btnAutoLine" runat="server" Text="Line login" CssClass="btn btn-sm btn-block line-btn socicon-googleplus" CommandName="Line" ToolTip="Line login" OnClick="btnOAuth2Login_Click">
                        <ContentTemplate>
                            <div>
                                <img src="images/LoginLine.png" alt="Line login" height="50" />
                            </div>
                        </ContentTemplate>
                    </telerik:RadButton>
                </div>
            </div>
            <div class="form-group">
                <telerik:RadTextBox ID="txtCompanyId" runat="server" EmptyMessage="公司代碼(統編)" CssClass="form-control" Width="100%" />
            </div>
            <div class="form-group">
                <telerik:RadTextBox ID="txtUserId" runat="server" EmptyMessage="工號或帳號" CssClass="form-control" Width="100%" />
            </div>
            <div class="form-group">
                <telerik:RadTextBox ID="txtUserPw" runat="server" TextMode="Password" CssClass="form-control" Width="100%" />
            </div>
            <telerik:RadLabel ID="lblMsg" runat="server" />
            <telerik:RadButton ID="btnSubmit" runat="server" Text="登入" OnClick="btnSubmit_Click" CssClass="btn btn-primary block full-width m-b" />
            <telerik:RadButton runat="server" Text="直接登入A0550(Admin)" OnClick="btnSpeedLogin_Click" CommandName="A0550" CommandArgument="FAYA0550" CssClass="btn btn-primary block full-width m-b" />
            <telerik:RadButton runat="server" Text="直接登入A0902(HR)" OnClick="btnSpeedLogin_Click" CommandName="A0902" CommandArgument="Hopax902" CssClass="btn btn-primary block full-width m-b" />
            <telerik:RadButton runat="server" Text="直接登入A1357(Emp)" OnClick="btnSpeedLogin_Click" CommandName="A1357" CommandArgument="3434" CssClass="btn btn-primary block full-width m-b" />

            <a href="LoginForgotPassword.aspx"><small>忘記密碼？</small></a>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Mainly scripts -->
    <script src="Templates/Inspinia/js/jquery-3.1.1.min.js"></script>
    <script src="Templates/Inspinia/js/popper.min.js"></script>
    <script src="Templates/Inspinia/js/bootstrap.js"></script>
</asp:Content>
