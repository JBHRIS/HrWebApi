<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserForm.aspx.cs" Inherits="Flow_UserForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
    function setCustomPosition(sender, args)
    {
        sender.moveTo(sender.get_left(), sender.get_top());
    }
</script>
    <div style="float: left; width: 200px" id="test">
        <telerik:RadTreeView ID="tv" runat="server" Skin="Vista" 
            onnodeclick="tv_NodeClick">
        </telerik:RadTreeView>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
            Style="z-index: 7001" Left="0px" Top="0px" ViewStateMode="Disabled">
            <Windows>
                <telerik:RadWindow ID="win" runat="server" EnableShadow="True" Height="700px" Modal="True"
                    VisibleStatusbar="True" Width="1000px" Left="0px" Top="0px" OnClientShow="setCustomPosition">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
