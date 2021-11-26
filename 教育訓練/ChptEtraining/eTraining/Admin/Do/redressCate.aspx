<%@ Page Title="矯正措施通知類別" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="redressCate.aspx.cs" Inherits="eTraining_Reports_Admin_Do_redressCate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        矯正措施通知類別</h2>
    <telerik:RadButton ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click">
    </telerik:RadButton>
    <br />
    <br />
    <asp:Panel ID="pnl" runat="server" Visible="False">
        <div style="width: 250px; background-color: #CDE5FF" class="funcblock">
            <br />
            &nbsp; 開立類別<telerik:RadTextBox ID="txtName" runat="server" ValidationGroup="M">
            </telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                Display="Dynamic" ErrorMessage="必填欄位" ForeColor="Red" SetFocusOnError="True"
                ValidationGroup="M"></asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;
            <telerik:RadButton ID="btnCheck" runat="server" Text="確定" ValidationGroup="M" 
                onclick="btnCheck_Click">
            </telerik:RadButton>
            &nbsp;
            <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
            </telerik:RadButton>
            <br />
            <br />
        </div>
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="gv" runat="server" Skin="Windows7" Width="40%" 
        CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGv" GridLines="None">
<MasterTableView AutoGenerateColumns="False" DataKeyNames="sCode" DataSourceID="sdsGv" 
            AllowAutomaticDeletes="True" AllowAutomaticInserts="True" 
            AllowAutomaticUpdates="True">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="sCode" 
            FilterControlAltText="Filter sCode column" HeaderText="sCode" ReadOnly="True" 
            SortExpression="sCode" UniqueName="sCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sName" 
            FilterControlAltText="Filter sName column" HeaderText="開立類別" 
            SortExpression="sName" UniqueName="sName">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" 
            FilterControlAltText="Filter edit column" UniqueName="edit">
        </telerik:GridButtonColumn>
        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
            FilterControlAltText="Filter column column" UniqueName="delete" Visible="False">
        </telerik:GridButtonColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7"></HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <asp:SqlDataSource ID="sdsGv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        SelectCommand="SELECT * FROM [trStudentError]" 
        DeleteCommand="DELETE FROM [trStudentError] WHERE [sCode] = @sCode" 
        InsertCommand="INSERT INTO [trStudentError] ([sCode], [sName]) VALUES (@sCode, @sName)" 
        UpdateCommand="UPDATE [trStudentError] SET [sName] = @sName WHERE [sCode] = @sCode">
        <DeleteParameters>
            <asp:Parameter Name="sCode" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sCode" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
