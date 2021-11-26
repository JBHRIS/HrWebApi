<%@ Page Title="費用項目" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="CostItem.aspx.cs" Inherits="eTraining_Admin_Design_CostItem" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        費用項目</h2>
    <telerik:RadButton ID="btnAddCost" runat="server" Text="新增" 
        onclick="btnAddCost_Click">
    </telerik:RadButton>
    <br />
    <br />
    <asp:Panel ID="pnlAddCost" runat="server" Visible="False">
    <div style="width: 220px;background-color: #CDE5FF""  class="funcblock">
        <br />
        &nbsp; 名稱<telerik:RadTextBox ID="txtsName" Runat="server" ValidationGroup="v">
        </telerik:RadTextBox>
        <asp:RequiredFieldValidator ID="rfvsName" runat="server" 
            ControlToValidate="txtsName" Display="Dynamic" ErrorMessage="必填欄位" 
            ForeColor="Red" SetFocusOnError="True" ValidationGroup="v"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;
        <telerik:RadButton ID="btnCheck" runat="server" onclick="btnCheck_Click" 
            Text="確定" ValidationGroup="v">
        </telerik:RadButton>
        &nbsp;
        <telerik:RadButton ID="btnCancel" runat="server" onclick="btnCancel_Click" 
            Text="取消">
        </telerik:RadButton>
        <br />
        
            <br />
    </div>
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="gvCost" runat="server" CellSpacing="0" 
    DataSourceID="sdsGv" GridLines="None" Skin="Windows7" Width="70%" 
        Culture="zh-TW" AllowAutomaticDeletes="True" AllowAutomaticUpdates="True" 
        AllowAutomaticInserts="True" AllowSorting="True">
<MasterTableView autogeneratecolumns="False" datakeynames="iAutoKey" 
            datasourceid="sdsGv">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="trCostItemCode" 
            FilterControlAltText="Filter trCostItemCode column" HeaderText="代碼" 
            ReadOnly="True" UniqueName="trCostItemCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="trCostItemName" 
            FilterControlAltText="Filter trCostItemName column" HeaderText="名稱" 
            SortExpression="trCostItemName" UniqueName="trCostItemName">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" 
            FilterControlAltText="Filter column column" UniqueName="column">
        </telerik:GridButtonColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
            FilterControlAltText="Filter column1 column" UniqueName="column1" 
            Visible="False">
        </telerik:GridButtonColumn>
    </Columns>

<EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column" 
                    UniqueName="EditCommandColumn1" ButtonType="PushButton" CancelText="取消" 
                    EditText="編輯" HeaderButtonType="PushButton" InsertText="新增" UpdateText="更新">
                </EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="sdsGv" runat="server" 
    ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
    SelectCommand="SELECT * FROM [trCostItem] order by trCostItemName
" 
        DeleteCommand="DELETE FROM [trCostItem] WHERE [iAutoKey] = @iAutoKey" 
        InsertCommand="INSERT INTO [trCostItem] ([trCostItemCode], [trCostItemName]) VALUES (@trCostItemCode, @trCostItemName)" 
        
        
        
        UpdateCommand="UPDATE [trCostItem] SET[trCostItemName] = @trCostItemName WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="trCostItemCode" Type="String" />
            <asp:Parameter Name="trCostItemName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="trCostItemName" Type="String" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    
</asp:Content>
