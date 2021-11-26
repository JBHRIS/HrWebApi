<%@ Page Title="" Language="C#" MasterPageFile="~/mpStd0990111.master" AutoEventWireup="true" CodeFile="Std.aspx.cs" Inherits="ShiftShort_Std" %>

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
                                <th colspan="6">
                                    新調班資料</th>
                            </tr>
                            <tr>
                                <th>
                                    工號
                                </th>
                                <th>
                                    姓名</th>
                                <th>
                                    &nbsp;</th>
                                <th>
                                    日期 
                                </th>
                                <th>
                                    班別</th>
                                <td rowspan="4" align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="新增" ValidationGroup="fv" 
                                        OnClick="btnAdd_Click" UseSubmitBehavior="False" Font-Size="12pt" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" rowspan="2">
                                    <asp:Label ID="lblNobr" runat="server"></asp:Label>
                                </td>
                                <td align="center" rowspan="2">
                                    <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" DataSourceID="odsName"
                                        DataTextField="sNameC" DataValueField="sNobr" OnDataBound="ddlName_DataBound"
                                        OnSelectedIndexChanged="ddlName_SelectedIndexChanged" 
                                        ValidationGroup="fv" Font-Size="12pt" >
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" CssClass="txtCode" OnTextChanged="txtName_TextChanged"
                                        ValidationGroup="fv" ReadOnly="True"></asp:TextBox>
                                </td>
                                <th align="center">
                                    原日期</th>
                                <td align="center">
                                    <asp:TextBox ID="txtDateA" runat="server" AutoPostBack="True" 
                                        CssClass="txtDate" ontextchanged="txtDateA_TextChanged" ValidationGroup="fv"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtDateA_MaskedEditExtender" runat="server" 
                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateA">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="txtDateA_CalendarExtender" runat="server" 
                                        CssClass="MyCalendar" Enabled="True" Format="yyyy/MM/dd" 
                                        PopupButtonID="ibtnDateA" TargetControlID="txtDateA">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibtnDateA" runat="server" CausesValidation="False" 
                                        ImageUrl="~/img/Calendar_scheduleHS.png" />
                                    <asp:RequiredFieldValidator ID="rfvDateA" runat="server" 
                                        ControlToValidate="txtDateA" Display="None" ErrorMessage="不允許空白" 
                                        SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvDateA_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rfvDateA">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RangeValidator ID="rvDateA" runat="server" ControlToValidate="txtDateA" 
                                        Display="None" ErrorMessage="格式不正確" MaximumValue="9999/12/31" 
                                        MinimumValue="1900/1/1" SetFocusOnError="True" Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                                    <asp:ValidatorCalloutExtender ID="rvDateA_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rvDateA">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblRoteA" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="center">
                                    換班後</th>
                                <td align="center">
                                    <asp:TextBox ID="txtDateB" runat="server" AutoPostBack="True" 
                                        CssClass="txtDate" ontextchanged="txtDateB_TextChanged" ValidationGroup="fv"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtDateB_MaskedEditExtender" runat="server" 
                                        AcceptNegative="Left" DisplayMoney="Left" Enabled="True" Mask="9999/99/99" 
                                        MaskType="Date" TargetControlID="txtDateB">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="txtDateB_CalendarExtender" runat="server" 
                                        CssClass="MyCalendar" Format="yyyy/MM/dd" PopupButtonID="ibtnDateB" 
                                        TargetControlID="txtDateB">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibtnDateB" runat="server" CausesValidation="False" 
                                        ImageUrl="~/img/Calendar_scheduleHS.png" />
                                    <asp:RequiredFieldValidator ID="rfvDateB" runat="server" 
                                        ControlToValidate="txtDateB" Display="None" ErrorMessage="不允許空白" 
                                        SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvDateB_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rfvDateB">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RangeValidator ID="rvDateB" runat="server" ControlToValidate="txtDateB" 
                                        Display="None" ErrorMessage="格式不正確" MaximumValue="9999/12/31" 
                                        MinimumValue="1900/1/1" SetFocusOnError="True" Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                                    <asp:ValidatorCalloutExtender ID="rvDateB_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rvDateB">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlRote" runat="server" AppendDataBoundItems="True" 
                                        ValidationGroup="fv" Font-Size="12pt">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    申請原因
                                </th>
                                <td colspan="4">
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="txtDescription" ValidationGroup="fv"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:ObjectDataSource ID="odsName" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="EmpBaseByNobrDeptmAll" 
                            TypeName="JBHR.Dll.Bas">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblNobrAppM" Name="sNobr" PropertyName="Text" 
                                    Type="String" />
                                <asp:Parameter DefaultValue="DI" Name="sDI" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:SqlDataSource ID="sdsName" runat="server" ConnectionString="<%$ ConnectionStrings:flow %>"
                            SelectCommand="SELECT Emp.id AS Emp_id, Emp.name FROM Role INNER JOIN Emp ON Role.Emp_id = Emp.id WHERE (GETDATE() BETWEEN Role.dateB AND Role.dateE) ORDER BY Emp.id">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnFlow" runat="server" Text="進行中流程" OnClick="btnFlow_Click" 
                            UseSubmitBehavior="False" Font-Size="12pt" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" >
                            <tr>
                                <th>
                                    被申請人資料
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAppS" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        DataKeyNames="iAutoKey" DataSourceID="sdsAppS" ForeColor="#333333" GridLines="None"
                                        Width="100%">
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete"
                                                        Text="刪除" />
                                                    <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                                        ConfirmText="您確定要刪除嗎？" Enabled="True" TargetControlID="btnDelete">
                                                    </asp:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sNobrA" HeaderText="工號" SortExpression="sNobrA" />
                                            <asp:BoundField DataField="sNameA" HeaderText="姓名" SortExpression="sNameA" />
                                            <asp:BoundField DataField="dDateA" DataFormatString="{0:d}" HeaderText="原日期" 
                                                SortExpression="dDateA" />
                                            <asp:BoundField DataField="sRoteNameA" HeaderText="原班別" 
                                                SortExpression="sRoteNameA" />
                                            <asp:BoundField DataField="dDateB" HeaderText="換班日" SortExpression="dDateB" 
                                                DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="sRoteNameB" HeaderText="換班班別" 
                                                SortExpression="sRoteNameB" />
                                            <asp:BoundField DataField="sNote" HeaderText="原因" SortExpression="sNote" />
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
                                        DeleteCommand="DELETE FROM [wfAppShiftShort] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT * FROM [wfAppShiftShort]
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
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="送出傳簽" 
                            onclientclick="return confirm('您確定要送出傳簽嗎？');" Font-Size="12pt" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="plPopupFlow" runat="server" CssClass="modalPopup" Style="display: none;"
                            Width="600px">
                            <table cellpadding="0" cellspacing="0" width="100%"  class="TableFullBorder">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plDragFlow" runat="server" Style="border-right: gray 1px solid;
                                            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                                            border-bottom: gray 1px solid; background-color: #dddddd;">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td nowrap="nowrap">
                                                            <asp:Label ID="lblDragNameFlow" runat="server" Text="進行中流程"></asp:Label>
                                                        </td>
                                                        <th align="right" width="1%">
                                                            <asp:Button ID="btnExitFlow" runat="server" CssClass="ButtonExit" Text="×" 
                                                                onclick="btnExitFlow_Click" />
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
                                                        <asp:GridView ID="gvFlow" runat="server" AutoGenerateColumns="False" 
                                                            CellPadding="4" DataKeyNames="iAutoKey" DataSourceID="sdsFlow" 
                                                            ForeColor="#333333" GridLines="None" Width="100%">
                                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:BoundField DataField="sNobrA" HeaderText="工號" SortExpression="sNobrA" />
                                                                <asp:BoundField DataField="sNameA" HeaderText="姓名" SortExpression="sNameA" />
                                                                <asp:BoundField DataField="dDateA" DataFormatString="{0:d}" HeaderText="原日期" 
                                                                    SortExpression="dDateA" />
                                                                <asp:BoundField DataField="sRoteNameA" HeaderText="原班別" 
                                                                    SortExpression="sRoteNameA" />
                                                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="換班日" 
                                                                    SortExpression="dDateB" />
                                                                <asp:BoundField DataField="sRoteNameB" HeaderText="換班班別" 
                                                                    SortExpression="sRoteNameB" />
                                                                <asp:BoundField DataField="sNote" HeaderText="原因" SortExpression="sNote" />
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
                                                        <asp:SqlDataSource ID="sdsFlow" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:Flow %>" 
                                                            SelectCommand="SELECT * FROM wfAppShiftShort 
WHERE (sState = '1') AND (idProcess &lt;&gt; 0) AND (sNobrA = @sNobr) OR (sState = '1') AND (idProcess &lt;&gt; 0) AND (sNobrB = @sNobr)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="lblFlowID" Name="sNobr" PropertyName="Text" />
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
                        <asp:ModalPopupExtender ID="mpePopupFlow" runat="server" BackgroundCssClass="modalBackground"  X="0" Y="0"
                            BehaviorID="programmaticModalPopupBehavior2" DropShadow="true" PopupControlID="plPopupFlow"
                            PopupDragHandleControlID="plDragFlow" RepositionMode="RepositionOnWindowScroll"
                            TargetControlID="hiddenTargetControlForModalPopupFlow">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
