<%@ Page Title="課程前中後查檢" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="NotifyTemplate.aspx.cs" Inherits="eTraining_Admin_Design_NotifyTemplate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>
            課程前中後查檢</h2>
        <telerik:radtabstrip id="RadTabStrip1" runat="server" multipageid="RadMultiPage1"
            selectedindex="3">
        <tabs>
            <telerik:RadTab runat="server" PageViewID="RadPageView3" 
                Text="新增流程項目">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="新增流程範本" PageViewID="RadPageView1">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="編輯流程範本內容" 
                PageViewID="RadPageView2">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="檢示流程範本" Selected="True">
            </telerik:RadTab>
        </tabs>
    </telerik:radtabstrip>
        <telerik:radmultipage id="RadMultiPage1" runat="server" selectedindex="3">
        <telerik:RadPageView ID="RadPageView1" runat="server" BackColor="#EBEBFF">
            範本名稱<telerik:RadTextBox 
            ID="txtNfName" Runat="server" ValidationGroup="T">
            </telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                ControlToValidate="txtNfName" Display="Dynamic" ErrorMessage="必填欄位" 
                ForeColor="Red" SetFocusOnError="True" ValidationGroup="T"></asp:RequiredFieldValidator>
            <br />
            <br />
            <telerik:RadButton ID="btnNfAdd" runat="server" onclick="btnNfAdd_Click" 
                Text="新增" ValidationGroup="T">
            </telerik:RadButton>
&nbsp;
            <br />
            <br />
            <telerik:RadGrid ID="gvNfTemplate" runat="server" AllowAutomaticDeletes="True" 
                CellSpacing="0" Culture="zh-TW" DataSourceID="sdsNotifyTemplate" 
                GridLines="None" Skin="Windows7" Width="70%" AllowAutomaticUpdates="True">
                <mastertableview autogeneratecolumns="False" datakeynames="iAutoKey" 
                datasourceid="sdsNotifyTemplate">
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </rowindicatorcolumn>
                    <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                        <HeaderStyle Width="20px" />
                    </expandcollapsecolumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="sCode" 
                            FilterControlAltText="Filter sCode column" HeaderText="樣版代碼" 
                            SortExpression="sCode" UniqueName="sCode" Visible="False" ReadOnly="True">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName" 
                            FilterControlAltText="Filter sName column" HeaderText="範本名稱" 
                            SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" 
                            FilterControlAltText="Filter column column" UniqueName="Edit">
                        </telerik:GridButtonColumn>
                    </Columns>
                    <editformsettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column" 
                    UniqueName="EditCommandColumn1" ButtonType="PushButton" CancelText="取消" 
                    EditText="編輯" HeaderButtonType="PushButton" InsertText="新增" UpdateText="更新">
                </EditColumn>
                    </editformsettings>
                </mastertableview>
                <filtermenu enableimagesprites="False">
                </filtermenu>
                <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
                </headercontextmenu>
            </telerik:RadGrid>
            <asp:SqlDataSource ID="sdsNotifyTemplate" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                DeleteCommand="DELETE FROM [trNotifyTemplate] WHERE [iAutoKey] = @iAutoKey" 
                InsertCommand="INSERT INTO [trNotifyTemplate] ([sCode], [sName], [sKeyMan], [dKeyDate]) VALUES (@sCode, @sName, @sKeyMan, @dKeyDate)" 
                SelectCommand="SELECT * FROM [trNotifyTemplate]" 
                
                UpdateCommand="UPDATE [trNotifyTemplate] SET  [sName] = @sName WHERE [iAutoKey] = @iAutoKey">
                <DeleteParameters>
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="sCode" Type="String" />
                    <asp:Parameter Name="sName" Type="String" />
                    <asp:Parameter Name="sKeyMan" Type="String" />
                    <asp:Parameter Name="dKeyDate" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sCode" Type="String" />
                    <asp:Parameter Name="sName" Type="String" />
                    <asp:Parameter Name="iAutoKey" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            
</telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" BackColor="#FFEBEB">
            <br />
            選擇範本<telerik:RadComboBox 
            ID="cbxNfName" Runat="server" DataSourceID="sdsNotifyTemplate" 
                DataTextField="sName" DataValueField="sCode" AutoPostBack="True" 
                onselectedindexchanged="cbxNfName_SelectedIndexChanged">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="面談技巧流程通知" Value="面談技巧流程通知" 
                        Owner="cbxNfName" />
                    <telerik:RadComboBoxItem runat="server" Text="教育訓練技巧流程通知" Value="教育訓練技巧流程通知" 
                        Owner="cbxNfName" />
                </Items>
            </telerik:RadComboBox>
            <br />
            <br />
            <telerik:RadGrid ID="gvPickItem" runat="server" 
                AllowMultiRowSelection="True" CellSpacing="0" Culture="zh-TW" 
                DataSourceID="sdsPickItem" GridLines="None" Skin="Office2010Blue" 
                Width="70%" onitemdatabound="gvPickItem_ItemDataBound" >
                <clientsettings>
                    <selecting allowrowselect="True" />
                    <selecting allowrowselect="True" />
                    <selecting allowrowselect="True" />
                    <selecting allowrowselect="True" />
                    <selecting allowrowselect="True" />
                </clientsettings>
                <mastertableview autogeneratecolumns="False" datakeynames="iAutokey" 
                datasourceid="sdsPickItem" allowpaging="True" pagesize="20">
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <commanditemsettings exporttopdftext="Export to PDF" />
                    <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                    </rowindicatorcolumn>
                    <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                    </expandcollapsecolumn>
                    <Columns>
                        <telerik:GridClientSelectColumn FilterControlAltText="Filter column column" 
                            UniqueName="column">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="iAutokey" DataType="System.Int32" 
                            FilterControlAltText="Filter iAutokey column" HeaderText="iAutokey" 
                            ReadOnly="True" SortExpression="iAutokey" UniqueName="iAutokey" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sName" 
                            FilterControlAltText="Filter sName column" HeaderText="項目" 
                            SortExpression="sName" UniqueName="sName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iTimespan" DataType="System.Int32" 
                            FilterControlAltText="Filter iTimespan column" HeaderText="iTimespan" 
                            SortExpression="iTimespan" UniqueName="iTimespan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sKeyMan" 
                            FilterControlAltText="Filter sKeyMan column" HeaderText="sKeyMan" 
                            SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
                            FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
                            SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sCode" EmptyDataText="" 
                            FilterControlAltText="Filter sCode column" HeaderText="sCode" 
                            SortExpression="sCode" UniqueName="sCode" Visible="False">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="iTimespanT" DataType="System.Int32" 
                            FilterControlAltText="Filter iTimespanT column" HeaderText="時間間距" 
                            SortExpression="iTimespanT" UniqueName="iTimespanT">
                            <EditItemTemplate>
                                <asp:TextBox ID="iTimespanTTextBox" runat="server" 
                                    Text='<%# Bind("iTimespanT") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="ntb_iTimespanT" Runat="server" Culture="zh-TW" 
                                    DataType="System.Int32" DbValue='<%# Bind("iTimespanT") %>' Width="125px">
                                    <numberformat decimaldigits="0" />
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="dtl_iAutoKey" EmptyDataText="" 
                            FilterControlAltText="Filter dtl_iAutoKey column" UniqueName="dtl_iAutoKey" 
                            Visible="False">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <editformsettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column" 
                    UniqueName="EditCommandColumn1" ButtonType="PushButton" CancelText="取消" 
                    EditText="編輯" HeaderButtonType="PushButton" InsertText="新增" UpdateText="更新">
                </EditColumn>
                    </editformsettings>
                </mastertableview>
                <filtermenu enableimagesprites="False">
                </filtermenu>
                <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
                </headercontextmenu>
            </telerik:RadGrid>
            <asp:Label ID="lblMsg2" runat="server" ForeColor="Red"></asp:Label>
            <asp:SqlDataSource ID="sdsPickItem" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="SELECT i.*,d.sCode,d.iTimespanT,d.iAutoKey as dtl_iAutoKey  FROM [trNotifyItem] i 
