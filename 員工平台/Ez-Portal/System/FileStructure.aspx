<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FileStructure.aspx.cs" Inherits="System_FileStructure" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function ShowInsertForm() {
                window.radopen("sysFileStructureEdit.aspx", "UserListDialog");
                return false;
            }

            function RowDblClick(sender, eventArgs) {
                window.radopen("sysFileStructureEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <div style="float: left; width: 300px">
            <telerik:RadButton ID="btnUpdateFileStructureCache" runat="server" OnClick="btnUpdateFileStructureCache_Click"
                Text="更改檔案結構快取">
            </telerik:RadButton>
            <telerik:RadTreeView ID="tv" runat="server" EnableDragAndDrop="True" EnableDragAndDropBetweenNodes="True"
                OnNodeDrop="tv_NodeDrop" Skin="Sunset" OnNodeClick="tv_NodeClick">
            </telerik:RadTreeView>
            <asp:Label ID="lblMode" runat="server" Visible="False"></asp:Label>
        </div>
        <div style="float: right;width: 700px">
            <table style="width: 100%;">
                <tbody>
                    <tr>
                        <td>
                            Key
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbKey" runat="server" Width="300px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            路徑
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbPath" runat="server" Width="300px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            檔名
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbFileName" runat="server" Width="300px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Title
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbTitle" runat="server" Width="300px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Description
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbDesc" runat="server" Width="300px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            父節點
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbParentKey" runat="server" Width="300px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            順序
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="ntbOrder" runat="server" DataType="System.Int32" Width="300px">
                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            IconPath
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbIconPath" runat="server" Width="300px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            IconFileName
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbIconName" runat="server" Width="300px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            允許角色
                        </td>
                        <td>
                            <asp:CheckBoxList ID="cblRole" runat="server" RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    </tr>
                    <tr>
                        <td>
                            顯示註釋
                        </td>
                        <td>
                            <asp:CheckBox ID="cbDisplayNotice" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            註釋標題
                        </td>
                        <td>
                            <telerik:RadTextBox ID="tbNoticeTitle" runat="server" Width="256px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            註釋內容
                        </td>
                        <td>
                            <telerik:RadEditor ID="etNoticeContent" runat="server" ContentAreaMode="Div" EditModes="Design, Preview"
                                Height="250px" ToolsFile="~/Editor/RadEditor/BasicTools.xml" Width="500px">
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlSave" runat="server" Visible="False">
                                <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
                                </telerik:RadButton>
                            </asp:Panel>
                            <asp:Panel ID="pnlAddUpdate" runat="server">
                                <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增">
                                </telerik:RadButton>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>