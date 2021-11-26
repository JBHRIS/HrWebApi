<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OnlineList.ascx.cs" Inherits="Utli_OnlineList" %>
<asp:Label ID="Label1" runat="server" Text="Label" BorderColor="White" ForeColor="Red"></asp:Label>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333"
    GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" />
    <EditRowStyle BackColor="#2461BF" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
