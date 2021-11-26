<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="PlanSurveyMail.aspx.cs" Inherits="eTraining_Admin_Plan_PlanSurveyMail" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        產生年度需求&寄Mail
    </h2>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" 
            Runat="server" Skin="Windows7">
        </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        width="100%" HorizontalAlign="NotSet" 
        LoadingPanelID="RadAjaxLoadingPanel1">
            年度<telerik:RadComboBox 
        ID="cbYear" runat="server" Width="70px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" 
                Owner="cbYear" />
        </Items>
    </telerik:RadComboBox>
    <br />
    
    <telerik:RadButton ID="btnGenQuestDept" runat="server" Text="產生部門年度需求調查" 
        onclick="btnGenQuestDept_Click">
    </telerik:RadButton>
            <telerik:RadButton ID="btnCreate" runat="server" onclick="btnCreate_Click" 
                Text="產生年度人員需求調查資料" Visible="False">
            </telerik:RadButton>
    &nbsp;
    <telerik:RadButton ID="btnDelete" runat="server" ForeColor="Red" 
        onclick="btnDelete_Click" Text="清除年度需求調查資料">
    </telerik:RadButton>
    <br />
    <br />
    <telerik:RadButton ID="btnSendMail" runat="server" Text="寄發MAIL通知" 
        onclick="btnSendMail_Click">
    </telerik:RadButton>
    <telerik:RadButton ID="btnPreview" runat="server" onclick="btnPreview_Click" 
        Text="郵件預覽">
    </telerik:RadButton>
    <br />
    <br />
    <asp:Panel ID="pnView" runat="server" Height="376px" Visible="False">
        <br />
        <table border="1" style="width:100%; background-color: #EEF5FC;">
            <tr>
                <td>
                    信件標題</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMailSubject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    信件內容</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMailBody" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </telerik:RadAjaxPanel>
    
</asp:Content>
