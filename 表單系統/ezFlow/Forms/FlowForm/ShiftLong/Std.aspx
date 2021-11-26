<%@ Page Title="" Language="C#" MasterPageFile="~/mpStd0990111.master" AutoEventWireup="true"
    CodeFile="Std.aspx.cs" Inherits="ShiftLong_Std" %>

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
                                <th colspan="5">
                                    新調班資料
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
                                    目前班別
                                </th>
                                <th>
                                    調班日期
                                </th>
                                <td rowspan="4" align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="新增" ValidationGroup="fv" OnClick="btnAdd_Click"
                                        UseSubmitBehavior="False" Font-Size="12pt" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNobr" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" DataSourceID="odsName"
                                        DataTextField="sNameC" DataValueField="sNobr" OnDataBound="ddlName_DataBound"
                                        OnSelectedIndexChanged="ddlName_SelectedIndexChanged" ValidationGroup="fv" 
                                        Font-Size="12pt">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" CssClass="txtCode" OnTextChanged="txtName_TextChanged"
                                        ValidationGroup="fv" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblRotet" runat="server"></asp:Label>
                                    <asp:Label ID="lblHoli" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblOtRate" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtDateA" runat="server" CssClass="txtDate" OnTextChanged="txtDateA_TextChanged"
                                        ValidationGroup="fv"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtDateA_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateA">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="txtDateA_CalendarExtender" runat="server" CssClass="MyCalendar"
                                        Enabled="True" Format="yyyy/MM/dd" PopupButtonID="ibtnDateA" TargetControlID="txtDateA">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibtnDateA" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                                    <asp:RequiredFieldValidator ID="rfvDateA" runat="server" ControlToValidate="txtDateA"
                                        Display="None" ErrorMessage="不允許空白" SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvDateA_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rfvDateA">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RangeValidator ID="rvDateA" runat="server" ControlToValidate="txtDateA" Display="None"
                                        ErrorMessage="格式不正確" MaximumValue="9999/12/31" MinimumValue="1900/1/1" SetFocusOnError="True"
                                        Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                                    <asp:ValidatorCalloutExtender ID="rvDateA_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="rvDateA">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    調班後班別</th>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlRotet" runat="server" Font-Size="12pt">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlHoli" runat="server" DataSourceID="ldsHoli" 
                                        DataTextField="sHoliName" DataValueField="sHoliCode" style="margin-top: 0px" 
                                        Visible="False">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlOtRate" runat="server" DataSourceID="ldsOtRate" 
                                        DataTextField="sOtRateName" DataValueField="sOtRateCode" Visible="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    申請原因 
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="txtDescription" 
                                        ValidationGroup="fv"></asp:TextBox>
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
                        <asp:ObjectDataSource ID="odsRotet" runat="server" SelectMethod="Rotet" 
                            TypeName="JBHR.Dll.Att"></asp:ObjectDataSource>
                        <asp:LinqDataSource ID="ldsHoli" runat="server" ContextTypeName="JBHR.Dll.dcAttDataContext"
                            Select="new (sHoliCode, sHoliName)" TableName="JB_HR_Holicd">
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="ldsOtRate" runat="server" ContextTypeName="JBHR.Dll.dcAttDataContext"
                            Select="new (sOtRateCode, sOtRateName)" TableName="JB_HR_OtRate">
                        </asp:LinqDataSource>
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
                                        Width="100%">
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="刪除" />
                                                    <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" ConfirmText="您確定要刪除嗎？"
                                                        Enabled="True" TargetControlID="btnDelete">
                                                    </asp:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                            <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                            <asp:BoundField DataField="sRotetNameA" HeaderText="原班別" SortExpression="sRotetNameA" />
                                            <asp:BoundField DataField="sHoliNameA" HeaderText="原行事曆" SortExpression="sHoliNameA"
                                                Visible="False" />
                                            <asp:BoundField DataField="sOtRateNameA" HeaderText="原加班別" SortExpression="sOtRateNameA"
                                                Visible="False" />
                                            <asp:BoundField DataField="dDate" HeaderText="日期" SortExpression="dDate" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="sRotetName" HeaderText="調班別" SortExpression="sRotetName" />
                                            <asp:BoundField DataField="sHoliName" HeaderText="調行事曆" SortExpression="sHoliName"
                                                Visible="False" />
                                            <asp:BoundField DataField="sOtRateName" HeaderText="調加班別" SortExpression="sOtRateName"
                                                Visible="False" />
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
                                        DeleteCommand="DELETE FROM [wfAppShiftLong] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT * FROM [wfAppShiftLong]
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
                            OnClientClick="return confirm('您確定要送出傳簽嗎？');" Font-Size="12pt" />
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
                                                        <asp:GridView ID="gvAppS0" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            DataKeyNames="iAutoKey" DataSourceID="sdsFlow" ForeColor="#333333" GridLines="None"
                                                            Width="100%">
                                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr" />
                                                                <asp:BoundField DataField="sName" HeaderText="姓名" SortExpression="sName" />
                                                                <asp:BoundField DataField="sRotetNameA" HeaderText="原班別" SortExpression="sRotetNameA" />
                                                                <asp:BoundField DataField="sHoliNameA" HeaderText="原行事曆" SortExpression="sHoliNameA"
                                                                    Visible="False" />
                                                                <asp:BoundField DataField="sOtRateNameA" HeaderText="原加班別" SortExpression="sOtRateNameA"
                                                                    Visible="False" />
                                                                <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="調班日期" 
                                                                    SortExpression="dDate" />
                                                                <asp:BoundField DataField="sRotetName" HeaderText="調班別" SortExpression="sRotetName" />
                                                                <asp:BoundField DataField="sHoliName" HeaderText="調行事曆" SortExpression="sHoliName"
                                                                    Visible="False" />
                                                                <asp:BoundField DataField="sOtRateName" HeaderText="調加班別" SortExpression="sOtRateName"
                                                                    Visible="False" />
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
                                                        <asp:SqlDataSource ID="sdsFlow" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                            SelectCommand="SELECT * FROM wfAppShiftLong 
WHERE (sState = '1') AND (idProcess &lt;&gt; 0) AND (sNobr = @sNobr) ">
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
                        <asp:ModalPopupExtender ID="mpePopupFlow" runat="server" BackgroundCssClass="modalBackground"
                            BehaviorID="programmaticModalPopupBehavior2" DropShadow="true" PopupControlID="plPopupFlow"  X="0" Y="0"
                            PopupDragHandleControlID="plDragFlow" RepositionMode="RepositionOnWindowScroll"
                            TargetControlID="hiddenTargetControlForModalPopupFlow">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
