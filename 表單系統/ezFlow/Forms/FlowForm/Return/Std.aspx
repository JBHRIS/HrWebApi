<%@ Page Title="" Language="C#" MasterPageFile="~/mpStd0990111.master" AutoEventWireup="true"
    CodeFile="Std.aspx.cs" Inherits="Return_Std" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            <asp:Label ID="lblFlowTree" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblFlowTreeID" runat="server" Visible="False"></asp:Label>
            <table align="center" class="TableFullBorder">
                <tr>
                    <th align="center" colspan="2" nowrap="true" width="1%">
                        被申請人資料
                    </th>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        返台目的 / 備註
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlIntention" runat="server">
                            <asp:ListItem Value="1">返台假</asp:ListItem>
                            <asp:ListItem Value="2">公差</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtNote" runat="server" CssClass="txtDescription" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        申請人姓名 / 工號
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" DataSourceID="odsName"
                            DataTextField="sNameC" DataValueField="sNobr" OnDataBound="ddlName_DataBound"
                            OnSelectedIndexChanged="ddlName_SelectedIndexChanged" ValidationGroup="fv" 
                            Visible="False">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" CssClass="txtCode" OnTextChanged="txtName_TextChanged"
                            ReadOnly="True" ValidationGroup="fv"></asp:TextBox>
                        /<asp:Label ID="lblNobr" runat="server"></asp:Label>
                        &nbsp;※可輸入工號或姓名<asp:ObjectDataSource ID="odsName" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="EmpBaseByNobrDeptmAll" TypeName="JBHR.Dll.Bas">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblNobrAppM" Name="sNobr" PropertyName="Text" 
                                    Type="String" />
                                <asp:Parameter DefaultValue="DI" Name="sDI" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        申請人部門</th>
                    <td>
                        <asp:Label ID="lblDept" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        申請人職稱</th>
                    <td>
                        <asp:Label ID="lblJob" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        代理人姓名 / 工號 / 部門</th>
                    <td>
                        <asp:TextBox ID="txtAgentName" runat="server" CssClass="txtBoxLine" 
                            ValidationGroup="fv"></asp:TextBox>
                        &nbsp;/&nbsp;<asp:TextBox ID="txtAgentNobr" runat="server" CssClass="txtBoxLine" 
                            ValidationGroup="fv"></asp:TextBox>
                        &nbsp;/
                        <asp:TextBox ID="txtAgentDept" runat="server" CssClass="txtBoxLine" 
                            ValidationGroup="fv"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        今年已申請時數</th>
                    <td>
                        <asp:Label ID="lblHour" runat="server" Text="0"></asp:Label>
                        小時</td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        預計回台停留期間 
                    </th>
                    <td>
                        <asp:TextBox ID="txtDateB" runat="server" CssClass="txtDate" 
                            ValidationGroup="fv"></asp:TextBox>
                        <asp:CalendarExtender ID="txtDateB_CalendarExtender" runat="server" 
                            CssClass="MyCalendar" DaysModeTitleFormat="yyyy/MM" Enabled="True" 
                            Format="yyyy/MM/dd" PopupButtonID="ibtnDateB" TargetControlID="txtDateB" 
                            TodaysDateFormat="yyyy/MM/dd">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="txtDateB_MaskedEditExtender" runat="server" 
                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                            Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateB">
                        </asp:MaskedEditExtender>
                        <asp:ImageButton ID="ibtnDateB" runat="server" CausesValidation="False" 
                            ImageUrl="~/img/Calendar_scheduleHS.png" />
                        &nbsp;至&nbsp;<asp:TextBox ID="txtDateE" runat="server" CssClass="txtDate" 
                            ValidationGroup="fv"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtDateE_MaskedEditExtender" runat="server" 
                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                            Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateE">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="txtDateE_CalendarExtender" runat="server" 
                            CssClass="MyCalendar" DaysModeTitleFormat="yyyy/MM" Enabled="True" 
                            Format="yyyy/MM/dd" PopupButtonID="ibtnDateE" TargetControlID="txtDateE" 
                            TodaysDateFormat="yyyy/MM/dd">
                        </asp:CalendarExtender>
                        <asp:ImageButton ID="ibtnDateE" runat="server" CausesValidation="False" 
                            ImageUrl="~/img/Calendar_scheduleHS.png" />
                        &nbsp; 
                        <asp:TextBox ID="txtTotalDay" runat="server" CssClass="txtNumber" 
                            ValidationGroup="fv" Visible="False"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvDateB" runat="server" 
                            ControlToValidate="txtDateB" Display="None" ErrorMessage="不允許空白" 
                            SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfvDateB_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="rfvDateB">
                        </asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="rfvDateE" runat="server" 
                            ControlToValidate="txtDateE" Display="None" ErrorMessage="不允許空白" 
                            SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfvDateE_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="rfvDateE">
                        </asp:ValidatorCalloutExtender>
                        <asp:RangeValidator ID="rvDateB" runat="server" ControlToValidate="txtDateB" 
                            Display="None" ErrorMessage="格式不正確" MaximumValue="9999/12/31" 
                            MinimumValue="1900/1/1" SetFocusOnError="True" Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="rvDateB_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="rvDateB">
                        </asp:ValidatorCalloutExtender>
                        <asp:RangeValidator ID="rvDateE" runat="server" ControlToValidate="txtDateE" 
                            Display="None" ErrorMessage="格式不正確" MaximumValue="9999/12/31" 
                            MinimumValue="1900/1/1" SetFocusOnError="True" Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="rvDateE_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="rvDateE">
                        </asp:ValidatorCalloutExtender>
                        <asp:RequiredFieldValidator ID="rfvTotalDay" runat="server" 
                            ControlToValidate="txtTotalDay" Display="None" ErrorMessage="不允許空白" 
                            SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfvTotalDay_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="rfvTotalDay">
                        </asp:ValidatorCalloutExtender>
                        <asp:RangeValidator ID="rvTotalDay" runat="server" 
                            ControlToValidate="txtTotalDay" Display="None" ErrorMessage="格式不正確" 
                            MaximumValue="9999" MinimumValue="0" SetFocusOnError="True" Type="Double" 
                            ValidationGroup="fv"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="rvTotalDay_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="rvTotalDay">
                        </asp:ValidatorCalloutExtender>
                        <asp:Button ID="btnCal" runat="server" OnClick="btnCal_Click" Text="試算" 
                            Visible="False" />
                        </td>
                </tr>
                <tr>
                    <th align="right" nowrap="true" width="1%">
                        預計回日期
                    </th>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" CssClass="txtDate" ValidationGroup="fv"></asp:TextBox>
                        <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" CssClass="MyCalendar"
                            DaysModeTitleFormat="yyyy/MM" Enabled="True" Format="yyyy/MM/dd" PopupButtonID="ibtnDate"
                            TargetControlID="txtDate" TodaysDateFormat="yyyy/MM/dd">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="txtDate_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDate">
                        </asp:MaskedEditExtender>
                        <asp:ImageButton ID="ibtnDate" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                        <asp:RangeValidator ID="rvDate" runat="server" ControlToValidate="txtDate" Display="None"
                            ErrorMessage="格式不正確" MaximumValue="9999/12/31" MinimumValue="1900/1/1" SetFocusOnError="True"
                            Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="rvDate_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="rvDate">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th align="center" colspan="2" nowrap="true" width="1%">
                        原單位(海外廠)交待事項
                    </th>
                </tr>
                <tr>
                    <td nowrap="true" colspan="2" width="1%">
                        <asp:TextBox ID="txtOrginal" Height="100px" Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="center" colspan="2" nowrap="true" width="1%">
                        總公司交待事項
                    </th>
                </tr>
                <tr>
                    <td colspan="2" nowrap="true" width="1%">
                        <asp:TextBox ID="txtHeadquarters" Height="100px" Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="送出傳簽" ValidationGroup="fv" />
                        <asp:ConfirmButtonExtender ID="btnSubmit_ConfirmButtonExtender" runat="server" ConfirmText="您確定要送出傳簽嗎？"
                            Enabled="True" TargetControlID="btnSubmit">
                        </asp:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
