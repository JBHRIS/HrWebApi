<%@ Page Title="區主管職能積分核可" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ConfirmOJT.aspx.cs" Inherits="eTraining_Manager_ConfirmOJT" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        區主管職能積分核可<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" 
            Skin="Vista" Height="60px" IsSticky="True" Width="100%" 
            HorizontalAlign="Center">
            <asp:Label ID="lblMsg" runat="server" Text="讀取中，請勿操作" Font-Size="X-Large" 
                ForeColor="Red"></asp:Label>
        </telerik:RadAjaxLoadingPanel>
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
        Width="100%" LoadingPanelID="RadAjaxLoadingPanel1">
 
        <div style="float: left; width: 20%">
            <asp:Panel ID="pnlDept" runat="server">
                部門<telerik:RadComboBox ID="cbxDept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbxDept_SelectedIndexChanged"
                    Width="125px">
                </telerik:RadComboBox>
            </asp:Panel>
            <br />
            <asp:SqlDataSource ID="sdsDept" runat="server"></asp:SqlDataSource>
            <telerik:RadGrid ID="gvEmp" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                Culture="zh-TW" DataSourceID="sdsName" GridLines="None" OnSelectedIndexChanged="gvEmp_SelectedIndexChanged"
                Skin="Outlook">
                <MasterTableView DataKeyNames="NOBR" DataSourceID="sdsName">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                            Text="選擇" UniqueName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                            HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                            HeaderText="D_NAME" SortExpression="D_NAME" UniqueName="D_NAME" Visible="False">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <div style="float: right; width: 78%; margin-top: 0px;">
            <asp:Panel ID="pnlOJT" runat="server">
                &nbsp;<br />
                <table style="width: 100%;">
                    <tr>
                        <td width="50%">
                            <telerik:RadComboBox ID="cbxCard" runat="server" AutoPostBack="True" DataSourceID="sdsCard"
                                DataTextField="sName" DataValueField="sCode">
                            </telerik:RadComboBox>
                            <asp:CheckBox ID="cbNeedCheckOnly" runat="server" AutoPostBack="True" OnCheckedChanged="cbNeedCheckOnly_CheckedChanged"
                                Text="顯示部門需簽核清單" />
                        </td>
                        <td width="50%" align="right">
                            <asp:Panel ID="pnlUserScore" runat="server">
                                <asp:Label ID="lblUserJobScore" runat="server" Font-Size="Medium" 
                                    ForeColor="Fuchsia"></asp:Label>
                                ｜<asp:Label ID="lblJobScoreAmt" runat="server"></asp:Label>
                            </asp:Panel>
                            <br />
                            <telerik:RadButton ID="btnSaveList0" runat="server" OnClick="btnSaveList_Click" Text="儲存">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
                <br />
                <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Skin="Windows7"
                    Width="100%" AutoGenerateColumns="False" Culture="zh-TW" DataSourceID="sdsCardData"
                    OnItemCommand="gv_ItemCommand" OnItemDataBound="gv_ItemDataBound" OnPreRender="gv_PreRender"
                    OnDataBound="gv_DataBound" AllowMultiRowSelection="True">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="iAutokey" DataSourceID="sdsCardData">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                HeaderText="課程名稱" SortExpression="sName" UniqueName="sName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iAutokey" FilterControlAltText="Filter iAutokey column"
                                HeaderText="iAutokey" SortExpression="iAutokey" UniqueName="iAutokey" DataType="System.Int32"
                                ReadOnly="True" Visible="False" EmptyDataText="">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                                HeaderText="sNobr" SortExpression="sNobr" UniqueName="sNobr" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OJT_sCode" FilterControlAltText="Filter OJT_sCode column"
                                HeaderText="OJT_sCode" SortExpression="OJT_sCode" UniqueName="OJT_sCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseCode" FilterControlAltText="Filter CourseCode column"
                                HeaderText="CourseCode" SortExpression="CourseCode" UniqueName="CourseCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sTeacher" FilterControlAltText="Filter sTeacher column"
                                HeaderText="教導者" SortExpression="sTeacher" UniqueName="sTeacher" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                                HeaderText="教導者" UniqueName="NAME_C" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dTeacherKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dTeacherKeyDate column"
                                HeaderText="dTeacherKeyDate" SortExpression="dTeacherKeyDate" UniqueName="dTeacherKeyDate"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dOJT_Date" DataType="System.DateTime" FilterControlAltText="Filter dOJT_Date column"
                                HeaderText="上課日期" SortExpression="dOJT_Date" UniqueName="dOJT_Date" DataFormatString="{0:d}"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iJobScore" DataType="System.Decimal" FilterControlAltText="Filter iJobScore column"
                                HeaderText="iJobScore" SortExpression="iJobScore" UniqueName="iJobScore" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iLevel" FilterControlAltText="Filter iLevel column"
                                HeaderText="熟練度" SortExpression="iLevel" UniqueName="iLevel" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dCreatedDate" DataType="System.DateTime" FilterControlAltText="Filter dCreatedDate column"
                                HeaderText="dCreatedDate" SortExpression="dCreatedDate" UniqueName="dCreatedDate"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sCreateMan" FilterControlAltText="Filter sCreateMan column"
                                HeaderText="sCreateMan" SortExpression="sCreateMan" UniqueName="sCreateMan" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                                HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                                HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="courseJobScore" FilterControlAltText="Filter courseJobScore column"
                                HeaderText="職能積分" SortExpression="courseJobScore" UniqueName="courseJobScore"
                                DataType="System.Int32">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dCheckDate" DataFormatString="{0:d}" EmptyDataText=""
                                FilterControlAltText="Filter dCheckDate column" HeaderText="主管確認日期" UniqueName="dCheckDate">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" FilterControlAltText="Filter bPass column"
                                HeaderText="通過" SortExpression="bPass" UniqueName="bPass">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridButtonColumn ButtonType="PushButton" CommandName="DataEdit" FilterControlAltText="Filter DataEdit column"
                                Text="編輯" UniqueName="DataEdit" Visible="False">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="PushButton" CommandName="LevelEdit" FilterControlAltText="Filter LevelEdit column"
                                Text="熟練度" UniqueName="LevelEdit" Visible="False">
                            </telerik:GridButtonColumn>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter Select column" HeaderText="通過2"
                                UniqueName="Select" Visible="False">
                            </telerik:GridClientSelectColumn>
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
                <telerik:RadGrid ID="gvByDept" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                    Culture="zh-TW" Skin="Vista"
                    Width="100%" Visible="False" AllowMultiRowSelection="True" AllowPaging="True" 
                    onneeddatasource="gvByDept_NeedDataSource" PageSize="500">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="iAutoKey">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                                HeaderText="學員姓名" UniqueName="NAME_C">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="deptName" FilterControlAltText="Filter deptName column"
                                HeaderText="部門" UniqueName="deptName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                                HeaderText="課程名稱" SortExpression="courseName" UniqueName="courseName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" EmptyDataText=""
                                FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" ReadOnly="True"
                                SortExpression="iAutoKey" UniqueName="iAutoKey" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                                HeaderText="sNobr" SortExpression="sNobr" UniqueName="sNobr" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="courseCode" FilterControlAltText="Filter courseCode column"
                                HeaderText="courseCode" SortExpression="courseCode" 
                                UniqueName="courseCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="courseJobScore" DataType="System.Int32" FilterControlAltText="Filter courseJobScore column"
                                HeaderText="職能積分" SortExpression="courseJobScore" UniqueName="courseJobScore">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dCheckDate" DataFormatString="{0:d}" EmptyDataText=""
                                FilterControlAltText="Filter dCheckDate column" HeaderText="主管確認日期" UniqueName="dCheckDate">
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" FilterControlAltText="Filter bPass column"
                                HeaderText="通過" SortExpression="bPass" UniqueName="bPass" Visible="False">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridClientSelectColumn FilterControlAltText="Filter Select column" 
                                UniqueName="Select">
                            </telerik:GridClientSelectColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <PagerStyle Position="TopAndBottom" />
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
                <telerik:RadButton ID="btnSaveList" runat="server" OnClick="btnSaveList_Click" Text="儲存">
                </telerik:RadButton>
            </asp:Panel>
            <asp:Panel ID="pnlEdit" runat="server" Visible="False">
                <table class="tableBlue">
                    <tr>
                        <th>
                            通過
                        </th>
                        <td>
                            <asp:CheckBox ID="cbPass" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            日期
                        </th>
                        <td>
                            <telerik:RadDatePicker ID="dpDate" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadButton ID="btnSave" runat="server" Text="存檔" OnClick="btnSave_Click">
                            </telerik:RadButton>
                            &nbsp;&nbsp;
                            <telerik:RadButton ID="btnCancel" runat="server" Text="返回" OnClick="btnCancel_Click">
                            </telerik:RadButton>
                            <telerik:RadGrid ID="gvNobr" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
                                AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsNobr"
                                GridLines="None" OnSelectedIndexChanged="gvNobr_SelectedIndexChanged" Visible="False"
                                Width="5%">
                                <MasterTableView DataKeyNames="NOBR" DataSourceID="sdsNobr">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Select" FilterControlAltText="Filter column column"
                                            Text="選擇" UniqueName="column">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn AutoPostBackOnFilter="True" CurrentFilterFunction="Contains"
                                            DataField="NAME_C" FilterControlAltText="Filter NAME_C column" HeaderText="姓名"
                                            ShowFilterIcon="False" SortExpression="NAME_C" UniqueName="NAME_C">
                                            <HeaderStyle Font-Size="Smaller" />
                                            <ItemStyle Font-Size="Smaller" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn AutoPostBackOnFilter="True" CurrentFilterFunction="Contains"
                                            DataField="NOBR" FilterControlAltText="Filter NOBR column" HeaderText="工號" ShowFilterIcon="False"
                                            SortExpression="NOBR" UniqueName="NOBR">
                                            <HeaderStyle Font-Size="Smaller" />
                                            <ItemStyle Font-Size="Smaller" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                            <telerik:RadTextBox ID="tbTeacher" runat="server" Enabled="False" ReadOnly="True"
                                Visible="False">
                            </telerik:RadTextBox>
                            <asp:Label ID="lblTeacherNobr" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:SqlDataSource ID="sdsName" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select dt.D_NAME,ba.NOBR,ba.NAME_C from BASE ba 
