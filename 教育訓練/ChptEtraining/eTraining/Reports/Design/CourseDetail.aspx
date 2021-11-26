<%@ Page Title="月份課程安排表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="CourseDetail.aspx.cs" Inherits="eTraining_Reports_Design_CourseDetail" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        月份課程安排表</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 400px">
            <legend>篩選條件</legend>年度<telerik:RadComboBox ID="cbxYear" runat="server" Width="70px">
            </telerik:RadComboBox>
            &nbsp;&nbsp;&nbsp;&nbsp; <telerik:RadComboBox ID="cbxMonth" runat="server" Width="70px" 
                Visible="False">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="1" Value="1" />
                    <telerik:RadComboBoxItem runat="server" Text="2" Value="2" />
                    <telerik:RadComboBoxItem runat="server" Text="3" Value="3" />
                    <telerik:RadComboBoxItem runat="server" Text="4" Value="4" />
                    <telerik:RadComboBoxItem runat="server" Text="5" Value="5" />
                    <telerik:RadComboBoxItem runat="server" Text="6" Value="6" />
                    <telerik:RadComboBoxItem runat="server" Text="7" Value="7" />
                    <telerik:RadComboBoxItem runat="server" Text="8" Value="8" />
                    <telerik:RadComboBoxItem runat="server" Text="9" Value="9" />
                    <telerik:RadComboBoxItem runat="server" Text="10" Value="10" />
                    <telerik:RadComboBoxItem runat="server" Text="11" Value="11" />
                    <telerik:RadComboBoxItem runat="server" Text="12" Value="12" />
                </Items>
            </telerik:RadComboBox>
            <br />
            <br />
            日期<telerik:RadDatePicker ID="dpStartD" runat="server" Skin="Outlook">
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                    Skin="Outlook">
                </Calendar>
                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            ~<telerik:RadDatePicker ID="dpEndD" runat="server" Skin="Outlook">
                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                    Skin="Outlook">
                </Calendar>
                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            <br />
            <br />
            講師<telerik:RadComboBox ID="cbxTeacher" runat="server" CheckBoxes="True" DataSourceID="sdsTeacher"
                DataTextField="sName" DataValueField="sCode" EnableCheckAllItemsCheckBox="True" 
                >
            </telerik:RadComboBox>
            <asp:SqlDataSource ID="sdsTeacher" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="select sCode,sName from trTeacher
"></asp:SqlDataSource>
            <telerik:RadButton ID="btnCheck" runat="server" Text="確定" OnClick="btnCheck_Click">
            </telerik:RadButton>
            <telerik:RadButton ID="btnExcel" runat="server" Text="Excel" 
                onclick="btnExcel_Click">
            </telerik:RadButton>
        </fieldset>
    </div>
    <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" 
        CellSpacing="0" Culture="zh-TW" onprerender="gv_PreRender" 
        Skin="Transparent">
<MasterTableView DataKeyNames="iAutoKey">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="ClassAttendDate" DataFormatString="{0:d}" 
            FilterControlAltText="Filter ClassAttendDate column" HeaderText="日期" 
            UniqueName="ClassAttendDate">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ClassAttendDateTime" 
            FilterControlAltText="Filter ClassAttendDateTime column" HeaderText="上課時間" 
            UniqueName="ClassAttendDateTime">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ClassCat" 
            FilterControlAltText="Filter ClassCat column" HeaderText="階層" 
            UniqueName="ClassCat">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ClassName" 
            FilterControlAltText="Filter ClassName column" HeaderText="課程名稱" 
            UniqueName="ClassName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Teacher" 
            FilterControlAltText="Filter Teacher column" HeaderText="講師" 
            UniqueName="Teacher">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Place" 
            FilterControlAltText="Filter Place column" HeaderText="地點" UniqueName="Place">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TrainingMethod" 
            FilterControlAltText="Filter TrainingMethod column" HeaderText="訓別" 
            UniqueName="TrainingMethod">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Student" 
            FilterControlAltText="Filter Student column" HeaderText="學員" 
            UniqueName="Student">
            <ItemStyle Width="100px" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Cost" 
            FilterControlAltText="Filter Cost column" HeaderText="費用" UniqueName="Cost">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iClassAutoKey" 
            FilterControlAltText="Filter iClassAutoKey column" HeaderText="iClassAutoKey" 
            UniqueName="iClassAutoKey" Visible="False">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="iAutoKey" 
            FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
            UniqueName="iAutoKey" Visible="False">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="900px" 
        Width="100%">
    </rsweb:ReportViewer>
</asp:Content>
