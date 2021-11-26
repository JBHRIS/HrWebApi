<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit2.master" AutoEventWireup="true"
    CodeFile="QFillInQuestionary.aspx.cs" Inherits="QFillInQuestionary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="CheckBoxes, Buttons, Scrollbars, Textbox, Textarea, Fieldset, Label, H4H5H6, Select, Zone, GridFormDetailsViews, ValidationSummary, LoginControls"
        Skin="Office2010Blue" CssClass="DivCategory" ControlsToSkip="Label" />
    <asp:Panel ID="pnlHeader" runat="server" CssClass="QHeader">
        <asp:Label ID="lbHeader" runat="server"></asp:Label>
    </asp:Panel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <table width="100%" border="0" cellpadding="1" cellspacing="1">
            <tr style="font-size: 16px">
                <td>
                    <asp:Label ID="Label1" runat="server" Text="工號："></asp:Label>
                    <asp:Label ID="lblNobr" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="font-size: 16px">
                <td>
                    <asp:Label ID="Label3" runat="server" Text="姓名："></asp:Label>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="font-size: 16px">
                <td>
                    <asp:Label ID="Label2" runat="server" Text="部門："></asp:Label>
                    <asp:Label ID="lblDept" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="font-size: 16px">
                <td>
                    <asp:Label ID="Label4" runat="server" Text="填表日期："></asp:Label>
                    <asp:Label ID="lblFillDate" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" Height="100%" Width="100%">
        <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click"
            OnClientClicking="ExcuteOnceOnlyConfirm">
        </telerik:RadButton>
    </telerik:RadAjaxPanel>
    <asp:Panel ID="pnlFooter" runat="server" CssClass="QHeader">
        <asp:Label ID="lbFooter" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .RadForm_Office2010Blue.rfdFieldset fieldset legend
        {
            font-size: 28px;
            font-weight: bold;
        }
        .RadForm_Vista.rfdFieldset fieldset legend
        {
            font-size: 16px;
            font-weight: bold;
        }
        .RadGrid_Default
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background: #fff;
            color: #333;
        }
        .RadGrid_Default .rgMasterTable
        {
            font: 12px/16px "segoe ui" ,arial,sans-serif;
        }
        .RadGrid .rgMasterTable
        {
            border-collapse: separate;
            border-spacing: 0;
        }
        .RadGrid_Default .rgHeader
        {
            color: #333;
        }
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-bottom: 1px solid #828282;
            background: #eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        }
        .RadGrid .rgHeader
        {
            padding-top: 5px;
            padding-bottom: 4px;
            text-align: left;
            font-weight: normal;
        }
        .RadGrid .rgHeader
        {
            padding-left: 7px;
            padding-right: 7px;
        }
        .RadGrid .rgHeader
        {
            cursor: default;
        }
        .RadGrid_Default .rgFilterRow
        {
            background: #eee;
        }
        .RadGrid_Default .rgFilterBox
        {
            border-color: #8e8e8e #c9c9c9 #c9c9c9 #8e8e8e;
            font-family: "segoe ui" ,arial,sans-serif;
            color: #333;
        }
        .RadGrid .rgFilterBox
        {
            border-width: 1px;
            border-style: solid;
            margin: 0;
            height: 15px;
            padding: 2px 1px 3px;
            font-size: 12px;
            vertical-align: middle;
        }
        .RadGrid_Default .rgFilter
        {
            background-position: 0 -300px;
        }
        .RadGrid_Default .rgFilter
        {
            background-image: url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif');
        }
        .RadGrid .rgFilter
        {
            width: 22px;
            height: 22px;
            margin: 0 0 0 2px;
        }
        .RadGrid .rgFilter
        {
            width: 16px;
            height: 16px;
            border: 0;
            margin: 0;
            padding: 0;
            background-color: transparent;
            background-repeat: no-repeat;
            vertical-align: middle;
            font-size: 1px;
            cursor: pointer;
        }

        .RadForm.rfdTextbox input[type="text"], .RadForm.rfdTextbox input[type="password"], .RadForm.rfdTextarea textarea, .RadForm.rfdTextarea textarea[disabled]:hover, .RadForm.rfdTextbox input[disabled][type="text"]:hover, .RadForm.rfdTextbox input[disabled][type="password"]:hover, .RadForm .rfdCheckboxChecked, .RadForm .rfdInputDisabled.rfdCheckboxChecked:hover, .RadForm .rfdCheckboxUnchecked, .RadForm .rfdInputDisabled.rfdCheckboxUnchecked:hover, .RadForm.rfdLabel label, .RadForm .rfdAspLabel, .RadForm .rfdRadioUnchecked, .RadForm .rfdInputDisabled.rfdRadioUnchecked:hover, .RadForm .rfdRadioUnchecked:hover, .RadForm .rfdRadioChecked, .RadForm .rfdInputDisabled.rfdRadioChecked:hover, .RadForm .rfdRadioChecked:hover, .RadForm .riTextBox, .RadForm .rfdValidationSummaryControl, .RadForm .rfdLoginControl, .RadForm legend
        {
            font-size: 40px;
        }
    </style>
</asp:Content>