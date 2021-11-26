<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Marquee.ascx.cs"
    Inherits="Marquee" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
            <asp:Timer ID="Timer1" runat="server" Interval="300000" ontick="Timer1_Tick">
            </asp:Timer>
    <div>
        <marquee direction="left" scrollamount="3" scrolldelay="120" loop="true" width="100%" bgcolor="#ffffff" onmouseover="this.stop()" onmouseout="this.start()">
    <asp:Label id="lblMarquee" runat="server" ></asp:Label>
</marquee>
    </div>
</telerik:RadAjaxPanel>