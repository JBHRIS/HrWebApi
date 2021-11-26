<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpApplyUpdateBase_hr.aspx.cs" Inherits="HR_Mang_EmpWorkHours_hr" Title="員工修改通訊資料查詢"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
            Skin="Hay" OnTabClick="RadTabStrip1_TabClick" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" Owner="RadTabStrip1" PageViewID="RadPageView1" Selected="True"
                    Text="員工通訊資料">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Owner="RadTabStrip1" PageViewID="RadPageView2" Text="設定通知">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" RenderSelectedPageOnly="True"
            Width="100%" SelectedIndex="0">
            <telerik:RadPageView ID="RadPageView1" runat="server">
                <table width="100%">
                    <tr>
                        <td valign="top">
                            <div class="SilverForm">
                                <div class="SilverFormHeader">
                                    <span class="SHLeft"></span><span class="SHeader">
                                        <asp:Label ID="lblHeader" runat="server" Text="申請更新員工通訊資料" meta:resourcekey="lblWorkHourResource1"></asp:Label></span>
                                    <span class="SHRight"></span>
                                </div>
                                <div class="SilverFormContent">
                                    <fieldset>
                                        <legend>
                                            <asp:Label ID="lblSearch" runat="server" Text="查詢條件" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                                        <asp:Label ID="Label1" runat="server" Text="日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                                        <telerik:RadDatePicker ID="adate" runat="server"  meta:resourcekey="adateResource1">
                                            </telerik:RadDatePicker>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                                            ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                                        <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                                        <telerik:RadDatePicker ID="ddate" runat="server"  meta:resourcekey="ddateResource1">
