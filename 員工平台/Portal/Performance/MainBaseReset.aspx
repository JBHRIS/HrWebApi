<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MainBaseReset.aspx.cs" Inherits="Performance.MainBaseReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>處理</h5>
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
                            <div class="form-group row">
                                <label class="col-sm-12 col-form-label">準備還原部門</label>
                                <div class="col-sm-12 ">
                                    <telerik:RadCheckBoxList ID="cblDept" runat="server" AutoPostBack="false" Skin="Bootstrap" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnSign" runat="server" Text="還原" OnClick="btnSend_Click" CommandName="Sign" OnClientClicking="ExcuteConfirm" CssClass="btn btn-primary btn-sm" />
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
