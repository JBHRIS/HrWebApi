<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="LoginChangePassword.aspx.cs" Inherits="Portal.LoginChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="row">
            <div class="col-md-12">
                <div class="ibox-content">
                    <h2 class="font-bold">更新密碼</h2>
                    <div class="col-lg-12">
                        <telerik:RadTextBox ID="txtResetKey" runat="server" EmptyMessage="ResetKey" Visible="false" class="form-control" Skin="Bootstrap" Width="100%" />
                        <div class="form-group row">
                            <telerik:RadLabel runat="server" Text="新密碼:" CssClass="label label-info col-auto" />
                            <telerik:RadTextBox ID="txtNewPassword" runat="server" TextMode="Password" class="form-control" Skin="Bootstrap" Width="100%" />
                        </div>
                        <div class="form-group row">
                            <telerik:RadLabel runat="server" Text="確認密碼:" CssClass="label label-info col-auto" />
                            <telerik:RadTextBox ID="txtCheckPassword" runat="server" TextMode="Password" class="form-control" Skin="Bootstrap" Width="100%" />
                        </div>
                        <telerik:RadLabel runat="server" ID="lblMsg" CssClass="label-danger" />
                        <telerik:RadButton ID="btnSubmit" runat="server" Text="更新密碼" CssClass="btn btn-primary block full-width m-b" OnClick="btnSubmit_Click" />
                        <a href="Login.aspx"><small>回登入頁</small></a>
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