left join trNotifyTemplateDetail d on i.iAutokey= d.NotifyItem_iAutokey  and d.sCode =@sCode
">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cbxNfName" DefaultValue="0" Name="sCode" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <telerik:RadButton ID="btnAddItem" runat="server" onclick="btnAddItem_Click" 
                Text="加入">
            </telerik:RadButton>
            <br />
            
</telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView3" runat="server" BackColor="#CDE5FF">
        <br />
        項目名稱<telerik:RadTextBox ID="txtNfItem" Runat="server" ValidationGroup="I">
        </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="rfvItem" runat="server" 
                ControlToValidate="txtNfItem" Display="Dynamic" ErrorMessage="必填欄位" 
                ForeColor="Red" SetFocusOnError="True" ValidationGroup="I"></asp:RequiredFieldValidator>
        <br />
        <br />
        時間間距<telerik:RadNumericTextBox ID="txtTimespan" Runat="server" ValidationGroup="I" 
                ontextchanged="txtTimespan_TextChanged">
                    <numberformat decimaldigits="0" />
        </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvTimespan" runat="server" 
                ControlToValidate="txtTimespan" Display="Dynamic" ErrorMessage="必填欄位" 
                ForeColor="Red" SetFocusOnError="True" ValidationGroup="I"></asp:RequiredFieldValidator>
        <br />
        <br />
        <telerik:RadButton ID="btnAddNfItem0" runat="server" onclick="btnAddNfItem0_Click" 
                Text="新增" ValidationGroup="I">
        </telerik:RadButton>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <telerik:RadGrid ID="gvNotifyItem" runat="server" AllowAutomaticDeletes="True" 
                AllowAutomaticInserts="True" AllowAutomaticUpdates="True" CellSpacing="0" 
                Culture="zh-TW" DataSourceID="sdsNotifyItem" GridLines="None" Skin="Windows7" 
                Width="70%" AllowCustomPaging="True" AllowPaging="True">
            <mastertableview autogeneratecolumns="False" datakeynames="iAutokey" 
                datasourceid="sdsNotifyItem" allowcustompaging="False">
                <commanditemsettings exporttopdftext="Export to PDF" />
                <commanditemsettings exporttopdftext="Export to PDF" />
                <commanditemsettings exporttopdftext="Export to PDF" />
                <commanditemsettings exporttopdftext="Export to PDF" />
                <commanditemsettings exporttopdftext="Export to PDF" />
                <commanditemsettings exporttopdftext="Export to PDF" />
                <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                </rowindicatorcolumn>
                <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                </expandcollapsecolumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="sName" 
                        FilterControlAltText="Filter sName column" HeaderText="項目名稱" 
                        SortExpression="sName" UniqueName="sName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="iTimespan" DataType="System.Int32" 
                        FilterControlAltText="Filter iTimespan column" HeaderText="時間間距" 
                        SortExpression="iTimespan" UniqueName="iTimespan">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" 
                        FilterControlAltText="Filter column column" UniqueName="Edit">
                    </telerik:GridButtonColumn>
                </Columns>
                <editformsettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column" 
                    UniqueName="EditCommandColumn1" ButtonType="PushButton" CancelText="取消" 
                    EditText="編輯" HeaderButtonType="PushButton" InsertText="新增" UpdateText="更新">
                </EditColumn>
                </editformsettings>
            </mastertableview>
            <filtermenu enableimagesprites="False">
            </filtermenu>
            <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
            </headercontextmenu>
        </telerik:RadGrid>
        <asp:SqlDataSource ID="sdsNotifyItem" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                DeleteCommand="DELETE FROM [trNotifyItem] WHERE [iAutokey] = @iAutokey" 
                InsertCommand="INSERT INTO [trNotifyItem] ([sName], [iTimespan], [sKeyMan], [dKeyDate]) VALUES (@sName, @iTimespan, @sKeyMan, @dKeyDate)" 
                SelectCommand="SELECT * FROM [trNotifyItem]
