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
                            <telerik:RadButton ID="btnAdd" runat="server" Text="預設訊息設定" CssClass="btn btn-primary btn-md m-t-xs" />
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
                    <table class="rwd-table">
                        <tr>
                            <th>標題</th>
                            <th>回報類型</th>
                            <th>填寫日期</th>
                            <th>回覆日期</th>
                            <th>動作</th>
                        </tr>

                        <tr>
                            <td data-th="標題">標題限制30字標題限制30字標題限制30字標題限制30字</td>
                            <td data-th="回報類型">系統操作 </td>
                            <td data-th="填寫日期">2021/12/1</td>
                            <td data-th="回覆日期">尚未回覆</td>
                            <td data-th="動作">
                                <telerik:RadButton ID="btnNextPage" runat="server" CssClass="btn btn-outline btn-link" Text="下一頁">
                                  <Icon SecondaryIconCssClass="rbNext" />
                                </telerik:RadButton>
                            </td>
                        </tr>

                        <tr>
                            <td data-th="標題">標題限制30字標題限制30字標題限制30字標題限制30字</td>
                            <td data-th="回報類型">系統操作 </td>
                            <td data-th="填寫日期">2021/12/1</td>
                            <td data-th="回覆日期">尚未回覆</td>
                            <td data-th="動作">
                                <telerik:RadButton ID="RadButton1" runat="server" CssClass="btn btn-outline btn-link" Text="下一頁">
                                    <Icon SecondaryIconCssClass="rbNext" />
                                </telerik:RadButton>
                            </td>
                        </tr>

                        <tr>
                            <td data-th="標題">標題限制30字標題限制30字標題限制30字標題限制30字</td>
                            <td data-th="回報類型">系統操作 </td>
                            <td data-th="填寫日期">2021/12/1</td>
                            <td data-th="回覆日期">尚未回覆</td>
                            <td data-th="動作">
                                <telerik:RadButton ID="RadButton2" runat="server" CssClass="btn btn-outline btn-link" Text="下一頁">
                                    <Icon SecondaryIconCssClass="rbNext" />
                                </telerik:RadButton>
                            </td>
                        </tr>

                    </table>
                    <!--<telerik:RadListView ID="lvMain" runat="server">
                        <LayoutTemplate>
                            <table Class="rwd-table">
                                <thead>
                                    <tr>
                                        <th>標題</th>
                                        <th>回報類型</th>
                                        <th>填寫日期</th>
                                        <th>回覆日期</th>
                                        <th>動做</th>
                                    </tr>
                                </thead>
                                <tbody id="Container" runat="server">
                                    <tr>
                                        <td>標題限制30字標題限制30字標題限制30字標題限制30字</td>
                                        <td>下一頁</td>
                                        <td>下一頁</td>
                                        <td>下一頁</td>
                                        <td>下一頁</td>
                                    </tr>
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
                                <td data-th="標題"><%# Eval("EmpId") %></td>
                                <td data-th="回報類型"><%# Eval("EmpName") %></td>
                                <td data-th="填寫日期"><%# Eval("DateA","{0:yyyy-MM-dd}") %></td>
                                <td data-th="回覆日期"><%# Eval("AbnormalType") %></td>
                                <td  data-th="動作">
                                    <telerik:RadButton ID="btn_Delete" runat="server" Text="刪除" CssClass="btn-white btn btn-xs" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                        </EmptyDataTemplate>
                    </telerik:RadListView>-->

                </div>
            </div>
        </div>
    </div>
</asp:Content>
