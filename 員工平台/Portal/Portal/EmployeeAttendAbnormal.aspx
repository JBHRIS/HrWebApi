﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendAbnormal.aspx.cs" Inherits="Portal.EmployeeAttendAbnormal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
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
                        <div class="form-group row">
                            <div class="col-md-3">
                                <label class="col-form-label">員工工號</label>
                                <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="false"
                                    Placeholder="請選擇..."
                                    AutoClose="false"
                                    TagMode="Single"
                                    Width="100%"
                                    ID="ddlEmp"
                                    AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                            </div>
                            <div class="col-md-3">
                                <label class="col-form-label">開始日期</label>
                                <div>
                                    <telerik:RadDatePicker RenderMode="Lightweight" DateInput-DateFormat="yyyy/MM/dd" runat="server" ID="txtDateB" Skin="Bootstrap" Width="100%" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label class="col-form-label">結束日期</label>
                                <div>
                                    <telerik:RadDatePicker RenderMode="Lightweight" DateInput-DateFormat="yyyy/MM/dd" runat="server" ID="txtDateE" Skin="Bootstrap" Width="100%" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-check abc-checkbox cleckbox_sy">
                                    <asp:CheckBox RenderMode="Lightweight" runat="server" ID="isNoCheck" Skin="Bootstrap" Text="只顯示未註記的異常" />
                                </div>
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group row">
                            <div class="col-sm-2 col-sm-offset-2">
                                <%--<asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" PostBackUrl="#ibox-Content" />--%>
                                <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" />
                                <%-- ButtonType="LinkButton" NavigateUrl="#iboxContent" --%>
                            </div>
                            <div>
                                <telerik:RadLabel ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div id="iboxContent" class="ibox">
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
                        <div class="form-group row">
                            <div class="col-sm-8">
                                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-outline btn-primary" />
                            </div>
                            <div class="col-sm-4" id="search_bg">
                                <input type="text" class="form-control form-control-sm m-b-xs" id="filter"
                                    placeholder="搜尋表格內的字串">
                            </div>
                            
                        </div>
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource">
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead  class="form_bg">
                                            <tr>
                                                <th>工號</th>
                                                <th>姓名</th>
                                                <th>出勤日期</th>
                                                <th>異常種類</th>
                                                <th data-hide="phone,tablet">班別名稱</th>
                                                <th data-hide="phone,tablet">已註記</th>
                                                <th data-hide="phone,tablet">註記說明</th>
                                                <th data-hide="phone">異常分鐘數</th>
                                                <th data-hide="phone">刷卡時間</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="9">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td><%# Eval("EmpId") %></td>
                                        <td><%# Eval("EmpName") %></td>
                                        <td><%# Eval("DateA","{0:yyyy-MM-dd}") %></td>
                                        <td><%# Eval("AbnormalType") %></td>
                                        <td><%# Eval("RoteName") %></td>
                                        <td><%# Eval("Marked") %></td>
                                        <td><%# Eval("MarkNote") %></td>
                                        <td><%# Eval("AbnormalMin") %></td>
                                        <td><%# Eval("AttcardTime") %></td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任何異常資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
    <script type="text/javascript">
        document.getElementById("ctl00_ContentPlaceHolder1_btnSearch").onclick = function () { Jump() };

        function Jump() {
            //window.location.href = "#iboxContent";
            document.getElementById("iboxContent").scrollIntoView();
        }
    </script>
    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
