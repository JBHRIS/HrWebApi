<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherCost.aspx.cs" Inherits="eTraining_Admin_Do_TeacherCost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>        
        <telerik:RadGrid ID="gv" runat="server" onneeddatasource="gv_NeedDataSource" 
            Width="80%" CellSpacing="0" Culture="zh-TW" GridLines="None" 
            AutoGenerateColumns="False" Skin="Outlook" 
            onitemdatabound="gv_ItemDataBound">
<ClientSettings>
<Selecting CellSelectionMode="None"></Selecting>
</ClientSettings>

<MasterTableView DataKeyNames="iAutoKey">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="iAutoKey" 
            FilterControlAltText="Filter iAutoKey column" UniqueName="iAutoKey" 
            Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TeacherName" 
            FilterControlAltText="Filter TeacherName column" HeaderText="講師名稱" 
            UniqueName="TeacherName">
        </telerik:GridBoundColumn>
        <telerik:GridCheckBoxColumn DataField="IsEntTeacher" 
            FilterControlAltText="Filter IsEntTeacher column" HeaderText="是否為內部講師" 
            UniqueName="IsEntTeacher">
        </telerik:GridCheckBoxColumn>
        <telerik:GridBoundColumn DataField="Nobr" 
            FilterControlAltText="Filter Nobr column" HeaderText="工號" UniqueName="Nobr">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn DataField="Charge" 
            FilterControlAltText="Filter Charge column" HeaderText="費用" UniqueName="Charge">
            <EditItemTemplate>
                <asp:TextBox ID="ChargeTextBox" runat="server" Text='<%# Bind("Charge") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <telerik:RadNumericTextBox ID="ntbCharge" Runat="server" Culture="zh-TW" 
                    DataType="System.Int32" DbValue='<%# Bind("Charge") %>' 
                    EnableSingleInputRendering="True" LabelWidth="64px">
                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                </telerik:RadNumericTextBox>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn DataField="Minutes" DataType="System.Double" 
            FilterControlAltText="Filter Minutes column" HeaderText="課程上課時數" 
            UniqueName="Minutes">
            <ItemTemplate>
                <telerik:RadNumericTextBox ID="ntbMinutes" Runat="server" Culture="zh-TW" 
                    DbValue='<%# Bind("Minutes") %>' EnableSingleInputRendering="True" 
                    LabelWidth="64px" style="top: 0px; left: 0px">
                </telerik:RadNumericTextBox>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>
        <br />
        <telerik:RadButton ID="btnSave" runat="server" Text="儲存" 
            onclick="btnSave_Click">
        </telerik:RadButton>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
    </div>
    </form>
</body>
</html>
