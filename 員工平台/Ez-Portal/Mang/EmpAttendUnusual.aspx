<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAttendUnusual.aspx.cs" Inherits="Mang_EmpAttendUnusual" Title="�����X�Բ��`�d��" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
            <table width="100%">
                <tr>
                    <td valign="top">
                        <h3>
                            <asp:Label ID="lblAtt" runat="server" Text="�X�Բ��`" meta:resourcekey="lblAttResource1"></asp:Label>
                        </h3>
                        <fieldset>
                            <legend>
                                <asp:Label ID="lblSearch" runat="server" Text="�d�߱���" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                            <asp:Label ID="Label1" runat="server" Text="�d�ߤ���G" meta:resourcekey="Label1Resource1"></asp:Label>
                            <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                                meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" type="text" 
                                    value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            &nbsp;
                            <asp:Label ID="lblTo" runat="server" Text="��" meta:resourcekey="lblToResource1"></asp:Label>
                            <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                                meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" type="text" 
                                    value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                                ErrorMessage="����榡���~�I" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="�d�����O�G" 
                                meta:resourcekey="Label2Resource1"></asp:Label>
                            <telerik:RadComboBox ID="cbType" runat="server" Culture="zh-TW" 
                                meta:resourcekey="cbTypeResource1">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="�u�d���" Value="0" 
                                        meta:resourcekey="RadComboBoxItemResource1" />
                                    <telerik:RadComboBoxItem runat="server" Text="�u�d���h" Value="1" 
                                        meta:resourcekey="RadComboBoxItemResource2" />
                                    <telerik:RadComboBoxItem runat="server" Text="�u�d�m¾" Value="2" 
                                        meta:resourcekey="RadComboBoxItemResource3" />
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="����" Value="3" 
                                        meta:resourcekey="RadComboBoxItemResource4" />
                                </Items>
                            </telerik:RadComboBox>
                            <br />
                            <asp:Label ID="lblM" runat="server" Text="�����ơG" meta:resourcekey="lblMResource1"></asp:Label>&nbsp;
                            &nbsp;<asp:TextBox ID="tbHrs" runat="server" meta:resourcekey="tbHrsResource1">1</asp:TextBox><br />
                            &nbsp;<asp:Button ID="Button1" runat="server" Text="�d��" ValidationGroup="group_date"
                                meta:resourcekey="Button1Resource1" OnClick="Button1_Click" />&nbsp;<asp:Button ID="ExportExcel"
                                    runat="server" Text="�ץXExcel" meta:resourcekey="ExportExcelResource1" OnClick="ExportExcel_Click" />
                            <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                            <asp:CheckBox ID="cbExcludeRote" runat="server" Checked="True" Text="�ư�����Z" Visible="False"
                                meta:resourcekey="cbExcludeRoteResource1" />
                        </fieldset>
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="Yahoo" AllowPaging="True"
                            AllowSorting="True" meta:resourcekey="gvResource1" OnPageIndexChanging="gv_PageIndexChanging"
                            OnRowDataBound="gv_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="D_NAME" HeaderText="����" meta:resourcekey="BoundFieldResource1" />
                                <asp:BoundField DataField="NOBR" HeaderText="���u�s��" meta:resourcekey="BoundFieldResource2" />
                                <asp:BoundField DataField="NAME_C" HeaderText="�m�W" meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="ADATE" HeaderText="���" DataFormatString="{0:d}" meta:resourcekey="BoundFieldResource4" />
                                <asp:BoundField DataField="LATE_MINS" HeaderText="���" meta:resourcekey="BoundFieldResource5" />
                                <asp:BoundField DataField="E_MINS" HeaderText="���h" meta:resourcekey="BoundFieldResource6" />
                                <asp:BoundField DataField="ABS" HeaderText="�m¾" meta:resourcekey="BoundFieldResource7" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="���L������ơI�I"
                                    meta:resourcekey="lb_emptyResource1"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
