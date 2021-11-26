<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewsContent.aspx.cs" Inherits="Portal.NewsContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- FooTable -->
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row justify-content-md-center">
            <div class="col-lg-10">
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="float-right">
                            <i class="fa fa-calendar"></i>
                            <telerik:RadLabel runat="server" ID="lblDate"></telerik:RadLabel>
                            <i class="fa fa-clock-o"></i>
                            <telerik:RadLabel runat="server" ID="lblTime"></telerik:RadLabel>
                            <i class="fa fa-bookmark"></i>
                            <telerik:RadLabel runat="server" ID="lblId"></telerik:RadLabel>
                        </div>
                        <div class="text-center article-title">
                            <h1>
                                <telerik:RadLabel runat="server" ID="lblTitle"></telerik:RadLabel>
                            </h1>
                        </div>
                        <p>
                            <telerik:RadLabel runat="server" ID="lblContent"></telerik:RadLabel>
                        </p>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
