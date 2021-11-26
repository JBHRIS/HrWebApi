<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AuthMenu.aspx.cs" Inherits="Portal.AuthMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnEdit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Message" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>目錄管理</h5>
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
                        <div class="form-group row">
                            <div class="col-sm-8">
                                <telerik:RadButton ID="btnInsert" runat="server" Text="新增" OnClick="btnInsert_Click" CssClass="btn btn-primary btn-sm" />
                                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-primary btn-outline" />
                                <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" Font-Size="Larger" runat="server" />
                            </div>
                            <div class="col-sm-4" id="search_bg">
                                <input type="text" class="form-control form-control-sm m-b-xs" id="filter" placeholder="搜尋表格內的字串">
                            </div>
                            
                        </div>
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container" OnItemCommand="lvMain_ItemCommand" OnNeedDataSource="lvMain_NeedDataSource">
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead class="form_bg">
                                            <tr>
                                                <th>頁面標題</th>
                                                <th>選單名稱</th>
                                                <th>上層名單</th>
                                                <th>動作</th>
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
                                        <td><%# Eval("FileTitle") %></td>
                                        <td><%# Eval("Code") %></td>
                                        <td><%# Eval("ParentCode") %></td>
                                        <td>
                                            <telerik:RadButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Code") %>' CommandName="Edit" Text="編輯" CssClass="btn-white btn btn-xs" />
                                            <button data-toggle="dropdown" class="btn-white btn btn-xs dropdown-toggle" type="button">更多</button>
                                            <ul class="dropdown-menu float-right">
                                                <li><telerik:RadButton ID="btnInsert" runat="server" CommandArgument='<%# Eval("Code") %>' CommandName="Insert" Text="向下新增" CssClass="btn-white btn btn-xs" /></li>
                                                <li><telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("Code") %>' OnClientClicking="ExcuteConfirm" CommandName="Delete" Text="刪除" CssClass="btn-white btn btn-xs" /></li>
                                                <li><telerik:RadButton ID="btnCopy" runat="server" CommandArgument='<%# Eval("Code") %>' CommandName="Copy" Text="複製此項" CssClass="btn-white btn btn-xs" /></li>
                                            </ul>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    無搜尋結果
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                        </telerik:RadAjaxPanel>
                        
                        <%--<div class="form-group row">
                            <label class="col-sm-2 col-form-label">目錄選單</label>
                            <div class="col-sm-10 row">
                                <telerik:RadDropDownTree runat="server" Skin="Bootstrap" ID="ddlMenu" Width="100%" DefaultMessage="請選擇要修改的目錄...">
                                    <DropDownSettings CloseDropDownOnSelection="true" />
                                </telerik:RadDropDownTree>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-2 col-sm-offset-2">
                                <telerik:RadButton ID="btnEdit" runat="server" Text="管理" OnClick="btnEdit_Click" CssClass="btn btn-primary btn-sm" />
                                <telerik:RadButton ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" CssClass="btn btn-w-m btn-danger" />
                            </div>
                                <telerik:RadLabel runat="server" CssClass="badge badge-danger" Font-Size="Larger" ID="Message"></telerik:RadLabel>
                        </div>--%>
                    </div>
                </div>
                </div>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>

    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
