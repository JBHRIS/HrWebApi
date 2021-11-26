<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="TeachingPlanUpload.aspx.cs" Inherits="eTraining_Design_TeachingPlan" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>單元教學教案上傳</h2>
    <br />
    <telerik:RadButton ID="btnGoBack" runat="server" onclick="btnGoBack_Click" 
        Text="回上頁">
    </telerik:RadButton>
    <br />
    <br />
    <br />
    <br />
    <telerik:RadAsyncUpload ID="ul" runat="server" 
        MultipleFileSelection="Automatic" Skin="Windows7" MaxFileSize="1024000000">
        <Localization Remove="移除" Select="選擇" />
    </telerik:RadAsyncUpload>
    <telerik:RadButton ID="btnUpload" runat="server" onclick="btnUpload_Click" 
        Text="檔案上傳" style="top: 0px; left: 0px">
    </telerik:RadButton>
    <br />
    <asp:SqlDataSource ID="sdsGv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select tm.*,ul.fileoriginname
  FROM trTeachingMaterial tm left join upload ul on tm.iautokey=ul.filecategorykey 
and ul.filecategory = 'teachingPlan' and filedeleted =0
where tm.iAutoKey = @ID">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
        </SelectParameters>
    </asp:SqlDataSource>
    </asp:Content>

