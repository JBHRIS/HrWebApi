<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPwd.aspx.cs" Inherits="ForgetPwd"
    MasterPageFile="~/LoginMasterPage.master" Title="e-HR" Culture="auto" 
    UICulture="auto" meta:resourcekey="PageResource1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="layout">
        <div id="loginblock">
            <table width="100%">
                <tr>
                    <td colspan="2">

                        <asp:Label ID="lblHeaderMsg" runat="server" ForeColor="#0033CC" 
                            meta:resourcekey="lblHeaderMsgResource1" 
                            Text="Please Input Your Logon Employee no. The system will send the password to the registered email address."></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                                                <asp:Label ID="lblID" runat="server" meta:resourcekey="lblIDResource1" 
                            Text="Employee no."></asp:Label></td>
                    <td align="left">
                                                <asp:TextBox ID="tbId" runat="server" Width="100px" meta:resourcekey="txtLoginResource1"
                            TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvId" runat="server" ControlToValidate="tbID"
                            Display="Dynamic" ErrorMessage="*不可空白" meta:resourcekey="RFV_LoginResource1"
                            Text="*不可空白"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" meta:resourcekey="btn_loginResource1"
                            TabIndex="3" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
