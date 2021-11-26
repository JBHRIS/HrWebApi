<%@ Page Title="加入調查人員清單" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="eTraining_Admin_Plan_MemberList" %>

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
    <h2>加入調查人員清單</h2>
    職等 <telerik:RadComboBox ID="cbBeginLevel" Runat="server" Width="50px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="1" Value="1" 
                Owner="cbBeginLevel" />
            <telerik:RadComboBoxItem runat="server" Text="2" Value="2" 
                Owner="cbBeginLevel" />
            <telerik:RadComboBoxItem runat="server" Text="3" Value="3" 
                Owner="cbBeginLevel" />
            <telerik:RadComboBoxItem runat="server" Text="4" Value="4" 
                Owner="cbBeginLevel" />
            <telerik:RadComboBoxItem runat="server" Text="5" Value="5" 
                Owner="cbBeginLevel" />
            <telerik:RadComboBoxItem runat="server" Text="6" Value="6" 
                Owner="cbBeginLevel" />
            <telerik:RadComboBoxItem runat="server" Text="7" Value="7" 
                Owner="cbBeginLevel" />
            <telerik:RadComboBoxItem runat="server" Text="8" Value="8" 
                Owner="cbBeginLevel" />
            <telerik:RadComboBoxItem runat="server" Text="9" Value="9" 
                Owner="cbBeginLevel" />
        </Items>
    </telerik:RadComboBox>
    &nbsp;到 <telerik:RadComboBox ID="cbEndLevel" Runat="server" Width="50px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="1" Value="1" Owner="cbEndLevel" />
            <telerik:RadComboBoxItem runat="server" Text="2" Value="2" Owner="cbEndLevel" />
            <telerik:RadComboBoxItem runat="server" Text="3" Value="3" Owner="cbEndLevel" />
            <telerik:RadComboBoxItem runat="server" Text="4" Value="4" Owner="cbEndLevel" />
            <telerik:RadComboBoxItem runat="server" Text="5" Value="5" Owner="cbEndLevel" />
            <telerik:RadComboBoxItem runat="server" Text="6" Value="6" Owner="cbEndLevel" />
            <telerik:RadComboBoxItem runat="server" Text="7" Value="7" Owner="cbEndLevel" />
            <telerik:RadComboBoxItem runat="server" Text="8" Value="8" Owner="cbEndLevel" />
            <telerik:RadComboBoxItem runat="server" Text="9" Value="9" Owner="cbEndLevel" />
        </Items>
    </telerik:RadComboBox>
    <br />
    部門<br />
                <telerik:RadTreeView ID="tvDept" runat="server" CheckBoxes="True"
                    MultipleSelect="True" CheckChildNodes="True">
                </telerik:RadTreeView>
            <br />
    <telerik:RadButton ID="btnAddUser" runat="server" onclick="btnAddUser_Click" 
        Text="加入調查人員清單">
    </telerik:RadButton>
            &nbsp;&nbsp;&nbsp;
    <telerik:RadButton ID="btnCancel" runat="server" onclick="btnCancel_Click" 
        Text="離開">
    </telerik:RadButton>
            </asp:Content>

