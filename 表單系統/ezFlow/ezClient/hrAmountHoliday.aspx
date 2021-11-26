<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="hrAmountHoliday.aspx.cs" Inherits="hrAmountHoliday" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="mv" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td nowrap="nowrap">
                        1.特休計算年度為何西元年？
                        <asp:TextBox ID="txtYear" runat="server" MaxLength="4" Width="40px">9999</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        2.特休計算起始日？<asp:RadioButtonList ID="rblDateB" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">到職日</asp:ListItem>
                            <asp:ListItem Value="2">到職年+自訂年月</asp:ListItem>
                        </asp:RadioButtonList><asp:TextBox ID="txtMonthDayB" runat="server" MaxLength="5"
                            Width="40px">1/1</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        3.特休計算結束日？<asp:RadioButtonList ID="rblDateE" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">計算年度+到職年月</asp:ListItem>
                            <asp:ListItem Value="2">計算年度+自訂年月</asp:ListItem>
                        </asp:RadioButtonList><asp:TextBox ID="txtMonthDayE" runat="server" MaxLength="5"
                            Width="40px">12/31</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        4.特休給假開始日？<asp:RadioButtonList ID="rblDateA" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">特休計算結束日</asp:ListItem>
                            <asp:ListItem Value="2">特休計算結束日加一年</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        5.特休給假結束日？一律以一年計算</td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        6.給假設定(單位：<asp:Label ID="lblHcode" runat="server"></asp:Label>)</td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職未滿1年<asp:RadioButtonList ID="rblHoliday" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">不給假</asp:ListItem>
                            <asp:ListItem Value="2">依整年比例分配(四捨五入)</asp:ListItem>
                            <asp:ListItem Value="3">自訂</asp:ListItem>
                        </asp:RadioButtonList><asp:TextBox ID="txtHoliday0" runat="server" MaxLength="4"
                            Width="40px">0</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿1年<asp:TextBox ID="txtHoliday1" runat="server" MaxLength="4" Width="40px">56</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿2年<asp:TextBox ID="txtHoliday2" runat="server" MaxLength="4" Width="40px">56</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿3年<asp:TextBox ID="txtHoliday3" runat="server" MaxLength="4" Width="40px">80</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿4年<asp:TextBox ID="txtHoliday4" runat="server" MaxLength="4" Width="40px">80</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿5年<asp:TextBox ID="txtHoliday5" runat="server" MaxLength="4" Width="40px">112</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿6年<asp:TextBox ID="txtHoliday6" runat="server" MaxLength="4" Width="40px">112</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿7年<asp:TextBox ID="txtHoliday7" runat="server" MaxLength="4" Width="40px">112</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿8年<asp:TextBox ID="txtHoliday8" runat="server" MaxLength="4" Width="40px">112</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿9年<asp:TextBox ID="txtHoliday9" runat="server" MaxLength="4" Width="40px">112</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        到職滿10年後每1年加<asp:TextBox ID="txtHoliday10" runat="server" MaxLength="4" Width="40px">8</asp:TextBox></td>
                </tr>
                <tr>
                    <td nowrap="nowrap">
                        <asp:Button ID="btnAmount" runat="server" OnClick="btnAmount_Click" OnClientClick="return confirm('您確定要產生名單嗎？產生名單後資料會先顯示出來，待按儲存後才會存入資料庫。');"
                            Text="產生" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="iAutoKey" Width="100%">
                <Columns>
                    <asp:BoundField DataField="sNobr" HeaderText="工號" SortExpression="sNobr">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sName" HeaderText="姓名">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dDatetimeB" DataFormatString="{0:d}" HeaderText="生效日"
                        HtmlEncode="False" SortExpression="dDatetimeB">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dDatetimeE" DataFormatString="{0:d}" HeaderText="失效日"
                        HtmlEncode="False" SortExpression="dDatetimeE">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sHcodeCode" HeaderText="假別代碼" SortExpression="sHcodeCode">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="iHour" HeaderText="總時數" SortExpression="iHour">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="return confirm('您確定要儲存嗎？');"
                Text="儲存" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="放棄儲存" /></asp:View>
    </asp:MultiView>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>

