<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ShareMessage.aspx.cs" Inherits="Performance.ShareMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>訊息內容</h5>
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
                            <div class="col">
                                <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col">
                                <telerik:RadLabel ID="lblMsg" runat="server" CssClass="badge badge-danger" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col">
                                <telerik:RadButton ID="RadButton1" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
