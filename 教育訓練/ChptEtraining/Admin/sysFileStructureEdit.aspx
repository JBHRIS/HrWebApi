<%@ Page Title="" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true" CodeFile="sysFileStructureEdit.aspx.cs" Inherits="Admin_sysFileStructureEdit" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function CloseAndRebind(args) {
            GetRadWindow().BrowserWindow.refreshGrid(args);
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
    </script>
    <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
        OnItemCommand="fv_ItemCommand" OnItemDeleted="fv_ItemDeleted" OnItemDeleting="fv_ItemDeleting"
        OnItemInserted="fv_ItemInserted" OnItemInserting="fv_ItemInserting" OnItemUpdated="fv_ItemUpdated"
        OnItemUpdating="fv_ItemUpdating" DefaultMode="Insert">
        <EditItemTemplate>
            <table class="tableOrange">
                <tr>
                    <th>
                        類別代碼
                    </th>
                    <th>
                        代碼
                    </th>
                    <th>
                        值
                    </th>
                    <th>
                        順序
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="sCategoryTextBox" runat="server" Text='<%# Bind("sCategory") %>'
                            CssClass="txtCode" />
                    </td>
                    <td>
                        <asp:TextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                       <telerik:RadMaskedTextBox ID="RadMaskedTextBox2" runat="server" Mask="##"
                    PromptChar=" "  Text='<%# Bind("iOrder") %>' CssClass="txtCode" LabelCssClass="" 
                            Width="100px" />

                 
                    </td>
                </tr>
                <tr>
                    <th>
                        備1
                    </th>
                    <th>
                        備2
                    </th>
                    <th>
                        備3
                    </th>
                    <th>
                        選項
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="s1TextBox" runat="server" Text='<%# Bind("s1") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="s2TextBox" runat="server" Text='<%# Bind("s2") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="s3TextBox" runat="server" Text='<%# Bind("s3") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:CheckBox ID="bDisplayCheckBox" runat="server" Checked='<%# Bind("bDisplay") %>'
                            Text="顯示" />
                        <asp:CheckBox ID="bSystemCheckBox" runat="server" Checked='<%# Bind("bSystem") %>'
                            Text="系統" />
                    </td>
                </tr>
                <tr>
                    <th colspan="4">
                        內容
                    </th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="sContentTextBox" runat="server" Text='<%# Bind("sContent") %>' CssClass="txtPath"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <telerik:RadButton ID="btnUpdate" runat="server" CommandName="Update" Text="更新" />
                        <telerik:RadButton ID="btnCancel" runat="server" CausesValidation="false" 
                            CommandName="Cancel" Text="取消" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' 
                Visible="False" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="tableOrange">
                <tr>
                    <th>
                        類別代碼
                    </th>
                    <th>
                        代碼
                    </th>
                    <th>
                        值
                    </th>
                    <th>
                        順序
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="sCategoryTextBox" runat="server" Text='<%# Bind("sCategory") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="sCodeTextBox" runat="server" Text='<%# Bind("sCode") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="iOrderTextBox" runat="server" Text='<%# Bind("iOrder") %>' CssClass="txtCode"/>
                    </td>
                </tr>
                <tr>
                    <th>
                        備1
                    </th>
                    <th>
                        備2
                    </th>
                    <th>
                        備3
                    </th>
                    <th>
                        選項
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="s1TextBox" runat="server" Text='<%# Bind("s1") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="s2TextBox" runat="server" Text='<%# Bind("s2") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:TextBox ID="s3TextBox" runat="server" Text='<%# Bind("s3") %>' CssClass="txtCode"/>
                    </td>
                    <td>
                        <asp:CheckBox ID="bDisplayCheckBox" runat="server" Checked='<%# Bind("bDisplay") %>'
                            Text="顯示" />
                        <asp:CheckBox ID="bSystemCheckBox" runat="server" Checked='<%# Bind("bSystem") %>'
                            Text="系統" />
                    </td>
                </tr>
                <tr>
                    <th colspan="4">
                        內容
                    </th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="sContentTextBox" runat="server" Text='<%# Bind("sContent") %>' CssClass="txtPath"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <telerik:RadButton ID="btnInsert" runat="server" CommandName="Insert" Text="新增" />
                        <telerik:RadButton ID="btnCancel" runat="server" CausesValidation="false" 
                            CommandName="Cancel" Text="取消" />
               
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        
        DeleteCommand="DELETE FROM [sysFileStructure] WHERE [iAutoKey] = @iAutoKey" InsertCommand="INSERT INTO [sysFileStructure] ([sKey], [sCat], [sPath], [sFileName], [sFileTitle], [sDescription], [sysRole_iKey], [sParentKey], [iOrder], [dDateA], [dDateD], [sKeyMan], [dKeyDate]) VALUES (@sKey, @sCat, @sPath, @sFileName, @sFileTitle, @sDescription, @sysRole_iKey, @sParentKey, @iOrder, @dDateA, @dDateD, @sKeyMan, @dKeyDate)"
        
        SelectCommand="SELECT * FROM [sysFileStructure] WHERE ([iAutoKey] = @iAutoKey)" 
        UpdateCommand="UPDATE [sysFileStructure] SET [sKey] = @sKey, [sCat] = @sCat, [sPath] = @sPath, [sFileName] = @sFileName, [sFileTitle] = @sFileTitle, [sDescription] = @sDescription, [sysRole_iKey] = @sysRole_iKey, [sParentKey] = @sParentKey, [iOrder] = @iOrder, [dDateA] = @dDateA, [dDateD] = @dDateD, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sKey" Type="String" />
            <asp:Parameter Name="sCat" Type="String" />
            <asp:Parameter Name="sPath" Type="String" />
            <asp:Parameter Name="sFileName" Type="String" />
            <asp:Parameter Name="sFileTitle" Type="String" />
            <asp:Parameter Name="sDescription" Type="String" />
            <asp:Parameter Name="sysRole_iKey" Type="Int32" />
            <asp:Parameter Name="sParentKey" Type="String" />
            <asp:Parameter Name="iOrder" Type="Int32" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="iAutoKey" QueryStringField="iAutoKey" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="sKey" Type="String" />
            <asp:Parameter Name="sCat" Type="String" />
            <asp:Parameter Name="sPath" Type="String" />
            <asp:Parameter Name="sFileName" Type="String" />
            <asp:Parameter Name="sFileTitle" Type="String" />
            <asp:Parameter Name="sDescription" Type="String" />
            <asp:Parameter Name="sysRole_iKey" Type="Int32" />
            <asp:Parameter Name="sParentKey" Type="String" />
            <asp:Parameter Name="iOrder" Type="Int32" />
            <asp:Parameter Name="dDateA" Type="DateTime" />
            <asp:Parameter Name="dDateD" Type="DateTime" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <telerik:RadListView ID="lv" runat="server" DataKeyNames="iAutoKey" 
        DataSourceID="sdsFV">
        <LayoutTemplate>
            <div class="RadListView RadListView_Default">
                <ul>
                    <li ID="itemPlaceholder" runat="server"></li>
                </ul>
                <div style="display:none">
                    <telerik:RadCalendar ID="rlvSharedCalendar" runat="server" 
                        RangeMinDate="<%#new DateTime(1900, 1, 1) %>" Skin="<%#Container.Skin %>" />
                </div>
                <div style="display:none">
                    <telerik:RadTimeView ID="rlvSharedTimeView" runat="server" 
                        Skin="<%# Container.Skin %>" />
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <li class="rlvI">&nbsp;<asp:Label ID="iAutoKeyLabel" runat="server" 
                    Text='<%# Eval("iAutoKey") %>' />
                &nbsp;<asp:Label ID="sKeyLabel" runat="server" Text='<%# Eval("sKey") %>' />
                &nbsp;<asp:Label ID="sCatLabel" runat="server" Text='<%# Eval("sCat") %>' />
                &nbsp;<asp:Label ID="sPathLabel" runat="server" Text='<%# Eval("sPath") %>' />
                &nbsp;<asp:Label ID="sFileNameLabel" runat="server" 
                    Text='<%# Eval("sFileName") %>' />
                &nbsp;<asp:Label ID="sFileTitleLabel" runat="server" 
                    Text='<%# Eval("sFileTitle") %>' />
                &nbsp;<asp:Label ID="sDescriptionLabel" runat="server" 
                    Text='<%# Eval("sDescription") %>' />
                &nbsp;<asp:Label ID="sysRole_iKeyLabel" runat="server" 
                    Text='<%# Eval("sysRole_iKey") %>' />
                &nbsp;<asp:Label ID="sParentKeyLabel" runat="server" 
                    Text='<%# Eval("sParentKey") %>' />
                &nbsp;<asp:Label ID="iOrderLabel" runat="server" Text='<%# Eval("iOrder") %>' />
                &nbsp;<asp:Label ID="dDateALabel" runat="server" Text='<%# Eval("dDateA") %>' />
                &nbsp;<asp:Label ID="dDateDLabel" runat="server" Text='<%# Eval("dDateD") %>' />
                &nbsp;<asp:Label ID="sKeyManLabel" runat="server" Text='<%# Eval("sKeyMan") %>' />
                &nbsp;<asp:Label ID="dKeyDateLabel" runat="server" Text='<%# Eval("dKeyDate") %>' />
                &nbsp;<asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" CssClass="rlvBDel" Text=" " ToolTip="Delete" />
                <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" CssClass="rlvBEdit" Text=" " ToolTip="Edit" />
            </li>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <li class="rlvA">&nbsp;<asp:Label ID="iAutoKeyLabel" runat="server" 
                    Text='<%# Eval("iAutoKey") %>' />
                &nbsp;<asp:Label ID="sKeyLabel" runat="server" Text='<%# Eval("sKey") %>' />
                &nbsp;<asp:Label ID="sCatLabel" runat="server" Text='<%# Eval("sCat") %>' />
                &nbsp;<asp:Label ID="sPathLabel" runat="server" Text='<%# Eval("sPath") %>' />
                &nbsp;<asp:Label ID="sFileNameLabel" runat="server" 
                    Text='<%# Eval("sFileName") %>' />
                &nbsp;<asp:Label ID="sFileTitleLabel" runat="server" 
                    Text='<%# Eval("sFileTitle") %>' />
                &nbsp;<asp:Label ID="sDescriptionLabel" runat="server" 
                    Text='<%# Eval("sDescription") %>' />
                &nbsp;<asp:Label ID="sysRole_iKeyLabel" runat="server" 
                    Text='<%# Eval("sysRole_iKey") %>' />
                &nbsp;<asp:Label ID="sParentKeyLabel" runat="server" 
                    Text='<%# Eval("sParentKey") %>' />
                &nbsp;<asp:Label ID="iOrderLabel" runat="server" Text='<%# Eval("iOrder") %>' />
                &nbsp;<asp:Label ID="dDateALabel" runat="server" Text='<%# Eval("dDateA") %>' />
                &nbsp;<asp:Label ID="dDateDLabel" runat="server" Text='<%# Eval("dDateD") %>' />
                &nbsp;<asp:Label ID="sKeyManLabel" runat="server" Text='<%# Eval("sKeyMan") %>' />
                &nbsp;<asp:Label ID="dKeyDateLabel" runat="server" Text='<%# Eval("dKeyDate") %>' />
                &nbsp;<asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" CssClass="rlvBDel" Text=" " ToolTip="Delete" />
                <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" CssClass="rlvBEdit" Text=" " ToolTip="Edit" />
            </li>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <li class="rlvIEdit">
                <table cellspacing="0" class="rlvEditTable">
                    <tr>
                        <td>
                            <asp:Label ID="iAutoKeyLabel2" runat="server" Text="iAutoKey"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sKeyLabel2" runat="server" AssociatedControlID="sKeyTextBox" 
                                Text="sKey"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sKeyTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sKey") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sCatLabel2" runat="server" AssociatedControlID="sCatTextBox" 
                                Text="sCat"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sCatTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sCat") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sPathLabel2" runat="server" AssociatedControlID="sPathTextBox" 
                                Text="sPath"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sPathTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sPath") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sFileNameLabel2" runat="server" 
                                AssociatedControlID="sFileNameTextBox" Text="sFileName"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sFileNameTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sFileName") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sFileTitleLabel2" runat="server" 
                                AssociatedControlID="sFileTitleTextBox" Text="sFileTitle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sFileTitleTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sFileTitle") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sDescriptionLabel2" runat="server" 
                                AssociatedControlID="sDescriptionTextBox" Text="sDescription"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sDescriptionTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sDescription") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sysRole_iKeyLabel2" runat="server" 
                                AssociatedControlID="sysRole_iKeyTextBox" Text="sysRole_iKey"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="sysRole_iKeyTextBox" runat="server" 
                                DataType="Int32" DbValue='<%# Bind("sysRole_iKey") %>' 
                                NumberFormat-DecimalDigits="0" Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sParentKeyLabel2" runat="server" 
                                AssociatedControlID="sParentKeyTextBox" Text="sParentKey"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sParentKeyTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sParentKey") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="iOrderLabel2" runat="server" AssociatedControlID="iOrderTextBox" 
                                Text="iOrder"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="iOrderTextBox" runat="server" DataType="Int32" 
                                DbValue='<%# Bind("iOrder") %>' NumberFormat-DecimalDigits="0" 
                                Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="dDateALabel2" runat="server" AssociatedControlID="dDateATextBox" 
                                Text="dDateA"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="dDateATextBox" runat="server" 
                                DbSelectedDate='<%# Bind("dDateA") %>' MinDate="<%#new DateTime(1900, 1, 1) %>" 
                                SharedCalendarID='<%# Container.OwnerListView.FindControl("rlvSharedCalendar").UniqueID %>' 
                                SharedTimeViewID='<%# Container.OwnerListView.FindControl("rlvSharedTimeView").UniqueID %>' 
                                Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="dDateDLabel2" runat="server" AssociatedControlID="dDateDTextBox" 
                                Text="dDateD"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="dDateDTextBox" runat="server" 
                                DbSelectedDate='<%# Bind("dDateD") %>' MinDate="<%#new DateTime(1900, 1, 1) %>" 
                                SharedCalendarID='<%# Container.OwnerListView.FindControl("rlvSharedCalendar").UniqueID %>' 
                                SharedTimeViewID='<%# Container.OwnerListView.FindControl("rlvSharedTimeView").UniqueID %>' 
                                Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sKeyManLabel2" runat="server" 
                                AssociatedControlID="sKeyManTextBox" Text="sKeyMan"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sKeyManTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sKeyMan") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="dKeyDateLabel2" runat="server" 
                                AssociatedControlID="dKeyDateTextBox" Text="dKeyDate"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="dKeyDateTextBox" runat="server" 
                                DbSelectedDate='<%# Bind("dKeyDate") %>' 
                                MinDate="<%#new DateTime(1900, 1, 1) %>" 
                                SharedCalendarID='<%# Container.OwnerListView.FindControl("rlvSharedCalendar").UniqueID %>' 
                                SharedTimeViewID='<%# Container.OwnerListView.FindControl("rlvSharedTimeView").UniqueID %>' 
                                Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                CssClass="rlvBUpdate" Text=" " ToolTip="Update" />
                            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" 
                                CommandName="Cancel" CssClass="rlvBCancel" Text=" " ToolTip="Cancel" />
                        </td>
                    </tr>
                </table>
            </li>
        </EditItemTemplate>
        <InsertItemTemplate>
            <li class="rlvIEdit">
                <table cellspacing="0" class="rlvEditTable">
                    <tr>
                        <td>
                            <asp:Label ID="sKeyLabel2" runat="server" AssociatedControlID="sKeyTextBox" 
                                Text="sKey"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sKeyTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sKey") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sCatLabel2" runat="server" AssociatedControlID="sCatTextBox" 
                                Text="sCat"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sCatTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sCat") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sPathLabel2" runat="server" AssociatedControlID="sPathTextBox" 
                                Text="sPath"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sPathTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sPath") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sFileNameLabel2" runat="server" 
                                AssociatedControlID="sFileNameTextBox" Text="sFileName"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sFileNameTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sFileName") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sFileTitleLabel2" runat="server" 
                                AssociatedControlID="sFileTitleTextBox" Text="sFileTitle"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sFileTitleTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sFileTitle") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sDescriptionLabel2" runat="server" 
                                AssociatedControlID="sDescriptionTextBox" Text="sDescription"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sDescriptionTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sDescription") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sysRole_iKeyLabel2" runat="server" 
                                AssociatedControlID="sysRole_iKeyTextBox" Text="sysRole_iKey"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="sysRole_iKeyTextBox" runat="server" 
                                DataType="Int32" DbValue='<%# Bind("sysRole_iKey") %>' 
                                NumberFormat-DecimalDigits="0" Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sParentKeyLabel2" runat="server" 
                                AssociatedControlID="sParentKeyTextBox" Text="sParentKey"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sParentKeyTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sParentKey") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="iOrderLabel2" runat="server" AssociatedControlID="iOrderTextBox" 
                                Text="iOrder"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="iOrderTextBox" runat="server" DataType="Int32" 
                                DbValue='<%# Bind("iOrder") %>' NumberFormat-DecimalDigits="0" 
                                Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="dDateALabel2" runat="server" AssociatedControlID="dDateATextBox" 
                                Text="dDateA"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="dDateATextBox" runat="server" 
                                DbSelectedDate='<%# Bind("dDateA") %>' MinDate="<%#new DateTime(1900, 1, 1) %>" 
                                SharedCalendarID='<%# Container.OwnerListView.FindControl("rlvSharedCalendar").UniqueID %>' 
                                SharedTimeViewID='<%# Container.OwnerListView.FindControl("rlvSharedTimeView").UniqueID %>' 
                                Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="dDateDLabel2" runat="server" AssociatedControlID="dDateDTextBox" 
                                Text="dDateD"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="dDateDTextBox" runat="server" 
                                DbSelectedDate='<%# Bind("dDateD") %>' MinDate="<%#new DateTime(1900, 1, 1) %>" 
                                SharedCalendarID='<%# Container.OwnerListView.FindControl("rlvSharedCalendar").UniqueID %>' 
                                SharedTimeViewID='<%# Container.OwnerListView.FindControl("rlvSharedTimeView").UniqueID %>' 
                                Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sKeyManLabel2" runat="server" 
                                AssociatedControlID="sKeyManTextBox" Text="sKeyMan"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sKeyManTextBox" runat="server" CssClass="rlvInput" 
                                Text='<%# Bind("sKeyMan") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="dKeyDateLabel2" runat="server" 
                                AssociatedControlID="dKeyDateTextBox" Text="dKeyDate"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDateTimePicker ID="dKeyDateTextBox" runat="server" 
                                DbSelectedDate='<%# Bind("dKeyDate") %>' 
                                MinDate="<%#new DateTime(1900, 1, 1) %>" 
                                SharedCalendarID='<%# Container.OwnerListView.FindControl("rlvSharedCalendar").UniqueID %>' 
                                SharedTimeViewID='<%# Container.OwnerListView.FindControl("rlvSharedTimeView").UniqueID %>' 
                                Skin="<%#Container.OwnerListView.Skin %>" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="PerformInsertButton" runat="server" CommandName="PerformInsert" 
                                CssClass="rlvBAdd" Text=" " ToolTip="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" 
                                CommandName="Cancel" CssClass="rlvBCancel" Text=" " ToolTip="Cancel" />
                        </td>
                    </tr>
                </table>
            </li>
        </InsertItemTemplate>
        <EmptyDataTemplate>
            <div class="RadListView RadListView_Default">
                <div class="rlvEmpty">
                    There are no items to be displayed.</div>
            </div>
        </EmptyDataTemplate>
        <SelectedItemTemplate>
            <li class="rlvISel">&nbsp;<asp:Label ID="iAutoKeyLabel" runat="server" 
                    Text='<%# Eval("iAutoKey") %>' />
                &nbsp;<asp:Label ID="sKeyLabel" runat="server" Text='<%# Eval("sKey") %>' />
                &nbsp;<asp:Label ID="sCatLabel" runat="server" Text='<%# Eval("sCat") %>' />
                &nbsp;<asp:Label ID="sPathLabel" runat="server" Text='<%# Eval("sPath") %>' />
                &nbsp;<asp:Label ID="sFileNameLabel" runat="server" 
                    Text='<%# Eval("sFileName") %>' />
                &nbsp;<asp:Label ID="sFileTitleLabel" runat="server" 
                    Text='<%# Eval("sFileTitle") %>' />
                &nbsp;<asp:Label ID="sDescriptionLabel" runat="server" 
                    Text='<%# Eval("sDescription") %>' />
                &nbsp;<asp:Label ID="sysRole_iKeyLabel" runat="server" 
                    Text='<%# Eval("sysRole_iKey") %>' />
                &nbsp;<asp:Label ID="sParentKeyLabel" runat="server" 
                    Text='<%# Eval("sParentKey") %>' />
                &nbsp;<asp:Label ID="iOrderLabel" runat="server" Text='<%# Eval("iOrder") %>' />
                &nbsp;<asp:Label ID="dDateALabel" runat="server" Text='<%# Eval("dDateA") %>' />
                &nbsp;<asp:Label ID="dDateDLabel" runat="server" Text='<%# Eval("dDateD") %>' />
                &nbsp;<asp:Label ID="sKeyManLabel" runat="server" Text='<%# Eval("sKeyMan") %>' />
                &nbsp;<asp:Label ID="dKeyDateLabel" runat="server" Text='<%# Eval("dKeyDate") %>' />
                &nbsp;<asp:Button ID="DeselectButton" runat="server" CausesValidation="False" 
                    CommandName="Deselect" CssClass="rlvBSel" Text=" " ToolTip="Deselect" />
                <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" CssClass="rlvBDel" Text=" " ToolTip="Delete" />
                <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" CssClass="rlvBEdit" Text=" " ToolTip="Edit" />
            </li>
        </SelectedItemTemplate>
    </telerik:RadListView>
    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    </asp:Content>

