<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeptEmpAttendedClass.ascx.cs" Inherits="UC_DeptEmpAttendedClass" %>
<div class="ErrorMsg" style="margin: 0px; padding: 0px; width:99%">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;部門上課通知</h2>
    <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-TW" 
        GridLines="None" Width="100%" 
        onneeddatasource="RadGrid1_NeedDataSource" AllowPaging="True" 
        AutoGenerateColumns="False">
<MasterTableView DataKeyNames="iAutokey">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="cateName" 
            FilterControlAltText="Filter cateName column" HeaderText="階層" 
            UniqueName="cateName">
        </telerik:GridBoundColumn>
        <telerik:GridHyperLinkColumn DataNavigateUrlFields="iAutokey" 
            DataNavigateUrlFormatString="~/eTraining/Staff/CourseDetail.aspx?ClassID={0}" 
            FilterControlAltText="Filter link column" UniqueName="link" 
            DataTextField="courseName" HeaderText="課程" Visible="False">
        </telerik:GridHyperLinkColumn>
        <telerik:GridBoundColumn DataField="courseName" 
            FilterControlAltText="Filter sName column" HeaderText="課程" 
            SortExpression="courseName" UniqueName="courseName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dDateTimeA" DataFormatString="{0:yyyy/M/d HHmm}" 
            DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column" 
            HeaderText="時間" SortExpression="dDateTimeA" UniqueName="dDateTimeA">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dWebJoinDateB" DataType="System.DateTime" 
            FilterControlAltText="Filter dWebJoinDateB column" HeaderText="dWebJoinDateB" 
            SortExpression="dWebJoinDateB" UniqueName="dWebJoinDateB" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dWebJoinDateE" DataType="System.DateTime" 
            FilterControlAltText="Filter dWebJoinDateE column" HeaderText="dWebJoinDateE" 
            SortExpression="dWebJoinDateE" UniqueName="dWebJoinDateE" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iUpLimitP" DataType="System.Int32" 
            FilterControlAltText="Filter iUpLimitP column" HeaderText="iUpLimitP" 
            SortExpression="iUpLimitP" UniqueName="iUpLimitP" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iStudentNum" DataType="System.Int32" 
            FilterControlAltText="Filter iStudentNum column" HeaderText="iStudentNum" 
            SortExpression="iStudentNum" UniqueName="iStudentNum" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="name_c" 
            FilterControlAltText="Filter name_c column" HeaderText="學員" 
            UniqueName="name_c">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutokey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutokey column" HeaderText="iAutokey" 
            ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutokey" Visible="False">
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