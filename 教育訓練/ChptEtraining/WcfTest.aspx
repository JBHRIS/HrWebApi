﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WcfTest.aspx.cs" Inherits="WcfTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    
    </div>
    <telerik:RadGrid ID="RadGrid1" runat="server">
    </telerik:RadGrid>
    </form>
</body>
</html>
