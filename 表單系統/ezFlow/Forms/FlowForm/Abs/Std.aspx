<%@ Page Title="" Language="C#" MasterPageFile="~/mpStd0990111.master" AutoEventWireup="true"
    CodeFile="Std.aspx.cs" Inherits="Abs_Std" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function fillCell(row, cellNumber, text) {
            var cell = row.insertCell(cellNumber);
            cell.innerHTML = text;
            cell.style.borderBottom = cell.style.borderRight = "solid 1px #aaaaff";
        }
        function addToClientTable(name, text) {
            var table = document.getElementById("<%= clientSide.ClientID %>");
            var row = table.insertRow(0);
            fillCell(row, 0, name);
            fillCell(row, 1, text);
        }

        function uploadError(sender, args) {
            addToClientTable(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");
        }
        function uploadComplete(sender, args) {
            var contentType = args.get_contentType();
            var text = args.get_length() + " bytes";
            if (contentType.length > 0) {
                text += ", '" + contentType + "'";
            }
            //            addToClientTable(args.get_fileName(), text);
            //            document.getElementById("<%= lblDragNameUpload.ClientID %>").innerText = text;
            //            document.getElementById("<%= lblDragNameUpload.ClientID %>").value = text;
            //            __doPostBack('<%= hiddenTargetControlForModalPopupUpload.ClientID %>', '');
            //            this.mpePopupUpload.Show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblTitle" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDate" runat="server"></asp:Label>
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
                                    新增請假人員</th>
                            </tr>
                            <tr>
                                <th>
                                    工號</th>
                                <th>
                                    姓名</th>
                                <th>
                                    假別</th>
                                <th>
                                    起迄日期時間</th>
                                <th>
                                    <asp:Label ID="lblAgent" runat="server" Text="代理人"></asp:Label>
                                    1</th>
                                <th>
                                    代理人2</th>
                                <td rowspan="4">
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增" 
                                        UseSubmitBehavior="False" ValidationGroup="fv" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNobr" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" DataSourceID="odsName"
                                        DataTextField="sNameC" DataValueField="sNobr" OnDataBound="ddlName_DataBound"
                                        OnSelectedIndexChanged="ddlName_SelectedIndexChanged" ValidationGroup="fv">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" CssClass="txtCode" OnTextChanged="txtName_TextChanged"
                                        ValidationGroup="fv" ReadOnly="True"></asp:TextBox>
                                    <br />
                                    ※可輸入工號或姓名</td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlHcode" runat="server" AutoPostBack="True" 
                                        DataSourceID="odsHcode" DataTextField="sName" DataValueField="sHcode" 
                                        OnSelectedIndexChanged="ddlHcode_SelectedIndexChanged" ValidationGroup="fv">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlAname" runat="server" AppendDataBoundItems="True" 
                                        AutoPostBack="True" OnDataBound="ddlAname_DataBound" ValidationGroup="fv" 
                                        Visible="False">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="center">
                                    自<asp:TextBox ID="txtDateB" runat="server" AutoPostBack="True" 
                                        CssClass="txtDate" OnTextChanged="txtDateB_TextChanged" ValidationGroup="fv"></asp:TextBox>
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
                                    <asp:TextBox ID="txtTimeB" runat="server" CssClass="txtTime" 
                                        ValidationGroup="fv">0000</asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtTimeB_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="9999" MaskType="Number" TargetControlID="txtTimeB">
                                    </asp:MaskedEditExtender>
                                    <br />
                                    至<asp:TextBox ID="txtDateE" runat="server" CssClass="txtDate" 
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
                                    <asp:TextBox ID="txtTimeE" runat="server" CssClass="txtTime" 
                                        ValidationGroup="fv">0000</asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtTimeE_MaskedEditExtender" runat="server" 
                                        AutoComplete="False" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="9999" MaskType="Number" TargetControlID="txtTimeE">
                                    </asp:MaskedEditExtender>
                                    <asp:RequiredFieldValidator ID="rfvDateB" runat="server" 
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
                                    <asp:ValidatorCalloutExtender ID="rvDateE_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rvDateE">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlAgentName" runat="server" ValidationGroup="fv" ondatabound="ddlAgentName_DataBound" 
                                        onselectedindexchanged="ddlAgentName_SelectedIndexChanged" 
                                        AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="odsNameA" 
                                        DataTextField="sNameC" DataValueField="sNobr">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:TextBox ID="txtAgentName" runat="server" AutoPostBack="True" 
                                        CssClass="txtCode" OnTextChanged="txtAgentName_TextChanged" 
                                        ValidationGroup="fv"></asp:TextBox>
                                    <asp:Label ID="lblAgentNobr" runat="server" Visible="False"></asp:Label>
                                    <br />
                                    ※可輸入工號或姓名(可跨部門)</td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlAgentName2" runat="server" 
                                        ondatabound="ddlAgentName2_DataBound" 
                                        onselectedindexchanged="ddlAgentName2_SelectedIndexChanged" 
                                        ValidationGroup="fv" AppendDataBoundItems="True" AutoPostBack="True" 
                                        DataSourceID="odsNameA" DataTextField="sNameC" DataValueField="sNobr">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:TextBox ID="txtAgentName2" runat="server" AutoPostBack="True" 
                                        CssClass="txtCode" OnTextChanged="txtAgentName2_TextChanged" 
                                        ValidationGroup="fv"></asp:TextBox>
                                    <asp:Label ID="lblAgentNobr2" runat="server" Visible="False"></asp:Label><br />
                                    ※可輸入工號或姓名(可跨部門)
                                </td>
                            </tr>
                            <tr>
                                <th nowrap="true">
                                    申請原因 
                                </th>
                                <td colspan="5">
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="txtDescription" 
                                        ValidationGroup="fv"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    交辦事項</th>
                                <td colspan="5">
                                    <asp:TextBox ID="txtAgentNote" runat="server" CssClass="txtDescription" ValidationGroup="fv"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:ObjectDataSource ID="odsName" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="EmpBaseByNobrDeptmAll" TypeName="JBHR.Dll.Bas">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblNobrAppM" Name="sNobr" PropertyName="Text" 
                                    Type="String" />
                                <asp:Parameter DefaultValue="DI" Name="sDI" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsNameA" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="EmpBaseByNobrDeptmAll" TypeName="JBHR.Dll.Bas">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="119999" Name="sNobr" Type="String" />
                                <asp:Parameter DefaultValue="DI" Name="sDI" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:LinqDataSource ID="ldsGV" runat="server" 
                            ContextTypeName="dcFormDataContext" EntityTypeName="" TableName="wfAppAgent" 
                            Where="sNobr == @sNobr">
                            <WhereParameters>
                                <asp:ControlParameter ControlID="lblNobr" Name="sNobr" PropertyName="Text" 
                                    Type="String" />
                            </WhereParameters>
                        </asp:LinqDataSource>
                        <asp:ObjectDataSource ID="odsHcode" runat="server" 
                            SelectMethod="HcodeByDisplay" TypeName="JBHR.Dll.Att"
                            OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblNobr" Name="sNobr" PropertyName="Text" 
                                    Type="String" />
                                <asp:Parameter Name="dDate" Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvAbsView" runat="server" DataSourceID="odsAbsView">
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsAbsView" runat="server" SelectMethod="AbsView" TypeName="JBHR.Dll.Att+AbsCal">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblNobr" Name="sNobr" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="txtDateB" Name="dDate" PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="ddlAname" ConvertEmptyStringToNull="False" Name="sName"
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnFlow" runat="server" OnClick="btnFlow_Click" Text="進行中流程"
                            UseSubmitBehavior="False" />
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
                                        Width="100%" OnRowCommand="gvAppS_RowCommand">
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
                                            <asp:BoundField DataField="dDateB" HeaderText="開始日期" SortExpression="dDateB"
                                                DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="sTimeB" HeaderText="開始時間" SortExpression="sTimeB" />
                                            <asp:BoundField DataField="dDateE" HeaderText="結束日期" SortExpression="dDateE"
                                                DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="sTimeE" HeaderText="結束時間" SortExpression="sTimeE" />
                                            <asp:BoundField DataField="sHname" HeaderText="假別" SortExpression="sHname" />
                                            <asp:BoundField DataField="iTotalDay" HeaderText="天數" SortExpression="iTotalDay" />
                                            <asp:BoundField DataField="iTotalHour" HeaderText="時數" SortExpression="iTotalHour" />
                                            <asp:BoundField DataField="sAgentName" HeaderText="代理人1" 
                                                SortExpression="sAgentName" />
                                            <asp:BoundField DataField="sAgentName2" HeaderText="代理人2" 
                                                SortExpression="sAgentName2" />
                                            <asp:TemplateField HeaderText="上傳附件">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnUpload" runat="server" CommandArgument='<%# Bind("iAutoKey") %>'
                                                        Text="附加" CommandName="Upload" ToolTip='<%# Eval("sNobr") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                        DeleteCommand="DELETE FROM [wfAppAbs] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT * FROM [wfAppAbs]
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
                            OnClientClick="return confirm('請再次確定請假時數是否無誤，送出入系統後不得任意更改，您確定要送出傳簽嗎？');" />
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
                                                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="開始日期"
                                                                    SortExpression="dDateB" />
                                                                <asp:BoundField DataField="sTimeB" HeaderText="開始時間" SortExpression="sTimeB" />
                                                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="結束日期"
                                                                    SortExpression="dDateE" />
                                                                <asp:BoundField DataField="sTimeE" HeaderText="結束時間" SortExpression="sTimeE" />
                                                                <asp:BoundField DataField="sHname" HeaderText="假別" SortExpression="sHname" />
                                                                <asp:BoundField DataField="iTotalDay" HeaderText="天數" SortExpression="iTotalDay" />
                                                                <asp:BoundField DataField="iTotalHour" HeaderText="時數" SortExpression="iTotalHour" />
                                                                <asp:BoundField DataField="sAgentName" HeaderText="代理人" SortExpression="sAgentName" />
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
                                                            SelectCommand="SELECT * FROM wfAppAbs
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
                        <asp:ModalPopupExtender ID="mpePopupFlow" runat="server" BackgroundCssClass="modalBackground"  X="0" Y="0"
                            BehaviorID="programmaticModalPopupBehavior2" DropShadow="true" PopupControlID="plPopupFlow"
                            PopupDragHandleControlID="plDragFlow" RepositionMode="RepositionOnWindowScroll"
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
                                                            <asp:Label ID="lblDragNameCalendar" runat="server" Visible="False"></asp:Label>
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
                                                            Font-Size="6pt" ForeColor="#003399" Height="200px">
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
                        <asp:ModalPopupExtender ID="mpePopupCalendar" runat="server" BackgroundCssClass="modalBackground"  X="0" Y="0"
                            BehaviorID="programmaticModalPopupBehavior3" DropShadow="true" PopupControlID="plPopupCalendar"
                            PopupDragHandleControlID="plDragCalendar" RepositionMode="RepositionOnWindowScroll"
                            TargetControlID="hiddenTargetControlForModalPopupCalendar">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="plPopupUpload" runat="server" CssClass="modalPopup" Style="display: none;"
                            Width="600px">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:Panel ID="plDragUpload" runat="server" Style="border-right: gray 1px solid;
                                            border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black;
                                            border-bottom: gray 1px solid; background-color: #dddddd;">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td nowrap="nowrap">
                                                            <asp:Label ID="lblDragNameUpload" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="right" width="1%">
                                                            <asp:Button ID="btnExitUpload" runat="server" CssClass="ButtonExit" Text="×" OnClick="btnExitUpload_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <asp:Label ID="lblUploadID" runat="server" Visible="False"></asp:Label>
                                            <asp:Label ID="lblUploadKey" runat="server" Visible="False"></asp:Label>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvUpload" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            DataKeyNames="iAutoKey" DataSourceID="sdsUpload" ForeColor="#333333" GridLines="None"
                                                            Width="100%" OnRowCommand="gvUpload_RowCommand" OnRowDataBound="gvUpload_RowDataBound">
                                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Bind("iAutoKey") %>'
                                                                            CommandName="Del" Text="刪除" />
                                                                        <asp:ConfirmButtonExtender ID="btnDel_ConfirmButtonExtender" runat="server" ConfirmText="您確定要刪除嗎？"
                                                                            Enabled="True" TargetControlID="btnDelete">
                                                                        </asp:ConfirmButtonExtender>
                                                                        <asp:Button ID="btnDownload" runat="server" CommandArgument='<%# Bind("iAutoKey") %>'
                                                                            CommandName="Download" Text="下載" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="sUpName" HeaderText="上傳名稱" SortExpression="sUpName" />
                                                                <asp:BoundField DataField="sDescription" HeaderText="說明" SortExpression="sDescription" />
                                                                <asp:BoundField DataField="sType" HeaderText="檔案類型" SortExpression="sType" />
                                                                <asp:BoundField DataField="iSize" HeaderText="大小(KB)" SortExpression="iSize" />
                                                                <asp:BoundField DataField="dKeyDate" HeaderText="上傳日期" SortExpression="dKeyDate" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                無上傳任何檔案。
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:SqlDataSource ID="sdsUpload" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                            DeleteCommand="DELETE FROM [wfFormUploadFile] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [wfFormUploadFile] ([sFormCode], [sFormName], [sProcessID], [idProcess], [sNobr], [sKey], [sUpName], [sServerName], [sDescription], [sType], [iSize], [dKeyDate]) VALUES (@sFormCode, @sFormName, @sProcessID, @idProcess, @sNobr, @sKey, @sUpName, @sServerName, @sDescription, @sType, @iSize, @dKeyDate)"
                                                            SelectCommand="SELECT * FROM [wfFormUploadFile] WHERE (([sProcessID] = @sProcessID) AND ([sNobr] = @sNobr) AND ([sKey] = @sKey))"
                                                            UpdateCommand="UPDATE [wfFormUploadFile] SET [sFormCode] = @sFormCode, [sFormName] = @sFormName, [sProcessID] = @sProcessID, [idProcess] = @idProcess, [sNobr] = @sNobr, [sKey] = @sKey, [sUpName] = @sUpName, [sServerName] = @sServerName, [sDescription] = @sDescription, [sType] = @sType, [iSize] = @iSize, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="lblDragNameUpload" Name="sProcessID" PropertyName="Text"
                                                                    Type="String" />
                                                                <asp:ControlParameter ControlID="lblUploadID" Name="sNobr" PropertyName="Text" Type="String" />
                                                                <asp:ControlParameter ControlID="lblUploadKey" Name="sKey" PropertyName="Text" Type="String" />
                                                            </SelectParameters>
                                                            <DeleteParameters>
                                                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                                                            </DeleteParameters>
                                                            <UpdateParameters>
                                                                <asp:Parameter Name="sFormCode" Type="String" />
                                                                <asp:Parameter Name="sFormName" Type="String" />
                                                                <asp:Parameter Name="sProcessID" Type="String" />
                                                                <asp:Parameter Name="idProcess" Type="Int32" />
                                                                <asp:Parameter Name="sNobr" Type="String" />
                                                                <asp:Parameter Name="sKey" Type="String" />
                                                                <asp:Parameter Name="sUpName" Type="String" />
                                                                <asp:Parameter Name="sServerName" Type="String" />
                                                                <asp:Parameter Name="sDescription" Type="String" />
                                                                <asp:Parameter Name="sType" Type="String" />
                                                                <asp:Parameter Name="iSize" Type="Int32" />
                                                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                                                <asp:Parameter Name="iAutoKey" Type="Int32" />
                                                            </UpdateParameters>
                                                            <InsertParameters>
                                                                <asp:Parameter Name="sFormCode" Type="String" />
                                                                <asp:Parameter Name="sFormName" Type="String" />
                                                                <asp:Parameter Name="sProcessID" Type="String" />
                                                                <asp:Parameter Name="idProcess" Type="Int32" />
                                                                <asp:Parameter Name="sNobr" Type="String" />
                                                                <asp:Parameter Name="sKey" Type="String" />
                                                                <asp:Parameter Name="sUpName" Type="String" />
                                                                <asp:Parameter Name="sServerName" Type="String" />
                                                                <asp:Parameter Name="sDescription" Type="String" />
                                                                <asp:Parameter Name="sType" Type="String" />
                                                                <asp:Parameter Name="iSize" Type="Int32" />
                                                                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                                                            </InsertParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        說明：<asp:TextBox ID="txtUpload" runat="server" CssClass="txtDescription"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        檔案：<asp:AsyncFileUpload ID="fu" runat="server" OnUploadedComplete="fu_UploadedComplete"
                                                            OnUploadedFileError="fu_UploadedFileError" OnClientUploadError="uploadError"
                                                            OnClientUploadComplete="uploadComplete" ThrobberID="lblThrobber" />
                                                        <asp:Label ID="lblThrobber" runat="server" Style="display: none">
<img src="../img/uploading.gif" align="absmiddle" alt="loading" />
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnUpload" runat="server" Text="上傳檔案" OnClick="btnUpload_Click" />
                                                        <asp:Label ID="lblMsgUpload" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                        <table style="border-collapse: collapse; border-left: solid 1px #aaaaff; border-top: solid 1px #aaaaff;"
                                                            runat="server" cellpadding="3" id="clientSide" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Button ID="hiddenTargetControlForModalPopupUpload" runat="server" Style="display: none" />&nbsp;
                        <asp:ModalPopupExtender ID="mpePopupUpload" runat="server" BackgroundCssClass="modalBackground" X="0" Y="0"
                            BehaviorID="programmaticModalPopupBehavior4" DropShadow="true" PopupControlID="plPopupUpload"
                            PopupDragHandleControlID="plDragUpload" RepositionMode="RepositionOnWindowScroll" 
                            TargetControlID="hiddenTargetControlForModalPopupUpload">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
