<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormCard.aspx.cs" Inherits="Portal.FormCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <%--<div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>打卡</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <div class="form-group">
                            <telerik:RadAjaxPanel runat="server">
                                <asp:Timer ID="Timer" runat="server" Interval="1000"></asp:Timer>
                                <telerik:RadLabel runat="server" ID="lblTime"></telerik:RadLabel>
                            </telerik:RadAjaxPanel>
                            <telerik:RadButton runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="打卡" CssClass="btn btn-primary"></telerik:RadButton>
                        </div>
                        <div class="form-group col-md-3" style="border: solid">
                            <h3>簽到資訊</h3>
                            <telerik:RadLabel runat="server" CssClass="col-form-label" Text="簽到時間:"></telerik:RadLabel>
                            <telerik:RadLabel runat="server" ID="lblCardTime"></telerik:RadLabel>
                        </div>
                        <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge badge-danger animated shake"></telerik:RadLabel>
                    </div>
                </div>
            </div>--%>
            <div class="col-lg-3">
                <telerik:RadAjaxPanel runat="server">

                    <div class="widget-head-color-box navy-bg p-lg">
                        <div class="row">
                            <div class="col-4">
                                <i class="fa fa-clock-o fa-4x"></i>
                            </div>
                            <div class="col-8 text-right">
                                <span>現在時間</span>

                                <h2 class="font-bold" style="margin-top: 5px; font-size: 30px;">
                                    <telerik:RadAjaxPanel runat="server">
                                        <asp:Timer ID="Timer" runat="server" Interval="1000"></asp:Timer>
                                        <telerik:RadLabel runat="server" ID="lblTime"></telerik:RadLabel>
                                    </telerik:RadAjaxPanel>
                                </h2>

                                <span>IP:<telerik:RadLabel runat="server" ID="lblCardIP"></telerik:RadLabel>
                                </span>
                            </div>
                        </div>


                        <div class="row text-center m-t-sm">
                            <telerik:RadButton runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="打卡" CssClass="btn btn-block btn-outline btn-default"></telerik:RadButton>
                        </div>
                    </div>
                    <div class="widget-text-box">
                        <h4 class="media-heading">打卡資訊</h4>
                        <p>
                            <telerik:RadLabel runat="server" ID="lblCardTime"></telerik:RadLabel>
                        </p>

                    </div>
                    <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge badge-danger animated shake"></telerik:RadLabel>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
