<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserRecord.ascx.cs" Inherits="Utli_UserRecord" %>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333"
    GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" />
    <EditRowStyle BackColor="#2461BF" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="sysLoginUser_sUserID" HeaderText="員工編號" />
        <asp:BoundField DataField="name_c" HeaderText="員工姓名" />
        <asp:BoundField DataField="dLoginTime" DataFormatString="{0:d}" HeaderText="登入時間"
            HtmlEncode="False" />
        <asp:BoundField DataField="dLogoutTime" DataFormatString="{0:d}" HeaderText="登出時間"
            HtmlEncode="False" />
    </Columns>
</asp:GridView>
