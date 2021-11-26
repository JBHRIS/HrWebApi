<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsChk.master" AutoEventWireup="true" CodeBehind="FormAppointChk.aspx.cs" Inherits="Portal.FormAppointChk" %>

<%@ Register Src="~/UserControls/UC_FileView.ascx" TagPrefix="uc1" TagName="UC_FileView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnLoadinSalary">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plSalary" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblError" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <asp:Panel runat="server" ID="plAudit" Visible="false">
        <div>
            <div class="row col-lg-6">
                <%--<div class="col col-xs-2  m-t-sm">
                    <span>
                        <label class="p-xs">
                            <telerik:RadCheckBox ID="cbAudit" runat="server" Text="允許審核" />
                        </label>
                    </span>
                </div>--%>
                <div class="col col-xs-2  m-t-sm">
                    <span>
                        <label class="p-xs">
                            <telerik:RadButton ID="btnLoadinSalary" OnClick="btnLoadinSalary_Click" CssClass="btn-outline btn-primary" runat="server" Text="載入薪資" />
                        </label>
                    </span>
                </div>

                <div class="col col-xs-2  m-t-sm">
                    <span>
                        <label class="p-xs">
                            <telerik:RadButton ID="btnCancelSalary" Visible="false" CssClass="btn-outline btn-primary" runat="server" Text="清空薪資" />
                        </label>
                    </span>
                </div>

            </div>
        </div>
    </asp:Panel>
    <div class="ibox-content">
        <div class="text-right">
            <telerik:RadAjaxPanel runat="server">
                <div class="text-right">
                    <telerik:RadButton ID="btnJobChange" runat="server" data-toggle="modal" data-target="#myModal" Text="職務異動紀錄" CssClass="btn btn-outline btn-success text-right">
                    </telerik:RadButton>
                </div>
            </telerik:RadAjaxPanel>
        </div>
        <div class="modal inmodal" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h5 class="modal-title">職務異動紀錄</h5>
                    </div>
                    <div class="modal-body">
                        <div class="table-responsive">
                            <telerik:RadListView ID="lvAppointChangeLog" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container">
                                <LayoutTemplate>
                                    <table class="table table-striped" data-page-size="10" data-filter="#filter">
                                        <thead>
                                            <tr>
                                                <th>編制部門</th>
                                                <th>簽核部門</th>
                                                <th>職等</th>
                                                <th>職稱</th>
                                                <th>異動者</th>
                                                <th>異動日期</th>
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
                                        <td><%# Eval("DeptNameChange") %></td>
                                        <td><%# Eval("DeptmNameChange") %></td>
                                        <td><%# Eval("JobNameChange") %></td>
                                        <td><%# Eval("JoblCodeChange") %></td>
                                        <td><%# Eval("InsertMan") %></td>
                                        <td><%# Eval("InsertDate","{0:yyyy/MM/dd HH:mm}") %></td>
                                    </tr>
                                </ItemTemplate>

                            </telerik:RadListView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-3">
                <label class="col-form-label">員工姓名</label>
                <telerik:RadLabel ID="lblEmpName" CssClass="form-control" runat="server" Text="王大明,A0550" />
            </div>

            <div class="col-md-3">
                <label class="col-form-label">學歷</label>
                <telerik:RadLabel ID="lblSchoolName" CssClass="form-control" runat="server" Text="國立台灣大學" />
            </div>

            <div class="col-md-2">
                <label class=" col-form-label">出生日期</label>
                <telerik:RadLabel ID="lblBirthday" CssClass="form-control" runat="server" Text="1857/5/5" />
            </div>

            <div class="col-md-2">
                <label class=" col-form-label">到職日期</label>
                <telerik:RadLabel ID="lblDateIn" CssClass="form-control" runat="server" Text="2021/01/02" />
            </div> 
            <div class="col-md-2">
                <label class=" col-form-label">異動項目</label>
                <telerik:RadLabel ID="lblChangeItem" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-3">
                <label class=" col-form-label">部門</label>
                <telerik:RadLabel ID="lblDeptName" CssClass="form-control" runat="server" Text="人資部" />
            </div>

            <div class="col-md-1">
                <label class=" col-form-label">職等</label>
                <telerik:RadLabel ID="lblJoblName" CssClass="form-control" runat="server" Text="2" />
            </div>

            <div class="col-md-2">
                <label class=" col-form-label">職稱</label>
                <telerik:RadLabel ID="lblJobName" CssClass="form-control" runat="server" Text="助理" />
            </div>

            <div class="col-md-3">
                <label class=" col-form-label">任職日期</label>
                <telerik:RadLabel ID="lblDateA" CssClass="form-control" runat="server" Text="2020/02/12" />
            </div>

            <div class="col-md-3">
                <label class=" col-form-label">簽核部門</label>
                <telerik:RadLabel ID="lblDeptm" CssClass="form-control" runat="server" Text="人資部" />
            </div>
        </div>
        <div class="row form-group">
            <div class="col-md-3">
                <label class=" col-form-label">調動部門</label>
                <telerik:RadComboBox ID="ddlDept" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                    ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%">
                </telerik:RadComboBox>
            </div>

            <div class="col-md-1">
                <label class=" col-form-label">調動職等</label>
                <telerik:RadComboBox ID="ddlJobl" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                    ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%">
                </telerik:RadComboBox>
            </div>


            <div class="col-md-2">
                <label class=" col-form-label">調動職稱</label>
                <telerik:RadComboBox ID="ddlJob" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                    ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%">
                </telerik:RadComboBox>
            </div>


            <div class="col-md-3">
                <label class=" col-form-label">調動任職日期</label>
                <div class="input-group date">
                    <telerik:RadDatePicker ID="txtDateAppoint" RenderMode="Lightweight" runat="server" Skin="Bootstrap" Width="100%" />
                </div>
            </div>

            <div class="col-md-3">
                <label class=" col-form-label">調動簽核部門</label>
                <telerik:RadComboBox ID="ddlDeptm" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                    ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="row form-group">
            <div class="col-lg-6">
                <label class=" col-form-label">異動原因</label>
                <telerik:RadTextBox ID="txtReasonChange" runat="server" Skin="Bootstrap" Enabled="false" Rows="3" TextMode="MultiLine" Width="100%" />
            </div>
            <div class="col-md-6">

                <label class="col-form-label">考績紀錄</label>

                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>年度</th>
                            <th>
                                <telerik:RadLabel ID="lblyear1" runat="server" Text="105" />
                            </th>
                            <th>
                                <telerik:RadLabel ID="lblyear2" runat="server" Text="106" />
                            </th>
                            <th>
                                <telerik:RadLabel ID="lblyear3" runat="server" Text="107" />
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>考績</td>
                            <td>
                                <telerik:RadLabel ID="lblPerformance1" runat="server" Text="3+" />
                            </td>
                            <td>
                                <telerik:RadLabel ID="lblPerformance2" runat="server" Text="3" />
                            </td>
                            <td>
                                <telerik:RadLabel ID="lblPerformance3" runat="server" Text="2" />
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>
        </div>
        <asp:Panel runat="server" ID="plSalary" Visible="false">
            <div class="hr-line-dashed"></div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="bg-muted p-xs b-r-sm  m-b-sm">薪資調整</div>

                    <div class="text-right m-b-sm">
                        <telerik:RadAjaxPanel runat="server">
                            <div class="text-right">
                                <telerik:RadButton ID="btnSalaryChange" runat="server" data-toggle="modal" data-target="#myModa3" Text="薪資異動紀錄" CssClass="btn btn-outline btn-success text-right">
                                </telerik:RadButton>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>

                <div class="modal inmodal fade" id="myModa3" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                <h5 class="modal-title">薪資異動紀錄</h5>
                            </div>
                            <div class="modal-body">
                                <div class="table-responsive">
                                    <telerik:RadListView ID="lvSalaryLog" runat="server" OnNeedDataSource="lvSalaryLog_NeedDataSource" RenderMode="Lightweight" ItemPlaceholderID="Container">
                                        <LayoutTemplate>
                                            <div class="table-responsive">
                                                <table class="table table-striped" data-page-size="10" data-filter="#filter">
                                                    <thead>
                                                        <tr>
                                                            <th>異動人員</th>
                                                            <th>薪資資料</th>
                                                            <th>異動日期</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="Container" runat="server">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr class="gradeX">
                                                <td><%# Eval("InsertMan") %> </td>
                                                <td><%# Eval("SalaryData") %></td>
                                                <td><%# Eval("InsertDate") %></td>
                                            </tr>
                                        </ItemTemplate>

                                    </telerik:RadListView>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <telerik:RadListView ID="lvSalary" OnNeedDataSource="lvSalary_NeedDataSource" OnDataBound="lvSalary_DataBound" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container">
                        <LayoutTemplate>
                            <table class="footable table table-stripped" data-filter="#filter">
                                <thead>
                                    <tr>
                                        <th>薪資項目</th>
                                        <th>原金額</th>
                                        <th>金額</th>
                                    </tr>
                                </thead>
                                <tbody id="Container" runat="server">
                                </tbody>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <telerik:RadLabel runat="server" ID="SalaryName" Text='<%# Eval("Text") %>'></telerik:RadLabel>
                                    <telerik:RadLabel runat="server" ID="SalaryCode" Text='<%#Eval("Column1") %>' Visible="false"></telerik:RadLabel>
                                </td>
                                <td>
                                    <telerik:RadLabel runat="server" ID="Amount" Text='<%# Eval("Value") %>'></telerik:RadLabel>
                                </td>
                                <td>
                                    <telerik:RadTextBox runat="server" ID="Salary" CssClass="form-control" InputType="Number"></telerik:RadTextBox></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            目前並無任何薪資資料
                        </EmptyDataTemplate>

                    </telerik:RadListView>
                </div>

            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="plPromotion">
            <div class="hr-line-dashed"></div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="bg-muted p-xs b-r-sm  m-b-md">人事晉升復核表</div>

                    <div class="form-group row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class=" col-form-label">現任職務執行情形之考評</label>
                                <telerik:RadTextBox ID="txtPerformance1" runat="server" Skin="Bootstrap" Width="100%" EmptyMessage="請具體記述擬晉升人對現任職務之執行情形是否達於優良水準,並列述認定之理由..." Rows="12" TextMode="MultiLine" />
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class=" col-form-label">適任性之判斷</label>
                                <telerik:RadTextBox ID="txtPerformance2" runat="server" Skin="Bootstrap" Width="100%" EmptyMessage="請記述擬晉升人能否勝任擬晉升之職務,及判斷之理由..." Rows="12" TextMode="MultiLine" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="plLog">
            <div class="hr-line-dashed"></div>
            <telerik:RadListView runat="server" ID="lvPerformanceLog" RenderMode="Lightweight" ItemPlaceholderID="Container">
                <LayoutTemplate>
                    <table class="footable table table-stripped" data-filter="#filter">
                        <thead>
                            <tr>
                                <th>現任職務執行情形之考評</th>
                                <th>適任性之判斷</th>
                            </tr>
                        </thead>
                        <tbody id="Container" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <telerik:RadLabel runat="server" ID="lblPerformace1" Text='<%# Eval("Performance1") %>'></telerik:RadLabel>
                        </td>
                        <td>
                            <telerik:RadLabel runat="server" ID="lblPerformace2" Text='<%# Eval("Performance2") %>'></telerik:RadLabel>
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    目前並無任何薪資資料
                </EmptyDataTemplate>
            </telerik:RadListView>
        </asp:Panel>
        <div class="col-md-2">
            <telerik:RadAjaxPanel runat="server">
                <telerik:RadButton ID="btnConfirm" CssClass="btn-outline btn-primary" runat="server" Text="更新" OnClick="btnConfirm_Click" />
            </telerik:RadAjaxPanel>
        </div>
        <telerik:RadLabel ID="lblError" runat="server" CssClass="badge badge-danger"></telerik:RadLabel>

        <telerik:RadLabel ID="lblProcessID" runat="server" Visible="false"></telerik:RadLabel>
        <telerik:RadLabel ID="lblNobrAppM" runat="server" Visible="False"></telerik:RadLabel>
        <telerik:RadLabel ID="lblCode" runat="server" Visible="False"></telerik:RadLabel>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
