<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="DesignCourseList.aspx.cs" Inherits="eTraining_Admin_Design_DesignCourseList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                Skin="Default">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
                    width="100%">
                
            
    <asp:Panel ID="palCourse" runat="server" Width="100%">
        <h2>
            課表排定
        </h2>
        <br />
        開課年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" AutoPostBack="True">
        </telerik:RadComboBox>
        <br />
        <br />
        
        <div class="field">
            <fieldset>
                <legend>開新課程</legend>&nbsp;<asp:RadioButton ID="rbtnPlanCourse" runat="server" Text="年度計劃課程"
                    Checked="True" GroupName="course" />
                &nbsp;<asp:RadioButton ID="rbtnNPlanCourse" runat="server" Text="手動開課" GroupName="course" />
                &nbsp;&nbsp; &nbsp;
                <telerik:RadButton ID="btnCourse" runat="server" OnClick="btnCourse_Click" Skin="Windows7"
                    Text="開課">
                </telerik:RadButton>
                <br />
                &nbsp;&nbsp;
            </fieldset>
         </div>
            <br />
            <asp:SqlDataSource ID="sdsClassGv" runat="server" 
            ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="SELECT class.*,c.sName as course_sname,cat.sName as category_sname,month(class.dDateA) as classMonth,
(trCourse_sCode+' '+c.sName) as combineCourse,
class.sKey+' '+ cat.sName as combineCategory FROM [trTrainingDetailM] class 
join trCourse c on class.trCourse_sCode = c.sCode  
left join trCategoryCourse cc on c.sCode = cc.sCourseCode
left join trCategory cat on cc.sCateCode = cat.sCode
where iYear = @iYear
order by class.iAutoKey desc">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="iYear" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
        </asp:SqlDataSource>
            <telerik:RadGrid ID="gvCourseList" runat="server" 
            AutoGenerateColumns="False" CellSpacing="0"
                Culture="zh-TW" GridLines="None" HorizontalAlign="Center"
                OnItemDataBound="gvCourseList_ItemDataBound" Skin="Vista" Width="100%" 
            ondeletecommand="gvCourseList_DeleteCommand" 
            onitemcommand="gvCourseList_ItemCommand" 
            onneeddatasource="gvCourseList_NeedDataSource">
                <AlternatingItemStyle BackColor="#E8F3FF" />
                <MasterTableView AllowFilteringByColumn="True" AllowMultiColumnSorting="True" AllowPaging="True"
                    AllowSorting="True" DataKeyNames="iAutoKey" PageSize="20">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                            HeaderText="開課代碼" ReadOnly="True" SortExpression="iAutoKey" 
                            UniqueName="iAutoKey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" FilterControlAltText="Filter iYear column"
                            HeaderText="年度" SortExpression="iYear" UniqueName="iYear" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="combineCategory" 
                            FilterControlAltText="Filter combineCategory column" HeaderText="階層名稱" 
                            UniqueName="combineCategory">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="category_sname" 
                            FilterControlAltText="Filter category_sname column" HeaderText="階層名稱" 
                            SortExpression="category_sname" UniqueName="category_sname" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="combineCourse" 
                            FilterControlAltText="Filter combineCourse column" HeaderText="課程名稱" 
                            UniqueName="combineCourse" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="course_sname" 
                            FilterControlAltText="Filter course_sname column" HeaderText="課程名稱" 
                            SortExpression="course_sname" UniqueName="course_sname">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trCourse_sCode" 
                            FilterControlAltText="Filter trCourse_sCode column" HeaderText="課程代碼" 
                            SortExpression="trCourse_sCode" UniqueName="trCourse_sCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                            HeaderText="梯次" SortExpression="iSession" UniqueName="iSession" 
                            AllowFiltering="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sKey" FilterControlAltText="Filter sKey column"
                            HeaderText="sKey" SortExpression="sKey" UniqueName="sKey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="classMonth" 
                            FilterControlAltText="Filter classMonth column" HeaderText="月份" 
                            UniqueName="classMonth" FilterControlWidth="15px">
                            <HeaderStyle Width="20px" />
                            <ItemStyle Width="15px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dDateA" DataType="System.DateTime" FilterControlAltText="Filter dDateA column"
                            HeaderText="開課日" SortExpression="dDateA" UniqueName="dDateA" 
                            DataFormatString="{0:d}" FilterControlWidth="25px">
                            <HeaderStyle Width="25px" />
                            <ItemStyle Width="25px" />
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
                        <telerik:GridBoundColumn DataField="iUpLimitP" DataType="System.Int32" FilterControlAltText="Filter iUpLimitP column"
                            HeaderText="iUpLimitP" SortExpression="iUpLimitP" UniqueName="iUpLimitP" 
                            Visible="False" AllowFiltering="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iLowLimitP" DataType="System.Int32" FilterControlAltText="Filter iLowLimitP column"
                            HeaderText="iLowLimitP" SortExpression="iLowLimitP" 
                            UniqueName="iLowLimitP" Visible="False" AllowFiltering="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bIsPublished" DataType="System.Boolean" FilterControlAltText="Filter bIsPublished column"
                            HeaderText="發佈" SortExpression="bIsPublished" UniqueName="bIsPublished" 
                            ShowFilterIcon="False">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="iYearPlanAutoKey" DataType="System.Int32" FilterControlAltText="Filter iYearPlanAutoKey column"
                            HeaderText="計畫課程" SortExpression="iYearPlanAutoKey" 
                            UniqueName="iYearPlanAutoKey" EmptyDataText="" AllowFiltering="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dDateTimeA" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeA column"
                            HeaderText="dDateTimeA" SortExpression="dDateTimeA" UniqueName="dDateTimeA" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dDateTimeD" DataType="System.DateTime" FilterControlAltText="Filter dDateTimeD column"
                            HeaderText="dDateTimeD" SortExpression="dDateTimeD" UniqueName="dDateTimeD" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iEstimateAMT" 
                            FilterControlAltText="Filter iEstimateAMT column" HeaderText="預估費用" 
                            UniqueName="iEstimateAMT" AllowFiltering="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iStudentNum" 
                            FilterControlAltText="Filter iStudentNum column" HeaderText="人數" 
                            UniqueName="iStudentNum" AllowFiltering="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter set column" 
                            UniqueName="set" AllowFiltering="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlSetClass" runat="server" 
                                    NavigateUrl="~/eTraining/Admin/Design/SetCourse.aspx">設定</asp:HyperLink>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridButtonColumn CommandName="Delete" 
                            FilterControlAltText="Filter Delete column" Text="刪除" UniqueName="Delete">
                        </telerik:GridButtonColumn>
                        <telerik:GridTemplateColumn AllowFiltering="False" 
                            FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink2" runat="server" 
                                    NavigateUrl="~/eTraining/Admin/Do/CourseInfoD.aspx">詳細</asp:HyperLink>
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
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Vista">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </HeaderContextMenu>
            </telerik:RadGrid>
        
    </asp:Panel>
    <asp:Panel ID="palNPlanCourse" runat="server" Visible="False">
        <h2>
            手動開課</h2>
        <br />
        <telerik:RadButton ID="btnNPlanAdd1" runat="server" Skin="Windows7" Text="加入開課清單"
            OnClick="btnClassAdd_Click" style="top: 2px; left: 0px">
        </telerik:RadButton>
        &nbsp;&nbsp;
        <telerik:RadButton ID="btnCancel" runat="server" OnClick="RadButton1_Click" Skin="Windows7"
            Text="取消">
        </telerik:RadButton>
        <br />
        <br />
        <div style="width: 35%; background-color: #CDE5FF" class="funcblock">
            <br />
            <telerik:RadButton ID="btnExpand" runat="server" Text="展開" GroupName="expand" OnClick="btnExpand_Click">
            </telerik:RadButton>
            <br />
            <telerik:RadTreeView ID="tv" runat="server" OnPreRender="tv_PreRender">
            </telerik:RadTreeView>
            <br />
        </div>
        <br />
        <telerik:RadButton ID="btnClassAdd" runat="server" OnClick="btnClassAdd_Click" Skin="Windows7"
            Text="加入開課清單">
        </telerik:RadButton>
        &nbsp;&nbsp;
        <telerik:RadButton ID="btnCancel1" runat="server" OnClick="RadButton1_Click" Skin="Windows7"
            Text="取消">
        </telerik:RadButton>
    </asp:Panel>
    <br />
    <asp:Panel ID="palPlanCourse" runat="server" Visible="False">
        <h2>
            年度計劃課程清單</h2>
        <br />
        年度<telerik:RadComboBox ID="cbxPlanYear" runat="server" Width="70px" Style="margin-bottom: 0px"
            AutoPostBack="True">
        </telerik:RadComboBox>
        <br />
        <asp:SqlDataSource ID="sdsYearPlanGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            DeleteCommand="DELETE FROM [trTrainingPlanDetail] WHERE [iAutoKey] = @iAutoKey"
            SelectCommand="select dtl.*,cat.sName as catsName,c.sName as csName,cat.sCode as trCategory_sCode,c.sCode as courseCode from trTrainingPlanDetail dtl left join 
