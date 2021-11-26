<%@ Page Title="部門年度訓練需求調查" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="DeptPlanFill3Summury.aspx.cs" Inherits="DeptPlanFill3Summury" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
        //<![CDATA[

        //Standard Window.confirm
        function StandardConfirm(sender, args) {
            args.set_cancel(!window.confirm("送出後即無法修改，確認送出?"));
        }

        //RadConfirm
        function RadConfirm(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                if (shouldSubmit) {
                    this.click();
                }
            });

            var text = "Are you sure you want to submit the page?";
            radconfirm(text, callBackFunction, 300, 100, null, "RadConfirm");
            args.set_cancel(true);
        }
        //]]>    
    </script>
    <div>
        <div>
            <h3>
                部門年度訓練需求調查
            </h3>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="tvDept">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                            <telerik:AjaxUpdatedControl ControlID="gvQuest" />
                            <telerik:AjaxUpdatedControl ControlID="gvQuestCustom" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="gvQuest">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                            <telerik:AjaxUpdatedControl ControlID="winQuest" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="rbtnAddCourse">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                            <telerik:AjaxUpdatedControl ControlID="winCus" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="gvQuestCustom">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="winQuest">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                            <telerik:AjaxUpdatedControl ControlID="gvQuest" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                    <telerik:AjaxSetting AjaxControlID="winCus">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbAmt" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <div style="float: right; width: 100%;">
                <asp:Label ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <h3>
                    調查清單課程
                </h3>
                <table>
                     <tr>
                        <td>
                            <asp:Label ID="lbMsg" runat="server" Text="課程費用加總："></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbAmt" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <telerik:RadGrid ID="gvQuest" runat="server" CellSpacing="0" GridLines="None" Skin="Outlook"
                    OnItemDataBound="gvQuest_ItemDataBound" Culture="zh-TW" OnNeedDataSource="gvQuest_NeedDataSource"
                    AutoGenerateColumns="False" OnSelectedIndexChanged="gvQuest_SelectedIndexChanged"
                    OnItemCommand="gvQuest_ItemCommand">
                    <MasterTableView DataKeyNames="Id">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" UniqueName="Id"
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter CourseName column"
                                HeaderText="課程名稱" UniqueName="CourseName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CourseCode" FilterControlAltText="Filter CourseCode column"
                                HeaderText="CourseCode" UniqueName="CourseCode" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Amt" FilterControlAltText="Filter Amt column"
                                HeaderText="預算(NTD)" UniqueName="Amt">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Budget" FilterControlAltText="Filter Budget column"
                                HeaderText="外訓課程預估費用/位" UniqueName="Budget">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StudentNum" FilterControlAltText="Filter StudentNum column"
                                HeaderText="人數" UniqueName="StudentNum">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Minutes" FilterControlAltText="Filter Minutes column"
                                HeaderText="時數(分鐘)" UniqueName="Minutes">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Month" FilterControlAltText="Filter Month column"
                                HeaderText="月份" UniqueName="Month" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SuggestionPassItemName" FilterControlAltText="Filter SuggestionPassItemName column"
                                HeaderText="評估方式" UniqueName="SuggestionPassItemName" Visible="False">
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
                <hr />
                <div>
                    <fieldset>
                        <h3>
                            自訂課程</h3>
                        &nbsp;<div>
                            <telerik:RadGrid ID="gvQuestCustom" runat="server" CellSpacing="0" GridLines="None"
                                OnItemDataBound="gvOtherQuest_ItemDataBound" AutoGenerateColumns="False" Culture="zh-TW"
                                OnNeedDataSource="gvQuestCustom_NeedDataSource" OnInsertCommand="gvQuestCustom_InsertCommand"
                                OnItemCommand="gvQuestCustom_ItemCommand">
                                <MasterTableView DataKeyNames="Id">
                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter CourseName column"
                                            HeaderText="課程名稱" SortExpression="CourseName" UniqueName="CourseName">
                                            <ItemStyle Wrap="False" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter Id column" UniqueName="Id"
                                            Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridCheckBoxColumn DataField="IsRejection" FilterControlAltText="Filter IsRejection column"
                                            HeaderText="駁回" UniqueName="IsRejection" Visible="False">
                                            <HeaderStyle ForeColor="Red" />
                                        </telerik:GridCheckBoxColumn>
                                        <telerik:GridBoundColumn DataField="Rejecter" FilterControlAltText="Filter Rejecter column"
                                            HeaderText="駁回者" UniqueName="Rejecter" Visible="False">
                                            <ItemStyle ForeColor="Red" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CourseName" FilterControlAltText="Filter CourseName column"
                                            HeaderText="課程名稱" UniqueName="CourseName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Amt" FilterControlAltText="Filter Amt column"
                                            HeaderText="預算(NTD)" UniqueName="Amt">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StudentNum" FilterControlAltText="Filter StudentNum column"
                                            HeaderText="人數" UniqueName="StudentNum">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Minutes" FilterControlAltText="Filter Minutes column"
                                            HeaderText="時數(分鐘)" UniqueName="Minutes">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Month" FilterControlAltText="Filter Month column"
                                            HeaderText="月份" UniqueName="Month">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SuggestionPassItemName" FilterControlAltText="Filter SuggestionPassItemName column"
                                            HeaderText="評估方式" UniqueName="SuggestionPassItemName" Visible="False">
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
                            <hr />
                            <h3>
                            各月費用
                            </h3>
                            <telerik:RadGrid ID="gvMonth" runat="server" AutoGenerateColumns="False" 
                                CellSpacing="0" Culture="zh-TW" GridLines="None">
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="m1" FilterControlAltText="Filter 1 column" 
            HeaderText="1月" UniqueName="m1">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="m2" FilterControlAltText="Filter 2 column" 
            HeaderText="2月" UniqueName="m2">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter 3 column" 
            UniqueName="m3" DataField="m3" HeaderText="3月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column3 column" 
            UniqueName="m4" DataField="m4" HeaderText="4月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column4 column" 
            UniqueName="m5" DataField="m5" HeaderText="5月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column5 column" 
            UniqueName="m6" DataField="m6" HeaderText="6月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column6 column" 
            UniqueName="m7" DataField="m7" HeaderText="7月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column7 column" 
            UniqueName="m8" DataField="m8" HeaderText="8月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column8 column" 
            UniqueName="m9" DataField="m9" HeaderText="9月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter 10 column" 
            UniqueName="m10" DataField="m10" HeaderText="10月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter 11 column" 
            UniqueName="m11" DataField="m11" HeaderText="11月">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter 12 column" 
            UniqueName="m12" DataField="m12" HeaderText="12月">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                            </telerik:RadGrid>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
