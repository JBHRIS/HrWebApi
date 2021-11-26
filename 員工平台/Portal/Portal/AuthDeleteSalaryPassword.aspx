<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AuthDeleteSalaryPassword.aspx.cs" Inherits="Portal.AuthDeleteSalaryPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <h5>刪除薪資密碼</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="form-group row">
                            <div class="col-lg-2">
                                <telerik:RadLabel runat="server" Font-Size="Large" CssClass="col-form-label" Text="被刪除者工號"></telerik:RadLabel>
                            </div>
                            
                            <div class="col-lg-6">
                                <telerik:RadTextBox runat="server" Width="90%" Skin="Bootstrap" ID="txtEmpId"></telerik:RadTextBox>
                            </div>
                            <telerik:RadButton runat="server" CssClass="btn btn-danger btn-sm" Text="刪除" ID="btnSubmit" OnClick="btnSubmit_Click"></telerik:RadButton>
                            <div class="col-lg-2">
                            <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge badge-danger animated shake"></telerik:RadLabel>
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
