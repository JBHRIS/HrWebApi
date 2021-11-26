<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalRpt3.aspx.cs" Inherits="CalRpt3" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
	Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
	<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
		rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
			DisplayGroupTree="False" HasCrystalLogo="False" HasDrillUpButton="False" HasGotoPageButton="False"
			HasViewList="False" Height="1121px" PrintMode="ActiveX" ReportSourceID="CrystalReportSource1"
			Width="878px" />
		<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
			<Report FileName="CalRpt3.rpt">
			</Report>
		</CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
