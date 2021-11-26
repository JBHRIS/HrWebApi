<%@ Page Title="催繳" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="Wake.aspx.cs" Inherits="eTraining_Admin_Plan_Wake" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Windows7" IsSticky="True">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%" ClientEvents-OnRequestStart="pnlRequestStarted"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                //                function mngRequestStarted(ajaxManager, eventArgs) {
                //                    if (eventArgs.EventTarget == "mngBtnExcel" || eventArgs.EventTarget == "mngBtnWord") {
                //                        eventArgs.EnableAjax = false;
                //                    }
                //                }
                function pnlRequestStarted(ajaxPanel, eventArgs) {
                    if (eventArgs.EventTarget == '<%= btnEmpExportExcel.UniqueID %>' || eventArgs.EventTarget == '<%= btnMangExportExcel.UniqueID %>') {
                        eventArgs.EnableAjax = false;
                    }
                }
                //                function gridRequestStart(grid, eventArgs) {
                //                    if ((eventArgs.EventTarget.indexOf("gridBtnExcel") != -1) || (eventArgs.EventTarget.indexOf("gridBtnWord") != -1)) {
                //                        eventArgs.EnableAjax = false;
                //                    }
                //                }
                function StandardConfirm(sender, args) {
                    args.set_cancel(!window.confirm("您確定要送出嗎？"));
                }
            </script>
        </telerik:RadCodeBlock>
        <div>
            <h2>
                催繳<telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" 
                    Skin="Windows7" DecoratedControls="All" />
            </h2>


            <br />


            年度<telerik:RadComboBox ID="cbYear" runat="server" Width="60px" AutoPostBack="True"
                OnDataBound="cbYear_DataBound" OnItemDataBound="cbYear_ItemDataBound" OnSelectedIndexChanged="cbYear_SelectedIndexChanged">
            </telerik:RadComboBox>
            &nbsp;
            <br />
            <br />
            <telerik:RadButton ID="btnEmpExportExcel" runat="server" 
                OnClick="btnEmpExportExcel_Click" Text="員工未填寫匯出">
            </telerik:RadButton>
            <telerik:RadButton ID="btnMangExportExcel" runat="server" 
                OnClick="btnMangExportExcel_Click" Text="主管未填寫匯出">
            </telerik:RadButton>
            <br />
            <table width="70%">
            <tr>
            <td>
            <asp:RadioButtonList ID="rrlCate" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">員工未填寫</asp:ListItem>
                <asp:ListItem Value="1">主管未填寫</asp:ListItem>
            </asp:RadioButtonList>
            </td>
            <td>
            郵件<telerik:RadComboBox ID="cbxMail" runat="server" DataSourceID="sdsCbx" 
                DataTextField="sName" DataValueField="iAutoKey">
            </telerik:RadComboBox>
            </td>
            <td>
            <telerik:RadButton ID="btnMailPreView" runat="server" 
                OnClick="btnMailPreView_Click" Text="郵件預覽">
            </telerik:RadButton>
            <telerik:RadButton ID="btnSendMail" runat="server" Text="郵件提醒發送" 
                OnClick="btnMailPreView_Click" onclientclicking="StandardConfirm">
            </telerik:RadButton>
            </td>
            </tr>
            </table>
            <br />
            <asp:SqlDataSource ID="sdsCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT * FROM [trMailTemplate]"></asp:SqlDataSource>
            <br />
            <div style="float: left; width: 50%">
                員工未填寫名單<br />
                <telerik:RadGrid ID="gvP" runat="server" AllowPaging="True" AllowSorting="True"
                    CellSpacing="0" DataSourceID="sdsGvP" GridLines="None" Culture="zh-TW">
                    <MasterTableView AutoGenerateColumns="False" DataSourceID="sdsGvP">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                                HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="D_NO" 
                                FilterControlAltText="Filter D_NO column" HeaderText="部門代碼" 
                                SortExpression="D_NO" UniqueName="D_NO">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                                HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                                HeaderText="sNobr" SortExpression="sNobr" UniqueName="sNobr" Visible="False">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </div>
            <div style="float: right; width: 50%">
                主管未填寫名單<br />
                <telerik:RadGrid ID="gvM" runat="server" AllowPaging="True" AllowSorting="True"
                    CellSpacing="0" DataSourceID="sdsGvM" GridLines="None" Culture="zh-TW" 
                    AutoGenerateColumns="False" onitemcommand="gvM_ItemCommand" 
                    onselectedindexchanged="gvM_SelectedIndexChanged">
                    <MasterTableView DataSourceID="sdsGvM">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="managerName" FilterControlAltText="Filter managerName column"
                                HeaderText="主管姓名" SortExpression="managerName" UniqueName="managerName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="empName" 
                                FilterControlAltText="Filter empName column" HeaderText="員工姓名" 
                                UniqueName="empName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="D_NO" 
                                FilterControlAltText="Filter D_NO column" HeaderText="部門代碼" 
                                SortExpression="D_NO" UniqueName="D_NO">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                                HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sManage" FilterControlAltText="Filter sManage column"
                                HeaderText="工號" SortExpression="sManage" UniqueName="sManage" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Select" 
                                FilterControlAltText="Filter column column" Text="換" UniqueName="column">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="empNobr" 
                                FilterControlAltText="Filter empNobr column" UniqueName="empNobr" 
                                Visible="False">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                <br />
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                <div style="font-size: x-small">
    <br />
    <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSearchNobr">
    姓名｜工號<telerik:RadTextBox ID="txtName" runat="server" Width="60px">
    </telerik:RadTextBox>
    &nbsp;<telerik:RadButton ID="btnSearchNobr" runat="server" Text="查詢" OnClick="btnSearchNobr_Click">
    </telerik:RadButton>    
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="gvNobr" runat="server" AllowPaging="True" CellSpacing="0" 
        Culture="zh-TW" GridLines="None" Skin="Office2010Blue" 
        onneeddatasource="gvNobr_NeedDataSource" AutoGenerateColumns="False">
        <MasterTableView DataKeyNames="Nobr">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridButtonColumn FilterControlAltText="Filter Select column" Text="選擇" UniqueName="Select"
                    CommandName="Select">
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                    HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter NOBR column"
                    HeaderText="工號" SortExpression="NOBR" UniqueName="Nobr" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                    HeaderText="部門" SortExpression="D_NAME" UniqueName="DeptName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JobName" FilterControlAltText="Filter JOB_NAME column"
                    HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JobName" 
                    Visible="False">
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
                    <telerik:RadButton ID="btnReplaceManager" runat="server" 
                        OnClick="btnReplaceManager_Click" Text="更換主管">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" 
                        Text="取消">
                    </telerik:RadButton>
    <br />
