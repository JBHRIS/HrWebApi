<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeacherAttendedClass.ascx.cs" Inherits="UC_TeacherAttendedClass" %>
<div class="ErrorMsg" style="margin: 0px; padding: 0px; width:99%">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;講師課程通知</h2>
    <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-TW" 
        GridLines="None" Width="100%" 
        onneeddatasource="RadGrid1_NeedDataSource" AllowPaging="True" 
        AutoGenerateColumns="False">
<MasterTableView DataKeyNames="iAutoKey">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="CourseName" 
            FilterControlAltText="Filter sName column" HeaderText="課程" 
            UniqueName="CourseName" SortExpression="courseName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dDateTimeA" DataFormatString="{0:yyyy/M/d HHmm}" 
            DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column" 
            HeaderText="時間" SortExpression="dDateTimeA" UniqueName="dDateTimeA">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iStudentNum" DataType="System.Int32" 
            FilterControlAltText="Filter iStudentNum column" HeaderText="學員數" 
            SortExpression="iStudentNum" UniqueName="iStudentNum">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutokey column" HeaderText="iAutokey" 
            ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutoKey" 
            Visible="False">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
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



</div>