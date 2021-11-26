<%@ Page Title="教學方式" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SetCourseType.aspx.cs" Inherits="SetCourseType" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        課程類型設定</h2>
    <telerik:RadButton ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click">
    </telerik:RadButton>
    <br />
    <br />
    <asp:Panel ID="pnlMethod" runat="server" Visible="False">
        <div style="width: 220px; background-color: #CDE5FF" class="funcblock">
            <br />
            &nbsp; 名稱<telerik:RadTextBox ID="txtName" runat="server" ValidationGroup="M">
            </telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                Display="Dynamic" ErrorMessage="必填欄位" ForeColor="Red"
                ValidationGroup="M"></asp:RequiredFieldValidator>
            <br />
            <br />
            &nbsp;
            <telerik:RadButton ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="確定"
                ValidationGroup="M">
            </telerik:RadButton>
            &nbsp;
            <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
            </telerik:RadButton>
            <br />
            <br />
        </div>
    </asp:Panel>
    <telerik:RadButton ID="btnExportExcel" runat="server" 
        onclick="btnExportExcel_Click" Text="匯出Excel">
    </telerik:RadButton>
    <br />
    <telerik:RadGrid ID="gv" runat="server" AllowPaging="True" DataSourceID="sds"
        GridLines="None" Culture="zh-TW" ShowFooter="True" CellSpacing="0" Skin="Windows7"
        Width="90%" AllowAutomaticDeletes="True" AllowAutomaticUpdates="True" 
        AutoGenerateColumns="False">
        <CommandItemStyle Wrap="True"></CommandItemStyle>
<ClientSettings>
<Selecting CellSelectionMode="None"></Selecting>
</ClientSettings>

        <MasterTableView DataKeyNames="sCode" DataSourceID="sds"
            ShowFooter="False">
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                    HeaderText="代碼" SortExpression="sCode" UniqueName="sCode" ReadOnly="True" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                    HeaderText="名稱" SortExpression="sName" UniqueName="sName">
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
                    UniqueName="EditCommandColumn1" ButtonType="PushButton" CancelText="取消" 
                    EditText="編輯" HeaderButtonType="PushButton" InsertText="新增" UpdateText="更新">
                </EditColumn>
            </EditFormSettings>
            <HeaderStyle Wrap="False" />
        </MasterTableView>
        <HeaderStyle Wrap="False" />
        <CommandItemStyle Wrap="True" />
        <ItemStyle Wrap="True" />
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <asp:SqlDataSource ID="sds" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        DeleteCommand="DELETE FROM [CourseType] WHERE [sCode] = @sCode" InsertCommand="INSERT INTO [CourseType] ([sCode], [sName]) VALUES (@MethodCode, @MethodName)"
        SelectCommand="SELECT * FROM [CourseType] order by sName" 
        UpdateCommand="UPDATE [CourseType] SET [sName] = @sName WHERE [sCode] = @sCode">
        <DeleteParameters>
            <asp:Parameter Name="sCode" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="MethodCode" Type="String" />
            <asp:Parameter Name="MethodName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="sName" />
            <asp:Parameter Name="sCode" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
