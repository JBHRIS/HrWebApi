<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeContactByUser.ascx.cs" Inherits="Employee_EmployeeContactByUser" %>
<h3>
            <asp:Label ID="lblContact" runat="server" Text="通訊資料" 
            meta:resourcekey="lblContactResource1"></asp:Label></h3>
        <asp:DetailsView ID="DetailsView1" runat="server" 
    AutoGenerateRows="False" BackColor="White"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
    CellPadding="4" DataSourceID="SqlDataSource1"
            Font-Size="Small" ForeColor="Black" GridLines="Vertical" Width="90%" 
            meta:resourcekey="DetailsView1Resource1">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" Font-Size="Small" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <Fields>
                <asp:BoundField DataField="gsm" HeaderText="手機" SortExpression="gsm" 
                    meta:resourcekey="BoundFieldResource1" >
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="eMail" SortExpression="email" 
                    Visible="False" meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="tel1" HeaderText="戶籍電話" SortExpression="tel1" 
                    Visible="False" meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="tel2" HeaderText="通訊電話" SortExpression="tel2"  
                    Visible="False" meta:resourcekey="BoundFieldResource4"/>
                <asp:BoundField DataField="postcode1" HeaderText="戶籍郵政區號" 
                    SortExpression="postcode1"  Visible="False" 
                    meta:resourcekey="BoundFieldResource5"/>
                <asp:BoundField DataField="addr1" HeaderText="戶籍地址" SortExpression="addr1"  
                    Visible="False" meta:resourcekey="BoundFieldResource6"/>
                <asp:BoundField DataField="postcode2" HeaderText="通訊地址區號" 
                    SortExpression="postcode2" Visible="False" 
                    meta:resourcekey="BoundFieldResource7" />
                <asp:BoundField DataField="addr2" HeaderText="通訊地址" SortExpression="addr2"  
                    Visible="False" meta:resourcekey="BoundFieldResource8"/>
                <asp:BoundField DataField="province" HeaderText="戶籍地" SortExpression="province" 
                    Visible="False" meta:resourcekey="BoundFieldResource9" />
                <asp:BoundField DataField="born_addr" HeaderText="出生地" 
                    SortExpression="born_addr" Visible="False" 
                    meta:resourcekey="BoundFieldResource10" />
            </Fields>
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" 
                Font-Size="Small" />
            <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    DeleteCommand="DELETE FROM [base] WHERE [Nobr] = @Nobr" InsertCommand="INSERT INTO [base] ([Nobr], [addr1], [addr2], [tel1], [tel2], [bbcall], [email], [gsm], [postcode1], [postcode2], [born_addr], [province]) VALUES (@Nobr, @addr1, @addr2, @tel1, @tel2, @bbcall, @email, @gsm, @postcode1, @postcode2, @born_addr, @province)"
    SelectCommand="SELECT NOBR, ADDR1, ADDR2, TEL1, TEL2, BBCALL, EMAIL, GSM, POSTCODE1, POSTCODE2, BORN_ADDR, PROVINCE FROM BASE WHERE (NOBR = @Nobr)"
    UpdateCommand="UPDATE [base] SET [addr1] = @addr1, [addr2] = @addr2, [tel1] = @tel1, [tel2] = @tel2, [bbcall] = @bbcall, [email] = @email, [gsm] = @gsm, [postcode1] = @postcode1, [postcode2] = @postcode2, [born_addr] = @born_addr, [province] = @province WHERE [Nobr] = @Nobr">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_nobr" Name="Nobr" PropertyName="Text" Type="String" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Nobr" Type="String" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="addr1" Type="String" />
        <asp:Parameter Name="addr2" Type="String" />
        <asp:Parameter Name="tel1" Type="String" />
        <asp:Parameter Name="tel2" Type="String" />
        <asp:Parameter Name="bbcall" Type="String" />
        <asp:Parameter Name="email" Type="String" />
        <asp:Parameter Name="gsm" Type="String" />
        <asp:Parameter Name="postcode1" Type="String" />
        <asp:Parameter Name="postcode2" Type="String" />
        <asp:Parameter Name="born_addr" Type="String" />
        <asp:Parameter Name="province" Type="String" />
        <asp:Parameter Name="Nobr" Type="String" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="Nobr" Type="String" />
        <asp:Parameter Name="addr1" Type="String" />
        <asp:Parameter Name="addr2" Type="String" />
        <asp:Parameter Name="tel1" Type="String" />
        <asp:Parameter Name="tel2" Type="String" />
        <asp:Parameter Name="bbcall" Type="String" />
        <asp:Parameter Name="email" Type="String" />
        <asp:Parameter Name="gsm" Type="String" />
        <asp:Parameter Name="postcode1" Type="String" />
        <asp:Parameter Name="postcode2" Type="String" />
        <asp:Parameter Name="born_addr" Type="String" />
        <asp:Parameter Name="province" Type="String" />
    </InsertParameters>
</asp:SqlDataSource>
<asp:Label ID="lb_nobr" runat="server" Visible="False" 
    meta:resourcekey="lb_nobrResource1" Font-Size="Small"></asp:Label>
