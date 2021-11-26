<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeBaseChangePassword.aspx.cs" Inherits="Portal.EmployeeBaseChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="row">
            <div class="col-md-12">
                <div class="ibox-content">
                    <h2 class="font-bold">密碼修改</h2>
                    <div class="col-lg-12">
                        <div class="form-group row">
                            <telerik:RadLabel runat="server" Text="舊密碼:" CssClass="label label-info col-auto" />
                            <telerik:RadTextBox ID="txtOldPassword" runat="server" TextMode="Password" class="form-control col-auto" Skin="Bootstrap" Width="100%" />
                        </div>
                        <div class="form-group row">
                            <telerik:RadLabel runat="server" Text="新密碼:" CssClass="label label-info col-auto" />
                            <telerik:RadTextBox ID="txtNewPassword" runat="server" TextMode="Password" class="form-control col-auto" Skin="Bootstrap" Width="100%" />
                        </div>
                        <div class="form-group row">
                            <telerik:RadLabel runat="server" Text="確認新密碼:" CssClass="label label-info col-auto" />
                            <telerik:RadTextBox ID="txtCheckPassword" runat="server" TextMode="Password" class="form-control col-auto" Skin="Bootstrap" Width="100%" />
                        </div>
                        <telerik:RadButton ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="密碼修改" CssClass="btn btn-primary block full-width m-b" />
                        <telerik:RadLabel runat="server" ID="lblMsg" CssClass="label-danger" />
                    </div>
                </div>
            </div>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
