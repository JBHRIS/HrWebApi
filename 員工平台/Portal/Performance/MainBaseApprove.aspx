<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MainBaseApprove.aspx.cs" Inherits="Performance.MainBaseApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>處理</h5>
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
                            <div class="form-group row">
                                <label class="col-sm-12 col-form-label">準備送出部門</label>
                                <div class="col-sm-12 ">
                                    <telerik:RadCheckBoxList ID="cblDept" runat="server" AutoPostBack="false" Skin="Bootstrap" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">評核人數</label>
                                <div class="col-sm-1">
                                    <telerik:RadLabel ID="lblPeopleNumber" runat="server" Text="0" />
                                </div>
                                <label class="col-sm-2 col-form-label">已分配獎金總合</label>
                                <div class="col-sm-1">
                                    <telerik:RadLabel ID="lblBonusReal" runat="server" Text="0" />
                                </div>
                                <label class="col-sm-2 col-form-label">未分配金額</label>
                                <div class="col-sm-1">
                                    <telerik:RadLabel ID="lblBonusBalance" runat="server" Text="0" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <label class="col-sm-12 col-form-label">簽核意見</label>
                                <div class="col-sm-12">
                                    <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="意見" TextMode="MultiLine" Height="100px" Width="100%" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnSign" runat="server" Text="呈核" OnClick="btnSend_Click" CommandName="Sign" OnClientClicking="ExcuteConfirm" CssClass="btn btn-primary btn-sm" />
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnApprove" runat="server" Text="核准" OnClick="btnSend_Click" CommandName="Approve" OnClientClicking="ExcuteConfirm" CssClass="btn btn-primary btn-sm" />
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="btn btn-w-m btn-warning" />
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadLabel ID="lblMsg" CssClass="badge badge-danger" runat="server" />
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group row">
                                <label class="col-sm-12 col-form-label">簽核歷程</label>
                                <div class="col-sm-10">
                                    <telerik:RadGrid ID="gvMain" runat="server" AllowPaging="False" AllowSorting="false" Skin="Bootstrap"
                                        AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None"
                                        OnNeedDataSource="gvMain_NeedDataSource" OnItemCommand="gvMain_ItemCommand"
                                        OnExportCellFormatting="gvMain_ExportCellFormatting" OnDataBound="gvMain_DataBound">
                                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="AutoKey"
                                            ClientDataKeyNames="AutoKey">
                                            <GroupByExpressions>
                                                <telerik:GridGroupByExpression>
                                                    <SelectFields>
                                                        <telerik:GridGroupByField FieldAlias="部門名稱" FieldName="PerformanceFlowCode"></telerik:GridGroupByField>
                                                    </SelectFields>
                                                    <GroupByFields>
                                                        <telerik:GridGroupByField FieldName="PerformanceFlowCode"></telerik:GridGroupByField>
                                                    </GroupByFields>
                                                </telerik:GridGroupByExpression>
                                            </GroupByExpressions>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="AutoKey" DataType="System.Int32"
                                                    ReadOnly="True" FilterControlAltText="Filter AutoKey column"
                                                    HeaderText="編號" SortExpression="AutoKey" UniqueName="AutoKey"
                                                    Display="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PerformanceFlowCode"
                                                    ReadOnly="True" FilterControlAltText="Filter PerformanceFlowCode column"
                                                    HeaderText="流程代碼" SortExpression="PerformanceFlowCode" UniqueName="PerformanceFlowCode"
                                                    Display="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EmpId"
                                                    FilterControlAltText="Filter EmpId column" HeaderText="工號"
                                                    SortExpression="EmpId" UniqueName="EmpId">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="EmpName"
                                                    FilterControlAltText="Filter EmpName column" HeaderText="姓名"
                                                    SortExpression="EmpName" UniqueName="EmpName">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="JobName"
                                                    FilterControlAltText="Filter JobName column" HeaderText="職稱"
                                                    SortExpression="JobName" UniqueName="JobName">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ActiveCode"
                                                    FilterControlAltText="Filter ActiveCode column" HeaderText="動作"
                                                    SortExpression="ActiveCode" UniqueName="ActiveCode">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Note"
                                                    FilterControlAltText="Filter Note column" HeaderText="簽核意見"
                                                    SortExpression="Note" UniqueName="Note">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="UpdateDate"
                                                    FilterControlAltText="Filter UpdateDate column" HeaderText="日期"
                                                    SortExpression="UpdateDate" UniqueName="UpdateDate">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
