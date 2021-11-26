<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassUpload.aspx.cs" Inherits="eTraining_Admin_Do_ClassUpload" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            課程檔案</h2>
        <table style="width: 100%;">
        <tr>
                <td class="style1" align="left" valign="top">
                    檔案名稱：<telerik:RadTextBox ID="tbNote" runat="server">
                    </telerik:RadTextBox>
                </td>
                <td class="style1" valign="top" align="left">
                    <telerik:RadAsyncUpload ID="ul" runat="server">
                        <Localization Remove="移除" Select="選擇" />
                    </telerik:RadAsyncUpload>
                </td>
            </tr>
            <tr>
                <td class="style1" align="left" colspan="2" valign="top">
                    <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                        Culture="zh-TW" DataSourceID="sdsGv" GridLines="None" OnDeleteCommand="gv_DeleteCommand"
                        OnItemDataBound="gv_ItemDataBound" Skin="Outlook" Width="85%">
                        <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsGv">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="FileOriginName" FilterControlAltText="Filter FileOriginName column"
                                    HeaderText="檔案名稱" SortExpression="FileOriginName" UniqueName="FileOriginName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FileNote" FilterControlAltText="Filter FileNote column"
                                    HeaderText="備註" SortExpression="FileNote" UniqueName="FileNote">
                                </telerik:GridBoundColumn>
                                <telerik:GridHyperLinkColumn FilterControlAltText="Filter Download column" Text="下載"
                                    UniqueName="Download">
                                </telerik:GridHyperLinkColumn>
                                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmText="是否刪除?"
                                    FilterControlAltText="Filter Delete column" UniqueName="Delete">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="FileStoredName" 
                                    FilterControlAltText="Filter FileStoredName column" HeaderText="存放檔案名稱" 
                                    UniqueName="FileStoredName" Visible="False">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                    <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                        SelectCommand="SELECT * FROM [UPLOAD] WHERE ([FileCategoryKey] = @FileCategoryKey) AND FileCategory = 'Class' and FileDeleted=0">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="0" Name="FileCategoryKey" QueryStringField="ID"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </td>
            </tr>
            
        </table>
        <br />
        <telerik:RadButton ID="btnUpload" runat="server" Text="上傳檔案" OnClick="btnUpload_Click">
        </telerik:RadButton>
        <br />
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>
