<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test3.aspx.cs" Inherits="test3" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:radscriptmanager ID="RadScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.Core.js">
        </asp:ScriptReference>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.jQuery.js">
        </asp:ScriptReference>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.jQueryInclude.js">
        </asp:ScriptReference>
    </Scripts>
</telerik:radscriptmanager>
    <div>
    
        <telerik:RadButton ID="RadButton3" runat="server" Text="修正講師是否評完分數" 
            onclick="RadButton3_Click">
        </telerik:RadButton>
    
        <telerik:RadDateTimePicker ID="RadDateTimePicker1" Runat="server" 
            Culture="zh-CHT">
<TimeView CellSpacing="-1" Culture="zh-CHT"></TimeView>

<TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>

<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDateTimePicker>
    
        <asp:Button ID="Button1" runat="server" Text="Button" ValidationGroup="g" />
        <telerik:RadDatePicker ID="RadDatePicker1" Runat="server">
        </telerik:RadDatePicker>
        <telerik:RadDateInput ID="RadDateInput1" Runat="server" CausesValidation="True" 
            ValidationGroup="g">
        </telerik:RadDateInput>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="RadDateInput1" ErrorMessage="RequiredFieldValidator" 
            ValidationGroup="g"></asp:RequiredFieldValidator>
    
        <Radbutton ID="RadButton1" runat="server" BorderStyle="Dotted" 
    Skin="Telerik" Text="RadButton">
</Radbutton>
    
    </div>
    <RadButton ID="RadButton2" runat="server" onclick="RadButton2_Click" 
        Text="RadButton">
    </RadButton>
    </form>
</body>
</html>
