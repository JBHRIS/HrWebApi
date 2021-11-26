<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="QQItemEdit.aspx.cs" Inherits="eTraining_Questionary_QQItemEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().close();
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



    </script>

    <br />
                <table class="tableBlue">
                <tr>
                    <th>
                        題目
                    </th>
                    <td>
                        <telerik:RadTextBox ID="tbQuestionText" runat="server" 
                             Width="400px" />
                    </td>
                </tr>
              </table>
<telerik:RadButton ID="btnSave" runat="server" Text="存檔" onclick="btnSave_Click">
</telerik:RadButton>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
