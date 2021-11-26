<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormFlowImage.aspx.cs" Inherits="Portal.FormFlowImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image runat="server" ID="img" Width="100%" />
    <telerik:RadButton ID="btnReturn" runat="server" Visible="false" CssClass="btn btn-w-m btn-primary" OnClick="btnReturn_Click" Text="回上頁"></telerik:RadButton>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
