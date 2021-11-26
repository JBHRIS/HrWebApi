<%@ Page Title="心得缺繳統計一覽表" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="StudentScoreLost.aspx.cs" Inherits="eTraining_Reports_Do_StudentScoreLost" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
.RadComboBox_Default{font:12px "Segoe UI",Arial,sans-serif;color:#333}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox *{margin:0;padding:0}.RadComboBox_Default .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{font:12px "Segoe UI",Arial,sans-serif;color:#333}.RadComboBox .rcbInput{text-align:left}.RadComboBox_Default .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI, Version=2012.2.607.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.ComboBox.rcbSprite.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        出席-學員評分未填寫一覽表</h2>
    <div class="field">
        <fieldset style="background-color: #EEF5FC; width: 600px">
            <legend>篩選條件</legend>
            <table style="width: 100%;">
                <tr>
                    <td>
                        時間起                        <telerik:RadDatePicker ID="rdpAdate" runat="server">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdpAdate"
                            Display="Dynamic" ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                            <br />
                            時間迄
                                                    <telerik:RadDatePicker ID="rdpDdate" runat="server">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpDdate"
                            Display="Dynamic" ErrorMessage="*必填欄位" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        <br />
                                        <telerik:RadButton ID="btnSearch" runat="server" 
                            OnClick="btnSearch_Click" Text="查詢">
            </telerik:RadButton>
            
    <telerik:RadButton ID="btnExportExcel" runat="server" Text="匯出Excel" OnClick="btnExportExcel_Click"
                ValidationGroup="g">
            </telerik:RadButton>
                    </td>
                    <td>

                                <asp:RadioButtonList ID="rbl" runat="server" Font-Size="Small" 
                            Width="200px" AutoPostBack="True">
                                    <asp:ListItem Value="1">講師</asp:ListItem>
                                </asp:RadioButtonList>
            <asp:SqlDataSource ID="sdsCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT * FROM [trMailTemplate]"></asp:SqlDataSource>
                        郵件<telerik:RadComboBox ID="cbxMail" runat="server" DataSourceID="sdsCbx" DataTextField="sName"
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
        GridLines="None" Skin="Office2007" Visible="False" 
        AllowFilteringByColumn="True" AllowPaging="True" 
        onitemcreated="gv_ItemCreated" onneeddatasource="gv_NeedDataSource" 
        AutoGenerateColumns="False">
        <MasterTableView DataKeyNames="iAutoKey" 
            PageSize="20">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="courseAdate" DataFormatString="{0:d}" 
                    FilterControlAltText="Filter courseAdate column" HeaderText="上課日期" 
                    UniqueName="courseAdate">
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
                <telerik:GridBoundColumn DataField="iAutoKey" 
                    FilterControlAltText="Filter iAutoKey column" UniqueName="iAutoKey" 
                    Visible="False">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="teacherName" 
                    FilterControlAltText="Filter teacherName column" HeaderText="講師" 
                    UniqueName="teacherName">
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
