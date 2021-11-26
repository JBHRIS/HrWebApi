<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="SalaryWeb.Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    </div>
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,Account_aspx_EmpNameLabel_DisplayText%>" ></asp:Label>
        <asp:TextBox ID="empidLabel" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        <br/>
        <asp:Label ID="ShowMsgLabel" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
