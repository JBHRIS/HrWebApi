<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransOldOjtCourse.aspx.cs" Inherits="TransOldOjtCourse" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:radscriptmanager ID="RadScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.Core.js">
        </asp:ScriptReference>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.jQuery.js">
        </asp:ScriptReference>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.jQueryInclude.js">
        </asp:ScriptReference>
    </Scripts>
</telerik:radscriptmanager>
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="修正" />
    
        <Radbutton ID="RadButton1" runat="server" BorderStyle="Dotted" 
    Skin="Telerik" Text="RadButton">
</Radbutton>
    
    </div>
    <RadButton ID="RadButton2" runat="server" onclick="RadButton2_Click" 
        Text="RadButton">
    </RadButton>
    </form>
</body>
</html>
