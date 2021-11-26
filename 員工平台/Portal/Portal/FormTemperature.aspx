<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormTemperature.aspx.cs" Inherits="Portal.FormTemperature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/style.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-3">
                <div class="widget-text-box">
                    <h4>今日測量溫度為</h4>
                    <div class="row m-t-sm">
                        <div class="col-9 text-left">
                            <div class="row">
                                <div class="text_green">
                                    <telerik:RadButton runat="server" ID="btnRadioNormal" ToggleType="Radio" ButtonType="ToggleButton" Value="1" Checked="True" GroupName="btnTemp" Text="溫度正常（37.5度)" AutoPostBack="false"></telerik:RadButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="text_red">
                                    <telerik:RadButton runat="server" ID="btnRadioAbnormal" ToggleType="Radio" ButtonType="ToggleButton" Value="2" Text='我可能發燒（37.5度）' GroupName="btnTemp" AutoPostBack="false"></telerik:RadButton>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="SelectedOption" runat="server" />
                        <div class="col-3">
                            <i class="fa fa-thermometer-3 fa-4x fa-color" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 m-t-md">
                            <telerik:RadButton runat="server" ID="btnSubmit" Text="確認" OnClick="btnSubmit_Click" CssClass="btn btn-block btn-w-m btn-primary"></telerik:RadButton>
                        </div>
                    </div>
                </div>
                <div class="widget-text-box">
                    <h4 class="media-heading">打卡資訊</h4>
                    <div class="row">

                        <div class="col-7">
                            <telerik:RadLabel runat="server" ID="lblCardTime"></telerik:RadLabel>
                        </div>
                        <div class="col-5">
                            <telerik:RadLabel runat="server" ID="lblTemp"></telerik:RadLabel>
                        </div>
                    </div>

                </div>
                <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge badge-danger animated shake"></telerik:RadLabel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        function OnClientClicked(sender, args) {
            var selectedoption = sender.value();
            //accessing the ASP HiddenField and setting its value
            document.getElementById("SelectedOption").value = selectedoption;
        }
    </script>
</asp:Content>
