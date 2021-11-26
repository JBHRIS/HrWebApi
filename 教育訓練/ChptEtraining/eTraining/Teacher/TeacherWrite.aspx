<%@ Page Title="填寫課後資料" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="TeacherWrite.aspx.cs" Inherits="eTraining_Teacher_TeacherWrite" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        填寫課後資料</h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        width="100%">
    
    年度
    <telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" 
        AutoPostBack="True" onselectedindexchanged="cbxYear_SelectedIndexChanged">
    </telerik:RadComboBox>
    <br />
   
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
        SelectedIndex="0" Skin="Vista" ontabclick="RadTabStrip1_TabClick">
        <Tabs>
            <telerik:RadTab runat="server" PageViewID="pvStudentScore" Text="學員評分表" 
                Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" PageViewID="pvQuestionary" Text="問卷填寫">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" 
        Width="100%" RenderSelectedPageOnly="True">
        <telerik:RadPageView ID="pvStudentScore" runat="server">
            <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
                CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGv" GridLines="None" 
                OnItemCommand="gv_ItemCommand" onitemdatabound="gv_ItemDataBound" Skin="Vista" 
                Width="90%"><mastertableview allowpaging="True" datakeynames="iAutoKey" 
                datasourceid="sdsGv"><commanditemsettings exporttopdftext="Export to PDF"></commanditemsettings><rowindicatorcolumn 
                filtercontrolalttext="Filter RowIndicator column"><HeaderStyle Width="20px">
            </HeaderStyle>
            </rowindicatorcolumn>
            <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
            <HeaderStyle Width="20px"></HeaderStyle>
            </expandcollapsecolumn>
            <Columns>
                <telerik:GridBoundColumn DataField="categoryName" 
                    FilterControlAltText="Filter categoryName column" HeaderText="階層" 
                    SortExpression="categoryName" UniqueName="categoryName"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="courseName" 
                    FilterControlAltText="Filter courseName column" HeaderText="課程名稱" 
                    SortExpression="courseName" UniqueName="courseName"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" 
                    DataType="System.DateTime" FilterControlAltText="Filter dDateA column" 
                    HeaderText="上課日期" SortExpression="dDateA" UniqueName="dDateA"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                    UniqueName="TemplateColumn" Visible="False"><ItemTemplate><telerik:RadButton 
                        ID="btnWrite" runat="server" Text="課後資料"></telerik:RadButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridCheckBoxColumn DataField="bIsNeedClassRpt" 
                    FilterControlAltText="Filter bIsNeedClassRpt column" 
                    HeaderText="bIsNeedClassRpt" UniqueName="bIsNeedClassRpt" Visible="False"></telerik:GridCheckBoxColumn>
                <telerik:GridCheckBoxColumn DataField="bIsNeedStudentScore" 
                    FilterControlAltText="Filter bIsNeedStudentScore column" 
                    HeaderText="bIsNeedStudentScore" UniqueName="bIsNeedStudentScore" 
                    Visible="False"></telerik:GridCheckBoxColumn>
                <telerik:GridCheckBoxColumn DataField="IsTeacherFinishClassScore" 
                    FilterControlAltText="Filter IsTeacherFinishClassScore column" 
                    HeaderText="是否完成學員表現評分" UniqueName="IsTeacherFinishClassScore"><ItemStyle 
                    HorizontalAlign="Center" VerticalAlign="Middle" /></telerik:GridCheckBoxColumn>
                <telerik:GridButtonColumn CommandName="Score" 
                    FilterControlAltText="Filter Score column" HeaderText="學員表現評分" Text="學員表現評分表填寫" 
                    UniqueName="Score"></telerik:GridButtonColumn>
                <telerik:GridButtonColumn CommandName="ScoreForReport" 
                    FilterControlAltText="Filter ScoreForReport column" HeaderText="心得評分" 
                    Text="心得評分" UniqueName="ScoreForReport"></telerik:GridButtonColumn>
            </Columns>
            <editformsettings>
            <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
            </editcolumn>
            </editformsettings>
            </mastertableview>
            <filtermenu enableimagesprites="False">
            <webservicesettings>
            <odatasettings initialcontainername="">
            </odatasettings>
            </webservicesettings>
            </filtermenu>
            <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
            <webservicesettings>
            <odatasettings initialcontainername="">
            </odatasettings>
            </webservicesettings>
            </headercontextmenu>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="sdsGv" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                OnSelecting="sdsGv_Selecting" SelectCommand="select m.iAutoKey,ca.sName as categoryName,co.sName as courseName,m.dDateA,m.bIsNeedClassRpt,m.bIsNeedStudentScore,m.IsTeacherFinishClassScore
 from trTrainingDetailM m
