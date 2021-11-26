<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrnClassCalendar.aspx.cs" Inherits="eTraining_Reports_Review_PrnClassCalendar" %>

<%@ Register src="../../../UC/UC_ClassCalendar.ascx" tagname="UC_ClassCalendar" tagprefix="uc1" %>

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
        <uc1:UC_ClassCalendar ID="UC_ClassCalendar1" runat="server" />
    
    </div>
    <asp:Button ID="btnPrint" runat="server" Text="列印" onclick="btnPrint_Click" />
    </form>
</body>
</html>
