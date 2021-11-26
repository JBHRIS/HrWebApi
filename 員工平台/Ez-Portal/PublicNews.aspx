<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PublicNews.aspx.cs" Inherits="PublicNews" Title="Untitled Page" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <h3>
        <asp:Localize ID="Localize1" runat="server" meta:resourcekey="Localize1Resource1"
            Text="公佈訊息"></asp:Localize>
    </h3>
    <fieldset>
        <legend>
            <asp:Localize ID="Localize4" runat="server" meta:resourcekey="Localize1Resource1"
                Text="查詢條件"></asp:Localize></legend>
        <asp:Label ID="Label1" runat="server" Text="查詢日期：" meta:resourcekey="Label1Resource1"></asp:Label>
        &nbsp;<telerik:RadDatePicker ID="rdpBdate" runat="server" Culture="(Default)">
            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
            </Calendar>
            <DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText=""
                LabelWidth="40%" type="text" value="" Width="">
            </DateInput>
            <DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
        </telerik:RadDatePicker>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdpBdate"
            Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
        <asp:Localize ID="Localize5" runat="server" meta:resourcekey="Localize2Resource1"
            Text="至"></asp:Localize>
        <telerik:RadDatePicker ID="rdpEdate" runat="server" Culture="(Default)">
            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
            </Calendar>
            <DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText=""
                LabelWidth="40%" type="text" value="" Width="">
            </DateInput>
            <DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
        </telerik:RadDatePicker>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdpEdate"
            Display="Dynamic" ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date" />
        &nbsp;</fieldset>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
        AutoGenerateColumns="False" DataKeyNames="news_id" PageSize="5" SkinID="Yahoo"
        Width="90%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" meta:resourcekey="GridView1Resource1"
        OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select"
                        Text="選取" meta:resourcekey="Button1Resource1" />
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:BoundField DataField="news_id" HeaderText="文號" ReadOnly="True" SortExpression="news_id"
                meta:resourcekey="BoundFieldResource1">
                <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="news_head" HeaderText="主旨" SortExpression="news_head"
                meta:resourcekey="BoundFieldResource2">
                <ItemStyle Width="50%" />
            </asp:BoundField>
            <asp:BoundField DataField="news_body" HeaderText="內容" HtmlEncode="False" SortExpression="news_body"
                Visible="False" meta:resourcekey="BoundFieldResource3">
                <ItemStyle Width="40%" />
            </asp:BoundField>
            <asp:BoundField DataField="post_date" HeaderText="發佈日期" SortExpression="post_date"
                meta:resourcekey="BoundFieldResource4" />
            <asp:CheckBoxField DataField="is_on" HeaderText="發佈" SortExpression="is_on" Visible="False"
                meta:resourcekey="CheckBoxFieldResource1">
                <ItemStyle Width="10%" />
            </asp:CheckBoxField>
            <asp:BoundField DataField="AttachmentCount" HeaderText="附件筆數" SortExpression="AttachmentCount"
                meta:resourcekey="BoundFieldResource5">
                <ItemStyle Width="10%" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="BrowsingNumber" HeaderText="點閱人次">
                <ItemStyle Width="10%" HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <h3>
        <asp:Localize ID="Localize2" runat="server" meta:resourcekey="Localize2Resource1"
            Text="訊息內容 "></asp:Localize>
    </h3>
    <asp:FormView ID="FormView1" runat="server" CellPadding="4" DataKeyNames="news_id"
        DataSourceID="SqlDataSource2" ForeColor="#333333" Width="80%" meta:resourcekey="FormView1Resource1"
        OnDataBinding="FormView1_DataBinding">
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#E3EAEB" />
        <EditItemTemplate>
            文號:
            <asp:Label ID="news_idLabel1" runat="server" Text='<%# Eval("news_id") %>' meta:resourcekey="news_idLabel1Resource1"></asp:Label>
            &nbsp; &nbsp; &nbsp;&nbsp; 發佈:
            <asp:CheckBox ID="is_onCheckBox" runat="server" Checked='<%# Bind("is_on") %>' meta:resourcekey="is_onCheckBoxResource1" /><br />
            主旨:
            <asp:TextBox ID="news_headTextBox" runat="server" Text='<%# Bind("news_head") %>'
                Width="378px" meta:resourcekey="news_headTextBoxResource1"></asp:TextBox><br />
            內容:
            <telerik:RadEditor ID="FreeTextBox1" runat="server" Language="zh-TW" meta:resourcekey="FreeTextBox1Resource1">
                <Content>
                </Content>
                <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" meta:resourcekey="UpdateButtonResource1" />
            <asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="取消" meta:resourcekey="UpdateCancelButtonResource1" />
        </EditItemTemplate>
        <InsertItemTemplate>
            文號:
            <asp:TextBox ID="news_idTextBox" runat="server" Text='<%# Bind("news_id") %>' meta:resourcekey="news_idTextBoxResource1"></asp:TextBox>
            &nbsp; 發佈:
            <asp:CheckBox ID="is_onCheckBox" runat="server" Checked='<%# Bind("is_on") %>' meta:resourcekey="is_onCheckBoxResource2" /><br />
            主旨:
            <asp:TextBox ID="news_headTextBox" runat="server" Text='<%# Bind("news_head") %>'
                Width="430px" meta:resourcekey="news_headTextBoxResource2"></asp:TextBox><br />
            內容:&nbsp;
            <telerik:RadEditor ID="FreeTextBox1" runat="server" Language="zh-TW" meta:resourcekey="FreeTextBox1Resource2">
                <Content>
                </Content>
                <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" meta:resourcekey="InsertButtonResource1" />
            <asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="取消" meta:resourcekey="InsertCancelButtonResource1" />
        </InsertItemTemplate>
        <ItemTemplate>
            文號:
            <asp:Label ID="news_idLabel" runat="server" Text='<%# Eval("news_id") %>' meta:resourcekey="news_idLabelResource1"></asp:Label>
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;發佈日期:
            <asp:Label ID="post_dateLabel" runat="server" Text='<%# Bind("post_date") %>' meta:resourcekey="post_dateLabelResource1"></asp:Label><br />
            主旨:
            <asp:Label ID="news_headLabel" runat="server" Text='<%# Bind("news_head") %>' meta:resourcekey="news_headLabelResource1"></asp:Label><br />
            內容:
            <br />
            <asp:Label ID="news_bodyLabel" runat="server" Text='<%# Bind("news_body") %>' meta:resourcekey="news_bodyLabelResource1"></asp:Label><br />
            <asp:Label ID="newsfileid_Label" runat="server" Text='<%# Bind("newsfileid") %>'
                Visible="False" meta:resourcekey="newsfileid_LabelResource1"></asp:Label><br />
            <h3>
                <asp:Localize ID="Localize3" runat="server" meta:resourcekey="Localize3Resource1"
                    Text="附件"></asp:Localize>
            </h3>
            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource3" RepeatColumns="1"
                OnSelectedIndexChanged="DataList1_SelectedIndexChanged" meta:resourcekey="DataList1Resource1">
                <ItemTemplate>
                    <table border="1" bordercolor="#eeeeee" style="border-collapse: collapse; width: 100%">
                        <tr>
                            <td align="center" rowspan="5" style="width: 50px">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/btn_action-log_bg.gif" meta:resourcekey="Image1Resource1" />
                                <br />
                            </td>
                            <td style="color: #000000" width="100">
                                檔案名稱：
                            </td>
                            <td>
                                <asp:Label ID="upfilenameLabel" runat="server" meta:resourcekey="upfilenameLabelResource2"
                                    Text='<%# Eval("upfilename") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                檔案大小：
                            </td>
                            <td>
                                <asp:Label ID="filesizeLabel" runat="server" meta:resourcekey="filesizeLabelResource2"
                                    Text='<%# Eval("filesize") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                上傳日期：
                            </td>
                            <td>
                                <asp:Label ID="upfiledateLabel" runat="server" meta:resourcekey="upfiledateLabelResource2"
                                    Text='<%# Eval("upfiledate") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                檔案說明：
                            </td>
                            <td>
                                <asp:Label ID="filetypeLabel" runat="server" meta:resourcekey="filetypeLabelResource2"
                                    Text='<%# Eval("filedesc") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("serverfilename") %>'
                                    CommandName="Select" meta:resourcekey="LinkButton2Resource1">下載檔案</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="fileServerName" runat="server" meta:resourcekey="fileServerNameResource1"
                        Text='<%# Eval("serverfilename") %>' Visible="False"></asp:Label>
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT newsfileid, upfilename, serverfilename, filetype, filesize, upfiledate, filedesc FROM UPFILE WHERE (newsfileid = @newsfileid)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="newsfileid_Label" Name="newsfileid" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </ItemTemplate>
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            &nbsp;
        </EmptyDataTemplate>
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <InsertRowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#E3EAEB" />
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        DeleteCommand="DELETE FROM [news] WHERE [news_id] = @news_id" InsertCommand="INSERT INTO [news] ([news_id], [news_head], [news_body], [post_date], [is_on]) VALUES (@news_id, @news_head, @news_body, @post_date, @is_on)"
        SelectCommand="SELECT * FROM [news] WHERE ([news_id] = @news_id)" UpdateCommand="UPDATE [news] SET [news_head] = @news_head, [news_body] = @news_body, [post_date] = @post_date, [is_on] = @is_on WHERE [news_id] = @news_id">
        <SelectParameters>
            <asp:ControlParameter ControlID="lb_newid" Name="news_id" PropertyName="Text" Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="news_id" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="news_head" Type="String" />
            <asp:Parameter Name="news_body" Type="String" />
            <asp:Parameter Name="post_date" Type="DateTime" />
            <asp:Parameter Name="is_on" Type="Boolean" />
            <asp:Parameter Name="news_id" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="news_id" Type="String" />
            <asp:Parameter Name="news_head" Type="String" />
            <asp:Parameter Name="news_body" Type="String" />
            <asp:Parameter Name="post_date" Type="DateTime" />
            <asp:Parameter Name="is_on" Type="Boolean" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        DeleteCommand="DELETE FROM [news] WHERE [news_id] = @news_id" InsertCommand="INSERT INTO [news] ([news_id], [news_head], [news_body], [post_date], [is_on]) VALUES (@news_id, @news_head, @news_body, @post_date, @is_on)"
        SelectCommand="SELECT *
