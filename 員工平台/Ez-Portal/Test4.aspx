<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test4.aspx.cs" Inherits="Test4" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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
    
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="333" />
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
        <telerik:RadEditor ID="RadEditor1" Runat="server" 
            ContentFilters="RemoveScripts, FixUlBoldItalic" 
            ToolsFile="~/Editor/RadEditor/NoneTools.xml">
        </telerik:RadEditor>
    
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
    
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
            Text="mailTest" />
    
        <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="Button" />
    
        <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="xml" />
    
        <br />
        <telerik:RadGrid ID="RadGrid1" runat="server">
        </telerik:RadGrid>
    
    </div>
    </form>
</body>
</html>
