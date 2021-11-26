<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAbs2.aspx.cs" Inherits="Attendance_EmpAbs2" Title="特休資料" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--<div class="GreenForm" runat="server" id="mangDiv">
        
        <div class="GreenFormFooter">
            <span class="GFLeft">&nbsp;</span><span class="GFRight"></span>
        </div>
    </div>--%>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <h3>
                    <asp:Label ID="lblShowHeader" runat="server" Text="特休資料" meta:resourcekey="lblShowHeaderResource1"></asp:Label>
                </h3>

            <asp:RadioButtonList ID="rblCate" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                OnSelectedIndexChanged="rblCate_SelectedIndexChanged" 
            meta:resourcekey="rblCateResource1">
                <asp:ListItem Selected="True" Value="1" meta:resourcekey="ListItemResource1">明細</asp:ListItem>
                <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">彙總</asp:ListItem>
            </asp:RadioButtonList>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <h3>
                        <asp:Label ID="lblShowEmpLeaveHeader" runat="server" Text="員工請假資料" meta:resourcekey="lblShowEmpLeaveHeaderResource1"></asp:Label></h3>
                    <fieldset>
                        <legend>
                            <asp:Label ID="lblShowQueryHeader" runat="server" Text="查詢條件" meta:resourcekey="lblShowQueryHeaderResource1"></asp:Label></legend>
                        <asp:Label ID="lblAbsDate" runat="server" Text="請假日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                        <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                                DisplayText="" LabelWidth="40%" type="text" value="" Width="">
                            </DateInput>
                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                            ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                        <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                                DisplayText="" LabelWidth="40%" type="text" value="" Width="">
                            </DateInput>
                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                            ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" ValidationGroup="group_date"
                            meta:resourcekey="Button1Resource2" />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="匯出" meta:resourcekey="Button2Resource1" />
                        <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                    </fieldset>
                    <%--OnPageIndexChanging="GridView2_PageIndexChanging"--%>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" meta:resourceKey="GridView2Resource1" 
                        OnRowDataBound="GridView2_RowDataBound" SkinID="Yahoo" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="NOBR" HeaderText="NOBR" 
                                meta:resourceKey="BoundFieldResource11" SortExpression="NOBR" Visible="False" />
                            <asp:BoundField DataField="NAME_C" HeaderText="員工" 
                                meta:resourceKey="BoundFieldResource12" SortExpression="NAME_C" />
                            <asp:BoundField DataField="NAME_E" HeaderText="英文名" 
                                meta:resourceKey="BoundFieldResource25" />
                            <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" 
                                meta:resourceKey="BoundFieldResource13" SortExpression="JOB_NAME" />
                            <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" 
                                meta:resourceKey="BoundFieldResource14" SortExpression="D_NAME" 
                                Visible="False" />
                            <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" 
                                HeaderText="請假日期" HtmlEncode="False" meta:resourceKey="BoundFieldResource15" 
                                SortExpression="BDATE" />
                            <asp:BoundField DataField="BTIME" HeaderText="開始時間" 
                                meta:resourceKey="BoundFieldResource16" SortExpression="BTIME" />
                            <asp:BoundField DataField="ETIME" HeaderText="結束時間" 
                                meta:resourceKey="BoundFieldResource17" SortExpression="ETIME" />
                            <asp:BoundField DataField="H_CODE" HeaderText="H_CODE" 
                                meta:resourceKey="BoundFieldResource18" SortExpression="H_CODE" 
                                Visible="False" />
                            <asp:BoundField DataField="H_NAME" HeaderText="假別" 
                                meta:resourceKey="BoundFieldResource19" SortExpression="H_NAME" />
                            <asp:BoundField DataField="UNIT" HeaderText="單位" 
                                meta:resourceKey="BoundFieldResource20" SortExpression="UNIT" />
                            <asp:BoundField DataField="TOL_HOURS" HeaderText="請假時數" 
                                meta:resourceKey="BoundFieldResource21" SortExpression="TOL_HOURS" />
                            <asp:BoundField DataField="NOTE" HeaderText="備註" 
                                meta:resourceKey="BoundFieldResource23" SortExpression="NOTE" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                                meta:resourceKey="lb_emptyResource1" Text="＊無相關資料！！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    &nbsp;&nbsp;<br>
                    &nbsp; &nbsp; &nbsp;&nbsp;
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Button ID="btnSummurySearch" runat="server" OnClick="btnSummurySearch_Click"
                        Text="查詢" meta:resourcekey="btnSummurySearchResource1" />
                    <asp:Button ID="Button3" runat="server" meta:resourcekey="Button2Resource1" OnClick="Button3_Click"
                        Text="匯出Excel" />
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        meta:resourcekey="GridView2Resource1" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="nobr" HeaderText="員工工號" meta:resourcekey="BoundFieldResource1" />
                            <asp:BoundField DataField="name" HeaderText="員工姓名" meta:resourcekey="BoundFieldResource2" />
                            <asp:BoundField DataField="name_e" HeaderText="英文名" 
                                meta:resourcekey="BoundFieldResource3" />
                            <asp:BoundField DataField="indt" HeaderText="到職日" meta:resourcekey="BoundFieldResource3" />
                            <asp:BoundField DataField="dept" HeaderText="部門" meta:resourcekey="BoundFieldResource4" />
                            <asp:BoundField DataField="a1" HeaderText="去年度剩餘年假" meta:resourcekey="BoundFieldResource5"
                                Visible="False" />
                            <asp:BoundField DataField="a2" HeaderText="今年度年假" meta:resourcekey="BoundFieldResource6" />
                            <asp:BoundField DataField="a3" HeaderText="今年已請時數" meta:resourcekey="BoundFieldResource7" />
                            <asp:BoundField DataField="a4" HeaderText="可累計之時數" meta:resourcekey="BoundFieldResource8"
                                Visible="False" />
                            <asp:BoundField DataField="a5" HeaderText="今年度剩餘時數" meta:resourcekey="BoundFieldResource9" />
                            <asp:BoundField DataField="a6" HeaderText="本月份已請時數" meta:resourcekey="BoundFieldResource10" />
                            <asp:BoundField DataField="a7" HeaderText="去年度剩餘年假未休時數" meta:resourcekey="BoundFieldResource11"
                                Visible="False">
                                <ItemStyle ForeColor="Red" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </asp:View>
            </asp:MultiView>
            <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
            <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C,NAME_AD, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
    <%--
    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
            <asp:Label ID="lblShowPageComment" runat="server"
                Text="程式說明" meta:resourcekey="lblShowPageCommentResource1"></asp:Label></span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <br />
            <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" 
                ForeColor="#FF3300" ReadOnly="True" Rows="10" TextMode="MultiLine" 
                Width="100%" meta:resourcekey="TextBox1Resource1" Text="1.查詢員工特休相關資料 (不含在途中時數)！
2.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！
3.輸入日期格式為西元年！例 2008/12/31&nbsp; ,也可點選欄位『日曆 圖案』可直接點選！
"></asp:TextBox>
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
