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
                                <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblBeginDateDic" Text="開始日期"></telerik:RadLabel></label>
                                <div>
                                    <telerik:RadDatePicker RenderMode="Lightweight" DateInput-DateFormat="yyyy/MM/dd" runat="server" ID="txtDateB" Skin="Bootstrap" Width="100%" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblEndDateDic" Text="結束日期"></telerik:RadLabel></label>
                                <div>
                                    <telerik:RadDatePicker RenderMode="Lightweight" DateInput-DateFormat="yyyy/MM/dd" runat="server" ID="txtDateE" Skin="Bootstrap" Width="100%" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblAbsenceTypeDic" Text="請假類別"></telerik:RadLabel></label>
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
                        <div class="panel blank-panel">
                            <div class="panel-heading">
                                <div class="panel-options">
                                    <ul class="nav nav-tabs">
                                        <li>
                                            <a class="nav-link active" href="#tabTaken" data-toggle="tab"><telerik:RadLabel runat="server" ID="lblAbsenceTakenDic" Text="請假"></telerik:RadLabel></a>
                                        </li>
                                        <li>
                                            <a class="nav-link" href="#tabEntitle" data-toggle="tab"><telerik:RadLabel runat="server" ID="lblAbsenceEntitle" Text="得假"></telerik:RadLabel></a>
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
                                                                <th><telerik:RadLabel runat="server" ID="lblEmpIdDic" Text="工號"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblEmpNameDic" Text="姓名"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblAbsenceNameDic" Text="假別名稱"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblAbsenceDateDic" Text="請假日期"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblBeginTimeDic1" Text="開始時間"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblEndTimeDic1" Text="結束時間"></telerik:RadLabel></th>
                                                                <th data-hide="phone,tablet"><telerik:RadLabel runat="server" ID="lblAbsensceHourDic" Text="請假時數(天數)"></telerik:RadLabel></th>
                                                                <th data-hide="phone,tablet"><telerik:RadLabel runat="server" ID="lblUnitDic" Text="單位"></telerik:RadLabel></th>
                                                                <th data-hide="phone,tablet"><telerik:RadLabel runat="server" ID="lblNoteDic" Text="備註"></telerik:RadLabel></th>
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
                                                    <telerik:radLabel runat="server" ID="lblAbsenceEmptyTakenDic" Text="目前並無請假資料"></telerik:radLabel>
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
                                                                <th><telerik:RadLabel runat="server" ID="lblEmpIdDic1" Text="工號"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblEmpNameDic1" Text="姓名"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblAbsenceNameDic1" Text="假別名稱"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblAbsenceBeginDateDic" Text="生效日期"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblAbsenceEndDateDic" Text="失效日期"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblObtainAbsenceDic" Text="得假"></telerik:RadLabel></th>
                                                                <th><telerik:RadLabel runat="server" ID="lblUseAbsenceDic" Text="已請"></telerik:RadLabel></th>
                                                                <th data-hide="phone,tablet"><telerik:RadLabel runat="server" ID="lblBalanceDic" Text="剩餘"></telerik:RadLabel></th>
                                                                <th data-hide="phone,tablet"><telerik:RadLabel runat="server" ID="lblUnitDic1" Text="單位"></telerik:RadLabel></th>
                                                                <th data-hide="phone,tablet"><telerik:RadLabel runat="server" ID="lblNoteDic1" Text="備註"></telerik:RadLabel></th>
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
                                                    <telerik:radLabel runat="server" ID="lblAbsenceEmptyEntitleDic" Text="目前並無得假資料"></telerik:radLabel>
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
