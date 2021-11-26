<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlow.master" AutoEventWireup="true" CodeBehind="ManageFlowSign.aspx.cs" Inherits="Performance.ManageFlowSign" %>

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
            <div class="col-sm-11 ">
                <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
            </div>
        </div>
        <telerik:RadListView ID="lvMain" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" OnItemCommand="lvMain_ItemCommand">
            <LayoutTemplate>
                <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                    <thead>
                        <tr>
                            <th data-hide="phone,tablet">部門名稱</th>
                            <th>工號</th>
                            <th>姓名</th>
                            <th data-hide="phone,tablet">職稱</th>
                            <th>簽核動作</th>
                            <th data-hide="phone,tablet">簽核意見</th>
                            <th>簽核日期</th>
                            <th>動作</th>
                        </tr>
                    </thead>
                    <tbody id="Container" runat="server">
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="8">
                                <ul class="pagination float-right"></ul>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="gradeX">
                    <td><%# Eval("PerformanceFlowCode") %></td>
                    <td><%# Eval("EmpId") %></td>
                    <td><%# Eval("EmpName") %></td>
                    <td><%# Eval("JobName") %></td>
                    <td><%# Eval("ActiveCode") %></td>
                    <td><%# Eval("Note") %></td>
                    <td><%# Eval("UpdateDate") %></td>
                    <td>
                        <telerik:RadButton ID="btnDelete" runat="server" Text="刪除" CommandName="Delete" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" OnClientClicking="ExcuteConfirm" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                目前並無任何資料
            </EmptyDataTemplate>
        </telerik:RadListView>
        <telerik:RadLabel ID="lblTypeCode" runat="server"  Visible="false" />
        <telerik:RadLabel ID="lblMainCode" runat="server"  Visible="false" />
        <telerik:RadLabel ID="lblDeptCode" runat="server" Visible="false"  />
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
