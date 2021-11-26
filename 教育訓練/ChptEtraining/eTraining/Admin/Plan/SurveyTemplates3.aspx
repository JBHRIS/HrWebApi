<%@ Page Title="調查範本設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SurveyTemplates3.aspx.cs" Inherits="eTraining_Admin_Plan_SurveyTemplates3" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            $('.funcblock').corner("15px");
        </script>
        <%--        <script type="text/javascript">           
            function ShowEditForm(id, rowIndex) {
                var grid = $find("");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("trCategoryEdit.aspx?iAutoKey=" + id, "UserListDialog");
                return false;
            }
            function ShowInsertForm() {
                window.radopen("MustTrainingAdd.aspx", "UserListDialog");
                return false;
            }
            function ShowInsertFormByParam(pid) {
                window.radopen("SurveyTemplates1.aspx?code=" + pid, "UserListDialog");
                return false;
            }
            function ShowInsertFormByParam2(cat, course) {
                window.radopen("SurveyTemplates2.aspx?cat=" + cat + "&course=" + course, "UserListDialog");
                return false;
            }
            function ShowCourseFormByParam(pid, mode) {
                window.radopen("trCourseEdit.aspx?pid=" + pid + "&m=" + mode, "UserListDialog2");
                return false;
            }
            function refreshGridTplCatDetail(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindTplCatDetail");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindTplCatDetail");
                }
            }
            function refreshCatDetail(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindCatDetail");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindCatDetail");
                }
            }
            function refreshFV(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindFV");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindFV");
                }
            }
            function RowDblClick(sender, eventArgs) {
                window.radopen("trTeacherEdit.aspx?iAutoKey=" + eventArgs.getDataKeyValue("iAutoKey"), "UserListDialog");
            }
        </script>--%>
    </telerik:RadCodeBlock>
    <h2>
        調查範本設定
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <div>
            <%--          <div style="float: left; width: 20%">--%>
            <div>
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                    SelectedIndex="0" Skin="Office2007" AutoPostBack="True" OnTabClick="RadTabStrip1_TabClick"
                    ShowBaseLine="True">
                    <Tabs>
                        <telerik:RadTab runat="server" Text="新增調查範本" PageViewID="RadPageView1" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" PageViewID="RadPageView5" Text="檢示調查範本">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </div>
            <%--<div style="float: right; width: 80%">--%>
            <div>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" Width="100%"
                    RenderSelectedPageOnly="True">
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <div style="background-color: #EBF5FF; width: 100%" class="funcblock">
                            <br />
                            &nbsp;&nbsp;&nbsp; 範本名稱<telerik:RadTextBox ID="tbTplName" runat="server">
                            </telerik:RadTextBox>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <telerik:RadButton ID="btnTplAdd" runat="server" OnClick="btnTplAdd_Click" Text="新增">
                            </telerik:RadButton>
                            &nbsp;&nbsp;&nbsp;
                            <br />
                            &nbsp;&nbsp;
                            <telerik:RadGrid ID="gvTemplate" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                GridLines="None" Skin="Windows7" Culture="zh-TW" OnItemCommand="gvTemplate_ItemCommand"
                                OnNeedDataSource="gvTemplate_NeedDataSource">
                                <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey">
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
                                        <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                                            HeaderText="範本代碼" SortExpression="sCode" UniqueName="sCode" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                            HeaderText="範本名稱" SortExpression="sName" UniqueName="sName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn CommandName="cmdEditCourse" FilterControlAltText="Filter cmdEditCourse column"
                                            Text="編輯課程" UniqueName="cmdEditCourse">
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Windows7">
                                </HeaderContextMenu>
                            </telerik:RadGrid>
                            &nbsp;<asp:Label ID="lblSelectedTplCode" runat="server" Visible="False"></asp:Label>
                            &nbsp;<asp:Panel ID="pnlCourse" runat="server" Visible="False">
                                <table>
                                    <tr>
                                        <td align="left" valign="top">
                                            <telerik:RadTreeView ID="tvCourse" runat="server" MultipleSelect="True">
                                            </telerik:RadTreeView>
                                        </td>
                                        <td align="center" valign="top">
                                            <asp:Button ID="btnAddCourse" runat="server" Text="新增" Height="300px" OnClick="btnAddCourse_Click" />
                                        </td>
                                        <td align="left" valign="top">
                                            <telerik:RadListBox ID="lbCourse" runat="server" AllowReorder="True" 
                                                AllowDelete="True">
                                            </telerik:RadListBox>
                                            <telerik:RadButton ID="btnSaveCourse" runat="server" Text="儲存" OnClick="btnSaveCourse_Click">
                                            </telerik:RadButton>
                                            <telerik:RadButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <br />
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView5" runat="server">
                        選擇範本<telerik:RadComboBox ID="cbTplView" runat="server" AutoPostBack="True" DataSourceID="sdsCbTpl"
                            DataTextField="sName" DataValueField="sCode" OnSelectedIndexChanged="cbTplView_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Owner="cbTplView" Text="主管調查樣版" Value="主管調查樣版" />
                                <telerik:RadComboBoxItem runat="server" Owner="cbTplView" Text="員工調查樣版" Value="員工調查樣版" />
                            </Items>
                        </telerik:RadComboBox>
                        <telerik:RadGrid ID="gvtrRequirementTemplateCourse" runat="server" CellSpacing="0"
                            GridLines="None" Skin="Windows7" Culture="zh-TW" 
                            OnNeedDataSource="gvtrRequirementTemplateCourse_NeedDataSource" 
                            AutoGenerateColumns="False" 
                            onitemcommand="gvtrRequirementTemplateCourse_ItemCommand" 
                            onselectedindexchanged="gvtrRequirementTemplateCourse_SelectedIndexChanged">
                            <MasterTableView DataKeyNames="Id">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" 
                                        HeaderText="Id" UniqueName="Id" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn CommandName="Select" 
                                        FilterControlAltText="Filter cmdSelect column" Text="選擇" UniqueName="cmdSelect">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="CourseCode" 
                                        FilterControlAltText="Filter CourseCode column" HeaderText="CourseCode" 
                                        UniqueName="CourseCode" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CourseName" 
                                        FilterControlAltText="Filter CourseName column" HeaderText="課程名稱" 
                                        UniqueName="CourseName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Budget" 
                                        FilterControlAltText="Filter Budget column" HeaderText="外訓課程預估費用/位" 
                                        UniqueName="Budget">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Sequence" 
                                        FilterControlAltText="Filter Sequence column" HeaderText="順序" 
                                        UniqueName="Sequence">
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
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </div>
        </div>

        <telerik:RadWindow ID="win" runat="server" Modal="True">

            <ContentTemplate>
                預算金額<telerik:RadNumericTextBox ID="ntbBudget" Runat="server" 
                    DataType="System.Int32" MinValue="0">
                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                </telerik:RadNumericTextBox>
                <telerik:RadButton ID="btnBudgetSave" runat="server" 
                    onclick="btnBudgetSave_Click" Text="儲存">
                </telerik:RadButton>
            </ContentTemplate>

        </telerik:RadWindow>

        <asp:SqlDataSource ID="sdsCbTpl" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            DeleteCommand="delete  [trRequirementTemplate] where iAutoKey=@iAutoKey" SelectCommand="SELECT * FROM [trRequirementTemplate]">
            <DeleteParameters>
                <asp:Parameter DefaultValue="0" Name="iAutoKey" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </telerik:RadAjaxPanel>
</asp:Content>
