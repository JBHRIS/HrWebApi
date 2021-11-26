<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpDeptQS.ascx.cs" Inherits="Templet_EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadStyleSheetManager runat="server" ID="ssm">
</telerik:RadStyleSheetManager>
<%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%"
    HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" 
    meta:resourcekey="RadAjaxPanel1Resource1">--%>
<script type="text/javascript">
    var MIN_TEXTLENGTH = 2;

    function OnValueChanged(sender, eventArgs) {

        if (eventArgs.get_newValue().length >= MIN_TEXTLENGTH) {
            try {
                var btn = $find("<%= btnSearch.ClientID %>");
                btn.click();
            }
            catch (err) {
                __doPostBack('btnSearch', '');
            }
        }
    }

    function OnValueChanging(sender, eventArgs) {
        if (eventArgs.get_newValue().length >= MIN_TEXTLENGTH) {
            try {
                var btn = $find("<%= btnSearch.ClientID %>");
                btn.click();
            }
            catch (err) {
                __doPostBack('btnSearch', '');
            }
        }
    }
    function KeyDown(e) {
        if (e.keyCode == 13) 
        {
            try {
                var btn = $find("<%= btnSearch.ClientID %>");
                btn.click();
            }
            catch (err) {
                __doPostBack('btnSearch', '');
            }
        }
    }

    function Blur(sender, eventArgs) {
        try {
            var btn = $find("<%= btnSearch.ClientID %>");
            btn.click();
        }
        catch (err) {
            __doPostBack('btnSearch', '');
        }
    }

    function OnKeyPress(sender, eventArgs) {
        var c = eventArgs.get_keyCode();
        if (c == 13) {
            try {
                var btn = $find("<%= btnSearch.ClientID %>");
                btn.click();
            }
            catch (err) {
                __doPostBack('btnSearch', '');
            }
        }


        //        var tb = $find("<%=tbQuickSearch.ClientID %>");
        //        var test = eventArgs.get_keyCharacter();
        //        var v = "";
        //        if (tb.get_textBoxValue() == undefined)
        //            v = test;
        //        else
        //            v = tb.get_textBoxValue() + test;
        //        //tb.set_value(v);
        //        //tb.value = v;
        //        //if (tb.value.length >= MIN_TEXTLENGTH) {
        //        if (v.length >= MIN_TEXTLENGTH) {
        //            try {
        //                var btn = $find("<%= btnSearch.ClientID %>");                
        //                btn.click();                                
        //            }
        //            catch (err) {
        //                __doPostBack('btnSearch', '');
        //            } 
        //            
        //        }
    }
