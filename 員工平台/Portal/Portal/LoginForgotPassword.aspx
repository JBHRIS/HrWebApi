<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="LoginForgotPassword.aspx.cs" Inherits="Portal.LoginForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="row">
            <div class="col-md-12">
                <div class="ibox-content">
                    <h2 class="font-bold">忘記密碼</h2>
                    <p>
                        請輸入您的身分證字號及電子信箱，以重置您的密碼
                    </p>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="m-t" role="form">
                                <div class="form-group">
                                    <telerik:RadTextBox Skin="Bootstrap" ID="txtEmpId" runat="server" EmptyMessage="工號" class="form-control" Width="100%" />
                                    <telerik:RadTextBox Skin="Bootstrap" ID="txtIdentifyNO" runat="server" EmptyMessage="身分證字號" class="form-control" Width="100%" />
                                    <telerik:RadTextBox Skin="Bootstrap" ID="txtEmail" runat="server" EmptyMessage="電子信箱" class="form-control" Width="100%" />
                                </div>
                                <telerik:RadLabel runat="server" ID="lblMsg" CssClass="label-danger" />
                                <telerik:RadButton ID="btnSubmit" runat="server" Text="送出" CssClass="btn btn-primary block full-width m-b" OnClick="btnSubmit_Click" />
                                <a href="Login.aspx"><small>回登入頁</small></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
