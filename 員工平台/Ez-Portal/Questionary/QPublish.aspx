<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="QPublish.aspx.cs" Inherits="eTraining_Questionary_QPublish" %>

<%@ Register Src="../Templet/SelectEmp3.ascx" TagName="SelectEmp3" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        /* this fixes the IE6/7 positioning bug */
        .RadGrid .rgDataDiv
        {
            position: relative;
        }
    </style>
    <telerik:RadStyleSheetManager runat="server" ID="ssm">
    </telerik:RadStyleSheetManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        產生問卷中，請勿關閉視窗
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <asp:Panel ID="pnl1" runat="server">
            <fieldset style="background-color:#E2E2E2">
                <asp:CheckBox ID="ckPublish" runat="server" Checked="True" Text="發佈" />
                <table>
                    <tr>
                        <td>
                            起<telerik:RadDateTimePicker ID="dtpB" runat="server" Width="250px" Culture="zh-TW">
                                <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm" Interval="00:30:00">
                                </TimeView>
                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                    LabelWidth="40%" type="text" value="">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDateTimePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dtpB"
                                ErrorMessage="必填" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            迄<telerik:RadDateTimePicker ID="dtpE" runat="server" Width="250px" Culture="zh-TW">
                                <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm" Interval="00:30:00">
                                </TimeView>
                                <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                    LabelWidth="40%" type="text" value="">
                                </DateInput>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            </telerik:RadDateTimePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dtpE"
                                ErrorMessage="必填" ForeColor="Red" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cbViewSummaryOpening" runat="server" Text="問卷開放中可看統計數字" />
                        </td>
                        <td>
                            <asp:CheckBox ID="cbViewSummaryClosed" runat="server" Text="問卷結束後可統計數字" />
                        </td>
                    </tr>
                                        <tr>
                        <td>
                            <asp:CheckBox ID="cbIsAnonymous" runat="server" Text="問卷匿名" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="background-color:#E6F0F5">
                <div>
                    發佈類型
                    <telerik:RadComboBox ID="cbTargetType" runat="server" CheckBoxes="True" EnableCheckAllItemsCheckBox="True">
                        <Localization AllItemsCheckedString="所有項目已選擇" CheckAllString="全選" ItemsCheckedString="個項目已選" />
                    </telerik:RadComboBox>
                </div>
                <div>
                    發佈對象
                    <asp:RadioButtonList ID="rblTargetType" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="True" OnSelectedIndexChanged="rblTargetType_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="1">全體員工</asp:ListItem>
                        <asp:ListItem Value="0">特定對象</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <asp:Panel runat="server" ID="pnlTarget">
                    <telerik:RadButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="刪除所有選定部門人員">
                    </telerik:RadButton>
                    <telerik:RadGrid ID="gvTarget" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                        Culture="zh-TW" GridLines="None" AllowPaging="True" AllowSorting="True" OnItemCommand="gvTarget_ItemCommand"
                        OnNeedDataSource="gvTarget_NeedDataSource">
                        <MasterTableView AllowSorting="False">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" UniqueName="Nobr"
                                    DataField="Nobr" HeaderText="工號">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" UniqueName="EmpName"
                                    DataField="EmpName" HeaderText="姓名">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                                    HeaderText="部門" UniqueName="DeptName">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DeptCode" FilterControlAltText="Filter DeptCode column"
                                    UniqueName="DeptCode" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridCheckBoxColumn DataField="IsEmp" DataType="System.Boolean" FilterControlAltText="Filter IsEmp column"
                                    UniqueName="IsEmp" Visible="False">
                                </telerik:GridCheckBoxColumn>
                                <telerik:GridButtonColumn CommandName="cmdDel" FilterControlAltText="Filter cmdDel column"
                                    Text="刪除" UniqueName="cmdDel">
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
                    <table width="100%">
                        <tr>
                            <td align="left" valign="top" width="50%">
                                <asp:Panel ID="pnlSelectDept" runat="server">
                                    <telerik:RadButton ID="btnAddDept" runat="server" Text="加入部門" OnClick="btnAddDept_Click">
                                    </telerik:RadButton>
                                    <telerik:RadTreeView ID="tvDept" runat="server" CheckBoxes="True" CheckChildNodes="True">
                                    </telerik:RadTreeView>
                                </asp:Panel>
                            </td>
                            <td align="left" valign="top" width="50%">
                                <asp:Panel ID="pnlSelectEmp" runat="server">
                                    <div>
                                        <telerik:RadButton ID="btnAddEmp" runat="server" Text="加入人員" OnClick="btnAddEmp_Click">
                                        </telerik:RadButton>
                                    </div>
                                    <uc1:SelectEmp3 ID="SelectEmp31" runat="server" />
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </fieldset>
            <fieldset style="background-color:#B7BFCA">
                <asp:Panel runat="server" ID="pnlMail">
                    <asp:CheckBox ID="cbxMail" runat="server" AutoPostBack="True" Text="發送mail" OnCheckedChanged="cbxMail_CheckedChanged" />
                    <asp:Panel runat="server" ID="pnlMailDetail" Visible="false">
                        <table>
                            <tr>
                                <td>
                                    標題
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="tbSubject" runat="server" Width="680px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    內容
                                </td>
                                <td>
                                    <telerik:RadEditor ID="edtContent" runat="server" EditModes="Design, Preview" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                                        Height="300px">
                                    </telerik:RadEditor>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </asp:Panel>
            </fieldset>
        </asp:Panel>
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
    </telerik:RadAjaxPanel>
    <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="發佈"
        ValidationGroup="g1">
    </telerik:RadButton>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>