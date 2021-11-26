<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserApplyForm.aspx.cs" Inherits="Flow_UserApplyForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <script type="text/javascript">
            function setCustomPosition(sender, args) {
                sender.moveTo(sender.get_left(), sender.get_top());
            }
        </script>
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
            SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" PageViewID="pvWorking" Text="進行中流程" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pvHistory" Text="歷史資料">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" Height="100%" Width="100%"
            SelectedIndex="0">
            <telerik:RadPageView ID="pvWorking" runat="server" OnLoad="pvWorking_Load" Selected="True">
                <telerik:RadGrid ID="gvWorking" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                    Culture="zh-TW" GridLines="None" OnItemCommand="gvWorking_ItemCommand" OnNeedDataSource="gvWorking_NeedDataSource" AllowSorting="True">
                    <MasterTableView DataKeyNames="ProcessID">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridButtonColumn CommandName="View" FilterControlAltText="Filter cmdConfirm column"
                                Text="檢視" UniqueName="View">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="FlowPath" FilterControlAltText="Filter FlowPath column"
                                Text="流程檢視" UniqueName="FlowPath">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="ProcessID" FilterControlAltText="Filter ProcessId column"
                                HeaderText="流程序" UniqueName="ProcessID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ApViewID" FilterControlAltText="Filter ApViewID column"
                                HeaderText="ApParmID" UniqueName="ApViewID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AppDate" FilterControlAltText="Filter AppDate column"
                                HeaderText="申請時間" UniqueName="AppDate">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FlowProgress" FilterControlAltText="Filter FlowProgress column"
                                HeaderText="處理進度" UniqueName="FlowProgress" Visible="True">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FormName" FilterControlAltText="Filter FormName column"
                                HeaderText="流程名稱" UniqueName="FormName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HistoryUrl" FilterControlAltText="Filter HistoryUrl column"
                                HeaderText="HistoryUrl" UniqueName="HistoryUrl" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SignDate" FilterControlAltText="Filter SignDate column"
                                HeaderText="送審時間" UniqueName="SignDate">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SignName" FilterControlAltText="Filter SignName column"
                                HeaderText="處理人姓名" UniqueName="SignName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ViewUrl" FilterControlAltText="Filter ViewUrl column"
                                HeaderText="ViewUrl" UniqueName="ViewUrl" Visible="False">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView><FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pvHistory" runat="server">
                <telerik:RadDatePicker ID="dpDateB" runat="server" Skin="Web20">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dpDateB"
                    ErrorMessage="*Required" SetFocusOnError="True"></asp:RequiredFieldValidator>－
                <telerik:RadDatePicker ID="dpDateE" runat="server" Skin="Web20">
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dpDateE"
                    ErrorMessage="*Required"></asp:RequiredFieldValidator>
                <a href="#">
                    <telerik:RadButton ID="RadButton1" runat="server" OnClick="RadButton1_Click" Text="搜尋">
                    </telerik:RadButton>
                    <br />
                    <telerik:RadGrid ID="gvHistory" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                        Culture="zh-TW" GridLines="None" OnItemCommand="gvHistory_ItemCommand" OnNeedDataSource="gvHistory_NeedDataSource" AllowSorting="True">
                        <MasterTableView DataKeyNames="ProcessID">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="View" FilterControlAltText="Filter cmdConfirm column"
                                    Text="檢視" UniqueName="View">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="FlowPath" FilterControlAltText="Filter FlowPath column"
                                    Text="流程檢視" UniqueName="FlowPath">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="ProcessID" FilterControlAltText="Filter ProcessId column"
                                    HeaderText="流程序" UniqueName="ProcessID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ApViewID" FilterControlAltText="Filter ApParamId column"
                                    HeaderText="ApViewID" UniqueName="ApViewID" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AppDate" FilterControlAltText="Filter AppDate column"
                                    HeaderText="申請時間" UniqueName="AppDate">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FormName" FilterControlAltText="Filter FormName column"
                                    HeaderText="流程名稱" UniqueName="FormName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ViewUrl" FilterControlAltText="Filter ViewUrl column"
                                    HeaderText="ViewUrl" UniqueName="ViewUrl" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HistoryUrl" FilterControlAltText="Filter HistoryUrl column"
                                    HeaderText="HistoryUrl" UniqueName="HistoryUrl" Visible="False">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView><FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid></a></telerik:RadPageView>
        </telerik:RadMultiPage>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Style="z-index: 7001"
            Left="300px" Top="300px">
            <Windows>
                <telerik:RadWindow ID="win" runat="server" EnableShadow="True" Height="700px" Modal="True"
                    VisibleStatusbar="True" Width="1000px" Left="300px" Top="300px" OnClientShow="setCustomPosition">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
