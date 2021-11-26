<%@ Page Title="調查範本設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SurveyTemplates2.aspx.cs" Inherits="eTraining_Admin_Plan_SurveyTemplates2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 { width: 100%; }
    </style>
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
    &nbsp;<h2>
        調查範本設定
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <div>
            <div style="float: left; width: 20%">
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                    SelectedIndex="0" Orientation="VerticalLeft" Skin="Office2007" AutoPostBack="True"
                    OnTabClick="RadTabStrip1_TabClick">
                    <Tabs>
                        <telerik:RadTab runat="server" Text="新增調查範本" PageViewID="RadPageView1" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="新增課程類別" Owner="RadTabStrip1" PageViewID="RadPageView3">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Owner="RadTabStrip1" PageViewID="RadPageView2" Text="加入調查範本類別">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" PageViewID="RadPageView5" Text="檢示調查範本">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </div>
            <div style="float: right; width: 80%">
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" Width="70%">
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <div style="background-color: #EBF5FF; width: 350px" class="funcblock">
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
                                DataSourceID="sdsCbTpl" GridLines="None" OnItemDeleted="gvTemplate_ItemDeleted"
                                Skin="Windows7" Culture="zh-TW">
                                <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey" DataSourceID="sdsCbTpl">
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
                                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" FilterControlAltText="Filter column column"
                                            UniqueName="column">
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
                            &nbsp;
                            <br />
                            <br />
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server">
                        <asp:Label ID="lblTplCat" runat="server" Visible="False"></asp:Label>
                        <asp:Panel ID="pnTplCatView" runat="server">
                            <telerik:RadGrid ID="gvTplCat" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                DataSourceID="sdsGvTplCat" GridLines="None" OnItemDataBound="gvTplCat_ItemDataBound"
                                Skin="Windows7" Culture="zh-TW">
                                <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsGvTplCat">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
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
                                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter tplName column"
                                            HeaderText="範本名稱" UniqueName="tplName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter tplCode column"
                                            UniqueName="tplCode" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                                            UniqueName="iAutoKey" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                                            <ItemTemplate>
                                                <telerik:RadButton ID="btnAddTplCat" runat="server" OnClick="btnAddTplCat_Click"
                                                    Text="加入類別">
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
                        </asp:Panel>
                        <asp:Panel ID="pnTplCatAdd" runat="server" Visible="False">
                            <table class="tableBlue">
                                <tr>
                                    <th>
                                        <asp:Label ID="lblTplName" runat="server" Font-Size="Medium" ForeColor="White"></asp:Label>
                                    </th>
                                </tr>
                            </table>
                            <table class="style1">
                                <caption>
                                    <br />
                                </caption>
                                <tr>
                                    <td align="left" valign="top" width="220">
                                        所有課程類別<br />
                                        <br />
                                        <telerik:RadListBox ID="lbTplCatList" runat="server" AllowReorder="True" AllowTransfer="True"
                                            AllowTransferDuplicates="True" AllowTransferOnDoubleClick="True" DataKeyField="iAutoKey"
                                            DataSourceID="sdsTplCatList" DataTextField="sName" DataValueField="sCode" Height="300px"
                                            Style="top: -16px; left: 0px" TransferToID="lbTplCatSelected" Width="200px">
                                        </telerik:RadListBox>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                            SelectCommand="SELECT iAutoKey, sCode, sName, sKeyMan, dKeyDate FROM trRequirementTemplateCat WHERE (sCode NOT IN (SELECT Rtc_sCode FROM trRequirementTemplateDetail WHERE (Rt_sCode = @Rt_sCode)))">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblTplCat" DefaultValue="0" Name="Rt_sCode" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td align="left" valign="top">
                                        已選課程類別<br />
                                        <telerik:RadListBox ID="lbTplCatSelected" runat="server" AllowReorder="True" DataKeyField="iAutoKey"
                                            DataSourceID="sdsTplCatSelected" DataTextField="sName" DataValueField="sCode"
                                            Height="300px" TransferToID="lbTplCatList" Width="200px">
                                        </telerik:RadListBox>
                                        <br />
                                        <asp:SqlDataSource ID="sdsTplCatSelected" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                            SelectCommand="SELECT * FROM [trRequirementTemplateDetail] d join trRequirementTemplateCat c on d.rtc_sCode = c.sCode where Rt_sCode=@Rt_sCode order by iOrder">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblTplCat" DefaultValue="0" Name="Rt_sCode" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <br />
                                        <telerik:RadButton ID="btnAddPageTplCat" runat="server" OnClick="btnAddPageTplCat_Click"
                                            Text="儲存">
                                        </telerik:RadButton>
                                        <telerik:RadButton ID="btnCancelPageTplCat" runat="server" OnClick="btnCancelPageTplCat_Click"
                                            Text="返回">
                                        </telerik:RadButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        &nbsp;
                        <asp:SqlDataSource ID="sdsGvTplCat" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT * FROM [trRequirementTemplate]"></asp:SqlDataSource>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView3" runat="server">
                        <div style="background-color: #EBF5FF; width: 350px" class="funcblock">
                            &nbsp;&nbsp;&nbsp;<br />
                            &nbsp;&nbsp;&nbsp; 類別名稱<telerik:RadTextBox ID="tbTplCatName" runat="server">
                            </telerik:RadTextBox>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblCatMsg" runat="server" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                            &nbsp;&nbsp;&nbsp;<div class="field">
                                <fieldset style="width: 130px">
                                    <legend>填寫項目</legend>&nbsp;&nbsp;項次
                                    <telerik:RadNumericTextBox ID="ntbFillMaxNum" runat="server" CausesValidation="True"
                                        DataType="System.Int32" MinValue="0" Width="30px">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                    <br />
                                    *不限制則填0</fieldset>
                            </div>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            <telerik:RadButton ID="btnTplCatAdd" runat="server" OnClick="btnTplCatAdd_Click"
                                Text="新增">
                            </telerik:RadButton>
                            &nbsp;&nbsp;&nbsp;<br />
                            <br />
                            <telerik:RadGrid ID="gvCat" runat="server" CellSpacing="0" DataSourceID="sdsTplCatList"
                                GridLines="None" Skin="Windows7" OnItemDeleted="gvCat_ItemDeleted" Culture="zh-TW"
                                AutoGenerateColumns="False">
                                <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey" DataSourceID="sdsTplCatList"
                                    AllowAutomaticUpdates="True">
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
                                            HeaderText="類別代碼" SortExpression="sCode" UniqueName="sCode" Visible="False" ReadOnly="True">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                            HeaderText="類別名稱" SortExpression="sName" UniqueName="sName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" FilterControlAltText="Filter column column"
                                            UniqueName="Delete">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" FilterControlAltText="Filter Edit column"
                                            UniqueName="Edit">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridNumericColumn DataField="iFillMaxNum" DataType="System.Int32" DecimalDigits="0"
                                            FilterControlAltText="Filter iFillMaxNum column" HeaderText="限制填寫項次" UniqueName="iFillMaxNum"
                                            Visible="False">
                                        </telerik:GridNumericColumn>
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
                            <br />
                            <asp:SqlDataSource ID="sdsTplCatList" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                                DeleteCommand="DELETE FROM [trRequirementTemplateCat] WHERE [iAutoKey] = @iAutoKey"
                                SelectCommand="SELECT * FROM [trRequirementTemplateCat]" InsertCommand="INSERT INTO [trRequirementTemplateCat] ([sCode], [sName], [iFillMaxNum], [sKeyMan], [dKeyDate]) VALUES (@sCode, @sName, @iFillMaxNum, @sKeyMan, @dKeyDate)"
                                UpdateCommand="UPDATE [trRequirementTemplateCat] SET [sName] = @sName, [iFillMaxNum] = @iFillMaxNum WHERE [iAutoKey] = @iAutoKey">
                                <DeleteParameters>
                                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="sCode" Type="String" />
                                    <asp:Parameter Name="sName" Type="String" />
                                    <asp:Parameter Name="iFillMaxNum" Type="Int32" />
                                    <asp:Parameter Name="sKeyMan" Type="String" />
                                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="sName" Type="String" />
                                    <asp:Parameter Name="iFillMaxNum" Type="Int32" />
                                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <br />
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView5" runat="server">
                        選擇範本<telerik:RadComboBox ID="cbTplView" runat="server" AutoPostBack="True" DataSourceID="sdsCbTpl"
                            DataTextField="sName" DataValueField="sCode">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Owner="cbTplView" Text="主管調查樣版" Value="主管調查樣版" />
                                <telerik:RadComboBoxItem runat="server" Owner="cbTplView" Text="員工調查樣版" Value="員工調查樣版" />
                            </Items>
                        </telerik:RadComboBox>
                        <asp:SqlDataSource ID="sdsTplView" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            
                            SelectCommand="SELECT d.*,c.sName,c.iFillMaxNum FROM [trRequirementTemplateDetail] d join trRequirementTemplateCat c on d.rtc_sCode = c.sCode where Rt_sCode=@Rt_sCode order by iOrder">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cbTplView" DefaultValue="0" Name="Rt_sCode" 
                                    PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                            DataSourceID="sdsTplView" GridLines="None" Skin="Windows7" Culture="zh-TW">
                            <MasterTableView DataKeyNames="iAutoKey" DataSourceID="sdsTplView">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                                        HeaderText="範本類別名稱" SortExpression="sName" UniqueName="sName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="iFillMaxNum" FilterControlAltText="Filter iFillMaxNum column"
                                        HeaderText="iFillMaxNum" SortExpression="iFillMaxNum" 
                                        UniqueName="iFillMaxNum" DataType="System.Int32" Visible="False">
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
        <asp:SqlDataSource ID="sdsCbTpl" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
            DeleteCommand="delete  [trRequirementTemplate] where iAutoKey=@iAutoKey" SelectCommand="SELECT * FROM [trRequirementTemplate]">
            <DeleteParameters>
                <asp:Parameter DefaultValue="0" Name="iAutoKey" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </telerik:RadAjaxPanel>
</asp:Content>
