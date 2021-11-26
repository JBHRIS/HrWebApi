<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="QViewTpl.aspx.cs" Inherits="eTraining_Questionary_QViewTpl" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All"
        Skin="Vista" CssClass="DivCategory" />
    <asp:Panel ID="pnlHeader" runat="server" CssClass="QHeader">
        <asp:Label ID="lbHeader" runat="server"></asp:Label>
    </asp:Panel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <script type="text/javascript">
            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }

            function Rebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
            }

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }

            function CancelEdit() {
                GetRadWindow().close();
            }

            //Standard Window.confirm
            function StandardConfirm(sender, args) {
                args.set_cancel(!window.confirm("您確定要儲存嗎？"));
            }

            //RadConfirm
            function RadConfirm(sender, args) {
                var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                    if (shouldSubmit) {
                        this.click();
                    }
                });

                var text = "Are you sure you want to submit the page?";
                radconfirm(text, callBackFunction, 300, 100, null, "RadConfirm");
                args.set_cancel(true);
            }
        </script>
    </telerik:RadAjaxPanel>
    <asp:Panel ID="pnlFooter" runat="server" CssClass="QHeader">
        <asp:Label ID="lbFooter" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .RadForm_Vista.rfdFieldset fieldset legend
        {
            font-size: 16px;
            font-weight: bold;
        }
        .RadGrid_Default
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background: #fff;
            color: #333;
        }
        .RadGrid_Default .rgMasterTable
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
            border-spacing: 0;
        }
        .RadGrid_Default .rgHeader
        {
            color: #333;
        }
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-bottom: 1px solid #828282;
            background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        }
        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }
        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        .RadGrid .rgHeader
        {
            cursor: default;
        }
        .RadGrid_Default .rgFilterRow
        {
            background: #eee;
        }
        .RadGrid_Default .rgFilterBox
        {
            border-color: #8e8e8e #c9c9c9 #c9c9c9 #8e8e8e;
            font-family: "segoe ui" ,arial,sans-serif;
            color: #333;
        }
        .RadGrid .rgFilterBox
        {
            border-width: 1px;
            border-style: solid;
            margin: 0;
            height: 15px;
            padding: 2px 1px 3px;
            font-size: 12px;
            vertical-align: middle;
        }
        .RadGrid_Default .rgFilter
        {
            background-position: 0 -300px;
        }
        .RadGrid_Default .rgFilter
        {
            background-image: url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        }
        .RadGrid .rgFilter
        {
            width: 22px;
            height: 22px;
            margin: 0 0 0 2px;
        }
        .RadGrid .rgFilter
        {
            width: 16px;
            height: 16px;
            border: 0;
            margin: 0;
            padding: 0;
            background-color: transparent;
            background-repeat: no-repeat;
            vertical-align: middle;
            font-size: 1px;
            cursor: pointer;
        }
    </style>
</asp:Content>