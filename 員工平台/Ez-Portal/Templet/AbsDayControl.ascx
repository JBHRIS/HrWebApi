<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AbsDayControl.ascx.cs"
    Inherits="Templet_AbsDayControl" %>
<h3>
    <asp:Label ID="lblHeader" runat="server" Text="本日請假人員" meta:resourcekey="lblHeaderResource1"></asp:Label>
</h3>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    OnPageIndexChanging="GridView1_PageIndexChanging" SkinID="Yahoo" DataKeyNames="nobr"
    meta:resourcekey="GridView1Resource1">
    <Columns>
        <asp:BoundField DataField="H_NAME" HeaderText="" Visible="false" meta:resourcekey="BoundFieldResource1" />
        <asp:BoundField DataField="d_name" HeaderText="部門名稱" meta:resourcekey="BoundFieldResource2" />
        <asp:BoundField DataField="nobr" HeaderText="員工編號" meta:resourcekey="BoundFieldResource3" />
        <asp:BoundField DataField="name_c" HeaderText="員工姓名" meta:resourcekey="BoundFieldResource4" />
        <asp:BoundField DataField="btime" HeaderText="請時間" meta:resourcekey="BoundFieldResource5" />
        <asp:BoundField DataField="etime" HeaderText="迄時間" meta:resourcekey="BoundFieldResource6" />
    </Columns>
    <EmptyDataTemplate>
        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
            meta:resourcekey="lb_emptyResource1"></asp:Label>
    </EmptyDataTemplate>
</asp:GridView>
<asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
