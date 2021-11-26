<%@ Page Title="年度計畫檢討" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="RptCourseReviewA.aspx.cs" Inherits="eTraining_Reports_Review_RptCourseReviewA" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        年度計畫檢討</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 200px">
            <legend>篩選條件</legend>年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
            </telerik:RadComboBox>
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            課程類別<telerik:RadComboBox ID="cbxCate" runat="server" Skin="Windows7" 
                Width="70px" DataSourceID="sdsCate" DataTextField="sName" 
                DataValueField="sCode">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="核心課程" Value="A" />
                    <telerik:RadComboBoxItem runat="server" Text="主題課程" Value="C" />
                    <telerik:RadComboBoxItem runat="server" Text="策略課程" Value="D" />
                    <telerik:RadComboBoxItem runat="server" Text="體驗激勵" Value="體驗激勵" />
                </Items>
            </telerik:RadComboBox>
            <br />
            <asp:SqlDataSource ID="sdsCate" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                SelectCommand="select * from trCategory where sParentCode='Root' and sCode in ('A','C','D','E') order by sCode">
            </asp:SqlDataSource>
            <br />
            &nbsp;&nbsp;<telerik:RadButton ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="確定">
            </telerik:RadButton>
        </fieldset>
    </div>
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Height="600px" Width="100%" Visible="False">
        <LocalReport ReportPath="eTraining\Reports\Review\RptCourseReviewA.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
    <br />
</asp:Content>