</script>
<fieldset>
    <table width="100%">
        <tr>
            <td width="300px" valign="top">
                <asp:Panel ID="pnlCat" runat="server" GroupingText="Search By" meta:resourcekey="pnlCatResource1">
                    <asp:RadioButtonList ID="rblViewType" runat="server" OnSelectedIndexChanged="rblViewType_SelectedIndexChanged"
                        RepeatColumns="3" Width="236px" meta:resourcekey="RBL_deptrResource1" AutoPostBack="True">
                        <asp:ListItem Value="0" meta:resourcekey="ListItemResource1" Text="員工"></asp:ListItem>
                        <asp:ListItem Value="1" meta:resourcekey="ListItemResource2" Selected="True" Text="部門"></asp:ListItem>
                    </asp:RadioButtonList>
                </asp:Panel>
                <asp:Panel ID="pnlSelectedEmp" runat="server" Visible="False" meta:resourcekey="pnlSelectedEmpResource1">
                    <asp:Label ID="lbSelectedEmpHeader" runat="server" Text="Selected employee：" meta:resourcekey="lbSelectedEmpHeaderResource1"
                        Visible="False"></asp:Label>
                    <asp:Label ID="lbSelectedEmpName" runat="server" meta:resourcekey="lbSelectedEmpNameResource1"
                        Visible="False"></asp:Label>
                </asp:Panel>
                <telerik:RadButton ID="btnShowDeptTree" runat="server" ButtonType="ToggleButton"
                    OnClick="btnShowDeptTree_Click" Text="Show Dept Tree" ToggleType="CheckBox" meta:resourcekey="btnShowDeptTreeResource1">
                </telerik:RadButton>
                <telerik:RadButton ID="btnPush" runat="server" OnClick="btnPush_Click" Text="查詢"
                    Visible="False" meta:resourcekey="btnPushResource1">
                </telerik:RadButton>
                <telerik:RadTreeView ID="tvDept" runat="server" Skin="Simple" Visible="False" OnNodeClick="tvDept_NodeClick"
                    CheckBoxes="True" CheckChildNodes="True" meta:resourcekey="tvDeptResource1" TriStateCheckBoxes="False">
                </telerik:RadTreeView>
                <br />
                <div style="width: 100%; float: left;">
                    <asp:Label ID="lbSelectedDeptHeader" runat="server" Text="已選擇部門：" Visible="False"
                        meta:resourcekey="lbSelectedDeptHeaderResource1"></asp:Label>
                    <asp:Label ID="lbSelectedDept" runat="server" Visible="False" meta:resourcekey="lbSelectedDeptResource1"></asp:Label>
                    <asp:Label ID="lbSelectedDeptCode" runat="server" Visible="False" meta:resourcekey="lbSelectedDeptCodeResource1"></asp:Label>
                    <br />
                    <asp:Label ID="lbSelectedNobr" runat="server" Visible="False" meta:resourcekey="lbSelectedNobrResource1"></asp:Label>
                </div>
            </td>
            <td align="left" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlQuickSearch" runat="server" DefaultButton="btnSearch" GroupingText="Quick Search"
                                meta:resourcekey="pnlQuickSearchResource1">
                                <asp:Label ID="lblHeaderMsg" runat="server" Text="輸入員工工號、姓名、部門名稱、兩個字元以上" meta:resourcekey="lblHeaderMsgResource1"></asp:Label>
                                <br />
                                <asp:Label ID="lblHeaderMsg2" runat="server" 
                                    meta:resourceKey="lblHeaderMsgResource2" Text="輸入員工工號、姓名、部門名稱、兩個字元以上" 
                                    Visible="False"></asp:Label>
                                <br />
                                <asp:Label ID="lbQuickSearchHeader" runat="server" Text="快查" Visible="False" meta:resourcekey="lbQuickSearchHeaderResource1"></asp:Label>
                                <telerik:RadTextBox ID="tbQuickSearch" runat="server" DisplayText="" LabelCssClass=""
                                    LabelWidth="64px" meta:resourcekey="tbQuickSearchResource1"
                                    BackColor="LightGoldenrodYellow">
                                    <ClientEvents OnBlur="Blur" />
                                </telerik:RadTextBox>
                                <telerik:RadButton ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click"
                                    meta:resourcekey="btnSearchResource1" style="display:none">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnClear" runat="server" Text="清除" OnClick="btnClear_Click"
                                    meta:resourcekey="btnClearResource1">
                                </telerik:RadButton>
                                <asp:CheckBox ID="cbIsQuickSearchAdvanced" runat="server" Visible="False" 
                                    meta:resourcekey="cbIsQuickSearchAdvancedResource1" />
                                <br />
                                <telerik:RadListView ID="lvQS_Dept" runat="server" OnNeedDataSource="lvQS_Dept_NeedDataSource"
                                    BorderWidth="1px" Skin="Web20" OnItemCommand="lvQS_Dept_ItemCommand" meta:resourcekey="lvQS_DeptResource1">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <telerik:RadButton ID="btnQS_Dept" runat="server" Text='<%# Eval("DeptName") %>'
                                            CommandName="Selected" Skin="Outlook" meta:resourcekey="btnQS_DeptResource1">
                                        </telerik:RadButton>
                                        <asp:Label ID="lbQS_DeptCode" Visible="False" runat="server" Text='<%# Eval("DeptCode") %>'
                                            meta:resourcekey="lbQS_DeptCodeResource1"></asp:Label>
                                    </ItemTemplate>
                                </telerik:RadListView>
                                <telerik:RadGrid ID="gvQsEmp" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                    Culture="(Default)" GridLines="None" OnSelectedIndexChanged="gvQsEmp_SelectedIndexChanged"
                                    PageSize="5" OnItemCommand="gvQsEmp_ItemCommand" >
                                    <MasterTableView DataKeyNames="Nobr">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridButtonColumn CommandName="ExplicitSelect" DataTextField="Name" FilterControlAltText="Filter Name column"
                                                UniqueName="Name" meta:resourcekey="GridButtonColumnResource1" Text="姓名">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn DataField="Nobr" FilterControlAltText="Filter Nobr column"
                                                HeaderText="Emp ID" UniqueName="Nobr" meta:resourcekey="GridBoundColumnResource1">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DeptName" FilterControlAltText="Filter DeptName column"
                                                HeaderText="Unit" UniqueName="DeptName" meta:resourcekey="GridBoundColumnResource2">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JobName" FilterControlAltText="Filter JobName column"
                                                HeaderText="Job Title" UniqueName="JobName" meta:resourcekey="GridBoundColumnResource3">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter EmpName column"
                                                HeaderText="EmpName" UniqueName="EmpName" Visible="False" meta:resourcekey="GridBoundColumnResource4">
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
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlEmp" runat="server" GroupingText="Team Member" meta:resourcekey="pnlEmpResource1">
                                <telerik:RadListView ID="lvEmp" runat="server" OnNeedDataSource="lvEmp_NeedDataSource"
                                    BorderWidth="1px" Skin="Web20" OnItemCommand="lvEmp_ItemCommand" meta:resourcekey="lvEmpResource1">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <telerik:RadButton ID="btnNameC" runat="server" Text='<%# Eval("NAME_C") %>' CommandName="Selected"
                                            Skin="Outlook" meta:resourcekey="btnNameCResource1">
                                        </telerik:RadButton>
                                        <asp:Label ID="lbNobr" Visible="False" runat="server" Text='<%# Eval("NOBR") %>'
                                            meta:resourcekey="lbNobrResource1"></asp:Label>
                                    </ItemTemplate>
                                </telerik:RadListView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</fieldset>
