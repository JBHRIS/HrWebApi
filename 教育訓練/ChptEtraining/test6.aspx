<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test6.aspx.cs" Inherits="test6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
          <div id="NavigateUrlZone" >
          <asp:Button ID="Button4" Text="open the window" runat="server" OnClientClick="openWinNavigateUrl(); return false;">
          </asp:Button>
          <script type="text/javascript">
              function openWinNavigateUrl() {
                  $find("<%=RadWindow1.ClientID %>").show();
              }
          </script>
     </div>
        
        <telerik:RadWindow ID="RadWindow1" runat="server" NavigateUrl="~/test3.aspx" 
            Modal="True">
        </telerik:RadWindow>
        <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="Button" />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <br />
    
    </div>
    <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="Button" />
    </form>
</body>
</html>