</telerik:RadDatePicker>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                                            ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                                        <asp:CheckBox ID="cbIsProcessed" runat="server" Text="顯示已處理" />
                                        <br />
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                                            meta:resourcekey="Button1Resource1" />&nbsp;<asp:Button ID="ExportExcel" runat="server"
                                                OnClick="ExportExcel_Click" Text="匯出Excel" meta:resourcekey="ExportExcelResource1"
                                                Visible="False" />
                                        <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                                        <br />
                                        <telerik:RadGrid ID="gv" runat="server" OnNeedDataSource="gv_NeedDataSource" AutoGenerateColumns="False"
                                            CellSpacing="0" Culture="zh-TW" GridLines="None" OnItemDataBound="gv_ItemDataBound"
                                            OnItemCommand="gv_ItemCommand" OnDetailTableDataBind="gv_DetailTableDataBind"
                                            Skin="Office2010Black">
                                            <MasterTableView DataKeyNames="Pk" HierarchyDefaultExpanded="True" BorderStyle="Double"
                                                GridLines="Both">
                                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                                    <HeaderStyle Width="20px"></HeaderStyle>
                                                </RowIndicatorColumn>
                                                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                                    <HeaderStyle Width="20px"></HeaderStyle>
                                                </ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridTemplateColumn FilterControlAltText="Filter ApproveItem column" UniqueName="ApproveItem">
                                                        <ItemTemplate>
                                                            <telerik:RadButton ID="btnApprove" runat="server" CommandName="Approve" Text="核准">
                                                            </telerik:RadButton>
                                                            <telerik:RadButton ID="btnUnapprove" runat="server" CommandName="Unapprove" Text="不核准">
                                                            </telerik:RadButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn FilterControlAltText="Filter column column" UniqueName="ApplyDatetime"
                                                        DataField="ApplyDatetime" DataFormatString="{0:d}" HeaderText="申請日期">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridCheckBoxColumn DataField="Approve" FilterControlAltText="Filter Approve column"
                                                        HeaderText="核准" UniqueName="Approve">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridBoundColumn DataField="ApproveMan" EmptyDataText="" FilterControlAltText="Filter ApproveMan column"
                                                        UniqueName="ApproveMan" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ApplyMan" FilterControlAltText="Filter ApplyMan column"
                                                        HeaderText="工號" UniqueName="ApplyMan" EmptyDataText="">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Name_c" FilterControlAltText="Filter Name_c column"
                                                        HeaderText="姓名" UniqueName="Name_c">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="SUBTEL" FilterControlAltText="Filter SUBTEL column"
                                                        HeaderText="公司分機" UniqueName="SUBTEL">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="GSM" FilterControlAltText="Filter GSM column"
                                                        HeaderText="手機" UniqueName="GSM">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="EMAIL" FilterControlAltText="Filter EMAIL column"
                                                        HeaderText="EMAIL" UniqueName="EMAIL" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="TEL1" FilterControlAltText="Filter TEL1 column"
                                                        HeaderText="通訊電話" UniqueName="TEL1">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="TEL2" FilterControlAltText="Filter TEL2 column"
                                                        HeaderText="戶籍電話" UniqueName="TEL2">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="POSTCODE1" FilterControlAltText="Filter POSTCODE1 column"
                                                        HeaderText="戶籍郵政區號" UniqueName="POSTCODE1">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ADDR1" FilterControlAltText="Filter ADDR1 column"
                                                        HeaderText="通訊地址" UniqueName="ADDR1">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="POSTCODE2" FilterControlAltText="Filter POSTCODE2 column"
                                                        HeaderText="通訊地址區號" UniqueName="POSTCODE2">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="ADDR2" FilterControlAltText="Filter ADDR2 column"
                                                        HeaderText="戶籍地址" UniqueName="ADDR2">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PROVINCE" FilterControlAltText="Filter PROVINCE column"
                                                        HeaderText="戶籍地" UniqueName="PROVINCE">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="BORN_ADDR" FilterControlAltText="Filter BORN_ADDR column"
                                                        HeaderText="出生地" UniqueName="BORN_ADDR" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_MAN" FilterControlAltText="Filter CONT_MAN column"
                                                        HeaderText="聯絡人1" UniqueName="CONT_MAN">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_REL1" FilterControlAltText="Filter CONT_REL1 column"
                                                        HeaderText="聯絡人1關係" UniqueName="CONT_REL1" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_REL1_NAME" FilterControlAltText="Filter CONT_REL1_NAME column"
                                                        HeaderText="聯絡人1關係名稱" UniqueName="CONT_REL1_NAME">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_TEL" FilterControlAltText="Filter CONT_TEL column"
                                                        HeaderText="聯絡人1電話" UniqueName="CONT_TEL">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_GSM" FilterControlAltText="Filter CONT_GSM column"
                                                        HeaderText="聯絡人1手機" UniqueName="CONT_GSM">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_MAN2" FilterControlAltText="Filter CONT_MAN2 column"
                                                        HeaderText="聯絡人2" UniqueName="CONT_MAN2" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_REL2" FilterControlAltText="Filter CONT_REL2 column"
                                                        HeaderText="聯絡人2關係" UniqueName="CONT_REL2" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_REL2_NAME" FilterControlAltText="Filter CONT_REL2_NAME column"
                                                        HeaderText="聯絡人2關係名稱" UniqueName="CONT_REL2_NAME" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_TEL2" FilterControlAltText="Filter CONT_TEL2 column"
                                                        HeaderText="聯絡人2電話" UniqueName="CONT_TEL2" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CONT_GSM2" FilterControlAltText="Filter CONT_GSM2 column"
                                                        HeaderText="聯絡人2手機" UniqueName="CONT_GSM2" Visible="False">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridCheckBoxColumn DataField="GSM_IsChanged" FilterControlAltText="Filter GSM_IsChanged column"
                                                        UniqueName="GSM_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="EMAIL_IsChanged" FilterControlAltText="Filter EMAIL_IsChanged column"
                                                        UniqueName="EMAIL_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="TEL1_IsChanged" FilterControlAltText="Filter TEL1_IsChanged column"
                                                        UniqueName="TEL1_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="TEL2_IsChanged" FilterControlAltText="Filter TEL2_IsChanged column"
                                                        UniqueName="TEL2_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="POSTCODE1_IsChanged" FilterControlAltText="Filter POSTCODE1_IsChanged column"
                                                        UniqueName="POSTCODE1_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="ADDR1_IsChanged" FilterControlAltText="Filter ADDR1_IsChanged column" 
                                                        UniqueName="ADDR1_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="POSTCODE2_IsChanged" FilterControlAltText="Filter POSTCODE2_IsChanged column"
                                                        UniqueName="POSTCODE2_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="ADDR2_IsChanged" FilterControlAltText="Filter ADDR2_IsChanged column"
                                                        UniqueName="ADDR2_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="PROVINCE_IsChanged" FilterControlAltText="Filter PROVINCE_IsChanged column"
                                                        UniqueName="PROVINCE_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="BORN_ADDR_IsChanged" FilterControlAltText="Filter BORN_ADDR_IsChanged column"
                                                        UniqueName="BORN_ADDR_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="CONT_MAN_IsChanged" FilterControlAltText="Filter CONT_MAN_IsChanged column"
                                                        UniqueName="CONT_MAN_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="CONT_REL1_IsChanged" FilterControlAltText="Filter CONT_REL1_IsChanged column"
                                                        UniqueName="CONT_REL1_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="CONT_TEL_IsChanged" FilterControlAltText="Filter CONT_TEL_IsChanged column"
                                                        UniqueName="CONT_TEL_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="CONT_GSM_IsChanged" FilterControlAltText="Filter CONT_GSM_IsChanged column"
                                                        UniqueName="CONT_GSM_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="CONT_MAN2_IsChanged" FilterControlAltText="Filter CONT_MAN2_IsChanged column"
                                                        UniqueName="CONT_MAN2_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="CONT_REL2_IsChanged" FilterControlAltText="Filter CONT_REL2_IsChanged column"
                                                        UniqueName="CONT_REL2_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="CONT_TEL2_IsChanged" FilterControlAltText="Filter CONT_TEL2_IsChanged column"
                                                        UniqueName="CONT_TEL2_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="CONT_GSM2_IsChanged" FilterControlAltText="Filter CONT_GSM2_IsChanged column"
                                                        UniqueName="CONT_GSM2_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridCheckBoxColumn DataField="SUBTEL_IsChanged" FilterControlAltText="Filter SUBTEL_IsChanged column"
                                                        UniqueName="SUBTEL_IsChanged" Visible="False">
                                                    </telerik:GridCheckBoxColumn>
                                                    <telerik:GridBoundColumn DataField="Pk" FilterControlAltText="Filter Pk column" UniqueName="Pk"
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
                                        </telerik:RadGrid>
                                        <br />
                                    </fieldset>
                                </div>
                                <div class="SilverFormFooter">
                                    <span class="SFLeft"></span><span class="SFRight"></span>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server">
                <table>
                    <tr>
                        <td>
                            資料群組代碼
                        </td>
                        <td>
                            <telerik:RadComboBox ID="dgCbx" runat="server" DataTextField="GROUPNAME" DataValueField="DATAGROUP1">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                    <td>
                    通知工號
                    </td>
                    <td>
                        <telerik:RadTextBox ID="tbNobr" runat="server">
                        </telerik:RadTextBox>
                        <telerik:RadButton ID="addBtn" runat="server" onclick="addBtn_Click" Text="新增">
                        </telerik:RadButton>
                    </td>
                    </tr>
                </table>
                <telerik:RadGrid ID="gvNotify" runat="server" AutoGenerateColumns="False" 
                    CellSpacing="0" Culture="zh-TW" GridLines="None" 
                    onitemcommand="gvNotify_ItemCommand" onneeddatasource="gvNotify_NeedDataSource">
                    <MasterTableView DataKeyNames="Id">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                            Visible="True">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                            Visible="True">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="DpName" 
                                FilterControlAltText="Filter DpName column" HeaderText="資料群組" 
                                UniqueName="DpName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Nobr" 
                                FilterControlAltText="Filter Nobr column" HeaderText="工號" UniqueName="Nobr">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" 
                                FilterControlAltText="Filter Name column" HeaderText="姓名" UniqueName="Name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Email" 
                                FilterControlAltText="Filter Email column" HeaderText="Email" 
                                UniqueName="Email">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="Del" 
                                FilterControlAltText="Filter Del column" Text="刪除" UniqueName="Del">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" 
                                UniqueName="Id" Visible="False">
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
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </telerik:RadAjaxPanel>
</asp:Content>
