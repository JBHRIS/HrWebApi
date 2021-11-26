<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpBase.ascx.cs" Inherits="Employee_EmpBase" %>
<%@ Register Src="../Account/AccountPicture.ascx" TagName="AccountPicture" TagPrefix="uc1" %>
<h3>
    <asp:Label ID="lblEmpBase" runat="server" Text="基本資料" meta:resourcekey="lblEmpBaseResource1"></asp:Label>
</h3>
<table width="90%">
    <tr>
        <td style="width: 20%" valign="top">
            <uc1:AccountPicture ID="AccountPicture1" runat="server" />
        </td>
        <td valign="top">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="LightGoldenrodYellow"
                BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
                Font-Size="Small" ForeColor="Black" GridLines="None" Width="100%" 
                meta:resourcekey="DetailsView1Resource1">
                <FooterStyle BackColor="Tan" />
                <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <Fields>
                    <asp:BoundField DataField="Nobr" HeaderText="員工工號" SortExpression="Nobr" meta:resourcekey="BoundFieldResource1">
                        <HeaderStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="name_c" HeaderText="中文姓名" SortExpression="name_c" meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="name_e" HeaderText="英文姓名" SortExpression="name_e" meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="sex" HeaderText="性別" SortExpression="sex" meta:resourcekey="BoundFieldResource4" />
                    <asp:BoundField DataField="birdt" DataFormatString="{0:yyyy/MM/dd}" HeaderText="生日"
                        HtmlEncode="False" SortExpression="birdt" meta:resourcekey="BoundFieldResource5" />
                    <asp:BoundField DataField="idno" HeaderText="身份證" SortExpression="idno" meta:resourcekey="BoundFieldResource6" />
                    <asp:BoundField DataField="BLOOD" HeaderText="血型" />
                    <asp:BoundField DataField="MARRY" HeaderText="婚姻狀況" />
                </Fields>
                <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Size="Small" />
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <RowStyle Font-Size="Small" />
            </asp:DetailsView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                
                SelectCommand="SELECT Nobr,name_c,name_e,    CASE sex WHEN 'M' THEN '男' WHEN 'F' THEN '女' ELSE '中性' END as sex,birdt,substring(idno,1,5)+'xxxxx' as idno,BLOOD,MARRY FROM [base] WHERE ([Nobr] = @Nobr)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_nobr" Name="Nobr" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
</table>
<asp:Label ID="lb_nobr" runat="server" Visible="False" 
    meta:resourcekey="lb_nobrResource1" Font-Size="Small"></asp:Label>
