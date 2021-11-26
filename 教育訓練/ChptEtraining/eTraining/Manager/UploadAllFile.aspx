<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="UploadAllFile.aspx.cs" Inherits="eTraining_Manager_UploadAllFile" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="style1">
<h2 class="style1">上傳員工繳交資料</h2>
        <div class="style1">
    <br />


    年度<telerik:RadComboBox ID="RadComboBox1" Runat="server" Width="70px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2010" Value="2010" />
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
            <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
        </Items>
    </telerik:RadComboBox>
    <br />
    <br />
        </div>
    <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" 
        Skin="Vista">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            UniqueName="TemplateColumn">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink4" runat="server" 
                    NavigateUrl="~/eTraining/Manager/UploadAllFile1.aspx">繳交</asp:HyperLink>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>


</div>
</asp:Content>

