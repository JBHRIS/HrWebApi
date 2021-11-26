<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CheckSPM.aspx.cs" Inherits="Attendance_CheckSPM" Title="SPM Check" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset>
<legend>查詢條件</legend>
                            <asp:Label ID="Label1" runat="server" Text="日期："></asp:Label>
                            <telerik:RadDatePicker ID="adate" runat="server">
                                <DateInput Skin="">
                                </DateInput></telerik:RadDatePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="至"></asp:Label>
                            <telerik:RadDatePicker ID="ddate" runat="server">
                                <DateInput Skin="">
                                </DateInput></telerik:RadDatePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="請假確認" ValidationGroup="group_date" />&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="加班確認" /><br />
    SPM筆數：<asp:Label ID="lb_spm" runat="server" EnableViewState="False" ForeColor="Red"
        Text="0"></asp:Label>
    ,HR差異筆數：<asp:Label ID="lb_HR" runat="server" EnableViewState="False" ForeColor="Red"
        Text="0"></asp:Label></fieldset>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>

