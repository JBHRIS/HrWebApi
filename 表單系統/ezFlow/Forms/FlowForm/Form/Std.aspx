<%@ Page Title="" Language="C#" MasterPageFile="~/mpStd0990111.master" AutoEventWireup="true"
    CodeFile="Std.aspx.cs" Inherits="Form_Std" %>

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
                                    �s�W�ҩ����
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    �u��
                                </th>
                                <th>
                                    �m�W
                                </th>
                                <th>
                                    ��¾��
                                </th>
                                <th>
                                    ���W��
                                </th>
                                <th>
                                    �ݨD�q
                                </th>
                                <th>
                                    �ݨD���
                                </th>
                                <td rowspan="3" align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="�s�W" ValidationGroup="fv" 
                                        OnClick="btnAdd_Click" UseSubmitBehavior="False" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNobr" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" DataSourceID="odsName"
                                        DataTextField="sName" DataValueField="sNobr" OnDataBound="ddlName_DataBound"
                                        OnSelectedIndexChanged="ddlName_SelectedIndexChanged" 
                                        ValidationGroup="fv" >
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" CssClass="txtCode" OnTextChanged="txtName_TextChanged"
                                        ValidationGroup="fv" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblDateIn" runat="server"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlForm" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                        DataSourceID="sdsForm" DataTextField="sName" DataValueField="sCode" OnSelectedIndexChanged="ddlForm_SelectedIndexChanged"
                                        ValidationGroup="fv">
                                        <asp:ListItem Value="0">�ۭq�W��</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtForm" runat="server" CssClass="txtName" ValidationGroup="fv"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtPage" runat="server" CssClass="txtOrder" MaxLength="4" ValidationGroup="fv">1</asp:TextBox>
                                    ��<asp:RequiredFieldValidator ID="rfvOrder" runat="server" 
                                        ControlToValidate="txtPage" Display="None" ErrorMessage="�����\�ť�" 
                                        SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvOrder_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rfvOrder">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RangeValidator ID="rvOrder" runat="server" ControlToValidate="txtPage" 
                                        Display="None" ErrorMessage="�榡�����T" MaximumValue="99" MinimumValue="0" 
                                        SetFocusOnError="True" Type="Integer" ValidationGroup="fv"></asp:RangeValidator>
                                    <asp:ValidatorCalloutExtender ID="rvOrder_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rvOrder">
                                    </asp:ValidatorCalloutExtender>
