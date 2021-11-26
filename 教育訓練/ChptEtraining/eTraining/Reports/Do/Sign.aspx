<%@ Page Title="簽到表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="Sign.aspx.cs" Inherits="eTraining_Reports_Do_Sign" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        簽到表</h2>
    <asp:Panel ID="pnlCourseList" runat="server">
        <div class="field">
            <fieldset style="background-color: #EEF5FC; width: 400px">
                <legend>篩選條件</legend>年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
                </telerik:RadComboBox>
                <br />
                <br />
                日期<telerik:RadDatePicker ID="dpStartD" runat="server" Culture="zh-TW" SelectedDate="2011-02-01"
                    Skin="Outlook">
                    <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                        ViewSelectorText="x">
                    </Calendar>
                    <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" 
                        SelectedDate="2011-02-01">
                    </DateInput>
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                </telerik:RadDatePicker>
                ~<telerik:RadDatePicker ID="dpEndD" runat="server" Culture="zh-TW" SelectedDate="2011-09-27"
                    Skin="Outlook">
                    <Calendar Skin="Outlook" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                        ViewSelectorText="x">
                    </Calendar>
                    <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" SelectedDate="2011-09-27">
                    </DateInput>
                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                </telerik:RadDatePicker>
                <br />
                <br />
                <telerik:RadButton ID="RadButton1" runat="server" OnClick="RadButton1_Click" Text="確定"
                    Skin="Office2007">
                </telerik:RadButton>
                <br />
            </fieldset>
        </div>
        <br />
        <telerik:RadGrid ID="gvCourseList" runat="server" CellSpacing="0" Culture="zh-TW"
            DataSourceID="sdsGv" GridLines="None" Skin="Vista" Width="70%" 
            AllowFilteringByColumn="True" Visible="False" AllowPaging="True">
            <MasterTableView AutoGenerateColumns="False" DataKeyNames="iAutoKey" DataSourceID="sdsGv">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" FilterControlAltText="Filter iAutoKey column"
                        HeaderText="iAutoKey" ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey"
                        Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sCode" FilterControlAltText="Filter sCode column"
                        HeaderText="階層代碼" SortExpression="sCode" UniqueName="CaCode">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                        HeaderText="階層名稱" SortExpression="sName" UniqueName="CaName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sCode1" FilterControlAltText="Filter sCode1 column"
                        HeaderText="課程代碼" UniqueName="CourseCode">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="sName1" FilterControlAltText="Filter sName1 column"
                        HeaderText="課程名稱" UniqueName="CourseName">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                        UniqueName="TemplateColumn" AllowFiltering="False" ShowFilterIcon="False">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnS" runat="server" Text="訓練名單" CommandArgument='<%# Eval("iAutoKey") %>'
                                OnClick="btnS_Click" Skin="Windows7">
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
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlDate" runat="server" Visible="False">
        <asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblCourseName" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 上課日期<telerik:RadComboBox ID="cbxClassDate"
            runat="server" DataSourceID="sdsClassDate" DataTextField="dClassDate" DataValueField="iAutoKey"
            Width="125px" DataTextFormatString="{0:d}">
        </telerik:RadComboBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <telerik:RadButton ID="btnCheck" runat="server" Text="確定" OnClick="btnCheck_Click">
        </telerik:RadButton>
        <telerik:RadButton ID="btnBack" runat="server" OnClick="btnBack_Click" Text="回上頁">
        </telerik:RadButton>
        <br />
        <asp:Panel ID="pnlReport" runat="server" Visible="False">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                Width="100%" Height="800px">
                <LocalReport ReportPath="eTraining\Reports\Do\Sign.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </asp:Panel>
        <br />
    </asp:Panel>
    <br />
    <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select a.iAutoKey,ca.sCode,ca.sName,b.sCode,b.sName from trTrainingDetailM a 
join trCourse b on a.trCourse_sCode=b.sCode
join trCategoryCourse caco on b.sCode=caco.sCourseCode
join trCategory ca on caco.sCateCode=ca.sCode
where a.iYear=@Year and a.bIsPublished=1
and a.dDateA between @dateA and @dateZ
">
        <SelectParameters>
            <asp:ControlParameter ControlID="cbxYear" DefaultValue="0" Name="Year" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="dpStartD" DefaultValue="0" Name="dateA" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="dpEndD" DefaultValue="0" Name="dateZ" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsClassDate" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="select * from trAttendClassDate where iClassAutoKey =@iAutokey">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblClassID" DefaultValue="0" Name="iAutokey" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
</asp:Content>
