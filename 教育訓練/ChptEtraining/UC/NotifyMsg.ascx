<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NotifyMsg.ascx.cs" Inherits="UC_NotifyMsg" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
    width="100%">
<div class="ErrorMsg" style="margin: 0px; padding: 0px;width:99%">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;課程訊息通知</h2>
    <telerik:RadGrid ID="gv" runat="server" Skin="Windows7" Culture="zh-TW"
        AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" 
        GridLines="None" PageSize="5" 
        Font-Size="X-Small" Width="100%" onneeddatasource="gv_NeedDataSource">
        <MasterTableView DataKeyNames="Guid">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="Guid" 
                    FilterControlAltText="Filter Guid column" UniqueName="Guid" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Message" 
                    FilterControlAltText="Filter Message column" HeaderText="訊息" 
                    UniqueName="Message">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NotifyAdate" 
                    FilterControlAltText="Filter NotifyAdate column" HeaderText="日期" 
                    UniqueName="NotifyAdate" DataFormatString="{0:d}">
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
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7">
        </HeaderContextMenu>
    </telerik:RadGrid>
</div>
</telerik:RadAjaxPanel>
