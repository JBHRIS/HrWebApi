<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="onlineSing.aspx.cs" Inherits="Attendance_onlineSing" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <h3>
                    <asp:Label ID="lblHeaderMsg" runat="server" Text="線上簽到"></asp:Label>
                </h3>
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="簽到確認！" />
                    <fieldset>
                        <legend>簽到資訊</legend>&nbsp; &nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="簽到時間："></asp:Label>
                        <asp:Label ID="lb_time" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><br />
                        &nbsp; &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="IP位址："></asp:Label>
                        <asp:Label ID="lb_ipadd" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></fieldset>
                <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
<%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">程式說明</span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            1.員工可用此功能完成刷卡程序！<br />
            2.點選『簽到確認』後，簽到資訊就會出現簽到的時間及員工使用電腦的IP位子！<br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
