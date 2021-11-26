<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FamilyList.ascx.cs" Inherits="FamilyList" %>
<h3>
    <asp:Localize ID="Localize1" runat="server">眷屬資料</asp:Localize>
</h3>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
    SkinID="Yahoo">
    <Columns>
        <asp:BoundField DataField="眷屬名稱" HeaderText="眷屬名稱" SortExpression="眷屬名稱" />
        <asp:BoundField DataField="眷屬關係" HeaderText="眷屬關係" SortExpression="眷屬關係" />
        <asp:BoundField DataField="身份證" HeaderText="身份證" SortExpression="身份證" />
        <asp:BoundField DataField="生日" DataFormatString="{0:yyyy/MM/dd}" HeaderText="生日"
            HtmlEncode="False" SortExpression="生日" />
        <asp:BoundField DataField="保險狀態" HeaderText="保險狀態" ReadOnly="True" SortExpression="保險狀態" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    SelectCommand="SELECT     FAMILY.FA_NAME AS 眷屬名稱, RELCODE.REL_NAME AS 眷屬關係, FAMILY.FA_IDNO AS 身份證, FAMILY.FA_BIRDT AS 生日,&#13;&#10;                          (SELECT     CASE rtrim(CODE) WHEN '1' THEN '在保' WHEN '2' THEN '退保' END AS CODE&#13;&#10;                            FROM          INSLAB&#13;&#10;                            WHERE      (CONVERT(CHAR(10), GETDATE(), 111) BETWEEN CONVERT(CHAR(10), IN_DATE, 111) AND CONVERT(CHAR(10), OUT_DATE, 111)) AND &#13;&#10;                                                   (FA_IDNO = FAMILY.FA_IDNO)) AS 保險狀態&#13;&#10;FROM         FAMILY INNER JOIN&#13;&#10;                      RELCODE ON FAMILY.REL_CODE = RELCODE.REL_CODE&#13;&#10;WHERE     (FAMILY.NOBR =@nobr)">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>