<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="EmpAbsStatistics_hr.aspx.cs" Inherits="HR_Mang_EmpAbsStatistics_hr"
    Title="員工休假統計" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script language="javascript" type="text/javascript">
            function refreshGrid() {
                var masterTable = $find("<%=gvLeave.ClientID%>").get_masterTableView();
                masterTable.rebind();
            }

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including classic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                return oWindow;
            }
        </script>
    </telerik:RadCodeBlock>
    <div style="float: left; width: 1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
    </div>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
        HorizontalAlign="NotSet" meta:resourcekey="RadAjaxPanel1Resource1">
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="mp" SelectedIndex="0"
            meta:resourcekey="RadTabStrip1Resource1">
            <Tabs>
                <telerik:RadTab runat="server" PageViewID="pv1" Text="Leave records" Selected="True"
                    meta:resourcekey="RadTabResource1" Owner="">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pv2" Text="Entitlement/Balance" meta:resourcekey="RadTabResource2"
                    Owner="">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="mp" runat="server" Width="100%" SelectedIndex="0" meta:resourcekey="mpResource1">
            <telerik:RadPageView ID="pv1" runat="server" meta:resourcekey="pv1Resource1" Selected="True">
                <h3>
                    <asp:Label ID="lblShowEmpLeaveHeader" runat="server" Text="員工假單資料" meta:resourcekey="lblShowEmpLeaveHeaderResource1"></asp:Label></h3>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblShowQueryHeader" runat="server" Text="查詢條件" meta:resourcekey="lblShowQueryHeaderResource1"></asp:Label></legend>
                    <asp:Label ID="lblAbsDate" runat="server" Text="請假日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                    <telerik:RadDatePicker ID="dpDtlB" runat="server" Culture="(Default)" meta:resourcekey="dpDtlBResource1">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" DisplayText=""
                            LabelWidth="40%" type="text" value="" Width="">
                        </DateInput>
                        <DatePopupButton HoverImageUrl="" ImageUrl="" CssClass="" />
                    </telerik:RadDatePicker>
                    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="dpDtlB" ErrorMessage="日期格式錯誤！" meta:resourcekey="RequiredFieldValidator1Resource1"
                        ValidationGroup="group_date"></asp:RequiredFieldValidator>&nbsp;
                    <asp:Label ID="Label3" runat="server" meta:resourcekey="Label2Resource1" Text="至"></asp:Label>
                    <telerik:RadDatePicker ID="dpDtlE" runat="server" Culture="(Default)" meta:resourcekey="dpDtlEResource1">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" DisplayText=""
                            LabelWidth="40%" type="text" value="" Width="">
                        </DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" CssClass="" />
                    </telerik:RadDatePicker>
                    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="dpDtlE" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date"
                        meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator><br />
                    <asp:Button ID="Button2" runat="server" meta:resourcekey="Button1Resource2" OnClick="Button2_Click"
                        Text="查詢" ValidationGroup="group_date" /><asp:Button ID="Button3" runat="server"
                            meta:resourcekey="Button2Resource1" OnClick="Button2_Click" Text="匯出" /><asp:Label
                                ID="lb_nobr" runat="server" meta:resourcekey="lb_nobrResource1" Visible="False"></asp:Label></fieldset>
                <telerik:RadGrid ID="gvLeave" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                    Culture="(Default)" GridLines="None" OnItemDataBound="gvLeave_ItemDataBound"
                    OnItemCommand="gvLeave_ItemCommand" AllowPaging="True" OnNeedDataSource="gvLeave_NeedDataSource">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridButtonColumn CommandName="cmdViewUrl" FilterControlAltText="Filter ViewUrl column"
                                Text="Detail" UniqueName="cmdViewUrl" ButtonType="ImageButton" ImageUrl="~/Images/Zoom-icon.gif">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="cmdDel" 
                                ConfirmText="Delete ?" FilterControlAltText="Filter cmdDel column" 
                                ImageUrl="~/Images/Delete-icon.png" UniqueName="cmdDel">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                meta:resourcekey="GridBoundColumnResource1" UniqueName="Nobr" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NameC" FilterControlAltText="Filter NameC column"
                                HeaderText="員工" meta:resourcekey="GridBoundColumnResource2" UniqueName="NameC">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NameE" FilterControlAltText="Filter NameE column"
                                HeaderText="英文名" meta:resourcekey="GridBoundColumnResource3" UniqueName="NameE"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DateB" DataFormatString="{0:d}" FilterControlAltText="Filter DateB column"
                                HeaderText="請假起始日期" meta:resourcekey="GridBoundColumnResource4" UniqueName="DateB">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TimeB" FilterControlAltText="Filter TimeB column"
                                HeaderText="開始時間" meta:resourcekey="GridBoundColumnResource6" UniqueName="TimeB">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DateE" DataFormatString="{0:d}" FilterControlAltText="Filter DateE column"
                                HeaderText="請假結束日期" meta:resourcekey="GridBoundColumnResource5" UniqueName="DateE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TimeE" FilterControlAltText="Filter TimeE column"
                                HeaderText="結束時間" meta:resourcekey="GridBoundColumnResource7" UniqueName="TimeE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sHcode" FilterControlAltText="Filter sHcode column"
                                HeaderText="sHcode" meta:resourcekey="GridBoundColumnResource8" UniqueName="sHcode"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HcodeName" FilterControlAltText="Filter HcodeName column"
                                HeaderText="假別" meta:resourcekey="GridBoundColumnResource9" UniqueName="HcodeName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Unit" FilterControlAltText="Filter Unit column"
                                HeaderText="單位" meta:resourcekey="GridBoundColumnResource10" UniqueName="Unit">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalHour" FilterControlAltText="Filter TotalHour column"
                                HeaderText="請假小計" meta:resourcekey="GridBoundColumnResource11" UniqueName="TotalHour">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalDay" FilterControlAltText="Filter TotalDay column"
                                HeaderText="請假天數" meta:resourcekey="GridBoundColumnResource12" UniqueName="TotalDay"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="YYMM" FilterControlAltText="Filter YYMM column"
                                HeaderText="計薪年月" meta:resourcekey="GridBoundColumnResource14" UniqueName="YYMM">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="State" FilterControlAltText="Filter State column"
                                HeaderText="狀態" meta:resourcekey="GridBoundColumnResource15" UniqueName="State">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Approver" FilterControlAltText="Filter Approver column"
                                HeaderText="Approver" meta:resourcekey="GridBoundColumnResource16" UniqueName="Approver">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ViewUrl" FilterControlAltText="Filter ViewUrl column"
                                HeaderText="ViewUrl" UniqueName="ViewUrl" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Note" FilterControlAltText="Filter Note column"
                                HeaderText="備註" meta:resourcekey="GridBoundColumnResource13" UniqueName="Note">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ProcessID" 
                                FilterControlAltText="Filter ProcessID column" HeaderText="ProcessID" 
                                UniqueName="ProcessID" Visible="False">
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
                <asp:Label ID="lb_dept" runat="server" meta:resourceKey="lb_deptResource1" Visible="False"></asp:Label>
                <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                    SelectCommand="SELECT NOBR, NAME_C,NAME_AD, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </telerik:RadPageView>
            <telerik:RadPageView ID="pv2" runat="server" meta:resourcekey="pv2Resource1">
                <h3>
                    <asp:Label ID="lblShowHeader" runat="server" Text="休假統計表" meta:resourcekey="lblShowHeaderResource1"></asp:Label></h3>
                <fieldset>
                    <legend>
                        <asp:Label ID="lblShowInquiryCondition" runat="server" Text="資料查詢" meta:resourcekey="lblShowInquiryConditionResource1"></asp:Label></legend>
                    <div style="width: 100%;">
                        <div style="float: left; padding-right: 20px;">
                            Employee No.:<asp:Label ID="lblNobr" runat="server" meta:resourcekey="lblNobrResource1"></asp:Label></div>
                        <div style="float: left; width=150px;">
                            Name:
                            <asp:Label ID="lblName" runat="server" meta:resourcekey="lblNameResource1"></asp:Label></div>
                    </div>
                    <asp:Label ID="lblYear" runat="server" Text="年度選擇：" meta:resourcekey="lblYearResource1"
                        Visible="False"></asp:Label><telerik:RadComboBox ID="RadComboBox1" runat="server"
                            AutoPostBack="True" Culture="zh-TW" meta:resourcekey="cbxYearResource1" Visible="False">
                        </telerik:RadComboBox>
                </fieldset>
                <br />
                <asp:GridView ID="gv" runat="server" SkinID="Yahoo" AllowPaging="True" AllowSorting="True"
                    meta:resourcekey="GridView2Resource1" AutoGenerateColumns="False" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="NOBR" HeaderText="工號" meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="NAME_C" HeaderText="姓名" meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="DI" HeaderText="直間接" Visible="False" meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="INDT" HeaderText="到職日" Visible="False" meta:resourcekey="BoundFieldResource4" />
                        <asp:BoundField DataField="GET_HOURS" HeaderText="特休應休" meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="FullHours1" HeaderText="特休已休" meta:resourcekey="BoundFieldResource6" />
                        <asp:BoundField DataField="LEAVE_HOURS" HeaderText="特休未休" meta:resourcekey="BoundFieldResource7" />
                        <asp:BoundField DataField="ABS_HOURS" HeaderText="其他已休" meta:resourcekey="BoundFieldResource8" />
                        <asp:BoundField DataField="TOL_HOURS" HeaderText="剩餘可休" meta:resourcekey="BoundFieldResource9" />
                        <asp:BoundField DataField="FullHours2" HeaderText="事假" meta:resourcekey="BoundFieldResource10" />
                        <asp:BoundField DataField="FullHours3" HeaderText="家庭照顧假" meta:resourcekey="BoundFieldResource11" />
                        <asp:BoundField DataField="HalfHours1" HeaderText="病假" meta:resourcekey="BoundFieldResource12" />
                        <asp:BoundField DataField="FullHours6" HeaderText="無薪病假" meta:resourcekey="BoundFieldResource13" />
                        <asp:BoundField DataField="HalfHours2" HeaderText="生理假" meta:resourcekey="BoundFieldResource14" />
                        <asp:BoundField DataField="FullHours4" HeaderText="無薪假" meta:resourcekey="BoundFieldResource15" />
                        <asp:BoundField DataField="FullHours5" HeaderText="曠職" meta:resourcekey="BoundFieldResource16" />
                        <asp:BoundField DataField="TOL_HOURS" HeaderText="剩餘時數" Visible="False" meta:resourcekey="BoundFieldResource17" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                            meta:resourcekey="lb_emptyResource1"></asp:Label></EmptyDataTemplate>
                </asp:GridView>
                <br />
                <asp:GridView ID="gv2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    meta:resourcekey="GridView2Resource1" SkinID="Yahoo" Width="70%">
                    <Columns>
                        <asp:BoundField DataField="HName" HeaderText="Leave Type" meta:resourcekey="BoundFieldResource27">
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BeginDateString" HeaderText="From" meta:resourcekey="BoundFieldResource33">
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EndDateString" HeaderText="To" meta:resourcekey="BoundFieldResource34">
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GetHrsDisp" HeaderText="Entitled" meta:resourcekey="BoundFieldResource28">
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AuthorizedHrsDisp" HeaderText="Taken" meta:resourcekey="BoundFieldResource29">
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Balance" meta:resourcekey="BoundFieldResource30" DataField="BalanceHrsDisp">
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UnitDisp" HeaderText="Unit" meta:resourcekey="BoundFieldResource31">
                            <HeaderStyle Font-Size="Small" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lb_empty0" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" meta:resourcekey="lb_emptyResource1"
                            Text="＊無相關資料！！"></asp:Label></EmptyDataTemplate>
                </asp:GridView>
                <br />
            </telerik:RadPageView>
        </telerik:RadMultiPage>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Style="z-index: 7001"
            Left="100px" Top="100px">
            <Windows>
                <telerik:RadWindow ID="win" runat="server" EnableShadow="True" Height="600px" Modal="True"
                    VisibleStatusbar="True" Width="900px" Left="100px" Top="100px" OnClientClose="refreshGrid">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