order by iTimespan" 
                
                
                UpdateCommand="UPDATE [trNotifyItem] SET [sName] = @sName, [iTimespan] = @iTimespan WHERE [iAutokey] = @iAutokey">
            <DeleteParameters>
                <asp:Parameter Name="iAutokey" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="sName" Type="String" />
                <asp:Parameter Name="iTimespan" Type="Int32" />
                <asp:Parameter Name="sKeyMan" Type="String" />
                <asp:Parameter Name="dKeyDate" Type="DateTime" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="sName" Type="String" />
                <asp:Parameter Name="iTimespan" Type="Int32" />
                <asp:Parameter Name="sKeyMan" Type="String" />
                <asp:Parameter Name="dKeyDate" Type="DateTime" />
                <asp:Parameter Name="iAutokey" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
                <br />
</telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView4" runat="server" BackColor="#F8F8D4">
                選擇範本<telerik:RadComboBox ID="cbxNfVName" Runat="server" 
                DataSourceID="sdsNotifyTemplate" DataTextField="sName" 
                DataValueField="sCode" AutoPostBack="True" 
                onselectedindexchanged="cbxNfVName_SelectedIndexChanged">
        <Items>
            <telerik:RadComboBoxItem runat="server" Owner="cbxNfVName" Text="面談技巧流程通知" 
                Value="面談技巧流程通知" />
            <telerik:RadComboBoxItem runat="server" Owner="cbxNfVName" Text="教育訓練技巧流程通知" 
                Value="教育訓練技巧流程通知" />
        </Items>
    </telerik:RadComboBox>
                <br />
                <br />
                <telerik:RadGrid ID="gvNotifyTemplateDetail" runat="server" CellSpacing="0" 
                Culture="zh-TW" DataSourceID="sdsNotifyTemplateDetail" GridLines="None" 
                Skin="Windows7" Width="70%">
                    <mastertableview autogeneratecolumns="False" 
                datasourceid="sdsNotifyTemplateDetail">
                        <commanditemsettings exporttopdftext="Export to PDF" />
                        <commanditemsettings exporttopdftext="Export to PDF" />
                        <commanditemsettings exporttopdftext="Export to PDF" />
                        <rowindicatorcolumn 
                filtercontrolalttext="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </rowindicatorcolumn>
                        <expandcollapsecolumn 
                filtercontrolalttext="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </expandcollapsecolumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="sName" 
                                FilterControlAltText="Filter sName column" HeaderText="項目名稱" 
                                SortExpression="sName" UniqueName="sName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="iTimespanT" DataType="System.Int32" 
                                FilterControlAltText="Filter iTimespan column" HeaderText="時間間距" 
                                SortExpression="iTimespanT" UniqueName="iTimespanT">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <editformsettings>
                            <editcolumn 
                filtercontrolalttext="Filter EditCommandColumn column">
                            </editcolumn>
                        </editformsettings>
                    </mastertableview>
                    <filtermenu enableimagesprites="False">
                    </filtermenu>
                    <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
                    </headercontextmenu>
                </telerik:RadGrid>
                <br />
                <asp:SqlDataSource ID="sdsNotifyTemplateDetail" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" SelectCommand="select ni.sName,ntd.iTimespanT from trNotifyTemplateDetail ntd
join trNotifyItem ni on ntd.NotifyItem_iAutokey=ni.iAutokey 
where ntd.sCode=@sCode
order by iTimespanT">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cbxNfVName" DefaultValue="0" Name="sCode" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
</telerik:RadPageView>
    </telerik:radmultipage>
        <br />
    </div>
</asp:Content>
