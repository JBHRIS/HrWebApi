<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BirthdayControl2.ascx.cs"
    Inherits="Templet_BirthdayControl2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
    <h3>
        <telerik:RadButton ID="btnHeader" runat="server" ButtonType="ToggleButton" Text="本月壽星"
            Font-Size="14px" OnCheckedChanged="btnHeader_CheckedChanged" Skin="Simple" ToggleType="CheckBox"
            Font-Names="微軟正黑體,arial" HoveredCssClass="Home">
        </telerik:RadButton>
    </h3>
    <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None"
        AutoGenerateColumns="False" Skin="Simple" Visible="False">
        <ClientSettings>
            <Scrolling AllowScroll="True" />
        </ClientSettings>
        <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn FilterControlAltText="Filter D_NAME column" UniqueName="D_NAME"
                    HeaderText="部門" DataField="D_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter NOBR column" UniqueName="NOBR"
                    DataField="NOBR" HeaderText="工號">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter NAME_C column" UniqueName="NAME_C"
                    DataField="NAME_C" HeaderText="姓名">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter BIRDT column" UniqueName="BIRDT"
                    DataField="BIRDT" HeaderText="月份" DataFormatString="{0:M/d}">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
</telerik:RadAjaxPanel>