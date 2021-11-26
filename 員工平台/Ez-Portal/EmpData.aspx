<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmpData.aspx.cs" Inherits="EmpData" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lb_dept" runat="server" Visible="False"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" />
            <asp:BoundField DataField="NAME_C" HeaderText="NAME_C" SortExpression="NAME_C" />
            <asp:BoundField DataField="INDT" HeaderText="INDT" SortExpression="INDT" />
            <asp:BoundField DataField="DEPT" HeaderText="DEPT" SortExpression="DEPT" />
            <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" />
            <asp:BoundField DataField="JOB" HeaderText="JOB" SortExpression="JOB" />
            <asp:BoundField DataField="JOB_NAME" HeaderText="JOB_NAME" SortExpression="JOB_NAME" />
            <asp:BoundField DataField="EMPCD" HeaderText="EMPCD" SortExpression="EMPCD" />
            <asp:BoundField DataField="EMPDESCR" HeaderText="EMPDESCR" SortExpression="EMPDESCR" />
            <asp:CheckBoxField DataField="MANG" HeaderText="MANG" SortExpression="MANG" />
            <asp:BoundField DataField="DI" HeaderText="DI" SortExpression="DI" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="HRDsTableAdapters.HR_Portal_EmpInfoTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="dept" QueryStringField="dept" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

