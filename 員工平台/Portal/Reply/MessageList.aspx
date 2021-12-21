<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs" Inherits="Portal.MessageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ibox">
        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            <div class="ibox-content">

                <div class="row">
                    <div class="col-lg-7">
                        <h2>預設訊息設定</h2>
                    </div>
                    <div class="col-lg-5">
                        <div class="row">
                            <div class="col-lg-4 text-right m-b-xs">
                                <telerik:RadButton ID="btnAdd" runat="server" Text="建立" OnClick="btnAdd_Click" CssClass="btn btn-primary btn-md m-t-xs">
                                    <Icon PrimaryIconCssClass="rbAdd" />
                                </telerik:RadButton>
                            </div>
                            <div class="col-lg-8">
                                 <input type="text" class="form-control form-control-sm m-b-xs" id="filter"
                                    placeholder="搜尋表格內的字串">
                                <!--<select class="form-control m-b" name="account">
                                 <option>未回覆</option>
                                 <option>操作問題</option>
                                 <option>畫面異常</option>
                                 <option>建議</option>
                                 <option>其他</option>
                           </select>-->
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row m-t-lg">
                    <div class="col-lg-12">

                        <telerik:RadListView ID="lvMain" runat="server" ItemPlaceholderID="Container" OnItemCommand="lvMain_ItemCommand" OnNeedDataSource="lvMain_NeedDataSource">
                            <LayoutTemplate>
                                 <table id="footable" class="footable table table-stripped rwd-table" data-page-size="10" data-filter="#filter">
                                    <thead>
                                        <tr>
                                            <th class="col-lg-2">標題</th>
                                            <th class="col-lg-4">內容</th>
                                            <th>新增日期</th>
                                            <th>新增人員</th>
                                            <th>更新日期</th>
                                            <th>更新人員</th>
                                            <th>操作</th>
                                        </tr>
                                    </thead>
                                    <tbody id="Container" runat="server">
                                        <tr>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td>
                                                    <td colspan="9">
                                                <ul class="pagination float-right"></ul>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                               
                                <tr class="gradeX" >

                                    <td data-th="標題"><%# Eval("Name") %></td>
                                    <td data-th="內容"><%# Eval("Contents") %></td>
                                    <td data-th="新增日期"><%# Eval("InsertDate","{0:yyyy-MM-dd}") %></td>
                                    <td data-th="新增人員"><%# Eval("InsertMan") %></td>
                                    <td data-th="更新日期"><%# Eval("UpdateDate","{0:yyyy-MM-dd}") %></td>
                                    <td data-th="更新人員"><%# Eval("UpdateMan") %></td>
                                    <td data-th="操作">
                                        <telerik:RadButton ID="btnUpdate" CommandArgument='<%# Eval("Code") %>' CommandName="Update" runat="server" Text="編輯" CssClass="btn btn-white btn-xs" >
                                            <Icon PrimaryIconCssClass="rbEdit" /> 
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnDelete" CommandArgument='<%# Eval("Code") %>' CommandName="Delete" runat="server" Text="刪除" CssClass="btn btn-white btn-xs" >
                                            <Icon PrimaryIconCssClass="rbRemove" />
                                        </telerik:RadButton>   
                                    </td>
                                </tr>
                                    
                            </ItemTemplate>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                        <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>


    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });


    </script>

</asp:Content>
