<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageFlowMain.aspx.cs" Inherits="Performance.ManageFlowMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style>
        .k-pdf-export, .k-pdf-export * {
            font-family: 'Arial Unicode MS' !important;
        }
    </style>

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script language="javascript" type="text/javascript">

            function exportElement() {
                var exp = $find("<%= RadClientExportManager1.ClientID %>");
                    exp.exportPDF($telerik.$("#<%= plMain.ClientID %>"));
            }
        </script>
    </telerik:RadCodeBlock>

    <telerik:RadClientExportManager runat="server" ID="RadClientExportManager1">
        <PdfSettings MarginTop="20mm" MarginBottom="20mm" MarginLeft="20mm" MarginRight="20mm" />
    </telerik:RadClientExportManager>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
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
                                <label class="col-sm-2 col-form-label">類別/名稱</label>
                                <div class="col-sm-5 ">
                                    <telerik:RadDropDownList ID="ddlType" Width="100%" runat="server" AutoPostBack="true" Skin="Bootstrap" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" />
                                </div>
                                <div class="col-sm-5 ">
                                    <telerik:RadDropDownList ID="ddlMain" Width="100%" runat="server" AutoPostBack="true" Skin="Bootstrap" OnSelectedIndexChanged="ddlMain_SelectedIndexChanged" />
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>內容</h5>
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
                            <div class="form-group  row">
                                <div class="col-sm-1 ">
                                    <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClientClicking="exportElement" CssClass="btn btn-w-m btn-info" />
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label>考核名稱</label>
                                    <telerik:RadLabel ID="lblInfoName" runat="server" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label>考核年月</label>
                                    <telerik:RadLabel ID="lblInfoYymm" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label>考核類別</label>
                                    <telerik:RadLabel ID="lblInfoTypeName" runat="server" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label>員工類別</label>
                                    <telerik:RadLabel ID="lblInfoEmpCategoryName" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label>可視獎金層級</label>
                                    <telerik:RadLabel ID="lblInfoDeptTreeB" runat="server" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label>結束層級</label>
                                    <telerik:RadLabel ID="lblInfoDeptTreeE" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label>考核開始日期</label>
                                    <telerik:RadLabel ID="lblInfoDateA" runat="server" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label>考核結束日期</label>
                                    <telerik:RadLabel ID="lblInfoDateD" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label>考核部門總數</label>
                                    <telerik:RadLabel ID="lblInfoFlow" runat="server" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label>考核人數</label>
                                    <telerik:RadLabel ID="lblInfoBase" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <label>已完成部門</label>
                                    <telerik:RadLabel ID="lblInfoFlowComplete" runat="server" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label>未完成部門</label>
                                    <telerik:RadLabel ID="lblInfoFlowImperfect" runat="server" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label>中止部門</label>
                                    <telerik:RadLabel ID="lblInfoFlowStop" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <label>總獎金</label>
                                    <telerik:RadLabel ID="lblInfoBonusTotal" runat="server" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label>已發獎金</label>
                                    <telerik:RadLabel ID="lblInfoBonusReal" runat="server" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label>未發獎金</label>
                                    <telerik:RadLabel ID="lblInfoBonusBalance" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <telerik:RadHtmlChart runat="server" ID="ctInfoBonus" Transitions="true" Skin="Silk">

                                        <ChartTitle Text="獎金分配圖">
                                            <Appearance Align="Center" Position="Top">
                                                <TextStyle FontFamily="Arial Unicode MS" />
                                            </Appearance>
                                        </ChartTitle>
                                        <Legend>
                                            <Appearance Position="Right" Visible="true">
                                                <TextStyle FontFamily="Arial Unicode MS" />
                                            </Appearance>
                                        </Legend>
                                    </telerik:RadHtmlChart>
                                </div>
                                <div class="form-group col-md-6">
                                    <telerik:RadHtmlChart runat="server" ID="ctInfoRating" Transitions="true" Skin="Silk">
                                        <ChartTitle Text="評等分配圖">
                                            <Appearance Align="Center" Position="Top">
                                                <TextStyle FontFamily="Arial Unicode MS" />
                                            </Appearance>
                                        </ChartTitle>
                                        <Legend>
                                            <Appearance Position="Right" Visible="true">
                                                <TextStyle FontFamily="Arial Unicode MS" />
                                            </Appearance>
                                        </Legend>
                                    </telerik:RadHtmlChart>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <telerik:RadHtmlChart runat="server" ID="ctInfoDept"  Height="800px" Transitions="true" Skin="Silk">
                                        <PlotArea>
                                            <Appearance>
                                                <FillStyle BackgroundColor="Transparent"></FillStyle>
                                            </Appearance>
                                            <XAxis AxisCrossingValue="0" Color="black" MajorTickType="Outside" MinorTickType="Outside"
                                                Reversed="false">
                                                <LabelsAppearance DataFormatString="{0}" RotationAngle="0" Skip="0" Step="1">
                                                    <TextStyle FontFamily="Arial Unicode MS" />
                                                </LabelsAppearance>
                                                <TitleAppearance Position="Center" RotationAngle="0" Text="部門">
                                                    <TextStyle FontFamily="Arial Unicode MS" />
                                                </TitleAppearance>
                                            </XAxis>
                                            <YAxis AxisCrossingValue="0" Color="black" MajorTickSize="1" MajorTickType="Outside"
                                                MinorTickType="None" Reversed="false">
                                                <LabelsAppearance DataFormatString="${0}" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                                                <TitleAppearance Position="Center" RotationAngle="0" Text="獎金">
                                                    <TextStyle FontFamily="Arial Unicode MS" />
                                                </TitleAppearance>
                                            </YAxis>
                                        </PlotArea>
                                        <Appearance>
                                            <FillStyle BackgroundColor="Transparent"></FillStyle>
                                        </Appearance>
                                        <ChartTitle Text="各部門獎金">
                                            <Appearance Align="Center" BackgroundColor="Transparent" Position="Top">
                                                <TextStyle FontFamily="Arial Unicode MS" />
                                            </Appearance>
                                        </ChartTitle>
                                        <Legend>
                                            <Appearance BackgroundColor="Transparent" Position="Bottom">
                                                <TextStyle FontFamily="Arial Unicode MS" />
                                            </Appearance>
                                        </Legend>
                                    </telerik:RadHtmlChart>
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
