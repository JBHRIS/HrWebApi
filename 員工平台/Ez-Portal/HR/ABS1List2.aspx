<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABS1List2.aspx.cs" Inherits="HR_ABS1List2" Title="員工補休時數查詢" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<br />
            
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        meta:resourcekey="GridView2Resource1" Width="100%">
        <Columns>
            <asp:BoundField DataField="nobr" HeaderText="員工工號" 
                meta:resourcekey="BoundFieldResource1" />
            <asp:BoundField DataField="name" HeaderText="員工姓名" 
                meta:resourcekey="BoundFieldResource2" />
              <asp:BoundField DataField="name_e" HeaderText="英文名" />
              <asp:BoundField DataField="indt" HeaderText="到職日" 
                meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="dept" HeaderText="部門" 
                meta:resourcekey="BoundFieldResource4" Visible="False" />
            <asp:BoundField DataField="deptName" HeaderText="部門名稱" />
            <asp:BoundField DataField="a1" HeaderText="去年度剩餘補休" 
                meta:resourcekey="BoundFieldResource5" />
            <asp:BoundField DataField="a2" HeaderText="今年度補休" 
                meta:resourcekey="BoundFieldResource6" />
            <asp:BoundField DataField="a3" HeaderText="今年已請補休時數" 
                meta:resourcekey="BoundFieldResource7" />
            <asp:BoundField DataField="a4" HeaderText="可累計之補休時數" Visible="False" 
                meta:resourcekey="BoundFieldResource8" />
            <asp:BoundField DataField="a5" HeaderText="今年度剩餘補休時數" 
                meta:resourcekey="BoundFieldResource9" />
            <asp:BoundField DataField="a6" HeaderText="本月份已請補休時數" 
                meta:resourcekey="BoundFieldResource10" Visible="False" />
            <asp:BoundField DataField="a7" HeaderText="去年度剩餘年假未休時數" Visible="False" 
                meta:resourcekey="BoundFieldResource11">
                <ItemStyle ForeColor="Red" />
            </asp:BoundField>
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
            </asp:Content>

