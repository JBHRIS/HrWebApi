<%@ Page Title="填寫部門年度訓練需求調查" Language="C#" MasterPageFile="~/mpTraining.master"
    AutoEventWireup="true" CodeFile="DeptPlanFill3.aspx.cs" Inherits="eTraining_Manager_PlanFill3" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
        //<![CDATA[

        //Standard Window.confirm
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("送出後即無法修改，確認送出?"));
        }

        //RadConfirm
        function RadConfirm(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                if (shouldSubmit) {
                    this.click();
                }
            });

            var text = "Are you sure you want to submit the page?";
            radconfirm(text, callBackFunction, 300, 100, null, "RadConfirm");
            args.set_cancel(true);
        }
        //]]>    
    </script>
    <div>
        <div>
            <h3>
                填寫部門年度訓練需求調查
            </h3>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="tvDept">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                            <telerik:AjaxUpdatedControl ControlID="gvQuest" />
                            <telerik:AjaxUpdatedControl ControlID="gvQuestCustom" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="gvQuest">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                            <telerik:AjaxUpdatedControl ControlID="winQuest" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rbtnAddCourse">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                            <telerik:AjaxUpdatedControl ControlID="winCus" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="gvQuestCustom">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="winQuest">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                            <telerik:AjaxUpdatedControl ControlID="gvQuest" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="winCus">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">--%>
            <div style="color: #0000FF">
            </div>
            <div>
                年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px" AutoPostBack="True"
                    OnLoad="cbxYear_Load" OnSelectedIndexChanged="cbxYear_SelectedIndexChanged" Culture="zh-TW">
                </telerik:RadComboBox>
            </div>
            <br />
            <div style="float: left; width: 18%">
                <telerik:RadTreeView ID="tvDept" runat="server" OnNodeClick="tvDept_NodeClick">
                </telerik:RadTreeView>
            </div>
            <div style="float: right; width: 80%; height: 264px;">
                <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <h3>
                    調查清單課程
                </h3>
                <fieldset>
                    <table width="100%">
                        <tr>
                            <td width="20%">
                                <asp:CheckBox runat="server" ID="cbIncludeChild" Text="含子部門"></asp:CheckBox>
                            </td>
                            <td>
                                <telerik:RadButton ID="btnShowSummury" runat="server" Text="部門已選課程費用匯總表" OnClick="btnShowSummury_Click">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnShowDetail" runat="server" Text="部門已選課程清單匯總表" OnClick="btnShowDetail_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbMsg" runat="server" Text="部門課程費用加總："></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbAmt" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <telerik:RadGrid ID="gvQuest" runat="server" CellSpacing="0" GridLines="None" Skin="Outlook"
                    OnItemDataBound="gvQuest_ItemDataBound" Culture="zh-TW" OnNeedDataSource="gvQuest_NeedDataSource"
                    AutoGenerateColumns="False" OnSelectedIndexChanged="gvQuest_SelectedIndexChanged"
                    OnItemCommand="gvQuest_ItemCommand">
                    <MasterTableView DataKeyNames="Id">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter cmdSelect column"
                                Text="內容" UniqueName="cmdSelect" HeaderText="選擇">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="cmdUnSelect" FilterControlAltText="Filter cmdUnSelect column"
                                Text="取消" UniqueName="cmdUnSelect" ConfirmText="是否取消?">
                            </telerik:GridButtonColumn>
                            <telerik:GridCheckBoxColumn DataField="IsRequired" FilterControlAltText="Filter IsRequired column"
                                HeaderText="已選" UniqueName="IsRequired">
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridCheckBoxColumn DataField="IsRejection" FilterControlAltText="Filter IsRejection column"
                                HeaderText="駁回" UniqueName="IsRejection">
                                <HeaderStyle ForeColor="Red" />
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridBoundColumn DataField="Rejecter" FilterControlAltText="Filter Rejecter column"
                                HeaderText="駁回者" UniqueName="Rejecter">
                                <ItemStyle ForeColor="Red" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" UniqueName="Id"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MethodName" FilterControlAltText="Filter MethodName column"
                                HeaderText="內外訓" UniqueName="MethodName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter CourseName column"
                                HeaderText="課程名稱" UniqueName="CourseName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RequestReason" FilterControlAltText="Filter RequestReason column"
                                HeaderText="課程目的" UniqueName="RequestReason">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseCode" FilterControlAltText="Filter CourseCode column"
                                HeaderText="CourseCode" UniqueName="CourseCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Amt" FilterControlAltText="Filter Amt column"
                                HeaderText="預算(NTD)" UniqueName="Amt">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Budget" FilterControlAltText="Filter Budget column"
                                HeaderText="外訓課程預估費用/位" UniqueName="Budget">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StudentNum" FilterControlAltText="Filter StudentNum column"
                                HeaderText="人數" UniqueName="StudentNum">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Minutes" FilterControlAltText="Filter Minutes column"
                                HeaderText="時數(分鐘)" UniqueName="Minutes">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Month" FilterControlAltText="Filter Month column"
                                HeaderText="月份" UniqueName="Month">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SuggestionPassItemName" FilterControlAltText="Filter SuggestionPassItemName column"
                                HeaderText="評估方式" UniqueName="SuggestionPassItemName">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ConfirmText="是否駁回?" FilterControlAltText="Filter cmdReject column"
                                Text="駁回" UniqueName="cmdReject" CommandName="cmdReject">
                                <ItemStyle ForeColor="Red" />
                            </telerik:GridButtonColumn>
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
                <hr />
                <div>
                    <fieldset>
                        <h3>
                            自訂課程</h3>
                        &nbsp;<telerik:RadButton ID="rbtnAddCourse" runat="server" Text="新增自訂課程" OnClick="rbtnAddCourse_Click"
                            Skin="Windows7">
                        </telerik:RadButton>
                        <div>
                            <telerik:RadGrid ID="gvQuestCustom" runat="server" CellSpacing="0" GridLines="None"
                                OnItemDataBound="gvOtherQuest_ItemDataBound" AutoGenerateColumns="False" Culture="zh-TW"
                                OnNeedDataSource="gvQuestCustom_NeedDataSource" OnInsertCommand="gvQuestCustom_InsertCommand"
                                OnItemCommand="gvQuestCustom_ItemCommand">
                                <MasterTableView DataKeyNames="Id">
                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter CourseName column"
                                            HeaderText="課程名稱" SortExpression="CourseName" UniqueName="CourseName">
                                            <ItemStyle Wrap="False" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn CommandName="CmdDel" ConfirmText="確認是否刪除?" FilterControlAltText="Filter CmdDel column"
                                            Text="刪除" UniqueName="CmdDel">
                                        </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" UniqueName="Id"
                                            Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridCheckBoxColumn DataField="IsRejection" FilterControlAltText="Filter IsRejection column"
                                            HeaderText="駁回" UniqueName="IsRejection">
                                            <HeaderStyle ForeColor="Red" />
                                        </telerik:GridCheckBoxColumn>
                                        <telerik:GridBoundColumn DataField="Rejecter" FilterControlAltText="Filter Rejecter column"
                                            HeaderText="駁回者" UniqueName="Rejecter">
                                            <ItemStyle ForeColor="Red" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MethodName" FilterControlAltText="Filter MethodName column"
                                            HeaderText="內外訓" UniqueName="MethodName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter CourseName column"
                                            HeaderText="課程名稱" UniqueName="CourseName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RequestReason" FilterControlAltText="Filter RequestReason column"
                                            HeaderText="課程目的" UniqueName="RequestReason">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Amt" FilterControlAltText="Filter Amt column"
                                            HeaderText="預算(NTD)" UniqueName="Amt">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StudentNum" FilterControlAltText="Filter StudentNum column"
                                            HeaderText="人數" UniqueName="StudentNum">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Minutes" FilterControlAltText="Filter Minutes column"
                                            HeaderText="時數(分鐘)" UniqueName="Minutes">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Month" FilterControlAltText="Filter Month column"
                                            HeaderText="月份" UniqueName="Month">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SuggestionPassItemName" FilterControlAltText="Filter SuggestionPassItemName column"
                                            HeaderText="評估方式" UniqueName="SuggestionPassItemName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ConfirmText="是否駁回?" FilterControlAltText="Filter cmdReject column"
                                            Text="駁回" UniqueName="cmdReject" CommandName="cmdReject">
                                            <ItemStyle ForeColor="Red" />
                                        </telerik:GridButtonColumn>
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
                        </div>
                    </fieldset>
                </div>
                <br />
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td class="style2">
                            <telerik:RadWindow ID="winQuest" runat="server" Height="600px" Modal="True" Width="800px">
                                <ContentTemplate>
                                    <table width="80%">
                                        <%--                                        <tr>
                                            <td>
                                                勾選需求
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbIsRequired" runat="server" Checked="True" Visible="False" />
                                                訓練方式
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="cbTrainingMethod" runat="server">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                預算(NTD)
                                            </td>
                                            <td align="left">
                                                <telerik:RadNumericTextBox ID="ntbAmt" runat="server" MinValue="0" ValidationGroup="A">
                                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                </telerik:RadNumericTextBox>
                                                <asp:RequiredFieldValidator ID="rfvAmt" runat="server" ControlToValidate="ntbAmt"
                                                    ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                人數
                                            </td>
                                            <td align="left">
                                                <telerik:RadNumericTextBox ID="ntbStudentNum" runat="server" MinValue="0" ValidationGroup="A">
                                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                </telerik:RadNumericTextBox>
                                                <asp:RequiredFieldValidator ID="rfvStudentNum" runat="server" ControlToValidate="ntbStudentNum"
                                                    ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                月份
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="cbMonth" runat="server" Culture="zh-TW">
                                                    <Items>
                                                        <telerik:RadComboBoxItem runat="server" Text="1月" Value="1" />
                                                        <telerik:RadComboBoxItem runat="server" Text="2月" Value="2" />
                                                        <telerik:RadComboBoxItem runat="server" Text="3月" Value="3" />
                                                        <telerik:RadComboBoxItem runat="server" Text="4月" Value="4" />
                                                        <telerik:RadComboBoxItem runat="server" Text="5月" Value="5" />
                                                        <telerik:RadComboBoxItem runat="server" Text="6月" Value="6" />
                                                        <telerik:RadComboBoxItem runat="server" Text="7月" Value="7" />
                                                        <telerik:RadComboBoxItem runat="server" Text="8月" Value="8" />
                                                        <telerik:RadComboBoxItem runat="server" Text="9月" Value="9" />
                                                        <telerik:RadComboBoxItem runat="server" Text="10月" Value="10" />
                                                        <telerik:RadComboBoxItem runat="server" Text="11月" Value="11" />
                                                        <telerik:RadComboBoxItem runat="server" Text="12月" Value="12" />
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                時數(分鐘)
                                            </td>
                                            <td align="left">
                                                <telerik:RadNumericTextBox ID="ntbMins" runat="server" DataType="System.Int32" MinValue="0"
                                                    ValidationGroup="A">
                                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                </telerik:RadNumericTextBox>
                                                <asp:RequiredFieldValidator ID="rfvMins" runat="server" ControlToValidate="ntbMins"
                                                    ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                評估方式
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="cbxSuggestionPassItem" runat="server">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                課程目的
                                            </td>
                                            <td align="left">
                                                <telerik:RadTextBox ID="tbRequestReason" runat="server" LabelWidth="300px" TextMode="MultiLine"
                                                    ValidationGroup="A">
                                                </telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="rfvRequestReason" runat="server" ControlToValidate="tbRequestReason"
                                                    ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <telerik:RadButton ID="btnQuestSave" runat="server" Text="儲存" OnClick="btnQuestSave_Click"
                                                    ValidationGroup="A">
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </telerik:RadWindow>
                        </td>
                    </tr>
                </table>
                <telerik:RadWindow ID="winCus" runat="server" Height="600px" Modal="True" Width="800px">
                    <ContentTemplate>
                        <table width="80%">
                            <tr>
                                <td>
                                    新增課程名稱
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbCusCourseName" runat="server" ValidationGroup="B">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfvCusCourseName" runat="server" ControlToValidate="tbCusRequestReason"
                                        ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    訓練方式
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cbCusTrainingMethod" runat="server">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    預算(NTD)
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="ntbCusAmt" runat="server" MinValue="0" ValidationGroup="B">
                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvCusAmt" runat="server" ControlToValidate="tbCusRequestReason"
                                        ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    人數
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="ntbCusStudentNum" runat="server" MinValue="0" ValidationGroup="B">
                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvCusStudentNum" runat="server" ControlToValidate="tbCusRequestReason"
                                        ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    月份
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cbCusMonth" runat="server" Culture="zh-TW">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" Text="1月" Value="1" />
                                            <telerik:RadComboBoxItem runat="server" Text="2月" Value="2" />
                                            <telerik:RadComboBoxItem runat="server" Text="3月" Value="3" />
                                            <telerik:RadComboBoxItem runat="server" Text="4月" Value="4" />
                                            <telerik:RadComboBoxItem runat="server" Text="5月" Value="5" />
                                            <telerik:RadComboBoxItem runat="server" Text="6月" Value="6" />
                                            <telerik:RadComboBoxItem runat="server" Text="7月" Value="7" />
                                            <telerik:RadComboBoxItem runat="server" Text="8月" Value="8" />
                                            <telerik:RadComboBoxItem runat="server" Text="9月" Value="9" />
                                            <telerik:RadComboBoxItem runat="server" Text="10月" Value="10" />
                                            <telerik:RadComboBoxItem runat="server" Text="11月" Value="11" />
                                            <telerik:RadComboBoxItem runat="server" Text="12月" Value="12" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    時數(分鐘)
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="ntbCusMins" runat="server" DataType="System.Int32"
                                        ValidationGroup="B" MinValue="0">
                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvCusMins" runat="server" ControlToValidate="tbCusRequestReason"
                                        ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    評估方式
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="cbxCusSuggestionPassItem" runat="server">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    課程目的
                                </td>
                                <td align="left">
                                    <telerik:RadTextBox ID="tbCusRequestReason" runat="server" LabelWidth="300px" TextMode="MultiLine"
                                        ValidationGroup="B">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="rfvCusRequestReason" runat="server" ControlToValidate="tbCusRequestReason"
                                        ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnCusSave" runat="server" Text="儲存" OnClick="btnCusSave_Click"
                                        ValidationGroup="B">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadWindow>
                <telerik:RadWindow ID="winOuter" runat="server" Height="600px" Modal="True" Width="1000px">
                </telerik:RadWindow>
            </div>
            <%--</telerik:RadAjaxPanel>--%>
        </div>
    </div>
</asp:Content>
