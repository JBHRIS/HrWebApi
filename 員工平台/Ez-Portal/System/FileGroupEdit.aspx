<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FileGroupEdit.aspx.cs" Inherits="System_FileGroupEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" 
        onajaxrequest="RadAjaxPanel1_AjaxRequest">
        <div style="float: left; width: 600px">
            <telerik:RadTreeView ID="tv" runat="server">
            </telerik:RadTreeView>
        </div>
        <div style="float: left;">
                <asp:Button ID="btnSelect" runat="server" Height="200px" 
                    onclick="btnSelect_Click" Text="Select" />
        </div>

        <div style="float: left;">
            <telerik:RadListBox ID="lb" runat="server" AllowDelete="True" 
                AllowReorder="True">
            </telerik:RadListBox>
            <telerik:RadButton ID="btnSave" runat="server" onclick="btnSave_Click" 
                Text="Submit">
            </telerik:RadButton>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>
