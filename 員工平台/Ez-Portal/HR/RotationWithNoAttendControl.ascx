<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RotationWithNoAttendControl.ascx.cs"
    Inherits="HR_RotationWithNoAttendControl" %>
    <h3>
        <asp:Localize ID="Localize1" runat="server">排班無刷卡資料</asp:Localize>
    </h3>
    <br />
    <asp:Button ID="btn_exportExcel" runat="server" OnClick="btn_exportExcel_Click" Text="匯出Excel" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataSourceID="obs" PageSize="15" AllowSorting="True" DataKeyNames="NOBR,ADATE">
        <Columns>
            <asp:BoundField DataField="NOBR" HeaderText="工號" SortExpression="NOBR" ReadOnly="True" />
            <asp:BoundField DataField="NAME_C" HeaderText="姓名" SortExpression="NAME_C" />
            <asp:BoundField DataField="D_NAME" HeaderText="部門" SortExpression="D_NAME" />
            <asp:BoundField DataField="ADATE" DataFormatString="{0:d}" HeaderText="日期" SortExpression="ADATE"
                ReadOnly="True" />
            <asp:BoundField DataField="ROTENAME" HeaderText="班別" SortExpression="ROTENAME" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="obs" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataByRotationWithNoAttend" TypeName="HIDsTableAdapters.RotationWithNoAttendTableAdapter">
    </asp:ObjectDataSource>
    <br />
    <br />
