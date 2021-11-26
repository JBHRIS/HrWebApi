<%@ Page Title="加入調查部門清單" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true" CodeFile="DeptPicker.aspx.cs" Inherits="eTraining_Admin_Plan_DeptPicker" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <h2>加入調查部門</h2>
    <br />
                <telerik:RadTreeView ID="tvDept" runat="server" CheckBoxes="True"
                    MultipleSelect="True" CheckChildNodes="True">
                </telerik:RadTreeView>
            <br />
    <telerik:RadButton ID="btnAddUser" runat="server" onclick="btnAddUser_Click" 
        Text="加入調查部門">
    </telerik:RadButton>
            &nbsp;&nbsp;&nbsp;
    <telerik:RadButton ID="btnCancel" runat="server" onclick="btnCancel_Click" 
        Text="離開">
    </telerik:RadButton>
            </asp:Content>

