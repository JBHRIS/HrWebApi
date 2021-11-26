<%@ Page Language="C#"  CodeFile="RoleConfig.aspx.cs" Inherits="HR_Mang_RoleConfig"
MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true" Title="Untitled Page" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>

    
        <telerik:RadGrid ID="gv" runat="server" onneeddatasource="gv_NeedDataSource" 
            AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None" 
            ondeletecommand="gv_DeleteCommand" meta:resourcekey="gvResource1">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="Role" 
            FilterControlAltText="Filter Role column" HeaderText="角色" 
            UniqueName="Role" meta:resourcekey="GridBoundColumnResource1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Type" 
            FilterControlAltText="Filter Type column" HeaderText="設定型態" 
            UniqueName="Type" meta:resourcekey="GridBoundColumnResource2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Value" 
            FilterControlAltText="Filter Value column" HeaderText="設定值" 
            UniqueName="Value" EmptyDataText="" 
            meta:resourcekey="GridBoundColumnResource3">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Delete" 
            ConfirmText="確定是否刪除?" FilterControlAltText="Filter CmdDelete column" Text="刪除" 
            UniqueName="CmdDelete" meta:resourcekey="GridButtonColumnResource1">
        </telerik:GridButtonColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>

    
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="110px" 
            meta:resourcekey="Panel1Resource1">
            <asp:Localize ID="Localize1" runat="server" 
                meta:resourcekey="Localize1Resource1" Text="角色"></asp:Localize>
            <telerik:RadTextBox ID="tbRole" Runat="server" DisplayText="" LabelCssClass="" 
                LabelWidth="64px" meta:resourcekey="tbRoleResource1">
            </telerik:RadTextBox>
            <br />
            <asp:Localize ID="Localize2" runat="server" 
                meta:resourcekey="Localize2Resource1" Text="設定類型"></asp:Localize>
            <telerik:RadComboBox ID="cbType" Runat="server" Culture="zh-TW" 
                AutoPostBack="True" onselectedindexchanged="cbType_SelectedIndexChanged" 
                meta:resourcekey="cbTypeResource1">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="工號" Value="工號" 
                        meta:resourcekey="RadComboBoxItemResource1" Owner="" />
                    <telerik:RadComboBoxItem runat="server" Text="部門" Value="部門" 
                        meta:resourcekey="RadComboBoxItemResource2" Owner="" />
                    <telerik:RadComboBoxItem runat="server" Text="資料群組" Value="資料群組" 
                        meta:resourcekey="RadComboBoxItemResource3" Owner="" />
                </Items>
            </telerik:RadComboBox>
            <br />
            <asp:Localize ID="Localize3" runat="server" 
                meta:resourcekey="Localize3Resource1" Text="設定值"></asp:Localize>
            <telerik:RadTextBox ID="tbValue" Runat="server" DisplayText="" LabelCssClass="" 
                LabelWidth="64px" meta:resourcekey="tbValueResource1">
            </telerik:RadTextBox>
            <telerik:RadComboBox ID="cbDataGroup" Runat="server" DataTextField="GROUPNAME" 
                DataValueField="DATAGROUP1" Visible="False" Culture="zh-TW" 
                meta:resourcekey="cbDataGroupResource1">
            </telerik:RadComboBox>
            <br />
            <telerik:RadButton ID="RadButton1" runat="server" onclick="RadButton1_Click" 
                Text="存檔" meta:resourcekey="RadButton1Resource1">
            </telerik:RadButton>
        </asp:Panel>
        <br />

    
    </div>
</asp:Content>