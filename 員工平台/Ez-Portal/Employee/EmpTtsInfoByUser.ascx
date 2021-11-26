<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpTtsInfoByUser.ascx.cs" Inherits="Employee_EmpTtsInfoByUser" %>
<h3>
            <asp:Label ID="lblPersonal" runat="server" Text="人事資料" 
            meta:resourcekey="lblPersonalResource1"></asp:Label>
            </h3>
        <asp:DetailsView ID="DetailsView1" runat="server" 
    AutoGenerateRows="False" BackColor="White"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" DataSourceID="SqlDataSource1"
            ForeColor="Black" GridLines="Vertical" OnDataBinding="DetailsView1_DataBinding"
            Width="90%" OnDataBound="DetailsView1_DataBound" 
            meta:resourcekey="DetailsView1Resource1" Font-Size="Small">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" Font-Size="Small" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <Fields>
                <asp:BoundField DataField="公司名稱" HeaderText="公司名稱" SortExpression="公司名稱" 
                    meta:resourcekey="BoundFieldResource1">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="編制部門代碼" HeaderText="編制部門代碼" SortExpression="編制部門代碼" 
                    Visible="False" meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="編制部門" HeaderText="編制部門" SortExpression="編制部門" 
                    meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="成本部門代碼" HeaderText="成本部門代碼" SortExpression="成本部門代碼" 
                    Visible="False" meta:resourcekey="BoundFieldResource4" />
                <asp:BoundField DataField="成本部門" HeaderText="成本部門" SortExpression="成本部門" 
                    meta:resourcekey="BoundFieldResource5" />
                <asp:BoundField DataField="職稱" HeaderText="職稱" SortExpression="職稱" 
                    meta:resourcekey="BoundFieldResource6" />
                <asp:BoundField DataField="職等" HeaderText="職等" SortExpression="職等" 
                    meta:resourcekey="BoundFieldResource7" />
                <asp:BoundField DataField="員別" HeaderText="員別" SortExpression="員別" 
                    meta:resourcekey="BoundFieldResource8" />
                <asp:BoundField DataField="直間接" HeaderText="直間接" SortExpression="直間接" 
                    meta:resourcekey="BoundFieldResource9" />
                <asp:BoundField DataField="行事曆" HeaderText="行事曆" SortExpression="行事曆" 
                    Visible="False" meta:resourcekey="BoundFieldResource10" />
                <asp:BoundField DataField="輪班別" HeaderText="輪班別" SortExpression="輪班別" 
                    meta:resourcekey="BoundFieldResource11" />
                <asp:CheckBoxField DataField="主管職" HeaderText="主管職" ReadOnly="True" 
                    SortExpression="主管職" Visible="False" 
                    meta:resourcekey="CheckBoxFieldResource1" />
                <asp:BoundField DataField="工作地" HeaderText="工作地" SortExpression="工作地" 
                    Visible="False" meta:resourcekey="BoundFieldResource12" />
            </Fields>
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" 
                Font-Size="Small" />
            <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
            SelectCommand="SELECT WORKCD.WORK_ADDR AS 工作地, HOLICD.HOLI_NAME AS 行事曆, ROTET.ROTETNAME AS 輪班別, EMPCD.EMPDESCR AS 員別, CASE basetts.DI WHEN 'D' THEN '直接人員(D)' WHEN 'd' THEN '直接人員(D)' WHEN 'I' THEN '間接人員(I)' WHEN 'i' THEN '間接人員(I)' END AS 直間接, DEPT.D_NO AS 編制部門代碼, DEPT.D_NAME AS 編制部門, COMP.COMP AS 公司別代碼, COMP.COMPNAME AS 公司名稱, DEPTS.D_NO AS 成本部門代碼, DEPTS.D_NAME AS 成本部門, JOB.JOB_NAME AS 職稱, BASETTS.JOB AS 職稱代碼, ISNULL(BASETTS.MANG, N'') AS 主管職, BASETTS.JOBL AS 職等 FROM BASETTS LEFT OUTER JOIN JOB ON BASETTS.JOB = JOB.JOB LEFT OUTER JOIN DEPTS ON BASETTS.DEPTS = DEPTS.D_NO LEFT OUTER JOIN COMP ON BASETTS.COMP = COMP.COMP LEFT OUTER JOIN DEPT ON BASETTS.DEPT = DEPT.D_NO LEFT OUTER JOIN EMPCD ON BASETTS.EMPCD = EMPCD.EMPCD LEFT OUTER JOIN ROTET ON BASETTS.ROTET = ROTET.ROTET LEFT OUTER JOIN HOLICD ON BASETTS.HOLI_CODE = HOLICD.HOLI_CODE LEFT OUTER JOIN WORKCD ON BASETTS.WORKCD = WORKCD.WORK_CODE WHERE (BASETTS.NOBR = @nobr) AND (CONVERT (CHAR(10), GETDATE(), 102) BETWEEN CONVERT (CHAR(10), BASETTS.ADATE, 102) AND CONVERT (CHAR(10), BASETTS.DDATE, 102))">
            <SelectParameters>
                <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
<asp:Label ID="lb_nobr" runat="server" Visible="False" 
    meta:resourcekey="lb_nobrResource1" Font-Size="Small"></asp:Label>
