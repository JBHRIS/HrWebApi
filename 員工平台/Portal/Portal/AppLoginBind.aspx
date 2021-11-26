<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppLoginBind.aspx.cs" Inherits="Portal.AppLoginBind" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">






       <!-- 查詢 工號 <> 機碼 -->

                <div class="col-lg-12">
                    <div class="ibox ">

                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="ibox-title">
                                <h5>查詢</h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>
                                </div>
                            </div>
                            <div class="ibox-content">
                                
                                <div class="hr-line-dashed"></div>
                                <div class="form-group  row">
                                    <label class="col-sm-2 col-form-label">姓名查詢</label>
                                    <div class="col-sm-10  col-lg-4 row">
                                        <telerik:RadTextBox ID="txt_Sreach_Name" runat="server" EmptyMessage="請輸入姓名" CssClass="form-control" Width="100%" />
                                    </div>
                                </div> 
                                
                                <div class="hr-line-dashed"></div>
                                <div class="form-group  row">
                                    <label class="col-sm-2 col-form-label">工號查詢</label>
                                    <div class="col-sm-10 col-lg-4 row">
                                        <telerik:RadTextBox ID="txt_Sreach_Nobr" runat="server" EmptyMessage="請輸入工號" CssClass="form-control" Width="100%" />
                                    </div>
                                </div>
                                
                                <div class="hr-line-dashed"></div>
                                <div class="form-group row">
                                    <div class="col-sm-2 col-lg-4  col-sm-offset-2">
                                        <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" CssClass="btn btn-primary btn-sm" /> 
                                    </div>
                                    <div>
                                        <telerik:RadLabel ID="lblMsg" runat="server"    />
                                    </div>
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>




    
                <!-- 查詢BSSID -->


                <div class="col-lg-12">
                    <div class="ibox">
                        <div class="ibox-title">
                            <h5>清單</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">

                             <div class="row">
                            <div class="col-sm-11">
                                <input type="text" class="form-control form-control-sm m-b-xs" id="filter"
                                            placeholder="搜尋表格內的字串">
                            </div>
                            <div class="col-sm-1 ">
                                <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" OnClick="btnExportExcel_Click" CssClass="btn btn-w-m btn-info" />
                            </div>
                        </div>



                            <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                            <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" Skin=""
                                 ItemPlaceholderID="Container" OnNeedDataSource="Table_AppRegistryKey_Bind_NeedDataSource"  OnItemCommand="lvMain_ItemCommand">
                                <LayoutTemplate>
                                    <table id="DataTable" class="footable table table-stripped" data-page-size="10" data-filter="#filter" >
                                        <thead>
                                            <tr>
                                                <th>姓名</th>
                                                <th>工號</th>
                                                <th>機碼</th>
                                                <th> </th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="4">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td><%# Eval("Name") %></td>
                                        <td><%# Eval("Nobr") %></td>
                                        <td><%# Eval("APP_RegistryKey") %></td>
                                        <td>
                                            <telerik:RadButton ID="btn_Delete" runat="server" Text="刪除" CommandName="Delete" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任人員資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>

                                </telerik:RadAjaxPanel>
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
