<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="Portal.Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
    <style>
        .RadLabel {
            word-break: break-all;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <h2>Information</h2>
                <telerik:RadLabel runat="server" CssClass="col-form-label RadLabel" ID="lblEmpID"></telerik:RadLabel>
                <br />
                <telerik:RadLabel runat="server" CssClass="col-form-label RadLabel" ID="lblEmpName"></telerik:RadLabel>
                <br />
                <telerik:RadLabel runat="server" CssClass="col-form-label RadLabel" ID="lblAccessToken"></telerik:RadLabel>
                <br />
                <telerik:RadLabel runat="server" CssClass="col-form-label RadLabel" ID="lblRefreshToken"></telerik:RadLabel>
                <br />
                <telerik:RadLabel runat="server" CssClass="col-form-label RadLabel" ID="lblConnectionToken"></telerik:RadLabel>
                <br />
                <telerik:RadLabel runat="server" CssClass="col-form-label RadLabel" ID="lblAppToken"></telerik:RadLabel>

            </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
