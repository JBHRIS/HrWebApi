<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeContactPeople.ascx.cs" Inherits="Employee_EmployeeContactPeople" %>
<h3>
            <asp:Label ID="lblContact" runat="server" Text="連絡人資料" 
            meta:resourcekey="lblContactResource1"></asp:Label>
            </h3>
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
                <asp:BoundField DataField="cont_man" HeaderText="連絡人" SortExpression="cont_man" 
                    meta:resourcekey="BoundFieldResource1" >
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="rel_name" HeaderText="連絡人關係" 
                    SortExpression="rel_name" meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="cont_tel" HeaderText="連絡人電話" 
                    SortExpression="cont_tel" meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="cont_gsm" HeaderText="連絡人手機" 
                    SortExpression="cont_gsm" meta:resourcekey="BoundFieldResource4" />
                <asp:BoundField DataField="cont_man2" HeaderText="連絡人2" 
                    SortExpression="cont_man2" Visible="False" 
                    meta:resourcekey="BoundFieldResource5" />
                <asp:BoundField DataField="Expr1" HeaderText="連絡人關係2" SortExpression="Expr1" 
                    Visible="False" meta:resourcekey="BoundFieldResource6" />
                <asp:BoundField DataField="cont_tel2" HeaderText="連絡人電話2" 
                    SortExpression="cont_tel2" Visible="False" 
                    meta:resourcekey="BoundFieldResource7" />
                <asp:BoundField DataField="cont_gsm2" HeaderText="連絡人手機2" 
                    SortExpression="cont_gsm2" Visible="False" 
                    meta:resourcekey="BoundFieldResource8" />
            </Fields>
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" 
                Font-Size="Small" />
            <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
            SelectCommand="SELECT base.cont_man, base.cont_tel, base.cont_gsm, base.cont_man2, base.cont_tel2, base.cont_gsm2, base.CONT_REL1, base.CONT_REL2, relcode.rel_name, relcode_1.rel_name AS Expr1 FROM base LEFT OUTER JOIN relcode AS relcode_1 ON base.CONT_REL2 = relcode_1.rel_code LEFT OUTER JOIN relcode ON base.CONT_REL1 = relcode.rel_code&#13;&#10;where nobr =@nobr ">
            <SelectParameters>
                <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
<asp:Label ID="lb_nobr" runat="server" Visible="False" 
    meta:resourcekey="lb_nobrResource1" Font-Size="Small"></asp:Label>
