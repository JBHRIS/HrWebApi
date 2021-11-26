<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="SummuryQuestionary.aspx.cs" Inherits="eTraining_Reports_Do_Questionary_SummuryQuestionary" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" 
        DecoratedControls="All" Skin="Vista" CssClass="DivCategory" />
      <telerik:RadButton ID="btnExport" runat="server" onclick="btnExport_Click" 
        Text="匯出">
    </telerik:RadButton>
      <br />
    <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
        CellSpacing="0" Culture="zh-TW" GridLines="None">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="QuestionText" 
            FilterControlAltText="Filter QuestionText column" HeaderText="問題" 
            UniqueName="QuestionText">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Score" 
            FilterControlAltText="Filter Score column" HeaderText="分數" UniqueName="Score">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="StrValue" 
            FilterControlAltText="Filter StrValue column" HeaderText="文字值" 
            UniqueName="StrValue">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="SaqAnswer" 
            FilterControlAltText="Filter SaqAnswer column" HeaderText="問答題答案" 
            UniqueName="SaqAnswer">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">

    <style type="text/css">
            .RadForm_Vista.rfdFieldset fieldset legend
             {
                 font-size:16px;
                 font-weight: bold;
             }
.RadGrid_Default{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid_Default{border:1px solid #828282;background:#fff;color:#333}.RadGrid_Default .rgMasterTable{font:12px/16px "segoe ui",arial,sans-serif}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}.RadGrid_Default .rgFilterRow{background:#eee}.RadGrid_Default .rgFilterBox{border-color:#8e8e8e #c9c9c9 #c9c9c9 #8e8e8e;font-family:"segoe ui",arial,sans-serif;color:#333}.RadGrid .rgFilterBox{border-width:1px;border-style:solid;margin:0;height:15px;padding:2px 1px 3px;font-size:12px;vertical-align:middle}.RadGrid_Default .rgFilter{background-position:0 -300px}.RadGrid_Default .rgFilter{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgFilter{width:22px;height:22px;margin:0 0 0 2px}.RadGrid .rgFilter{width:16px;height:16px;border:0;margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;vertical-align:middle;font-size:1px;cursor:pointer}
        </style>

</asp:Content>
