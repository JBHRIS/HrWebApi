<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoteChgViewControl.ascx.cs"
    Inherits="HR_RoteChgViewControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<h3>
    <asp:Localize ID="Localize1" runat="server">異常出勤項目</asp:Localize>
</h3>
<telerik:RadDatePicker ID="radAdate" runat="server">
</telerik:RadDatePicker>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="radAdate"
    Display="Dynamic" ErrorMessage="日期格式錯誤！" SetFocusOnError="True" ValidationGroup="group_date"></asp:RequiredFieldValidator>
至
<telerik:RadDatePicker ID="radDdate" runat="server">
</telerik:RadDatePicker>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="radDdate"
    Display="Dynamic" ErrorMessage="日期格式錯誤！" SetFocusOnError="True" ValidationGroup="group_date"></asp:RequiredFieldValidator>
<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查詢異常出勤項目"
    ValidationGroup="group_date" />
<asp:Button ID="btn_exportExcel" runat="server" OnClick="btn_exportExcel_Click" Text="匯出Excel"
    ValidationGroup="group_date" />
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    PageSize="15" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging"
    DataKeyNames="NOBR,ADATE" OnSorting="GridView1_Sorting">
    <Columns>
        <asp:BoundField DataField="NOBR" HeaderText="工號" SortExpression="NOBR" />
        <asp:BoundField DataField="NAME_C" HeaderText="姓名" SortExpression="NAME_C" />
        <asp:BoundField DataField="D_NAME" HeaderText="部門" SortExpression="D_NAME" />
        <asp:BoundField DataField="ADATE" DataFormatString="{0:d}" HeaderText="日期" HtmlEncode="False"
            SortExpression="ADATE" />
        <asp:BoundField DataField="ROTENAME" HeaderText="班別" SortExpression="ROTENAME" />
        <asp:BoundField DataField="CODE" HeaderText="備註" SortExpression="CODE">
            <ItemStyle Width="220px" />
        </asp:BoundField>
        <asp:BoundField DataField="KEY_DATE" DataFormatString="{0:d}" HeaderText="輸入日期" SortExpression="KEY_DATE" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="RoteViewObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetData" TypeName="HIDsTableAdapters.RoteChgViewTableAdapter">
</asp:ObjectDataSource>
