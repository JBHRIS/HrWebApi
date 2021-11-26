<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpBasetts.ascx.cs" Inherits="Employee_EmpBasetts" %>
<h3>
    <asp:Localize ID="Localize1" runat="server">異動資料</asp:Localize>
</h3>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
    BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
    Font-Size="X-Small" ForeColor="Black" GridLines="None" Width="90%">
    <FooterStyle BackColor="Tan" />
    <Columns>
        <asp:BoundField DataField="ADATE" DataFormatString="{0:d}" HeaderText="異動日期" HtmlEncode="False"
            SortExpression="ADATE" />
        <asp:BoundField DataField="MENO" HeaderText="備註" SortExpression="MENO" />
    </Columns>
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" />
    <AlternatingRowStyle BackColor="PaleGoldenrod" />
    <RowStyle HorizontalAlign="Center" />
</asp:GridView>
<br />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    SelectCommand="SELECT         ADATE, MENO, NOBR&#13;&#10;FROM             BASETTS&#13;&#10;WHERE         NOBR=@NOBR AND TTSCODE!='1'  ORDER BY ADATE">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_nobr" Name="NOBR" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>
