<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ViewQuestionare.aspx.cs" Inherits="eTraining_Teacher_TeacherWrite" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        查詢課程問卷資料</h2>
    年度
    <telerik:RadComboBox ID="RadComboBox1" runat="server" Width="70px">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="2010" Value="2010" />
            <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
            <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
        </Items>
    </telerik:RadComboBox>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" 
        Skin="Windows7" Width="80%">
        <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink4" runat="server" 
                            NavigateUrl="~/eTraining/Teacher/ViewQuestionare1.aspx">查閱</asp:HyperLink>
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
    <div style="color: #FF0000">
        備註:若課程相關問卷尚未開放查閱則不show查閱btn</div>
</asp:Content>
