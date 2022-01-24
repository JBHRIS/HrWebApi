<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMailTplStatement.aspx.cs" Inherits="Performance.ManageMailTplStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>郵件語句修改</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="fullscreen-link">
                                <i class="fa fa-expand"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <telerik:RadLabel ID="lblAutoKey" runat="server" Visible="false" />
                            <div class="form-group row" >
                                <div class="col-sm-12"> 
                                    <telerik:RadTextBox ID="txtStatement" Width="100%" CssClass="form-control StatementContent"    TextMode="MultiLine" runat="server"></telerik:RadTextBox>
                                </div>
                            </div>                           
                            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" ValidationGroup="Main" CssClass="btn btn-primary" />
                             <telerik:RadLabel ID="lblMsg" runat="server" CssClass="badge badge-danger" />
                            <telerik:RadLabel ID="lblUserCode" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblKey1" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblKey2" runat="server" Visible="False" />
                            <telerik:RadLabel ID="lblGuid" runat="server" Visible="False" />
                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
