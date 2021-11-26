<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ErrorMsg.ascx.cs" Inherits="UC_ErrorMsg" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
    width="100%">
<div class="HRErrorMsg" style="margin: 0px; padding: 0px;width:99%">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;教育訓練異常訊息通知</h2>
    <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRole" runat="server" Visible="False"></asp:Label>
    <telerik:RadGrid ID="gv" runat="server" Skin="Windows7" Culture="zh-TW" DataSourceID="sdsGv"
        AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" 
        GridLines="None" PageSize="5" onitemcommand="gv_ItemCommand" 
        Font-Size="X-Small" Width="100%">
        <MasterTableView DataSourceID="sdsGv" DataKeyNames="iAutoKey">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                    UniqueName="iAutoKey" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ErrorMsg" FilterControlAltText="Filter ErrorMsg column"
                    HeaderText="訊息" UniqueName="ErrorMsg">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NotifyDate" FilterControlAltText="Filter NotifyDate column"
                    HeaderText="日期" UniqueName="NotifyDate" DataFormatString="{0:d}">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn CommandName="Done" ConfirmText="不再顯示此通知訊息!" 
                    FilterControlAltText="Filter Done column" Text="確認" UniqueName="Done">
                </telerik:GridButtonColumn>
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
    <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select * from trErrorNotify where TargetNobr = @nobr and dCompletedDate is null
union select * from trErrorNotify where TargetRole = @role and dCompletedDate is null
order by NotifyDate desc" OnSelecting="sdsGv_Selecting">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblNobr" DefaultValue="0" Name="nobr" PropertyName="Text" />
            <asp:ControlParameter ControlID="lblRole" DefaultValue="0" Name="role" 
                PropertyName="Text" DbType="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>
</telerik:RadAjaxPanel>
