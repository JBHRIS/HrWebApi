<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyFrame.aspx.cs" Inherits="MyFrame" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>對話盒</title>
</head>
<body scroll=no class="none">	
<iframe frameborder=0 width=100% height=100% src='<%= Request["url"] %>' style="background-color:White"></iframe>	
</body>
</html>
