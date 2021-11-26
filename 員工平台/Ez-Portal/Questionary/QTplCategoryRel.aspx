<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="QTplCategoryRel.aspx.cs" Inherits="eTraining_Questionary_QTplCategoryRel" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Hay" />
        <br />
        <br />
        <table width="100%">
            <tr>
                <td>
                    未選擇類別
                </td>
                <td>
                    已選擇類別
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <telerik:RadListBox ID="lb1" runat="server" AllowReorder="True" AllowTransfer="True"
                        AllowTransferOnDoubleClick="True" DataTextField="Name" DataValueField="Code"
                        TransferToID="lb2" Width="250px" BorderColor="Silver" BorderStyle="Outset"
                        BorderWidth="1px" onitemdatabound="lb1_ItemDataBound" Skin="Transparent">
                    </telerik:RadListBox>
                </td>
                <td valign="top">
                    <telerik:RadListBox ID="lb2" runat="server" AllowReorder="True" AllowTransferOnDoubleClick="True"
                        DataTextField="Name" DataValueField="Code" Width="250px"
                        BorderColor="Silver" BorderStyle="Outset" BorderWidth="1px"
                        onitemdatabound="lb2_ItemDataBound" Skin="Transparent">
                    </telerik:RadListBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
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
        <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存">
        </telerik:RadButton>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>