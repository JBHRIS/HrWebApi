<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendOverview.aspx.cs" Inherits="Portal.EmployeeAttendOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                        <telerik:RadDatePicker RenderMode="Lightweight" runat="server" DateInput-DateFormat="yyyy/MM/dd" ID="txtDateB" Skin="Bootstrap" Width="100%" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label class="col-form-label">結束日期</label>
                                    <div>
                                        <telerik:RadDatePicker RenderMode="Lightweight" runat="server" DateInput-DateFormat="yyyy/MM/dd" ID="txtDateE" Skin="Bootstrap" Width="100%" />
                                    </div>
                                </div>
                                <div class="col-sm-3 form-inline m-t-lg">
                                    <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" />
                                    <telerik:RadLabel ID="lblMsg" runat="server" />
                                </div>
                            </div>
                            
                        </telerik:RadAjaxPanel>
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
                        <div class="form-group  row">
                            <div class="col-sm-8">
                                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-primary btn-outline" />
                            </div>
                            <div class="col-sm-4" id="search_bg">
                                <input type="text" class="form-control form-control-sm m-b-xs" id="filter" placeholder="搜尋表格內的字串">
                            </div>
                            
                        </div>

                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" OnItemCommand="lvMain_ItemCommand">
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead class="form_bg">
                                            <tr>
                                                <th>工號</th>
                                                <th>姓名</th>
                                                <th>日期</th>
                                                <th data-hide="phone">班別代碼</th>
                                                <th>班別名稱</th>
                                                <th data-hide="phone">班別時間</th>
                                                <th data-hide="phone">刷卡時間</th>
                                                <th data-hide="phone,tablet">請假</th>
                                                <th data-hide="phone,tablet">加班</th>
                                                <th data-hide="phone,tablet">早來晚走</th>
                                                <th data-hide="phone,tablet">遲到(分)</th>
                                                <th data-hide="phone,tablet">早退(分)</th>
                                                <th data-hide="phone,tablet">曠職</th>
                                                <th data-hide="phone,tablet">忘刷(次)</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="14">
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
                                        <td><%# Eval("RoteDisplayName") %></td>
                                        <td><%# Eval("RoteName") %></td>
                                        <td><%# Eval("RoteTime") %></td>
                                        <td><%# Eval("AttcardTime") %></td>
                                        <td><%# Eval("AbsData") %></td>
                                        <td><%# Eval("OtData") %></td>
                                        <td><%# Eval("AbnormalData") %></td>
                                        <td><%# Eval("LateMins") %></td>
                                        <td><%# Eval("EarlyMins") %></td>
                                        <td><%# Eval("IsAbs") %></td>
                                        <td><%# Eval("Forget") %></td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任何資料
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
    <!-- FooTable -->
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
