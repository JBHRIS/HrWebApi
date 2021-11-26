<%@ Page Title="" Language="C#" MasterPageFile="~/Single.Master" AutoEventWireup="true" CodeBehind="LoginFirst.aspx.cs" Inherits="Performance.LoginFirst" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="row">
            <div class="col-md-12">
                <div class="ibox-content">
                    <h2 class="font-bold">第一次登入</h2>
                    <p>
                        請輸入您的電子信箱，以取得您的密碼
                    </p>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="m-t" role="form">
                                <div class="form-group">
                                    <telerik:RadTextBox Skin="Bootstrap" ID="txtEmpId" runat="server" EmptyMessage="工號" class="form-control" Width="100%" />
                                    <telerik:RadTextBox Skin="Bootstrap" ID="txtEmail" runat="server" EmptyMessage="電子信箱" class="form-control" Width="100%" />
                                </div>
                                <telerik:RadLabel ID="lblMsg" runat="server"  CssClass="badge badge-warning"/>
                                <telerik:RadButton ID="btnSubmit" runat="server" Text="送出"  OnClick="btnSubmit_Click" CssClass="btn btn-primary block full-width m-b" />
                                <a href="Login.aspx"><small>回登入頁</small></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>