&nbsp;<asp:MaskedEditExtender AutoComplete="false" ErrorTooltipEnabled="True" ID="meePage" Mask="99" 
                                        MaskType="Number" MessageValidatorTip="true"
                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" runat="server"
                                        TargetControlID="txtPage">
                                    </asp:MaskedEditExtender>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtDateD" runat="server" CssClass="txtDate" 
                                        ValidationGroup="fv"></asp:TextBox>
                                    <asp:ImageButton ID="ibtnDateD" runat="server" CausesValidation="False" ImageUrl="~/img/Calendar_scheduleHS.png" />
                                    <asp:RequiredFieldValidator ID="rfvDateB" runat="server" 
                                        ControlToValidate="txtDateD" Display="None" ErrorMessage="�����\�ť�" 
                                        SetFocusOnError="True" ValidationGroup="fv"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="rfvDateB_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rfvDateB">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RangeValidator ID="rvDateB" runat="server" ControlToValidate="txtDateD" 
                                        Display="None" ErrorMessage="�榡�����T" MaximumValue="9999/12/31" 
                                        MinimumValue="1900/1/1" SetFocusOnError="True" Type="Date" ValidationGroup="fv"></asp:RangeValidator>
                                    <asp:ValidatorCalloutExtender ID="rvDateB_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="rvDateB">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:MaskedEditExtender ID="meeDateD" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                        Enabled="True" Mask="9999/99/99" MaskType="Date" TargetControlID="txtDateD">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="ceDateD" runat="server" Format="yyyy/MM/dd" PopupButtonID="ibtnDateD"
                                        TargetControlID="txtDateD" CssClass="MyCalendar">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    �ӽЭ�]
                                </th>
                                <td colspan="5">
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="txtDescription" ValidationGroup="fv"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:SqlDataSource ID="sdsForm" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                            
                            SelectCommand="SELECT [sCode], [sName] FROM [wfFormCode] WHERE ([sCategory] = @sCategory)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Form" Name="sCategory" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:ObjectDataSource ID="odsName" runat="server" 
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
                    <td>
                        <asp:Button ID="btnFlow" runat="server" Text="�i�椤�y�{" OnClick="btnFlow_Click" 
                            UseSubmitBehavior="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" >
                            <tr>
                                <th>
                                    �Q�ӽФH���
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
                                                        Text="�R��" />
                                                    <asp:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                                        ConfirmText="�z�T�w�n�R���ܡH" Enabled="True" TargetControlID="btnDelete">
                                                    </asp:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                            <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                            <asp:BoundField DataField="dDateIn" DataFormatString="{0:d}" HeaderText="��¾��" SortExpression="dDateIn" />
                                            <asp:BoundField DataField="sDeptName" HeaderText="����" SortExpression="sDeptName" />
                                            <asp:BoundField DataField="sJobName" HeaderText="¾��" SortExpression="sJobName" />
                                            <asp:BoundField DataField="sNameF" HeaderText="�ҩ����" SortExpression="sNameF" />
                                            <asp:BoundField DataField="iPage" HeaderText="�ݨD(��)" SortExpression="iPage" />
                                            <asp:BoundField DataField="dDateD" DataFormatString="{0:d}" HeaderText="�ݨD���" SortExpression="dDateD" />
                                            <asp:BoundField DataField="sNote" HeaderText="�ӽЭ�]" SortExpression="sNote" />
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <EmptyDataTemplate>
                                            �L�ӽЪ̸�ơC
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="sdsAppS" runat="server" ConnectionString="<%$ ConnectionStrings:Flow %>"
                                        DeleteCommand="DELETE FROM [wfAppForm] WHERE [iAutoKey] = @iAutoKey" SelectCommand="SELECT * FROM [wfAppForm]
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
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="�e�X��ñ" 
                            onclientclick="return confirm('�z�T�w�n�e�X��ñ�ܡH');" />
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
                                                            <asp:Label ID="lblDragNameFlow" runat="server" Text="�i�椤�y�{"></asp:Label>
                                                        </td>
                                                        <th align="right" width="1%">
                                                            <asp:Button ID="btnExitFlow" runat="server" CssClass="ButtonExit" Text="��" 
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
                                                                <asp:BoundField DataField="sNobr" HeaderText="�u��" SortExpression="sNobr" />
                                                                <asp:BoundField DataField="sName" HeaderText="�m�W" SortExpression="sName" />
                                                                <asp:BoundField DataField="dDateIn" DataFormatString="{0:d}" HeaderText="��¾��" 
                                                                    SortExpression="dDateIn" />
                                                                <asp:BoundField DataField="sDeptName" HeaderText="����" 
                                                                    SortExpression="sDeptName" />
                                                                <asp:BoundField DataField="sJobName" HeaderText="¾��" 
                                                                    SortExpression="sJobName" />
                                                                <asp:BoundField DataField="sNameF" HeaderText="�ҩ����" SortExpression="sNameF" />
                                                                <asp:BoundField DataField="iPage" HeaderText="�ݨD(��)" SortExpression="iPage" />
                                                                <asp:BoundField DataField="dDateD" DataFormatString="{0:d}" HeaderText="�ݨD���" 
                                                                    SortExpression="dDateD" />
                                                                <asp:BoundField DataField="sNote" HeaderText="�ӽЭ�]" SortExpression="sNote" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <EmptyDataTemplate>
                                                                �L�i�椤�y�{�C
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                        <asp:SqlDataSource ID="sdsFlow" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:Flow %>" SelectCommand="SELECT * FROM wfAppForm
WHERE          (sState = '1') AND (idProcess &lt;&gt; 0) AND (sNobr = @sNobr)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="lblFlowID" DefaultValue="" Name="sNobr" 
                                                                    PropertyName="Text" />
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
                            PopupDragHandleControlID="plDragFlow" RepositionMode="RepositionOnWindowScroll"
                            TargetControlID="hiddenTargetControlForModalPopupFlow">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
