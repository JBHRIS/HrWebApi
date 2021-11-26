<%@ Page Title="" Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpViewQuestionary.aspx.cs" Inherits="EmpViewQuestionary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        起<telerik:RadDatePicker ID="dpB" runat="server">
        </telerik:RadDatePicker>
        <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="dpB" ErrorMessage="*必填"
            ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>
        迄<telerik:RadDatePicker ID="dpE" runat="server">
        </telerik:RadDatePicker>
        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="dpE" ErrorMessage="*必填"
            ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>
        <telerik:RadButton ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="查詢"
            ValidationGroup="g1">
        </telerik:RadButton>
        <br />
        <div>
            <asp:Panel ID="pnlQList" runat="server">
                <telerik:RadGrid ID="gvQList" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None"
                    Skin="Outlook" OnItemCommand="gvQList_ItemCommand" OnSelectedIndexChanged="gvQList_SelectedIndexChanged"
                    Width="90%" AllowSorting="True" AutoGenerateColumns="False" OnNeedDataSource="gvQList_NeedDataSource"
                    OnItemDataBound="gvQList_ItemDataBound">
                    <MasterTableView DataKeyNames="Id" AllowSorting="False">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" FilterControlAltText="Filter Id column"
                                HeaderText="Id" ReadOnly="True" SortExpression="Id" UniqueName="Id" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="QTplCode" FilterControlAltText="Filter QTplCode column"
                                HeaderText="QTplCode" SortExpression="QTplCode" UniqueName="QTplCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                                HeaderText="問卷名稱" SortExpression="Name" UniqueName="Name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FillFormDatetimeB" FilterControlAltText="Filter FillFormDatetimeB column"
                                HeaderText="問卷填寫開始時間" UniqueName="FillFormDatetimeB"
                                DataFormatString="{0:yyyy/MM/dd HHmm}" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FillFormDatetimeE" FilterControlAltText="Filter FillFormDatetimeE column"
                                HeaderText="問卷填寫截止時間" UniqueName="FillFormDatetimeE"
                                DataFormatString="{0:yyyy/MM/dd HHmm}">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                                Text="細節" UniqueName="Select">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="Summary" FilterControlAltText="Filter column column"
                                Text="匯總" UniqueName="Summary">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn FilterControlAltText="Filter Percent column" HeaderText="比例"
                                UniqueName="Percent">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="IsPublished" DataType="System.Boolean" FilterControlAltText="Filter IsPublished column"
                                HeaderText="發佈" UniqueName="IsPublished" Visible="False">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="FillerCategory" EmptyDataText="" FilterControlAltText="Filter FillerCategory column"
                                HeaderText="FillerCategory" UniqueName="FillerCategory" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="ViewSummaryClosed"
                                DataType="System.Boolean"
                                FilterControlAltText="Filter ViewSummaryClosed column"
                                UniqueName="ViewSummaryClosed" Visible="False">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridCheckBoxColumn DataField="ViewSummaryOpening"
                                DataType="System.Boolean"
                                FilterControlAltText="Filter ViewSummaryOpening column"
                                UniqueName="ViewSummaryOpening" Visible="False">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridCheckBoxColumn DataField="IsAnonymous" DataType="System.Boolean"
                                FilterControlAltText="Filter IsAnonymous column" UniqueName="IsAnonymous"
                                Visible="False">
                            </telerik:GridCheckBoxColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                        <WebServiceSettings>
                            <ODataSettings InitialContainerName="">
                            </ODataSettings>
                        </WebServiceSettings>
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        <WebServiceSettings>
                            <ODataSettings InitialContainerName="">
                            </ODataSettings>
                        </WebServiceSettings>
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </asp:Panel>
            <asp:Panel ID="pnlNobrList" runat="server" Visible="False">
                <telerik:RadButton ID="btnBack" runat="server" Text="回問卷管理" OnClick="btnBack_Click">
                </telerik:RadButton>
                <asp:Label ID="lblQcode" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>
                <telerik:RadGrid ID="gvS" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None"
                    Skin="Outlook" Width="98%" OnSelectedIndexChanged="gvS_SelectedIndexChanged"
                    AutoGenerateColumns="False" OnUpdateCommand="gvS_UpdateCommand" OnNeedDataSource="gvS_NeedDataSource">
                    <MasterTableView AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True"
                        DataKeyNames="Id">
                        <NoRecordsTemplate>
                        </NoRecordsTemplate>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                                HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C" ReadOnly="True" FilterControlWidth="50px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                                HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR" ReadOnly="True" FilterControlWidth="50px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DEPT" FilterControlAltText="Filter DEPT column"
                                HeaderText="部門代碼" SortExpression="DEPT" UniqueName="DEPT" ReadOnly="True"
                                FilterControlWidth="50px" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                                HeaderText="部門名稱" SortExpression="D_NAME" UniqueName="D_NAME" ReadOnly="True"
                                FilterControlWidth="50px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="WriteDate" DataType="System.DateTime" FilterControlAltText="Filter WriteDate column"
                                HeaderText="填寫日" SortExpression="WriteDate" UniqueName="WriteDate" DataFormatString="{0:yyyy/M/d HHmm}"
                                ReadOnly="True" ShowFilterIcon="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FillFormDatetimeE" DataFormatString="{0:yyyy/M/d HHmm}"
                                FilterControlAltText="Filter FillFormDatetimeE column" HeaderText="截止時間" ShowFilterIcon="False"
                                UniqueName="FillFormDatetimeE" DataType="System.DateTime" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridEditCommandColumn EditText="修改截止日" FilterControlAltText="Filter EditCommandColumn column"
                                UpdateText="修改截止日" Visible="False">
                            </telerik:GridEditCommandColumn>
                            <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                                Text="檢視" UniqueName="Select">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" HeaderText="Id"
                                UniqueName="Id" Visible="False" ReadOnly="True">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                        <WebServiceSettings>
                            <ODataSettings InitialContainerName="">
                            </ODataSettings>
                        </WebServiceSettings>
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        <WebServiceSettings>
                            <ODataSettings InitialContainerName="">
                            </ODataSettings>
                        </WebServiceSettings>
                    </HeaderContextMenu>
                </telerik:RadGrid>
                <br />
            </asp:Panel>
        </div>
        <telerik:RadWindow ID="RadWindow1" runat="server" Modal="True" VisibleStatusbar="False">
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
</asp:Content>