<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AuthUserWithMenu.aspx.cs" Inherits="Portal.AuthUserWithMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnEdit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Message" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
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
                            <label class="col-sm-2 col-form-label">使用者管理</label>
                            <div class="col-sm-10 row">
                                <telerik:RadDropDownTree runat="server" Skin="Bootstrap" ID="ddlUser" Width="100%" OnEntryAdded="ddlUser_EntryAdded" CheckBoxes="TriState" ButtonSettings-ShowCheckAll="true" Localization-CheckAll="全選" DefaultMessage="請選擇要修改的使用者...">
                                </telerik:RadDropDownTree>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">權限</label>
                            <div class="col-sm-10 row">
                                <telerik:RadDropDownTree runat="server" Skin="Bootstrap" ID="ddlPage" ButtonSettings-ShowCheckAll="true" 
                                    Localization-CheckAll="全選" CheckBoxes="TriState" Width="100%" DefaultMessage="請選擇要修改的目錄...">
                                </telerik:RadDropDownTree>
                            </div>
                        </div>
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
