<%@ Page Title="人員篩選" Language="C#" AutoEventWireup="true" CodeFile="MustTrainingAdd.aspx.cs" Inherits="eTraining_Admin_Plan_MustTrainingAdd" MasterPageFile="~/mpEdit.master" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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

        function OpenAlert() {
            radalert('<h4>Welcome to <strong>RadWindow</strong>!</h4>', 330, 100, 'RadAlert custom title');
            return false;
        }

    </script>

    <table border="1" cellpadding="1" cellspacing="1" width="70%" class="tbGreen">
        <tr>
            <th>
                部門
            </th>
            <th>
                職稱
            </th>
        </tr>
        <tr>
            <td width="50%" align="left" valign="top">
                <telerik:RadTreeView ID="tvDept" runat="server" CheckBoxes="True" CheckChildNodes="True"
                    MultipleSelect="True">
                </telerik:RadTreeView>
            </td>
            <td width="50%" align="left" valign="top">
                <telerik:RadTreeView ID="tvJob" runat="server" CheckBoxes="True" 
                    MultipleSelect="True" CheckChildNodes="True">
                    <expandanimation type="OutQuad" />
                </telerik:RadTreeView>
            </td>
        </tr>
    </table>

    <br />
    <telerik:RadButton ID="btnSave" runat="server" Text="新增" onclick="btnSave_Click">
    </telerik:RadButton>
&nbsp;&nbsp;&nbsp;&nbsp;
    <telerik:RadButton ID="btnCancel" runat="server" Text="取消" 
        onclick="btnCancel_Click">
    </telerik:RadButton>
&nbsp;
</asp:Content>
