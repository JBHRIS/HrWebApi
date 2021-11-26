<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Role.aspx.cs" Inherits="System_Role" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= gvNobr.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("sysFileStructureEdit.aspx?iAutoKey=" + id, "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("sysFileStructureEdit.aspx", "UserListDialog");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("sysFileStructureEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
        Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <table style="width: 100%;">
            <tr valign="top">
                <td style="width: 59%;">
                    <telerik:RadGrid ID="gvRole" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None"
                         Skin="Simple" OnSelectedIndexChanged="gvRole_SelectedIndexChanged"
                        OnNeedDataSource="gvRole_NeedDataSource" AutoGenerateColumns="False">
                        <MasterTableView DataKeyNames="Code">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                                    Text="選取" UniqueName="Select">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column"
                                    HeaderText="角色" SortExpression="Name" UniqueName="Name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Code" FilterControlAltText="Filter Code column"
                                    HeaderText="Code" UniqueName="Code" Visible="False">
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
                </td>
                <td style="width: 39%;">
                    <asp:CheckBox ID="cbxPage" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="cbxPage_CheckedChanged"
                        Text="分頁" />
                    <br />
                    <telerik:RadGrid ID="gvNobr" runat="server" AllowFilteringByColumn="True" AllowPaging="True"
                        AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW"
                        GridLines="None" OnSelectedIndexChanged="gvNobr_SelectedIndexChanged" Skin="Office2007"
                        AllowMultiRowSelection="True" OnItemDataBound="gvNobr_ItemDataBound" OnNeedDataSource="gvNobr_NeedDataSource">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" 
                                UseClientSelectColumnOnly="True" />
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="False"></Selecting>
                        </ClientSettings>
                        <MasterTableView DataKeyNames="NOBR">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridClientSelectColumn FilterControlAltText="Filter Select column" UniqueName="Select">
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                                    HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                                    HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                                    HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="D_NAMETextBox" runat="server" Text='<%# Bind("D_NAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="D_NAMELabel" runat="server" Text='<%# Eval("D_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="JOB_NAME" FilterControlAltText="Filter JOB_NAME column"
                                    HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RoleName" EmptyDataText="" FilterControlAltText="Filter sName column"
                                    HeaderText="角色" UniqueName="RoleName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RoleCode" FilterControlAltText="Filter iRoleKey column"
                                    UniqueName="RoleCode" Visible="False" EmptyDataText="">
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
                    <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
</asp:Content>
