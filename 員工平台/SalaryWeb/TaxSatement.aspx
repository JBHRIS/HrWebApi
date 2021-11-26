<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaxSatement.aspx.cs" Inherits="SalaryWeb.TaxSatement" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    
    </div>



    <table class="TableFullBorder">
        <tr>
            <th align="right" colspan="2" style="text-align: center" >
                年度所得查詢
            </th>
        </tr>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
     <tr>
            <th align="right" nowrap="true" width="1%">Year
                                
            </th>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" DataSourceID="sdsYear"
                    DataTextField="sText" DataValueField="sValue" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
    </asp:Panel>
        
    <asp:Panel ID="Panel2" runat="server" Visible="false">
         <tr>
                         <th align="right" nowrap="true" width="1%">Employee No                                
                            </th>
                            <td>
                                <asp:TextBox ID="TextNobr" runat="server" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
         <tr>
            
            <th align="right" nowrap="true" width="1%">Year
                                
            </th>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlYear1" runat="server" AutoPostBack="True" DataSourceID="sdsYear1"
                    DataTextField="sText" DataValueField="sValue" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
    </asp:Panel>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td style="text-align: left">
                <%--<asp:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" ValidationGroup="fvSalary" ClientIDMode="Static" />--%>
                <asp:Label ID="lblPassCount" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
                            <td align="right" style="text-align: left">
                                <%--<span style="color: red">由於安全性嚴謹的考量，如果點「查詢」沒有反應，請重新登入此頁再進行查詢。--%><asp:SqlDataSource ID="sdsYear"
                                    runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                                    
                                    
                                    
                                    
                                    
                                    SelectCommand="select year as sValue,note as sText from lock_yr where YEAR&lt;=year(getdate()) and type_name='年度所得' and adate &lt; getdate() order by year desc">
                                </asp:SqlDataSource> 
                                
                                <asp:SqlDataSource ID="sdsYear1"
                                    runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                                    
                                    
                                    
                                    
                                    SelectCommand="SELECT YEAR AS sValue, NOTE AS sText FROM LOCK_YR WHERE (YEAR &lt;= YEAR(GETDATE())) AND (TYPE_NAME = '年度所得') ORDER BY sValue DESC">
                                </asp:SqlDataSource> 
                                <asp:Label ID="lblNobr" runat="server" Visible="False"></asp:Label>
                               <asp:Label ID="lblYear" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
</table>

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <span style="color: red">
                   
        <div id="printDiv">
                    <rsweb:ReportViewer ID="RptViewer" runat="server" ClientIDMode="Static"
        Height="700px" Width="863px" ShowPrintButton="False" AsyncRendering="False" InteractivityPostBackMode="AlwaysSynchronous" KeepSessionAlive="False" ShowRefreshButton="False" >
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
    </div>
    </span></asp:Content>

    </form>



 
</body>
</html>

