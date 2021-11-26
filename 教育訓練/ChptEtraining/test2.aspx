<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="test2" %>

<%@ Register src="UC/UserQuickSearch.ascx" tagname="UserQuickSearch" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    
        <br />
        <telerik:RadButton ID="RadButton7" runat="server" Text="計算講師費用及時數" 
            onclick="RadButton7_Click" style="top: -5px; left: -7px; height: 21px">
        </telerik:RadButton>
        <br />
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="test confirm" onclientclick="return confirm('test')" />
    
    </div>
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
    <br />
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />
    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Button" />
    <br />
    <telerik:RadGrid ID="RadGrid3" runat="server" CellSpacing="0" Culture="zh-TW" 
        GridLines="None" AutoGenerateHierarchy="True" 
        onexcelexportcellformatting="RadGrid3_ExcelExportCellFormatting" 
        onexcelmlexportrowcreated="RadGrid3_ExcelMLExportRowCreated" 
        onexportcellformatting="RadGrid3_ExportCellFormatting" 
        onitemdatabound="RadGrid3_ItemDataBound" 
        onneeddatasource="RadGrid3_NeedDataSource" ShowFooter="True">
        <ExportSettings ExportOnlyData="True">
            <Excel Format="ExcelML" />
        </ExportSettings>
<ClientSettings>
<Selecting CellSelectionMode="None"></Selecting>
</ClientSettings>

<MasterTableView ShowFooter="False">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
    <br />
    <asp:Button ID="Button5" runat="server" Text="test_del" 
        onclick="Button5_Click" />
    <br />
    <telerik:RadButton ID="RadButton1" runat="server" onclick="RadButton1_Click" 
        Text="test">
    </telerik:RadButton>
    <br />
    <telerik:RadButton ID="RadButton3" runat="server" Skin="Hay" Text="RadButton" 
        onclick="RadButton3_Click">
    </telerik:RadButton>
    <telerik:RadDateTimePicker ID="RadDateTimePicker1" Runat="server">
    </telerik:RadDateTimePicker>
    <br />
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        <asp:ListItem>123</asp:ListItem>
        <asp:ListItem>456</asp:ListItem>
        <asp:ListItem>789</asp:ListItem>
    </asp:CheckBoxList>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>123</asp:ListItem>
        <asp:ListItem>456</asp:ListItem>
        <asp:ListItem>789</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="Button" />
    <br />
    <br />
  
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" 
        MultipleFileSelection="Automatic">
    </telerik:RadAsyncUpload>
    <telerik:RadComboBox ID="RadComboBox1" Runat="server" 
        Culture="zh-TW" DataSourceID="SqlDataSource1" DataTextField="sName" 
        DataValueField="iAutokey" AllowCustomText="True" Filter="Contains" 
        MarkFirstMatch="True" MaxLength="5" Skin="Sunset">
    </telerik:RadComboBox>
    <br />
    <telerik:RadEditor ID="RadEditor1" Runat="server">
    </telerik:RadEditor>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" 
        CellSpacing="0" Culture="zh-TW" GridLines="None" 
        onpageindexchanged="RadGrid1_PageIndexChanged">
    </telerik:RadGrid>
    <telerik:RadButton ID="RadButton2" runat="server" onclick="RadButton2_Click" 
        Text="RadButton">
    </telerik:RadButton>
    <br />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="iAutokey" 
        DataSourceID="SqlDataSource1" RepeatColumns="8" RepeatDirection="Horizontal">
        <ItemTemplate>
            sName:
            <asp:Label ID="sNameLabel" runat="server" Text='<%# Eval("sName") %>' />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl='<%# "~/Default_Disp.aspx?id=" + Eval("sName") %>' 
                Text='<%# Eval("sName") %>'></asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        SelectCommand="SELECT * FROM [trNotifyItem]"></asp:SqlDataSource>
    <br />
    <telerik:RadToolBar ID="RadToolBar1" Runat="server">
    </telerik:RadToolBar>
    <telerik:RadGrid ID="RadGrid2" runat="server">
    </telerik:RadGrid>
    <br />
    </form>
</body>
</html>
