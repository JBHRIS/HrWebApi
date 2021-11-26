<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="ManageFlowDeptRating.aspx.cs" Inherits="Performance.ManageFlowDeptRating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>新增或修改內容</h5>
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
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadLabel ID="lblAutoKey" runat="server" Visible="false" />
                            <telerik:RadListView ID="lvMain" runat="server" DataKeyNames="AutoKey" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvMain_NeedDataSource" OnDataBound="lvMain_DataBound" OnItemCommand="lvMain_ItemCommand">
                                <LayoutTemplate>
                                    <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                        <thead>
                                            <tr>
                                                <th>評等</th>
                                                <th>人數上限(%)</th>
                                                <th>人數下限(%)</th>
                                                <th>調整人數(%)</th>
                                            </tr>
                                        </thead>
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="3">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td><%# Eval("PerformanceRatingName") %></td>
                                        <td><%# Eval("NumPerMax") %></td>
                                        <td><%# Eval("NumPerMin") %></td>
                                        <td>
                                            <telerik:RadNumericTextBox Text='<%# Eval("NumPerNew") %>' Width="100%" EnabledStyle-HorizontalAlign="Right" CssClass="form-control" 
                                                ID="txtNumPerNew" NumberFormat-DecimalDigits="0" MaxLength="3"
                                                MinValue="0" MaxValue="100" runat="server" />
                                            <telerik:RadToolTip RenderMode="Lightweight" ID="ttNumPerNew" runat="server"  Width="250px"  ShowEvent="OnClick"
                                                TargetControlID="txtNumPerNew" IsClientID="true" HideEvent="LeaveToolTip" Position="TopRight" Skin="Bootstrap" 
                                                ShowDelay="0" RelativeTo="Element" Text="" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    目前並無任何資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                            <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                            <telerik:RadLabel ID="lblMsg" runat="server" CssClass="badge badge-danger" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>

