<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="trKnotTeaches.aspx.cs" Inherits="eTraining_Admin_Design_trKnotTeaches" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    $('.funcblock').corner("15px");
    </script>
<h2>結訓條件</h2>
    <telerik:RadButton ID="btnAdd" runat="server" Text="新增" onclick="btnAdd_Click">
    </telerik:RadButton>
    <br />
    <br />
    <asp:Panel ID="pnlKnotTeaches" runat="server" Visible="False">
    <div style="width: 220px;background-color: #CDE5FF""  class="funcblock">
        <br />
        &nbsp; 名稱<telerik:RadTextBox ID="txtName" Runat="server" ValidationGroup="K">
        </telerik:RadTextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" 
            ControlToValidate="txtName" Display="Dynamic" ErrorMessage="必填欄位" 
            ForeColor="Red" SetFocusOnError="True" ValidationGroup="K"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;
        <telerik:RadButton ID="btnCheck" runat="server" onclick="btnCheck_Click" 
            Text="確定" ValidationGroup="K">
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
    <telerik:RadGrid ID="gvKnotTeaches" runat="server" AllowAutomaticDeletes="True" 
        AllowAutomaticUpdates="True" CellSpacing="0" Culture="zh-TW" 
        DataSourceID="sdsKnotTeaches" GridLines="None" Skin="Windows7" Width="70%">
<MasterTableView autogeneratecolumns="False" datakeynames="KnotTeachesCode" 
            datasourceid="sdsKnotTeaches">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="KnotTeachesCode" 
            FilterControlAltText="Filter KnotTeachesCode column" HeaderText="代碼" 
            ReadOnly="True" SortExpression="KnotTeachesCode" 
            UniqueName="KnotTeachesCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="KnotTeachesName" 
            FilterControlAltText="Filter KnotTeachesName column" HeaderText="名稱" 
            SortExpression="KnotTeachesName" UniqueName="KnotTeachesName">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" 
            FilterControlAltText="Filter column column" UniqueName="column">
        </telerik:GridButtonColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
            ConfirmDialogType="RadWindow" ConfirmText="確定刪除?" 
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
    <asp:SqlDataSource ID="sdsKnotTeaches" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        DeleteCommand="DELETE FROM [trKnotTeaches] WHERE [KnotTeachesCode] = @KnotTeachesCode" 
        InsertCommand="INSERT INTO [trKnotTeaches] ([KnotTeachesCode], [KnotTeachesName]) VALUES (@KnotTeachesCode, @KnotTeachesName)" 
        SelectCommand="SELECT * FROM [trKnotTeaches]" 
        UpdateCommand="UPDATE [trKnotTeaches] SET [KnotTeachesName] = @KnotTeachesName WHERE [KnotTeachesCode] = @KnotTeachesCode">
        <DeleteParameters>
            <asp:Parameter Name="KnotTeachesCode" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="KnotTeachesCode" Type="String" />
            <asp:Parameter Name="KnotTeachesName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="KnotTeachesName" Type="String" />
            <asp:Parameter Name="KnotTeachesCode" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

