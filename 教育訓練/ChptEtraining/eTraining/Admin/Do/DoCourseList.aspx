<%@ Page Title="課程執行狀況" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="DoCourseList.aspx.cs" Inherits="eTraining_Admin_Do_DoCourseList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
        Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="pnlRequestStarted">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <script type="text/javascript">
                        //                function mngRequestStarted(ajaxManager, eventArgs) {
                        //                    if (eventArgs.EventTarget == "mngBtnExcel" || eventArgs.EventTarget == "mngBtnWord") {
                        //                        eventArgs.EnableAjax = false;
                        //                    }
                        //                }
                        function pnlRequestStarted(ajaxPanel, eventArgs) {
                            if (eventArgs.EventTarget == '<%= btnExcel.UniqueID %>') {
                                eventArgs.EnableAjax = false;
                            }
                        }
                        //                function gridRequestStart(grid, eventArgs) {
                        //                    if ((eventArgs.EventTarget.indexOf("gridBtnExcel") != -1) || (eventArgs.EventTarget.indexOf("gridBtnWord") != -1)) {
                        //                        eventArgs.EnableAjax = false;
                        //                    }
                        //                }
                    </script>
                    </telerik:RadCodeBlock>

    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        課程執行狀況</h2>
    <br />
    年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" AutoPostBack="True">
    </telerik:RadComboBox>
    <asp:SqlDataSource ID="sdsClassGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="SELECT class.*,c.sName as course_sname,cat.sName as category_sname,
(trCourse_sCode+' '+c.sName) as combineCourse,month(class.dDateA) as classMonth,
class.sKey+' '+ cat.sName as combineCategory,
(select COUNT(1) from UPLOAD ul where ul.FileCategory='TeachingMaterial' 
and ul.FileDeleted = 0
and ul.FileCategoryKey=CONVERT(varchar(50),class.iAutoKey)) as TeachingMaterialQty
FROM [trTrainingDetailM] class 
join trCourse c on class.trCourse_sCode = c.sCode  
left join trCategoryCourse cc on c.sCode = cc.sCourseCode
left join trCategory cat on cc.sCateCode = cat.sCode
where iYear = @iYear 
and bIsPublished =1 
order by dDateTimeA desc">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="iYear" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <telerik:RadButton ID="btnExcel" runat="server" onclick="btnExcel_Click" 
        Text="匯出Excel">
    </telerik:RadButton>
    <br />
    <br />
    <div>
        <telerik:RadGrid ID="gvCourseList" runat="server" Skin="Office2007" 
            CellSpacing="0" GridLines="None"
            HorizontalAlign="Center" DataSourceID="sdsClassGv" AutoGenerateColumns="False"
            OnItemDataBound="gvCourseList_ItemDataBound" Culture="zh-TW" 
            onitemcommand="gvCourseList_ItemCommand" 
            onitemcreated="gvCourseList_ItemCreated">
<ClientSettings>
<Selecting CellSelectionMode="None"></Selecting>
</ClientSettings>

            <AlternatingItemStyle BackColor="#E8F3FF" />

            <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsClassGv" AllowFilteringByColumn="True"
                AllowMultiColumnSorting="True" AllowPaging="True" AllowSorting="True" 
                PageSize="25">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="combineCategory" FilterControlAltText="Filter combineCategory column"
                        HeaderText="階層" UniqueName="combineCategory">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="category_sname" FilterControlAltText="Filter category_sname column"
                        HeaderText="階層" SortExpression="category_sname" UniqueName="category_sname" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="combineCourse" FilterControlAltText="Filter combineCourse column"
                        HeaderText="課程名稱" UniqueName="combineCourse">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                        HeaderText="課程代碼" SortExpression="trCourse_sCode" UniqueName="trCourse_sCode"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="course_sname" FilterControlAltText="Filter course_sname column"
                        HeaderText="課程名稱" SortExpression="course_sname" UniqueName="course_sname" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sTimeA" FilterControlAltText="Filter sTimeA column"
                        HeaderText="sTimeA" SortExpression="sTimeA" UniqueName="sTimeA" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sTimeD" FilterControlAltText="Filter sTimeD column"
                        HeaderText="sTimeD" SortExpression="sTimeD" UniqueName="sTimeD" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                        HeaderText="梯次" SortExpression="iSession" UniqueName="iSession" AllowFiltering="False"
                        ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sKey" FilterControlAltText="Filter sKey column"
                        HeaderText="sKey" SortExpression="sKey" UniqueName="sKey" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="classMonth" FilterControlAltText="Filter classMonth column"
                        HeaderText="月份" UniqueName="classMonth" FilterControlWidth="15px">
                        <ItemStyle Width="15px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateA" DataType="System.DateTime" FilterControlAltText="Filter dDateA column"
                        HeaderText="開課日" SortExpression="dDateA" UniqueName="dDateA" DataFormatString="{0:d}"
                        AllowFiltering="False" ShowFilterIcon="False">
                        <ItemStyle Width="55px" />
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
                    <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                        HeaderText="開課代碼" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                        Visible="False">
                    </telerik:GridBoundColumn>
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
                    <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" FilterControlAltText="Filter iYear column"
                        HeaderText="年度" SortExpression="iYear" UniqueName="iYear" Visible="False">
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
                    <telerik:GridCheckBoxColumn DataField="bIsPublished" DataType="System.Boolean" FilterControlAltText="Filter bIsPublished column"
                        HeaderText="發佈" SortExpression="bIsPublished" UniqueName="bIsPublished" Visible="False">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="iYearPlanAutoKey" DataType="System.Int32" FilterControlAltText="Filter iYearPlanAutoKey column"
                        HeaderText="計畫課程" SortExpression="iYearPlanAutoKey" UniqueName="iYearPlanAutoKey"
                        EmptyDataText="" AllowFiltering="False" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateTimeA" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column"
                        HeaderText="dDateTimeA" SortExpression="dDateTimeA" UniqueName="dDateTimeA" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="dDateTimeD" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeD column"
                        HeaderText="dDateTimeD" SortExpression="dDateTimeD" UniqueName="dDateTimeD" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iStudentNum" FilterControlAltText="Filter iStudentNum column"
                        HeaderText="人數" UniqueName="iStudentNum" AllowFiltering="False" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn AllowFiltering="False" DataField="TeachingMaterialQty" 
                        FilterControlAltText="Filter TeachingMaterialQty column" HeaderText="教材數" 
                        ShowFilterIcon="False" UniqueName="TeachingMaterialQty">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iActualAMT" FilterControlAltText="Filter iActualAMT column"
                        HeaderText="實際費用" UniqueName="iActualAMT" AllowFiltering="False" ShowFilterIcon="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter set column" UniqueName="set"
                        AllowFiltering="False" ShowFilterIcon="False">
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
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </div>
    </telerik:RadAjaxPanel>
</asp:Content>
