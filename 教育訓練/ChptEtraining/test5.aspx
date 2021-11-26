<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test5.aspx.cs" Inherits="test5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
   <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="true" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
     <p>
          Mouseover the left/top tabstrips and click on the tabs of the right one to open
          the hidden sliding panes</p>
     <p>
          Please note that the <strong>vertical</strong> tabs use proprietary text-direction
          styles, which are supported by Microsoft Internet Explorer only.
     </p>
     <telerik:RadSplitter ID="RadSplitter1" runat="server" Width="100%" Height="100%">
          <telerik:RadPane ID="LeftPane" runat="server" Width="150px" Scrolling="none">
               <telerik:RadSlidingZone ID="SlidingZone1" runat="server" Width="22px">
                    <telerik:RadSlidingPane ID="RadSlidingPane1" Title="Pane1" runat="server" Width="150px"
                         MinWidth="100">
                         <telerik:RadTreeView ID="TvMain" runat="server" AutoPostBack="True" 
                             OnNodeClick="TvMain_NodeClick" OnPreRender="TvMain_PreRender" Skin="Vista">
                         </telerik:RadTreeView>
                    </telerik:RadSlidingPane>
               </telerik:RadSlidingZone>
          </telerik:RadPane>
          <telerik:RadSplitBar ID="Radsplitbar1" runat="server">
          </telerik:RadSplitBar>
          <telerik:RadSplitBar ID="RadSplitBar2" runat="server">
          </telerik:RadSplitBar>
     </telerik:RadSplitter>
    
    </div>
    </form>
</body>
</html>
