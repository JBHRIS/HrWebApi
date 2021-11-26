<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionaryManage.aspx.cs"
    Inherits="eTraining_Admin_Do_QuestionaryManage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        width="100%">

    <br />
    <div>
        <asp:Panel ID="pnlQList" runat="server">
            <telerik:RadGrid ID="gvQList" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsQList"
                GridLines="None" Skin="Outlook" onitemcommand="gvQList_ItemCommand" 
                onselectedindexchanged="gvQList_SelectedIndexChanged" Width="90%" 
                AllowSorting="True">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutokey" 
                    DataSourceID="sdsQList" AllowSorting="False">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="iAutokey" DataType="System.Int32" FilterControlAltText="Filter iAutokey column"
                            HeaderText="iAutokey" ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutokey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                            HeaderText="sCode" SortExpression="sCode" UniqueName="sCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                            HeaderText="問卷名稱" SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dDeadLine" 
                            FilterControlAltText="Filter dDeadLine column" HeaderText="問卷填寫截止時間" 
                            UniqueName="dDeadLine" DataFormatString="{0:yyyy/M/d HHmm}">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="Select" 
                            FilterControlAltText="Filter Select column" Text="學員問卷" UniqueName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="FillerCategory" EmptyDataText="" 
                            FilterControlAltText="Filter FillerCategory column" HeaderText="FillerCategory" 
                            UniqueName="FillerCategory" Visible="False">
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
        </asp:Panel>
        <asp:Panel ID="pnlNobrList" runat="server" Visible="False">
            <telerik:RadButton ID="btnBack" runat="server" Text="回問卷管理" OnClick="btnBack_Click">
            </telerik:RadButton>
            <asp:Label ID="lblQcode" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>
            <telerik:RadGrid ID="gvS" runat="server" CellSpacing="0" Culture="zh-TW" 
                DataSourceID="sds_gvS" GridLines="None" 
                Skin="Outlook" Width="90%" 
                onselectedindexchanged="gv_SelectedIndexChanged" 
                AutoGenerateColumns="False" onupdatecommand="gvS_UpdateCommand">
                <MasterTableView DataSourceID="sds_gvS" 
                    AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="iAutoKey">
                    <NoRecordsTemplate>

                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="NAME_C" 
                            FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
                            SortExpression="NAME_C" UniqueName="NAME_C" ReadOnly="True" 
                            FilterControlWidth="50px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NOBR" 
                            FilterControlAltText="Filter NOBR column" HeaderText="工號" SortExpression="NOBR" 
                            UniqueName="NOBR" ReadOnly="True" FilterControlWidth="50px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DEPT" 
                            FilterControlAltText="Filter DEPT column" HeaderText="部門代碼" 
                            SortExpression="DEPT" UniqueName="DEPT" ReadOnly="True" 
                            FilterControlWidth="50px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="D_NAME" 
                            FilterControlAltText="Filter D_NAME column" HeaderText="部門名稱" 
                            SortExpression="D_NAME" UniqueName="D_NAME" ReadOnly="True" 
                            FilterControlWidth="50px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dWriteDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dWriteDate column" HeaderText="填寫日" 
                            SortExpression="dWriteDate" UniqueName="dWriteDate" 
                            DataFormatString="{0:yyyy/M/d HHmm}" ReadOnly="True" 
                            ShowFilterIcon="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dFillFormDatetimeE" 
                            DataFormatString="{0:yyyy/M/d HHmm}" 
                            FilterControlAltText="Filter dFillFormDatetimeE column" HeaderText="截止時間" 
                            ShowFilterIcon="False" UniqueName="dFillFormDatetimeE" 
                            DataType="System.DateTime">
                        </telerik:GridBoundColumn>
                        <telerik:GridEditCommandColumn EditText="修改截止日" 
                            FilterControlAltText="Filter EditCommandColumn column" UpdateText="修改截止日">
                        </telerik:GridEditCommandColumn>
                        <telerik:GridButtonColumn CommandName="Select" 
                            FilterControlAltText="Filter Select column" Text="檢視" UniqueName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="iAutoKey" 
                            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                            UniqueName="iAutoKey" Visible="False" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bPresence" 
                            FilterControlAltText="Filter bPresence column" HeaderText="是否出勤" 
                            UniqueName="bPresence">
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
            <br />
            <telerik:RadGrid ID="gvM" runat="server" CellSpacing="0" Culture="zh-TW" 
                DataSourceID="sds_gvM" GridLines="None" 
                onselectedindexchanged="gvM_SelectedIndexChanged" Skin="Outlook" 
                Width="90%" AutoGenerateColumns="False" 
                onupdatecommand="gvS_UpdateCommand">
                <MasterTableView DataKeyNames="iAutoKey" 
                    DataSourceID="sds_gvM">
                    <NoRecordsTemplate>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="NAME_C" 
                            FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
                            SortExpression="NAME_C" UniqueName="NAME_C" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NOBR" 
                            FilterControlAltText="Filter NOBR column" HeaderText="工號" SortExpression="NOBR" 
                            UniqueName="NOBR" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dWriteDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dWriteDate column" HeaderText="填寫日" 
                            SortExpression="dWriteDate" UniqueName="dWriteDate" 
                            DataFormatString="{0:yyyy/M/d HHmm}" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dFillFormDatetimeE" 
                            DataFormatString="{0:yyyy/M/d HHmm}" 
                            FilterControlAltText="Filter dFillFormDatetimeE column" HeaderText="截止時間" 
                            UniqueName="dFillFormDatetimeE">
                        </telerik:GridBoundColumn>
                        <telerik:GridEditCommandColumn EditText="修改截止日" 
                            FilterControlAltText="Filter EditCommandColumn column">
                        </telerik:GridEditCommandColumn>
                        <telerik:GridButtonColumn CommandName="Select" 
                            FilterControlAltText="Filter Select column" Text="檢視" UniqueName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="iAutoKey" 
                            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                            UniqueName="iAutoKey" Visible="False" ReadOnly="True">
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
            <telerik:RadGrid ID="gvT" runat="server" CellSpacing="0" Culture="zh-TW" 
                DataSourceID="sds_gvT" GridLines="None" 
                onselectedindexchanged="gvT_SelectedIndexChanged" Skin="Outlook" 
                Width="90%" AutoGenerateColumns="False" 
                onupdatecommand="gvS_UpdateCommand">
                <MasterTableView AllowSorting="True" DataKeyNames="iAutoKey" 
                    DataSourceID="sds_gvT">
                    <NoRecordsTemplate>
                    </NoRecordsTemplate>
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="sName" 
                            FilterControlAltText="Filter sName column" HeaderText="姓名" 
                            SortExpression="sName" UniqueName="sName" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNobr" 
                            FilterControlAltText="Filter sNobr column" HeaderText="工號" SortExpression="sNobr" 
                            UniqueName="sNobr" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dWriteDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dWriteDate column" HeaderText="填寫日" 
                            SortExpression="dWriteDate" UniqueName="dWriteDate" 
                            DataFormatString="{0:yyyy/M/d HHmm}" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dFillFormDatetimeE" 
                            DataFormatString="{0:yyyy/M/d HHmm}" 
                            FilterControlAltText="Filter dFillFormDatetimeE column" HeaderText="截止時間" 
                            UniqueName="dFillFormDatetimeE">
                        </telerik:GridBoundColumn>
                        <telerik:GridEditCommandColumn EditText="修改截止日" 
                            FilterControlAltText="Filter EditCommandColumn column">
                        </telerik:GridEditCommandColumn>
                        <telerik:GridButtonColumn CommandName="Select" 
                            FilterControlAltText="Filter Select column" Text="檢視" UniqueName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="iAutoKey" 
                            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                            UniqueName="iAutoKey" Visible="False" ReadOnly="True">
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
        </asp:Panel>
    </div>
    <asp:SqlDataSource ID="sdsQList" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        
        SelectCommand="select * from ClassQuestionnaire cq join qQuestionaryM qm on cq.qQuestionaryM = qm.sCode
