<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Output.aspx.cs" Inherits="Output" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
        <style type="text/css">
        .return
        {
            display: inline-block;
            background: #603;
            padding: 5px 10px 5px 10px;
            border-radius: 4px;
            color: #fff;
            font-family: 微軟正黑體;
            font-weight: bold;
            font-size: 14px;
            text-decoration: none;
        }
    </style>
</head>
<body style="background-color: #ffffff">
    <form id="form1" runat="server">  
    
    <asp:Button ID="btnReturn" runat="server" Text="回首頁" 
        onclick="btnReturn_Click"      CssClass="return"   />
		<img src="DrawImage.aspx" />
    </form>
</body>
</html>
