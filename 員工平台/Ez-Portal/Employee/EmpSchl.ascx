<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpSchl.ascx.cs" Inherits="Employee_EmpSchl" %>
<h3>
    <asp:Label ID="lblSchl" runat="server" Text="學歷資料" meta:resourcekey="lblSchlResource1"></asp:Label></h3>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
    BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
    Font-Size="Small" ForeColor="Black" GridLines="Vertical" Width="90%" OnRowDataBound="GridView1_RowDataBound"
    meta:resourcekey="GridView1Resource1">
    <Columns>
        <asp:BoundField DataField="edudesc" HeaderText="教育程度" SortExpression="edudesc" meta:resourcekey="BoundFieldResource1">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="adate" DataFormatString="{0:d}" HeaderText="生效日期" HtmlEncode="False"
            SortExpression="adate" meta:resourcekey="BoundFieldResource2">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="schl" HeaderText="學校名稱" SortExpression="schl" meta:resourcekey="BoundFieldResource3">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="SUBJ_DETAIL" HeaderText="科系" 
            SortExpression="SUBJ_DETAIL" meta:resourcekey="BoundFieldResource4">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="date_b" DataFormatString="{0:yyyy/MM/dd}" HeaderText="入學日"
            HtmlEncode="False" SortExpression="date_b" meta:resourcekey="BoundFieldResource5">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="date_e" DataFormatString="{0:d}" HeaderText="畢業日" HtmlEncode="False"
            SortExpression="date_e" meta:resourcekey="BoundFieldResource6">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="ok" HeaderText="畢業" SortExpression="ok" meta:resourcekey="BoundFieldResource7">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
    </Columns>
    <FooterStyle BackColor="Tan" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <RowStyle Font-Size="Small" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Size="Small" />
    <AlternatingRowStyle BackColor="PaleGoldenrod" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    
    SelectCommand="SELECT SCHL.NOBR, SCHL.EDUCCODE, SCHL.SCHL, SCHL.SUBJ,SCHL.SUBJ_DETAIL, SCHL.DATE_B, SCHL.DATE_E, SCHL.ADATE, SCHL.OK, MTCODE.NAME AS EDUDESC 
FROM SCHL LEFT OUTER JOIN 
MTCODE ON SCHL.EDUCCODE = MTCODE.CODE and CATEGORY='EDUCODE' WHERE (SCHL.NOBR = @nobr) AND (MTCODE.CATEGORY = 'EDUCODE') ORDER BY SCHL.EDUCCODE DESC">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label ID="lb_nobr" runat="server" Visible="False" 
    meta:resourcekey="lb_nobrResource1" Font-Size="Small"></asp:Label>