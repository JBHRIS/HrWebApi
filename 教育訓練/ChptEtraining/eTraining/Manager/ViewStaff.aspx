<%@ Page Title="查詢員工上課記錄" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ViewStaff.aspx.cs" Inherits="eTraining_Manager_ViewStaff" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" ClientEvents-OnRequestStart="pnlRequestStarted"
        Width="100%">
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                //                function mngRequestStarted(ajaxManager, eventArgs) {
                //                    if (eventArgs.EventTarget == "mngBtnExcel" || eventArgs.EventTarget == "mngBtnWord") {
                //                        eventArgs.EnableAjax = false;
                //                    }
                //                }
                function pnlRequestStarted(ajaxPanel, eventArgs) {
                    if (eventArgs.EventTarget == '<%= btnExportExcel.UniqueID %>') {
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
        <h2>
            查詢員工上課記錄</h2>
        <asp:SqlDataSource ID="sdsName" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            SelectCommand="select dt.D_NAME,ba.NOBR,ba.NAME_C from BASETTS bt
join DEPT dt on bt.DEPT=dt.D_NO
join BASE ba on bt.NOBR=ba.NOBR
where bt.TTSCODE in ('1','4','6')
and CONVERT(varchar(10), GETDATE(),111) between bt.ADATE and bt.DDATE
and dt.D_NO=@Dept
and bt.NOBR&lt;&gt;@Manage">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblLoginDept" DefaultValue="0" Name="Dept" PropertyName="Text" />
                <asp:Parameter Name="Manage" />
            </SelectParameters>
        </asp:SqlDataSource>
        <telerik:RadWindow ID="win" runat="server" Height="550px" Modal="True" VisibleStatusbar="False"
            Width="800px">
        </telerik:RadWindow>
        <div style="float: left; width: 30%">
            <telerik:RadGrid ID="gvEmp" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                Culture="zh-TW" GridLines="None" OnSelectedIndexChanged="gvEmp_SelectedIndexChanged"
                Skin="Outlook" AllowFilteringByColumn="True" AllowSorting="True" 
                AllowPaging="True" Font-Size="Small" onneeddatasource="gvEmp_NeedDataSource" 
                PageSize="20">
                <MasterTableView DataKeyNames="NOBR">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                            Text="選擇" UniqueName="Select">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="NOBR" FilterControlAltText="Filter NOBR column"
                            HeaderText="工號" SortExpression="NOBR" UniqueName="NOBR" 
                            FilterControlWidth="20px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C" 
                            FilterControlWidth="20px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                            HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME" 
                            FilterControlWidth="20px">
                        </telerik:GridBoundColumn>
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
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <div style="float: right; width: 70%">
            <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" Skin="Black" OnClick="btnExportExcel_Click">
            </telerik:RadButton>
            <telerik:RadGrid ID="gvEmpData" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                Culture="zh-TW" GridLines="None" Skin="Windows7" AllowFilteringByColumn="True"
                AllowSorting="True" OnItemCreated="gvEmpData_ItemCreated" OnExportCellFormatting="gvEmpData_ExportCellFormatting"
                OnNeedDataSource="gvEmpData_NeedDataSource" OnItemCommand="gvEmpData_ItemCommand"
                OnItemDataBound="gvEmpData_ItemDataBound">
                <MasterTableView DataKeyNames="iAutoKey">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn AllowFiltering="False" DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" UniqueName="NAME_C" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="categoryName" FilterControlAltText="Filter categoryName column"
                            HeaderText="課程類別" SortExpression="categoryName" UniqueName="categoryName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                            HeaderText="課程名稱" SortExpression="courseName" UniqueName="courseName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn AllowFiltering="False" DataField="TrainingMethodName" FilterControlAltText="Filter TrainingMethodName column"
                            HeaderText="訓練別" UniqueName="TrainingMethodName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iSession" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                            HeaderText="梯次" SortExpression="iSession" UniqueName="iSession" FilterControlWidth="20px">
                            <HeaderStyle Width="20px" />
                            <ItemStyle Width="20px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" DataType="System.DateTime"
                            FilterControlAltText="Filter dDateA column" HeaderText="開課日期" SortExpression="dDateA"
                            UniqueName="dDateA" FilterControlWidth="50px">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bPass" DataType="System.Boolean" FilterControlAltText="Filter bPass column"
                            HeaderText="結訓" SortExpression="bPass" UniqueName="bPass">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                            HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                            HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNote1" FilterControlAltText="Filter sNote1 column"
                            HeaderText="sNote1" SortExpression="sNote1" UniqueName="sNote1" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sAbsenceNote" FilterControlAltText="Filter sAbsenceNote column"
                            HeaderText="sAbsenceNote" SortExpression="sAbsenceNote" UniqueName="sAbsenceNote"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="bAbsence" DataType="System.Boolean" FilterControlAltText="Filter bAbsence column"
                            HeaderText="bAbsence" SortExpression="bAbsence" UniqueName="bAbsence" Visible="False">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="trCourse_sCode" FilterControlAltText="Filter trCourse_sCode column"
                            HeaderText="trCourse_sCode" SortExpression="trCourse_sCode" UniqueName="trCourse_sCode"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sNobr" FilterControlAltText="Filter sNobr column"
                            HeaderText="sNobr" SortExpression="sNobr" UniqueName="sNobr" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sDeptCode" FilterControlAltText="Filter sDeptCode column"
                            HeaderText="sDeptCode" SortExpression="sDeptCode" UniqueName="sDeptCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="ClassRpt" FilterControlAltText="Filter ClassRpt column"
                            Text="心得" UniqueName="ClassRpt">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="IsManagerScoreStudentClassReport" FilterControlAltText="Filter IsManagerScoreStudentClassReport column"
                            UniqueName="IsManagerScoreStudentClassReport" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="bIsNeedClassRpt" FilterControlAltText="Filter bIsNeedClassRpt column"
                            UniqueName="bIsNeedClassRpt" Visible="False">
                        </telerik:GridBoundColumn>
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
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <asp:Label ID="lblLoginDept" runat="server" Visible="False"></asp:Label>
        <br />
    </telerik:RadAjaxPanel>
</asp:Content>
