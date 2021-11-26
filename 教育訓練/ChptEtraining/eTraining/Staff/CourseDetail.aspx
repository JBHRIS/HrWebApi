<%@ Page Title="開課報名" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="CourseDetail.aspx.cs" Inherits="eTraining_Staff_CourseDetail" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;
    <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select tm.trCourse_sCode,td.dClassDate,tc.sName as placeName,tt.sName as teacherName,tm.iJobScore 
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
            <asp:QueryStringParameter DefaultValue="0" Name="iAutoKey" QueryStringField="ClassID" />
        </SelectParameters>
    </asp:SqlDataSource>
    <h2>
        <asp:Label ID="lblCourse" runat="server"></asp:Label></h2>
    <br />
    <asp:Label ID="lblnobr" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>
    <br />
    <telerik:RadGrid ID="gv" runat="server" Culture="zh-TW" DataSourceID="SqlDataSource2"
        Skin="Windows7" CellSpacing="0" GridLines="None" Width="90%">
        <MasterTableView DataSourceID="SqlDataSource2" AutoGenerateColumns="False">
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
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <telerik:RadButton ID="btnAdd" runat="server" Text="報名" 
        OnClick="RadButton1_Click">
    </telerik:RadButton>
    <br />
</asp:Content>
