<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectEmp3.ascx.cs" Inherits="Templet_SelectEmp3" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
          //<![CDATA[
        function onfocus() {
            var tb = $find("<%=tbQuickSearch.ClientID %>");
            tb.select();
        }
          //]]>
    </script>
</telerik:RadScriptBlock>
<asp:CheckBox ID="cbIncludeEmpLeaving" runat="server" AutoPostBack="True" Text="含離職人員"
    Visible="False" meta:resourcekey="cbIncludeEmpLeavingResource1" />
<asp:CheckBox ID="cbIsQuickSearchAdvanced" runat="server" Visible="False" meta:resourcekey="cbIsQuickSearchAdvancedResource1" />
<asp:Label ID="lblHeaderMsg2" runat="server" meta:resourceKey="lblHeaderMsgResource2"
    Text="1.請輸入部門、工號、姓名、英文名、職稱...等,兩個字元以上"></asp:Label>
<br />
<asp:Label ID="lbQuickSearchHeader" runat="server" Text="快查" Visible="False" meta:resourcekey="lbQuickSearchHeaderResource1"></asp:Label>
<telerik:RadTextBox ID="tbQuickSearch" runat="server" DisplayText="" LabelWidth="64px"
    meta:resourcekey="tbQuickSearchResource1" AutoPostBack="True" BackColor="LightGoldenrodYellow"
    OnTextChanged="tbQuickSearch_TextChanged" type="text" value="" Width="160px">
    <ClientEvents OnFocus="onfocus" />
</telerik:RadTextBox>
<telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click"
    meta:resourcekey="btnSearchResource1" Visible="False">
</telerik:RadButton>
<telerik:RadButton ID="btnClear" runat="server" Text="清除" OnClick="btnClear_Click"
    meta:resourcekey="btnClearResource1">
</telerik:RadButton>
<br />
<telerik:RadListBox ID="lb" runat="server" AllowDelete="True" SelectionMode="Multiple"
    Culture="zh-TW" meta:resourcekey="lbResource1">
</telerik:RadListBox>
<telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
    Culture="(Default)" GridLines="None" OnSelectedIndexChanged="gv_SelectedIndexChanged"
    PageSize="5" OnItemCommand="gv_ItemCommand">
    <MasterTableView DataKeyNames="Nobr">
        <CommandItemSettings ExportToPdfText="Export to PDF" />
        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
        </RowIndicatorColumn>
        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
        </ExpandCollapseColumn>
        <Columns>
            <telerik:GridTemplateColumn FilterControlAltText="Filter tpl column" UniqueName="tpl"
                meta:resourcekey="GridTemplateColumnResource1">
                <HeaderTemplate>
                    <telerik:RadButton ID="btnSelectAll" runat="server" CommandName="SelectAll" Text="全選"
                        meta:resourcekey="btnSelectAllResource1">
                    </telerik:RadButton>
                </HeaderTemplate>
                <ItemTemplate>
                    <telerik:RadButton ID="btnName" runat="server" CommandName="ExplicitSelect" Text='<%# Bind("Name") %>'
                        meta:resourcekey="btnNameResource1">
                    </telerik:RadButton>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridButtonColumn CommandName="ExplicitSelect" DataTextField="Name" FilterControlAltText="Filter Name column"
                UniqueName="Name" meta:resourcekey="GridButtonColumnResource1" Text="姓名">
            </telerik:GridButtonColumn>
            <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                HeaderText="工號" UniqueName="Nobr" meta:resourcekey="GridBoundColumnResource1">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                HeaderText="部門" UniqueName="DeptName" meta:resourcekey="GridBoundColumnResource2">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="JobName" FilterControlAltText="Filter JobName column"
                HeaderText="職稱" UniqueName="JobName" meta:resourcekey="GridBoundColumnResource3">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column"
                HeaderText="姓名" UniqueName="EmpName" Visible="False" meta:resourcekey="GridBoundColumnResource4">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column"
                UniqueName="NameC" Visible="False" HeaderText="姓名" meta:resourcekey="GridBoundColumnResource5">
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
