<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsCertificate.aspx.cs" Inherits="SalaryWeb.InsCertificate" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <table class="TableFullBorder">
            <tr>
                <td align="right" colspan="2" style="text-align: left">
                    <%--<span style="color: red">由於安全性嚴謹的考量，如果點「查詢」沒有反應，請重新登入此頁再進行查詢。--%><asp:SqlDataSource ID="sdsYear"
                        runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                        SelectCommand="select year as sValue,note as sText from lock_yr where YEAR &lt;=year(getdate()) and type_name='保費證明' and adate &lt; getdate() order by year desc"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sdsYear1"
                        runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                        SelectCommand="select year as sValue,note as sText from lock_yr where YEAR &lt;=year(getdate()) and type_name='保費證明'  order by year desc"></asp:SqlDataSource>
                    <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblYear" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <span style="color: red">
            <div id="printDiv">
                <rsweb:ReportViewer ID="RptViewer" runat="server" ClientIDMode="Static"
                    Height="1200px" Width="863px" AsyncRendering="False" InteractivityPostBackMode="AlwaysSynchronous" KeepSessionAlive="False" ShowRefreshButton="False" ShowPrintButton="False">
                </rsweb:ReportViewer>
                <script type="text/javascript">
                    function RptExportPdf() {
                        var exportEle = document.getElementById('RptViewer_ctl05_ctl04_ctl00_Menu');
                        if (exportEle) {
                            exportEle.children[0].style.display = 'none';
                            exportEle.children[2].style.display = 'none';
                        }
                    }
                    new RptExportPdf();
                </script>
    </form>
</body>
</html>