where cq.iClassAutoKey = @ID">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue=" " Name="ID" QueryStringField="ID" />
        </SelectParameters>
    </asp:SqlDataSource>
        <telerik:RadWindow ID="RadWindow1" runat="server" AutoSize="True" Modal="True">
        </telerik:RadWindow>
    <asp:SqlDataSource ID="sds_gvS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select bm.iAutoKey,b.NAME_C,b.NOBR,tts.DEPT,DEPT.D_NAME,bm.dWriteDate,bm.dFillFormDatetimeE,tsm.bPresence from qBaseM bm 
left join BASE b on bm.sNobr = b.NOBR
left join basetts tts on tts.NOBR = bm.sNobr
left join DEPT on dept.D_NO = tts.DEPT
left join trTrainingStudentM tsm on tsm.iClassAutoKey = bm.iClassAutoKey and tsm.sNobr=bm.sNobr
where CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE and  bm.iClassAutoKey =@ID
and qQuestionary_sCode =@Qcode">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblClassID" DefaultValue=" " Name="ID" 
                PropertyName="Text" />
            <asp:ControlParameter ControlID="lblQcode" DefaultValue=" " Name="Qcode" 
                PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="sds_gvM" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select * from qBaseM bm
left join BASE b on bm.sKeyMan = b.NOBR
where  bm.iClassAutoKey =@ID
and qQuestionary_sCode =@Qcode">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblClassID" DefaultValue=" " Name="ID" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="lblQcode" DefaultValue=" " Name="Qcode" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sds_gvT" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select bm.iAutokey,bm.trTeacher_sCode,t.sName,t.sNobr,bm.dWriteDate,bm.dFillFormDatetimeE  from qBaseM bm
left join trTeacher t on bm.trTeacher_sCode=t.sCode
where  bm.iClassAutoKey =@ID
and qQuestionary_sCode =@Qcode">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblClassID" DefaultValue=" " Name="ID" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="lblQcode" DefaultValue=" " Name="Qcode" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        </telerik:RadAjaxPanel>
    </form>
</body>
</html>
