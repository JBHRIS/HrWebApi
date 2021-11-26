<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AuthMenuEdit.aspx.cs" Inherits="Portal.AuthMenuEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
    <link href="styles/redcontrol_form.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>
            
            <telerik:AjaxSetting AjaxControlID="btnSubmit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Message" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>新增或修改選單</h5>
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
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>選單名稱</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtCode" Skin="Bootstrap" Width="100%" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">上層名單</label>
                            <div class="col-sm-10 row">
                                <telerik:RadDropDownTree runat="server" Skin="Bootstrap" ID="ddlParent" Width="100%" DefaultMessage="請選擇要上層的目錄...">
                                    <DropDownSettings CloseDropDownOnSelection="true" />
                                </telerik:RadDropDownTree>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">檔案名稱</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtFileName" Skin="Bootstrap" Width="100%" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>頁面標題</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtFileTitle" Skin="Bootstrap" Width="100%" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">標籤</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtTag" Skin="Bootstrap" Width="100%" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">圖檔名稱</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtIconName" Skin="Bootstrap" Width="100%" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">排序</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtOrder" Skin="Bootstrap" Width="100%" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">開啟時用新分頁</label>
                            <div class="col-sm-10 row">
                                <telerik:RadCheckBox runat="server" ID="cbOpen" AutoPostBack="false"></telerik:RadCheckBox>
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group row">
                            <div class="col-sm-10 col-sm-offset-2">
                                <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-primary btn-outline" />
                                <telerik:RadButton ID="btnSubmit" runat="server" Text="儲存" OnClick="btnSubmit_Click" AutoPostBack="true" CssClass="btn btn-primary btn-sm" />
                                <telerik:RadLabel runat="server" CssClass="badge badge-danger" ID="lblMsg" Skin="Bootstrap"></telerik:RadLabel>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
