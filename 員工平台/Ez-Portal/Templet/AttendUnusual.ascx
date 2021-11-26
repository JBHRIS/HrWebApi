<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttendUnusual.ascx.cs"
    Inherits="Templet_AttendUnusual" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<h3>
    <asp:Localize ID="Localize1" runat="server">出勤異常</asp:Localize>
</h3>
起<telerik:RadDatePicker ID="startRdp" runat="server">
</telerik:RadDatePicker>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*日期須選擇"
    ControlToValidate="startRdp" ValidationGroup="a"></asp:RequiredFieldValidator>
迄
<telerik:RadDatePicker ID="endRdp" runat="server">
</telerik:RadDatePicker>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*日期須選擇"
    ControlToValidate="endRdp" ValidationGroup="a"></asp:RequiredFieldValidator>
<br />
<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查詢" ValidationGroup="a" />
<asp:Button ID="btnExportExcel" runat="server" OnClick="btnExportExcel_Click" Text="匯出"
    ValidationGroup="a" />
<asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="Yahoo" AllowPaging="True"
    AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging" Width="90%"
    OnRowDataBound="gv_RowDataBound">
    <Columns>
        <asp:BoundField DataField="D_NAME" HeaderText="部門" />
        <asp:BoundField DataField="NOBR" HeaderText="員工編號" />
        <asp:BoundField DataField="NAME_C" HeaderText="姓名" />
        <asp:BoundField DataField="ADATE" HeaderText="日期" DataFormatString="{0:d}" />
        <asp:BoundField DataField="LATE_MINS" HeaderText="遲到(分)" DataFormatString="{0:N0}" />
        <asp:BoundField DataField="E_MINS" HeaderText="早退(分)" DataFormatString="{0:N0}" />
        <asp:BoundField DataField="ABS" HeaderText="曠職" />
    </Columns>
    <EmptyDataTemplate>
        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"></asp:Label>
    </EmptyDataTemplate>
</asp:GridView>
