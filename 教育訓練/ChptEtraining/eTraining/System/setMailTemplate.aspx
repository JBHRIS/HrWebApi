<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="setMailTemplate.aspx.cs" Inherits="eTraining_System_setMailTemplate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../UC/MailVariables.ascx" TagName="MailVariables" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <h2>
        郵件範本設定
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <asp:Label runat="server" ID="lblAutoKey" Visible="False"></asp:Label>
        <asp:Label ID="lblMode" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Panel ID="pnView" runat="server">
            <telerik:RadButton ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click">
            </telerik:RadButton>
            <telerik:RadGrid ID="gv" runat="server" CellSpacing="0" DataSourceID="sdsGv" GridLines="None"
                OnItemCommand="gv_ItemCommand" Culture="zh-TW" Skin="Vista">
                <MasterTableView AllowAutomaticDeletes="True" AutoGenerateColumns="False" DataKeyNames="iAutoKey"
                    DataSourceID="sdsGv">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn CommandName="Select" FilterControlAltText="Filter column column"
                            Text="選擇" UniqueName="column">
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="sName" FilterControlAltText="Filter sName column"
                            HeaderText="範本名稱" SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sMailSubject" FilterControlAltText="Filter sMailSubject column"
                            HeaderText="信件標題" SortExpression="sMailSubject" UniqueName="sMailSubject">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sMailContent" FilterControlAltText="Filter sMailContent column"
                            HeaderText="sMailContent" SortExpression="sMailContent" UniqueName="sMailContent"
                            Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyMan" FilterControlAltText="Filter dKeyMan column"
                            HeaderText="dKeyMan" SortExpression="dKeyMan" UniqueName="dKeyMan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" FilterControlAltText="Filter dKeyDate column"
                            HeaderText="dKeyDate" SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" FilterControlAltText="Filter column1 column"
                            UniqueName="column1">
                        </telerik:GridButtonColumn>
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
            <asp:SqlDataSource ID="sdsGv" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                DeleteCommand="delete  [trMailTemplate] where iAutoKey=@iAutoKey" SelectCommand="SELECT * FROM [trMailTemplate]">
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" />
                </DeleteParameters>
            </asp:SqlDataSource>
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="pnEdit" runat="server">
            範本名稱<telerik:RadTextBox ID="tbName" runat="server">
            </telerik:RadTextBox>
            <br />
            郵件標題<telerik:RadTextBox ID="tbSubject" runat="server" Width="400px">
            </telerik:RadTextBox>
            <br />
            郵件內容<br />
            <telerik:RadEditor ID="edt" runat="server" 
                ToolsFile="~/Editor/RadEditor/BasicTools.xml">
            </telerik:RadEditor>
            <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="存檔"
                Style="top: 0px; left: 0px">
            </telerik:RadButton>
            <telerik:RadButton ID="btnClear" runat="server" OnClick="btnClear_Click" Text="清除">
            </telerik:RadButton>
            <br />
        </asp:Panel>
        <table width="100%">
            <tr>
                <td style="width: 50%" align="left" valign="top">
                    <uc1:MailVariables ID="MailVariables1" runat="server" />
                </td>
                <td style="width: 50%" align="left" valign="top">
                    <telerik:RadGrid ID="gvNotifyCustomVariable" runat="server" AutoGenerateColumns="False"
                        CellSpacing="0" Culture="zh-TW" GridLines="None" OnNeedDataSource="gvNotifyCustomVariable_NeedDataSource"
                        AutoGenerateDeleteColumn="True" DataSourceID="LinqDataSource1" OnEditCommand="gvNotifyCustomVariable_EditCommand"
                        OnItemUpdated="gvNotifyCustomVariable_ItemUpdated" 
                        onselectedindexchanged="gvNotifyCustomVariable_SelectedIndexChanged">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView AllowAutomaticDeletes="True" AllowAutomaticInserts="True" AllowAutomaticUpdates="True"
                            DataKeyNames="Code" DataSourceID="LinqDataSource1">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridButtonColumn CommandName="Select" 
                                    FilterControlAltText="Filter Select column" Text="選擇" UniqueName="Select">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="Code" 
                                    FilterControlAltText="Filter Code column" HeaderText="代碼" ReadOnly="True" 
                                    UniqueName="Code">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Text" 
                                    FilterControlAltText="Filter Text column" HeaderText="替換文字" UniqueName="Text">
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
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="dcTrainingDataContext"
                        EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName=""
                        TableName="NotifyCustomVariable">
                    </asp:LinqDataSource>
                    <br />
                    <table width="100%" border="1px">
                        <tr>
                            <td align="left" valign="top">
                                代碼
                            </td>
                            <td>
                                <telerik:RadTextBox ID="tbCode" runat="server">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:20%" align="left" valign="top">
                                替換文字
                            </td>
                            <td style="width:80%">
                                <telerik:RadEditor ID="edt2" runat="server" Height="250px"
                                    Width="100%" Skin="Office2007" 
                                    ToolsFile="~/Editor/RadEditor/BasicTools.xml">
                                </telerik:RadEditor>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" valign="top">
                                <telerik:RadButton ID="RadButton1" runat="server" Text="新增" OnClick="RadButton1_Click">
                                </telerik:RadButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </telerik:RadAjaxPanel>
</asp:Content>
