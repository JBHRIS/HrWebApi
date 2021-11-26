<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpFamilyInfoByUser.ascx.cs"
    Inherits="Employee_EmpFamilyInfoByUser" %>
<h3>
    <asp:Label ID="lblFamilyInfo" runat="server" Text="眷屬資料" meta:resourcekey="lblFamilyInfoResource1"></asp:Label>
</h3>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
    Font-Size="Small" ForeColor="Black" GridLines="None" Width="90%" OnRowDataBound="GridView1_RowDataBound"
    meta:resourcekey="GridView1Resource2">
    <Columns>
        <asp:BoundField DataField="關係" HeaderText="關係" SortExpression="關係" meta:resourcekey="BoundFieldResource9" />
        <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" meta:resourcekey="BoundFieldResource10" />
        <asp:BoundField DataField="身份證" HeaderText="身份證" SortExpression="身份證" meta:resourcekey="BoundFieldResource11" />
        <asp:BoundField DataField="出生日" DataFormatString="{0:yyyy/MM/dd}" HeaderText="出生年"
            HtmlEncode="False" SortExpression="出生日" meta:resourcekey="BoundFieldResource12" />
        <asp:CheckBoxField DataField="所得稅扶養親屬" HeaderText="所得稅扶養親屬" SortExpression="所得稅扶養親屬"
            Visible="False" meta:resourcekey="CheckBoxFieldResource8" />
        <asp:CheckBoxField DataField="附加健保" HeaderText="附加健保" SortExpression="附加健保" Visible="False"
            meta:resourcekey="CheckBoxFieldResource9" />
        <asp:CheckBoxField DataField="外籍眷屬" HeaderText="外籍眷屬" SortExpression="外籍眷屬" Visible="False"
            meta:resourcekey="CheckBoxFieldResource10" />
    </Columns>
    <FooterStyle BackColor="Tan" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Size="Small" />
    <AlternatingRowStyle BackColor="PaleGoldenrod" />
    <RowStyle HorizontalAlign="Center" Font-Size="Small" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    SelectCommand="SELECT FAMILY.REL_CODE, RELCODE.REL_NAME AS 關係, FAMILY.FA_NAME AS 姓名, FAMILY.FA_IDNO AS 身份證, CONVERT (char(4), YEAR(FAMILY.FA_BIRDT)) + '年' AS 出生日, FAMILY.TAX AS 所得稅扶養親屬, FAMILY.AUTOINSLAB AS 附加健保, FAMILY.FAMFORN AS 外籍眷屬 FROM FAMILY INNER JOIN RELCODE ON FAMILY.REL_CODE = RELCODE.REL_CODE WHERE (FAMILY.NOBR = @nobr)  AND LIVE =0  ORDER BY FAMILY.REL_CODE">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="OldSqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    SelectCommand="SELECT FAMILY.REL_CODE, RELCODE.REL_NAME AS 關係, FAMILY.FA_NAME AS 姓名, FAMILY.FA_IDNO AS 身份證, CONVERT (char(4), YEAR(FAMILY.FA_BIRDT)) + '年' AS 出生日, FAMILY.TAX AS 所得稅扶養親屬, FAMILY.AUTOINSLAB AS 附加健保, FAMILY.FAMFORN AS 外籍眷屬 FROM FAMILY INNER JOIN RELCODE ON FAMILY.REL_CODE = RELCODE.REL_CODE WHERE (FAMILY.FAMFORN =1 OR FAMILY.TAX=1 OR FAMILY.AUTOINSLAB =1) AND  (FAMILY.NOBR = @nobr)  AND LIVE =0  ORDER BY FAMILY.REL_CODE">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource2"
    Font-Size="Small" ForeColor="Black" GridLines="None" Width="90%" OnDataBound="GridView2_DataBound"
    Visible="False" meta:resourcekey="GridView2Resource2">
    <RowStyle HorizontalAlign="Center" Font-Size="Small" />
    <Columns>
        <asp:BoundField DataField="關係" HeaderText="關係" SortExpression="關係" meta:resourcekey="BoundFieldResource13" />
        <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" meta:resourcekey="BoundFieldResource14" />
        <asp:BoundField DataField="身份證" HeaderText="身份證" SortExpression="身份證" meta:resourcekey="BoundFieldResource15" />
        <asp:BoundField DataField="出生日" DataFormatString="{0:yyyy/MM/dd}" HeaderText="出生日期"
            HtmlEncode="False" SortExpression="出生日" meta:resourcekey="BoundFieldResource16" />
        <asp:CheckBoxField DataField="所得稅扶養親屬" HeaderText="所得稅扶養親屬" SortExpression="所得稅扶養親屬"
            Visible="False" meta:resourcekey="CheckBoxFieldResource11" />
        <asp:CheckBoxField DataField="附加健保" HeaderText="附加健保" SortExpression="附加健保" Visible="False"
            meta:resourcekey="CheckBoxFieldResource12" />
        <asp:CheckBoxField DataField="附加團保" HeaderText="附加團保" SortExpression="附加團保" Visible="False"
            meta:resourcekey="CheckBoxFieldResource13" />
        <asp:CheckBoxField DataField="不顯示於主管查詢" HeaderText="不顯示於主管查詢" SortExpression="不顯示於主管查詢"
            Visible="False" meta:resourcekey="CheckBoxFieldResource14" />
    </Columns>
    <FooterStyle BackColor="Tan" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Size="Small" />
    <AlternatingRowStyle BackColor="PaleGoldenrod" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    SelectCommand="SELECT FAMILY.REL_CODE, RELCODE.REL_NAME AS 關係, FAMILY.FA_NAME AS 姓名, FAMILY.FA_IDNO AS 身份證, FAMILY.FA_BIRDT  AS 出生日, FAMILY.TAX AS 所得稅扶養親屬, FAMILY.AUTOINSLAB AS 附加健保, FAMILY.FAMFORN AS 附加團保 ,FAMILY.LIVE AS 不顯示於主管查詢 FROM FAMILY INNER JOIN RELCODE ON FAMILY.REL_CODE = RELCODE.REL_CODE WHERE  (FAMILY.NOBR = @nobr)  AND LIVE =0  ORDER BY FAMILY.REL_CODE">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:SqlDataSource ID="OldSqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    SelectCommand="SELECT FAMILY.REL_CODE, RELCODE.REL_NAME AS 關係, FAMILY.FA_NAME AS 姓名, FAMILY.FA_IDNO AS 身份證, FAMILY.FA_BIRDT  AS 出生日, FAMILY.TAX AS 所得稅扶養親屬, FAMILY.AUTOINSLAB AS 附加健保, FAMILY.FAMFORN AS 附加團保 ,FAMILY.LIVE AS 不顯示於主管查詢 FROM FAMILY INNER JOIN RELCODE ON FAMILY.REL_CODE = RELCODE.REL_CODE WHERE (FAMILY.FAMFORN =1 OR FAMILY.TAX=1 OR FAMILY.AUTOINSLAB =1) AND (FAMILY.NOBR = @nobr)  AND LIVE =0  ORDER BY FAMILY.REL_CODE">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label ID="lb_nobr" runat="server" Visible="False" 
    meta:resourcekey="lb_nobrResource2" Font-Size="Small"></asp:Label>