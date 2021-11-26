<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageShareDefault.aspx.cs" Inherits="Performance.ManageShareDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
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
                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">分類</label>
                                <div class="col-sm-10 ">
                                    <telerik:RadDropDownList ID="ddlGroup" runat="server" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" AutoPostBack="true" Skin="Bootstrap" />
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="ibox">
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
                            <div class="col-sm-11 ">
                                <input type="text" class="form-control form-control-sm m-b-xs" id="filter" placeholder="搜尋表格內的字串">
                            </div>
                            <div class="col-sm-1 ">
                                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-info" />
                            </div>
                        </div>
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                            <telerik:RadListView ID="lvMain" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" OnItemCommand="lvMain_ItemCommand">
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead>
                                            <tr>
                                                <th>說明</th>
                                                <th>程式對應名稱</th>
                                                <th data-hide="phone,tablet">型態</th>
                                                <th data-hide="phone,tablet">程式使用的值</th>
                                                <th data-hide="phone,tablet">輸入型態</th>
                                                <th data-hide="phone,tablet">系統</th>
                                                <th data-hide="phone,tablet">排序</th>
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
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("FieldKey") %></td>
                                        <td><%# Eval("ColumnTypeName") %></td>
                                        <td><%# Eval("FieldValue") %></td>
                                        <td><%# Eval("FormTypeName") %></td>
                                        <td><%# Eval("SystemUse") %></td>
                                        <td><%# Eval("Sort") %></td>
                                        <td><%# Eval("UpdateMan") %></td>
                                        <td><%# Eval("UpdateDate") %></td>
                                        <td>
                                            <telerik:RadButton ID="btnEdit" runat="server" Text="編輯" CommandName="Edit" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" />
                                            <telerik:RadButton ID="btnDelete" runat="server" Text="刪除" CommandName="Delete" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" OnClientClicking="ExcuteConfirm" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任何資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                             <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>

    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
