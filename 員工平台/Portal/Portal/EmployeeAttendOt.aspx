<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendOt.aspx.cs" Inherits="Portal.EmployeeAttendOt" %>

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
                        <h5><telerik:RadLabel runat="server" ID="lblConditionDic" Text="條件"></telerik:RadLabel></h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="form-group row">
                            <div class="col-md-3">
                                <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblEmpDic" Text="員工工號"></telerik:RadLabel></label>
                                <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="false"
                                    Placeholder="請選擇..."
                                    AutoClose="false"
                                    TagMode="Single"
                                    Width="100%"
                                    ID="ddlEmp"
                                    AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                                <%--<telerik:RadButton ID="btnEmpSelectAll" runat="server" Text="全選" OnClick="btnEmpSelectAll_Click"  Visible="false" CssClass="btn btn-success btn-xs" />--%>
                            </div>

                            <div class="col-md-3">
                                <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblBeginDateDic" Text="開始日期"></telerik:RadLabel></label>
                                <div>
                                    <telerik:RadDatePicker RenderMode="Lightweight" runat="server" DateInput-DateFormat="yyyy/MM/dd" ID="txtDateB" Skin="Bootstrap" Width="100%" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblEndDateDic" Text="結束日期"></telerik:RadLabel></label>
                                <div>
                                    <telerik:RadDatePicker RenderMode="Lightweight" runat="server" DateInput-DateFormat="yyyy/MM/dd" ID="txtDateE" Skin="Bootstrap" Width="100%" />
                                </div>
                            </div>
                            <div class="col-sm-3 form-inline m-t-lg">
                                <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" />
                                <telerik:RadLabel ID="lblMsg" runat="server" />
                            </div>
                           
                               
  
                        </div>
                        
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="ibox">
                    <div id="iboxContent" class="ibox-title">
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
                        <div class="form-group row">
                            <div class="col-sm-8">
                                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-primary btn-outline" />
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
                                        <thead class="form_bg">
                                            <tr>
                                                <th><telerik:RadLabel runat="server" ID="lblEmpIdDic" Text="工號"></telerik:RadLabel></th>
                                                <th><telerik:RadLabel runat="server" ID="lblEmpNameDic" Text="姓名"></telerik:RadLabel></th>
                                                <th><telerik:RadLabel runat="server" ID="lblOtDateDic" Text="加班日期"></telerik:RadLabel></th>
                                                <th><telerik:RadLabel runat="server" ID="lblBeginTimeDic" Text="開始時間"></telerik:RadLabel></th>
                                                <th><telerik:RadLabel runat="server" ID="lblEndTimeDic" Text="結束時間"></telerik:RadLabel></th>
                                                <th data-hide="phone"><telerik:RadLabel runat="server" ID="lblTotalHourDic" Text="總時數"></telerik:RadLabel></th>
                                                <th data-hide="phone"><telerik:RadLabel runat="server" ID="lblOtHourDic" Text="加班時數"></telerik:RadLabel></th>
                                                <th data-hide="phone"><telerik:RadLabel runat="server" ID="lblRestHourDic" Text="補休時數"></telerik:RadLabel></th>
                                                <th data-hide="phone,tablet"><telerik:RadLabel runat="server" ID="lblOtReasonDic" Text="加班原因"></telerik:RadLabel></th>
                                                <th data-hide="phone,tablet"><telerik:RadLabel runat="server" ID="lblNoteDic" Text="備註"></telerik:RadLabel></th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="11">
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
                                        <td><%# Eval("OtBeginTime") %></td>
                                        <td><%# Eval("OtEndTime") %></td>
                                        <td><%# Eval("TotalTime") %></td>
                                        <td><%# Eval("OtTime") %></td>
                                        <td><%# Eval("RestTime") %></td>
                                        <td><%# Eval("OtReason") %></td>
                                        <td><%# Eval("Note") %></td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任何加班資料
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
