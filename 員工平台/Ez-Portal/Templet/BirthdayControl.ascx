<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BirthdayControl.ascx.cs"
    Inherits="Templet_BirthdayControl" %>
<h3>
    <asp:Label ID="lblBirthDayThisMonth" runat="server" Text="本月壽星" meta:resourcekey="lblBirthDayThisMonthResource1"></asp:Label>
</h3>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    OnPageIndexChanging="GridView1_PageIndexChanging" SkinID="Yahoo" DataKeyNames="nobr"
    meta:resourcekey="GridView1Resource1" PageSize="6">
    <Columns>
        <asp:BoundField DataField="D_NAME" HeaderText="部門名稱" meta:resourcekey="BoundFieldResource1" />
        <asp:BoundField DataField="NOBR" HeaderText="員工編號" SortExpression="NOBR" Visible="false"
            meta:resourcekey="BoundFieldResource2" />
        <asp:BoundField DataField="NAME_C" HeaderText="員工姓名" SortExpression="NAME_C" meta:resourcekey="BoundFieldResource3" />
        <asp:BoundField DataField="BIRDT" HeaderText="出生月份" HtmlEncode="False" SortExpression="BIRDT"
            meta:resourcekey="BoundFieldResource4" DataFormatString="{0:M/d}" />
    </Columns>
    <EmptyDataTemplate>
        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
            meta:resourcekey="lb_emptyResource1"></asp:Label>
    </EmptyDataTemplate>
</asp:GridView>
&nbsp;
<asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
