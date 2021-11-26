<%@ Page Language="C#" AutoEventWireup="true" CodeFile="helpStudentKnotTeach.aspx.cs"
    Inherits="eTraining_Admin_Do_helpStudentKnotTeach" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Formosa/Images/eTraining/helpDoStudentKnot.jpg" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/eTraining/Admin/Do/SetStudentKnotTeaches.aspx"
            OnDisposed="HyperLink1_Disposed">返回</asp:HyperLink>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>