FROM [news] 
where (post_deadline &gt; GETDATE() or post_deadline is null) and is_on=1
order by sort desc
" UpdateCommand="UPDATE [news] SET [news_head] = @news_head, [news_body] = @news_body, [post_date] = @post_date, [is_on] = @is_on WHERE [news_id] = @news_id">
        <DeleteParameters>
            <asp:Parameter Name="news_id" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="news_head" Type="String" />
            <asp:Parameter Name="news_body" Type="String" />
            <asp:Parameter Name="post_date" Type="DateTime" />
            <asp:Parameter Name="is_on" Type="Boolean" />
            <asp:Parameter Name="news_id" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="news_id" Type="String" />
            <asp:Parameter Name="news_head" Type="String" />
            <asp:Parameter Name="news_body" Type="String" />
            <asp:Parameter Name="post_date" Type="DateTime" />
            <asp:Parameter Name="is_on" Type="Boolean" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        DeleteCommand="DELETE FROM [news] WHERE [news_id] = @news_id" InsertCommand="INSERT INTO [news] ([news_id], [news_head], [news_body], [post_date], [is_on]) VALUES (@news_id, @news_head, @news_body, @post_date, @is_on)"
        SelectCommand="SELECT *,(SELECT         COUNT(*) AS c
                                FROM              upfile
                                WHERE          newsfileid = news.newsfileid) AS filecount 
FROM [news] 
where (post_deadline &gt; GETDATE() or post_deadline is null) and is_on=1" UpdateCommand="UPDATE [news] SET [news_head] = @news_head, [news_body] = @news_body, [post_date] = @post_date, [is_on] = @is_on WHERE [news_id] = @news_id">
        <DeleteParameters>
            <asp:Parameter Name="news_id" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="news_head" Type="String" />
            <asp:Parameter Name="news_body" Type="String" />
            <asp:Parameter Name="post_date" Type="DateTime" />
            <asp:Parameter Name="is_on" Type="Boolean" />
            <asp:Parameter Name="news_id" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="news_id" Type="String" />
            <asp:Parameter Name="news_head" Type="String" />
            <asp:Parameter Name="news_body" Type="String" />
            <asp:Parameter Name="post_date" Type="DateTime" />
            <asp:Parameter Name="is_on" Type="Boolean" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lb_newid" runat="server" Visible="False" meta:resourcekey="lb_newidResource1"></asp:Label>
</asp:Content>
