<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="User.aspx.cs" Inherits="System_User" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <div style="float: left; width: 700px">
            <telerik:RadGrid ID="gvNobr" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
                AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW"
                GridLines="None" OnSelectedIndexChanged="gvNobr_SelectedIndexChanged" Skin="Office2007"
                OnNeedDataSource="gvNobr_NeedDataSource">
                <MasterTableView DataKeyNames="NOBR">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                            Text="選擇" UniqueName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                            HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                            HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                            HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
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
        </div>
        <div style="float: left;">
            <telerik:RadGrid ID="gvUserRole" runat="server" AllowMultiRowSelection="True" CellSpacing="0"
                Culture="zh-TW" GridLines="None" OnItemDataBound="gvUserRole_ItemDataBound" Skin="Simple"
                OnNeedDataSource="gvUserRole_NeedDataSource" AutoGenerateColumns="False">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" UseClientSelectColumnOnly="True" />
                </ClientSettings>
                <MasterTableView DataKeyNames="Code">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter Select column" UniqueName="Select">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                            HeaderText="角色名稱" SortExpression="Name" UniqueName="Name">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Code" FilterControlAltText="Filter iKey column"
                            HeaderText="Code" SortExpression="Code" UniqueName="Code" Visible="False">
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
            <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="存檔">
            </telerik:RadButton>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
