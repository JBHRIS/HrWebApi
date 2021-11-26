<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMailView.aspx.cs" Inherits="Performance.ManageMailView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>條件(只會取得最符合條件的最後插入資料100筆)</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">系統類別</label>
                                <div class="col-sm-10 ">
                                    <telerik:RadDropDownList ID="ddlKey1" runat="server" AutoPostBack="false" Skin="Bootstrap" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">關鍵字</label>
                                <div class="col-sm-10 ">
                                    <telerik:RadTextBox ID="txtSearch" runat="server" CssClass="form-control" Width="100%" EmptyMessage="請輸入關鍵字" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <div class="col-sm-2 col-sm-offset-2">
                                    <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" />
                                </div>
                                <div>
                                    <telerik:RadLabel ID="lblMsgSearch" CssClass="badge badge-danger" runat="server" />
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
                                                <th>收件者信箱</th>
                                                <th>收件者姓名</th>
                                                <th data-hide="phone,tablet">主旨</th>
                                                <th>完成</th>
                                                <th data-hide="phone,tablet">修改者</th>
                                                <th data-hide="phone,tablet">修改日期</th>
                                                <th>動作</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="7">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td>
                                            <telerik:RadTextBox ID="txtAddr" Text='<%# Eval("ToAddr") %>' runat="server" CssClass="form-control" Width="100%" />
                                            <telerik:RadButton ID="btnSave" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Save" Text="儲存" CssClass="btn-white btn btn-xs " />
                                        </td>
                                        <td><%# Eval("ToName") %> </td>
                                        <td><%# Eval("Subject") %></td>
                                        <td><%# Eval("Sucess") %></td>
                                        <td><%# Eval("UpdateMan") %></td>
                                        <td><%# Eval("UpdateDate") %></td>
                                        <td>
                                            <telerik:RadButton ID="btnBody" runat="server" Text="內容" CommandName="Body" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs " />
                                            <button data-toggle="dropdown" class="btn-white btn btn-xs dropdown-toggle" type="button">更多</button>
                                            <ul class="dropdown-menu float-right">
                                                <li>
                                                    <telerik:RadButton ID="btnReSend" runat="server" Text="重送" CommandName="ReSend" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" />
                                                </li>
                                                <li>
                                                    <telerik:RadButton ID="btnDelete" runat="server" Text="刪除" CommandName="Delete" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" OnClientClicking="ExcuteConfirm" />
                                                </li>
                                            </ul>
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
