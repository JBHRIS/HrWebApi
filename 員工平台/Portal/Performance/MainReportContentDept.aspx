<%@ Page Title="" Language="C#" MasterPageFile="~/MainView.master" AutoEventWireup="true" CodeBehind="MainReportContentDept.aspx.cs" Inherits="Performance.MainReportContentDept" %>

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

    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div class="form-group  row">
            <div class="col-sm-2">
                <telerik:RadButton ID="btnCopy" runat="server" Text="複製(覆蓋)此次樣版" OnClick="btnCopy_Click" OnClientClicking="ExcuteConfirm"  CssClass="btn btn-w-m btn-primary" />
            </div>
            <div class="col-sm-1">
                <telerik:RadButton ID="btnInsert" runat="server" Text="新增" OnClick="btnInsert_Click" CssClass="btn btn-w-m btn-primary" />
            </div>
            <div class="col-sm-9">
                <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
            </div>
        </div>
        <div class="form-group  row">
            <div class="col-sm-11 ">
                <input type="text" class="form-control form-control-sm m-b-xs" id="filter" placeholder="搜尋表格內的字串">
            </div>
            <div class="col-sm-1 ">
                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-info" />
            </div>
        </div>
        <telerik:RadListView ID="lvMain" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" OnItemCommand="lvMain_ItemCommand">
            <LayoutTemplate>
                <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                    <thead>
                        <tr>
                            <th>評核內容</th>
                            <th data-hide="phone,tablet">指標類型/分值</th>
                            <th data-hide="phone,tablet">具體指標或<br />
                                非量化參考指標</th>
                            <th data-hide="phone,tablet">修改者</th>
                            <th data-hide="phone,tablet">修改日期</th>
                            <th>動作</th>
                        </tr>
                    </thead>
                    <tbody id="Container" runat="server">
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="6">
                                <ul class="pagination float-right"></ul>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="gradeX">
                    <td><%# Eval("ReportContentName") %></td>
                    <td><%# Eval("ContentTargetType") %></td>
                    <td><%# Eval("ContentTargetRef") %></td>
                    <td><%# Eval("UpdateMan") %></td>
                    <td><%# Eval("UpdateDate") %></td>
                    <td>
                        <telerik:RadButton ID="btnContentType" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CommandName="ContentType" Text="指標" CssClass="btn-white btn btn-xs" />
                        <telerik:RadButton ID="btnContentRef" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CommandName="ContentRef" Text="參考指標" CssClass="btn-white btn btn-xs" />
                        <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Delete" Text="刪除" OnClientClicking="ExcuteConfirm" CssClass="btn-white btn btn-xs" />
                    </td>
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
        <telerik:RadLabel ID="lblReportTypeCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblReportContentCode" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblSubDept" runat="server" Visible="false" />
        <telerik:RadLabel ID="lblBase" runat="server" Visible="false" />
    </telerik:RadAjaxPanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
