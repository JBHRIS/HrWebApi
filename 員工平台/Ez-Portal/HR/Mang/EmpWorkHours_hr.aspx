<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpWorkHours_hr.aspx.cs" Inherits="HR_Mang_EmpWorkHours_hr" Title="工時資料"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <h3>
                    <asp:Label ID="lblWorkHour" runat="server" Text="工時資料" meta:resourcekey="lblWorkHourResource1"></asp:Label>
                </h3>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                    <asp:Label ID="Label1" runat="server" Text="日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                        meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                            type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                        ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                        meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                            type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                        ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                    <asp:CheckBox ID="ckRealLessThenBase" runat="server" Checked="True" Text="只顯示工時不足"
                        meta:resourcekey="ckRealLessThenBaseResource1" />
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                        meta:resourcekey="Button1Resource1" />&nbsp;<asp:Button ID="ExportExcel" runat="server"
                            OnClick="ExportExcel_Click" Text="匯出Excel" meta:resourcekey="ExportExcelResource1" />
                    <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                    <br />
                </fieldset>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                    AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging"
                    meta:resourcekey="GridView2Resource1">
                    <Columns>
                        <asp:BoundField DataField="Nobr" HeaderText="工號" meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="Name_C" HeaderText="姓名" meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="Name_E" HeaderText="英文名" meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="DeptName" HeaderText="部門" meta:resourcekey="BoundFieldResource4" />
                        <asp:BoundField DataField="JobName" HeaderText="職稱" meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="Indt" HeaderText="到職日" meta:resourcekey="BoundFieldResource6" />
                        <asp:BoundField DataField="BaseWorkHours" HeaderText="基準工時" meta:resourcekey="BoundFieldResource7" />
                        <asp:BoundField DataField="RealWorkHours" HeaderText="實際工時" meta:resourcekey="BoundFieldResource8" />
                        <asp:BoundField DataField="OtHours" HeaderText="固定加班時數" meta:resourcekey="BoundFieldResource9" />
                        <asp:BoundField DataField="OtHoursAmt" HeaderText="應產生固定加班時數" meta:resourcekey="BoundFieldResource10" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lb_empty" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Text="＊無相關資料！！"
                            meta:resourcekey="lb_emptyResource1"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
