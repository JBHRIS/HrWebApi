<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActualAMT.aspx.cs" Inherits="eTraining_Admin_Do_SetCourse6" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblPlanAmt" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;<br />
        &nbsp;<asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Panel ID="pnlCost" runat="server" Visible="False">
            <telerik:RadGrid ID="gvCostItem" runat="server" CellSpacing="0" Culture="zh-TW" DataSourceID="sdsGvCostItem"
                GridLines="None" OnNeedDataSource="gvCostItem_NeedDataSource" OnSelectedIndexChanged="gvCostItem_SelectedIndexChanged"
                Skin="Windows7" Width="40%">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="trCostItemCode" DataSourceID="sdsGvCostItem">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column column"
                            Text="加入" UniqueName="column" Visible="False">
                        </telerik:GridButtonColumn>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column1 column" UniqueName="column1">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="trCostItemName" FilterControlAltText="Filter trCostItemName column"
                            HeaderText="費用名稱" SortExpression="trCostItemName" UniqueName="trCostItemName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trCostItemCode" FilterControlAltText="Filter trCostItemCode column"
                            HeaderText="trCostItemCode" SortExpression="trCostItemCode" UniqueName="trCostItemCode"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                            HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="金額"
                            UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="txtAmt" runat="server">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid>
            <br />
            <telerik:RadButton ID="btnCostAdd" runat="server" OnClick="btnCostAdd_Click" Text="加入">
            </telerik:RadButton>
            &#160;
            <telerik:RadButton ID="btnCancelC" runat="server" OnClick="btnCancelC_Click" Text="取消">
            </telerik:RadButton>
            &#160;<asp:SqlDataSource ID="sdsGvCostItem" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT * FROM [trCostItem]"></asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="pnlACost" runat="server">
            <div>
                <telerik:RadButton ID="btnAddC" runat="server" Text="加入費用" OnClick="btnAddC_Click">
                </telerik:RadButton>
            </div>
            <br />
            <div style="float: left; width: 35%">
                <telerik:RadGrid ID="gvEstimateAmt" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                    Culture="zh-TW" DataSourceID="sdsGvEstimateAmt" GridLines="None" Skin="Outlook">
                    <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey" DataSourceID="sdsGvEstimateAmt">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="trCostItemName" FilterControlAltText="Filter trCostItemName column"
                                HeaderText="預估費用" SortExpression="trCostItemName" UniqueName="trCostItemName">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="iAmt" DataType="System.Int32" FilterControlAltText="Filter iAmt column"
                                HeaderText="金額" SortExpression="iAmt" UniqueName="iAmt">
                                <EditItemTemplate>
                                    <asp:TextBox ID="iAmtTextBox0" runat="server" Text='<%# Bind("iAmt") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblamt" runat="server" Text='<%# Bind("iAmt") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="dPayDate" DataType="System.DateTime" FilterControlAltText="Filter dPayDate column"
                                HeaderText="dPayDate" SortExpression="dPayDate" UniqueName="dPayDate" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="trCostItem_sCode" FilterControlAltText="Filter trCostItem_sCode column"
                                HeaderText="trCostItem_sCode" SortExpression="trCostItem_sCode" UniqueName="trCostItem_sCode"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                <asp:SqlDataSource ID="sdsGvEstimateAmt" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    DeleteCommand="DELETE FROM [trTrainingEstimateCost] WHERE [iAutoKey] = @iAutoKey"
                    InsertCommand="INSERT INTO [trTrainingEstimateCost] ([iClassAutoKey], [trCostItem_sCode], [iAmt], [dPayDate], [sKeyMan], [dKeyDate]) VALUES (@iClassAutoKey, @trCostItem_sCode, @iAmt, @dPayDate, @sKeyMan, @dKeyDate)"
                    SelectCommand="SELECT ec.*,cost.trCostItemName FROM [trTrainingEstimateCost] ec join trCostItem cost on ec.trCostItem_sCode = cost.trCostItemCode WHERE ([iClassAutoKey] = @iClassAutoKey)
