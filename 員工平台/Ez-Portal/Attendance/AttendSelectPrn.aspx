<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendSelectPrn.aspx.cs" Inherits="Attendance_AttendSelect" Title="e-HR" %>
<%@ Register Src="../Account/AccountPictureBind.ascx" TagName="AccountPictureBind" TagPrefix="uc2" %>
<%@ Register Src="../Account/AccountPicture.ascx" TagName="AccountPicture" TagPrefix="uc1" %>
<%@ Register src="RoteList.ascx" tagname="RoteList" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style>
 .class1{margin:0;padding:0;font-size:7pt;text-align:left;           
    }
    
    
    </style>
</head>
<body>
    <form id="form1" runat="server">    
    <uc3:RoteList 
                ID="RoteList1" runat="server" />
   </form>
</body>
</html>


