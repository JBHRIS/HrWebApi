<%@ Page Title="學員名立牌" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="NameCard.aspx.cs" Inherits="eTraining_Reports_Do_NameCard" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        學員名立牌</h2>
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
                <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" SelectedDate="2011-02-01">
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
            <telerik:RadButton ID="RadButton1" runat="server" Text="確定" Skin="Office2007">
            </telerik:RadButton>
            <br />
        </fieldset>
    </div>
    <asp:Label ID="lblClassID" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Panel ID="pnlCourseList" runat="server">
        <telerik:RadGrid ID="gvCourseList" runat="server" CellSpacing="0" Culture="zh-TW"
            DataSourceID="sdsGv" GridLines="None" Skin="Vista" Width="100%" 
            AllowFilteringByColumn="True" AllowPaging="True">
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
                        UniqueName="TemplateColumn" Visible="False">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnS" runat="server" Text="名立牌" CommandArgument='<%# Eval("iAutoKey") %>'
                                Skin="Windows7" onclick="btnS_Click">
                            </telerik:RadButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
                        UniqueName="TemplateColumn1" AllowFiltering="False">
                        <ItemTemplate>
                            <telerik:RadButton ID="btn1" runat="server" 
                                CommandArgument='<%# Eval("iAutoKey") %>' onclick="btn1_Click" Skin="Windows7" 
                                Text="小立牌">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btn2" runat="server" 
                                CommandArgument='<%# Eval("iAutoKey") %>' onclick="btn2_Click" Skin="Windows7" 
                                Text="大立牌">
                            </telerik:RadButton>
                            <telerik:RadButton ID="btn3" runat="server" Text="名牌" 
                                CommandArgument='<%# Eval("iAutoKey") %>' onclick="btn3_Click" 
                                Skin="Windows7">
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
    <br />
    <asp:Panel ID="pnlReport" runat="server" Visible="False">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt" Height="800px" Width="100%">
            <LocalReport ReportPath="eTraining\Reports\Do\NameCard.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </asp:Panel>
    <asp:Panel ID="pnlS" runat="server" Visible="false">
        <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="800px" InteractiveDeviceInfos="(集合)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="eTraining\Reports\Do\NameCardS.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </asp:Panel>
    <asp:Panel ID="pnlF" runat="server" Visible="false">
        <rsweb:ReportViewer ID="ReportViewer3" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="800px" InteractiveDeviceInfos="(集合)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="eTraining\Reports\Do\NameCardF.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </asp:Panel>
    <asp:Panel ID="pnlN" runat="server" Visible="false">
        <rsweb:ReportViewer ID="ReportViewer4" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="800px" InteractiveDeviceInfos="(集合)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="eTraining\Reports\Do\NameCardN.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </asp:Panel>
</asp:Content>
