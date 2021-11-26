<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="hrHoliday.aspx.cs" Inherits="hrHoliday" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td nowrap="nowrap">
                <asp:DropDownList ID="ddlBase" runat="server" AppendDataBoundItems="True"
                    DataSourceID="sdsBase" DataTextField="sName" DataValueField="sNobr">
                    <asp:ListItem Value=" ">所有人</asp:ListItem>
                </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlRote" runat="server" AppendDataBoundItems="True" DataSourceID="sdsRote" DataTextField="sRoteName" DataValueField="sRoteCode">
                    <asp:ListItem Value=" ">所有班別</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlHoliday" runat="server">
                    <asp:ListItem Value="1">休假</asp:ListItem>
                    <asp:ListItem Value="0">上班</asp:ListItem>
                    <asp:ListItem Value="2">清除設定</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="sdsBase" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                    SelectCommand="SELECT sNobr, sName FROM hrBaseM WHERE (GETDATE() BETWEEN dDateA AND dDateD) ORDER BY sNobr">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sdsRote" runat="server" ConnectionString="<%$ ConnectionStrings:ezflowConnectionString %>"
                    SelectCommand="SELECT [sRoteCode], [sRoteName] FROM [hrRote]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">
                <asp:Calendar ID="cldHoliday" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana"
                    Font-Size="9pt" ForeColor="Black" OnDayRender="cldHoliday_DayRender" Width="100%" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth" OnSelectionChanged="cldHoliday_SelectionChanged">
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                    <DayHeaderStyle ForeColor="#333333" Height="8pt" Font-Bold="True" Font-Size="8pt" />
                    <TitleStyle BackColor="#333399" Font-Bold="True"
                        Font-Size="12pt" ForeColor="White" Height="12pt" BorderStyle="Solid" />
                    <DayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

