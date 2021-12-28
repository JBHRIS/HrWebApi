<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturnListM.aspx.cs" Inherits="Portal.ProblemReturnListM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ibox">
        
            <div class="ibox-content">
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                <div class="row">
                    <div class="col-lg-7">
                        <h2>回覆管理</h2>
                    </div>
                    <div class="col-lg-5">
                        <div class="row">
                            <div class="col-lg-4">
                                <telerik:RadButton ID="btnAdd" runat="server" Text="預設訊息設定" OnClick="btnSet_Click" CssClass="btn btn-primary btn-md m-t-xs" />
                            </div>
                            <div class="col-lg-8 text-right">
                                <telerik:RadComboBox ID="txtReturnS" runat="server" class="txtReturnS" Skin="Bootstrap" AllowCustomText="True"
                                    AutoPostBack="true" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                                    LoadingMessage="載入中…" Width="100%" OnSelectedIndexChanged="txtReturnS_SelectedIndexChanged">
                                </telerik:RadComboBox>
                            </div>

                        </div>
                    </div>
                </div>



                <div class="row m-t-lg">
                    <div class="col-lg-12">
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadListView ID="lvMain" runat="server" ItemPlaceholderID="Container" OnItemCommand="lvMain_ItemCommand" OnNeedDataSource="lvMain_NeedDataSource">
                                <LayoutTemplate>
                                    <table id="footable" class="footable table table-stripped rwd-table" data-page-size="10" data-filter="#filterTaken">
                                        <thead>
                                            <tr>
                                                <th>標題</th>
                                                <th>回報類型</th>
                                                <th>填寫日期</th>
                                                <th>回覆日期</th>
                                                <th>操作</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
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

                                    <tr class="gradeX">
                                        <td data-th="標題"><%# Eval("TitleContent") %></td>
                                        <td data-th="回報類型"><%# Eval("QuestionCategoryName") %></td>
                                        <td data-th="填寫日期"><%# Eval("DateE","{0:yyyy-MM-dd}") %></td>
                                        <td data-th="回覆日期"><%# Eval("UpdateDate","{0:yyyy-MM-dd}") %></td>
                                        <td data-th="操作">
                                            <telerik:RadButton ID="btnCheck" runat="server" Text="查看" CommandArgument='<%# Eval("Code")%>' CssClass="btn btn-outline btn-primary btn-xs" OnClick="btnCheck_Click">
                                                <Icon SecondaryIconCssClass="rbNext" />
                                            </telerik:RadButton>
                                        </td>
                                    </tr>

                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <table id="footable" class="footable table table-stripped rwd-table" data-page-size="10" data-filter="#filterTaken">
                                        <thead>
                                            <tr>
                                                <th>標題</th>
                                                <th>回報類型</th>
                                                <th>填寫日期</th>
                                                <th>回覆日期</th>
                                                <th>操作</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">

                                            <tr>
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
                      </telerik:RadAjaxPanel>
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
