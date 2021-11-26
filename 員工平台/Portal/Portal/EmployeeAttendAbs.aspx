<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendAbs.aspx.cs" Inherits="Portal.EmployeeAttendAbs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlEmp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="AbsType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
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
                                <%--                                    <telerik:RadMultiSelect runat="server" Skin="Bootstrap"
                                        Placeholder="請選擇..."
                                        AutoClose="false"
                                        TagMode="Multiple"
                                        Width="100%"
                                        ID="ddlEmp"            />--%>
                                <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="false" CssClass="select2_demo_1"
                                    Placeholder="請選擇..."
                                    AutoClose="false"
                                    TagMode="Single"
                                    Width="100%"
                                    ID="ddlEmp"
                                    AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                                <telerik:RadButton ID="btnEmpSelectAll" runat="server" Text="全選" OnClick="btnEmpSelectAll_Click" Visible="false" CssClass="btn btn-success btn-xs" />
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
                                <label class="col-form-label">請假類別</label>
                                <%--<telerik:RadMultiSelect runat="server" Skin="Bootstrap"
                                        Placeholder="請選擇..."
                                        AutoClose="false"
                                        TagMode="Multiple"
                                        Width="100%"
                                        ID="AbsType" />--%>

                                <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="false"
                                    Placeholder="請選擇..."
                                    AutoClose="false"
                                    TagMode="Single"
                                    Width="100%"
                                    ID="ddlHcode"
                                    AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…" />
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="form-group row">
                            <div class="col-sm-2 col-sm-offset-2">
                                <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" />
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
                        <div class="panel blank-panel">
                            <div class="panel-heading">
                                <div class="panel-options">
                                    <ul class="nav nav-tabs">
                                        <li>
                                            <a class="nav-link active" href="#tabTaken" data-toggle="tab">請假</a>
                                        </li>
                                        <li>
                                            <a class="nav-link" href="#tabEntitle" data-toggle="tab">得假</a>
                                        </li>
                                    </ul>
                                </div>
                            </div>

                            <div class="panel-body">
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tabTaken">
                                        <div class="row">
                                            <div class="col-sm-8">
                                                <telerik:RadButton ID="btnExportExcelTaken" runat="server" Text="匯出" Visible="false" OnClick="btnExportExcelTaken_Click" CssClass="btn btn-w-m btn-primary btn-outline" />
                                            </div>
                                            <div class="col-sm-4" id="search_bg">
                                                <input type="text" class="form-control form-control-sm m-b-xs"  id="filterTaken"
                                                 placeholder="搜尋表格內的字串">
                                            </div>
                                            
                                        </div>
                                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                            <telerik:RadListView ID="lvMainTaken" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMainTaken_NeedDataSource">
                                                <LayoutTemplate>
                                                    <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                                                        <thead class="form_bg">
                                                            <tr>
                                                                <th>工號</th>
                                                                <th>姓名</th>
                                                                <th>假別名稱</th>
                                                                <th>請假日期</th>
                                                                <th>開始時間</th>
                                                                <th>結束時間</th>
                                                                <th data-hide="phone,tablet">請假時數(天數)</th>
                                                                <th data-hide="phone,tablet">單位</th>
                                                                <th data-hide="phone,tablet">備註</th>
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
                                                        <td><%# Eval("AbsName") %></td>
                                                        <td><%# Eval("DateA","{0:yyyy-MM-dd}") %></td>
                                                        <td><%# Eval("AbsBeginTime") %></td>
                                                        <td><%# Eval("AbsEndTime") %></td>
                                                        <td><%# Eval("AbsHours") %></td>
                                                        <td><%# Eval("Unit") %></td>
                                                        <td><%# Eval("Note") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    目前並無請假資料
                                                </EmptyDataTemplate>
                                            </telerik:RadListView>
                                        </telerik:RadAjaxPanel>
                                    </div>
                                    <div class="tab-pane" id="tabEntitle">
                                        <div class="from-group row">
                                           
                                            <div class="col-sm-8">
                                                <telerik:RadButton ID="btnExportExcelEntitle" runat="server" Text="匯出" Visible="false" OnClick="btnExportExcelEntitle_Click" CssClass="btn btn-w-m btn-primary btn-outline" />
                                            </div>
                                             <div class="col-sm-4" id="search_bg">
                                                <input type="text" class="form-control form-control-sm m-b-xs" id="filterEntitle"
                                                    placeholder="搜尋表格內的字串">
                                            </div>
                                        </div>
                                        <telerik:RadAjaxPanel ID="plMain1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                            <telerik:RadListView ID="lvMainEntitle" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMainEntitle_NeedDataSource">
                                                <LayoutTemplate>
                                                    <table id="footableEntitle" class="footable table table-stripped" data-page-size="10" data-filter="#filterEntitle">
                                                        <thead class="form_bg">
                                                            <tr>
                                                                <th>工號</th>
                                                                <th>姓名</th>
                                                                <th>假別名稱</th>
                                                                <th>生效日期</th>
                                                                <th>失效日期</th>
                                                                <th>得假</th>
                                                                <th>已請</th>
                                                                <th data-hide="phone,tablet">剩餘</th>
                                                                <th data-hide="phone,tablet">單位</th>
                                                                <th data-hide="phone,tablet">備註</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody id="Container" runat="server">
                                                        </tbody>
                                                        <tfoot>
                                                            <tr>
                                                                <td colspan="10">
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
                                                        <td><%# Eval("AbsName") %></td>
                                                        <td><%# Eval("EffectiveDate","{0:yyyy-MM-dd}") %></td>
                                                        <td><%# Eval("ExpirationDate","{0:yyyy-MM-dd}") %></td>
                                                        <td><%# Eval("Entitle") %></td>
                                                        <td><%# Eval("Leaved") %></td>
                                                        <td><%# Eval("Remaining") %></td>
                                                        <td><%# Eval("Unit") %></td>
                                                        <td><%# Eval("Note") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <EmptyDataTemplate>
                                                    目前並無得假資料
                                                </EmptyDataTemplate>
                                            </telerik:RadListView>
                                        </telerik:RadAjaxPanel>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <telerik:RadLabel runat="server" ID="TotalTime" Visible="false"></telerik:RadLabel>
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
            $('.footableTaken').footable();
            $('.footableEntitle').footable();
        });
    </script>
</asp:Content>
