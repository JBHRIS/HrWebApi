<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="CourseInfoD.aspx.cs" Inherits="eTraining_Admin_Do_CourseInfoD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="field" style="width: 100%">
        <h2>
            階層-課程名稱<telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" 
                Skin="Windows7" />
        </h2>
        <fieldset style="background-color: #EEF5FC; width: 100%">
            <legend>上課資訊</legend>
            <table width="100%">
                <tr>
                    <th>
                        課程日期
                    </th>
                    <td>
                        <asp:Label ID="lblClassBeginDate" runat="server"></asp:Label>
&nbsp;～ 
                        <asp:Label ID="lblClassEndDate" runat="server"></asp:Label>
                    </td>
                    <th>
                        梯次
                    </th>
                    <td>
                        <asp:Label ID="lblSession" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        上課時間
                    </th>
                    <td>
                        <telerik:RadGrid ID="gvAttendDate" runat="server" AutoGenerateColumns="False" 
                            CellSpacing="0" Culture="zh-TW" GridLines="None" 
                            onneeddatasource="gvAttendDate_NeedDataSource">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn FilterControlAltText="Filter ClassDate column" 
            HeaderText="日期" UniqueName="ClassDate">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter ClassBeginTime column" 
            HeaderText="上課" UniqueName="ClassBeginTime">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter ClassEndTime column" 
            HeaderText="下課" UniqueName="ClassEndTime">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                        </telerik:RadGrid>
                    </td>
                    <th>
                        時間
                    </th>
                    <td>
                        15:00~17:00
                    </td>
                </tr>
                <tr>
                    <th>
                        講師
                    </th>
                    <td>
                        陳老師
                    </td>
                    <th>
                        訓別
                    </th>
                    <td>
                        外訓
                    </td>
                </tr>
                <tr>
                    <th>
                        地點
                    </th>
                    <td>
                        訓練教室
                    </td>
                    <th>
                        學員人數
                    </th>
                    <td>
                        &nbsp;<asp:Label ID="lblStudentNum" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />
    <div class="field" style="width: 100%">
        <fieldset style="background-color: #EEF5FC; width: 100%">
            <legend>課程目標</legend>
            <asp:Label ID="Label1" runat="server" Text="課程內容課程內容課程內容課程內容課程內容"></asp:Label>
        </fieldset>
    </div>
    <br />
    <div class="field" style="width: 100%">
        <fieldset style="background-color: #EEF5FC; width: 100%">
            <legend>課程大鋼</legend>
            <asp:Label ID="Label3" runat="server" Text="課程內容課程內容課程內容課程內容課程內容"></asp:Label>
        </fieldset>
    </div>
    <br />
    <div class="field" style="width: 48%;float:left">
        <fieldset style="background-color: #EEF5FC; width: 100%">
            <legend>教案</legend>
            <asp:HyperLink ID="HyperLink1" runat="server">教案下載</asp:HyperLink>
        </fieldset>
    </div>
    <div class="field" style="width: 48%;float:right">
        <fieldset style="background-color: #EEF5FC; width: 100%">
            <legend>教材</legend>
            <asp:Label ID="Label2" runat="server" Text="無"></asp:Label>
        </fieldset>
    </div>
</asp:Content>
