<%@ Page Title="教學資源" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="trTeachingResource.aspx.cs" Inherits="eTraining_Admin_Design_trTeachingResource" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
<h2>教學資源</h2>
    <telerik:RadButton ID="btnAdd" runat="server" Text="新增" onclick="btnAdd_Click">
    </telerik:RadButton>
    <br />
    <br />
    <asp:Panel ID="pnlResource" runat="server" Visible="False">
    <div style="width: 220px;background-color: #CDE5FF""  class="funcblock">
        <br />
        &nbsp; 名稱<telerik:RadTextBox ID="txtName" Runat="server" ValidationGroup="R">
        </telerik:RadTextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" 
            ControlToValidate="txtName" Display="Dynamic" ErrorMessage="必填欄位" 
            ForeColor="Red" SetFocusOnError="True" ValidationGroup="R"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;
        <telerik:RadButton ID="RadButton1" runat="server" onclick="RadButton1_Click" 
            Text="確定" ValidationGroup="R">
        </telerik:RadButton>
        &nbsp;
        <telerik:RadButton ID="RadButton2" runat="server" onclick="RadButton2_Click" 
            Text="取消">
        </telerik:RadButton>
        <br />
        
            <br />
    </div>
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="gvResource" runat="server" AllowAutomaticDeletes="True" 
        CellSpacing="0" Culture="zh-TW" DataSourceID="sdsResource" GridLines="None" 
        Skin="Windows7" Width="80%" AllowAutomaticInserts="True" 
        AllowAutomaticUpdates="True">
<MasterTableView autogeneratecolumns="False" datakeynames="ResourceCode" 
            datasourceid="sdsResource">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="ResourceCode" 
            FilterControlAltText="Filter ResourceCode column" HeaderText="代碼" 
            ReadOnly="True" SortExpression="ResourceCode" UniqueName="ResourceCode" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ResourceName" 
            FilterControlAltText="Filter ResourceName column" HeaderText="名稱" 
            SortExpression="ResourceName" UniqueName="ResourceName">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" 
            FilterControlAltText="Filter column1 column" UniqueName="column1">
        </telerik:GridButtonColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
            ConfirmDialogType="RadWindow" ConfirmText="確定刪除?" 
            FilterControlAltText="Filter column column" UniqueName="column" 
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
    <br />
    <asp:SqlDataSource ID="sdsResource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        DeleteCommand="DELETE FROM [trTeachingResource] WHERE [ResourceCode] = @ResourceCode" 
        InsertCommand="INSERT INTO [trTeachingResource] ([ResourceCode], [ResourceName]) VALUES (@ResourceCode, @ResourceName)" 
        SelectCommand="SELECT * FROM [trTeachingResource]" 
        UpdateCommand="UPDATE [trTeachingResource] SET [ResourceName] = @ResourceName WHERE [ResourceCode] = @ResourceCode">
        <DeleteParameters>
            <asp:Parameter Name="ResourceCode" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ResourceCode" Type="String" />
            <asp:Parameter Name="ResourceName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ResourceName" Type="String" />
            <asp:Parameter Name="ResourceCode" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

