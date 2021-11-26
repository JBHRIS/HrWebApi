<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServiceCertification.aspx.cs" Inherits="Employee_ServiceCertification" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<%--<a href="#">--%>
        <%--<input type="button" onclick="printRep()"  value="Print" id="printBtn" style="visibility:hidden;" /></a>--%>
        <div id="printDiv">
        <rsweb:ReportViewer ID="RptViewer" runat="server" Height="1024px" Width="863px">
    </rsweb:ReportViewer>
    </div>
  <%--  <script>
        var i = 60;
        var intObj = 0;
        var btn = document.getElementById('printBtn');

        function run() {
            btn.style.visibility = 'visible';
        };

        function printRep() {
            var backup = document.body.innerHTML;
            document.getElementById('<%=RptViewer.ClientID%>'+'_Toolbar').style.display = 'none';
            var con = document.getElementById('printDiv').outerHTML;
            document.body.innerHTML = '<html><head></head><body>' + con + '</body></html>';
            window.print();
            document.body.innerHTML = backup;
            document.getElementById('ctl00_ContentPlaceHolder1_RptViewer_Toolbar').style.display = 'block';
            //btn.style.visibility = 'hidden';
        };
        </script>--%>
<script type="text/javascript">
    function RptExportPdf() {
        var exportEle = document.getElementById('ctl00_ContentPlaceHolder2_RptViewer_ctl05_ctl04_ctl00_Menu');
        exportEle.children[0].style.display = 'none';
        exportEle.children[2].style.display = 'none';
    }
    new RptExportPdf();
</script>   
</asp:Content>

