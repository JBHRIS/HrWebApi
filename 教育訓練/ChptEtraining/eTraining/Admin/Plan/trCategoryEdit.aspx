<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trCategoryEdit.aspx.cs" MasterPageFile="~/mpEdit.master"
    Inherits="Admin_Plan_trCategoryEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshTV(args);
            GetRadWindow().close();
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

            return oWindow;
        }

        function CancelEdit() {
            GetRadWindow().close();
        }

        function OpenAlert() {
            radalert('<h4>Welcome to <strong>RadWindow</strong>!</h4>', 330, 100, 'RadAlert custom title');
            return false;
        }

    </script>
    <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" 
        DataSourceID="sdsFV" onitemcommand="fv_ItemCommand" 
        oniteminserting="fv_ItemInserting" onitemupdating="fv_ItemUpdating" 
        oniteminserted="fv_ItemInserted" onitemupdated="fv_ItemUpdated" 
        ondatabound="fv_DataBound">
        <EditItemTemplate>
            <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' 
                Visible="False" />
            <br />
            <table style="width:100%;" class="tableBlue">
                <tr>
                    <th>代碼</th>
                    <td><telerik:RadTextBox ID="sCodeTextBox" runat="server" 
                            Text='<%# Bind("sCode") %>' Width="98%" Enabled="False" ReadOnly="True" /></td>
                    </tr>
                
                <tr>
                    <th>名稱</th> 
                    <td><telerik:RadTextBox ID="sNameTextBox" runat="server" 
                            Text='<%# Bind("sName") %>' Width="98%" /></td>                   
                </tr>
                
                    <tr>
                    <th>順位</th>
                    <td><telerik:RadTextBox ID="iOrderTextBox" runat="server" 
                            Text='<%# Bind("iOrder") %>' Width="98%" /></td>
                    </tr>
                    
                <tr>
                    <th>生效日</th>   
                    <td><telerik:RadDatePicker ID="dDateATextBox" Runat="server" Culture="zh-TW" 
                            DbSelectedDate='<%# bind("dDateA") %>' Width="100%">
                        </telerik:RadDatePicker></td>                 
                </tr>
                
                    <tr>
                    <th>失效日</th>
                    <td><telerik:RadDatePicker ID="dDateDTextBox" Runat="server" Culture="zh-TW" 
                            DbSelectedDate='<%# bind("dDateD") %>' Width="100%" MaxDate="9999-12-31">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker></td>
                    </tr>
                    
            </table>
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="更新" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="取消" />
        </EditItemTemplate>
        <InsertItemTemplate>
            &nbsp;<table style="width:100%;" class="tableBlue">
                <tr>
                    <th>代碼</th>
                    <td><telerik:RadTextBox ID="sCodeTextBox" runat="server" 
                            Text='<%# Bind("sCode") %>' Width="98%" /></td>
                    </tr>
                
                <tr>
                    <th>名稱</th> 
                    <td><telerik:RadTextBox ID="sNameTextBox" runat="server" 
                            Text='<%# Bind("sName") %>' Width="98%" /></td>                   
                </tr>
                
                    <tr>
                    <th>順位</th>
                    <td><telerik:RadTextBox ID="iOrderTextBox" runat="server" 
                            Text='<%# bind("iOrder") %>' Width="98%" /></td>
                    </tr>
                    
                <tr>
                    <th>生效日</th>   
                    <td><telerik:RadDatePicker ID="dDateATextBox" Runat="server" Culture="zh-TW" 
                            DbSelectedDate='<%# bind("dDateA") %>' Width="100%">
                        </telerik:RadDatePicker></td>                 
                </tr>
                
                    <tr>
                    <th>失效日</th>
                    <td><telerik:RadDatePicker ID="dDateDTextBox" Runat="server" Culture="zh-TW" 
                            DbSelectedDate='<%# bind("dDateD") %>' Width="100%" MaxDate="9999-12-31" 
                            SelectedDate="9999-12-31">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" 
                                selecteddate="9999-12-31">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker></td>
                    </tr>
                    
            </table>
            <br />
            &nbsp;<telerik:RadButton ID="rbtnAdd" runat="server" CommandName="Insert" 
                Text="新增">
            </telerik:RadButton>
            <telerik:RadButton ID="rbtnCancel" runat="server" CommandName="Cancel" 
                Text="取消">
            </telerik:RadButton>
        </InsertItemTemplate>
        <ItemTemplate>
            iAutoKey:
            <asp:Label ID="iAutoKeyLabel" runat="server" Text='<%# Eval("iAutoKey") %>' />
            <br />
            sysRole_iKey:
            <asp:Label ID="sysRole_iKeyLabel" runat="server" 
                Text='<%# Bind("sysRole_iKey") %>' />
            <br />
            sCode:
            <asp:Label ID="sCodeLabel" runat="server" Text='<%# Bind("sCode") %>' />
            <br />
            sName:
            <asp:Label ID="sNameLabel" runat="server" Text='<%# Bind("sName") %>' />
            <br />
            iOrder:
            <asp:Label ID="iOrderLabel" runat="server" Text='<%# Bind("iOrder") %>' />
            <br />
            sParentCode:
            <asp:Label ID="sParentCodeLabel" runat="server" 
                Text='<%# Bind("sParentCode") %>' />
            <br />
            dDateA:
            <asp:Label ID="dDateALabel" runat="server" Text='<%# Bind("dDateA") %>' />
            <br />
            dDateD:
            <asp:Label ID="dDateDLabel" runat="server" 
                Text='<%# Bind("dDateD") %>' />
            <br />
            sKeyMan:
            <asp:Label ID="sKeyManLabel" runat="server" Text='<%# Bind("sKeyMan") %>' />
            <br />
            dKeyDate:
            <asp:Label ID="dKeyDateLabel" runat="server" Text='<%# Bind("dKeyDate") %>' />
            <br />

        </ItemTemplate>
    </asp:FormView>
    <br />

    <br />
    <asp:Label ID="lblMsg" runat="server" Text="新增失敗，請確認是否重複" Visible="False"></asp:Label>
    <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="SELECT * FROM [trCategory] WHERE ([sCode] = @sCode)" 
        DeleteCommand="DELETE FROM [trCategory] WHERE [iAutoKey] = @iAutoKey" 
        InsertCommand="INSERT INTO [trCategory] ([sysRole_iKey], [sCode], [sName], [iOrder], [sParentCode], [dDateA], [dDateD], [sKeyMan], [dKeyDate]) VALUES (@sysRole_iKey, @sCode, @sName, @iOrder, @sParentCode, @dDateA, @dDateD, @sKeyMan, @dKeyDate)" 
        
        
        UpdateCommand="UPDATE [trCategory] SET [sysRole_iKey] = @sysRole_iKey, [sCode] = @sCode, [sName] = @sName, [iOrder] = @iOrder, [sParentCode] = @sParentCode, [dDateA] = @dDateA, [dDateD] = @dDateD, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [sCode] = @sCode">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sysRole_iKey" Type="Int32" />
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="iOrder" Type="Int32" />
            <asp:Parameter Name="sParentCode" Type="String" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="sCode" 
                QueryStringField="pid" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="sysRole_iKey" Type="Int32" />
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="iOrder" Type="Int32" />
            <asp:Parameter Name="sParentCode" Type="String" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    </asp:Content>

