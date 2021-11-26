<%@ Page Title="" Language="C#" MasterPageFile="~/mpStd0990111.master" AutoEventWireup="true"
    CodeFile="Std.aspx.cs" Inherits="Ot_Std" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblTitle" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblFlowTreeID" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <th colspan="7">
                                    新增加班人員
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    工號
                                </th>
                                <th>
                                    姓名 
                                </th>
                                <th>
                                    給付方式
                                </th>
                                <th>
                                    加班日期
                                </th>
                                <th>
                                    時間 
                                </th>
                                <th>
                                    加班班別</th>
                                <td rowspan="4" align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="新增" ValidationGroup="fv" OnClick="btnAdd_Click"
                                        UseSubmitBehavior="False" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNobr" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" 
                                        DataSourceID="odsName" DataTextField="sNameC" DataValueField="sNobr" 
                                        OnDataBound="ddlName_DataBound" 
                                        OnSelectedIndexChanged="ddlName_SelectedIndexChanged" ValidationGroup="fv">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" CssClass="txtCode" 
                                        OnTextChanged="txtName_TextChanged" ReadOnly="True" ValidationGroup="fv"></asp:TextBox>
                                    ※可輸入工號或姓名 
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlOtCat" runat="server" ValidationGroup="fv">
                                    </asp:DropDownList>
                                </td>
                                <td align="center" nowrap="nowrap">
                                    <asp:TextBox ID="txtDateB" runat="server" CssClass="txtDate" ValidationGroup="fv"
                                        AutoPostBack="True" OnTextChanged="txtDateB_TextChanged"></asp:TextBox>
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
                                    <asp:RequiredFieldValidator ID="rfvDateB" runat="server" ControlToValidate="txtDateB"
                                        Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvDateB_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfvDateB">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RangeValidator ID="rvDateB" runat="server" ControlToValidate="txtDateB" Display="None"
                                        ErrorMessage="格式不正確" MaximumValue="9999/12/31" MinimumValue="1900/1/1" SetFocusOnError="True"
                                        Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                                    <asp:ValidatorCalloutExtender ID="rvDateB_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rvDateB">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td align="center" nowrap="nowrap">
                                                                        自<asp:TextBox ID="txtTimeB" runat="server" CssClass="txtTime" ValidationGroup="fv">0000</asp:TextBox>
                                    至<asp:MaskedEditExtender ID="txtTimeB_MaskedEditExtender" runat="server" AutoComplete="False"
                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="9999" MaskType="Number" TargetControlID="txtTimeB">
                                    </asp:MaskedEditExtender>
                                    <asp:TextBox ID="txtTimeE" runat="server" CssClass="txtTime" ValidationGroup="fv">0000</asp:TextBox>
                                    止<asp:MaskedEditExtender ID="txtTimeE_MaskedEditExtender" runat="server" AutoComplete="False"
                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="9999" MaskType="Number" TargetControlID="txtTimeE">
                                    </asp:MaskedEditExtender>
                                    <asp:RequiredFieldValidator ID="rfvTimeB" runat="server" ControlToValidate="txtTimeB"
                                        Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvTimeB_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfvTimeB">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="rfvTimeE" runat="server" ControlToValidate="txtTimeE"
                                        Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvTimeE_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfvTimeE">
                                    </asp:ValidatorCalloutExtender>
                                    <br />
                                    </td>
                                <td align="center" nowrap="nowrap">
                                    <asp:DropDownList ID="ddlRote" runat="server" AppendDataBoundItems="True" 
                                        DataSourceID="odsRote" DataTextField="sName" DataValueField="sRoteCode" 
                                        OnDataBound="ddlRote_DataBound" ValidationGroup="fv">
                                        <asp:ListItem Value="0">預設班別</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnConvert" runat="server" onclick="btnConvert_Click" 
                                        Text="轉換" />
                                </td>
                            </tr>
                            <tr>
                                <th nowrap="true">
                                    刷卡時間
                                </th>
                                <TD colspan="5" nowrap="true">
                                    <asp:Label ID="lblCard" runat="server"></asp:Label>
                                    <asp:Label ID="lblCardTime" runat="server" Visible="False"></asp:Label>
                                    <asp:DropDownList ID="ddlDepts" runat="server" AppendDataBoundItems="True" 
                                        DataSourceID="odsDepts" DataTextField="sDeptName" DataValueField="sDeptCode" 
                                        OnDataBound="ddlRote_DataBound" ValidationGroup="fv" Visible="False">
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="ckEat" runat="server" Text="沒有休息或沒有用餐" Visible="False" />
                                    <asp:Label ID="lblOt1" runat="server" Visible="False"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;</TD>
                            </tr>
                            <tr>
                                <th nowrap="true">
                                    申請原因 
                                </th>
                                <TD nowrap="true" colspan="5">
                                    <asp:DropDownList ID="ddlOtrcd" runat="server" AutoPostBack="True" 
                                        DataSourceID="odsOtrcd" DataTextField="sOtrName" DataValueField="sOtrCode" 
                                        ValidationGroup="fv">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="txtDescription" 
                                        ValidationGroup="fv" Width="70%"></asp:TextBox>
                                </TD>
                            </tr>
                        </table>
                        <asp:ObjectDataSource ID="odsRote" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="Rote" TypeName="JBHR.Dll.Att"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsOtrcd" runat="server" SelectMethod="OtrcdDisplay" TypeName="JBHR.Dll.Att"
                            OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblNobr" Name="sNobr" PropertyName="Text" 
                                    Type="String" />
                                <asp:Parameter Name="dDate" Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsDepts" runat="server" SelectMethod="Depts" TypeName="JBHR.Dll.Bas">
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsName" runat="server" OldValuesParameterFormatString="original_{0}"
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
                    <td>
                        <asp:Button ID="btnFlow" runat="server" OnClick="btnFlow_Click" Text="進行中流程" UseSubmitBehavior="False" />
                        <asp:Button ID="btnAttendView" runat="server" OnClick="btnAttendView_Click" Text="個人行事曆"
                            UseSubmitBehavior="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <th>
                                    被申請人資料
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAppS" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        DataKeyNames="iAutoKey" DataSourceID="sdsAppS" ForeColor="#333333" GridLines="None"
                                        Width="100%" OnRowDataBound="gvAppS_RowDataBound" 
                                        EnableModelValidation="True">
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="刪除" ToolTip='<%# Eval("iAutoKey") %>' />
                                                    <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText="您確定要刪除嗎？"
                                                        Enabled="True" TargetControlID="btnDelete">
                                                    </asp:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                            <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                            <asp:BoundField DataField="dDateB" HeaderText="加班日期" SortExpression="dDateB" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="sTimeB" HeaderText="開始時間" SortExpression="sTimeB" />
                                            <asp:BoundField DataField="sTimeE" HeaderText="結束時間" SortExpression="sTimeE" />
                                            <asp:BoundField DataField="sOtcatName" HeaderText="給付方式" SortExpression="sOtcatName" />
                                            <asp:BoundField DataField="sRoteName" HeaderText="加班班別" SortExpression="sRoteName" />
                                            <asp:BoundField DataField="iTotalHour" HeaderText="總時數" SortExpression="iTotalHour" />
                                            <asp:BoundField DataField="sReserve1" HeaderText="本月加班時數" 
                                                SortExpression="sReserve1" />
                                            <asp:BoundField DataField="sReserve2" HeaderText="本月補休時數" 
                                                SortExpression="sReserve2" />
                                            <asp:BoundField DataField="sOtrcdName" HeaderText="加班原因" SortExpression="sOtrcdName" />
                                            <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            無申請者資料。
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="sdsAppS" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                        DeleteCommand="DELETE FROM [wfAppOt] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT * FROM [wfAppOt]
WHERE          (sProcessID = @sProcessID)">
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
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="送出傳簽" OnClientClick="return confirm('您確定要送出傳簽嗎？');" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="plPopupFlow" runat="server" CssClass="modalPopup" Style="display: none;"
                            Width="600px">
                            <table cellpadding="0" cellspacing="0" width="100%" class="TableFullBorder">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plDragFlow" runat="server" Style="border-right: gray 1px solid; border-top: gray 1px solid;
                                            border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid;
                                            background-color: #dddddd;">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td nowrap="nowrap">
                                                            <asp:Label ID="lblDragNameFlow" runat="server" Text="進行中流程"></asp:Label>
                                                        </td>
                                                        <th align="right" width="1%">
                                                            <asp:Button ID="btnExitFlow" runat="server" CssClass="ButtonExit" Text="×" OnClick="btnExitFlow_Click" />
                                                        </th>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Label ID="lblFlowID" runat="server" Visible="False"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvFlow" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            DataKeyNames="iAutoKey" DataSourceID="sdsFlow" ForeColor="#333333" GridLines="None"
                                                            Width="100%">
                                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                                                <asp:BoundField DataField="dDateB" HeaderText="加班日期" SortExpression="dDateB" DataFormatString="{0:d}" />
                                                                <asp:BoundField DataField="sTimeB" HeaderText="開始時間" SortExpression="sTimeB" />
                                                                <asp:BoundField DataField="sTimeE" HeaderText="結束時間" SortExpression="sTimeE" />
                                                                <asp:BoundField DataField="sOtcatName" HeaderText="加班費/補休假" SortExpression="sOtcatName" />
                                                                <asp:BoundField DataField="sRoteName" HeaderText="加班班別" SortExpression="sRoteName" />
                                                                <asp:BoundField DataField="iTotalHour" HeaderText="總時數" SortExpression="iTotalHour" />
                                                                <asp:BoundField DataField="sOtrcdName" HeaderText="加班原因" SortExpression="sOtrcdName" />
                                                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                無申請者資料。
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="sdsFlow" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                            SelectCommand="SELECT * FROM wfAppOt
WHERE          (sState = '1') AND (idProcess &lt;&gt; 0) AND (sNobr = @sNobr)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="lblFlowID" DefaultValue="" Name="sNobr" PropertyName="Text" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMsgFlow" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="hiddenTargetControlForModalPopupFlow" runat="server" Style="display: none" />&nbsp;
                        <asp:ModalPopupExtender ID="mpePopupFlow" runat="server" BackgroundCssClass="modalBackground"
                            BehaviorID="programmaticModalPopupBehavior2" DropShadow="true" PopupControlID="plPopupFlow"
                            PopupDragHandleControlID="plDragFlow" RepositionMode="RepositionOnWindowScroll"  X="0" Y="0"
                            TargetControlID="hiddenTargetControlForModalPopupFlow">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="plPopupCalendar" runat="server" CssClass="modalPopup" Style="display: none;"
                            Width="800px">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plDragCalendar" runat="server" Style="border-right: gray 1px solid;
                                            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                                            border-bottom: gray 1px solid; background-color: #dddddd;">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td nowrap="nowrap">
                                                            <asp:Label ID="lblDragNameCalendar" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right" width="1%">
                                                            <asp:Button ID="btnExitCalendar" runat="server" CssClass="ButtonExit" Text="×" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Label ID="lblCalendarID" runat="server" Visible="False"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlYYMM" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYYMM_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:Calendar ID="cldAttendView" runat="server" Width="100%" OnDayRender="cldAttendView_DayRender"
                                                            OnSelectionChanged="cldAttendView_SelectionChanged" OnVisibleMonthChanged="cldAttendView_VisibleMonthChanged"
                                                            SelectionMode="None" BackColor="White" BorderColor="#3366CC" 
                                                            BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" 
                                                            Font-Size="8pt" ForeColor="#003399" Height="200px">
                                                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                            <DayStyle VerticalAlign="Top" />
                                                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                            <OtherMonthDayStyle ForeColor="#999999" />
                                                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                                                                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                            <WeekendDayStyle BackColor="#CCCCFF" />
                                                        </asp:Calendar>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMsgCalendar" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="hiddenTargetControlForModalPopupCalendar" runat="server" Style="display: none" />&nbsp;
                        <asp:ModalPopupExtender ID="mpePopupCalendar" runat="server" BackgroundCssClass="modalBackground"
                            BehaviorID="programmaticModalPopupBehavior3" DropShadow="true" PopupControlID="plPopupCalendar"
                            PopupDragHandleControlID="plDragCalendar" RepositionMode="RepositionOnWindowScroll"  X="0" Y="0"
                            TargetControlID="hiddenTargetControlForModalPopupCalendar">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
