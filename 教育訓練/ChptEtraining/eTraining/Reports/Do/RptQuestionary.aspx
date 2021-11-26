<%@ Page Title="問卷分數一覽表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="RptQuestionary.aspx.cs" Inherits="eTraining_Reports_Do_RptQuestionary" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        問卷分數一覽表
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <fieldset style="background-color: #EEF5FC; width: 100%">
            <legend>篩選條件</legend>
            <table>
                <tr>
                    <td>
                        時間起<telerik:RadDatePicker ID="dpB" runat="server">
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        時間迄<telerik:RadDatePicker ID="dpE" runat="server">
                        </telerik:RadDatePicker>
                    </td>
                    <td>
                        <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </fieldset>
        <telerik:RadGrid ID="gv" runat="server" Culture="zh-TW" AutoGenerateColumns="False"
            CellSpacing="0" GridLines="None" onitemcommand="gv_ItemCommand">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="AutoKey">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter Select column"
                        Text="選擇" UniqueName="Select">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="AutoKey" FilterControlAltText="Filter AutoKey column"
                        HeaderText="AutoKey" UniqueName="AutoKey" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="QTplCode" FilterControlAltText="Filter QTplCode column"
                        HeaderText="QTplCode" UniqueName="QTplCode" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="QTplName" FilterControlAltText="Filter QTplName column"
                        HeaderText="問卷名稱" UniqueName="QTplName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DeadLine" FilterControlAltText="Filter DeadLine column"
                        HeaderText="問卷填寫截止日" UniqueName="DeadLine" DataFormatString="{0:yyyy/M/d HHmm}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ClassDateTimeB" DataFormatString="{0:yyyy/M/d HHmm}"
                        FilterControlAltText="Filter ClassDateTimeB column" HeaderText="課程時間" UniqueName="ClassDateTimeB">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ClassName" FilterControlAltText="Filter ClassName column"
                        HeaderText="課程名稱" UniqueName="ClassName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Counter" 
                        FilterControlAltText="Filter Counter column" UniqueName="Counter">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
                <telerik:RadWindow ID="win" runat="server" Modal="True" EnableShadow="True" 
            VisibleStatusbar="False">
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
</asp:Content>
