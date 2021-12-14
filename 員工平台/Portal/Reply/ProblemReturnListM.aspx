<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturnListM.aspx.cs" Inherits="Portal.ProblemReturnListM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ibox">
        <div class="ibox-content">
            <div class="row">
                <div class="col-lg-7">
                    <h2>回覆管理</h2>
                </div>
                <div class="col-lg-5">
                    <div class="row">
                        <div class="col-lg-4 text-right">
                            <telerik:RadButton ID="btnAdd" runat="server" Text="預設訊息設定" OnClick="btnSet_Click" CssClass="btn btn-primary btn-md m-t-xs" />
                        </div>
                        <div class="col-lg-8">
                            <telerik:RadComboBox ID="txtReturnS" runat="server" Skin="Bootstrap" Width="100%">
                            </telerik:RadComboBox>
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
                   <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                        <telerik:RadListView ID="lvMain" runat="server" ItemPlaceholderID="Container" >
                            <LayoutTemplate>
                                <table id="footable" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                                    <thead>
                                        <tr>
                                            <th>標題</th>
                                            <th>回報類型</th>
                                            <th>填寫日期</th>
                                            <th>回覆日期</th>
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
                                    <td data-th="標題"><%# Eval("TitleContent") %></td>
                                    <td data-th="回報類型"><%# Eval("QuestionCategoryCode") %></td>
                                    <td data-th="填寫日期"><%# Eval("DateE","{0:yyyy-MM-dd}") %></td>
                                    <td data-th="回覆日期"><%# Eval("UpdateDate","{0:yyyy-MM-dd}") %></td>
                                    <td data-th="操作">
                                        <telerik:RadButton ID="btnCheck" runat="server" Text="查看" CommandArgument='<%# Eval("Code") %>' CssClass="btn-white btn btn-xs" Onclick="btnCheck_Click" />
                                    </td>
                                </tr>

                            </ItemTemplate>
                            <EmptyDataTemplate>
                                 無任何回報記錄
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                    </telerik:RadAjaxPanel>
                    <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>
                </div>
            </div>
        </div>
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
