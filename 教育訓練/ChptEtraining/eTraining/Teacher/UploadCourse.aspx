<%@ Page Title="上傳教材" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="UploadCourse.aspx.cs" Inherits="eTraining_Teacher_UploadCourse" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>上傳教材</h2>
    <table style="width:100%;">
        <tr>
            <td class="style1" colspan="2">
                年度：<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" AutoPostBack="True">
    </telerik:RadComboBox>
                <asp:CheckBox ID="cbMyClass" runat="server" AutoPostBack="True" Checked="True" 
                    oncheckedchanged="cbMyClass_CheckedChanged" Text="只顯示個人課程" />
                <br />
    <asp:SqlDataSource ID="sdsClassGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        
        
                    SelectCommand="SELECT class.*,c.sName as course_sname,cat.sName as category_sname  FROM [trTrainingDetailM] class join trCourse c on class.trCourse_sCode = c.sCode  join trCategory cat on class.sKey = cat.sCode  
where iYear = @iYear and bIsPublished =1
order by dDateA desc">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="iYear" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsMyClassGv" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                    onselecting="sdsMyClassGv_Selecting" SelectCommand="SELECT class.*,c.sName as course_sname,cat.sName as category_sname  FROM [trTrainingDetailM] class join trCourse c on class.trCourse_sCode = c.sCode  join trCategory cat on class.sKey = cat.sCode  
where iYear = @iYear and bIsPublished =1 and class.iAutoKey in 
(select act.iClassAutoKey from trAttendClassTeacher act join trTeacher t
 on act.sTeacherCode = t.sCode where t.sNobr = @nobr)
order by dDateA desc">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cbxYear" Name="iYear" 
                            PropertyName="SelectedValue" />
                        <asp:Parameter Name="nobr" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
        <telerik:RadGrid ID="gvCourseList" runat="server" Skin="Vista" CellSpacing="0" GridLines="None"
            HorizontalAlign="Center" DataSourceID="sdsMyClassGv" AutoGenerateColumns="False"
            OnItemDataBound="gvCourseList_ItemDataBound" Culture="zh-TW" 
                    onselectedindexchanged="gvCourseList_SelectedIndexChanged">
            <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsMyClassGv"
                AllowMultiColumnSorting="True" AllowPaging="True" AllowSorting="True">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn CommandName="Select" 
                        FilterControlAltText="Filter column column" Text="選擇" UniqueName="column">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                        HeaderText="開課代碼" ReadOnly="True" SortExpression="iAutoKey" 
                        UniqueName="iAutoKey" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" FilterControlAltText="Filter iYear column"
                        HeaderText="年度" SortExpression="iYear" UniqueName="iYear" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sTimeA" FilterControlAltText="Filter sTimeA column"
                        HeaderText="sTimeA" SortExpression="sTimeA" UniqueName="sTimeA" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sTimeD" FilterControlAltText="Filter sTimeD column"
                        HeaderText="sTimeD" SortExpression="sTimeD" UniqueName="sTimeD" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                        HeaderText="課程代碼" SortExpression="trCourse_sCode" 
                        UniqueName="trCourse_sCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="category_sname" FilterControlAltText="Filter category_sname column"
                        HeaderText="階層名稱" SortExpression="category_sname" UniqueName="category_sname">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="course_sname" FilterControlAltText="Filter course_sname column"
                        HeaderText="課程名稱" SortExpression="course_sname" UniqueName="course_sname">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                        HeaderText="梯次" SortExpression="iSession" UniqueName="iSession">
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="bIsPublished" DataType="System.Boolean" FilterControlAltText="Filter bIsPublished column"
                        HeaderText="發佈" SortExpression="bIsPublished" UniqueName="bIsPublished" 
                        Visible="False">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="sKey" FilterControlAltText="Filter sKey column"
                        HeaderText="sKey" SortExpression="sKey" UniqueName="sKey" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateA" DataType="System.DateTime" FilterControlAltText="Filter dDateA column"
                        HeaderText="上課日期" SortExpression="dDateA" UniqueName="dDateA" 
                        DataFormatString="{0:d}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateD" DataType="System.DateTime" FilterControlAltText="Filter dDateD column"
                        HeaderText="結束日" SortExpression="dDateD" UniqueName="dDateD" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="trTeacher_sCode" FilterControlAltText="Filter trTeacher_sCode column"
                        HeaderText="trTeacher_sCode" SortExpression="trTeacher_sCode" UniqueName="trTeacher_sCode"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="trClassroom_sCode" FilterControlAltText="Filter trClassroom_sCode column"
                        HeaderText="trClassroom_sCode" SortExpression="trClassroom_sCode" UniqueName="trClassroom_sCode"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="bWebJoin" DataType="System.Boolean" FilterControlAltText="Filter bWebJoin column"
                        HeaderText="網路報名" SortExpression="bWebJoin" UniqueName="bWebJoin" Visible="False">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="dWebJoinDateB" DataType="System.DateTime" FilterControlAltText="Filter dWebJoinDateB column"
                        HeaderText="dWebJoinDateB" SortExpression="dWebJoinDateB" UniqueName="dWebJoinDateB"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dWebJoinDateE" DataType="System.DateTime" FilterControlAltText="Filter dWebJoinDateE column"
                        HeaderText="dWebJoinDateE" SortExpression="dWebJoinDateE" UniqueName="dWebJoinDateE"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sKeyMan" FilterControlAltText="Filter sKeyMan column"
                        HeaderText="sKeyMan" SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                        HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iUpLimitP" DataType="System.Int32" FilterControlAltText="Filter iUpLimitP column"
                        HeaderText="iUpLimitP" SortExpression="iUpLimitP" UniqueName="iUpLimitP" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iLowLimitP" DataType="System.Int32" FilterControlAltText="Filter iLowLimitP column"
                        HeaderText="iLowLimitP" SortExpression="iLowLimitP" UniqueName="iLowLimitP" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iYearPlanAutoKey" DataType="System.Int32" FilterControlAltText="Filter iYearPlanAutoKey column"
                        HeaderText="計畫編號" SortExpression="iYearPlanAutoKey" 
                        UniqueName="iYearPlanAutoKey" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateTimeA" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column"
                        HeaderText="上課時間" SortExpression="dDateTimeA" UniqueName="dDateTimeA" 
                        DataFormatString="{0:HH:mm}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateTimeD" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeD column"
                        HeaderText="dDateTimeD" SortExpression="dDateTimeD" UniqueName="dDateTimeD" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                        UniqueName="TemplateColumn" Visible="False">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlSetClass" runat="server" NavigateUrl="~/eTraining/Admin/Do/SetCourseDo.aspx">設定</asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
            </HeaderContextMenu>
        </telerik:RadGrid>
            </td>
        </tr>
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
                                <asp:ControlParameter ControlID="gvCourseList" DefaultValue="0" Name="ID" 
                                    PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
        </tr>
    </table>
</asp:Content>

