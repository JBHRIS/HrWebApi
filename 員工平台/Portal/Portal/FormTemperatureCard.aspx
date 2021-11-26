<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormTemperatureCard.aspx.cs" Inherits="Portal.FormTemperatureCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/style.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-3">
                <div class="widget-head-color-box navy-bg p-md">
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
                </div>
                <div class="widget-text-box">
                    <h4><strong>今日測量溫度為</strong></h4>
                    <div class="row m-t-sm">
                        <div class="col-9 text-left">
                            <div class="text_green">
                                <telerik:RadButton runat="server" ID="btnRadioNormal" ToggleType="Radio" ButtonType="ToggleButton" Value="1" Checked="True" GroupName="btnTemp" Text="溫度正常（37.5度)" AutoPostBack="false"></telerik:RadButton>
                            </div>

                            <div class="text_red">
                                <telerik:RadButton runat="server" ID="btnRadioAbnormal" ToggleType="Radio" ButtonType="ToggleButton" Value="2" Text='我可能發燒（ 37.5度）' GroupName="btnTemp" AutoPostBack="false"></telerik:RadButton>
                            </div>
                        </div>
                        <div class="col-3 text-right">
                            <i class="fa fa-thermometer-3 fa-4x fa-color" aria-hidden="true"></i>
                        </div>

                    </div>
                    <div class="row m-t-sm">
                        <div class="col-lg-12">
                            <telerik:RadButton runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="打卡" CssClass="btn btn-block btn-w-m btn-primary"></telerik:RadButton>
                        </div>
                        
                    </div>
                </div>
                <div class="widget-text-box">
                    <h4 class="media-heading">打卡資訊</h4>
                    <p> <telerik:RadLabel runat="server" ID="lblCardTime"></telerik:RadLabel> </p>
                </div>
                <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge badge-danger animated shake"></telerik:RadLabel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
