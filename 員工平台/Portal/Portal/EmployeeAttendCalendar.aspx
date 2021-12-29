<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendCalendar.aspx.cs" Inherits="Portal.EmployeeAttendCalendar" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Skins/MyCustomSkinLite/Button.MyCustomSkin.css" rel="stylesheet" type="text/css" />
    <link href="styles/calendar.css" rel="stylesheet">
    <style>
        .col-form-label{
          white-space:normal;  
        }
    </style>
<script>
    function OnClientLoad(sender, args) {
        sender.get_items()[0]._element.firstChild.style.color = "#23c6c8";
        sender.get_items()[0]._element.children[1].style = "font-weight:600";
        sender.get_items()[0]._element.children[1].style.color = "#24b8ba";
        sender.get_items()[1]._element.firstChild.style.color = "#1c84c6";
        //style the text
        sender.get_items()[1]._element.children[1].style = "font-weight:600";
        sender.get_items()[1]._element.children[1].style.color = "#1778b6";
        sender.get_items()[2]._element.firstChild.style.color = "#1ab394";
        //style the text
        sender.get_items()[2]._element.children[1].style = "font-weight:600";
        sender.get_items()[2]._element.children[1].style.color = "#17977d";
        sender.get_items()[3]._element.firstChild.style.color = "#f8ac59";
        //style the text
        sender.get_items()[3]._element.children[1].style = "font-weight:600";
        sender.get_items()[3]._element.children[1].style.color = "#eba456";
        sender.get_items()[4]._element.firstChild.style.color = "#ed5565";
        //style the text
        sender.get_items()[4]._element.children[1].style = "font-weight:600";
        sender.get_items()[4]._element.children[1].style.color = "#e15665";
		sender.get_items()[5]._element.firstChild.style.color = "#a387be";
        //style the text
        sender.get_items()[5]._element.children[1].style = "font-weight:600";
        sender.get_items()[5]._element.children[1].style.color = "#A06CD5";
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlEmp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cblAttendType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>

    <div class="wrapper wrapper-content animated fadeIn">
        <div id="calendar2" class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>條件</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpDic" Text="員工工號"></telerik:RadLabel></label>
                                <div class="col-sm-10 col-lg-4">
                                    <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="true" OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged"
                                        Placeholder="請選擇..."
                                        AutoClose="false"
                                        TagMode="Single"
                                        Width="100%"
                                        ID="ddlEmp"
                                        AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label"><telerik:RadLabel runat="server" ID="lblAttendTypeDic" Text="出勤種類"></telerik:RadLabel></label>
                                <div class="col-sm-10 col-form-label">
                                    <telerik:RadCheckBoxList ID="cblAttendType" runat="server" Direction="Horizontal" AutoPostBack="true" ClientEvents-OnLoad="OnClientLoad" Skin="MyCustomSkin" EnableEmbeddedSkins="false"  OnSelectedIndexChanged="cblAttendType_SelectedIndexChanged" />
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="ibox" id="calendar">
                    <div class="ibox-title">
                        <h5><telerik:RadLabel runat="server" ID="lblContentDic" Text="內容"></telerik:RadLabel></h5>
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
                            <telerik:RadLabel ID="lblDate" runat="server" Visible="false" />
                            <telerik:RadCalendar RenderMode="Lightweight" ID="cldAttend" Width="100%" EnableMultiSelect="false" EnableKeyboardNavigation="false" Skin="Bootstrap"
                                CellAlign="Left" CellVAlign="Top"
                                ShowColumnHeaders="true" ShowDayCellToolTips="false" SelectedDate="08/10/2015" ShowRowHeaders="true" runat="server"
                                OnDayRender="cldAttend_DayRender"
                                OnDefaultViewChanged="cldAttend_DefaultViewChanged"
                                PresentationType="Preview"
                                AutoPostBack="true" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                <FastNavigationSettings EnableTodayButtonSelection="false">
                                </FastNavigationSettings>
                                <SelectedDates>
                                    <telerik:RadDate Date="2015-08-10" />
                                </SelectedDates>

                            </telerik:RadCalendar>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
            <telerik:RadLabel runat="server" ID="TotalTime" Visible="false"></telerik:RadLabel>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
