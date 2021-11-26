<%@ Page Title="" Language="C#" MasterPageFile="~/mpMT0990113.master" AutoEventWireup="true"
    CodeFile="ViewFlow.aspx.cs" Inherits="Manage_ViewFlow" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table class="TableFullBorder">
                <tr>
                    <td>
                        <asp:CheckBox ID="ckManage" runat="server" Text="管理" />
                        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重新整理" />
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblPage" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblSort" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvFlow" runat="server" EnableTheming="True" OnRowCommand="gvFlow_RowCommand"
                            OnRowDataBound="gvFlow_RowDataBound">
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                        
                        <asp:SqlDataSource ID="sdsFlow" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT sFormCode, sFormName, sFlowTree FROM wfForm ORDER BY s5">
                        </asp:SqlDataSource>
                        <asp:RangeValidator ID="rvDateB" runat="server" ControlToValidate="txtDateB" Display="None"
                            ErrorMessage="日期格式不正確" MaximumValue="9999/12/31" MinimumValue="1900/1/1" Type="Date"
                            ValidationGroup="View"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="rvDateB_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="rvDateB">
                        </asp:ValidatorCalloutExtender>
                        <asp:RangeValidator ID="rvDateE" runat="server" ControlToValidate="txtDateE" Display="None"
                            ErrorMessage="日期格式不正確" MaximumValue="9999/12/31" MinimumValue="1900/1/1" Type="Date"
                            ValidationGroup="View"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="rvDateE_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="rvDateE">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <th>
                                    表單
                                </th>
                                <th>
                                    狀態
                                </th>
                                <th>
                                    流程序
                                </th>
                                <th>
                                    工號
                                </th>
                                <th>
                                    部門
                                </th>
                                <th>
                                    申請日期
                                </th>
                                <th>
                                    簽核日期
                                </th>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:DropDownList ID="ddlForm" runat="server" DataSourceID="sdsForm" DataTextField="sFormName"
                                        DataValueField="sFormCode">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sdsForm" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                        SelectCommand="SELECT sFormCode, sFormName FROM wfForm ORDER BY s5"></asp:SqlDataSource>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlState" runat="server" DataSourceID="sdsState" DataTextField="sName"
                                        DataValueField="sCode" AppendDataBoundItems="True">
                                        <asp:ListItem Value="-1">全部</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sdsState" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                        
                                        SelectCommand="SELECT sCode, sName FROM wfFormCode WHERE (sCategory = 'State') AND (bDisplay = 1) ORDER BY iOrder">
                                    </asp:SqlDataSource>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtProcessID" runat="server" CssClass="txtCode"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtNobr" runat="server" CssClass="txtCode"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtDept" runat="server" CssClass="txtCode"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtDateB" runat="server" CssClass="txtDate" ValidationGroup="View"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtDateB_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateB">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="txtDateB_CalendarExtender" runat="server" Enabled="True"
                                        PopupButtonID="ibtnDateB" TargetControlID="txtDateB" CssClass="MyCalendar">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibtnDateB" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                                    &nbsp;至<br />
                                    <asp:TextBox ID="txtDateE" runat="server" CssClass="txtDate" ValidationGroup="View"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtDateE_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateE">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="txtDateE_CalendarExtender" runat="server" CssClass="MyCalendar"
                                        Enabled="True" PopupButtonID="ibtnDateE" TargetControlID="txtDateE">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibtnDateE" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtDateA" runat="server" CssClass="txtDate" ValidationGroup="View"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtDateA_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateA">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="txtDateA_CalendarExtender" runat="server" Enabled="True"
                                        PopupButtonID="ibtnDateA" TargetControlID="txtDateA" CssClass="MyCalendar">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibtnDateA" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                                    &nbsp;至<br />
                                    <asp:TextBox ID="txtDateD" runat="server" CssClass="txtDate" ValidationGroup="View"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtDateD_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateD">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="txtDateD_CalendarExtender" runat="server" CssClass="MyCalendar"
                                        Enabled="True" PopupButtonID="ibtnDateD" TargetControlID="txtDateD">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibtnDateD" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnDisplay" runat="server" OnClick="btnDisplay_Click" Text="顯示" ValidationGroup="View" />
                                    <asp:Button ID="btnSql" runat="server" OnClick="btnSql_Click" Text="檢視語法" />
                                </td>
                            </tr>
                            <tr>
                                <th align="center">
                                    執行動作
                                </th>
                                <td align="center">
                                    <asp:DropDownList ID="ddlActive" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlActive_SelectedIndexChanged">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                        <asp:ListItem Value="1">重送流程</asp:ListItem>
                                        <asp:ListItem Value="4">原點重送</asp:ListItem>
                                         <asp:ListItem Value="5">上點重送</asp:ListItem>
                                        <asp:ListItem Value="2">存入資料</asp:ListItem>
                                        <asp:ListItem Value="3">刪除資料</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnActive" runat="server" Text="執行" OnClick="btnActive_Click" OnClientClick="alert('請選擇執行動作');return false;" />
                                </td>
                                <th align="center">
                                    查詢筆數
                                </th>
                                <td align="center">
                                    <asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="ckError" runat="server" Text="僅顯示遺失的流程" />
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="匯出" />
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnSelectAll" runat="server" CommandName="1" 
                                        onclick="btnSelectAll_Click" Text="全選" />
                                    &nbsp;
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <!--
                            <tr>
                                <td  colspan="8" class="style2">
                                    ※核准欄位為"預設核准(打勾)"狀態,若查詢是否核准,請至"流程檢視",點選"內容"即可,確認流程結束及核准。</td>
                            </tr>
                            -->
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvAbs" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnSorting="gv_Sorting" Width="100%"
                            OnRowDataBound="gv_RowDataBound" OnRowCommand="gv_RowCommand" ToolTip="14">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="dDateB" HeaderText="開始日期" SortExpression="dDateB"
                                    DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sTimeB" HeaderText="時間" SortExpression="sTimeB" />
                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="結束日期" SortExpression="dDateE" />
                                <asp:BoundField DataField="sTimeE" HeaderText="時間" SortExpression="sTimeE" />
                                <asp:BoundField DataField="sHname" HeaderText="假別" SortExpression="sHname" />
                                <asp:BoundField DataField="iDay" HeaderText="天數" SortExpression="iDay" />
                                <asp:BoundField DataField="iHour" HeaderText="時數" SortExpression="iHour" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvAbs1" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                            OnSorting="gv_Sorting" ToolTip="12" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                              <%-- <asp:Button ID="btnMessage" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="Message" Text="通知" ToolTip='<%# Eval("sProcessID") %>' />--%>
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="開始日期" SortExpression="dDateB" />
                                <asp:BoundField DataField="sTimeB" HeaderText="時間" SortExpression="sTimeB" />
                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="結束日期" SortExpression="dDateE" />
                                <asp:BoundField DataField="sTimeE" HeaderText="時間" SortExpression="sTimeE" />
                                <asp:BoundField DataField="iTotalDay" HeaderText="時數" SortExpression="iTotalDay" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />

                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvAbs2" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="iAutoKey" OnPageIndexChanging="gv_PageIndexChanging" 
                            OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound" 
                            OnSorting="gv_Sorting" ToolTip="14" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' 
                                            ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView0" runat="server" 
                                            CommandArgument='<%# Eval("sProcessID") %>' CommandName="View" Text="檢視" 
                                            ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" NavigateUrl="#" Target="_blank" 
                                            ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" 
                                    ReadOnly="True" SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" 
                                    SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" 
                                    SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" 
                                    SortExpression="sJobName" />
                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="開始日期" 
                                    SortExpression="dDateB" />
                                <asp:BoundField DataField="sTimeB" HeaderText="時間" SortExpression="sTimeB" />
                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="結束日期" 
                                    SortExpression="dDateE" />
                                <asp:BoundField DataField="sTimeE" HeaderText="時間" SortExpression="sTimeE" />
                                <asp:BoundField DataField="sHname" HeaderText="假別" SortExpression="sHname" />
                                <asp:BoundField DataField="iDay" HeaderText="天數" SortExpression="iDay" />
                                <asp:BoundField DataField="iHour" HeaderText="時數" SortExpression="iHour" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" 
                                    SortExpression="dKeyDate" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvOt" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnSorting="gv_Sorting" Width="100%"
                            OnRowDataBound="gv_RowDataBound" OnRowCommand="gv_RowCommand" ToolTip="13">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="sOtcatName" HeaderText="給付方式" 
                                    SortExpression="sOtcatName" />
                                <asp:BoundField DataField="sOtrcdName" HeaderText="加班原因" SortExpression="sOtrcdName" />
                                <asp:BoundField DataField="dDateB" HeaderText="加班日期" SortExpression="dDateB"
                                    DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sTimeB" HeaderText="開始時間" SortExpression="sTimeB" />
                                <asp:BoundField DataField="sTimeE" HeaderText="結束時間" SortExpression="sTimeE" />
                                <asp:BoundField DataField="iTotalHour" HeaderText="時數" SortExpression="iTotalHour" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="sRoteName" HeaderText="加班班別" 
                                    SortExpression="sRoteName" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                        </asp:GridView>
                        <asp:GridView ID="gvForm" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnSorting="gv_Sorting" Width="100%"
                            OnRowDataBound="gv_RowDataBound" OnRowCommand="gv_RowCommand" ToolTip="11">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="sNameF" HeaderText="文件名稱" SortExpression="sNameF" />
                                <asp:BoundField DataField="iPage" HeaderText="份" SortExpression="iPage" />
                                <asp:BoundField DataField="dDateIn" HeaderText="到職日" SortExpression="dDateIn" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="dDateD" HeaderText="需求日" SortExpression="dDateD" DataFormatString="{0:d}" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                        </asp:GridView>
                        <asp:GridView ID="gvCard" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                            OnSorting="gv_Sorting" Width="100%" ToolTip="10">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="忘刷日期" SortExpression="dDate" />
                                <asp:BoundField DataField="sTime" HeaderText="忘刷時間" SortExpression="sTime" />
                                <asp:BoundField DataField="sReserve1" HeaderText="忘刷原因" SortExpression="sReserve1" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                        </asp:GridView>
                        <asp:GridView ID="gvAbsc" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                            OnSorting="gv_Sorting" Width="100%" ToolTip="12">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                <asp:BoundField DataField="dDate" HeaderText="開始日期" SortExpression="dDate"
                                    DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sTime" HeaderText="時間" SortExpression="sTime" />

                                <asp:BoundField DataField="sHname" HeaderText="假別" SortExpression="sHname" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="核准" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                        </asp:GridView>
                        <asp:GridView ID="gvShiftShort" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                            OnSorting="gv_Sorting" ToolTip="9" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sNameA" HeaderText="姓名" SortExpression="sNameA" />
                                <asp:BoundField DataField="dDateA" HeaderText="原日期" SortExpression="dDateA" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sRoteA" HeaderText="原班別" SortExpression="sRoteA" />
                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="換班日期" SortExpression="dDateB" />
                                <asp:BoundField DataField="sRoteB" HeaderText="換班班別" SortExpression="sRoteB" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                        </asp:GridView>
                        <asp:GridView ID="gvShiftLong" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                            OnSorting="gv_Sorting" ToolTip="8" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sRotetNameA" HeaderText="原本班別" 
                                    SortExpression="sRotetNameA" />
                                <asp:BoundField DataField="dDate" HeaderText="調班日期" SortExpression="dDate" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sRotetName" HeaderText="調班後班別" 
                                    SortExpression="sRotetName" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                        </asp:GridView>
                        <asp:GridView ID="gvReturn" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            OnPageIndexChanging="gv_PageIndexChanging" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound"
                            OnSorting="gv_Sorting" ToolTip="9" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckActive" runat="server" ToolTip='<%# Eval("sProcessID") %>' ValidationGroup='<%# Eval("iAutoKey") %>' />
                                        <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="View" Text="檢視" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>內容</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="自動編號" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="流程序號" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sIntentionName" HeaderText="返台目的" SortExpression="sIntentionName" />
                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="停留開始日" SortExpression="dDateB" />
                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="停留結束日" SortExpression="dDateE" />
                                <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="報到日" SortExpression="dDate" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="申請日期" SortExpression="dKeyDate" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="sdsView" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            SelectCommand="SELECT * FROM [wfAppOt]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSql" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="plPopupView" runat="server" CssClass="modalPopup" Style="display: none;"
                            Width="700px">
                            <table class="TableFullBorder" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plDragView" runat="server" Style="border-right: gray 1px solid; border-top: gray 1px solid;
                                            border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid;
                                            background-color: #dddddd;">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td nowrap="nowrap">
                                                            <asp:Label ID="lblDragNameView" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right" width="1%">
                                                            <asp:Button ID="btnExitView" runat="server" CssClass="ButtonExit" Text="×" OnClick="btnExitView_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Label ID="lblViewID" runat="server" Visible="False"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="plOverflow" runat="server">
                                            <tr>
                                                <th>
                                                    申請人資料
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvAppM" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                                                        Width="100%" DataSourceID="sdsAppM">
                                                        <Columns>
                                                            <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                                            <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                                            <asp:BoundField DataField="sDeptName" HeaderText="部門" SortExpression="sDeptName" />
                                                            <asp:BoundField DataField="sJobName" HeaderText="職稱" SortExpression="sJobName" />
                                                            <asp:CheckBoxField DataField="bSign" HeaderText="是否申請" SortExpression="bSign" />
                                                            <asp:BoundField DataField="sState" HeaderText="狀態" SortExpression="sState" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:SqlDataSource ID="sdsAppM" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                        SelectCommand="SELECT *
 FROM wfFormApp WHERE (sProcessID = '')"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    審核者資料
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                <asp:GridView ID="gvSignM" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            DataSourceID="sdsSignM" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                <asp:BoundField DataField="sDept" HeaderText="部門代碼" SortExpression="sDept" 
                                    Visible="False" />
                                <asp:BoundField DataField="sDeptName" HeaderText="部門名稱" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sNote" HeaderText="備註" SortExpression="sNote" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="申請" SortExpression="bSign" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="簽核日期" SortExpression="dKeyDate" />
                            </Columns>
                        </asp:GridView>
                                                    <asp:SqlDataSource ID="sdsSignM" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                        SelectCommand="SELECT *
 FROM wfFormSignM WHERE (sProcessID = '')"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvProcess" runat="server" AutoGenerateColumns="False" DataSourceID="sdsProcess"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="Role_idDefault" HeaderText="角色(D)" SortExpression="Role_idDefault"
                                                                Visible="False" />
                                                            <asp:BoundField DataField="Emp_idDefault" HeaderText="工號(D)" SortExpression="Emp_idDefault" />
                                                            <asp:BoundField DataField="Emp_nameDefault" HeaderText="姓名(D)" SortExpression="Emp_nameDefault" />
                                                            <asp:BoundField DataField="Role_idAgent" HeaderText="角色(A)" SortExpression="Role_idAgent"
                                                                Visible="False" />
                                                            <asp:BoundField DataField="Emp_idAgent" HeaderText="工號(A)" SortExpression="Emp_idAgent" />
                                                            <asp:BoundField DataField="Emp_nameAgent" HeaderText="姓名(A)" SortExpression="Emp_nameAgent" />
                                                            <asp:BoundField DataField="Role_idReal" HeaderText="角色(R)" SortExpression="Role_idReal"
                                                                Visible="False" />
                                                            <asp:BoundField DataField="Emp_idReal" HeaderText="工號(R)" SortExpression="Emp_idReal" />
                                                            <asp:BoundField DataField="Emp_nameReal" HeaderText="姓名(R)" SortExpression="Emp_nameReal" />
                                                            <asp:BoundField DataField="ProcessNode_adate" HeaderText="開始日" SortExpression="ProcessNode_adate" />
                                                            <asp:BoundField DataField="ProcessCheck_adate" HeaderText="簽結日" SortExpression="ProcessCheck_adate" />
                                                            <asp:CheckBoxField DataField="ProcessNode_isFinish" HeaderText="完成" SortExpression="ProcessNode_isFinish" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:SqlDataSource ID="sdsProcess" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                        SelectCommand="SELECT ProcessCheck.Role_idDefault, ProcessCheck.Emp_idDefault, Emp_2.name AS Emp_nameDefault, ProcessCheck.Role_idAgent, ProcessCheck.Emp_idAgent, Emp_1.name AS Emp_nameAgent, ProcessCheck.Role_idReal, ProcessCheck.Emp_idReal, Emp.name AS Emp_nameReal, ProcessNode.adate AS ProcessNode_adate, ProcessCheck.adate AS ProcessCheck_adate, ProcessNode.isFinish AS ProcessNode_isFinish FROM ProcessFlow INNER JOIN ProcessNode ON ProcessFlow.id = ProcessNode.ProcessFlow_id INNER JOIN ProcessCheck ON ProcessNode.auto = ProcessCheck.ProcessNode_auto LEFT OUTER JOIN Emp ON ProcessCheck.Emp_idReal = Emp.id LEFT OUTER JOIN Emp AS Emp_2 ON ProcessCheck.Emp_idDefault = Emp_2.id LEFT OUTER JOIN Emp AS Emp_1 ON ProcessCheck.Emp_idAgent = Emp_1.id WHERE (ProcessFlow.id = @id) ORDER BY ProcessNode.auto">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="lblViewID" Name="id" PropertyName="Text" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    ※(D)原簽核者；(A)代理簽核者；(R)實際簽核者
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMsgView" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="hiddenTargetControlForModalPopupView" runat="server" Style="display: none"
                            UseSubmitBehavior="False" />
                        <asp:ModalPopupExtender ID="mpePopupView" runat="server" BackgroundCssClass="modalBackground"
                            DropShadow="true" PopupControlID="plPopupView" PopupDragHandleControlID="plDragView"
                            CancelControlID="btnExitView" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopupView">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
