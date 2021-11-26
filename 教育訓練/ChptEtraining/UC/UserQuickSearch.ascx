<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserQuickSearch.ascx.cs"
    Inherits="UC_UserQuickSearch" %>
<!--  <div style="width: 450px; background-color: #CDE5FF" class="funcblock">-->
<div style="font-size: x-small">
    <br />
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearchNobr">
    姓名｜工號<telerik:RadTextBox ID="txtName" runat="server" Width="60px">
    </telerik:RadTextBox>
    &nbsp;<telerik:RadButton ID="btnSearchNobr" runat="server" Text="查詢" OnClick="btnSearchNobr_Click">
    </telerik:RadButton>    
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="gvNobr" runat="server" AllowPaging="True" CellSpacing="0" 
        Culture="zh-TW" GridLines="None" Skin="Office2010Blue" 
        OnSelectedIndexChanged="gvNobr_SelectedIndexChanged" 
        onneeddatasource="gvNobr_NeedDataSource" AutoGenerateColumns="False">
        <MasterTableView DataKeyNames="Nobr">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridButtonColumn FilterControlAltText="Filter Select column" Text="選擇" UniqueName="Select"
                    CommandName="Select">
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                    HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter NOBR column"
                    HeaderText="工號" SortExpression="NOBR" UniqueName="Nobr" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                    HeaderText="部門" SortExpression="D_NAME" UniqueName="DeptName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JobName" FilterControlAltText="Filter JOB_NAME column"
                    HeaderText="職稱" SortExpression="JOB_NAME" UniqueName="JobName" 
                    Visible="False">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
            <WebServiceSettings>
                <ODataSettings InitialContainerName="">
                </ODataSettings>
            </WebServiceSettings>
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            <WebServiceSettings>
                <ODataSettings InitialContainerName="">
                </ODataSettings>
            </WebServiceSettings>
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
</div>
<!--   </div> -->
