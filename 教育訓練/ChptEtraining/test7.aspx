<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test7.aspx.cs" Inherits="test7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
          <div id="NavigateUrlZone" >
          <asp:Button ID="Button4" Text="open the window" runat="server" OnClientClick="openWinNavigateUrl(); return false;">
          </asp:Button>

     </div>
        
        <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="Button" />
        <br />
    
    </div>
    <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="Button" />
    </form>
</body>
</html>
