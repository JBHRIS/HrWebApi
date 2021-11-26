<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageSystemUserGroupEdit.aspx.cs" Inherits="Performance.ManageSystemUserGroupEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
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
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>角色名稱</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" ID="txtName" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label"><label style=" color: #FF0000;">※</label>權限代碼</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" InputType="Number" ID="txtAuth" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label class="col-sm-2 col-form-label">排序</label>
                            <div class="col-sm-10 row">
                                <telerik:RadTextBox runat="server" InputType="Number" ID="txtSort" Skin="Bootstrap" Width="100%"></telerik:RadTextBox>
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
     
</asp:Content>
