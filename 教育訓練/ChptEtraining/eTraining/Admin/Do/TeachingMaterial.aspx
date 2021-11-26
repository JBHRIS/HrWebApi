<%@ Page Title="上傳教材" Language="C#" AutoEventWireup="true" CodeFile="TeachingMaterial.aspx.cs" Inherits="eTraining_Admin_Do_TeachingMaterial" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <style type="text/css">
        .style1 {}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadGrid_Outlook
{
    font:12px/16px "segoe ui",arial,sans-serif;
}

.RadGrid_Outlook
{
    border:1px solid #002d96;
    background:#fff;
    color:#000;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

.RadInput_Default
{
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput
{
	vertical-align:middle;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div> 



    <h2>教材</h2>
    <table style="width:100%;">
        <tr>
            <td class="style1" width="40%" valign="top">
                <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <telerik:RadAsyncUpload ID="ul" runat="server" 
                    MultipleFileSelection="Automatic">
                    <Localization Remove="移除" Select="選擇" />
                </telerik:RadAsyncUpload>
                <br />
                檔案備註：<telerik:RadTextBox ID="tbFileNote" Runat="server">
                        </telerik:RadTextBox>
                    <br />
                <telerik:RadButton ID="btnUpload" runat="server" onclick="btnUpload_Click" 
                    Text="上傳檔案">
                </telerik:RadButton>
            </td>
            <td align="left" valign="top">
                        <telerik:RadGrid ID="gvTeachingMaterial" runat="server" CellSpacing="0" 
                            Culture="zh-TW" DataSourceID="sdsTeachingMaterialGv" GridLines="None" 
                            Skin="Outlook" onitemcommand="gvTeachingMaterial_ItemCommand">
                            <mastertableview autogeneratecolumns="False" datakeynames="iAutoKey" 
                            datasourceid="sdsTeachingMaterialGv">
                                <commanditemsettings exporttopdftext="Export to PDF" />
                                <commanditemsettings exporttopdftext="Export to PDF" />
                                <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </rowindicatorcolumn>
                                <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px" />
                                </expandcollapsecolumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="FileOriginName" 
                                        FilterControlAltText="Filter FileOriginName column" HeaderText="檔案" 
                                        SortExpression="FileOriginName" UniqueName="FileOriginName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FileNote" 
                                        FilterControlAltText="Filter FileNote column" HeaderText="備註" 
                                        SortExpression="FileNote" UniqueName="FileNote">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridHyperLinkColumn DataNavigateUrlFields="FileStoredName" 
                                        DataNavigateUrlFormatString="~/eTraining/Admin/download.ashx?ID={0}" FilterControlAltText="Filter Download column" 
                                        Text="下載" UniqueName="Download">
                                    </telerik:GridHyperLinkColumn>
                                    <telerik:GridBoundColumn DataField="FileCategoryKey" 
                                        FilterControlAltText="Filter FileCategoryKey column" 
                                        HeaderText="FileCategoryKey" SortExpression="FileCategoryKey" 
                                        UniqueName="FileCategoryKey" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn CommandName="MyDel" ConfirmDialogType="RadWindow" 
                                        ConfirmText="確認是否刪除?" FilterControlAltText="Filter Delete column" Text="刪除" 
                                        UniqueName="Delete">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="iAutoKey" 
                                        FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                                        UniqueName="iAutoKey" Visible="False">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <editformsettings>
                                    <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                                    </editcolumn>
                                </editformsettings>
                            </mastertableview>
                            <filtermenu enableimagesprites="False">
                            </filtermenu>
                            <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
                            </headercontextmenu>
                        </telerik:RadGrid>
                        <asp:SqlDataSource ID="sdsTeachingMaterialGv" runat="server" 
                            
                    ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="SELECT * FROM [UPLOAD] where FileCategory = 'TeachingMaterial' and FileCategoryKey=@ID
and FileDeleted =0">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblClassId" DefaultValue="0" Name="ID" 
                                    PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
        </tr>
    </table>
    </div>
    <asp:Label ID="lblClassId" runat="server" Visible="False"></asp:Label>
    </form>
</body>
</html>

