<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlow.master" AutoEventWireup="true" CodeBehind="ManageFlowNode.aspx.cs" Inherits="Performance.ManageFlowNode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
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
            <div class="col ">
                <span class="badge badge-warning">※如果流程已經結束，則通知功能的寄送內容將不會正確</span>
            </div>
        </div>
        <div class="form-group  row">
            <div class="col-sm-2 ">
                <telerik:RadButton ID="btnFlowReStart" runat="server" Text="重送流程" OnClientClicking="ExcuteConfirm" CommandName="ReStart" OnClick="btnFlowSet_Click" CssClass="btn btn-primary" />
            </div>
            <div class="col-sm-2 ">
                <telerik:RadButton ID="btnFlowCancel" runat="server" Text="中止流程" OnClientClicking="ExcuteConfirm" CommandName="Cancel" OnClick="btnFlowSet_Click" CssClass="btn btn-primary" />
            </div>
            <div class="col-sm-2 ">
                <telerik:RadButton ID="btnFlowStart" runat="server" Text="恢復流程" OnClientClicking="ExcuteConfirm" CommandName="Start" OnClick="btnFlowSet_Click" CssClass="btn btn-primary" />
            </div>
            <div class="col-sm-6 ">
                <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
            </div>
        </div>
        <telerik:RadListView ID="lvMain" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" OnItemCommand="lvMain_ItemCommand">
            <LayoutTemplate>
                <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                    <thead>
                        <tr>
                            <th>簽核部門</th>
                            <th>簽核部門(實)</th>
                            <th data-hide="phone,tablet">工號</th>
                            <th data-hide="phone,tablet">姓名</th>
                            <th data-hide="phone,tablet">工號(實)</th>
                            <th>姓名(實)</th>
                            <th>簽核動作</th>
                            <th data-hide="phone,tablet">修改者</th>
                            <th data-hide="phone,tablet">修改日期</th>
                            <th>動作</th>
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
                    <td><%# Eval("PerformanceDeptNameDefault") %></td>
                    <td><%# Eval("PerformanceDeptNameReal") %></td>
                    <td><%# Eval("EmpIdDefault") %></td>
                    <td><%# Eval("EmpNameDefault") %></td>
                    <td><%# Eval("EmpIdReal") %></td>
                    <td><%# Eval("EmpNameReal") %></td>
                    <td><%# Eval("ActiveName") %></td>
                    <td><%# Eval("UpdateMan") %></td>
                    <td><%# Eval("UpdateDate") %></td>
                    <td>
                        <telerik:RadButton ID="btnStart" runat="server" CommandArgument='<%# Eval("AutoKey") %>' OnClientClicking="ExcuteConfirm" CommandName="Start" Text="從這開始" CssClass="btn-white btn btn-xs" />
                        <button data-toggle="dropdown" class="btn-white btn btn-xs dropdown-toggle" type="button">更多</button>
                        <ul class="dropdown-menu float-right">
                            <li>
                                <telerik:RadButton ID="btnChange" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Change" Text="換人" CssClass="btn-white btn btn-xs" />
                            </li>
                            <li>
                                <telerik:RadButton ID="btnMailSend" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CommandName="MailSend" Text="通知" OnClientClicking="ExcuteConfirm" CssClass="btn-white btn btn-xs" />
                            </li>
                            <li>
                                <telerik:RadButton ID="btnReminder" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Reminder" Text="催簽" OnClientClicking="ExcuteConfirm" CssClass="btn-white btn btn-xs" />
                            </li>
                        </ul>
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                目前並無任何資料
            </EmptyDataTemplate>
        </telerik:RadListView>
        <telerik:RadLabel ID="lblTypeCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblMainCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblDeptCode" runat="server" Visible="false" />
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
