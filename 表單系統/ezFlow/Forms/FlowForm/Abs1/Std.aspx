<%@ Page Title="" Language="C#" MasterPageFile="~/mpStd0990111.master" AutoEventWireup="true"
    CodeFile="Std.aspx.cs" Inherits="Abs1_Std" %>

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
                        &nbsp; * 部份資料由人事系統帶出，錯誤請自行更正
                    </td>
                    <th align="right">
                        申請日期
                    </th>
                    <td>
                        <asp:Label ID="lblDateA" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        申請人姓名 / 工號
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" DataSourceID="odsName"
                            DataTextField="sNameC" DataValueField="sNobr" OnDataBound="ddlName_DataBound"
                            OnSelectedIndexChanged="ddlName_SelectedIndexChanged" ValidationGroup="fv" 
                            Visible="False">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" CssClass="txtCode" OnTextChanged="txtName_TextChanged"
                            ValidationGroup="fv" ReadOnly="True"></asp:TextBox>
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
                    <th align="right">
                        代理人姓名 / 工號
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlAgentName" runat="server" AutoPostBack="True" DataSourceID="odsNameA"
                            DataTextField="sNameC" DataValueField="sNobr" ValidationGroup="fv" OnDataBound="ddlAgentName_DataBound"
                            OnSelectedIndexChanged="ddlAgentName_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtAgentName" runat="server" AutoPostBack="True" CssClass="txtCode"
                            ValidationGroup="fv" OnTextChanged="txtAgentName_TextChanged"></asp:TextBox>
                        /<asp:Label ID="lblAgentNobr" runat="server"></asp:Label>
                        &nbsp;※可輸入工號或姓名(可跨部門)<asp:ObjectDataSource ID="odsNameA" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="EmpBaseByNobrDeptmAll" 
                            TypeName="JBHR.Dll.Bas">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="119999" Name="sNobr" Type="String" />
                                <asp:Parameter DefaultValue="DI" Name="sDI" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        部門/職稱
                    </th>
                    <td colspan="3">
                        <asp:Label ID="lblDept" runat="server"></asp:Label>
                        &nbsp;/
                        <asp:Label ID="lblJob" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        &nbsp;出差類別</th>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rblInOut" runat="server" RepeatDirection="Horizontal" 
                            RepeatLayout="Flow">
                            <asp:ListItem Value="0">國內出差</asp:ListItem>
                            <asp:ListItem Value="1">國外出差</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        出差目的
                    </th>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlErrandType" runat="server" DataSourceID="sdsErrandType"
                            DataTextField="sName" DataValueField="sCode" ValidationGroup="fv">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtErrandType" runat="server" CssClass="txtDescription" ValidationGroup="fv"
                            Width="70%"></asp:TextBox>*
                        <asp:SqlDataSource ID="sdsErrandType" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfFormCode]
WHERE          (sCategory = 'Abs1ErrandType') AND (bDisplay = 1)
ORDER BY   iOrder"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="rfvErrandType" runat="server" ControlToValidate="txtErrandType"
                            Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfvErrandType_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="rfvErrandType" PopupPosition="Left">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        工作項目</th>
                    <td colspan="3">
                        <asp:TextBox ID="txtFactoryContact" runat="server" CssClass="txtDescription" 
                            ValidationGroup="fv" Width="70%"></asp:TextBox>
                        <asp:Button ID="btnFactoryContactAdd" runat="server" 
                            CommandArgument="txtContact" CommandName="Abs1FactoryContact" 
                            OnClick="btnFactoryContactAdd_Click" Text="加入" UseSubmitBehavior="False" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="4">
                        <asp:GridView ID="gvFactoryContact" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="iAutoKey" DataSourceID="sdsFactoryContactGV">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" 
                                            CommandName="Delete" Text="刪除" UseSubmitBehavior="False" />
                                        <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender2" runat="server" 
                                            ConfirmText="確定刪除嗎？" Enabled="True" TargetControlID="btnDelete">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sContent" HeaderText="工作項目" 
                                    SortExpression="sContent" />
                            </Columns>
                            <EmptyDataTemplate>
                                目前無工作項目
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsFactoryContactGV" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:Flow %>" 
                            DeleteCommand="DELETE FROM [wfFormAppCode] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT *
 FROM wfFormAppCode 
