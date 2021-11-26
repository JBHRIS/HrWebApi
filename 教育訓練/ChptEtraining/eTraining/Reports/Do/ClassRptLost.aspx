<%@ Page Title="心得缺繳統計一覽表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ClassRptLost.aspx.cs" Inherits="eTraining_Reports_Do_ClassRptLost" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        出席-心得缺繳統計一覽表</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 700px">
            <legend>篩選條件</legend>
            <table style="width: 100%;">
                <tr>
                    <td align="left" valign="top">
                        時間起<telerik:RadDatePicker ID="rdpAdate" runat="server">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdpAdate"
                            Display="Dynamic" ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                        <br />
                        時間迄<telerik:RadDatePicker ID="rdpDdate" runat="server">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpDdate"
                            Display="Dynamic" ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                        <br />
                        <telerik:RadComboBox ID="cbType" runat="server" Culture="zh-TW">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Checked="True" Text="未填寫學員" Value="0" Owner="cbType" />
                                <telerik:RadComboBoxItem runat="server" Text="未評分講師" Value="1" Owner="cbType" />
                            </Items>
                        </telerik:RadComboBox>
                        <telerik:RadButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查詢">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出Excel" OnClick="btnExportExcel_Click"
                            ValidationGroup="g">
                        </telerik:RadButton>
                    </td>
                    <td align="left" valign="top">
                        <div class="field">
                            <fieldset style="background-color: #EEF5FC; width: 200px">
                                <legend>寄送人員</legend>
                                <asp:RadioButtonList ID="rbl" runat="server" Font-Size="Small" Width="200px" AutoPostBack="True"
                                    OnSelectedIndexChanged="rbl_SelectedIndexChanged">
                                    <asp:ListItem Value="1">講師</asp:ListItem>
                                    <asp:ListItem Value="3">清單中學員</asp:ListItem>
                                    <asp:ListItem Value="4">清單中學員及該部門主管</asp:ListItem>
                                    <asp:ListItem Value="5">清單中學員及上層主管</asp:ListItem>
                                    <asp:ListItem Value="6">清單中學員及上二層主管</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RadioButtonList ID="rblStudentProperty" runat="server" Visible="False" BorderColor="#CC6699"
                                    BorderStyle="Groove" ForeColor="Red">
                                    <asp:ListItem Selected="True" Value="1">無</asp:ListItem>
                                    <asp:ListItem Value="2">心得未填寫</asp:ListItem>
                                    <asp:ListItem Value="3">問卷未填寫</asp:ListItem>
                                </asp:RadioButtonList>
            <asp:SqlDataSource ID="sdsCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT * FROM [trMailTemplate]"></asp:SqlDataSource>
                            </fieldset>
                        </div>
                        郵件
                        <telerik:RadComboBox ID="cbxMail" runat="server" DataSourceID="sdsCbx" DataTextField="sName"
                            DataValueField="iAutoKey">
                        </telerik:RadComboBox>
                        <telerik:RadButton ID="btnView" runat="server" Text="預覽" OnClick="btnSend_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnSend" runat="server" Text="寄送" OnClick="btnSend_Click">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />
    <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" Culture="zh-TW"
        GridLines="None" Skin="Office2007" AllowFilteringByColumn="True"
        AllowPaging="True" OnItemCreated="gv_ItemCreated" 
        AutoGenerateColumns="False" onneeddatasource="gv_NeedDataSource">
        <MasterTableView DataKeyNames="iAutoKey">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="dDateA" DataFormatString="{0:d}" 
                    FilterControlAltText="Filter dDateA column" HeaderText="開課日期" 
                    UniqueName="dDateA">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="catName" FilterControlAltText="Filter catName column"
                    HeaderText="階層" SortExpression="catName" UniqueName="catName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="courseCode" FilterControlAltText="Filter courseCode column"
                    HeaderText="課程代碼" SortExpression="courseCode" UniqueName="courseCode">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="courseName" FilterControlAltText="Filter courseName column"
                    HeaderText="課程名稱" SortExpression="courseName" UniqueName="courseName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="D_NO" FilterControlAltText="Filter D_NO column"
                    HeaderText="部門代碼" SortExpression="D_NO" UniqueName="D_NO" ReadOnly="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="D_NAME" FilterControlAltText="Filter D_NAME column"
                    HeaderText="部門" SortExpression="D_NAME" UniqueName="D_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NAME_C" FilterControlAltText="Filter NAME_C column"
                    HeaderText="姓名" SortExpression="NAME_C" UniqueName="NAME_C">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="iAutoKey" FilterControlAltText="Filter iAutoKey column"
                    UniqueName="iAutoKey" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="teacherName" 
                    FilterControlAltText="Filter column column" HeaderText="講師" UniqueName="column">
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
    <br />
    <asp:Panel ID="pnView" runat="server" Height="376px" Visible="False">
        <br />
        <table border="1" style="width: 100%; background-color: #EEF5FC;">
            <tr>
                <td>
                    信件標題
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMailSubject" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    信件內容
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMailBody" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
