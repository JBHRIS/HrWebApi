<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttendedClass.ascx.cs" Inherits="UC_AttendedClass" %>
<div class="ErrorMsg" style="margin: 0px; padding: 0px; width:99%">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;學員上課通知</h2>
    <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="zh-TW" 
        DataSourceID="sdsGv" GridLines="None" Width="100%">
<MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutokey" 
            DataSourceID="sdsGv">
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
            DataTextField="sName" HeaderText="課程">
        </telerik:GridHyperLinkColumn>
        <telerik:GridBoundColumn DataField="sName" 
            FilterControlAltText="Filter sName column" HeaderText="課程" 
            SortExpression="sName" UniqueName="sName" Visible="False">
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
        <telerik:GridBoundColumn DataField="placeName" 
            FilterControlAltText="Filter placeName column" HeaderText="地點" 
            SortExpression="placeName" UniqueName="placeName">
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
    <asp:SqlDataSource ID="sdsGv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        onselecting="sdsGv_Selecting" SelectCommand="select  tm.iAutokey,cate.sName as cateName,co.sName,tm.dDateTimeA,tm.dWebJoinDateB,tm.dWebJoinDateE,tm.iUpLimitP,iStudentNum,room.sName as placeName from 
trTrainingDetailM tm
join trCourse co on tm.trCourse_sCode=co.sCode
join trCategory cate on tm.sKey = cate.sCode
join trTrainingStudentM sm on tm.iAutoKey =sm.iClassAutoKey
join trAttendClassPlace acp on acp.iClassAutoKey = tm.iAutoKey
join trClassroom room on acp.sPlaceCode = room.sCode
where tm.bIsPublished=1 and getdate()&lt;=tm.dDateTimeA
 and sm.sNobr = @nobr">
        <SelectParameters>
            <asp:Parameter Name="nobr" />
        </SelectParameters>
    </asp:SqlDataSource>



</div>