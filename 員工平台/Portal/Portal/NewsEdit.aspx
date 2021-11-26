<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="Portal.NewsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
    <link href="Templates/Inspinia/css/plugins/dropzone/basic.css" rel="stylesheet">
    <link href="Templates/Inspinia/css/plugins/dropzone/dropzone.css" rel="stylesheet">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="lvMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plContent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
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
                        <div class="form-group row">
                            <div class="col-sm-8">
                                 <telerik:RadButton ID="btnInsert" runat="server" Text="新增" OnClick="btnInsert_Click" CssClass="btn btn-primary m-b-sm" />
                                 <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" Font-Size="Larger" runat="server" />
                            </div>
                            <div class="col-sm-4" id="search_bg">
                                <input type="text" class="form-control form-control-sm m-b-xs" id="filter" placeholder="搜尋表格內的字串">
                            </div>

                            <%--<div class="col-sm-1 ">
                                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-info" />
                            </div>--%>
                        </div>
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                           
                            <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" ItemPlaceholderID="Container" OnItemCommand="lvMain_ItemCommand" OnNeedDataSource="lvMain_NeedDataSource">
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead class="form_bg">
                                            <tr>
                                                <th>標題</th>
                                                <th>發布時間</th>
                                                <th>截止時間</th>
                                                <th>是否發布</th>
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
                                        <td><%# Eval("NewsMain") %></td>
                                        <td><%# Eval("NewsDate","{0:yyyy/MM/dd}") %></td>
                                        <td><%# Eval("NewsDeadLine","{0:yyyy/MM/dd}") %></td>
                                        <td><%# Eval("IsOn").ToString() == "True" ?"是":"否" %></td>
                                        <td>
                                            <telerik:RadButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("NewsId") %>' CommandName="Edit" Text="編輯" CssClass="btn-white btn btn-xs"/>
                                               
                                            
                                            <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("NewsId") %>' OnClientClicking="ExcuteConfirm" CommandName="Delete" Text="刪除" CssClass="btn-white btn btn-xs" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    無搜尋結果
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                            </telerik:RadAjaxPanel>
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
