<%@ Page Title="職能積分卡目標設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="TrainingCardGoal.aspx.cs" Inherits="eTraining_Admin_Do_TrainingCardGoal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        職能積分卡目標設定</h2>
    選擇職能積分卡<telerik:RadComboBox ID="cbxOjt" runat="server" 
        DataSourceID="sdscbx" DataTextField="sName"
        DataValueField="sCode" AutoPostBack="True" ondatabound="cbxOjt_DataBound" 
        onselectedindexchanged="cbxOjt_SelectedIndexChanged">
    </telerik:RadComboBox>
    <asp:SqlDataSource ID="sdscbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="SELECT [sCode], [sName] FROM [trOJTTemplate]"></asp:SqlDataSource>
    <br />
    年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="80px" 
        AutoPostBack="True" ondatabound="cbxYear_DataBound" 
        onselectedindexchanged="cbxYear_SelectedIndexChanged">
    </telerik:RadComboBox>
    <telerik:RadGrid ID="GV" runat="server" CellSpacing="0" Culture="zh-TW" 
        DataSourceID="sdsGV" GridLines="None" Visible="False">
<MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" 
            DataSourceID="sdsGV">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
            ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iOJTTemplateCode" 
            FilterControlAltText="Filter iOJTTemplateCode column" 
            HeaderText="iOJTTemplateCode" SortExpression="iOJTTemplateCode" 
            UniqueName="iOJTTemplateCode" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iYear" DataType="System.Int32" 
            FilterControlAltText="Filter iYear column" HeaderText="iYear" 
            SortExpression="iYear" UniqueName="iYear" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn DataField="iMonth1" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth1 column" HeaderText="iMonth1" 
            SortExpression="iMonth1" UniqueName="iMonth1">
            <EditItemTemplate>
                <asp:TextBox ID="iMonth1TextBox" runat="server" Text='<%# Bind("iMonth1") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="iMonth1Label" runat="server" Text='<%# Eval("iMonth1") %>'></asp:Label>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridBoundColumn DataField="iMonth2" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth2 column" HeaderText="iMonth2" 
            SortExpression="iMonth2" UniqueName="iMonth2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth3" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth3 column" HeaderText="iMonth3" 
            SortExpression="iMonth3" UniqueName="iMonth3">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth4" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth4 column" HeaderText="iMonth4" 
            SortExpression="iMonth4" UniqueName="iMonth4">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth5" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth5 column" HeaderText="iMonth5" 
            SortExpression="iMonth5" UniqueName="iMonth5">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth6" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth6 column" HeaderText="iMonth6" 
            SortExpression="iMonth6" UniqueName="iMonth6">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth7" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth7 column" HeaderText="iMonth7" 
            SortExpression="iMonth7" UniqueName="iMonth7">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth8" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth8 column" HeaderText="iMonth8" 
            SortExpression="iMonth8" UniqueName="iMonth8">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth9" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth9 column" HeaderText="iMonth9" 
            SortExpression="iMonth9" UniqueName="iMonth9">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth10" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth10 column" HeaderText="iMonth10" 
            SortExpression="iMonth10" UniqueName="iMonth10">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth11" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth11 column" HeaderText="iMonth11" 
            SortExpression="iMonth11" UniqueName="iMonth11">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iMonth12" DataType="System.Int32" 
            FilterControlAltText="Filter iMonth12 column" HeaderText="iMonth12" 
            SortExpression="iMonth12" UniqueName="iMonth12">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAvg" DataType="System.Int32" 
            FilterControlAltText="Filter iAvg column" HeaderText="iAvg" 
            SortExpression="iAvg" UniqueName="iAvg" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="sKeyMan" 
            FilterControlAltText="Filter sKeyMan column" HeaderText="sKeyMan" 
            SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
            FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
            SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
    <asp:SqlDataSource ID="sdsGV" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select * from trTrainingCardGoal
where iOJTTemplateCode=@OJTTemplate
and iYear=@Year" onselecting="sdsGV_Selecting" onselected="sdsGV_Selected">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbxOjt" DefaultValue="0" Name="OJTTemplate" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="Year" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table class="tableBlue">
        <tr>
            <th>
                一月
            </th>
            <th>
                二月
            </th>
            <th>
                三月
            </th>
            <th>
                四月
            </th>
            <th>
                五月
            </th>
            <th>
                六月
            </th>
            <th>
                七月
            </th>
            <th>
                八月
            </th>
            <th>
                九月
            </th>
            <th>
                十月
            </th>
            <th>
                十一月
            </th>
            <th>
                十二月
            </th>
        </tr>
        <tr>
            <td>
                <telerik:RadNumericTextBox ID="ntbG1" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG2" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG3" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG4" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG5" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG6" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG7" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG8" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG9" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG10" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG11" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="ntbG12" Runat="server" DataType="System.Int32" 
                    MinValue="0" Width="50px">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
        </tr>
    </table>
    <br />
    <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click">
    </telerik:RadButton>
    &nbsp;
    <telerik:RadButton ID="btnCancel" runat="server" Text="取消" 
        onclick="btnCancel_Click">
    </telerik:RadButton>
</asp:Content>
