<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMailViewBody.aspx.cs" Inherits="Performance.ManageMailViewBody" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>郵件內容</h5>
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
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadLabel ID="lblAutoKey" runat="server" Visible="false" />
                            <div class="form-group row">
                                <label class="col-sm-12 col-form-label">主旨</label>
                                <div class="col-sm-12">
                                    <telerik:RadLabel ID="lblSubject" runat="server" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-12 col-form-label">內容</label>
                                <div class="col-sm-12">
                                    <telerik:RadLabel ID="lblBody" runat="server" />
                                </div>
                            </div>
                                 <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"  CssClass="btn btn-w-m btn-warning" />
                            <telerik:RadLabel ID="lblMsg" runat="server" CssClass="badge badge-danger" />
                            <telerik:RadLabel ID="lblRowIndex" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblUserCode" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblKey1" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblKey2" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblGuid" runat="server" Visible="False" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
