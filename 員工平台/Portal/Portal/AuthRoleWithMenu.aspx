<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AuthRoleWithMenu.aspx.cs" Inherits="Portal.AuthRoleWithMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnEdit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="btnEdit" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlRole">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlPage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>權限管理</h5>
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
                            <label class="col-sm-2 col-form-label">角色權限</label>
                            <div class="col-sm-10 row">
                                <telerik:RadAjaxPanel Width="100%" runat="server">
                                    <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged"
                                        Placeholder="請選擇..."
                                        AutoClose="false"
                                        TagMode="Single"
                                        Width="100%"
                                        ID="ddlRole"
                                        AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                                </telerik:RadAjaxPanel>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">頁面</label>
                            <div class="col-sm-10 row">
                                <telerik:RadAjaxPanel Width="100%" runat="server">
                                    <telerik:RadDropDownTree runat="server" Skin="Bootstrap" ID="ddlPage" ButtonSettings-ShowCheckAll="true"
                                        Localization-CheckAll="全選" CheckBoxes="TriState" Width="100%" DefaultMessage="請選擇要修改的目錄...">
                                    </telerik:RadDropDownTree>
                                </telerik:RadAjaxPanel>
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group row">
                            <div class="col-sm-2 col-sm-offset-2">
                                <telerik:RadButton ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" CssClass="btn btn-primary btn-sm" />
                            </div>
                            <telerik:RadLabel runat="server" CssClass="badge badge-danger" Font-Size="Larger" ID="lblMsg"></telerik:RadLabel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
