<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttendCardList_mang1.aspx.cs" Inherits="Attendance_AttendCardList_mang1" Title="員工出勤表" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <fieldset>
                            <legend>查詢條件</legend>
                            <asp:Label ID="Label1" runat="server" Text="日期："></asp:Label>
                            <telerik:RadDatePicker ID="adate" runat="server">
                                <DateInput Skin="">
                                </DateInput></telerik:RadDatePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="至"></asp:Label>
                            <telerik:RadDatePicker ID="ddate" runat="server">
                                <DateInput Skin="">
                                </DateInput></telerik:RadDatePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                                ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date" />&nbsp;<asp:Button
                                ID="ExportExcel" runat="server" OnClick="ExportExcel_Click" Text="匯出Excel" />
                            <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>&nbsp;
                        </fieldset>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="NOBR" HeaderText="工號" SortExpression="NOBR" />
            <asp:BoundField DataField="NAME_C" HeaderText="姓名" SortExpression="NAME_C" />
            <asp:BoundField DataField="DEPT" HeaderText="部門" SortExpression="DEPT" />
            <asp:BoundField DataField="ADATE" HeaderText="日期"   SortExpression="ADATE" DataFormatString="{0:yyyy/MM/dd}" />
            <asp:BoundField DataField="ROTE" Visible="False" HeaderText="ROTE" SortExpression="ROTE" />
            <asp:BoundField DataField="ROTENAME" HeaderText="班別" SortExpression="ROTENAME" />
            <asp:BoundField DataField="ON_TIME" HeaderText="ON_TIME"  Visible="False" SortExpression="ON_TIME" />
            <asp:BoundField DataField="OFF_TIME" HeaderText="OFF_TIME"  Visible="False"   SortExpression="OFF_TIME" />
            <asp:TemplateField HeaderText="上班時間">
                <ItemTemplate>
                    <asp:Label ID="lb_inTime" runat="server"></asp:Label>
                     <asp:Label ID="lb_on_time" runat="server" Text='<%# Bind("ON_TIME")  %>' Visible="false" ></asp:Label>
                      <asp:Label ID="lb_off_time" runat="server" Text='<%# Bind("OFF_TIME") %>' Visible="false" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="下班時間">
                <ItemTemplate>
                    <asp:Label ID="lb_outTime" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="請假記錄">
                <ItemTemplate>
                    <asp:Label ID="lb_abs" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    &nbsp;
</asp:Content>

