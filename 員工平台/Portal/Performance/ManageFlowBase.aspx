<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlow.master" AutoEventWireup="true" CodeBehind="ManageFlowBase.aspx.cs" Inherits="Performance.ManageFlowBase" %>

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
                <span class="badge badge-warning">※以下的內容超過200筆，只會載入200筆名單，以節省伺服器的負擔。</span>
            </div>
        </div>
        <div class="form-group  row">
            <div class="col-sm-1 ">
                <telerik:RadButton ID="btnInsert" runat="server" Text="新增" OnClick="btnInsert_Click" CssClass="btn btn-primary" />
            </div>
            <div class="col-sm-11 ">
                <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
            </div>
        </div>
        <telerik:RadListView ID="lvMain" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" OnItemCommand="lvMain_ItemCommand">
            <LayoutTemplate>
                <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                    <thead>
                        <tr>
                            <th data-hide="phone,tablet">工號</th>
                            <th>姓名</th>
                            <th data-hide="phone,tablet">部門</th>
                            <th data-hide="phone,tablet">職稱</th>
                            <th data-hide="phone,tablet">到職日</th>

                            <th>修改者</th>
                            <th>修改日期</th>
                            <th>動作</th>
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
                    <td><%# Eval("DeptName") %></td>
                    <td><%# Eval("JobName") %></td>
                    <td><%# Eval("DateIn") %></td>
                    <td><%# Eval("UpdateMan") %></td>
                    <td><%# Eval("UpdateDate") %></td>
                    <td>
                        <telerik:RadButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Edit" Text="編輯" CssClass="btn-white btn btn-xs" />
                        <button data-toggle="dropdown" class="btn-white btn btn-xs dropdown-toggle" type="button">更多</button>
                        <ul class="dropdown-menu float-right">
                            <li>
                                <telerik:RadButton ID="btnSaveHr" runat="server" CommandArgument='<%# Eval("AutoKey") %>' OnClientClicking="ExcuteConfirm" CommandName="SaveHr" Text="同步回HR" CssClass="btn-white btn btn-xs" />
                            </li>
                            <li>
                                <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AutoKey") %>' OnClientClicking="ExcuteConfirm" CommandName="Delete" Text="刪除" CssClass="btn-white btn btn-xs" />
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
