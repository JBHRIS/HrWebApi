<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectEmp2.ascx.cs" Inherits="Templet_SelectEmp2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:CheckBox ID="cbIncludeEmpLeaving" runat="server" AutoPostBack="True"
    Text="含離職人員" Visible="False" />
<br />
<asp:CheckBox ID="cbDisplaySelected" runat="server" AutoPostBack="True"
    Text="只顯示已選擇" oncheckedchanged="cbDisplaySelected_CheckedChanged" />
<telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
    Culture="zh-TW" GridLines="None" onneeddatasource="gv_NeedDataSource" 
    AllowFilteringByColumn="True" AllowMultiRowSelection="True" PageSize="6" 
    onitemcommand="gv_ItemCommand" onprerender="gv_PreRender" Skin="Vista" 
    AllowCustomPaging="True" AllowPaging="True">
    <MasterTableView datakeynames="Nobr" AllowCustomPaging="False">
        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <Columns>
            <telerik:GridTemplateColumn FilterControlAltText="Filter tplSelect column" 
                UniqueName="tplSelect" AllowFiltering="False">
                <HeaderTemplate>
                              <telerik:RadButton ID="btnSelectAll" runat="server" CommandName="SelectAll" 
                  Text="全選">
              </telerik:RadButton>              
                </HeaderTemplate>                
                <ItemTemplate>
                    <telerik:RadButton ID="btnSelect" runat="server" CommandName="Select" Text="選擇">
                    </telerik:RadButton>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn AllowFiltering="False" 
                FilterControlAltText="Filter tplDeselect column" UniqueName="tplDeselect">
                <HeaderTemplate>
                    <telerik:RadButton ID="btnDeselectAll" runat="server" CommandName="DeselectAll" 
                        Text="全消">
                    </telerik:RadButton>
                </HeaderTemplate>
                <ItemTemplate>
                    <telerik:RadButton ID="btnDeselect" runat="server" CommandName="Deselect" 
                        Text="取消">
                    </telerik:RadButton>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                HeaderText="工號" UniqueName="Nobr" 
                meta:resourcekey="GridBoundColumnResource1" AutoPostBackOnFilter="True" 
                CurrentFilterFunction="Contains">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column"
                HeaderText="姓名" UniqueName="EmpName" 
                meta:resourcekey="GridBoundColumnResource4" AutoPostBackOnFilter="True" 
                CurrentFilterFunction="Contains">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                HeaderText="部門" UniqueName="DeptName" 
                meta:resourcekey="GridBoundColumnResource2" AutoPostBackOnFilter="True" 
                CurrentFilterFunction="Contains">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="JobName" FilterControlAltText="Filter JobName column"
                HeaderText="職稱" UniqueName="JobName" 
                meta:resourcekey="GridBoundColumnResource3" AutoPostBackOnFilter="True" 
                CurrentFilterFunction="Contains">
            </telerik:GridBoundColumn>
        </Columns>
        <EditFormSettings>
            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
            </EditColumn>
        </EditFormSettings>
        <PagerStyle AlwaysVisible="True" />
    </MasterTableView>
    <PagerStyle AlwaysVisible="True" />
    <FilterMenu EnableImageSprites="False">
    </FilterMenu>
</telerik:RadGrid>
