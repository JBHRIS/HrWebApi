<%@ Page Title="套裝課程設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SerialCourse.aspx.cs" Inherits="eTraining_Admin_Plan_SerialCourse" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">

        .RadListBox
        {
        	display: inline-block;
        }
        .RadListBox { float: none; }

.RadListBox { float: left; }
.RadListBox
{
	position: relative;
    vertical-align: top;
    display: block;
    display: inline-block;
    *display: inline;	
    zoom:1;
	width: 140px;
}

        .RadListBox
        {
        	display: inline-block;
        }
        .RadListBox { float: none; }

.RadListBox { float: left; }
.RadListBox
{
	position: relative;
    vertical-align: top;
    display: block;
    display: inline-block;
    *display: inline;	
    zoom:1;
	width: 140px;
}

        .RadListBox
        {
        	display: inline-block;
        }
        .RadListBox { float: none; }

.RadListBox { float: left; }
.RadListBox
{
	position: relative;
    vertical-align: top;
    display: block;
    display: inline-block;
    *display: inline;	
    zoom:1;
	width: 140px;
}

.RadListBox .rlbButtonAreaRight
{
	float: right;
}

.RadListBox .rlbButtonAreaRight
{
    -moz-user-select:-moz-none;
    -khtml-user-select:none;
}

.RadListBox .rlbButtonAreaRight
{
	float: right;
}

.RadListBox .rlbButtonAreaRight
{
    -moz-user-select:-moz-none;
    -khtml-user-select:none;
}

.RadListBox .rlbButtonAreaRight
{
	float: right;
}

.RadListBox .rlbButtonAreaRight
{
    -moz-user-select:-moz-none;
    -khtml-user-select:none;
}

        .RadListBox .rlbButtonAreaRight .rlbButton
        {
        	margin-left: 5px;
        	margin-right: 0;
        }
        .RadListBox .rlbButtonAreaRight .rlbButton
        {
        	margin-left: 5px;
        	margin-right: 0;
        }
        .RadListBox .rlbButtonAreaRight .rlbButton
        {
        	margin-left: 5px;
        	margin-right: 0;
        }
        
.RadListBox .rlbButton
{
	direction: ltr;
}

.RadListBox .rlbDisabled
{
	cursor: default;
}

.RadListBox .rlbNoButtonText
{
	padding: 0;
    margin: 0 0 5px 6px;
}

.RadListBox .rlbButton
{
	display: block;
	width: auto;
	height: 21px;
	line-height: 15px;
	margin: 0 7px 5px 3px;
	padding-right: 5px;
	position: relative;
	text-decoration: none;
	cursor: pointer;
}

.RadListBox .rlbButton
{
	direction: ltr;
}

.RadListBox .rlbDisabled
{
	cursor: default;
}

.RadListBox .rlbNoButtonText
{
	padding: 0;
    margin: 0 0 5px 6px;
}

.RadListBox .rlbButton
{
	display: block;
	width: auto;
	height: 21px;
	line-height: 15px;
	margin: 0 7px 5px 3px;
	padding-right: 5px;
	position: relative;
	text-decoration: none;
	cursor: pointer;
}

.RadListBox .rlbButton
{
	direction: ltr;
}

.RadListBox .rlbDisabled
{
	cursor: default;
}

.RadListBox .rlbNoButtonText
{
	padding: 0;
    margin: 0 0 5px 6px;
}

