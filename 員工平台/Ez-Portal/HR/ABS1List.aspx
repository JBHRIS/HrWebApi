<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true" CodeFile="ABS1List.aspx.cs" Inherits="HR_ABS1List" Title="Untitled Page" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<br />
    <asp:Button ID="btnExportExcel" runat="server" onclick="btnExportExcel_Click" 
        Text="匯出Excel" />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        meta:resourcekey="GridView2Resource1">
        <Columns>
            <asp:BoundField DataField="nobr" HeaderText="員工工號" 
                meta:resourcekey="BoundFieldResource1" />
            <asp:BoundField DataField="name" HeaderText="員工姓名" 
                meta:resourcekey="BoundFieldResource2" />
              <asp:BoundField DataField="indt" HeaderText="到職日" 
                meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="dept" HeaderText="部門" 
                meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="d_name" HeaderText="部門名稱" />
            <asp:BoundField DataField="a1" HeaderText="去年度剩餘年假" 
                meta:resourcekey="BoundFieldResource5" />
            <asp:BoundField DataField="a2" HeaderText="今年度年假" 
                meta:resourcekey="BoundFieldResource6" />
            <asp:BoundField DataField="BDATE" DataFormatString="{0:d}" 
                HeaderText="今年度特休得假日" />
            <asp:BoundField DataField="a3" HeaderText="今年已請天數" 
                meta:resourcekey="BoundFieldResource7" />
            <asp:BoundField DataField="a4" HeaderText="可累計之天數" Visible="False" 
                meta:resourcekey="BoundFieldResource8" />
            <asp:BoundField DataField="a5" HeaderText="今年度剩餘天數" 
                meta:resourcekey="BoundFieldResource9" />
            <asp:BoundField DataField="a6" HeaderText="本月份已請天數" 
                meta:resourcekey="BoundFieldResource10" />
            <asp:BoundField DataField="a7" HeaderText="去年度剩餘年假未休天數" Visible="False" 
                meta:resourcekey="BoundFieldResource11">
                <ItemStyle ForeColor="Red" />
            </asp:BoundField>
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
</asp:Content>

