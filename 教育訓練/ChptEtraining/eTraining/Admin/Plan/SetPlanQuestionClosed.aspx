<%@ Page Title="設定需求調查關閉" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="SetPlanQuestionClosed.aspx.cs" Inherits="eTraining_Admin_Plan_SetPlanQuestionClosed" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .MyClass
        {
            height: 300px;
        }
        .MyClass td
        {
            text-align: left;
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        設定需求調查關閉</h2>
    <telerik:RadAjaxLoadingPanel ID="AjaxLP_Loading" runat="server" Skin="Default" />
    <telerik:RadAjaxPanel runat="server" LoadingPanelID="AjaxLP_Loading">
        <table class="MyClass" >
            <tr>
                <td>
                    <asp:Label runat="server" AssociatedControlID="CB_Year">選擇年度</asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox runat="server" ID="CB_Year" AutoPostBack="True" OnSelectedIndexChanged="CB_Year_SelectedIndexChanged" />
                    <asp:CheckBox ID="CB_IsClose" runat="server" Text="關閉需求填寫" />
                </td>
                <td>
                    <telerik:RadButton ID="Btn_Save" runat="server" Text="存檔" OnClick="Btn_Save_Click" />
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
</asp:Content>
