<%@ Page Title="學員表現評分表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="RptScore.aspx.cs" Inherits="eTraining_Reports_Do_RptScore" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        學員表現評分表</h2>
        <div class="field">
            <fieldset style="background-color: #EEF5FC; width: 300px">
                <legend>篩選條件</legend>年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
                </telerik:RadComboBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 梯次<telerik:RadNumericTextBox ID="txtSession" 
                    Runat="server" Skin="Web20" ValidationGroup="g" Width="30px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtSession" ErrorMessage="*" ForeColor="Red" 
                    SetFocusOnError="True" ValidationGroup="g"></asp:RequiredFieldValidator>
                <br />
                <br />
                類別<telerik:RadComboBox ID="cbxCateB" runat="server" Width="100px" AutoPostBack="True"
                    DataSourceID="sdsBcate" DataTextField="sName" DataValueField="sCode" />
                <br />
                <asp:SqlDataSource ID="sdsBcate" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="select * from trCategory where sParentCode='ROOT' order by sCode">
                </asp:SqlDataSource>
                <br />
                階層<telerik:RadComboBox ID="cbxCate" runat="server" Width="180px" AutoPostBack="True"
                    DataSourceID="sdsCate" DataTextField="sName" DataValueField="sCode" />
                <br />
                <asp:SqlDataSource ID="sdsCate" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    SelectCommand="select * from trCategory
where sParentCode=@Bcate 
order by sCode">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cbxCateB" DefaultValue="0" Name="Bcate" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                &nbsp;&nbsp;<telerik:RadButton ID="btnCheck" runat="server" Text="確定" 
                    OnClick="btnCheck_Click" ValidationGroup="g">
                </telerik:RadButton>
            </fieldset>
        </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Visible="False" Width="100%"
        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt" Height="600px">
        <LocalReport ReportPath="eTraining\Reports\Do\RptScore.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
