<%@ Page Title="課程異常處理" Language="C#" AutoEventWireup="true"
    CodeFile="ClassExceptionProcess.aspx.cs" Inherits="eTraining_Reports_Admin_Do_ClassExceptionProcess" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        課程異常處理</h2>
    <telerik:RadButton ID="btnCancelClassPublish" runat="server" Text="取消發佈" 
        onclick="btnCancelClassPublish_Click">
    </telerik:RadButton>
    <br />
    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
    <br />

        </div>
    </form>
</body>
</html>