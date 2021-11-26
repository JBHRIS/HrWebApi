<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="setMail.aspx.cs" Inherits="eTraining_System_setMail" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    設定電子郵件帳號<br />
    <br />
    SMTP伺服器：<telerik:RadTextBox ID="tbSmtpServer" Runat="server">
    </telerik:RadTextBox>
    <br />
    SMTP寄信者：<telerik:RadTextBox ID="tbMailFrom" Runat="server">
    </telerik:RadTextBox>
    <br />
    SMTP連接埠：<telerik:RadTextBox ID="tbSmtpPort" Runat="server">
    </telerik:RadTextBox>

    <br />
    
    SMTP使用者：<telerik:RadTextBox ID="tbSmtpUser" Runat="server">
    </telerik:RadTextBox>
    <br />
    SMTP密碼：<telerik:RadTextBox ID="tbSmtpPassword" Runat="server">
    </telerik:RadTextBox>
    <br />
    <telerik:RadButton ID="btnSave" runat="server" onclick="btnSave_Click" 
        Text="存檔">
    </telerik:RadButton>
    
    <br />
</asp:Content>

