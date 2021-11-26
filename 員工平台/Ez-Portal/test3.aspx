<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test3.aspx.cs" Inherits="test3" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            PostBackUrl="~/AutoLogin.aspx" Text="Button" />
        <asp:TextBox ID="id" runat="server"></asp:TextBox>
        <asp:TextBox ID="AutoLoginAuth" runat="server"></asp:TextBox>
    
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
    <telerik:RadDateTimePicker ID="rdtpClassRptDeadLine" Runat="server" 
                                                            Culture="zh-TW">
                                                            <TimeView CellSpacing="-1" Culture="zh-TW" TimeFormat="HH:mm">
                                                            </TimeView>
                                                            <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                                ViewSelectorText="x">
                                                            </Calendar>
                                                            <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" 
                                                                DisplayText="" LabelWidth="40%" type="text" value="">
                                                            </DateInput>
                                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                        </telerik:RadDateTimePicker>
    </div>
    </form>
</body>
</html>
