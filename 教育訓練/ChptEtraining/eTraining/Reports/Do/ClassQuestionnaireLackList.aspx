<%@ Page Title="心得缺繳統計一覽表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="ClassQuestionnaireLackList.aspx.cs" Inherits="eTraining_Reports_Do_ClassQuestionnaireLackList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        出席-問卷缺繳統計一覽表</h2>
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
                        <telerik:RadComboBox ID="cbType" runat="server" Culture="zh-TW" 
                            onselectedindexchanged="cbType_SelectedIndexChanged" AutoPostBack="True" 
                            onload="cbType_Load">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Checked="True" Text="講師" Value="T" 
                                    Owner="cbType" />
                                <telerik:RadComboBoxItem runat="server" Text="學員" Value="S" Owner="cbType" />
                                <telerik:RadComboBoxItem runat="server" Text="組訓員" Value="M" />
                                <telerik:RadComboBoxItem runat="server" Text="自訂人員" Value="CU" />
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
                                <asp:RadioButtonList ID="rbl" runat="server" Font-Size="Small" Width="200px"
                                    OnSelectedIndexChanged="rbl_SelectedIndexChanged">
                                    <asp:ListItem Value="3">清單中學員</asp:ListItem>
                                    <asp:ListItem Value="4">清單中學員及該部門主管</asp:ListItem>
                                    <asp:ListItem Value="5">清單中學員及上層主管</asp:ListItem>
                                    <asp:ListItem Value="6">清單中學員及上兩層主管</asp:ListItem>
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
        GridLines="None" Skin="Office2007" 
        AllowFilteringByColumn="True" AllowPaging="True" 
        onitemcreated="gv_ItemCreated" onneeddatasource="gv_NeedDataSource" 
        AutoGenerateColumns="False" PageSize="25">
        <MasterTableView DataKeyNames="AutoKey">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="CourseDateB" DataFormatString="{0:d}" 
                    FilterControlAltText="Filter courseAdate column" HeaderText="上課日期" 
                    UniqueName="CourseDateB">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CourseCate" FilterControlAltText="Filter catName column"
                    HeaderText="階層" SortExpression="catName" UniqueName="CourseCate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CourseCode" FilterControlAltText="Filter courseCode column"
                    HeaderText="課程代碼" SortExpression="courseCode" UniqueName="CourseCode">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter courseName column"
                    HeaderText="課程名稱" SortExpression="courseName" UniqueName="CourseName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DeptCode" FilterControlAltText="Filter D_NO column"
                    HeaderText="部門代碼" SortExpression="D_NO" UniqueName="DeptCode" 
                    ReadOnly="True">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter D_NAME column"
                    HeaderText="部門" SortExpression="D_NAME" UniqueName="DeptName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter NAME_C column"
                    HeaderText="姓名" SortExpression="NAME_C" UniqueName="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AutoKey" 
                    FilterControlAltText="Filter iAutoKey column" UniqueName="AutoKey" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Nobr" 
                    FilterControlAltText="Filter Nobr column" UniqueName="Nobr" Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ClassId" 
                    FilterControlAltText="Filter ClassId column" UniqueName="ClassId" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TeacherCode" 
                    FilterControlAltText="Filter TeacherCode column" UniqueName="TeacherCode" 
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