</div>
                </asp:Panel>
            </div>
            <asp:SqlDataSource ID="sdsGvP" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select distinct(tq.sNobr),base.NAME_C,DEPT.D_NAME,DEPT.D_NO  from trTrainingQuest tq  left join BASETTS tts on tq.sNobr= tts.NOBR  
left join BASE on BASE.NOBR= tq.sNobr
left join DEPT on tts.DEPT = DEPT.D_NO
where iDemandIntensityPdate is null 
and TTSCODE in ('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and  tts.DDATE
and tq.iYear = @year">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cbYear" DefaultValue="0" Name="year" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:SqlDataSource ID="sdsGvM" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select tq.sManage,b1.NAME_C as managerName,DEPT.D_NAME,DEPT.D_NO,b2.NAME_C as empName,b2.NOBR as empNobr
from trTrainingQuest tq  
left join BASETTS tts on tq.sManage= tts.NOBR  
left join BASE as b1 on b1.NOBR= tq.sManage
left join BASE as b2 on b2.NOBR= tq.sNobr
left join DEPT on tts.DEPT = DEPT.D_NO
where iDemandIntensityMdate is null 
and TTSCODE in ('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and  tts.DDATE
and tq.iYear = @year
group by sManage,b1.NAME_C,D_NAME,D_NO,b2.NAME_C,b2.NOBR">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cbYear" DefaultValue="0" Name="year" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Panel ID="pnPreView" runat="server" Height="220px" Visible="False">
                <br />
                <br />
                <table style="width: 100%; background-color: #EEF5FC;" border="1">
                    <tr>
                        <td>
                            信件標題
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMailSubject" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            信件內容
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMailBody" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
