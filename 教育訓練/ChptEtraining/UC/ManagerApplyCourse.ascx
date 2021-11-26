<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManagerApplyCourse.ascx.cs" Inherits="UC_ManagerApplyCourse" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div class="ApplyCourse" style="margin: 0px; padding: 0px;width:99%">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 課程報名</h2>
    
    <telerik:RadGrid ID="Gv" runat="server" Skin="Windows7" CellSpacing="0" 
        Culture="zh-TW" GridLines="None" 
        onitemdatabound="Gv_ItemDataBound" AutoGenerateColumns="False" 
        AllowPaging="True" Width="100%" Font-Size="X-Small" 
        onneeddatasource="Gv_NeedDataSource">
<MasterTableView 
            datakeynames="iAutoKey">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="categoryName" 
            FilterControlAltText="Filter categoryName column" HeaderText="階層" 
            UniqueName="categoryName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="courseName" 
            FilterControlAltText="Filter courseName column" HeaderText="課程名稱" 
            SortExpression="courseName" UniqueName="courseName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dWebJoinDateB" DataFormatString="{0:d}" 
            DataType="System.DateTime" FilterControlAltText="Filter dWebJoinDateB column" 
            HeaderText="報名起" SortExpression="dWebJoinDateB" UniqueName="dWebJoinDateB" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dWebJoinDateE" DataFormatString="{0:d}" 
            DataType="System.DateTime" FilterControlAltText="Filter dWebJoinDateE column" 
            HeaderText="報名截止日" SortExpression="dWebJoinDateE" 
            UniqueName="dWebJoinDateE" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dDateTimeA" DataFormatString="{0:d}" 
            DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column" 
            HeaderText="開課日期" SortExpression="dDateTimeA" UniqueName="dDateTimeA">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iUpLimitP" DataType="System.Int32" 
            FilterControlAltText="Filter iUpLimitP column" HeaderText="人數上限" 
            SortExpression="iUpLimitP" UniqueName="iUpLimitP" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iStudentNum" 
            FilterControlAltText="Filter iStudentNum column" HeaderText="報名人數" 
            UniqueName="iStudentNum">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
            UniqueName="TemplateColumn1">
            <ItemTemplate>
                <asp:HyperLink ID="hlJoin" runat="server">報名</asp:HyperLink>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
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

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />

</div>


