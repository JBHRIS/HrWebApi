<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageSystemPageEdit.aspx.cs" Inherits="Performance.ManageSystemPageEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>內容</h5>
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
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>代碼</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtCode" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>檔案名稱</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtFileName" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>頁面標題</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtFileTitle" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>角色權限</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtRoleKey" InputType="Number" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>上層頁面</label>
                            <div class="col-sm-10 row">
                                <telerik:RadDropDownTree runat="server" ID="ddlParentCode" Skin="Bootstrap" Width="100%"></telerik:RadDropDownTree>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>圖檔</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtIcon" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>排序</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtSort" InputType="Number" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label">在目錄欄位顯示</label>
                            <div class="col-sm-10 row">
                                 <telerik:RadCheckBox runat="server" ID="isHref" Checked="true" AutoPostBack="false"></telerik:RadCheckBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label">開啟新分頁顯示</label>
                            <div class="col-sm-10 row">
                                 <telerik:RadCheckBox runat="server" ID="isOpenWindow" Checked="false" AutoPostBack="false"></telerik:RadCheckBox>
                            </div>
                        </div>
                        <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                        <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                        <telerik:RadLabel runat="server" CssClass="badge-danger" Font-Size="Larger" ID="lblMsg"></telerik:RadLabel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>

    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
