<%@ Page Title="訓練地點" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="trClassroom.aspx.cs" Inherits="eTraining_Admin_Design_trClassroom" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        訓練地點</h2>
    <telerik:RadButton runat="server" Text="新增" ID="btnAdd" OnClick="btnAdd_Click">
    </telerik:RadButton>
    <br />
    <br />
    <asp:Panel ID="pnlClassroom" runat="server" Visible="False">
        <div style="width: 450px; background-color: #CDE5FF" class="funcblock">
            <br />
            &nbsp; 名稱<telerik:RadTextBox ID="txtName" runat="server" ValidationGroup="C">
            </telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                Display="Dynamic" ErrorMessage="必填欄位" ForeColor="Red"
                ValidationGroup="C"></asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp; 地址<telerik:RadTextBox ID="txtaddr" runat="server" TextMode="MultiLine" ValidationGroup="C"
                Width="350px">
            </telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="rfvCode1" runat="server" ControlToValidate="txtaddr"
                Display="Dynamic" ErrorMessage="必填欄位" ForeColor="Red"
                ValidationGroup="C"></asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;
            <telerik:RadButton ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="確定"
                ValidationGroup="C">
            </telerik:RadButton>
            &nbsp;
            <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
            </telerik:RadButton>
            <br />
            <br />
        </div>
    </asp:Panel>
    <br />
    <telerik:RadGrid ID="gvClassroom" runat="server" AllowAutomaticDeletes="True" AllowAutomaticUpdates="True"
        CellSpacing="0" Culture="zh-TW" DataSourceID="sdsClassroom" GridLines="None"
        Skin="Windows7" Width="90%">
<ClientSettings>
<Selecting CellSelectionMode="None"></Selecting>
</ClientSettings>

        <MasterTableView AutoGenerateColumns="False" DataKeyNames="sCode" DataSourceID="sdsClassroom">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                    HeaderText="代碼" SortExpression="sCode" UniqueName="sCode" Visible="False" ReadOnly="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                    HeaderText="地點" SortExpression="sName" UniqueName="sName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sAddr" FilterControlAltText="Filter sAddr column"
                    HeaderText="地址" SortExpression="sAddr" UniqueName="sAddr">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" FilterControlAltText="Filter column column"
                    UniqueName="Edit">
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                    ConfirmText="確定刪除?" FilterControlAltText="Filter column1 column" UniqueName="column1"
                    Visible="False">
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column" 
                    ButtonType="PushButton" CancelText="取消" EditText="編輯" 
                    HeaderButtonType="PushButton" InsertText="新增" UpdateText="更新">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="sdsClassroom" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        DeleteCommand="DELETE FROM [trClassroom] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [trClassroom] ([sCode], [sName], [sAddr], [sKeyMan], [dKeyDate]) VALUES (@sCode, @sName, @sAddr, @sKeyMan, @dKeyDate)"
        SelectCommand="SELECT * FROM [trClassroom]" UpdateCommand="UPDATE [trClassroom] SET  [sName] = @sName, [sAddr] = @sAddr WHERE [sCode] = @sCode">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sAddr" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sAddr" Type="String" />
            <asp:Parameter Name="sCode" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
</asp:Content>