.RadListBox .rlbButton
{
	display: block;
	width: auto;
	height: 21px;
	line-height: 15px;
	margin: 0 7px 5px 3px;
	padding-right: 5px;
	position: relative;
	text-decoration: none;
	cursor: pointer;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonBL
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonBL
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonBL
{
	width: 100%;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonBL
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonBL
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonBL
{
	width: 100%;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonBL
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonBL
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonBL
{
	width: 100%;
}

        .RadListBox .rlbButtonBL
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonBL
{
	top: 4px;
	right: 0;
	background-position: 0 100%;
}

.RadListBox .rlbButtonBL
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonBL
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonBL
{
	top: 4px;
	right: 0;
	background-position: 0 100%;
}

.RadListBox .rlbButtonBL
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonBL
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonBL
{
	top: 4px;
	right: 0;
	background-position: 0 100%;
}

.RadListBox .rlbButtonBL
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonBR
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonBR
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonBR
{
	width: 100%;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonBR
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonBR
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonBR
{
	width: 100%;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonBR
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonBR
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonBR
{
	width: 100%;
}

        .RadListBox .rlbButtonBR
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonBR
{
	right: -4px;
    display: table;
    display: inline-block;
	background-position: 100% 100%;
}

.RadListBox .rlbButtonBR
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonBR
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonBR
{
	right: -4px;
    display: table;
    display: inline-block;
	background-position: 100% 100%;
}

.RadListBox .rlbButtonBR
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonBR
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonBR
{
	right: -4px;
    display: table;
    display: inline-block;
	background-position: 100% 100%;
}

.RadListBox .rlbButtonBR
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonTR
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonTR
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonTR
{
	width: 100%;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonTR
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonTR
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonTR
{
	width: 100%;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonTR
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonTR
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonTR
{
	width: 100%;
}

        .RadListBox .rlbButtonTR
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonTR
{
	bottom: 4px;
	right: 0;
	overflow: visible;
	background-position: 100% 0;
}

.RadListBox .rlbButtonTR
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonTR
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonTR
{
	bottom: 4px;
	right: 0;
	overflow: visible;
	background-position: 100% 0;
}

.RadListBox .rlbButtonTR
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonTR
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonTR
{
	bottom: 4px;
	right: 0;
	overflow: visible;
	background-position: 100% 0;
}

.RadListBox .rlbButtonTR
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonTL
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonTL
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonTL
{
	width: 100%;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonTL
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonTL
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonTL
{
	width: 100%;
}

        .RadListBox .rlbButtonAreaRight .rlbButtonTL
        {
        	width: 100%;
        }
        
.RadListBox .rlbNoButtonText .rlbButtonTL
{
	width: auto;
}

.RadListBox .rlbButtonAreaRight .rlbButtonTL
{
	width: 100%;
}

        .RadListBox .rlbButtonTL
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonTL
{
	left: -4px;
	background-position: 0 0;
}

.RadListBox .rlbButtonTL
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonTL
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonTL
{
	left: -4px;
	background-position: 0 0;
}

.RadListBox .rlbButtonTL
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

        .RadListBox .rlbButtonTL
        {
        	display: block;
        	float: left;
        }
        
.RadListBox .rlbButtonTL
{
	left: -4px;
	background-position: 0 0;
}

.RadListBox .rlbButtonTL
{
    display: -moz-inline-block;
    display: inline-block;
	position: relative;
}

.RadListBox .rlbNoButtonText .rlbButtonText { font-size /*\**/: 12px \9 }

	.RadListBox .rlbNoButtonText .rlbButtonText { margin-top: 2px; height: 12px; }

.RadListBox .rlbNoButtonText .rlbButtonText
{
	padding-left: 18px;
    width: 0;
    font-size: 0;
}

.RadListBox .rlbNoButtonText .rlbButtonText { font-size /*\**/: 12px \9 }

	.RadListBox .rlbNoButtonText .rlbButtonText { margin-top: 2px; height: 12px; }

.RadListBox .rlbNoButtonText .rlbButtonText
{
	padding-left: 18px;
    width: 0;
    font-size: 0;
}

.RadListBox .rlbNoButtonText .rlbButtonText { font-size /*\**/: 12px \9 }

	.RadListBox .rlbNoButtonText .rlbButtonText { margin-top: 2px; height: 12px; }

.RadListBox .rlbNoButtonText .rlbButtonText
{
	padding-left: 18px;
    width: 0;
    font-size: 0;
}

        .RadListBox .rlbButtonText
        {
            overflow: hidden;
            line-height: 12px;
        	float: left;
       	}
        
.RadListBox .rlbButtonText
{
	position: relative;
    display: -moz-inline-box;
    display: inline-block;
	z-index: 1;
	padding-left: 20px;
	padding-top: 3px;
	line-height: 15px;
	background-color: transparent;
	text-align: left;
}
        .RadListBox .rlbButtonText
        {
            overflow: hidden;
            line-height: 12px;
        	float: left;
       	}
        
.RadListBox .rlbButtonText
{
	position: relative;
    display: -moz-inline-box;
    display: inline-block;
	z-index: 1;
	padding-left: 20px;
	padding-top: 3px;
	line-height: 15px;
	background-color: transparent;
	text-align: left;
}
        .RadListBox .rlbButtonText
        {
            overflow: hidden;
            line-height: 12px;
        	float: left;
       	}
        
.RadListBox .rlbButtonText
{
	position: relative;
    display: -moz-inline-box;
    display: inline-block;
	z-index: 1;
	padding-left: 20px;
	padding-top: 3px;
	line-height: 15px;
	background-color: transparent;
	text-align: left;
}
        .RadListBox .rlbGroup
        {
        	top: 0;
        	left: 0;
        	right: auto;
	        bottom: auto;
	        height: 100%;
        }
        
.RadListBoxScrollable .rlbGroupRight
{
	left: 0;
	right: 0;
	top: 0;
	bottom: 0;
	position: absolute;
}

.RadListBoxScrollable .rlbGroup
{
	overflow: auto;
}

.RadListBox .rlbGroup
{
    -moz-user-select:-moz-none;
    -khtml-user-select:none;
}

.RadListBox .rlbGroup
{
	outline: none;
}

        .RadListBox .rlbGroup
        {
        	top: 0;
        	left: 0;
        	right: auto;
	        bottom: auto;
	        height: 100%;
        }
        
.RadListBoxScrollable .rlbGroupRight
{
	left: 0;
	right: 0;
	top: 0;
	bottom: 0;
	position: absolute;
}

.RadListBoxScrollable .rlbGroup
{
	overflow: auto;
}

.RadListBox .rlbGroup
{
    -moz-user-select:-moz-none;
    -khtml-user-select:none;
}

.RadListBox .rlbGroup
{
	outline: none;
}

        .RadListBox .rlbGroup
        {
        	top: 0;
        	left: 0;
        	right: auto;
	        bottom: auto;
	        height: 100%;
        }
        
.RadListBoxScrollable .rlbGroupRight
{
	left: 0;
	right: 0;
	top: 0;
	bottom: 0;
	position: absolute;
}

.RadListBoxScrollable .rlbGroup
{
	overflow: auto;
}

.RadListBox .rlbGroup
{
    -moz-user-select:-moz-none;
    -khtml-user-select:none;
}

.RadListBox .rlbGroup
{
	outline: none;
}

.RadListBox .rlbList
{
    list-style: none outside;
    position: relative;
    margin: 0;
    padding: 0;
    height:100%;
}

.RadListBox .rlbList
{
    list-style: none outside;
    position: relative;
    margin: 0;
    padding: 0;
    height:100%;
}

.RadListBox .rlbList
{
    list-style: none outside;
    position: relative;
    margin: 0;
    padding: 0;
    height:100%;
}

        .RadListBox .rlbItem
        {
        	white-space: normal !important;
        }
        
.RadListBox .rlbItem
{
	cursor: default;
	padding: 2px 5px;
	white-space: nowrap;
}

        .RadListBox .rlbItem
        {
        	white-space: normal !important;
        }
        
.RadListBox .rlbItem
{
	cursor: default;
	padding: 2px 5px;
	white-space: nowrap;
}

        .RadListBox .rlbItem
        {
        	white-space: normal !important;
        }
        
.RadListBox .rlbItem
{
	cursor: default;
	padding: 2px 5px;
	white-space: nowrap;
}

.RadListBox .rlbText
{
	vertical-align: middle;
}

.RadListBox .rlbText
{
    display: inline;
	white-space: normal;
}

.RadListBox .rlbText
{
	vertical-align: middle;
}

.RadListBox .rlbText
{
    display: inline;
	white-space: normal;
}

.RadListBox .rlbText
{
	vertical-align: middle;
}

.RadListBox .rlbText
{
    display: inline;
	white-space: normal;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        套裝課程設定</h2>
    <p>
        &nbsp;<asp:Panel ID="pnSerialCourseView" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td valign="top">
                        <telerik:RadGrid ID="gv" runat="server" AllowPaging="True" AllowSorting="True" CellSpacing="0"
                            DataSourceID="sdsGv" GridLines="None" AutoGenerateColumns="False" OnItemDataBound="gv_ItemDataBound"
                            Skin="Windows7" Culture="zh-TW">
                            <MasterTableView AllowPaging="False" AllowSorting="False" DataKeyNames="sCode" DataSourceID="sdsGv">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column1 column"
                                        Text="選擇" UniqueName="column1">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                                        HeaderText="課程代碼" SortExpression="sCode" UniqueName="sCode">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                        HeaderText="套裝課程" SortExpression="sName" UniqueName="sName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="加入課程">
                                            </telerik:RadButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
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
                    </td>
                    <td valign="top">
                        <telerik:RadGrid ID="gvDetail" runat="server" CellSpacing="0" DataSourceID="sdsGvDetail"
                            GridLines="None" Skin="Windows7">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsGvDetail">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                                        HeaderText="內含課程代碼" SortExpression="sCode" UniqueName="sCode">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                        HeaderText="內含課程名稱" SortExpression="sName" UniqueName="sName">
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
                    </td>
                </tr>
            </table>
            <br />
            <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT * FROM [trCourse] where bIsSerialCourse =1"></asp:SqlDataSource>
            <asp:SqlDataSource ID="sdsGvDetail" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT c.* FROM trSerialCourse s join trCourse c on s.sCourseCode=c.sCode WHERE ([sSerialCourseCode] = @sCode)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="gv" DefaultValue="0" Name="sCode" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </asp:Panel>
        <asp:Panel ID="pnSerialCourserAdd" runat="server" Visible="False">
            <asp:Label ID="lblSerialCourseCode" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblSerialCourseName" runat="server" Font-Size="Medium" ForeColor="#99CCFF"></asp:Label>
            <br />
            <table class="style1">
                <tr>
                    <td align="left" valign="top" class="style1" style="margin-left: 40px">
                        所有課程<br />
                        <telerik:RadTreeView ID="tv" runat="server" CheckBoxes="True" CheckChildNodes="True">
                        </telerik:RadTreeView>
                        <br />
                        <telerik:RadButton ID="btnAddItem" runat="server" Text="加入" OnClick="btnAddItem_Click">
                        </telerik:RadButton>
                        <br />
                    </td>
                    <td class="style3">
                        <br />
                        <br />
                        <br />
                    </td>
                    <td align="left" valign="top">
                        已選課程項目<br />
                        <telerik:RadListBox ID="lbSelected" runat="server" AllowDelete="True" AllowReorder="True"
                            DataKeyField="iAutoKey" DataSourceID="sdsSelected" DataTextField="sName" DataValueField="sCourseCode"
                            EnableDragAndDrop="True" Skin="Vista" Style="top: 8px; left: 0px; height: 392px;
                            width: 200px">
                        </telerik:RadListBox>
                        <br />
                        <br />
                        <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="確定">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
                        </telerik:RadButton>
                        <asp:SqlDataSource ID="sdsSelected" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT s.*,c.sName FROM trSerialCourse s join trCourse c on s.sCourseCode =c.sCode  WHERE 
s.sSerialCourseCode = @sSerialCourseCode order by s.iOrder">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblSerialCourseCode" DefaultValue="0" Name="sSerialCourseCode"
                                    PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <p>
            &nbsp;</p>
</asp:Content>
