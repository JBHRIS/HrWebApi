<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="SalaryWeb.Entry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="TicketLabel" runat="server" Visible="False"></asp:Label>
        <asp:Label runat="server" ID="EmpIdLabel" Visible="False"></asp:Label>
        <asp:Label ID="showMsgLabel" runat="server" Text=""></asp:Label>
        <div id="initialDiv" runat="server" visible="False">
            <asp:Label ID="Label3" runat="server" Text="<%$Resources:Resource,Entry_aspx_initEnterPassword%>"></asp:Label>
            <asp:TextBox ID="NewPasswordTextBox1" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="<%$Resources:Resource,Entry_aspx_initEnterPasswordConfirm %>"></asp:Label>
            <asp:TextBox ID="NewPasswordTextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="SetNewPasswordBtn" runat="server" Text="Submit" OnClick="SetNewPasswordBtn_Click" />
        </div>
        <div id="queryDiv" runat="server">


            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,Entry_aspx_EnterEmpId%>"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="EmpIdTextBox" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,Entry_aspx_EnterPassword%>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                             <asp:DropDownList ID="LanguageDropdownlist" runat="server">
                            <%--<asp:ListItem  Value="EN">English</asp:ListItem>--%>
                            <asp:ListItem Selected="True" Value="zh-tw">中文</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;"></td>
                    <td>
                        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" Style="height: 26px" />
                        <asp:Button ID="InitialPWButton" runat="server" Text="<%$Resources:Resource,Entry_aspx_initSetPasswordShowName%>" OnClick="InitialPWButton_Click" />
                    </td>
                </tr>
            </table>
            <br />


        </div>
        <div runat="server" id="SalaryDiv" visible="False">
            <asp:DropDownList ID="YYMMSelect" runat="server" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="YYMMSelect_SelectedIndexChanged">
                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
