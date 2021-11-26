<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageReportContent.aspx.cs" Inherits="Performance.ManageReportContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlReportType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlReportContent">
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
                                <label class="col-sm-2 col-form-label">樣版代碼/評核內容</label>
                                <div class="col-sm-5 ">
                                    <telerik:RadDropDownList ID="ddlReportType" runat="server" AutoPostBack="true" Width="100%" Skin="Bootstrap" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" />
                                </div>
                                <div class="col-sm-5 ">
                                    <telerik:RadDropDownList ID="ddlReportContent" runat="server" AutoPostBack="true" Width="100%" Skin="Bootstrap" OnSelectedIndexChanged="ddlReportContent_SelectedIndexChanged" />
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
                            <div class="form-group  row">
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnInsert" runat="server" Text="新增" OnClick="btnInsert_Click" CssClass="btn btn-w-m btn-primary" />
                                </div>
                                <div class="col-sm-11">
                                    <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
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
