<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppCardType.aspx.cs" Inherits="Portal.AppCardType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">








    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>新增打卡類型</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">打卡類型名稱</label>
                            <div class="col-sm-10 col-lg-4 row">
                                 <telerik:RadTextBox ID="txt_CardName" runat="server" EmptyMessage="打卡類型名稱" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">打卡代碼名稱</label>
                            <div class="col-sm-10 col-lg-4 row">
                                 <telerik:RadTextBox ID="txt_CardType" runat="server" EmptyMessage="打卡代碼名稱" CssClass="form-control" Width="100%" />
                            </div>
                        </div>

                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">排序</label>
                            <div class="col-sm-10 col-lg-4 row">
                                 <telerik:RadTextBox ID="txt_ItemOrder" runat="server" EmptyMessage="排序" CssClass="form-control" Width="100%" InputType="Number" />
                            </div>
                        </div>
                        
                        <div class="hr-line-dashed"></div>
                        <div class="form-group  row">
                            <label class="col-sm-2 col-form-label">
                                 <%--<telerik:RadButton ID="btn_Save_CardType" runat="server" Text="新增" CssClass="btn btn-primary btn-sm" OnClick="btn_Save_CardType_Click" />--%>

                                <telerik:RadButton ID="btnSearch" runat="server" Text="新增查詢" CssClass="btn btn-primary btn-sm" OnClick="btn_Save_CardType_Click" />


                                


                                
                            </label>
                            <div class="col-sm-10 row">
                                
                            </div>
                        </div>

                    </div>
                </div>
            </div>

         
        </div>
    </div>







    <div>

           <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>內容</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                       <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" Skin=""
                                 ItemPlaceholderID="Container" 
                           OnItemCommand="lvMain_ItemCommand"
                           OnNeedDataSource="Table_PunchCardType_NeedDataSource" > 
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead>
                                            <tr>
                                                <th>卡片名稱</th>
                                                <th>卡片代碼</th>
                                                <th>排序</th>
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
                                        <td><%# Eval("CardName") %></td>
                                        <td><%# Eval("CardType") %></td>
                                        <td><%# Eval("ItemOrder") %></td>
                                        <td>
                                            <telerik:RadButton ID="btn_Delete" runat="server" Text="刪除" CommandName="Delete" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任BSSID資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                            </telerik:RadAjaxPanel>









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



