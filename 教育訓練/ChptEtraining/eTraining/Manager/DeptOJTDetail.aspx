<%@ Page Title="職能明細表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="DeptOJTDetail.aspx.cs" Inherits="eTraining_Reports_Review_DeptOJTDetail" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>職能明細表</h2>
    <table style="width:90%;">
        <tr>
            <td>
                學習卡<telerik:RadComboBox ID="cbxOJTCard" Runat="server" 
                    DataSourceID="sdsCbxOJTCard" DataTextField="sName" DataValueField="sCode" 
                    MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td>
                OJT部門<telerik:RadComboBox ID="cbxOjtDept" Runat="server" 
                    DataSourceID="sdsOjtDept" DataTextField="D_NAME" DataValueField="D_NO" 
                    MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td>
                計算年月<telerik:RadMonthYearPicker ID="rmypMYP" Runat="server" Culture="zh-TW">
<DateInput DisplayDateFormat="yyyy MMMM" DateFormat="yyyy MMMM"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadMonthYearPicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="rmypMYP" Display="Dynamic" ErrorMessage="*必填欄位" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <telerik:RadButton ID="btnExportExcel" runat="server" 
        onclick="btnExportExcel_Click" Text="匯出Excel">
    </telerik:RadButton>
    <br />
    <br />
    <asp:SqlDataSource ID="sdsCbxOJTCard" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        SelectCommand="select * from trOJTTemplate"></asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="sdsOjtDept" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        SelectCommand="select d.D_NO,d.D_NO+' '+d.D_NAME as D_NAME  from dept d
join BASETTS b on d.D_NO=b.DEPT
where CONVERT(varchar(10), GETDATE(),111) between b.ADATE and b.DDATE
and b.NOBR=@Manage
 order by D_NAME
">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="Manage" />
        </SelectParameters>
    </asp:SqlDataSource>
<br />
</asp:Content>

