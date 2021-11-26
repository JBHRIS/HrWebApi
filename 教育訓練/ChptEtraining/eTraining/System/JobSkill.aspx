<%@ Page Title="職能積分熟練度設定" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="JobSkill.aspx.cs" Inherits="eTraining_System_JobSkill" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $('.funcblock').corner("15px");
    </script>
<h2>職能積分熟練度設定</h2>



    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        width="100%">
        <telerik:RadButton ID="btnAdd" runat="server" Text="新增" 
    onclick="btnAdd_Click">
        </telerik:RadButton>        
                        <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" 
                    DataSourceID="sdsFv" DefaultMode="Insert" oniteminserted="fv_ItemInserted" 
                    oniteminserting="fv_ItemInserting" onitemcommand="fv_ItemCommand" 
            onitemupdated="fv_ItemUpdated" onitemupdating="fv_ItemUpdating" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' 
                            Visible="False" />
                        <br />
                        代碼： 
                        <asp:TextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>' />
                        <br />
                        名稱： 
                        <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>' />
                        <br />
                        &nbsp;<asp:TextBox ID="sKeyManTextBox" runat="server" Text='<%# Bind("sKeyMan") %>' 
                            Visible="False" />
                        <br />
                        &nbsp;<asp:TextBox ID="dKeyDateTextBox" runat="server" 
                            Text='<%# Bind("dKeyDate") %>' Visible="False" />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="更新" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="取消" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        代碼： 
                        <asp:TextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>' />
                        <asp:RequiredFieldValidator ID="rfvCode" runat="server" 
                            ControlToValidate="sCodeTextBox" Display="None" ErrorMessage="*必要欄位" 
                            ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        名稱： 
                        <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>' />
                        <br />
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                            ControlToValidate="sNameTextBox" Display="None" ErrorMessage="*必要欄位" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="新增" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="取消" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        iAutoKey:
                        <asp:Label ID="iAutoKeyLabel" runat="server" Text='<%# Eval("iAutoKey") %>' />
                        <br />
                        sCode:
                        <asp:Label ID="sCodeLabel" runat="server" Text='<%# Bind("sCode") %>' />
                        <br />
                        sName:
                        <asp:Label ID="sNameLabel" runat="server" Text='<%# Bind("sName") %>' />
                        <br />
                        sKeyMan:
                        <asp:Label ID="sKeyManLabel" runat="server" Text='<%# Bind("sKeyMan") %>' />
                        <br />
                        dKeyDate:
                        <asp:Label ID="dKeyDateLabel" runat="server" Text='<%# Bind("dKeyDate") %>' />
                        <br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="編輯" />
                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="刪除" />
                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                            CommandName="New" Text="新增" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="sdsFv" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                    DeleteCommand="DELETE FROM [JobSkill] WHERE [iAutoKey] = @iAutoKey" 
                    InsertCommand="INSERT INTO [JobSkill] ([sCode], [sName], [sKeyMan], [dKeyDate]) VALUES (@sCode, @sName, @sKeyMan, @dKeyDate)" 
                    SelectCommand="SELECT * FROM [JobSkill] WHERE ([iAutoKey] = @iAutoKey)" 
                    
                    
                    UpdateCommand="UPDATE [JobSkill] SET [sCode] = @sCode, [sName] = @sName, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
                    <DeleteParameters>
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="sCode" Type="String" />
                        <asp:Parameter Name="sName" Type="String" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gv" DefaultValue="-1" Name="iAutoKey" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="sCode" Type="String" />
                        <asp:Parameter Name="sName" Type="String" />
                        <asp:Parameter Name="sKeyMan" Type="String" />
                        <asp:Parameter Name="dKeyDate" Type="DateTime" />
                        <asp:Parameter Name="iAutoKey" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <telerik:RadGrid ID="gv" runat="server" AllowAutomaticDeletes="True" 
                    AllowAutomaticInserts="True" AllowAutomaticUpdates="True" CellSpacing="0" 
                    Culture="zh-TW" DataSourceID="sdsGv" GridLines="None" Skin="Windows7" 
                    Width="80%" onselectedindexchanged="gv_SelectedIndexChanged">
                    <mastertableview autogeneratecolumns="False" datakeynames="iAutoKey" 
                        datasourceid="sdsGv">
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <commanditemsettings exporttopdftext="Export to PDF" />
                        <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column">
                        </rowindicatorcolumn>
                        <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column">
                        </expandcollapsecolumn>
                        <Columns>
                            <telerik:GridButtonColumn CommandName="Select" 
                                FilterControlAltText="Filter Select column" Text="選擇" UniqueName="Select">
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="iAutoKey" DataType="System.Int32" 
                                FilterControlAltText="Filter iAutoKey column" HeaderText="iAutoKey" 
                                ReadOnly="True" SortExpression="iAutoKey" UniqueName="iAutoKey" 
                                Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sCode" 
                                FilterControlAltText="Filter sCode column" HeaderText="代碼" 
                                SortExpression="sCode" UniqueName="sCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sName" 
                                FilterControlAltText="Filter sName column" HeaderText="名稱" 
                                SortExpression="sName" UniqueName="sName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="sKeyMan" 
                                FilterControlAltText="Filter sKeyMan column" HeaderText="sKeyMan" 
                                SortExpression="sKeyMan" UniqueName="sKeyMan" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="dKeyDate" DataType="System.DateTime" 
                                FilterControlAltText="Filter dKeyDate column" HeaderText="dKeyDate" 
                                SortExpression="dKeyDate" UniqueName="dKeyDate" Visible="False">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <editformsettings>
                            <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                            </editcolumn>
                        </editformsettings>
                    </mastertableview>
                    <filtermenu enableimagesprites="False">
                    </filtermenu>
                    <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
                    </headercontextmenu>
                </telerik:RadGrid>
                <asp:SqlDataSource ID="sdsGv" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
                    SelectCommand="SELECT * FROM [JobSkill]"></asp:SqlDataSource>
            
    </telerik:RadAjaxPanel>
    <br />
    <br />
    <br />
    <br />
    </asp:Content>