WHERE (sCategory = 'Abs1FactoryContact') AND (sProcessID = @sProcessID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblProcessID" Name="sProcessID" 
                                    PropertyName="Text" />
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
                            ValidationGroup="fv"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtTimeB_MaskedEditExtender" runat="server" 
                            AutoComplete="False" CultureAMPMPlaceholder="" 
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                            Mask="9999" MaskType="Number" TargetControlID="txtTimeB">
                        </asp:MaskedEditExtender>
                        &nbsp;至
                        <asp:TextBox ID="txtDateE" runat="server" CssClass="txtDate" ValidationGroup="fv"></asp:TextBox>
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
                            ValidationGroup="fv"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtTimeE_MaskedEditExtender" runat="server" 
                            AutoComplete="False" CultureAMPMPlaceholder="" 
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                            Mask="9999" MaskType="Number" TargetControlID="txtTimeE">
                        </asp:MaskedEditExtender>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvDateB" runat="server" ControlToValidate="txtDateB"
                            Display="None" ErrorMessage="不允許空白" ValidationGroup="fv" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvDateE" runat="server" ControlToValidate="txtDateE"
                            Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfvDateE_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="rfvDateE">
                        </asp:ValidatorCalloutExtender>
                        <asp:ValidatorCalloutExtender ID="rfvDateB_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="rfvDateB">
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
                <tr>
                    <th align="right">
                        預定前往地點 / 備註
                    </th>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlPlace1" runat="server" DataSourceID="sdsPlace1" DataTextField="sName"
                            DataValueField="sCode" ValidationGroup="fv" AppendDataBoundItems="True">
                            <asp:ListItem Value="0">請選擇</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtPlace1" runat="server" CssClass="txtDescription" ValidationGroup="fv"
                            Width="50%"></asp:TextBox>
                        <asp:Button ID="btnPlace1Add" runat="server" CommandArgument="txtPlace1" CommandName="Place1"
                            OnClick="btnPlace1Add_Click" Text="加入" UseSubmitBehavior="False" 
                            style="height: 21px" />
                        <asp:SqlDataSource ID="sdsPlace1" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfFormCode]
WHERE          (sCategory = 'Place1') AND (bDisplay = 1)
ORDER BY   iOrder"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvPlace1" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            DataSourceID="sdsPlace1GV">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="刪除" UseSubmitBehavior="False" />
                                        <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender1" runat="server" ConfirmText="確定刪除嗎？"
                                            Enabled="True" TargetControlID="btnDelete">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sName" HeaderText="預定前往地點" 
                                    SortExpression="sName" />
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
                    <th align="right">
                        事項/說明
                    </th>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlTransact" runat="server" DataSourceID="sdsTransact" DataTextField="sName"
                            DataValueField="sCode" ValidationGroup="fv">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtTransact" runat="server" CssClass="txtDescription" ValidationGroup="fv"
                            Width="70%"></asp:TextBox>
                        <asp:Button ID="btnTransactAdd" runat="server" CommandArgument="txtTransact" CommandName="Abs1Transact"
                            OnClick="btnTransactAdd_Click" Text="加入" UseSubmitBehavior="False" />
                        <asp:SqlDataSource ID="sdsTransact" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfFormCode]
WHERE          (sCategory = 'Abs1Transact') AND (bDisplay = 1)
ORDER BY   iOrder"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvTransact" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            DataSourceID="sdsTransactGV">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="刪除" UseSubmitBehavior="False" />
                                        <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText="確定要刪除嗎？"
                                            Enabled="True" TargetControlID="btnDelete">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
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

                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnFlow" runat="server" CausesValidation="False" Text="進行中流程" UseSubmitBehavior="False"
                            Visible="False" />
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
                        <asp:ConfirmButtonExtender ID="btnSubmit_ConfirmButtonExtender" runat="server" ConfirmText="請再次確定成本中心歸屬是否正確，您確定要送出傳簽嗎？"
                            Enabled="True" TargetControlID="btnSubmit">
                        </asp:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
