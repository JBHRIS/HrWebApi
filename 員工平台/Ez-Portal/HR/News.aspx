<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="News.aspx.cs" Inherits="HR_News" Title="Untitled Page" ValidateRequest="false"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../Templet/SelectEmp3.ascx" TagName="SelectEmp3" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        /* this fixes the IE6/7 positioning bug */
        .RadGrid .rgDataDiv {
            position: relative;
        }
    </style>
    <h3>
        <asp:Label ID="lblPublishHeader" runat="server" Text="公佈資料維護" meta:resourcekey="lblPublishHeaderResource1"></asp:Label>
        <telerik:RadStyleSheetManager runat="server" ID="ssm">
        </telerik:RadStyleSheetManager>
    </h3>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <telerik:RadButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增">
        </telerik:RadButton>
        <asp:Panel ID="pnlDetail" runat="server" Visible="False">
            <telerik:RadTabStrip ID="ts" runat="server" MultiPageID="mp">
                <Tabs>
                    <telerik:RadTab runat="server" Text="公告內容" PageViewID="pv1">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="檔案上傳" PageViewID="pv2">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="發佈對象" PageViewID="pv3">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="mp" runat="server" Width="100%">
                <telerik:RadPageView ID="pv1" runat="server">
                    <div>
                        <asp:RadioButtonList ID="rblTargetType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">全體員工</asp:ListItem>
                            <asp:ListItem Value="0">特定對象</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <asp:Label ID="lblNewsShowAddID" runat="server" meta:resourcekey="lblNewsShowAddIDResource1"
                            Text="文號:"></asp:Label>
                        <asp:TextBox ID="news_idTextBox" runat="server" meta:resourcekey="news_idTextBoxResource1"></asp:TextBox>
                        截止日：<telerik:RadDateInput ID="rdiDeadLine" runat="server" Culture="Chinese (Taiwan)"
                            LabelCssClass="radLabelCss_Default" MaxDate="9999-12-31" Width="125px">
                        </telerik:RadDateInput>
                        <asp:CheckBox ID="ck_is_on" runat="server" Text="發佈" />
                        <telerik:RadButton ID="btnSendMail" runat="server" Text="發送mail" OnClick="btnSendMail_Click">
                        </telerik:RadButton>
                        <br />
                        <asp:Label ID="lblNewsShowAddTitle" runat="server" meta:resourcekey="lblNewsShowAddTitleResource1"
                            Text="主旨:"></asp:Label>
                        <asp:TextBox ID="news_headTextBox" runat="server" meta:resourcekey="news_headTextBoxResource2"
                            Width="430px"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblNewsShowAddContent" runat="server" meta:resourcekey="lblNewsShowAddContentResource1"
                        Text="內容:"></asp:Label>
                    <telerik:RadEditor ID="edt" runat="server" EditModes="Design, Preview" Width="100%"
                        BorderWidth="1px" EnableResize="False" ToolbarMode="ShowOnFocus" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                        CssClass="lineHeight" Height="200px">
                    </telerik:RadEditor>
                    <telerik:RadButton ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click">
                    </telerik:RadButton>
                </telerik:RadPageView>
                <telerik:RadPageView ID="pv2" runat="server">
                    <asp:Panel runat="server" ID="pnlUpload">
                        選擇檔案<telerik:RadAsyncUpload ID="up" runat="server">
                        </telerik:RadAsyncUpload>
                        檔案描述<telerik:RadTextBox ID="tbFileDesc" runat="server">
                        </telerik:RadTextBox>
                        <telerik:RadButton ID="btnUpload" runat="server" Text="上傳" OnClick="btnUpload_Click">
                        </telerik:RadButton>
                        <telerik:RadGrid ID="gvAttachment" runat="server" OnNeedDataSource="gvAttachment_NeedDataSource"
                            AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None"
                            OnItemCommand="gvAttachment_ItemCommand">
                            <MasterTableView DataKeyNames="AUTOKEY">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="AUTOKEY" FilterControlAltText="Filter AUTOKEY column"
                                        UniqueName="AUTOKEY" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="UPFILENAME" FilterControlAltText="Filter UPFILENAME column"
                                        HeaderText="檔案名稱" UniqueName="UPFILENAME">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FILEDESC" FilterControlAltText="Filter FILEDESC column"
                                        HeaderText="備註" UniqueName="FILEDESC">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FILESIZE" FilterControlAltText="Filter FILESIZE column"
                                        HeaderText="大小" UniqueName="FILESIZE">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn CommandName="cmdDel" ConfirmText="確認是否刪除" FilterControlAltText="Filter cmdDel column"
                                        Text="刪除" UniqueName="cmdDel">
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
                    </asp:Panel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="pv3" runat="server">
                    <telerik:RadButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="刪除所有選定部門人員">
                    </telerik:RadButton>
                    <telerik:RadGrid ID="gvTarget" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                        Culture="zh-TW" GridLines="None" AllowPaging="True" AllowSorting="True" OnItemCommand="gvTarget_ItemCommand"
                        OnNeedDataSource="gvTarget_NeedDataSource">
                        <MasterTableView AllowSorting="False" DataKeyNames="Id">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column column" UniqueName="Id"
                                    DataField="Id" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" UniqueName="Nobr"
                                    DataField="Nobr" HeaderText="工號">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" UniqueName="EmpName"
                                    DataField="EmpName" HeaderText="姓名">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                                    HeaderText="部門" UniqueName="DeptName">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="cmdDel" FilterControlAltText="Filter cmdDel column"
                                    Text="刪除" UniqueName="cmdDel">
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
                    <table width="100%">
                        <tr>
                            <td align="left" valign="top" width="50%">
                                <asp:Panel ID="pnlSelectDept" runat="server">
                                    <telerik:RadButton ID="btnAddDept" runat="server" Text="加入部門" OnClick="btnAddDept_Click">
                                    </telerik:RadButton>
                                    <telerik:RadTreeView ID="tvDept" runat="server" CheckBoxes="True" CheckChildNodes="True">
                                    </telerik:RadTreeView>
                                </asp:Panel>
                            </td>
                            <td align="left" valign="top" width="50%">
                                <asp:Panel ID="pnlSelectEmp" runat="server">
                                    <div>
                                        <telerik:RadButton ID="btnAddEmp" runat="server" Text="加入人員" OnClick="btnAddEmp_Click">
                                        </telerik:RadButton>
                                    </div>
                                    <uc1:SelectEmp3 ID="SelectEmp31" runat="server" />
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </asp:Panel>
        <telerik:RadGrid ID="gv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemCommand="gv_ItemCommand"
            OnNeedDataSource="gv_NeedDataSource" OnSelectedIndexChanged="gv_SelectedIndexChanged"
            PageSize="5" Skin="Office2010Blue">
            <MasterTableView DataKeyNames="news_id">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn ButtonType="PushButton" CommandName="Select" FilterControlAltText="Filter cmdSelect column"
                        Text="選取" UniqueName="cmdSelect">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="news_id" FilterControlAltText="Filter news_id column"
                        HeaderText="文號" UniqueName="news_id">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="news_head" FilterControlAltText="Filter news_head column"
                        HeaderText="主旨" UniqueName="news_head">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="news_body" FilterControlAltText="Filter news_body column"
                        HeaderText="內容" UniqueName="news_body">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="post_date" FilterControlAltText="Filter post_date column"
                        HeaderText="發佈日期" UniqueName="post_date" DataFormatString="{0:yyyy/MM/dd}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="post_deadline" FilterControlAltText="Filter post_deadline column"
                        HeaderText="截止日" UniqueName="post_deadline" DataFormatString="{0:yyyy/MM/dd}">
                    </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn DataField="is_on" FilterControlAltText="Filter is_on column"
                        HeaderText="發佈" UniqueName="is_on">
                    </telerik:GridCheckBoxColumn>
                    <telerik:GridBoundColumn DataField="AttachmentCount" FilterControlAltText="Filter filecount column"
                        HeaderText="附件筆數" UniqueName="AttachmentCount">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="newsfileid" FilterControlAltText="Filter newsfileid column"
                        HeaderText="newsfileid" UniqueName="newsfileid" Visible="False">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LatestSendMailDate" FilterControlAltText="Filter LatestSendMailDate column"
                        HeaderText="Mail寄送紀錄" UniqueName="LatestSendMailDate" DataFormatString="{0:d}">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="cmdUp" FilterControlAltText="Filter cmdUp column"
                        ImageUrl="~/Images/arrow-up16.png" UniqueName="cmdUp">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="cmdDown" FilterControlAltText="Filter cmdDown column"
                        ImageUrl="~/Images/arrow-down16.png" UniqueName="cmdDown">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn CommandName="cmdDelete" ConfirmText="確認是否刪除?" FilterControlAltText="Filter cmdDelete column"
                        Text="刪除" UniqueName="cmdDelete">
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
        <br />
        &nbsp;
        <asp:Label ID="lb_newsfileid" runat="server" Visible="False" meta:resourcekey="lb_newsfileidResource1"></asp:Label>
        <asp:Label ID="lblFormStatus" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
    </telerik:RadAjaxPanel>
</asp:Content>