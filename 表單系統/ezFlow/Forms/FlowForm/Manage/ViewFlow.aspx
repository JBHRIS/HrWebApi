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
                        <asp:CheckBox ID="ckManage" runat="server" Text="�޲z" />
                        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="���s��z" />
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
                            ErrorMessage="����榡�����T" MaximumValue="9999/12/31" MinimumValue="1900/1/1" Type="Date"
                            ValidationGroup="View"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="rvDateB_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="rvDateB">
                        </asp:ValidatorCalloutExtender>
                        <asp:RangeValidator ID="rvDateE" runat="server" ControlToValidate="txtDateE" Display="None"
                            ErrorMessage="����榡�����T" MaximumValue="9999/12/31" MinimumValue="1900/1/1" Type="Date"
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
                                    ���
                                </th>
                                <th>
                                    ���A
                                </th>
                                <th>
                                    �y�{��
                                </th>
                                <th>
                                    �u��
                                </th>
                                <th>
                                    ����
                                </th>
                                <th>
                                    �ӽФ��
                                </th>
                                <th>
                                    ñ�֤��
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
                                        <asp:ListItem Value="-1">����</asp:ListItem>
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
                                    &nbsp;��<br />
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
                                    &nbsp;��<br />
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
                                    <asp:Button ID="btnDisplay" runat="server" OnClick="btnDisplay_Click" Text="���" ValidationGroup="View" />
                                    <asp:Button ID="btnSql" runat="server" OnClick="btnSql_Click" Text="�˵��y�k" />
                                </td>
                            </tr>
                            <tr>
                                <th align="center">
                                    ����ʧ@
                                </th>
                                <td align="center">
                                    <asp:DropDownList ID="ddlActive" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlActive_SelectedIndexChanged">
                                        <asp:ListItem Value="0">�п��</asp:ListItem>
                                        <asp:ListItem Value="1">���e�y�{</asp:ListItem>
                                        <asp:ListItem Value="4">���I���e</asp:ListItem>
                                         <asp:ListItem Value="5">�W�I���e</asp:ListItem>
                                        <asp:ListItem Value="2">�s�J���</asp:ListItem>
                                        <asp:ListItem Value="3">�R�����</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnActive" runat="server" Text="����" OnClick="btnActive_Click" OnClientClick="alert('�п�ܰ���ʧ@');return false;" />
                                </td>
                                <th align="center">
                                    �d�ߵ���
                                </th>
                                <td align="center">
                                    <asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="ckError" runat="server" Text="����ܿ򥢪��y�{" />
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="�ץX" />
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnSelectAll" runat="server" CommandName="1" 
                                        onclick="btnSelectAll_Click" Text="����" />
                                    &nbsp;
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>
                            </tr>
                            <!--
                            <tr>
                                <td  colspan="8" class="style2">
                                    ���֭���쬰"�w�]�֭�(����)"���A,�Y�d�߬O�_�֭�,�Ц�"�y�{�˵�",�I��"���e"�Y�i,�T�{�y�{�����ή֭�C</td>
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                <asp:BoundField DataField="dDateB" HeaderText="�}�l���" SortExpression="dDateB"
                                    DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sTimeB" HeaderText="�ɶ�" SortExpression="sTimeB" />
                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="�������" SortExpression="dDateE" />
                                <asp:BoundField DataField="sTimeE" HeaderText="�ɶ�" SortExpression="sTimeE" />
                                <asp:BoundField DataField="sHname" HeaderText="���O" SortExpression="sHname" />
                                <asp:BoundField DataField="iDay" HeaderText="�Ѽ�" SortExpression="iDay" />
                                <asp:BoundField DataField="iHour" HeaderText="�ɼ�" SortExpression="iHour" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                              <%-- <asp:Button ID="btnMessage" runat="server" CommandArgument='<%# Eval("sProcessID") %>'
                                            CommandName="Message" Text="�q��" ToolTip='<%# Eval("sProcessID") %>' />--%>
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="�}�l���" SortExpression="dDateB" />
                                <asp:BoundField DataField="sTimeB" HeaderText="�ɶ�" SortExpression="sTimeB" />
                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="�������" SortExpression="dDateE" />
                                <asp:BoundField DataField="sTimeE" HeaderText="�ɶ�" SortExpression="sTimeE" />
                                <asp:BoundField DataField="iTotalDay" HeaderText="�ɼ�" SortExpression="iTotalDay" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />

                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                            CommandArgument='<%# Eval("sProcessID") %>' CommandName="View" Text="�˵�" 
                                            ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" NavigateUrl="#" Target="_blank" 
                                            ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" 
                                    ReadOnly="True" SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" 
                                    SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" 
                                    SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" 
                                    SortExpression="sJobName" />
                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="�}�l���" 
                                    SortExpression="dDateB" />
                                <asp:BoundField DataField="sTimeB" HeaderText="�ɶ�" SortExpression="sTimeB" />
                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="�������" 
                                    SortExpression="dDateE" />
                                <asp:BoundField DataField="sTimeE" HeaderText="�ɶ�" SortExpression="sTimeE" />
                                <asp:BoundField DataField="sHname" HeaderText="���O" SortExpression="sHname" />
                                <asp:BoundField DataField="iDay" HeaderText="�Ѽ�" SortExpression="iDay" />
                                <asp:BoundField DataField="iHour" HeaderText="�ɼ�" SortExpression="iHour" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" 
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                <asp:BoundField DataField="sOtcatName" HeaderText="���I�覡" 
                                    SortExpression="sOtcatName" />
                                <asp:BoundField DataField="sOtrcdName" HeaderText="�[�Z��]" SortExpression="sOtrcdName" />
                                <asp:BoundField DataField="dDateB" HeaderText="�[�Z���" SortExpression="dDateB"
                                    DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sTimeB" HeaderText="�}�l�ɶ�" SortExpression="sTimeB" />
                                <asp:BoundField DataField="sTimeE" HeaderText="�����ɶ�" SortExpression="sTimeE" />
                                <asp:BoundField DataField="iTotalHour" HeaderText="�ɼ�" SortExpression="iTotalHour" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="sRoteName" HeaderText="�[�Z�Z�O" 
                                    SortExpression="sRoteName" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                <asp:BoundField DataField="sNameF" HeaderText="���W��" SortExpression="sNameF" />
                                <asp:BoundField DataField="iPage" HeaderText="��" SortExpression="iPage" />
                                <asp:BoundField DataField="dDateIn" HeaderText="��¾��" SortExpression="dDateIn" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="dDateD" HeaderText="�ݨD��" SortExpression="dDateD" DataFormatString="{0:d}" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="�Ѩ���" SortExpression="dDate" />
                                <asp:BoundField DataField="sTime" HeaderText="�Ѩ�ɶ�" SortExpression="sTime" />
                                <asp:BoundField DataField="sReserve1" HeaderText="�Ѩ��]" SortExpression="sReserve1" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                <asp:BoundField DataField="dDate" HeaderText="�}�l���" SortExpression="dDate"
                                    DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sTime" HeaderText="�ɶ�" SortExpression="sTime" />

                                <asp:BoundField DataField="sHname" HeaderText="���O" SortExpression="sHname" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�֭�" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sNameA" HeaderText="�m�W" SortExpression="sNameA" />
                                <asp:BoundField DataField="dDateA" HeaderText="����" SortExpression="dDateA" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sRoteA" HeaderText="��Z�O" SortExpression="sRoteA" />
                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="���Z���" SortExpression="dDateB" />
                                <asp:BoundField DataField="sRoteB" HeaderText="���Z�Z�O" SortExpression="sRoteB" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sRotetNameA" HeaderText="�쥻�Z�O" 
                                    SortExpression="sRotetNameA" />
                                <asp:BoundField DataField="dDate" HeaderText="�կZ���" SortExpression="dDate" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="sRotetName" HeaderText="�կZ��Z�O" 
                                    SortExpression="sRotetName" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                            CommandName="View" Text="�˵�" ToolTip='<%# Eval("sProcessID") %>' />
                                        <asp:HyperLink ID="hlForm" runat="server" Target="_blank" NavigateUrl="#" ToolTip='<%# Eval("sProcessID") %>'>���e</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="iAutoKey" HeaderText="�۰ʽs��" InsertVisible="False" ReadOnly="True"
                                    SortExpression="iAutoKey" />
                                <asp:BoundField DataField="idProcess" HeaderText="�y�{�Ǹ�" SortExpression="idProcess" />
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sIntentionName" HeaderText="��x�ت�" SortExpression="sIntentionName" />
                                <asp:BoundField DataField="dDateB" DataFormatString="{0:d}" HeaderText="���d�}�l��" SortExpression="dDateB" />
                                <asp:BoundField DataField="dDateE" DataFormatString="{0:d}" HeaderText="���d������" SortExpression="dDateE" />
                                <asp:BoundField DataField="dDate" DataFormatString="{0:d}" HeaderText="�����" SortExpression="dDate" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="�ӽФ��" SortExpression="dKeyDate" />
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
                                                            <asp:Button ID="btnExitView" runat="server" CssClass="ButtonExit" Text="��" OnClick="btnExitView_Click" />
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
                                                    �ӽФH���
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvAppM" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                                                        Width="100%" DataSourceID="sdsAppM">
                                                        <Columns>
                                                            <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                                            <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                                            <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                                            <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                                            <asp:CheckBoxField DataField="bSign" HeaderText="�O�_�ӽ�" SortExpression="bSign" />
                                                            <asp:BoundField DataField="sState" HeaderText="���A" SortExpression="sState" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:SqlDataSource ID="sdsAppM" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                                        SelectCommand="SELECT *
 FROM wfFormApp WHERE (sProcessID = '')"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    �f�̸֪��
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                <asp:GridView ID="gvSignM" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                            DataSourceID="sdsSignM" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                <asp:BoundField DataField="sDept" HeaderText="�����N�X" SortExpression="sDept" 
                                    Visible="False" />
                                <asp:BoundField DataField="sDeptName" HeaderText="�����W��" SortExpression="sDeptName" />
                                <asp:BoundField DataField="sNote" HeaderText="�Ƶ�" SortExpression="sNote" />
                                <asp:CheckBoxField DataField="bSign" HeaderText="�ӽ�" SortExpression="bSign" />
                                <asp:BoundField DataField="dKeyDate" HeaderText="ñ�֤��" SortExpression="dKeyDate" />
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
                                                            <asp:BoundField DataField="Role_idDefault" HeaderText="����(D)" SortExpression="Role_idDefault"
                                                                Visible="False" />
                                                            <asp:BoundField DataField="Emp_idDefault" HeaderText="�u��(D)" SortExpression="Emp_idDefault" />
                                                            <asp:BoundField DataField="Emp_nameDefault" HeaderText="�m�W(D)" SortExpression="Emp_nameDefault" />
                                                            <asp:BoundField DataField="Role_idAgent" HeaderText="����(A)" SortExpression="Role_idAgent"
                                                                Visible="False" />
                                                            <asp:BoundField DataField="Emp_idAgent" HeaderText="�u��(A)" SortExpression="Emp_idAgent" />
                                                            <asp:BoundField DataField="Emp_nameAgent" HeaderText="�m�W(A)" SortExpression="Emp_nameAgent" />
                                                            <asp:BoundField DataField="Role_idReal" HeaderText="����(R)" SortExpression="Role_idReal"
                                                                Visible="False" />
                                                            <asp:BoundField DataField="Emp_idReal" HeaderText="�u��(R)" SortExpression="Emp_idReal" />
                                                            <asp:BoundField DataField="Emp_nameReal" HeaderText="�m�W(R)" SortExpression="Emp_nameReal" />
                                                            <asp:BoundField DataField="ProcessNode_adate" HeaderText="�}�l��" SortExpression="ProcessNode_adate" />
                                                            <asp:BoundField DataField="ProcessCheck_adate" HeaderText="ñ����" SortExpression="ProcessCheck_adate" />
                                                            <asp:CheckBoxField DataField="ProcessNode_isFinish" HeaderText="����" SortExpression="ProcessNode_isFinish" />
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
                                                    ��(D)��ñ�̡֪F(A)�N�zñ�̡֪F(R)���ñ�֪�
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
