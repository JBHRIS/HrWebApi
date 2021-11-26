<%@ Page Title="查詢學習紀綠" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ViewAllLearinig.aspx.cs" Inherits="eTraining_Admin_ViewAllLearinig" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../UC/UserQuickSearch.ascx" TagName="UserQuickSearch" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
    <h2>
        查詢學習紀綠<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
            IsSticky="True" Skin="Windows7">
        </telerik:RadAjaxLoadingPanel>
    </h2>
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



        <div style="background-color: #CDE5FF; float: left; width: 24%" class="funcblock">
            <br />
            年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" 
                OnSelectedIndexChanged="cbxYear_SelectedIndexChanged" AutoPostBack="True">
            </telerik:RadComboBox>
            <uc1:UserQuickSearch ID="UserQuickSearch1" runat="server" />
            <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblSearchBy" runat="server" Visible="False"></asp:Label>
            <br />
            <telerik:RadTreeView ID="tvDept" runat="server" OnNodeClick="tvDept_NodeClick">
            </telerik:RadTreeView>
            <br />
        </div>
        <div style="float: right; width: 75%">
            <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出" Skin="Windows7" 
                onclick="btnExportExcel_Click">
            </telerik:RadButton>
            <telerik:RadGrid ID="gv" runat="server" Skin="Outlook" Culture="zh-TW"
                CellSpacing="0" GridLines="None" onneeddatasource="gv_NeedDataSource" 
                AllowSorting="True" AllowPaging="True" onitemcreated="gv_ItemCreated" 
                onexportcellformatting="gv_ExportCellFormatting">
                <MasterTableView AutoGenerateColumns="False" AllowFilteringByColumn="True" 
                    PageSize="20" DataKeyNames="Nobr">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn AllowFiltering="False" DataField="Nobr" FilterControlAltText="Filter NOBR column"
                            HeaderText="工號" UniqueName="Nobr">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Name_C" FilterControlAltText="Filter NAME_C column"
                            HeaderText="姓名" SortExpression="NAME_C" UniqueName="Name_C" 
                            FilterControlWidth="40px">
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DeptName" 
                            FilterControlAltText="Filter D_NAME column" FilterControlWidth="40px" 
                            HeaderText="部門" UniqueName="DeptName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CateCode" FilterControlAltText="Filter CateCode column"
                            HeaderText="階層代碼" SortExpression="sCode" UniqueName="CateCode" 
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CateName" FilterControlAltText="Filter CateName column"
                            HeaderText="階層" SortExpression="sName" UniqueName="CateName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CourseCode" FilterControlAltText="Filter CourseCode column"
                            HeaderText="課程代碼" SortExpression="sCode1" UniqueName="CourseCode" 
                            FilterControlWidth="40px">
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter CourseName column"
                            HeaderText="課程" SortExpression="sName1" UniqueName="CourseName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Session" DataType="System.Int32" FilterControlAltText="Filter iSession column"
                            HeaderText="梯次" SortExpression="iSession" UniqueName="iSession" AllowFiltering="False"
                            FilterControlWidth="30px">
                            <HeaderStyle Width="25px" />
                            <ItemStyle Width="25px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CourseAdate" DataType="System.DateTime" FilterControlAltText="Filter dDateA column"
                            HeaderText="修課日期" SortExpression="dDateA" UniqueName="CourseAdate" DataFormatString="{0:d}"
                            FilterControlWidth="40px">
                            <HeaderStyle Width="70px" />
                            <ItemStyle Width="70px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="Pass" 
                            FilterControlAltText="Filter Pass column" HeaderText="通過" ReadOnly="True" 
                            UniqueName="Pass">
                        </telerik:GridCheckBoxColumn>
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
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Outlook">
                    <WebServiceSettings>
                        <ODataSettings InitialContainerName="">
                        </ODataSettings>
                    </WebServiceSettings>
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
