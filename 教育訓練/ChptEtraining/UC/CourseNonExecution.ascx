<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CourseNonExecution.ascx.cs" Inherits="UC_CourseNonExecution" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
    width="100%">
<div class="ErrorMsg" style="margin: 0px; padding: 0px;width:99%">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;未執行課程</h2>
    <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRole" runat="server" Visible="False"></asp:Label>
    <telerik:RadGrid ID="gv" runat="server" Skin="Windows7" Culture="zh-TW"
        AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" 
        GridLines="None" PageSize="5" 
        Font-Size="X-Small" Width="100%" onneeddatasource="gv_NeedDataSource">
        <MasterTableView DataKeyNames="iAutoKey">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                    UniqueName="iAutoKey" Visible="False" HeaderText="開課代碼">
                </telerik:GridBoundColumn>
                <telerik:GridHyperLinkColumn DataNavigateUrlFields="iAutoKey" 
                    DataNavigateUrlFormatString="~/eTraining/Admin/Do/SetCourseDo.aspx?ID={0}" 
                    DataTextField="courseName" FilterControlAltText="Filter hlCourseName column" 
                    HeaderText="課程名稱" UniqueName="hlCourseName">
                </telerik:GridHyperLinkColumn>
                <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                    HeaderText="課程名稱" UniqueName="courseName" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="startDate" FilterControlAltText="Filter startDate column"
                    HeaderText="開課日期" UniqueName="startDate" 
                    DataFormatString="{0:yyyy/M/d HHmm}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="studentNum" 
                    FilterControlAltText="Filter studentNum column" HeaderText="報名人數" 
                    UniqueName="studentNum">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
            <PagerStyle ShowPagerText="False" />
        </MasterTableView>
        <PagerStyle ShowPagerText="False" />
        <FilterMenu EnableImageSprites="False">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
        </HeaderContextMenu>
    </telerik:RadGrid>
</div>

</telerik:RadAjaxPanel>

