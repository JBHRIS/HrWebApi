<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAttendUnusual.aspx.cs" Inherits="Mang_EmpAttendUnusual" Title="部門出勤異常查詢" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
                            <asp:Label ID="lblAtt" runat="server" Text="出勤異常" meta:resourcekey="lblAttResource1"></asp:Label>
                        </h3>
                        <fieldset>
                            <legend>
                                <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                            <asp:Label ID="Label1" runat="server" Text="查詢日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                            <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                                meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" type="text" 
                                    value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            &nbsp;
                            <asp:Label ID="lblTo" runat="server" Text="至" meta:resourcekey="lblToResource1"></asp:Label>
                            <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                                meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" type="text" 
                                    value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="查詢類別：" 
                                meta:resourcekey="Label2Resource1"></asp:Label>
                            <telerik:RadComboBox ID="cbType" runat="server" Culture="zh-TW" 
                                meta:resourcekey="cbTypeResource1">
                                <Items>
                                    <telerik:RadComboBoxItem runat="server" Text="只查遲到" Value="0" 
                                        meta:resourcekey="RadComboBoxItemResource1" />
                                    <telerik:RadComboBoxItem runat="server" Text="只查早退" Value="1" 
                                        meta:resourcekey="RadComboBoxItemResource2" />
                                    <telerik:RadComboBoxItem runat="server" Text="只查曠職" Value="2" 
                                        meta:resourcekey="RadComboBoxItemResource3" />
                                    <telerik:RadComboBoxItem runat="server" Selected="True" Text="全部" Value="3" 
                                        meta:resourcekey="RadComboBoxItemResource4" />
                                </Items>
                            </telerik:RadComboBox>
                            <br />
                            <asp:Label ID="lblM" runat="server" Text="分鐘數：" meta:resourcekey="lblMResource1"></asp:Label>&nbsp;
                            &nbsp;<asp:TextBox ID="tbHrs" runat="server" meta:resourcekey="tbHrsResource1">1</asp:TextBox><br />
                            &nbsp;<asp:Button ID="Button1" runat="server" Text="查詢" ValidationGroup="group_date"
                                meta:resourcekey="Button1Resource1" OnClick="Button1_Click" />&nbsp;<asp:Button ID="ExportExcel"
                                    runat="server" Text="匯出Excel" meta:resourcekey="ExportExcelResource1" OnClick="ExportExcel_Click" />
                            <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                            <asp:CheckBox ID="cbExcludeRote" runat="server" Checked="True" Text="排除假日班" Visible="False"
                                meta:resourcekey="cbExcludeRoteResource1" />
                        </fieldset>
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="Yahoo" AllowPaging="True"
                            AllowSorting="True" meta:resourcekey="gvResource1" OnPageIndexChanging="gv_PageIndexChanging"
                            OnRowDataBound="gv_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="D_NAME" HeaderText="部門" meta:resourcekey="BoundFieldResource1" />
                                <asp:BoundField DataField="NOBR" HeaderText="員工編號" meta:resourcekey="BoundFieldResource2" />
                                <asp:BoundField DataField="NAME_C" HeaderText="姓名" meta:resourcekey="BoundFieldResource3" />
                                <asp:BoundField DataField="ADATE" HeaderText="日期" DataFormatString="{0:d}" meta:resourcekey="BoundFieldResource4" />
                                <asp:BoundField DataField="LATE_MINS" HeaderText="遲到" meta:resourcekey="BoundFieldResource5" />
                                <asp:BoundField DataField="E_MINS" HeaderText="早退" meta:resourcekey="BoundFieldResource6" />
                                <asp:BoundField DataField="ABS" HeaderText="曠職" meta:resourcekey="BoundFieldResource7" />
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                                    meta:resourcekey="lb_emptyResource1"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
