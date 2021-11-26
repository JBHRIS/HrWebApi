<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="FileStructure.aspx.cs" Inherits="eTraining_System_FileStructure" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
        Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <table style="width: 100%;">
            <tr valign="top">
                <td style="width: 50%;">
                    <telerik:RadButton ID="btnUpdateFileStructureCache" runat="server" OnClick="btnUpdateFileStructureCache_Click"
                        Text="更改檔案結構快取">
                    </telerik:RadButton>
                    <telerik:RadTreeView ID="tv" runat="server" EnableDragAndDrop="True" EnableDragAndDropBetweenNodes="True"
                        OnNodeDrop="tv_NodeDrop" Skin="Sunset" OnNodeClick="tv_NodeClick">
                    </telerik:RadTreeView>
                    <asp:Label ID="lblMode" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="width: 49%;">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Key
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbKey" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                類別
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCategory" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                路徑
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbPath" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                檔名
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbFileName" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Title
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbTitle" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Description
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbDesc" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                父節點
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbParentKey" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                順序
                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="ntbOrder" runat="server" DataType="System.Int32">
                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                IconPath
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbIconPath" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                IconFileName
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbIconName" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                允許角色
                            </td>
                            <td>
                                <asp:CheckBoxList ID="cblRole" runat="server">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                                                <tr>
                            <td colspan="2">

                                <asp:Panel ID="pnlSave" runat="server" Visible="False">
                                    <telerik:RadButton ID="btnSave" runat="server" onclick="btnSave_Click" 
                                        Text="儲存">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                                        Text="取消">
                                    </telerik:RadButton>
                                </asp:Panel>
                                <asp:Panel ID="pnlAddUpdate" runat="server">
                                    <telerik:RadButton ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="新增">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                                        Text="修改">
                                    </telerik:RadButton>
                                </asp:Panel>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
</asp:Content>
