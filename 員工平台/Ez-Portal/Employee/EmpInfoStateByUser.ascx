<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpInfoStateByUser.ascx.cs"
    Inherits="Employee_EmpInfoStateByUser" %>
<h3>
    <asp:Label ID="lblInfo" runat="server" Text="在職資訊" meta:resourcekey="lblInfoResource1"></asp:Label>
</h3>
<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="狀態："
    meta:resourcekey="Label1Resource1"></asp:Label>
<asp:Label ID="lb_state" runat="server"
         meta:resourcekey="lb_stateResource1" Font-Size="Small"></asp:Label><br />
<asp:Label ID="Label3" runat="server" Font-Bold="True" Text="年資："
    meta:resourcekey="Label3Resource1"></asp:Label>
<asp:Label ID="lb_year" runat="server"
        meta:resourcekey="lb_yearResource1" Font-Size="Small"></asp:Label><asp:GridView
            ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
            BorderWidth="1px" CellPadding="2" Font-Size="Small" 
    ForeColor="Black" GridLines="None"
            Width="50%" OnDataBound="GridView1_DataBound" 
    meta:resourcekey="GridView1Resource1">
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Size="Small" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <RowStyle HorizontalAlign="Center" Font-Size="Small" />
        </asp:GridView>
<asp:Label ID="lb_nobr" runat="server" Visible="False" 
    meta:resourcekey="lb_nobrResource1" Font-Size="Small"></asp:Label>
