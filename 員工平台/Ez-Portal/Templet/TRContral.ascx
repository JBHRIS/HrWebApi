<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TRContral.ascx.cs" Inherits="Templet_TRContral" %>
<h3>
    <asp:Localize ID="Localize1" runat="server">本季教育訓練</asp:Localize>
</h3>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataSourceID="SqlDataSource1" SkinID="Yahoo">
    <Columns>
        <asp:BoundField DataField="COSCODE" HeaderText="課程代碼" SortExpression="COSCODE" />
        <asp:BoundField DataField="DESCR" HeaderText="課程名稱" SortExpression="DESCR" />
        <asp:BoundField DataField="COSINTRO" HeaderText="課程簡介" SortExpression="COSINTRO" />
        <asp:BoundField DataField="COSDATEB" DataFormatString="{0:d}" HeaderText="開訓日期" HtmlEncode="False"
            SortExpression="COSDATEB" />
        <asp:BoundField DataField="COSDATEE" DataFormatString="{0:d}" HeaderText="結訓日期" HtmlEncode="False"
            SortExpression="COSDATEE" />
        <asp:BoundField DataField="COSTIMEB" HeaderText="開訓時間" SortExpression="COSTIMEB" />
        <asp:BoundField DataField="COSTIMEE" HeaderText="結訓時間" SortExpression="COSTIMEE" />
        <asp:BoundField DataField="HOURS" HeaderText="總時數" SortExpression="HOURS" />
        <asp:BoundField DataField="ADDRDESCR" HeaderText="上課地點" SortExpression="ADDRDESCR" />
    </Columns>
    <EmptyDataTemplate>
        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"></asp:Label>
    </EmptyDataTemplate>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
    SelectCommand="SELECT TRCOS.COSCODE, TRCOS.DESCR, TRCOS.COSDATEB, TRCOS.COSDATEE, TRCOS.COSTIMEB, TRCOS.COSTIMEE, TRCOS.HOURS, TRCOS.COSINTRO, TRADDRCD.ADDRDESCR FROM TRCOS LEFT OUTER JOIN TRADDRCD ON TRCOS.ADDRCD = TRADDRCD.ADDRCD WHERE  CONVERT (char(10),  TRCOS.COSDATEB, 111) BETWEEN  CONVERT (char(10), GETDATE(), 111)&#13;&#10;AND @date_e">
    <SelectParameters>
        <asp:ControlParameter ControlID="lb_datee" Name="date_e" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:Label ID="lb_datee" runat="server" Visible="False"></asp:Label><br />
