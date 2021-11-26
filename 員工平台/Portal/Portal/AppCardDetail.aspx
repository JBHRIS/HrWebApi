<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppCardDetail.aspx.cs" Inherits="Portal.AppCardDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInUp">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>打卡詳細資訊 </h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-lg-12 m-b-md">
                                <telerik:RadButton ID="btnBack" runat="server" Text="上一頁" CssClass="btn btn-outline btn-primary" OnClick="btnBack_Click" />
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-lg-6">
                                <div class="row">
                                    <div class="col-lg-4">
                                        <asp:HyperLink ID="hlMap" runat="server" NavigateUrl="https://www.google.com/maps/search/?api=1&amp;query=25.01642096483497,121.29815943780103" Target="_blank">顯示地圖位置</asp:HyperLink>
                                    </div>
                                    <div class="col-lg-4">打卡地址：<telerik:RadLabel ID="lblAddress" runat="server" Text="桃園-傑報公司" /></div>
                                    <div class="col-lg-4">
                                        <label>打卡日期：<telerik:RadLabel ID="lblDate" runat="server" Text="2021/9/7" /></label>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>打卡時間：<telerik:RadLabel ID="lblTime" runat="server" Text="08:30" /></label>
                                    </div>
                                </div>
                                <div class="row">
                                    <%--<div class="col-lg-4">
                                        <label>修改時間：<telerik:RadLabel ID="lblChangeTime" runat="server" Text="無修改時間" /></label>
                                    </div>--%>
                                    <div class="col-lg-4">
                                        <label>座標：<telerik:RadLabel ID="lblCoordinat" runat="server" Text="25.01642096483497,121.29815943780103" /></label>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>BSSID碼：<telerik:RadLabel ID="lblBssid" runat="server" Text="f4:28:53:7d:64:48" /></label>
                                    </div>
                                </div>
                                <%--<div class="row">
                                    <div class="col-lg-12">
                                        <label>QRCode碼：<telerik:RadLabel ID="lblQrcode" runat="server" Text="testtesttesttesttest" /></label>
                                    </div>
                                </div>--%>

                                <%--<div class="row">
                                    <div class="col-lg-12 m-b-sm">上傳圖片</div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">未上傳圖片</div>
                                    如果要顯示圖片,使用這段
                                            <div class="row">
                                            <div class="col-lg-4 AppCard_img"></div>
                                            <div class="col-lg-4 AppCard_img"></div>
                                            <div class="col-lg-4 AppCard_img"></div> 
                                </div>--%>
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
