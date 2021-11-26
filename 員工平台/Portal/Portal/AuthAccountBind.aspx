<%@ Page  Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AuthAccountBind.aspx.cs" Inherits="Portal.AuthAccountBind" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>

            <telerik:AjaxSetting AjaxControlID="btnSubmit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>帳號綁定</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="fullscreen-link">
                                <i class="fa fa-expand"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">FaceBook</label>
                            <div class="col-sm-10 row">
                                <telerik:RadButton ID="btnBindFacebook" runat="server" Text="綁定" OnClick="btnBind_Click" CommandName="Facebook" AutoPostBack="true" CssClass="btn btn-primary btn-sm" />
                                <telerik:RadLabel runat="server" CssClass="badge badge-danger" ID="lblBindFacebook" Text="未綁定"></telerik:RadLabel>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Google</label>
                            <div class="col-sm-10 row">
                                <telerik:RadButton ID="btnBindGoogle" runat="server" Text="綁定" OnClick="btnBind_Click" CommandName="Google" AutoPostBack="true" CssClass="btn btn-primary btn-sm" />
                                <telerik:RadLabel runat="server" CssClass="badge badge-danger" ID="lblBindGoogle" Text="未綁定"></telerik:RadLabel>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Line</label>
                            <div class="col-sm-10 row">
                                <telerik:RadButton ID="btnBindLine" runat="server" Text="綁定" OnClick="btnBind_Click" CommandName="Line" AutoPostBack="true" CssClass="btn btn-primary btn-sm" />
                                <telerik:RadLabel runat="server" CssClass="badge badge-danger" ID="lblBindLine" Text="未綁定"></telerik:RadLabel>
                            </div>
                        </div>
                        ※必須要有具備SSL的網址才能進行綁定
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
