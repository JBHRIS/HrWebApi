<%@ Page Title="簽到表" Language="C#" AutoEventWireup="true"
    CodeFile="SignForClass.aspx.cs" Inherits="eTraining_Reports_Do_SignForClass" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
        簽到表</h2>
    <asp:Panel ID="pnlDate" runat="server">
        <asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblCourseName" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 上課日期<telerik:RadComboBox ID="cbxClassDate"
            runat="server" DataSourceID="sdsClassDate" DataTextField="dClassDate" DataValueField="iAutoKey"
            Width="125px" DataTextFormatString="{0:d}">
        </telerik:RadComboBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <telerik:RadButton ID="btnCheck" runat="server" Text="確定" OnClick="btnCheck_Click">
        </telerik:RadButton>
        <br />
        <asp:Panel ID="pnlReport" runat="server" Visible="True">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                Width="100%" Height="800px">
                <LocalReport ReportPath="eTraining\Reports\Do\Sign.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </asp:Panel>
        <br />
    </asp:Panel>
    <br />
    <asp:SqlDataSource ID="sdsClassDate" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select * from trAttendClassDate where iClassAutoKey =@iAutokey">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iAutokey" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    </div>
    </form>
</body>
</html>
