<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="sysFileStructure.aspx.cs" Inherits="Admin_sysFileStructure" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= gv.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("sysFileStructureEdit.aspx?iAutoKey=" + id, "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("sysFileStructureEdit.aspx", "UserListDialog");
                return false;
            }
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("sysFileStructureEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gv" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gv">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gv" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnAdd" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadGrid ID="gv" runat="server" AllowPaging="True" 
    AllowSorting="True" DataSourceID="sdsGV"
        GridLines="None" OnItemCreated="gv_ItemCreated" Culture="zh-TW" 
    ShowFooter="True" CellSpacing="0" ondeletecommand="gv_DeleteCommand">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsGV">
            <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                    UniqueName="TemplateColumn">
                    <FooterTemplate>
                        <telerik:RadButton ID="btnExport" runat="server" CommandName="Export" Text="匯出">
                        </telerik:RadButton>
                    </FooterTemplate>
                    <HeaderTemplate>
                        <telerik:RadButton ID="btnAdd" runat="server" CommandName="A" Text="新增">
                        </telerik:RadButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <telerik:RadButton ID="btnEdit" runat="server" 
                            CommandArgument='<%# Eval("iAutoKey") %>' CommandName="E" 
                            SplitButtonCssClass="" SplitButtonPosition="Right" Text="編輯" 
                            ToolTip='<%# Eval("iAutoKey") %>'>
                        </telerik:RadButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn ConfirmText="您確定要刪除嗎？" ConfirmDialogType="RadWindow" ConfirmTitle="刪除"
                    ButtonType="ImageButton" CommandName="Delete" ConfirmDialogHeight="100px" ConfirmDialogWidth="220px"
                    Text="刪除" />
                <telerik:GridBoundColumn DataField="sKey" FilterControlAltText="Filter sKey column"
                    HeaderText="主鍵" SortExpression="sKey" UniqueName="sKey">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sCat" FilterControlAltText="Filter sCat column"
                    HeaderText="類別" SortExpression="sCat" UniqueName="sCat">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sPath" FilterControlAltText="Filter sPath column"
                    HeaderText="路徑" SortExpression="sPath" UniqueName="sPath">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sFileName" 
                    FilterControlAltText="Filter sFileName column" HeaderText="檔名"
                    SortExpression="sFileName" UniqueName="sFileName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sFileTitle" 
                    FilterControlAltText="Filter sFileTitle column" HeaderText="抬頭"
                    SortExpression="sFileTitle" UniqueName="sFileTitle">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sysRole_iKey" FilterControlAltText="Filter sysRole_iKey column"
                    HeaderText="權限代碼" SortExpression="sysRole_iKey" UniqueName="sysRole_iKey" 
                    DataType="System.Int32">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sParentKey" 
                    FilterControlAltText="Filter sParentKey column" HeaderText="上層鍵"
                    SortExpression="sParentKey" UniqueName="sParentKey">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iOrder" DataType="System.Int32" FilterControlAltText="Filter iOrder column"
                    HeaderText="順序" SortExpression="iOrder" UniqueName="iOrder">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" 
                    DataType="System.DateTime" FilterControlAltText="Filter dDateA column" 
                    HeaderText="生效日" SortExpression="dDateA" UniqueName="dDateA">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dDateD" DataType="System.DateTime" FilterControlAltText="Filter dDateD column"
                    HeaderText="失效日" SortExpression="dDateD" UniqueName="dDateD" 
                    DataFormatString="{0:d}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                    HeaderText="登錄者" SortExpression="sKeyMan" UniqueName="sKeyMan">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
                    FilterControlAltText="Filter dKeyDate column" HeaderText="登錄日期" 
                    SortExpression="dKeyDate" UniqueName="dKeyDate">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="sdsGV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        
        DeleteCommand="DELETE FROM [sysFileStructure] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [sysFileStructure] ([sKey], [sCat], [sPath], [sFileName], [sFileTitle], [sDescription], [sysRole_iKey], [sParentKey], [iOrder], [dDateA], [dDateD], [sKeyMan], [dKeyDate]) VALUES (@sKey, @sCat, @sPath, @sFileName, @sFileTitle, @sDescription, @sysRole_iKey, @sParentKey, @iOrder, @dDateA, @dDateD, @sKeyMan, @dKeyDate)"
        SelectCommand="SELECT * FROM [sysFileStructure]" 
        UpdateCommand="UPDATE [sysFileStructure] SET [sKey] = @sKey, [sCat] = @sCat, [sPath] = @sPath, [sFileName] = @sFileName, [sFileTitle] = @sFileTitle, [sDescription] = @sDescription, [sysRole_iKey] = @sysRole_iKey, [sParentKey] = @sParentKey, [iOrder] = @iOrder, [dDateA] = @dDateA, [dDateD] = @dDateD, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sKey" Type="String" />
            <asp:Parameter Name="sCat" Type="String" />
            <asp:Parameter Name="sPath" Type="String" />
            <asp:Parameter Name="sFileName" Type="String" />
            <asp:Parameter Name="sFileTitle" Type="String" />
            <asp:Parameter Name="sDescription" Type="String" />
            <asp:Parameter Name="sysRole_iKey" Type="Int32" />
            <asp:Parameter Name="sParentKey" Type="String" />
            <asp:Parameter Name="iOrder" Type="Int32" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="sKey" Type="String" />
            <asp:Parameter Name="sCat" Type="String" />
            <asp:Parameter Name="sPath" Type="String" />
            <asp:Parameter Name="sFileName" Type="String" />
            <asp:Parameter Name="sFileTitle" Type="String" />
            <asp:Parameter Name="sDescription" Type="String" />
            <asp:Parameter Name="sysRole_iKey" Type="Int32" />
            <asp:Parameter Name="sParentKey" Type="String" />
            <asp:Parameter Name="iOrder" Type="Int32" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="UserListDialog" runat="server" Title="Editing record" Height="300px"
                Width="400px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true" />
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>

