<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LeaveRecord.aspx.cs" Inherits="Employee_LeaveRecord" Title="e-HR" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function setCustomPosition(sender, args) {
            sender.moveTo(sender.get_left(), sender.get_top());
        }
    </script>
    <style type="text/css">
        .RadForm legend
        {
            font-size: 16px;
        }
    </style>
    <div style="font-size: 16px">
        <fieldset>
            <legend>說明 </legend>
            <div style="border-style: groove; border-width: thin; word-wrap: break-word; word-break: normal;
                background-color: #DAE3EB">
                <ol>
                    <li>查詢日期則預設當天日期為主 </li>
                    <li>若是查詢整年度則請KEY 2014/01/01 即可 </li>
                    <li>若是查詢補休相關
                        <ol type="a">
                            <li>假別:請勾選"補休"</li>
                            <li>請注意點選得假或已申請項目</li>
                            <li>點選"細節"即可查詢當筆補休資料</li>
                        </ol>
                    </li>
                </ol>
            </div>
        </fieldset>
        <h3>
            <asp:Label ID="lblShowHeader" runat="server" Text="請假資料" meta:resourcekey="lblShowHeaderResource1"></asp:Label>
        </h3>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Web20" />
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
            HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
            <fieldset>
                <legend>
                    <asp:Label ID="lblShowInquiryCondition" runat="server" Text="查詢條件" meta:resourcekey="lblShowInquiryConditionResource1"></asp:Label></legend>
                <asp:Label ID="Label1" runat="server" Text="請假日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" meta:resourcekey="adateResource1">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText=""
                        LabelWidth="40%" type="text" value="">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" meta:resourcekey="ddateResource1">
                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                    </Calendar>
                    <DateInput DisplayDateFormat="" DateFormat="" DisplayText="" LabelWidth="40%" type="text"
                        value="">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" ValidationGroup="group_date"
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource1" />&nbsp;
                <asp:Button ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" Text="匯出Excel"
                    ValidationGroup="group_date" Visible="False" meta:resourcekey="ExportExcelResource1" />
                <div>
                    <asp:Label ID="lblCat" runat="server" Text="假別："></asp:Label>
                    <telerik:RadComboBox ID="cbxHoliType" runat="server" CheckBoxes="True" Culture="zh-TW"
                        EnableCheckAllItemsCheckBox="True">
                        <Localization CheckAllString="全選" AllItemsCheckedString="選擇全部" ItemsCheckedString="個已選擇" />
                    </telerik:RadComboBox>
                    <asp:RadioButtonList ID="rblCat" runat="server" RepeatDirection="Horizontal" RepeatLayout="flow"
                        OnSelectedIndexChanged="rblCat_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="0">得假</asp:ListItem>
                        <asp:ListItem Value="1">已申請</asp:ListItem>
                        <asp:ListItem Value="2">總計</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <telerik:RadGrid ID="gvPositive" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                    Culture="zh-TW" GridLines="None" OnNeedDataSource="gvPositive_NeedDataSource"
                    OnSelectedIndexChanged="gvPositive_SelectedIndexChanged" Font-Size="16px">
                    <MasterTableView DataKeyNames="Guid">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter cmdSelect column"
                                Text="細節" UniqueName="cmdSelect">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="Guid" FilterControlAltText="Filter Guid column"
                                UniqueName="Guid" Visible="False">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                HeaderText="工號" UniqueName="Nobr">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column"
                                HeaderText="姓名" UniqueName="NameC">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HCode" FilterControlAltText="Filter HCode column"
                                HeaderText="假別代碼" UniqueName="HCode" Visible="False">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HCodeDisp" FilterControlAltText="Filter HCodeDisp column"
                                HeaderText="代碼" UniqueName="HCodeDisp">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HName" FilterControlAltText="Filter HName column"
                                HeaderText="名稱" UniqueName="HName">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Unit" FilterControlAltText="Filter Unit column"
                                HeaderText="單位" UniqueName="Unit">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BeginDate" DataFormatString="{0:yyyy/M/d}" FilterControlAltText="Filter BeginDate column"
                                HeaderText="起" UniqueName="BeginDate">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EndDate" DataFormatString="{0:yyyy/M/d}" FilterControlAltText="Filter EndDate column"
                                HeaderText="迄(失效)" UniqueName="EndDate">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Entitled" FilterControlAltText="Filter Entitled column"
                                HeaderText="得假" DataFormatString="{0:#,0.##}" UniqueName="Entitled">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Taken" FilterControlAltText="Filter Taken column"
                                HeaderText="已請" UniqueName="Taken" DataFormatString="{0:#,0.##}">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Balance" FilterControlAltText="Filter Balance column"
                                HeaderText="剩餘" UniqueName="Balance" DataFormatString="{0:#,0.##}">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
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
                <telerik:RadGrid ID="gvNegative" runat="server" OnNeedDataSource="gvNegative_NeedDataSource"
                    AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None"
                    OnSelectedIndexChanged="gvNegative_SelectedIndexChanged" Font-Size="20px">
                    <MasterTableView DataKeyNames="Guid">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter cmdSelect column"
                                Text="細節" UniqueName="cmdSelect">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="Guid" FilterControlAltText="Filter Guid column"
                                HeaderText="Guid" UniqueName="Guid" Visible="False">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                HeaderText="工號" UniqueName="Nobr">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column"
                                HeaderText="姓名" UniqueName="NameC">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Hcode" FilterControlAltText="Filter Hcode column"
                                HeaderText="Hcode" Visible="false" UniqueName="Hcode">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HcodeDisp" FilterControlAltText="Filter HcodeDisp column"
                                HeaderText="代碼" Visible="false" UniqueName="HcodeDisp">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Hname" FilterControlAltText="Filter Hname column"
                                HeaderText="假名" UniqueName="Hname">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Adate" DataFormatString="{0:yyyy/M/d}" FilterControlAltText="Filter Adate column"
                                HeaderText="日期" UniqueName="Adate">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BeginTime" FilterControlAltText="Filter BeginTime column"
                                HeaderText="時間起" DataFormatString="{0:HH:mm}" UniqueName="BeginTime">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EndTime" FilterControlAltText="Filter EndTime column"
                                HeaderText="時間迄" DataFormatString="{0:HH:mm}" UniqueName="EndTime">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Serno" FilterControlAltText="Filter Serno column"
                                HeaderText="單號" UniqueName="Serno" Visible="false">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Memo" FilterControlAltText="Filter Memo column"
                                HeaderText="備註" UniqueName="Memo">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Taken" FilterControlAltText="Filter Taken column"
                                HeaderText="申請時數(天數)" UniqueName="Taken">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Unit" FilterControlAltText="Filter Unit column"
                                HeaderText="單位" UniqueName="Unit">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
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
                <telerik:RadGrid ID="gvPositiveTotal_" runat="server" AutoGenerateColumns="False"
                    CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="gvPositiveTotal_NeedDataSource"
                    Font-Size="16px">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                HeaderText="工號" UniqueName="Nobr">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column"
                                HeaderText="姓名" UniqueName="NameC">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HCodeDisp" FilterControlAltText="Filter HCodeDisp column"
                                HeaderText="代碼" UniqueName="HCodeDisp">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HName" FilterControlAltText="Filter HName column"
                                HeaderText="名稱" UniqueName="HName">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Unit" FilterControlAltText="Filter Unit column"
                                HeaderText="單位" UniqueName="Unit">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EntitledTotal" FilterControlAltText="Filter EntitledTotal column"
                                HeaderText="得假(總)" UniqueName="EntitledTotal">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TakenTotal" FilterControlAltText="Filter TakenTotal column"
                                HeaderText="已請(總)" UniqueName="TakenTotal">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BalanceTotal" FilterControlAltText="Filter BalanceTotal column"
                                HeaderText="剩餘(總)" UniqueName="BalanceTotal">
                                <HeaderStyle Font-Size="16px" />
                                <ItemStyle Font-Size="16px" />
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
            </fieldset>
            <telerik:RadWindow ID="win" runat="server" Height="700px" Modal="True" Width="1000px"
                OnClientShow="setCustomPosition">
                <ContentTemplate>
                    <telerik:RadGrid ID="gvPositiveDetail" runat="server" OnNeedDataSource="gvPositiveDetail_NeedDataSource"
                        AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                        <MasterTableView DataKeyNames="Guid">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Guid" FilterControlAltText="Filter Guid column"
                                    HeaderText="Guid" UniqueName="Guid" Visible="False">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                    HeaderText="工號" UniqueName="Nobr">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column"
                                    HeaderText="姓名" UniqueName="NameC">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Hcode" FilterControlAltText="Filter Hcode column"
                                    HeaderText="Hcode" Visible="false" UniqueName="Hcode">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HcodeDisp" FilterControlAltText="Filter HcodeDisp column"
                                    HeaderText="代碼" Visible="false" UniqueName="HcodeDisp">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Hname" FilterControlAltText="Filter Hname column"
                                    HeaderText="假名" UniqueName="Hname">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Adate" DataFormatString="{0:yyyy/M/d}" FilterControlAltText="Filter Adate column"
                                    HeaderText="日期" UniqueName="Adate">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BeginTime" FilterControlAltText="Filter BeginTime column"
                                    HeaderText="時間起" DataFormatString="{0:HH:mm}" UniqueName="BeginTime">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EndTime" FilterControlAltText="Filter EndTime column"
                                    HeaderText="時間迄" DataFormatString="{0:HH:mm}" UniqueName="EndTime">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Serno" FilterControlAltText="Filter Serno column"
                                    HeaderText="單號" UniqueName="Serno" Visible="false">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Memo" FilterControlAltText="Filter Memo column"
                                    HeaderText="備註" UniqueName="Memo">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Taken" FilterControlAltText="Filter Taken column"
                                    HeaderText="申請時數(天數)" UniqueName="Taken">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Unit" FilterControlAltText="Filter Unit column"
                                    HeaderText="單位" UniqueName="Unit">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
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
                    <telerik:RadGrid ID="gvNegativeDetail" runat="server" AutoGenerateColumns="False"
                        CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="gvNegativeDetail_NeedDataSource">
                        <MasterTableView DataKeyNames="Guid">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Guid" FilterControlAltText="Filter Guid column"
                                    UniqueName="Guid" Visible="False">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                    HeaderText="工號" UniqueName="Nobr">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column"
                                    HeaderText="姓名" UniqueName="NameC">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HCode" FilterControlAltText="Filter HCode column"
                                    HeaderText="假別代碼" UniqueName="HCode" Visible="False">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HCodeDisp" FilterControlAltText="Filter HCodeDisp column"
                                    HeaderText="代碼" UniqueName="HCodeDisp">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HName" FilterControlAltText="Filter HName column"
                                    HeaderText="名稱" UniqueName="HName">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Unit" FilterControlAltText="Filter Unit column"
                                    HeaderText="單位" UniqueName="Unit">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BeginDate" DataFormatString="{0:yyyy/M/d}" FilterControlAltText="Filter BeginDate column"
                                    HeaderText="起" UniqueName="BeginDate">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EndDate" DataFormatString="{0:yyyy/M/d}" FilterControlAltText="Filter EndDate column"
                                    HeaderText="迄" UniqueName="EndDate">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Entitled" FilterControlAltText="Filter Entitled column"
                                    HeaderText="得假" DataFormatString="{0:#,0.##}" UniqueName="Entitled">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Taken" FilterControlAltText="Filter Taken column"
                                    HeaderText="已請" UniqueName="Taken" DataFormatString="{0:#,0.##}">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Balance" FilterControlAltText="Filter Balance column"
                                    HeaderText="剩餘" UniqueName="Balance" DataFormatString="{0:#,0.##}">
                                    <HeaderStyle Font-Size="16px" />
                                    <ItemStyle Font-Size="16px" />
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
                </ContentTemplate>
            </telerik:RadWindow>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>