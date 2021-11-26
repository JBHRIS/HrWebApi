<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ins_hr.aspx.cs" Inherits="ins_ins_hr" Title="HR_眷屬資料維護" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        <asp:Localize ID="Localize1" runat="server" 
            meta:resourcekey="Localize1Resource1" Text="保險資料核准"></asp:Localize>
    </h3>
    <table width="100%">
        <tr>
            <td style="width: 60%;">
                <telerik:RadDatePicker ID="adate" runat="server" Culture="zh-TW" 
                    meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" DisplayText="" LabelWidth="64px" 
                        Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                    ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="至" 
                    meta:resourcekey="Label2Resource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="zh-TW" 
                    meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" DisplayText="" LabelWidth="64px" 
                        Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                    ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>&nbsp;<asp:RadioButtonList
                        ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" 
                    Width="239px" meta:resourcekey="RadioButtonList1Resource1">
                        <asp:ListItem Selected="True" meta:resourcekey="ListItemResource1">只顯示未完成</asp:ListItem>
                        <asp:ListItem meta:resourcekey="ListItemResource2">顯示全部資料</asp:ListItem>
                    </asp:RadioButtonList>
            </td>
            <td style="height: 28px">
                <asp:Button ID="Button1" runat="server" Text="查詢" OnClick="Button1_Click" 
                    ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="NOBR"
                    DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" 
                    meta:resourcekey="GridView1Resource1">
                    <Columns>
                        <asp:BoundField DataField="Adate" DataFormatString="{0:d}" HeaderText="申請日期" HtmlEncode="False"
                            SortExpression="Adate" meta:resourcekey="BoundFieldResource1" />
                        <asp:BoundField DataField="NOBR" HeaderText="工號" ReadOnly="True" 
                            SortExpression="NOBR" meta:resourcekey="BoundFieldResource2" />
                        <asp:BoundField DataField="NAME_C" HeaderText="姓名" SortExpression="NAME_C" 
                            meta:resourcekey="BoundFieldResource3" />
                        <asp:BoundField DataField="IDNO" HeaderText="員工ID" SortExpression="IDNO" 
                            meta:resourcekey="BoundFieldResource4" />
                        <asp:BoundField DataField="FA_NAME" HeaderText="眷屬姓名" SortExpression="FA_NAME" 
                            meta:resourcekey="BoundFieldResource5" />
                        <asp:BoundField DataField="FA_IDNO" HeaderText="眷屬ID" SortExpression="FA_IDNO" 
                            meta:resourcekey="BoundFieldResource6" />
                        <asp:BoundField DataField="REL_NAME" HeaderText="關係" SortExpression="REL_NAME" 
                            meta:resourcekey="BoundFieldResource7" />
                        <asp:TemplateField HeaderText="生日" SortExpression="FA_BIRDT" 
                            meta:resourcekey="TemplateFieldResource1">
                            <ItemTemplate>
                                <asp:Label ID="AutoKey" runat="server" Text='<%# Bind("AutoKey") %>' 
                                    Visible="False" meta:resourcekey="AutoKeyResource1"></asp:Label>
                                異動後：
                                <br>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FA_BIRDT", "{0:d}") %>' 
                                    meta:resourcekey="Label2Resource2"></asp:Label>
                                <br>
                                異動前：
                                <br>
                                <asp:Label ID="o_FA_BIRDT" runat="server" ForeColor="Red" 
                                    meta:resourcekey="o_FA_BIRDTResource1"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FA_BIRDT") %>' 
                                    meta:resourcekey="TextBox1Resource1"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="扶養" SortExpression="TAX" 
                            meta:resourcekey="TemplateFieldResource2">
                            <ItemTemplate>
                                異動後：
                                <br>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("TAX") %>' 
                                    meta:resourcekey="Label3Resource1"></asp:Label>
                                <br>
                                異動前：<br>
                                <asp:Label ID="o_TAX" runat="server" ForeColor="Red" 
                                    meta:resourcekey="o_TAXResource1"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TAX") %>' 
                                    meta:resourcekey="TextBox2Resource1"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="健保" SortExpression="AUTOINSLAB" 
                            meta:resourcekey="TemplateFieldResource3">
                            <ItemTemplate>
                                異動後：<br>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("AUTOINSLAB") %>' 
                                    meta:resourcekey="Label4Resource1"></asp:Label>
                                <br>
                                異動前：<br>
                                <asp:Label ID="o_AUTOINSLAB" runat="server" ForeColor="Red" 
                                    meta:resourcekey="o_AUTOINSLABResource1"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AUTOINSLAB") %>' 
                                    meta:resourcekey="TextBox3Resource1"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="顯示" SortExpression="LIVE" 
                            meta:resourcekey="TemplateFieldResource4">
                            <ItemTemplate>
                                異動後：<br>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("LIVE") %>' 
                                    meta:resourcekey="Label5Resource1"></asp:Label>
                                <br>
                                異動前：<br>
                                <asp:Label ID="o_LIVE" runat="server" ForeColor="Red" 
                                    meta:resourcekey="o_LIVEResource1"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("LIVE") %>' 
                                    meta:resourcekey="TextBox4Resource1"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="團保" SortExpression="FAMFORN" 
                            meta:resourcekey="TemplateFieldResource5">
                            <ItemTemplate>
                                異動後：<br>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("FAMFORN") %>' 
                                    meta:resourcekey="Label6Resource1"></asp:Label>
                                <br>
                                異動前：<br>
                                <asp:Label ID="o_FAMFORN" runat="server" ForeColor="Red" 
                                    meta:resourcekey="o_FAMFORNResource1"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("FAMFORN") %>' 
                                    meta:resourcekey="TextBox5Resource1"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HR確認" SortExpression="HR_Check" 
                            meta:resourcekey="TemplateFieldResource6">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("HR_Check") %>' OnCheckedChanged="CheckBox1_CheckedChanged"
                                    AutoPostBack="True" meta:resourcekey="CheckBox1Resource2" />
                                <br />
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("HR_Check_Date") %>' 
                                    meta:resourcekey="Label1Resource1"></asp:Label>
                                <br />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("HR_Check") %>' 
                                    meta:resourcekey="CheckBox1Resource1" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ins_Type" HeaderText="狀態" SortExpression="ins_Type" 
                            meta:resourcekey="BoundFieldResource8" />
                        <asp:BoundField DataField="KEY_DATE" HeaderText="登入日" SortExpression="KEY_DATE" 
                            meta:resourcekey="BoundFieldResource9" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        SelectCommand="SELECT FAMILY_temp.Adate, BASE.NOBR,BASE.IDNO, BASE.NAME_C, FAMILY_temp.FA_NAME, FAMILY_temp.FA_IDNO, RELCODE.REL_NAME, FAMILY_temp.FA_BIRDT, FAMILY_temp.TAX, FAMILY_temp.AUTOINSLAB, FAMILY_temp.LIVE, FAMILY_temp.FAMFORN, FAMILY_temp.HR_Check, FAMILY_temp.HR_Check_Date, FAMILY_temp.ins_Type, FAMILY_temp.KEY_DATE, FAMILY_temp.AutoKey FROM FAMILY_temp INNER JOIN BASE ON FAMILY_temp.NOBR = BASE.NOBR LEFT OUTER JOIN RELCODE ON FAMILY_temp.REL_CODE = RELCODE.REL_CODE WHERE (FAMILY_temp.HR_Check = @check ) ORDER BY FAMILY_temp.Adate DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="false" Name="check" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="All_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        SelectCommand="SELECT FAMILY_temp.Adate, BASE.NOBR,BASE.IDNO, BASE.NAME_C, FAMILY_temp.FA_NAME, FAMILY_temp.FA_IDNO, RELCODE.REL_NAME, FAMILY_temp.FA_BIRDT, FAMILY_temp.TAX, FAMILY_temp.AUTOINSLAB, FAMILY_temp.LIVE, FAMILY_temp.FAMFORN, FAMILY_temp.HR_Check, FAMILY_temp.HR_Check_Date, FAMILY_temp.ins_Type, FAMILY_temp.KEY_DATE, FAMILY_temp.AutoKey FROM FAMILY_temp INNER JOIN BASE ON FAMILY_temp.NOBR = BASE.NOBR LEFT OUTER JOIN RELCODE ON FAMILY_temp.REL_CODE = RELCODE.REL_CODE 
where FAMILY_temp.KEY_DATE between @Adate and @Ddate
ORDER BY FAMILY_temp.Adate DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="adate" Name="Adate" PropertyName="SelectedDate" />
            <asp:ControlParameter ControlID="ddate" Name="Ddate" PropertyName="SelectedDate" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
