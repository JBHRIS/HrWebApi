<%@ Page Title="" Language="C#" MasterPageFile="~/MainView.master" AutoEventWireup="true" CodeBehind="MainBaseView.aspx.cs" Inherits="Performance.MainBaseView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlYear">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlMonth">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlEmpCategory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlDept">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbSubDept">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="cbBase">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="form-group  row">
        <div class="col-sm-11 ">
            <input type="text" class="form-control form-control-sm m-b-xs" id="filter" placeholder="搜尋表格內的字串">
        </div>
        <div class="col-sm-1 ">
            <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-info" />
        </div>
    </div>
    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="form-group  row">
            <div class="col-sm-2 ">
                <telerik:RadButton ID="btnExportReport" runat="server" Text="匯出評核表" OnClick="btnExportReport_Click" CssClass="btn btn-w-m btn-info" />
            </div>
            <div class="col-sm-10 ">
                <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
            </div>
        </div>
        <telerik:RadListView ID="lvMain" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound">
            <LayoutTemplate>
                <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                    <thead>
                        <tr>
                            <th data-hide="phone,tablet">工號</th>
                            <th>姓名</th>
                            <th data-hide="phone,tablet">職稱</th>
                            <th data-hide="phone,tablet">工作績效</th>
                            <th data-hide="phone,tablet">工作態度</th>
                            <th data-hide="phone,tablet">能力評價</th>
                            <th data-hide="phone,tablet">激勵</th>
                            <th>評核總分</th>
                            <th>評等</th>
                            <th runat="server" id="BonusCardinal" data-hide="phone,tablet">獎金基數</th>
                            <th runat="server" id="BonusAdjust" data-hide="phone,tablet">考績加減</th>
                            <th runat="server" id="BonusReal">總分配獎金</th>
                            <th data-hide="phone,tablet">備註</th>
                        </tr>
                    </thead>
                    <tbody id="Container" runat="server">
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="13">
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
                    <td><%# Eval("JobName") %></td>
                    <td><%# Eval("WorkPerformance","{0:N0}") %></td>
                    <td><%# Eval("MannerEsteem","{0:N0}") %></td>
                    <td><%# Eval("AbilityEsteem","{0:N0}") %></td>
                    <td><%# Eval("Encourage","{0:N0}") %></td>
                    <td><%# Eval("TotalIntegrate","{0:N0}") %></td>
                    <td><%# Eval("RatingName") %></td>
                    <td><%# Eval("BonusCardinal","{0:N0}") %></td>
                    <td><%# Eval("BonusAdjust","{0:N0}") %></td>
                    <td><%# Eval("BonusReal","{0:N0}") %></td>
                    <td><%# Eval("Note") %></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                目前並無任何資料
            </EmptyDataTemplate>
        </telerik:RadListView>
        <telerik:RadLabel ID="lblTypeCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblMainCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblEmpCategoryCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblDeptCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblSubDept" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblBase" runat="server" Visible="false" />
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMain1" runat="server">
    <div class="col-lg-12">
        <div class="ibox">
            <div class="ibox-title">
                <h5>部門資訊</h5>
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
                    <div class="col-sm-1 ">
                        <telerik:RadButton ID="btnExportExcel1" runat="server" Text="匯出" OnClick="btnExportExcel1_Click" CssClass="btn btn-w-m btn-info" />
                    </div>
                </div>
                <telerik:RadAjaxPanel ID="plMain1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <telerik:RadListView ID="lvMain1" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain1_NeedDataSource" OnDataBound="lvMain1_DataBound">
                        <LayoutTemplate>
                            <table class="footable1 table table-stripped" data-page-size="10" data-filter="#filter">
                                <thead>
                                    <tr>
                                        <th>部門名稱</th>
                                        <th data-hide="phone,tablet">評核人數</th>
                                        <th data-hide="phone,tablet">獎金基數總額(a)</th>
                                        <th data-hide="phone,tablet">已分配獎金總額(b)</th>
                                        <th>未分配獎金(c)=a-b</th>
                                    </tr>
                                </thead>
                                <tbody id="Container" runat="server">
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="5">
                                            <ul class="pagination float-right"></ul>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class="gradeX">
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("PeopleNumber") %></td>
                                <td><%# Eval("BonusCardinalSubDept","{0:N0}") %></td>
                                <td><%# Eval("BonusRealSubDept","{0:N0}") %></td>
                                <td><%# Eval("BonusAdjustSubDept","{0:N0}") %></td>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script>
        $(document).ready(function () {
            $('.footable1').footable();
        });
    </script>
</asp:Content>
