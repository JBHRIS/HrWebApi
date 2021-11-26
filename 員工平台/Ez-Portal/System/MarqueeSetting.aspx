<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MarqueeSetting.aspx.cs" Inherits="System_MarqueeSetting" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxPanel1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
                <div style="float: left;width: 1000px">
            <asp:Panel ID="pnlAddForm" runat="server" Visible="false">
                <table>
                    <tr>
                        <td>
                            顯示文字
                        </td>
                        <td>
                            <telerik:RadEditor ID="etDisplayText" Runat="server" 
                                EditModes="Design, Preview" Height="200px" 
                                ToolsFile="~/Editor/RadEditor/BasicTools.xml" Width="500px">
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Label ID="起" runat="server" Text="起"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDateTimePicker ID="dpB" Runat="server" Skin="Default" Width="300px">
                                                              <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                        LabelWidth="40%" type="text" value=""  AutoPostBack="True">
                                    </DateInput>
                        </telerik:RadDateTimePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="dpB" ErrorMessage="RequiredFieldValidator" ForeColor="Red"
                            ValidationGroup="a">*必填</asp:RequiredFieldValidator>
                    </td>
                    </tr>
                                        <tr>
                    <td>
                        <asp:Label ID="迄" runat="server" Text="迄"></asp:Label>
                    </td>
                    <td>
                                                <telerik:RadDateTimePicker ID="dpE" Runat="server" Skin="Default" Width="300px">
                                                                                      <DateInput DateFormat="yyyy/M/d HH:mm" DisplayDateFormat="yyyy/M/d HH:mm" DisplayText=""
                                        LabelWidth="40%" type="text" value=""  AutoPostBack="True">
                                    </DateInput>
                        </telerik:RadDateTimePicker>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="dpE" ErrorMessage="RequiredFieldValidator" ForeColor="Red"
                            ValidationGroup="a">*必填</asp:RequiredFieldValidator>
                    </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click"
                                ValidationGroup="a">
                            </telerik:RadButton>
                            <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblFormMode" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadButton ID="btnCancel" runat="server" Text="取消"
                                OnClick="btnCancel_Click">
                            </telerik:RadButton>
                            <asp:CheckBox ID="cbEnable" runat="server" Checked="True" Visible="False" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div style="float: left; width: 1000px">
            <telerik:RadButton ID="btnNew" runat="server" Text="新增" OnClick="btnNew_Click"
                style="top: 0px; left: 0px">
            </telerik:RadButton>
            <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                Culture="zh-TW" GridLines="None" OnItemCommand="gv_ItemCommand" OnNeedDataSource="gv_NeedDataSource">
                <MasterTableView DataKeyNames="ID">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn CommandName="Edt" FilterControlAltText="Filter cmdEdit column"
                            Text="Edit" UniqueName="cmdEdit">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="DisplayText" FilterControlAltText="Filter DisplayText column"
                            HeaderText="顯示文字" UniqueName="DisplayText">
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="Enable" DataType="System.Boolean"
                            FilterControlAltText="Filter Enable column" HeaderText="生效" UniqueName="Enable">
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="ID" FilterControlAltText="Filter Id column"
                            HeaderText="ID" UniqueName="ID" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn CommandName="Del" ConfirmText="Delete item?" FilterControlAltText="Filter cmdDel column"
                            Text="Delete" UniqueName="cmdDel">
                        </telerik:GridButtonColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>