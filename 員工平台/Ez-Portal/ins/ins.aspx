<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ins.aspx.cs" Inherits="ins_ins" Title="FEFC EZ-Portal" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../Employee/EmpFamilyInfo.ascx" TagName="EmpFamilyInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
        DataKeyNames="NOBR,FA_IDNO" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"
        OnRowDataBound="GridView2_RowDataBound" 
        meta:resourcekey="GridView2Resource1">
        <Columns>
            <asp:CommandField ShowSelectButton="True" 
                meta:resourcekey="CommandFieldResource1" />
            <asp:BoundField DataField="FA_NAME" HeaderText="眷屬姓名" SortExpression="FA_NAME" 
                meta:resourcekey="BoundFieldResource1" />
            <asp:BoundField DataField="REL_NAME" HeaderText="關係" SortExpression="REL_NAME" 
                meta:resourcekey="BoundFieldResource2" />
            <asp:BoundField DataField="FA_BIRDT" DataFormatString="{0:yyyy/MM/dd}" HeaderText="眷屬生日"
                SortExpression="FA_BIRDT" meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="FA_IDNO" HeaderText="眷屬身份證" SortExpression="FA_IDNO" 
                meta:resourcekey="BoundFieldResource4" />
            <asp:CheckBoxField DataField="TAX" HeaderText="扶養眷屬" SortExpression="TAX" 
                meta:resourcekey="CheckBoxFieldResource1" />
            <asp:CheckBoxField DataField="AUTOINSLAB" HeaderText="附加健保" 
                SortExpression="AUTOINSLAB" meta:resourcekey="CheckBoxFieldResource2" />
            <asp:CheckBoxField DataField="FAMFORN" HeaderText="附加團保" 
                SortExpression="FAMFORN" meta:resourcekey="CheckBoxFieldResource3" />
            <asp:TemplateField HeaderText="不顯示於主管查詢" SortExpression="LIVE" 
                meta:resourcekey="TemplateFieldResource1">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("LIVE") %>' 
                        meta:resourcekey="CheckBox1Resource1" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("LIVE") %>' OnCheckedChanged="CheckBox1_CheckedChanged"
                        ValidationGroup='<%# Eval("FA_IDNO") %>' AutoPostBack="True" 
                        ToolTip='<%# Eval("NOBR") %>' meta:resourcekey="CheckBox1Resource2" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        SelectCommand="SELECT FAMILY.FA_NAME,FAMILY.NOBR, RELCODE.REL_NAME, FAMILY.FA_BIRDT, FAMILY.FA_IDNO, FAMILY.AUTOINSLAB, FAMILY.TAX, FAMILY.FAMFORN, FAMILY.LIVE FROM FAMILY INNER JOIN RELCODE ON FAMILY.REL_CODE = RELCODE.REL_CODE WHERE (FAMILY.NOBR = @NOBR) ORDER BY FAMILY.REL_CODE">
        <SelectParameters>
            <asp:ControlParameter ControlID="lb_nobr" Name="NOBR" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lb_nobr" runat="server" Visible="False" 
        meta:resourcekey="lb_nobrResource1"></asp:Label>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="申請記錄" 
        meta:resourcekey="Button1Resource1" /><asp:Button
        ID="Button2" runat="server" OnClick="Button2_Click" Text="維護眷屬資料" 
        meta:resourcekey="Button2Resource1" /><asp:MultiView
            ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <fieldset>
                    <legend>
                        <asp:Localize ID="Localize1" runat="server" 
                            meta:resourcekey="Localize1Resource1" Text="申請記錄"></asp:Localize></legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AutoKey"
                        DataSourceID="ObjectDataSource1" OnRowDeleting="GridView1_RowDeleting" 
                        meta:resourcekey="GridView1Resource1">
                        <Columns>
                            <asp:BoundField DataField="Adate" HeaderText="申請日" SortExpression="Adate" 
                                meta:resourcekey="BoundFieldResource5" />
                            <asp:BoundField DataField="ins_Type" HeaderText="狀態" SortExpression="ins_Type" 
                                meta:resourcekey="BoundFieldResource6" />
                            <asp:BoundField DataField="FA_IDNO" HeaderText="眷屬身分證" SortExpression="FA_IDNO" 
                                meta:resourcekey="BoundFieldResource7" />
                            <asp:BoundField DataField="FA_NAME" HeaderText="眷屬姓名" SortExpression="FA_NAME" 
                                meta:resourcekey="BoundFieldResource8" />
                            <asp:BoundField DataField="FA_BIRDT" HeaderText="眷屬生日" SortExpression="FA_BIRDT"
                                DataFormatString="{0:yyyy/MM/dd}" meta:resourcekey="BoundFieldResource9" />
                            <asp:BoundField DataField="BBC" HeaderText="關係" SortExpression="BBC" 
                                meta:resourcekey="BoundFieldResource10" />
                            <asp:BoundField DataField="TAX" HeaderText="扶養眷屬" SortExpression="TAX" 
                                meta:resourcekey="BoundFieldResource11" />
                            <asp:BoundField DataField="AUTOINSLAB" HeaderText="附加健保" 
                                SortExpression="AUTOINSLAB" meta:resourcekey="BoundFieldResource12" />
                            <asp:BoundField DataField="ADDR" HeaderText="合於健保投保條件" SortExpression="ADDR" 
                                meta:resourcekey="BoundFieldResource13" />
                            <asp:BoundField DataField="GSM" HeaderText="身份別" SortExpression="GSM" 
                                meta:resourcekey="BoundFieldResource14" />
                            <asp:BoundField DataField="FAMFORN" HeaderText="附加團保" SortExpression="FAMFORN" 
                                meta:resourcekey="BoundFieldResource15" />
                            <asp:BoundField DataField="LIVE" HeaderText="顯示於主管查詢" SortExpression="LIVE" 
                                meta:resourcekey="BoundFieldResource16" />
                            <asp:BoundField DataField="REL_CODE" HeaderText="REL_CODE" SortExpression="REL_CODE"
                                Visible="False" meta:resourcekey="BoundFieldResource17" />
                            <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" 
                                Visible="False" meta:resourcekey="BoundFieldResource18" />
                            <asp:BoundField DataField="KEY_DATE" HeaderText="KEY_DATE" SortExpression="KEY_DATE"
                                Visible="False" meta:resourcekey="BoundFieldResource19" />
                            <asp:BoundField DataField="KEY_MAN" HeaderText="KEY_MAN" SortExpression="KEY_MAN"
                                Visible="False" meta:resourcekey="BoundFieldResource20" />
                            <asp:BoundField DataField="TEL" HeaderText="TEL" SortExpression="TEL" 
                                Visible="False" meta:resourcekey="BoundFieldResource21" />
                            <asp:BoundField DataField="EDUCODE" HeaderText="EDUCODE" SortExpression="EDUCODE"
                                Visible="False" meta:resourcekey="BoundFieldResource22" />
                            <asp:BoundField DataField="COMPNY" HeaderText="COMPNY" SortExpression="COMPNY" 
                                Visible="False" meta:resourcekey="BoundFieldResource23" />
                            <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE" 
                                Visible="False" meta:resourcekey="BoundFieldResource24" />
                            <asp:BoundField DataField="AutoKey" HeaderText="AutoKey" ReadOnly="True" SortExpression="AutoKey"
                                Visible="False" meta:resourcekey="BoundFieldResource25" />
                            <asp:TemplateField HeaderText="HR確認" SortExpression="HR_Check" 
                                meta:resourcekey="TemplateFieldResource2">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("HR_Check") %>' 
                                        meta:resourcekey="CheckBox1Resource3" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("HR_Check") %>' 
                                        Enabled="False" meta:resourcekey="CheckBox1Resource4" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HR_Check_Date" HeaderText="HR確認時間" 
                                SortExpression="HR_Check_Date" meta:resourcekey="BoundFieldResource26" />
                            <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource3">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        OnClientClick="return confirm(&quot;確認要刪除？&quot;);" Text="刪除" 
                                        meta:resourcekey="LinkButton1Resource1"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
                        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
                        TypeName="insDSTableAdapters.FAMILY_tempTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_AutoKey" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="FA_IDNO" Type="String" />
                            <asp:Parameter Name="FA_NAME" Type="String" />
                            <asp:Parameter Name="REL_CODE" Type="String" />
                            <asp:Parameter Name="FA_BIRDT" Type="DateTime" />
                            <asp:Parameter Name="NOBR" Type="String" />
                            <asp:Parameter Name="KEY_DATE" Type="DateTime" />
                            <asp:Parameter Name="KEY_MAN" Type="String" />
                            <asp:Parameter Name="ADDR" Type="String" />
                            <asp:Parameter Name="TEL" Type="String" />
                            <asp:Parameter Name="GSM" Type="String" />
                            <asp:Parameter Name="BBC" Type="String" />
                            <asp:Parameter Name="TAX" Type="String" />
                            <asp:Parameter Name="AUTOINSLAB" Type="String" />
                            <asp:Parameter Name="LIVE" Type="String" />
                            <asp:Parameter Name="EDUCODE" Type="String" />
                            <asp:Parameter Name="COMPNY" Type="String" />
                            <asp:Parameter Name="TITLE" Type="String" />
                            <asp:Parameter Name="FAMFORN" Type="String" />
                            <asp:Parameter Name="AutoKey" Type="Int32" />
                            <asp:Parameter Name="HR_Check" Type="Boolean" />
                            <asp:Parameter Name="HR_Check_Date" Type="DateTime" />
                            <asp:Parameter Name="ins_Type" Type="String" />
                            <asp:Parameter Name="Adate" Type="DateTime" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="FA_IDNO" Type="String" />
                            <asp:Parameter Name="FA_NAME" Type="String" />
                            <asp:Parameter Name="REL_CODE" Type="String" />
                            <asp:Parameter Name="FA_BIRDT" Type="DateTime" />
                            <asp:Parameter Name="NOBR" Type="String" />
                            <asp:Parameter Name="KEY_DATE" Type="DateTime" />
                            <asp:Parameter Name="KEY_MAN" Type="String" />
                            <asp:Parameter Name="ADDR" Type="String" />
                            <asp:Parameter Name="TEL" Type="String" />
                            <asp:Parameter Name="GSM" Type="String" />
                            <asp:Parameter Name="BBC" Type="String" />
                            <asp:Parameter Name="TAX" Type="String" />
                            <asp:Parameter Name="AUTOINSLAB" Type="String" />
                            <asp:Parameter Name="LIVE" Type="String" />
                            <asp:Parameter Name="EDUCODE" Type="String" />
                            <asp:Parameter Name="COMPNY" Type="String" />
                            <asp:Parameter Name="TITLE" Type="String" />
                            <asp:Parameter Name="FAMFORN" Type="String" />
                            <asp:Parameter Name="HR_Check" Type="Boolean" />
                            <asp:Parameter Name="HR_Check_Date" Type="DateTime" />
                            <asp:Parameter Name="ins_Type" Type="String" />
                            <asp:Parameter Name="Adate" Type="DateTime" />
                            <asp:Parameter Name="Original_AutoKey" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </fieldset>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <fieldset>
                    <legend>
                        <asp:Localize ID="Localize2" runat="server" 
                            meta:resourcekey="Localize2Resource1" Text="眷屬資料維護"></asp:Localize></legend>
                    <br />
                    眷屬姓名：<asp:TextBox ID="tb_f_name" runat="server" 
                        meta:resourcekey="tb_f_nameResource1"></asp:TextBox><br />
                    眷屬關係：<asp:DropDownList ID="ddl_f_re" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="REL_NAME" DataValueField="REL_CODE" 
                        meta:resourcekey="ddl_f_reResource1">
                    </asp:DropDownList>
                    <br />
                    合於健保投保條件：<asp:DropDownList ID="DropDownList2" runat="server" 
                        meta:resourcekey="DropDownList2Resource1">
                        <asp:ListItem meta:resourcekey="ListItemResource1"></asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource2">隨同被保險人加保</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource3">喪失被保險人身份</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource4">新生嬰兒</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource5">結婚</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource6">收養</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource7">更新所依附之被保險人</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource8">A領有殘障手冊且不能自謀生活</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource9">G應屆畢業或股兵役退伍且無職業</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource10">P受禁治產宣告尚未撤銷</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource11">S在學就讀且無職業</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" 
                        Text="＊子女為&quot;新生嬰兒&quot;請至HR填寫『請領健保IC卡申請表』" 
                        meta:resourcekey="Label3Resource1"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" 
                        Text="＊子女為｢在學就讀且無職業｣【請影印學生證送至HR】" meta:resourcekey="Label4Resource1"></asp:Label>
                    <br />
                    眷屬生日：
                    <telerik:RadDatePicker ID="tb_f_br" runat="server" FocusedDate="1911-01-01" 
                        MinDate="1911-01-01" Culture="zh-TW" meta:resourcekey="tb_f_brResource1">
                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                            ViewSelectorText="x">
                        </Calendar>
                        <DateInput DateFormat="yyyy/M/d" DisplayDateFormat="yyyy/M/d" DisplayText="" 
                            LabelWidth="64px">
                        </DateInput>
                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                    </telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_f_br"
                        Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                        ValidationGroup="group_date" 
                        meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;<br />
                    眷屬身分證：<asp:TextBox ID="tb_f_idno" runat="server" 
                        meta:resourcekey="tb_f_idnoResource1"></asp:TextBox><br />
                    <br />
                    所得稅扶養眷屬：<asp:DropDownList ID="ddl_f_tax" runat="server" 
                        meta:resourcekey="ddl_f_taxResource1">
                        <asp:ListItem Value="不扶養" meta:resourcekey="ListItemResource12">不扶養</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource13">扶養</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    附加健保：<asp:DropDownList ID="ddl_t_h" runat="server" 
                        meta:resourcekey="ddl_t_hResource1">
                        <asp:ListItem Value="不加保" meta:resourcekey="ListItemResource14">不加保</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource15">加保</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    身份別：<asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3"
                        DataTextField="RATE_NAME" DataValueField="RATE_CODE" 
                        meta:resourcekey="DropDownList3Resource1">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                        SelectCommand="SELECT RATE_CODE, RATE_NAME FROM HARCODE ORDER BY RATE_CODE">
                    </asp:SqlDataSource>
                    <br />
                    附加團保：<asp:DropDownList ID="ddl_f_t" runat="server" 
                        meta:resourcekey="ddl_f_tResource1">
                        <asp:ListItem Value="不加保" meta:resourcekey="ListItemResource16">不加保</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource17">加保</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    不顯示於主管查詢：<asp:DropDownList ID="ddl_f_v" runat="server" 
                        meta:resourcekey="ddl_f_vResource1">
                        <asp:ListItem meta:resourcekey="ListItemResource18">顯示</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource19">不顯示</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="申請眷屬資料異動" 
                        Width="116px" meta:resourcekey="Button4Resource1" />
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="系統主動e-Mail通知HR" 
                        meta:resourcekey="Label2Resource1"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" 
                        Text="備註:眷屬健保加保轉入者，請提供退保書面資料，送至人資部，確認是否須追溯加保區間和追收保費;眷屬已轉換投保單位，但仍然在公司加保者，轉出且須退還保費者，亦同．" 
                        meta:resourcekey="Label1Resource1"></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                        SelectCommand="SELECT [REL_CODE], [REL_NAME] FROM [RELCODE]"></asp:SqlDataSource>
                    <br />
                </fieldset>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <fieldset>
                    <legend>
                        <asp:Localize ID="Localize3" runat="server" 
                            meta:resourcekey="Localize3Resource1" Text="修改眷屬資料"></asp:Localize></legend>
                </fieldset>
            </asp:View>
        </asp:MultiView>
</asp:Content>