join BASETTS tts on ba.NOBR = tts.NOBR
join DEPT dt on dt.D_NO=tts.DEPT
where tts.TTSCODE in ('1','4','6')
and tts.DEPT = @dept
and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE
and CONVERT(varchar(10), GETDATE(),111) between dt.ADATE and dt.DDATE
group by dt.D_NAME,ba.NOBR,ba.NAME_C

" OnSelecting="sdsName_Selecting">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblDept" DefaultValue="-1" Name="dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsCardData" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select sd.*,tpld.trCourse_sCode as CourseCode,tpld.OJT_sCode,course.sName,course.iJobScore as courseJobScore,b.NAME_C from trOJTTemplateDetail tpld 
left join trOJTStudentD sd on tpld.trCourse_sCode = sd.trCourse_sCode and sd.sNobr =@nobr
left join trCourse course on tpld.trCourse_sCode = course.sCode
left join BASE b on sd.sCheckMan = b.NOBR
where tpld.OJT_sCode = @ojtCode">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvEmp" DefaultValue="0" Name="nobr" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="cbxCard" DefaultValue="0" Name="ojtCode" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsCard" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select ojttpl.sCode,ojttpl.sName from trOJTStudentM ojtsm 
left join trOJTTemplate ojttpl on ojtsm.OJT_sCode = ojttpl.sCode
where ojtsm.sNobr =@nobr and ojttpl.IsValid = 1
group by ojttpl.sCode,ojttpl.sName">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gvEmp" DefaultValue="0" Name="nobr" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsNobr" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select b.NAME_C,b.NOBR from BASE b left join BASETTS tts on b.NOBR = tts.NOBR
where tts.TTSCODE in ('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between tts.ADATE and tts.DDATE"></asp:SqlDataSource>
            <br />
            <asp:Label ID="lblKey" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblOjtCode" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblCourseCode" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label>
        </div>
       </telerik:RadAjaxPanel>
</asp:Content>
