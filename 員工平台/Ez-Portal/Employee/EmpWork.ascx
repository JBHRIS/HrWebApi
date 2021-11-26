<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpWork.ascx.cs" Inherits="Employee_EmpWork" %>
<div class="BlueForm">
<div class="BlueFormHeader">
<span class="BHLeft"></span>
<span class="BHeader">經歷</span>
<span class="BHRight"></span>
</div>
<div class="BlueFormContent">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
        Font-Size="X-Small" ForeColor="Black" GridLines="None" Width="90%">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:BoundField DataField="COMPANY" HeaderText="公司名稱" SortExpression="COMPANY" />
            <asp:BoundField DataField="TITLE" HeaderText="職稱" SortExpression="TITLE" />
            <asp:BoundField DataField="BDATE" DataFormatString="{0:d}" HeaderText="開始日期" HtmlEncode="False"
                SortExpression="BDATE" />
            <asp:BoundField DataField="EDATE" DataFormatString="{0:d}" HeaderText="截止日期" HtmlEncode="False"
                SortExpression="EDATE" />
        </Columns>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        SelectCommand="SELECT COMPANY, TITLE, BDATE, EDATE FROM WORKS WHERE (NOBR = @nobr) ORDER BY BDATE">
        <SelectParameters>
            <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;</div>
<div class="BlueFormFooter">
<span class="BFLeft"></span>
<span class="BFRight"></span>
</div>
</div>
<asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>