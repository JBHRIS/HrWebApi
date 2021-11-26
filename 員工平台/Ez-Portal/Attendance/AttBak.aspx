<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttBak.aspx.cs" Inherits="Attendance_AttBak" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
        <legend>匯入備勤人員資料</legend>
        <table id="Table4" border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td align="left" width="70%">
                    <asp:FileUpload ID="txtUpload" runat="server" />&nbsp;<asp:Button ID="Button1" runat="server"
                        OnClick="Button1_Click" Text="開始上傳" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                    <asp:DropDownList ID="ddlJob" runat="server" Visible="False">
                    </asp:DropDownList>
                    <asp:Label ID="lab2" runat="server" Visible="False">評等</asp:Label>
                    <asp:Label ID="Label6" runat="server" Visible="False">工號：</asp:Label>
                    <asp:Label ID="Label2" runat="server" Visible="False">排序</asp:Label></td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="開始匯入" />&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddeff" runat="server" Visible="False">
                    </asp:DropDownList>
                    <asp:TextBox ID="tb_year" runat="server" Visible="False" Width="50px"></asp:TextBox>
                    <asp:TextBox ID="tb_month" runat="server" Visible="False" Width="48px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td style="width: 71px">
                    <asp:DropDownList ID="ddorder" runat="server" Visible="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                    <asp:Label ID="showMsg" runat="server" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 71px; height: 34px">
                    &nbsp;
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left" valign="bottom">
                    <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal">
                        <StaticMenuStyle CssClass="menu" />
                        <StaticMenuItemStyle CssClass="menuItem" />
                        <StaticSelectedStyle CssClass="menuSelectedItem" />
                        <DynamicMenuStyle CssClass="menuPopup" />
                        <DynamicMenuItemStyle CssClass="menuPopupItem" Font-Strikeout="False" />
                        <DynamicHoverStyle CssClass="menuPopupItem" />
                        <StaticHoverStyle CssClass="menuItemHover" />
                    </asp:Menu>
                </td>
                <td style="width: 71px" valign="bottom">
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>

