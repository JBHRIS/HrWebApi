<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trTeacherEdit.aspx.cs" MasterPageFile="~/mpEdit.master"
    Inherits="Admin_Design_trTeacherEdit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:FormView ID="fv" runat="server" DataKeyNames="iAutoKey" DataSourceID="sdsFV"
        OnItemCommand="fv_ItemCommand" OnItemInserting="fv_ItemInserting" OnItemUpdating="fv_ItemUpdating"
        OnItemInserted="fv_ItemInserted1" OnItemUpdated="fv_ItemUpdated1">
        <EditItemTemplate>
            <asp:Label ID="iAutoKeyLabel1" runat="server" Text='<%# Eval("iAutoKey") %>' Visible="False" />
            <br />
            <telerik:RadTextBox Text='<%# Bind("sCode") %>' runat="server" ID="sCodeTextBox"
                Width="130px" Visible="False" />
            <table class="tableBlue" border="1">
                <tr>
                    <th>
                        工號
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox2" runat="server" Text='<%# Bind("sNobr") %>' Width="100px" />
                        <telerik:RadButton ID="RadButton1" runat="server" Text="帶入" CommandName="LoadDataEdit">
                        </telerik:RadButton>
                    </td>
                    <th>
                        姓名
                    </th>
                    <td>
                        <telerik:RadTextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>'
                            Width="100px" />
                        <asp:RequiredFieldValidator ID="rfv_sName" runat="server" ControlToValidate="sNameTextBox"
                            Display="Dynamic" ErrorMessage="*必要欄位" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <th style="width: 100px">
                        內部講師
                    </th>
                    <td>
                        <asp:CheckBox ID="ckxEntTeacherType" runat="server" Checked='<%# Bind("bEntTeacherType") %>' />
                    </td>
                    <tr>
                        <th style="width: 100px">
                            身分證號
                        </th>
                        <td>
                            <telerik:RadTextBox ID="txtsTeacherID" runat="server" Text='<%# Bind("sTeacherID") %>'
                                Width="130px" />
                        </td>
                        <th style="width: 100px">
                            公司統編
                        </th>
                        <td>
                            <telerik:RadTextBox ID="txtsCompanyID" runat="server" Text='<%# Bind("sCompanyID") %>'
                                Width="130px" />
                        </td>
                        <th>
                            電話
                        </th>
                        <td>
                            <telerik:RadTextBox ID="sTelTextBox" runat="server" Text='<%# Bind("sTel") %>' Width="130px" />
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 100px">
                            公司名稱
                        </th>
                        <td>
                            <telerik:RadTextBox ID="tbCompanyName" runat="server" Text='<%# Bind("CompanyName") %>'
                                Width="130px" />
                        </td>
                        <th style="width: 100px">
                            聯絡人
                        </th>
                        <td>
                            <telerik:RadTextBox ID="tbContactPerson" runat="server" Text='<%# Bind("ContactPerson") %>'
                                Width="130px" />
                        </td>
                        <th>
                            聯絡電話
                        </th>
                        <td>
                            <telerik:RadTextBox ID="tbContactPhoneNumber" runat="server" Text='<%# Bind("ContactPhoneNumber") %>'
                                Width="130px" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            E-mail
                        </th>
                        <td>
                            <telerik:RadTextBox ID="sEmailTextBox" runat="server" Text='<%# Bind("sEmail") %>'
                                Width="100%" />
                        </td>
                        <th>
                            外部講師密碼
                        </th>
                        <td>
                            帳號：<telerik:RadTextBox ID="sOuterTeacherIdTextBox" runat="server" Text='<%# Bind("sOuterTeacherId") %>'
                                Width="100%" DisplayText="" LabelWidth="40%" type="text" value="" />
                            密碼：<telerik:RadTextBox ID="sTeacherPWDTextBox" runat="server" Text='<%# Bind("sTeacherPWD") %>'
                                Width="100%" />
                        </td>
                        <th>
                            手機
                        </th>
                        <td>
                            <telerik:RadTextBox ID="sCellPhoneTextBox" runat="server" Text='<%# Bind("sCellPhone") %>'
                                Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            學歷
                        </th>
                        <td colspan="5">
                            <telerik:RadTextBox ID="sNote1TextBox0" runat="server" Text='<%# Bind("sNote1") %>'
                                TextMode="MultiLine" Width="98%" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            工作經歷<td colspan="5">
                                <telerik:RadTextBox ID="txtsWorkExp" runat="server" Text='<%# Bind("sWorkExp") %>'
                                    TextMode="MultiLine" Width="98%" />
                            </td>
                            <tr>
                                <th>
                                    授課經歷
                                </th>
                                <td colspan="5">
                                    <telerik:RadTextBox ID="txtsTeachExp" runat="server" Text='<%# Bind("sTeachExp") %>'
                                        TextMode="MultiLine" Width="98%" />
                                </td>
                            </tr>
                            <th>
                                專長
                            </th>
                            <td colspan="5">
                                <telerik:RadTextBox ID="txtsNote2" runat="server" Text='<%# Bind("sNote2") %>' TextMode="MultiLine"
                                    Width="98%" />
                            </td>
                        </th>
                    </tr>
                    </th>
                </tr>
                </tr>
            </table>
            &nbsp;<telerik:RadButton ID="rbtn_Update" runat="server" CommandName="Update" Text="更新">
            </telerik:RadButton>
            &nbsp;&nbsp;
            <telerik:RadButton ID="rbtn_Cancel" runat="server" CommandName="Cancel" Text="取消">
            </telerik:RadButton>
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="tableBlue" border="1">
                <tr>
                    <th>
                        工號
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox2" runat="server" Text='<%# Bind("sNobr") %>' Width="100px" />
                        <telerik:RadButton ID="btnLoadData" runat="server" Text="帶入" CausesValidation="False"
                            CommandName="LoadDataInsert" GroupName="test" OnClick="btnLoadData_Click">
                        </telerik:RadButton>
                    </td>
                    <th>
                        姓名
                    </th>
                    <td>
                        <telerik:RadTextBox ID="sNameTextBox" runat="server" Text='<%# Bind("sName") %>'
                            Width="100px" />
                        <asp:RequiredFieldValidator ID="rfv_sName" runat="server" ControlToValidate="sNameTextBox"
                            Display="Dynamic" ErrorMessage="*必要欄位" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <th style="width: 100px">
                        內部講師
                    </th>
                    <td>
                        <asp:CheckBox ID="ckxEntTeacherType" runat="server" Checked='<%# Bind("bEntTeacherType") %>' />
                    </td>
                    <tr>
                        <th style="width: 100px">
                            身分證號
                        </th>
                        <td>
                            <telerik:RadTextBox ID="txtsTeacherID" runat="server" Text='<%# Bind("sTeacherID") %>'
                                Width="130px" />
                        </td>
                        <th style="width: 100px">
                            公司統編
                        </th>
                        <td>
                            <telerik:RadTextBox ID="txtsCompanyID" runat="server" Text='<%# Bind("sCompanyID") %>'
                                Width="130px" />
                        </td>
                        <th>
                            電話
                        </th>
                        <td>
                            <telerik:RadTextBox ID="sTelTextBox" runat="server" Text='<%# Bind("sTel") %>' Width="130px" />
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 100px">
                            公司名稱
                         
                            <td>
                                <telerik:RadTextBox ID="tbCompanyName" runat="server" 
                                    Text='<%# Bind("CompanyName") %>' Width="130px" />
                            </td>
                            <th style="width: 100px">
                                聯絡人 
                            </th>
                            <td>
                                <telerik:RadTextBox ID="tbContactPerson" runat="server" 
                                    Text='<%# Bind("ContactPerson") %>' Width="130px" />
                            </td>
                            <th>
                                聯絡電話 
                            </th>
                            <td>
                                <telerik:RadTextBox ID="tbContactPhoneNumber" runat="server" 
                                    Text='<%# Bind("ContactPhoneNumber") %>' Width="130px" />
                            </td>
                            <tr>
                                <th>
                                    E-mail
                                    <td>
                                        <telerik:RadTextBox ID="sEmailTextBox" runat="server" 
                                            Text='<%# Bind("sEmail") %>' Width="100%" />
                                    </td>
                                    <th>
                                        外部講師密碼 
                                    </th>
                                    <td>
                                        帳號：<telerik:RadTextBox ID="sOuterTeacherIdTextBox" runat="server" 
                                            DisplayText="" LabelWidth="40%" Text='<%# Bind("sOuterTeacherId") %>' 
                                            type="text" value="" Width="100%" />
                                        密碼：<telerik:RadTextBox ID="sTeacherPWDTextBox" runat="server" 
                                            Text='<%# Bind("sTeacherPWD") %>' Width="100%" />
                                    </td>
                                    <th>
                                        手機 
                                    </th>
                                    <td>
                                        <telerik:RadTextBox ID="sCellPhoneTextBox" runat="server" 
                                            Text='<%# Bind("sCellPhone") %>' Width="100%" />
                                    </td>
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    學歷 
                                    <td colspan="5">
                                        <telerik:RadTextBox ID="sNote1TextBox0" runat="server" 
                                            Text='<%# Bind("sNote1") %>' TextMode="MultiLine" Width="98%" />
                                    </td>
                                    <tr>
                                        <th>
                                            工作經歷<td colspan="5">
                                                <telerik:RadTextBox ID="txtsWorkExp" runat="server" 
                                                    Text='<%# Bind("sWorkExp") %>' TextMode="MultiLine" Width="98%" />
                                            </td>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>
                                            授課經歷 
                                        </th>
                                    </tr>
                                    <td colspan="5">
                                        <telerik:RadTextBox ID="txtsTeachExp" runat="server" 
                                            Text='<%# Bind("sTeachExp") %>' TextMode="MultiLine" Width="98%" />
                                    </td>
                                    <tr>
                                        <th>
                                            專長 
                                        </th>
                                        <td colspan="5">
                                            <telerik:RadTextBox ID="txtsNote2" runat="server" Text='<%# Bind("sNote2") %>' 
                                                TextMode="MultiLine" Width="98%" />
                                        </td>
                                    </tr>
                                </th>
                            </tr>
                        </th>
                    </tr>
                </tr>
            </table>
            <br />
            &nbsp;<telerik:RadButton ID="rbtnInsert" runat="server" CommandName="Insert" Text="插入">
            </telerik:RadButton>
            &nbsp;&nbsp;
            <telerik:RadButton ID="rbtnCancel" runat="server" CommandName="Cancel" 
                Text="取消" ValidationGroup="G1">
            </telerik:RadButton>
        </InsertItemTemplate>
        <ItemTemplate>
            <asp:Label ID="iAutoKeyLabel" runat="server" Text='<%# Eval("iAutoKey") %>' />
            <table style="width: 100%;" class="tableBlue">
                <tr>
                    <th class="style1">
                        代碼
                    </th>
                    <th>
                        名稱
                    </th>
                    <th>
                        性別
                    </th>
                    <th>
                    信箱</td>
                </tr>
                <tr>
                    <td class="style1">
                        <telerik:RadTextBox Text='<%# Bind("sCode") %>' runat="server" ID="sCodeTextBox"
                            Width="130px" />
                        <asp:RequiredFieldValidator ID="rfv_sCode" runat="server" ControlToValidate="sCodeTextBox"
                            Display="Dynamic" ErrorMessage="*必要欄位" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <telerik:RadTextBox Text='<%# Bind("sName") %>' runat="server" ID="sNameTextBox" />
                        <asp:RequiredFieldValidator ID="rfv_sName" runat="server" ControlToValidate="sNameTextBox"
                            Display="Dynamic" ErrorMessage="*必要欄位" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="sSexRCBs" runat="server" SelectedValue='<%# Bind("sSex") %>'
                            ShowDropDownOnTextboxClick="False" ShowWhileLoading="False">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Owner="sSexRCBs" Text="男" Value="M" />
                                <telerik:RadComboBoxItem runat="server" Owner="sSexRCBs" Text="女" Value="F" />
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <telerik:RadTextBox Text='<%# Bind("sEmail") %>' runat="server" ID="sEmailTextBox" />
                    </td>
                </tr>
                <tr>
                    <th class="style1">
                        電話</td>
                        <th>
                            傳真</td>
                            <th>
                                手機</td>
                                <th>
                    工號</td>
                </tr>
                <tr>
                    <td class="style1">
                        <telerik:RadTextBox Text='<%# Bind("sTel") %>' runat="server" ID="sTelTextBox" Width="130px" />
                    </td>
                    <td>
                        <telerik:RadTextBox Text='<%# Bind("sFax") %>' runat="server" ID="sFaxTextBox" />
                    </td>
                    <td>
                        <telerik:RadTextBox Text='<%# Bind("sCallPhone") %>' runat="server" ID="sCallPhoneTextBox"
                            Width="150px" />
                    </td>
                    <td>
                        <telerik:RadTextBox Text='<%# Bind("sNobr") %>' runat="server" ID="sNobrTextBox" />
                    </td>
                </tr>
                <tr>
                    <th class="style1" colspan="2">
                        學經歷</td>
                        <th colspan="2">
                    專長</td>
                </tr>
                <tr>
                    <td class="style1" colspan="2">
                        <telerik:RadTextBox ID="sNote1TextBox" runat="server" Text='<%# Bind("sNote1") %>'
                            TextMode="MultiLine" Width="98%" />
                    </td>
                    <td colspan="2">
                        <telerik:RadTextBox ID="sNote2TextBox" runat="server" Text='<%# Bind("sNote2") %>'
                            TextMode="MultiLine" Width="99%" />
                    </td>
                </tr>
                <tr>
                    <th class="style2" colspan="4">
                    住址</td>
                </tr>
                <tr>
                    <td class="style1" colspan="4">
                        <telerik:RadTextBox ID="sAddrTextBox" runat="server" Text='<%# Bind("sAddr") %>'
                            TextMode="MultiLine" Width="99%" />
                    </td>
                </tr>
                <tr>
                    <th class="style1" colspan="4">
                    備註</tr>
                <tr>
                    <td class="style1" colspan="4">
                        <telerik:RadTextBox ID="sNote3TextBox" runat="server" Text='<%# Bind("sNote3") %>'
                            TextMode="MultiLine" Width="99%" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <br />
    <asp:SqlDataSource ID="sdsFV" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
        SelectCommand="SELECT * FROM [trTeacher] where iAutoKey = @iAutoKey" DeleteCommand="DELETE FROM [trTeacher] WHERE [iAutoKey] = @iAutoKey"
        InsertCommand="INSERT INTO [trTeacher] ([sCode], [sName], [sSex], [sEmail], [sTel], [sFax], [sCellPhone], [sAddr], [sNote1], [sNote2], [sNote3], [sNote4], [sNote5], [sNobr], [sKeyMan], [dKeyDate],
 [sTeacherID],[sCompanyID],[sWorkExp],[sTeachExp],[sTeacherPWD],[sOuterTeacherId],[CompanyName],[ContactPerson],[ContactPhoneNumber]) VALUES (@sCode, @sName, @sSex, @sEmail, @sTel, @sFax, @sCellPhone, @sAddr, @sNote1, @sNote2, @sNote3, @sNote4, @sNote5, @sNobr, @sKeyMan, @dKeyDate,@sTeacherID,@sCompanyID,@sWorkExp,@sTeachExp,@sTeacherPWD,@sOuterTeacherId,@CompanyName,@ContactPerson,@ContactPhoneNumber )"
        UpdateCommand="UPDATE [trTeacher] SET [sCode] = @sCode, [sName] = @sName, [sSex] = @sSex, [sEmail] = @sEmail, [sTel] = @sTel, [sFax] = @sFax, [sCellPhone] = @sCellPhone, [sAddr] = @sAddr, [sNote1] = @sNote1, [sNote2] = @sNote2, [sNote3] = @sNote3, [sNote4] = @sNote4, [sNote5] = @sNote5, [sNobr] = @sNobr, [sKeyMan] = @sKeyMan, [dKeyDate] = @dKeyDate , [sTeacherID]=@sTeacherID,[sCompanyID]=@sCompanyID,[sWorkExp]=@sWorkExp,[sTeachExp]=@sTeachExp,[bEntTeacherType]=@bEntTeacherType,[sTeacherPWD]=@sTeacherPWD,[sOuterTeacherId] = @sOuterTeacherId,[CompanyName] = @CompanyName,[ContactPerson]=@ContactPerson,[ContactPhoneNumber]=@ContactPhoneNumber
  WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sSex" Type="String" />
            <asp:Parameter Name="sEmail" Type="String" />
            <asp:Parameter Name="sTel" Type="String" />
            <asp:Parameter Name="sFax" Type="String" />
            <asp:Parameter Name="sCellPhone" />
            <asp:Parameter Name="sAddr" Type="String" />
            <asp:Parameter Name="sNote1" Type="String" />
            <asp:Parameter Name="sNote2" Type="String" />
            <asp:Parameter Name="sNote3" Type="String" />
            <asp:Parameter Name="sNote4" Type="String" />
            <asp:Parameter Name="sNote5" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="sTeacherID" />
            <asp:Parameter Name="sCompanyID" />
            <asp:Parameter Name="sWorkExp" />
            <asp:Parameter Name="sTeachExp" />
            <asp:Parameter Name="sTeacherPWD" />
            <asp:Parameter Name="sOuterTeacherId" />
            <asp:Parameter Name="CompanyName" />
            <asp:Parameter Name="ContactPerson" />
            <asp:Parameter Name="ContactPhoneNumber" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="iAutoKey" QueryStringField="iAutoKey" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="sCode" Type="String" />
            <asp:Parameter Name="sName" Type="String" />
            <asp:Parameter Name="sSex" Type="String" />
            <asp:Parameter Name="sEmail" Type="String" />
            <asp:Parameter Name="sTel" Type="String" />
            <asp:Parameter Name="sFax" Type="String" />
            <asp:Parameter Name="sCellPhone" />
            <asp:Parameter Name="sAddr" Type="String" />
            <asp:Parameter Name="sNote1" Type="String" />
            <asp:Parameter Name="sNote2" Type="String" />
            <asp:Parameter Name="sNote3" Type="String" />
            <asp:Parameter Name="sNote4" Type="String" />
            <asp:Parameter Name="sNote5" Type="String" />
            <asp:Parameter Name="sNobr" Type="String" />
            <asp:Parameter Name="sKeyMan" Type="String" />
            <asp:Parameter Name="dKeyDate" Type="DateTime" />
            <asp:Parameter Name="sTeacherID" />
            <asp:Parameter Name="sCompanyID" />
            <asp:Parameter Name="sWorkExp" />
            <asp:Parameter Name="sTeachExp" />
            <asp:Parameter Name="bEntTeacherType" />
            <asp:Parameter Name="sTeacherPWD" />
            <asp:Parameter Name="sOuterTeacherId" />
            <asp:Parameter Name="CompanyName" />
            <asp:Parameter Name="ContactPerson" />
            <asp:Parameter Name="ContactPhoneNumber" />
            <asp:QueryStringParameter DefaultValue="0" Name="iAutoKey" QueryStringField="iAutoKey" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            width: 148px;
        }
        .style2
        {
            width: 148px;
            height: 21px;
        }
    </style>
</asp:Content>
