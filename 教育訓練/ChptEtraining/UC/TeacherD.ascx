<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeacherD.ascx.cs" Inherits="UC_TeacherD" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="ApplyCourse">
    <h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 已開課資訊</h2>
    年度<telerik:RadComboBox ID="RadComboBox1" runat="server" Width="70px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2010" Value="2010" />
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
        </Items>
    </telerik:RadComboBox>
    <br />
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Windows7">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

        <PagerStyle EnableSEOPaging="True" />

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7"></HeaderContextMenu>
    </telerik:RadGrid>
    <br />
</div>
