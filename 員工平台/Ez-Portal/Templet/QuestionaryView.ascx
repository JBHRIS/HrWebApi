<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuestionaryView.ascx.cs"
    Inherits="Templet_QuestionaryView" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
    BorderStyle="None">
    <h3>
        <telerik:RadButton ID="btnHeader" runat="server" ButtonType="ToggleButton" Text="問卷調查"
            Font-Size="14px" OnCheckedChanged="btnHeader_CheckedChanged" Skin="Simple" ToggleType="CheckBox"
            Font-Names="微軟正黑體,arial" HoveredCssClass="Home" Checked="True">
        </telerik:RadButton>
    </h3>
    <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW" GridLines="None"
        Skin="Simple" OnNeedDataSource="gv_NeedDataSource" OnItemCommand="gv_ItemCommand"
        AutoGenerateColumns="False" BorderStyle="None" Height="200px" ShowHeader="False">
        <ClientSettings>
            <Scrolling AllowScroll="True" />
        </ClientSettings>
        <MasterTableView DataKeyNames="Id">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" HeaderText="Id"
                    UniqueName="Id" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn CommandName="FillIn" FilterControlAltText="Filter cmdFillIn column"
                    Text="填寫" UniqueName="cmdFillIn" Visible="False">
                    <ItemStyle Font-Size="Medium" />
                </telerik:GridButtonColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text='<%# Eval("Name") %>'></asp:Label>
                        <br />
                        <telerik:RadButton ID="RadButton1" runat="server" CommandName="FillIn" Text="填寫">
                        </telerik:RadButton>
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
    </telerik:RadGrid>
</telerik:RadAjaxPanel>