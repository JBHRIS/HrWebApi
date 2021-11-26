<%@ Page Title="" Language="C#" MasterPageFile="~/mpCheck0990119.master" AutoEventWireup="true"
    CodeFile="Check.aspx.cs" Inherits="Abs1_Check" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblTitle" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNobrSign" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
            <table class="TableFullBorder" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblCurrency" runat="server" Font-Bold="True" ForeColor="Red" Text="此單據已超過暫支款的總預算！"
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:FormView ID="fvAppS" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsAppS"
                            Width="100%" OnDataBound="fvAppS_DataBound">
                            <ItemTemplate>
                                <table class="TableFullBorder">
                                    <tr>
                                        <th colspan="4">
                                            申請人基本資料
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <th align="right">
                                            申請日期
                                        </th>
                                        <td>
                                            <asp:Label ID="dKeyDateLabel" runat="server" Text='<%# Bind("dKeyDate", "{0:d}") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right">
                                            申請人姓名 / 工號
                                        </th>
                                        <td>
                                            <asp:Label ID="sNameLabel" runat="server" Text='<%# Bind("sName") %>' />
                                            /<asp:Label ID="sNobrLabel" runat="server" Text='<%# Bind("sNobr") %>' />
                                        </td>
                                        <th align="right">
                                            代理人姓名 / 工號
                                        </th>
                                        <td>
                                            <asp:Label ID="sAgentNameLabel" runat="server" Text='<%# Bind("sAgentName") %>' />
                                            /<asp:Label ID="sAgentNobrLabel" runat="server" Text='<%# Bind("sAgentNobr") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right">
                                            部門 / 職稱
                                        </th>
                                        <td colspan="3">
                                            <asp:Label ID="lblDept" runat="server" Text='<%# Eval("sDeptName") %>'></asp:Label>
                                            &nbsp;/
                                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("sJobName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right">
                                            出差類別
                                        </th>
                                        <td colspan="3">
                                            <asp:Label ID="sName3Label1" runat="server" Text='<%# Bind("sName2") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="right">
                                            出差目的
                                        </th>
                                        <td colspan="3">
                                            <asp:Label ID="sName3Label" runat="server" Text='<%# Bind("sName3") %>' />
                                            /<asp:Label ID="sName3Label0" runat="server" Text='<%# Bind("sReserve1") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th align="left" colspan="4">
                                            工作項目
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="4">
                                            <asp:GridView ID="gvFactoryContact" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                                                DataSourceID="sdsFactoryContactGV">
                                                <Columns>
                                                    <asp:BoundField DataField="sContent" HeaderText="工作項目" SortExpression="sContent" />
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    目前無聯絡人。
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="sdsFactoryContactGV" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                DeleteCommand="DELETE FROM [wfFormAppCode] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT *
 FROM wfFormAppCode 
WHERE (sCategory = 'Abs1FactoryContact') AND (sProcessID = @sProcessID)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                                                </SelectParameters>
                                                <DeleteParameters>
                                                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                                                </DeleteParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="4">
                                            出差行程
                                        </th>
                                    </tr>
                                    <tr>
                                        <th align="right">
                                            預定起訖日期
                                        </th>
                                        <td colspan="3">
                                            <asp:Label ID="dDateTimeBLabel" runat="server" Text='<%# Bind("dDateTimeB1", "{0:d}") %>' />
                                            <asp:Label ID="dDateTimeBLabel0" runat="server" Text='<%# Bind("sTimeB1") %>' />
                                            至<asp:Label ID="dDateTimeELabel" runat="server" Text='<%# Bind("dDateTimeE1", "{0:d}") %>' />
                                            <asp:Label ID="dDateTimeELabel0" runat="server" Text='<%# Bind("sTimeE1") %>' />
                                            ,共<asp:Label ID="Label1" runat="server" Text='<%# Eval("iTotalDay1") %>'></asp:Label>
                                            天
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvPlace1" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                                                DataSourceID="sdsPlace1GV">
                                                <Columns>
                                                    <asp:BoundField DataField="sName" HeaderText="預定前往地點" SortExpression="sName" />
                                                    <asp:BoundField DataField="sContent" HeaderText="備註" SortExpression="sContent" />
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    目前無出差地。
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="sdsPlace1GV" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                DeleteCommand="DELETE FROM [wfFormAppCode] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT *
 FROM wfFormAppCode 
WHERE (sCategory = 'Place1') AND (sProcessID = @sProcessID)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                                                </SelectParameters>
                                                <DeleteParameters>
                                                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                                                </DeleteParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="4">
                                            須協助辦理事項
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvTransact" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                                                DataSourceID="sdsTransactGV">
                                                <Columns>
                                                    <asp:BoundField DataField="sName" HeaderText="交待事項" SortExpression="sName" />
                                                    <asp:BoundField DataField="sContent" HeaderText="說明" SortExpression="sContent" />
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    目前無代辦事項。
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="sdsTransactGV" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                DeleteCommand="DELETE FROM [wfFormAppCode] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT * FROM wfFormAppCode WHERE (sCategory = 'Abs1Transact') AND (sProcessID = @sProcessID)">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                                                </SelectParameters>
                                                <DeleteParameters>
                                                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                                                </DeleteParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </ItemTemplate>
                        </asp:FormView>
                        <asp:SqlDataSource ID="sdsAppS" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfAppAbs1]
