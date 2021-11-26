<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="eTraining_System_User" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

            function RowDblClick(sender, eventArgs) {
                window.radopen("sysFileStructureEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" 
        Runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
                    width="100%" HorizontalAlign="NotSet" 
        LoadingPanelID="RadAjaxLoadingPanel1">

                       <table style="width:100%;">
        <tr valign="top">
            <td style="width:59%;">

                <telerik:RadGrid ID="gvNobr" runat="server" AllowFilteringByColumn="True" 
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                    CellSpacing="0" Culture="zh-TW" GridLines="None" 
                    onselectedindexchanged="gvNobr_SelectedIndexChanged" Skin="Office2007" 
                    onneeddatasource="gvNobr_NeedDataSource">
<MasterTableView datakeynames="NOBR">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridButtonColumn CommandName="Select" 
            FilterControlAltText="Filter Select column" Text="選擇" UniqueName="Select">
        </telerik:GridButtonColumn>
        <telerik:GridBoundColumn DataField="NOBR" 
            FilterControlAltText="Filter NOBR column" HeaderText="工號" 
            SortExpression="NOBR" UniqueName="NOBR">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NAME_C" 
            FilterControlAltText="Filter NAME_C column" HeaderText="姓名" 
            SortExpression="NAME_C" UniqueName="NAME_C">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="D_NAME" 
            FilterControlAltText="Filter D_NAME column" HeaderText="部門" 
            SortExpression="D_NAME" UniqueName="D_NAME">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="JOB_NAME" 
            FilterControlAltText="Filter JOB_NAME column" HeaderText="職稱" 
            SortExpression="JOB_NAME" UniqueName="JOB_NAME">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                </telerik:RadGrid>
            </td>
            <td style="width:39%;">
                <telerik:RadGrid ID="gvUserRole" runat="server" AllowMultiRowSelection="True" 
                    CellSpacing="0" Culture="zh-TW" GridLines="None" 
                    onitemdatabound="gvUserRole_ItemDataBound" Skin="Simple" 
                    onneeddatasource="gvUserRole_NeedDataSource">
                    <clientsettings>
                        <selecting allowrowselect="True" EnableDragToSelectRows="False" 
                            UseClientSelectColumnOnly="True" />
                    </clientsettings>
<MasterTableView autogeneratecolumns="False" datakeynames="iAutoKey">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridClientSelectColumn FilterControlAltText="Filter Select column" 
            UniqueName="Select">
        </telerik:GridClientSelectColumn>
        <telerik:GridBoundColumn DataField="sName" 
            FilterControlAltText="Filter sName column" HeaderText="角色名稱" 
            SortExpression="sName" UniqueName="sName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iKey" DataType="System.Int32" 
            FilterControlAltText="Filter iKey column" HeaderText="iKey" 
            SortExpression="iKey" UniqueName="iKey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="NOBR" EmptyDataText="" 
            FilterControlAltText="Filter NOBR column" HeaderText="NOBR" 
            SortExpression="NOBR" UniqueName="NOBR" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutoKey" 
            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
            UniqueName="iAutoKey" Visible="False">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                </telerik:RadGrid>
                <telerik:RadButton ID="btnSave" runat="server" onclick="btnSave_Click" 
                    Text="存檔">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="sdsUserRole" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        SelectCommand="select r.*,ur.NOBR from sysRole r left join sysUserRole ur on r.iKey = ur.iRoleKey and NOBR=@nobr 
where CONVERT(varchar(10), GETDATE(),111) between r.ddateA and r.ddateD">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvNobr" DefaultValue="0" Name="nobr" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Editing record" Height="300px"
                Width="400px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true" />
        </Windows>
    </telerik:RadWindowManager>
                </telerik:RadAjaxPanel>
 
</asp:Content>

