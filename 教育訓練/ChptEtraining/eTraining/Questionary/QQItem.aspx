<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="QQItem.aspx.cs" Inherits="eTraining_Questionary_QQ" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
        </script>
    </telerik:RadCodeBlock>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Sitefinity">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
        Width="100%" HorizontalAlign="NotSet" 
        LoadingPanelID="RadAjaxLoadingPanel1" onajaxrequest="RadAjaxPanel1_AjaxRequest">
        <fieldset>
            <legend>新增題目</legend>
            <asp:Panel ID="pnl1" runat="server">
                <table>
                    <tr>
                        <td valign="top" width="40%">
                            問題：<telerik:RadTextBox ID="tbQuestionText" runat="server" Width="200px">
                            </telerik:RadTextBox>
                            <br />
                            問題類型：<telerik:RadComboBox ID="cbType" runat="server" DataTextField="Name" DataValueField="Code"
                                AutoPostBack="True" OnSelectedIndexChanged="cbType_SelectedIndexChanged">
                            </telerik:RadComboBox>
                            <br />
                            <asp:CheckBox ID="cbMcqDisplayHorizontal" runat="server" Text="選擇題選項水平展開" />
                            <br />
                            <asp:CheckBox ID="cbIsValueInt" runat="server" Text="選擇題採(數字值)" />
                            <br />
                            <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增問題">
                            </telerik:RadButton>
                        </td>
                        <td valign="top">
                            <asp:Panel ID="pnl2" runat="server" Visible="false">
                                <fieldset>
                                    <legend>選項群組</legend>選項群組選擇<telerik:RadComboBox ID="cbGroup" runat="server" AutoPostBack="True"
                                        DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="cbGroup_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                    <telerik:RadGrid ID="gv2" runat="server" OnNeedDataSource="gv2_NeedDataSource" AutoGenerateColumns="False"
                                        CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemCommand="gv2_ItemCommand">
                                        <MasterTableView DataKeyNames="Id">
                                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridButtonColumn CommandName="Update" FilterControlAltText="Filter Edit column"
                                                    Text="編輯" UniqueName="Edit">
                                                </telerik:GridButtonColumn>
                                                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" HeaderText="Id"
                                                    UniqueName="Id" Visible="False">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="GroupCode" FilterControlAltText="Filter GroupCode column"
                                                    HeaderText="群組代碼" UniqueName="GroupCode">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Sequence" FilterControlAltText="Filter Sequence column"
                                                    HeaderText="順序" UniqueName="Sequence">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Text" FilterControlAltText="Filter Text column"
                                                    HeaderText="選項文字" UniqueName="Text">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="StringValue" FilterControlAltText="Filter StringValue column"
                                                    HeaderText="選項值(文字)" UniqueName="StringValue">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="IntValue" FilterControlAltText="Filter IntValue column"
                                                    HeaderText="選項值(數字)" UniqueName="IntValue">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn CommandName="Del" ConfirmText="確認是否刪除?" FilterControlAltText="Filter Del column"
                                                    Text="刪除" UniqueName="Del">
                                                </telerik:GridButtonColumn>
                                            </Columns>
                                            <EditFormSettings>
                                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                </EditColumn>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>
                                    <telerik:RadButton ID="btnAddGp" runat="server" Text="新增選項" OnClick="btnAddGp_Click">
                                    </telerik:RadButton>
                                </fieldset>
                            </asp:Panel>
                        </td>
                        <td valign="top">
                            <asp:Panel ID="pnl3" runat="server" Visible="false">
                                <table>
                                    <tr>
                                        <td>
                                            群組代碼
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="tbGroupCode" runat="server" ValidationGroup="A">
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="tbGroupCode" ErrorMessage="需輸入資料" ForeColor="Red" 
                                                ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            順序
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="ntbSequence" runat="server" ValidationGroup="A">
                                                <NumberFormat AllowRounding="False" DecimalDigits="0" ZeroPattern="n" />
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="ntbSequence" ErrorMessage="需輸入資料" ForeColor="Red" 
                                                ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            選項文字
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="tbText" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            文字值
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="tbStringValue" runat="server">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            數字值
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="ntbIntValue" runat="server" ValidationGroup="A">
                                                <NumberFormat AllowRounding="False" DecimalDigits="0" ZeroPattern="n" />
                                            </telerik:RadNumericTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="ntbIntValue" ErrorMessage="需輸入資料" ForeColor="Red" 
                                                ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                <telerik:RadButton ID="btnSaveDetailTpl" runat="server" 
                                    onclick="btnSaveDetailTpl_Click" Text="儲存" ValidationGroup="A">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                                    Text="取消">
                                </telerik:RadButton>
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="lblMode" runat="server" Visible="False"></asp:Label>
                                <br />
                                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </fieldset>
        <br />
        <br />
        <script type="text/javascript">
            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }

            function Rebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
            }

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }

            function CancelEdit() {
                GetRadWindow().close();
            }


            //Standard Window.confirm
            function StandardConfirm(sender, args) {
                args.set_cancel(!window.confirm("您確定要儲存嗎？"));
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

        </script>
        <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
            Culture="zh-TW" GridLines="None" OnItemCommand="gv_ItemCommand" OnNeedDataSource="gv_NeedDataSource"
            OnSelectedIndexChanged="gv_SelectedIndexChanged" 
            AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" 
            onitemdatabound="gv_ItemDataBound">
            <ClientSettings>
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <MasterTableView DataKeyNames="Id">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" HeaderText="Id"
                        UniqueName="Id" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="QuestionText" FilterControlAltText="Filter QuestionText column"
                        HeaderText="問題" UniqueName="QuestionText">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TypeCode" FilterControlAltText="Filter TypeCode column"
                        HeaderText="TypeCode" UniqueName="TypeCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TypeName" FilterControlAltText="Filter TypeName column"
                        HeaderText="題型" UniqueName="TypeName">
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="McqDisplayHorizontal" FilterControlAltText="Filter McqDisplayHorizontal column"
                        HeaderText="選擇題水平展開" UniqueName="McqDisplayHorizontal">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridCheckBoxColumn DataField="IsValueInt" 
                        FilterControlAltText="Filter IsValueInt column" HeaderText="選擇題採用數字值" 
                        UniqueName="IsValueInt">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter tpl1 column" 
                        HeaderText="選項" UniqueName="tpl1">
                        <ItemTemplate>
                            <asp:Table ID="tbl" runat="server" BorderColor="Silver" BorderStyle="Groove" 
                                BorderWidth="1px" CaptionAlign="Top" GridLines="Both">
                            </asp:Table>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn CommandName="Edt" 
                        FilterControlAltText="Filter CommandEdit column" Text="編輯" 
                        UniqueName="CommandEdit">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="Del" FilterControlAltText="Filter CommandDel column"
                        Text="刪除" UniqueName="CommandDel" ConfirmText="確認是否刪除?">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="McqId" EmptyDataText="" 
                        FilterControlAltText="Filter McqId column" UniqueName="McqId" Visible="False">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
        <telerik:RadWindow ID="win" runat="server" EnableShadow="True" Modal="True" 
            VisibleStatusbar="False">
        </telerik:RadWindow>
        <br />
        <br />
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
