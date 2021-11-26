<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AttendCardList.aspx.cs" Inherits="Attendance_AttendCardList" Title="員工出勤異常"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset>
        <legend>
            <asp:Label ID="lblShowInquiryCondition" runat="server" Text="查詢條件" meta:resourcekey="lblShowInquiryConditionResource1"></asp:Label></legend>
        <asp:Label ID="Label1" runat="server" Text="日期：" meta:resourcekey="Label1Resource1"></asp:Label>
        <telerik:RadDatePicker ID="adate" runat="server" Culture="Chinese (Taiwan)" meta:resourcekey="adateResource1">
            <DateInput Skin="">
            </DateInput></telerik:RadDatePicker>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
            ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
        <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
        <telerik:RadDatePicker ID="ddate" runat="server" Culture="Chinese (Taiwan)" meta:resourcekey="ddateResource1">
            <DateInput Skin="">
            </DateInput></telerik:RadDatePicker>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
            ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
            meta:resourcekey="Button1Resource1" />&nbsp;<asp:Button ID="ExportExcel" runat="server"
                OnClick="ExportExcel_Click" Text="匯出Excel" meta:resourcekey="ExportExcelResource1" />
        <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>&nbsp;
    </fieldset>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
        meta:resourcekey="GridView1Resource1">
        <Columns>
            <asp:BoundField DataField="NOBR" HeaderText="工號" SortExpression="NOBR" meta:resourcekey="BoundFieldResource1" />
            <asp:BoundField DataField="NAME_C" HeaderText="姓名" SortExpression="NAME_C" meta:resourcekey="BoundFieldResource2" />
            <asp:BoundField DataField="DEPT" HeaderText="部門" SortExpression="DEPT" meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="ADATE" HeaderText="日期" SortExpression="ADATE" DataFormatString="{0:yyyy/MM/dd}"
                meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="ROTE" Visible="False" HeaderText="ROTE" SortExpression="ROTE"
                meta:resourcekey="BoundFieldResource5" />
            <asp:BoundField DataField="ROTENAME" HeaderText="班別" SortExpression="ROTENAME" meta:resourcekey="BoundFieldResource6" />
            <asp:BoundField DataField="ON_TIME" HeaderText="ON_TIME" Visible="False" SortExpression="ON_TIME"
                meta:resourcekey="BoundFieldResource7" />
            <asp:BoundField DataField="OFF_TIME" HeaderText="OFF_TIME" Visible="False" SortExpression="OFF_TIME"
                meta:resourcekey="BoundFieldResource8" />
            <asp:TemplateField HeaderText="上班時間" meta:resourcekey="TemplateFieldResource1">
                <ItemTemplate>
                    <asp:Label ID="lb_inTime" runat="server" meta:resourcekey="lb_inTimeResource1"></asp:Label>
                    <asp:Label ID="lb_on_time" runat="server" Text='<%# Bind("ON_TIME") %>' Visible="False"
                        meta:resourcekey="lb_on_timeResource1"></asp:Label>
                    <asp:Label ID="lb_off_time" runat="server" Text='<%# Bind("OFF_TIME") %>' Visible="False"
                        meta:resourcekey="lb_off_timeResource1"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="下班時間" meta:resourcekey="TemplateFieldResource2">
                <ItemTemplate>
                    <asp:Label ID="lb_outTime" runat="server" meta:resourcekey="lb_outTimeResource1"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="請假記錄" meta:resourcekey="TemplateFieldResource3">
                <ItemTemplate>
                    <asp:Label ID="lb_abs" runat="server" meta:resourcekey="lb_absResource1"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    &nbsp;
</asp:Content>
