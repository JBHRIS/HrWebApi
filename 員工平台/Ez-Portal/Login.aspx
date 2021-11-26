<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    MasterPageFile="~/LoginMasterPage.master" Title="e-HR" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="layout">
        <div id="loginblock">
            <table width="100%">
                <tr>
                    <td align="right">
                        <asp:Label ID="lblID" runat="server" meta:resourcekey="lblIDResource1" Text="帳號"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLogin" runat="server" Width="100px" meta:resourcekey="txtLoginResource1"
                            TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_Login" runat="server" ControlToValidate="txtLogin"
                            Display="Dynamic" ErrorMessage="*不可空白" meta:resourcekey="RFV_LoginResource1"
                            Text="*不可空白"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPW" runat="server" meta:resourcekey="lblPWResource1" Text="密碼"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPass" runat="server" Width="100px" TextMode="Password" meta:resourcekey="txtPassResource1"
                            TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_PassWord" runat="server" ControlToValidate="txtPass"
                            Display="Dynamic" ErrorMessage="*不可空白" meta:resourcekey="RFV_PassWordResource1"
                            Text="*不可空白"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblRemeberMsg" runat="server" Text="記憶密碼" meta:resourcekey="lblRemeberMsgResource1"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlRem" runat="server" Width="100px" OnSelectedIndexChanged="ddlLang_SelectedIndexChanged"
                            TabIndex="4" meta:resourcekey="ddlRemResource1">
                            <asp:ListItem meta:resourcekey="ListItemResource6" Value="0">不記憶</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True" meta:resourcekey="ListItemResource3">一天</asp:ListItem>
                            <asp:ListItem Value="30" meta:resourcekey="ListItemResource4">一個月</asp:ListItem>
                            <asp:ListItem Value="180" meta:resourcekey="ListItemResource5">六個月</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:DropDownList ID="ddlLang" runat="server" Width="100px" meta:resourcekey="ddlLangResource1"
                            OnSelectedIndexChanged="ddlLang_SelectedIndexChanged" TabIndex="4" Visible="False">
                            <asp:ListItem Value="en-US" meta:resourcekey="ListItemResource1">English</asp:ListItem>
                            <asp:ListItem Selected="True" Value="zh-TW" meta:resourcekey="ListItemResource2">繁體</asp:ListItem>
                        </asp:DropDownList>
                        <asp:LinkButton ID="lbtnForgetPwd" runat="server" onclick="lbtnForgetPwd_Click" 
                            ValidationGroup="B" meta:resourcekey="lbtnForgetPwdResource1">Forget password?</asp:LinkButton>
                    </td>
                    <td>
                        <asp:Button ID="btn_login" runat="server" Text="登入" OnClick="btn_login_Click" meta:resourcekey="btn_loginResource1"
                            TabIndex="3" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