trCategory cat on dtl.sKey = cat.sCode left join 
trCourse c on dtl.trCourse_sCode = c.sCode 
 WHERE (dtl.iYear = @iYear)
and dtl.iClassAutoKey is null" UpdateCommand="UPDATE [trTrainingPlanDetail] SET [iYear] = @iYear, 
[iSession] = @iSession, [iMonth] = @iMonth, 
[trCourse_sCode] = @trCourse_sCode, [sKey] = @sKey, 
[iHours] = @iHours, [iNumOfPeople] = @iNumOfPeople, 
[iAmt] = @iAmt, [sPersonInCharge] = @sPersonInCharge, 
[sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate 
WHERE [iAutoKey] = @iAutoKey">
            <DeleteParameters>
                <asp:Parameter Name="iAutoKey" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="cbxPlanYear" DefaultValue="0" Name="iYear" PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="iYear" />
                <asp:Parameter Name="iSession" />
                <asp:Parameter Name="iMonth" />
                <asp:Parameter Name="trCourse_sCode" />
                <asp:Parameter Name="sKey" />
                <asp:Parameter Name="iHours" />
                <asp:Parameter Name="iNumOfPeople" />
                <asp:Parameter Name="iAmt" />
                <asp:Parameter Name="sPersonInCharge" />
                <asp:Parameter Name="sKeyMan" />
                <asp:Parameter Name="dKeyDate" />
                <asp:Parameter Name="iAutoKey" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <telerik:RadGrid ID="gvYearPlan" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" GridLines="None" OnItemDataBound="gvYearPlan_ItemDataBound"
            Skin="Outlook" AllowMultiRowSelection="True" AllowFilteringByColumn="True" 
            AllowSorting="True" Culture="zh-TW" 
            onneeddatasource="gvYearPlan_NeedDataSource">
            <ClientSettings>
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
            </ClientSettings>
            <AlternatingItemStyle BackColor="#D0E8FF" />
            <MasterTableView DataKeyNames="iAutokey" AllowPaging="True" PageSize="20">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridClientSelectColumn FilterControlAltText="Filter cbx_select column" UniqueName="cbx_select">
                    </telerik:GridClientSelectColumn>
                    <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" FilterControlAltText="Filter iYear column"
                        HeaderText="年度" SortExpression="iYear" UniqueName="iYear">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iMonth" DataType="System.Int32" FilterControlAltText="Filter iMonth column"
                        HeaderText="月份" SortExpression="iMonth" UniqueName="iMonth">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="trCategory_sCode" 
                        FilterControlAltText="Filter trCategory_sCode column" HeaderText="階層代碼" 
                        SortExpression="trCategory_sCode" UniqueName="trCategory_sCode">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="catsName" 
                        FilterControlAltText="Filter catsName column" HeaderText="階層" 
                        SortExpression="catsName" UniqueName="catsName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="courseCode" 
                        FilterControlAltText="Filter courseCode column" HeaderText="課程代碼" 
                        SortExpression="courseCode" UniqueName="courseCode">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="csName" FilterControlAltText="Filter csName column"
                        HeaderText="課程名稱" SortExpression="csName" UniqueName="csName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iHours" FilterControlAltText="Filter iHours column"
                        HeaderText="時數" SortExpression="iHours" UniqueName="iHours" 
                        DataType="System.Decimal" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iNumOfPeople" DataType="System.Int32" FilterControlAltText="Filter iNumOfPeople column"
                        HeaderText="人數" SortExpression="iNumOfPeople" UniqueName="iNumOfPeople" 
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iAmt" DataType="System.Int32" FilterControlAltText="Filter iAmt column"
                        HeaderText="預估費用" SortExpression="iAmt" UniqueName="iAmt" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn DataField="iClassAutoKey" FilterControlAltText="Filter iClassAutoKey column"
                        HeaderText="開課編號" UniqueName="iClassAutoKey" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="iClassAutoKeyTextBox" runat="server" Text='<%# Bind("iClassAutoKey") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="iClassAutoKeyLabel" runat="server" Text='<%# Eval("iClassAutoKey") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                        UniqueName="iAutoKey" Visible="False">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
                <AlternatingItemStyle BackColor="#E8F3FF" />
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
        <br />
        <br />
        <telerik:RadButton ID="btnPlanAdd" runat="server" OnClick="btnNPlanAdd_Click" Skin="Windows7"
            Text="加入開課清單">
        </telerik:RadButton>
        &nbsp;&nbsp;
        <telerik:RadButton ID="btnCanelP" runat="server" OnClick="btnCanelP_Click" Skin="Windows7"
            Text="取消">
        </telerik:RadButton>
        <br />
    </asp:Panel>
    </telerik:RadAjaxPanel>
</asp:Content>