WHERE          (sProcessID = @sProcessID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <th>
                        簽核者資料
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvSignM" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            DataSourceID="sdsSignM" Width="100%">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="sNote" HeaderText="意見" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="簽核日期" SortExpression="dKeyDate" />
                            </Columns>
                            <EmptyDataTemplate>
                                無簽核資料。
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsSignM" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfFormSignM]
WHERE          (sProcessID = @sProcessID)
ORDER BY   dKeyDate DESC">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="plDate" runat="server" Visible="false">
                            <table class="style1">
                                <tr>
                                    <th nowrap="true" width="1%" class="style2">
                                        <font color="red"><b>實際出差日期</b></font>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtDateB" runat="server" CssClass="txtDate" ValidationGroup="fv"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtDateB_CalendarExtender" runat="server" CssClass="MyCalendar"
                                            DaysModeTitleFormat="yyyy/MM" Enabled="True" Format="yyyy/MM/dd" PopupButtonID="ibtnDateB"
                                            TargetControlID="txtDateB" TodaysDateFormat="yyyy/MM/dd">
                                        </asp:CalendarExtender>
                                        <asp:MaskedEditExtender ID="txtDateB_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateB">
                                        </asp:MaskedEditExtender>
                                        <asp:ImageButton ID="ibtnDateB" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                                        <asp:TextBox ID="txtTimeB" runat="server" CssClass="txtTime" 
                                            ValidationGroup="fv">0000</asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtTimeB_MaskedEditExtender" runat="server" 
                                            AutoComplete="False" CultureAMPMPlaceholder="" 
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="9999" MaskType="Number" TargetControlID="txtTimeB">
                                        </asp:MaskedEditExtender>
                                        &nbsp;至&nbsp;<asp:TextBox ID="txtDateE" runat="server" CssClass="txtDate" ValidationGroup="fv"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtDateE_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateE">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="txtDateE_CalendarExtender" runat="server" CssClass="MyCalendar"
                                            DaysModeTitleFormat="yyyy/MM" Enabled="True" Format="yyyy/MM/dd" PopupButtonID="ibtnDateE"
                                            TargetControlID="txtDateE" TodaysDateFormat="yyyy/MM/dd">
                                        </asp:CalendarExtender>
                                        <asp:ImageButton ID="ibtnDateE" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                                        <asp:TextBox ID="txtTimeE" runat="server" CssClass="txtTime" 
                                            ValidationGroup="fv">0000</asp:TextBox>
                                        <asp:MaskedEditExtender ID="txtTimeE_MaskedEditExtender" runat="server" 
                                            AutoComplete="False" CultureAMPMPlaceholder="" 
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="9999" MaskType="Number" TargetControlID="txtTimeE">
                                        </asp:MaskedEditExtender>
                                        &nbsp;<asp:RequiredFieldValidator ID="rfvDateB" runat="server" ControlToValidate="txtDateB"
                                            Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfvDateB_ValidatorCalloutExtender" runat="server"
                                            Enabled="True" TargetControlID="rfvDateB">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RequiredFieldValidator ID="rfvDateE" runat="server" ControlToValidate="txtDateE"
                                            Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="rfvDateE_ValidatorCalloutExtender" runat="server"
                                            Enabled="True" TargetControlID="rfvDateE">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RangeValidator ID="rvDateB" runat="server" ControlToValidate="txtDateB" Display="None"
                                            ErrorMessage="格式不正確" MaximumValue="9999/12/31" MinimumValue="1900/1/1" SetFocusOnError="True"
                                            Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                                        <asp:ValidatorCalloutExtender ID="rvDateB_ValidatorCalloutExtender" runat="server"
                                            Enabled="True" TargetControlID="rvDateB">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:RangeValidator ID="rvDateE" runat="server" ControlToValidate="txtDateE" Display="None"
                                            ErrorMessage="格式不正確" MaximumValue="9999/12/31" MinimumValue="1900/1/1" SetFocusOnError="True"
                                            Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                                        <asp:ValidatorCalloutExtender ID="rvDateE_ValidatorCalloutExtender" runat="server"
                                            Enabled="True" TargetControlID="rvDateE">
                                        </asp:ValidatorCalloutExtender>

                                                                      <asp:RequiredFieldValidator ID="rfvTimeB" runat="server" 
                                        ControlToValidate="txtTimeB" Display="None" ErrorMessage="不允許空白" 
                                        SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvTimeB_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rfvTimeB">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="rfvTimeE" runat="server" 
                                        ControlToValidate="txtTimeE" Display="None" ErrorMessage="不允許空白" 
                                        SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvTimeE_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rfvTimeE">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" 
                                        runat="server" Enabled="True" TargetControlID="rvDateE">
                                    </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <th>
                        主管意見
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNote" runat="server" Height="100px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="updatePanel2" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rblSign" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1">核准</asp:ListItem>
                            <asp:ListItem Value="0">駁回</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="送出傳簽" />
                        <asp:ConfirmButtonExtender ID="btnSubmit_ConfirmButtonExtender" runat="server" ConfirmText="您確定要送出傳簽嗎？"
                            Enabled="True" TargetControlID="btnSubmit">
                        </asp:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
