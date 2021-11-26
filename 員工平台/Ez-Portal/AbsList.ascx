<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AbsList.ascx.cs" Inherits="AbsList" %>
<h3>
    <asp:Label ID="lblHeader" runat="server" Text="請假列表" meta:resourcekey="lblHeaderResource1"></asp:Label>
</h3>
<asp:GridView ID="GridView1" runat="server" meta:resourcekey="GridView1Resource1"
    Visible="False" Font-Size="Small">
    <HeaderStyle Font-Size="Small" />
    <RowStyle Font-Size="Small" />
</asp:GridView>
<asp:GridView ID="GridView3" runat="server" meta:resourcekey="GridView1Resource1"
    AutoGenerateColumns="False" Visible="False" Font-Size="Small">
    <Columns>
        <asp:BoundField DataField="LeaveCode" HeaderText="假別代碼" Visible="False" />
        <asp:BoundField DataField="LeaveName" HeaderText="假別" />
        <asp:BoundField DataField="Unit" HeaderText="單位" />
        <asp:BoundField DataField="Approved" HeaderText="已核准" Visible="False" />
        <asp:BoundField DataField="Processing" HeaderText="在途中" />
    </Columns>
    <HeaderStyle Font-Size="Small" />
    <RowStyle Font-Size="Small" />
</asp:GridView>
<asp:Label ID="lblNobr" runat="server" Visible="False" Font-Size="Small"></asp:Label>
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" meta:resourcekey="GridView2Resource1"
    Visible="False" Font-Size="Small">
    <Columns>
        <asp:BoundField HeaderText="去年度剩餘年假" DataField="a1" meta:resourcekey="BoundFieldResource1"
            Visible="False" />
        <asp:BoundField HeaderText="今年度年假" DataField="a2" meta:resourcekey="BoundFieldResource2" />
        <asp:BoundField HeaderText="今年已請時數" DataField="a3" meta:resourcekey="BoundFieldResource3"
            Visible="False" />
        <asp:BoundField HeaderText="可累計之時數" DataField="a4" Visible="false" meta:resourcekey="BoundFieldResource4" />
        <asp:BoundField HeaderText="今年度剩餘時數" DataField="a5" meta:resourcekey="BoundFieldResource5"
            Visible="False" />
        <asp:BoundField HeaderText="本月份已請時數" DataField="a6" meta:resourcekey="BoundFieldResource6"
            Visible="False" />
        <asp:BoundField HeaderText="去年度剩餘年假未休時數" DataField="a7" Visible="false" meta:resourcekey="BoundFieldResource7">
            <ItemStyle ForeColor="Red" />
        </asp:BoundField>
    </Columns>
    <HeaderStyle Font-Size="Small" />
    <RowStyle HorizontalAlign="Center" Font-Size="Small" />
</asp:GridView>
<asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
    Font-Size="Small">
    <Columns>
        <asp:BoundField DataField="Nobr" HeaderText="Nobr" Visible="False" />
        <asp:BoundField DataField="HName" HeaderText="假別" />
        <asp:BoundField DataField="Unit" HeaderText="單位" />
        <asp:BoundField DataField="GetHrs" HeaderText="可休" />
        <asp:BoundField DataField="AuthorizedHrs" HeaderText="已核准" Visible="False" />
        <asp:BoundField DataField="AuthorizingHrs" HeaderText="在途中" Visible="False" />
    </Columns>
    <HeaderStyle Font-Size="Small" />
    <RowStyle Font-Size="Small" />
</asp:GridView>
&nbsp;&nbsp;<asp:GridView ID="GridView4" runat="server" 
    AutoGenerateColumns="False" Font-Size="Small">
    <Columns>
        <asp:BoundField DataField="Nobr" HeaderText="Nobr" Visible="False" />
        <asp:BoundField DataField="HName" HeaderText="假別" />
        <asp:BoundField DataField="Unit" HeaderText="單位" />
        <asp:BoundField DataField="GetHrs" HeaderText="可休" Visible="False" />
        <asp:BoundField DataField="AuthorizedHrs" HeaderText="已核准" />
        <asp:BoundField DataField="AuthorizingHrs" HeaderText="在途中" />
    </Columns>
    <HeaderStyle Font-Size="Small" />
    <RowStyle Font-Size="Small" />
</asp:GridView>