order by cost.trCostItemName
"
                    
                    
                    UpdateCommand="UPDATE [trTrainingEstimateCost] SET [iClassAutoKey] = @iClassAutoKey, [trCostItem_sCode] = @trCostItem_sCode, [iAmt] = @iAmt, [dPayDate] = @dPayDate, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                    <DeleteParameters>
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                        <asp:Parameter Name="trCostItem_sCode" Type="String" />
                        <asp:Parameter Name="iAmt" Type="Int32" />
                        <asp:Parameter Name="dPayDate" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iClassAutoKey"
                            PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                        <asp:Parameter Name="trCostItem_sCode" Type="String" />
                        <asp:Parameter Name="iAmt" Type="Int32" />
                        <asp:Parameter Name="dPayDate" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
            <div style="float: right; width: 60%">
                <telerik:RadGrid ID="gvActualAmt" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                    Culture="zh-TW" DataSourceID="sdsGvActualAMT" GridLines="None" OnItemDeleted="gvActualAmt_ItemDeleted"
                    Skin="Outlook" Width="60%">
                    <MasterTableView AllowAutomaticDeletes="True" DataKeyNames="iAutoKey" DataSourceID="sdsGvActualAMT">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="trCostItemName" FilterControlAltText="Filter trCostItemName column"
                                HeaderText="實支實付" SortExpression="trCostItemName" UniqueName="trCostItemName">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="iAmt" DataType="System.Int32" FilterControlAltText="Filter iAmt column"
                                HeaderText="金額" SortExpression="iAmt" UniqueName="iAmt">
                                <EditItemTemplate>
                                    <asp:TextBox ID="iAmtTextBox" runat="server" Text='<%# Bind("iAmt") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <telerik:RadNumericTextBox ID="ntb_iAmt" runat="server" Culture="zh-TW" DataType="System.Int32"
                                        DbValue='<%# Bind("iAmt") %>' Width="125px">
                                        <NumberFormat DecimalDigits="0" />
                                    </telerik:RadNumericTextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="dPayDate" DataType="System.DateTime" FilterControlAltText="Filter dPayDate column"
                                HeaderText="dPayDate" SortExpression="dPayDate" UniqueName="dPayDate" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="trCostItem_sCode" FilterControlAltText="Filter trCostItem_sCode column"
                                HeaderText="trCostItem_sCode" SortExpression="trCostItem_sCode" UniqueName="trCostItem_sCode"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iClassAutoKey" DataType="System.Int32" FilterControlAltText="Filter iClassAutoKey column"
                                HeaderText="iClassAutoKey" SortExpression="iClassAutoKey" UniqueName="iClassAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                                HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                ConfirmText="確定刪除?" FilterControlAltText="Filter delete column" UniqueName="delete">
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
                
                <asp:Label ID="lblActualAmt" runat="server" Font-Size="Medium"></asp:Label>
                <br />
                <asp:SqlDataSource ID="sdsGvActualAMT" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                    DeleteCommand="DELETE FROM [trTrainingActualCost] WHERE [iAutoKey] = @iAutoKey"
                    InsertCommand="INSERT INTO [trTrainingEstimateCost] ([iClassAutoKey], [trCostItem_sCode], [iAmt], [dPayDate], [sKeyMan], [dKeyDate]) VALUES (@iClassAutoKey, @trCostItem_sCode, @iAmt, @dPayDate, @sKeyMan, @dKeyDate)"
                    SelectCommand="SELECT ec.*,cost.trCostItemName FROM [trTrainingActualCost] ec join trCostItem cost on ec.trCostItem_sCode = cost.trCostItemCode WHERE ([iClassAutoKey] = @ID) order by cost.trCostItemName"
                    
                    
                    UpdateCommand="UPDATE [trTrainingEstimateCost] SET [iClassAutoKey] = @iClassAutoKey, [trCostItem_sCode] = @trCostItem_sCode, [iAmt] = @iAmt, [dPayDate] = @dPayDate, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                    <DeleteParameters>
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                        <asp:Parameter Name="trCostItem_sCode" Type="String" />
                        <asp:Parameter Name="iAmt" Type="Int32" />
                        <asp:Parameter Name="dPayDate" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ID" QueryStringField="ID" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="iClassAutoKey" Type="Int32" />
                        <asp:Parameter Name="trCostItem_sCode" Type="String" />
                        <asp:Parameter Name="iAmt" Type="Int32" />
                        <asp:Parameter Name="dPayDate" Type="DateTime" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <telerik:RadButton ID="RadButton1" runat="server" GroupName="check" OnClick="btnSaveCost_Click"
                    Text="存檔">
                </telerik:RadButton>
            </div>
        </asp:Panel>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>