join trCategory ca on m.sKey=ca.sCode
join trCourse co on m.trCourse_sCode=co.sCode
where GETDATE() &gt; m.dDateTimeA and m.iYear=@Year
and m.bIsPublished =1 
and m.iAutoKey in (select at.iClassAutoKey from trAttendClassTeacher at 
join trTeacher t on at.sTeacherCode = t.sCode where t.sNobr = @teacher)
order by m.dDateA desc"><SelectParameters><asp:ControlParameter ControlID="cbxYear" 
                        DefaultValue="0" Name="Year" PropertyName="SelectedValue" /><asp:Parameter 
                        Name="teacher" />
                </SelectParameters>
            </asp:SqlDataSource>
        </telerik:RadPageView>
        <telerik:RadPageView ID="pvQuestionary" runat="server">
            <telerik:RadGrid ID="gvQ" runat="server" AutoGenerateColumns="False" 
                CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGvQ" GridLines="None" 
                onitemdatabound="gvQ_ItemDataBound" Skin="Vista" Width="90%"><mastertableview 
                allowpaging="True" datakeynames="iAutokey" datasourceid="sdsGvQ"><commanditemsettings 
                exporttopdftext="Export to PDF"></commanditemsettings><rowindicatorcolumn 
                filtercontrolalttext="Filter RowIndicator column"></rowindicatorcolumn><expandcollapsecolumn 
                filtercontrolalttext="Filter ExpandColumn column"></expandcollapsecolumn><Columns><telerik:GridBoundColumn 
                    DataField="categoryName" FilterControlAltText="Filter categoryName column" 
                    HeaderText="階層" UniqueName="categoryName"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="CourseName" FilterControlAltText="Filter CourseName column" 
                    HeaderText="課程名稱" UniqueName="CourseName"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dDateA" DataFormatString="{0:d}" 
                    FilterControlAltText="Filter dDateA column" HeaderText="上課日期" 
                    UniqueName="dDateA"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="ClassSession" FilterControlAltText="Filter ClassSession column" 
                    HeaderText="梯次" UniqueName="ClassSession" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="Qname" FilterControlAltText="Filter Qname column" HeaderText="問卷名稱" 
                    SortExpression="Qname" UniqueName="Qname"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="iAutokey" DataType="System.Int32" 
                    FilterControlAltText="Filter iAutokey column" HeaderText="iAutokey" 
                    ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutokey" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="sCode" FilterControlAltText="Filter sCode column" HeaderText="sCode" 
                    SortExpression="sCode" UniqueName="sCode" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="qType_sCode" FilterControlAltText="Filter qType_sCode column" 
                    HeaderText="qType_sCode" SortExpression="qType_sCode" UniqueName="qType_sCode" 
                    Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="sNobr" FilterControlAltText="Filter sNobr column" HeaderText="sNobr" 
                    SortExpression="sNobr" UniqueName="sNobr" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="sPW" FilterControlAltText="Filter sPW column" HeaderText="sPW" 
                    SortExpression="sPW" UniqueName="sPW" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="sName" FilterControlAltText="Filter sName column" HeaderText="sName" 
                    SortExpression="sName" UniqueName="sName" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="sDeptCode" FilterControlAltText="Filter sDeptCode column" 
                    HeaderText="sDeptCode" SortExpression="sDeptCode" UniqueName="sDeptCode" 
                    Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="sDeptName" FilterControlAltText="Filter sDeptName column" 
                    HeaderText="sDeptName" SortExpression="sDeptName" UniqueName="sDeptName" 
                    Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dAmountDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter dAmountDate column" HeaderText="dAmountDate" 
                    SortExpression="dAmountDate" UniqueName="dAmountDate" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dWriteDate" DataFormatString="{0:d}" DataType="System.DateTime" 
                    EmptyDataText="" FilterControlAltText="Filter dWriteDate column" 
                    HeaderText="填寫日" SortExpression="dWriteDate" UniqueName="dWriteDate" 
                    Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dSchoolDateB" DataType="System.DateTime" 
                    FilterControlAltText="Filter dSchoolDateB column" HeaderText="dSchoolDateB" 
                    SortExpression="dSchoolDateB" UniqueName="dSchoolDateB" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dSchoolDateE" DataType="System.DateTime" 
                    FilterControlAltText="Filter dSchoolDateE column" HeaderText="dSchoolDateE" 
                    SortExpression="dSchoolDateE" UniqueName="dSchoolDateE" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dFillFormDatetimeB" DataFormatString="{0:d}" 
                    DataType="System.DateTime" 
                    FilterControlAltText="Filter dFillFormDatetimeB column" HeaderText="填寫日起" 
                    SortExpression="dFillFormDatetimeB" UniqueName="dFillFormDatetimeB"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dFillFormDatetimeE" DataFormatString="{0:d}" 
                    DataType="System.DateTime" 
                    FilterControlAltText="Filter dFillFormDatetimeE column" HeaderText="填寫截止日" 
                    SortExpression="dFillFormDatetimeE" UniqueName="dFillFormDatetimeE"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dTeacherCheckedDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter dTeacherCheckedDate column" 
                    HeaderText="dTeacherCheckedDate" SortExpression="dTeacherCheckedDate" 
                    UniqueName="dTeacherCheckedDate" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dTRCheckedDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter dTRCheckedDate column" HeaderText="dTRCheckedDate" 
                    SortExpression="dTRCheckedDate" UniqueName="dTRCheckedDate" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="iYear" DataType="System.Int32" 
                    FilterControlAltText="Filter iYear column" HeaderText="iYear" 
                    SortExpression="iYear" UniqueName="iYear" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="iSession" DataType="System.Int32" 
                    FilterControlAltText="Filter iSession column" HeaderText="iSession" 
                    SortExpression="iSession" UniqueName="iSession" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="iClassAutoKey" DataType="System.Int32" 
                    FilterControlAltText="Filter iClassAutoKey column" HeaderText="iClassAutoKey" 
                    SortExpression="iClassAutoKey" UniqueName="iClassAutoKey" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column" 
                    HeaderText="trCourse_sCode" SortExpression="trCourse_sCode" 
                    UniqueName="trCourse_sCode" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="trCourse_sName" FilterControlAltText="Filter trCourse_sName column" 
                    HeaderText="trCourse_sName" SortExpression="trCourse_sName" 
                    UniqueName="trCourse_sName" Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="iTotalFraction" DataType="System.Int32" 
                    FilterControlAltText="Filter iTotalFraction column" HeaderText="總分" 
                    SortExpression="iTotalFraction" UniqueName="iTotalFraction"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column" 
                    HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" 
                    Visible="False"></telerik:GridBoundColumn><telerik:GridBoundColumn 
                    DataField="dKeyDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
                    SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False"></telerik:GridBoundColumn><telerik:GridHyperLinkColumn 
                    DataNavigateUrlFields="sCode" 
                    DataNavigateUrlFormatString="~/eTraining/Questionary/qWrite.aspx?Code={0}" 
                    FilterControlAltText="Filter Write column" Text="填寫" UniqueName="Write"></telerik:GridHyperLinkColumn><telerik:GridBoundColumn 
                    DataField="CourseCode" FilterControlAltText="Filter CourseCode column" 
                    HeaderText="課程代碼" UniqueName="CourseCode" Visible="False"></telerik:GridBoundColumn>
            </Columns>
            <editformsettings>
            <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
            </editcolumn>
            </editformsettings>
            </mastertableview>
            <filtermenu enableimagesprites="False">
            </filtermenu>
            <headercontextmenu cssclass="GridContextMenu GridContextMenu_Windows7">
            </headercontextmenu>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="sdsGvQ" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                onselecting="sdsGvQ_Selecting" SelectCommand="select bm.*,qm.sName as Qname,bm.iClassAutoKey,dm.iSession as ClassSession,dm.trCourse_sCode as CourseCode,c.sName as CourseName,ca.sName as categoryName,dm.dDateA
from qBaseM bm 
left join qQuestionaryM qm on bm.qQuestionary_sCode = qm.sCode
left join ClassQuestionnaire cq on bm.iClassAutoKey = cq.iClassAutoKey and bm.qQuestionary_sCode = cq.qQuestionaryM
left join trTrainingDetailM dm on cq.iClassAutoKey = dm.iAutoKey
left join trCourse c on dm.trCourse_sCode = c.sCode
left join trCategory ca on dm.sKey=ca.sCode
where dm.iYear =@year and qm.FillerCategory ='T'
and bm.trTeacher_sCode=@teacherCode
and dm.dDateTimeA &lt;GETDATE()
order by dFillFormDatetimeB desc"><SelectParameters><asp:ControlParameter ControlID="cbxYear" 
                        DefaultValue=" " Name="year" PropertyName="SelectedValue" /><asp:Parameter 
                        Name="teacherCode" />
                </SelectParameters>
            </asp:SqlDataSource>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    </telerik:RadAjaxPanel>
    <br />
    <br />
</asp:Content>
