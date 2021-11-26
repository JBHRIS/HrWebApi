<%@ Page Title="結訓成績一覽表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="RptClassClosedByCate.aspx.cs" Inherits="eTraining_Reports_Review_RptClassClosedByCate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        結訓成績一覽表</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 500px">
            <legend>篩選條件</legend>
            <table style="width: 100%;">
                <tr>
                    <td>
                        時間起
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdpAdate" runat="server">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdpAdate"
                            Display="Dynamic" ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        時間迄
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdpDdate" runat="server">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpDdate"
                            Display="Dynamic" ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        課程類別
                    </td>
                    <td>
                        <telerik:RadComboBox ID="cbxClassCateLevel1" runat="server" AutoPostBack="True" DataSourceID="sdsClassCateLevel1"
                            DataTextField="sName" DataValueField="sCode" OnSelectedIndexChanged="cbxClassCateLevel1_SelectedIndexChanged"
                            Width="100px">
                        </telerik:RadComboBox>
                        <asp:SqlDataSource ID="sdsClassCateLevel1" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT * FROM [trCategory]  where sParentCode ='ROOT'"></asp:SqlDataSource>
                    </td>
                    <td>
                        課程階層別
                    </td>
                    <td>
                        <telerik:RadComboBox ID="cbxClassCateLevel2" runat="server" DataSourceID="sdsClassCateLevel2"
                            DataTextField="sName" DataValueField="sCode">
                        </telerik:RadComboBox>
                        <asp:SqlDataSource ID="sdsClassCateLevel2" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                            SelectCommand="SELECT * FROM [trCategory]  where sParentCode =@code">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cbxClassCateLevel1" DefaultValue=" " Name="code"
                                    PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        梯次
                    </td>
                    <td>
                        <telerik:RadNumericTextBox ID="ntbSession" runat="server" DataType="System.Int32"
                            MinValue="0" Width="50px">
                            <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ntbSession"
                            Display="Dynamic" ErrorMessage="*梯次必填" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="g"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <telerik:RadButton ID="btnCheck" runat="server" Text="確定" ValidationGroup="g" 
                onclick="btnCheck_Click">
            </telerik:RadButton>
        </fieldset>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="600px" InteractiveDeviceInfos="(集合)" Visible="False" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="eTraining\Reports\Review\RptClassClosedByCate.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
    <br />
    <br />
    <br />
</asp:Content>
