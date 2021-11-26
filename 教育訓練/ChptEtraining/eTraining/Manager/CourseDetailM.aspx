<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="CourseDetailM.aspx.cs" Inherits="eTraining_Manager_CourseDetailM" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;
    <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select tm.trCourse_sCode,td.dClassDate,tc.sName,tt.sName,tm.iJobScore from trTrainingDetailM tm
join trAttendClassDate td on tm.iAutoKey=td.iClassAutoKey
join trAttendClassPlace tp on tm.iAutoKey=tp.iClassAutoKey and td.dClassDate=tp.dClassDate
join trClassroom tc on tp.sPlaceCode=tc.sCode
join trAttendClassTeacher tct on tm.iAutoKey=tct.iClassAutoKey and td.dClassDate=tct.dClassDate
join trTeacher tt on tct.sTeacherCode=tt.sCode
where tm.iAutoKey=@iAutoKey
order by td.dClassDate">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="iAutoKey" QueryStringField="ClassID" />
        </SelectParameters>
    </asp:SqlDataSource>
    <h2>
        <asp:Label ID="lblCourse" runat="server"></asp:Label></h2>
    <telerik:RadButton ID="btnGoBack" runat="server" onclick="btnGoBack_Click" 
        Text="回上頁">
    </telerik:RadButton>
    <br />
    <telerik:RadGrid ID="gv" runat="server" Culture="zh-TW" DataSourceID="sdsGv"
        Skin="Windows7" CellSpacing="0" GridLines="None" Width="90%" 
        AutoGenerateColumns="False">
        <MasterTableView DataSourceID="sdsGv">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="categoryName" FilterControlAltText="Filter categoryName column"
                    HeaderText="階層" UniqueName="categoryName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="courseName" 
                    FilterControlAltText="Filter courseName column" HeaderText="課程名稱" 
                    UniqueName="courseName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dClassDate" DataType="System.DateTime" FilterControlAltText="Filter dClassDate column"
                    HeaderText="上課日期" SortExpression="dClassDate" UniqueName="dClassDate" 
                    DataFormatString="{0:d}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dClassDateA" DataFormatString="{0:HH:mm}" 
                    FilterControlAltText="Filter dClassDateA column" HeaderText="上課時間" 
                    UniqueName="dClassDateA">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="trCourse_sCode" 
                    FilterControlAltText="Filter trCourse_sCode column" HeaderText="課程代碼" 
                    SortExpression="trCourse_sCode" UniqueName="trCourse_sCode" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="teacherName" FilterControlAltText="Filter sName column"
                    HeaderText="講師" SortExpression="teacherName" UniqueName="teacherName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="placeName" FilterControlAltText="Filter sName1 column"
                    HeaderText="訓練地點" SortExpression="placeName" UniqueName="placeName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dWebJoinDateE" FilterControlAltText="Filter dWebJoinDateE column"
                    HeaderText="報名截止日" UniqueName="dWebJoinDateE" DataFormatString="{0:d}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iJobScore" DataType="System.Int32" 
                    FilterControlAltText="Filter iJobScore column" HeaderText="職能積分" 
                    SortExpression="iJobScore" UniqueName="iJobScore" Visible="False">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
        </HeaderContextMenu>
    </telerik:RadGrid>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        width="100%">
        
    <table style="width:100%;">
        <tr>
            <td align="left" valign="top">
                <telerik:RadTreeView ID="tvDept" Runat="server" onnodeclick="tvDept_NodeClick">
                </telerik:RadTreeView>
            </td>
            <td align="left" valign="top">
    選擇報名學員<telerik:RadGrid ID="gvNobr" runat="server" 
    CellSpacing="0" Culture="zh-TW" DataSourceID="sdsName" GridLines="None" 
    Skin="Windows7" Width="80%" AllowFilteringByColumn="True" 
            AllowMultiRowSelection="True" AllowPaging="True" 
    AllowSorting="True" onitemcommand="gvNobr_ItemCommand" 
    onitemdatabound="gvNobr_ItemDataBound">
            <clientsettings>
                <selecting allowrowselect="True" />
<Selecting AllowRowSelect="True"></Selecting>
            </clientsettings>
            <MasterTableView autogeneratecolumns="False" 
        datakeynames="NOBR" datasourceid="sdsName" allowfilteringbycolumn="False" 
                allowpaging="False" allowsorting="False">
                <CommandItemSettings ExportToPdfText="Export to PDF">
                </CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="D_NAME" 
            FilterControlAltText="Filter D_NAME column" HeaderText="部門" SortExpression="D_NAME" 
            UniqueName="D_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NOBR" 
            FilterControlAltText="Filter NOBR column" HeaderText="工號" 
            SortExpression="NOBR" UniqueName="NOBR">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NAME_C" 
                        FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
                        SortExpression="NAME_C" UniqueName="NAME_C">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_NAME" 
                        FilterControlAltText="Filter JOB_NAME column" HeaderText="職稱" 
                        UniqueName="JOB_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Reg" 
                        FilterControlAltText="Filter Reg column" Text="報名" UniqueName="Reg">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="PushButton" CommandName="DeReg" 
                        ConfirmDialogType="RadWindow" FilterControlAltText="Filter DeReg column" 
                        Text="取消報名" UniqueName="DeReg">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="stKey" EmptyDataText="" 
                        FilterControlAltText="Filter stKey column" UniqueName="stKey" Visible="False">
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
            </td>
        </tr>
    </table>
        <br />
    <br />
        <br />
        <asp:SqlDataSource ID="sdsName" runat="server" 
            
    ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select ba.NOBR,ba.NAME_C,dt.D_NAME ,st.iAutoKey as stKey,JOB_NAME
from BASE ba
join BASETTS bt on ba.NOBR=bt.NOBR
join DEPT dt on bt.DEPT=dt.D_NO
left join trTrainingStudentM st on ba.NOBR = st.sNobr and st.iClassAutoKey = @ClassID
left join JOB on bt.JOB = job.JOB
where bt.TTSCODE in('1','4','6') and CONVERT(varchar(10), GETDATE(),111) between bt.ADATE and bt.DDATE
and dt.D_NO=@dept
and CONVERT(varchar(10), GETDATE(),111) between dt.ADATE and dt.DDATE">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="ClassID" 
                    QueryStringField="ClassID" />
                <asp:ControlParameter ControlID="tvDept" DefaultValue="-1" Name="dept" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsGv" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select tm.trCourse_sCode,td.dClassDate,tc.sName as placeName,tt.sName as teacherName,tm.iJobScore 
,course.sName as courseName,category.sName as categoryName,tm.dWebJoinDateE,td.dClassDateA
from trTrainingDetailM tm
join trCourse course on tm.trCourse_sCode = course.sCode
join trCategory category on tm.sKey = category.sCode
join trAttendClassDate td on tm.iAutoKey=td.iClassAutoKey
join trAttendClassPlace tp on tm.iAutoKey=tp.iClassAutoKey and td.dClassDate=tp.dClassDate
join trClassroom tc on tp.sPlaceCode=tc.sCode
join trAttendClassTeacher tct on tm.iAutoKey=tct.iClassAutoKey and td.dClassDate=tct.dClassDate
join trTeacher tt on tct.sTeacherCode=tt.sCode
where tm.iAutoKey=@iAutoKey
order by td.dClassDate">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="iAutoKey" 
                    QueryStringField="ClassID" />
            </SelectParameters>
        </asp:SqlDataSource>
    <br />
    <asp:Label ID="lbldept" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblnobr" runat="server" Visible="False"></asp:Label>
    </telerik:RadAjaxPanel>
</asp:Content>
