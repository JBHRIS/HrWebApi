<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="關閉視窗" />
    
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="顯示" />
    
    </div>
    <div runat="server" id="ShowWindow" visible="false">
<iframe id="ifm1" name="iframe1" src="default.aspx" scrolling="auto" runat="server" 
            height="500" width="700">
</iframe>
</div>
    </form>
</body>
</html>
