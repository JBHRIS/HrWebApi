<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAnnualLeave_hr.aspx.cs" Inherits="HR_Mang_EmpAnnualLeave_hr" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
    <%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
           <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
            <h3>
                <asp:Label ID="lblShowDepartment" runat="server" Text="部門資料" meta:resourcekey="lblShowDepartmentResource1"></asp:Label>
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
                        <asp:Label ID="lblShowEmpLeaveHeader" runat="server" Text="員工請假資料" meta:resourcekey="lblShowEmpLeaveHeaderResource1"></asp:Label>
                    </h3>
                    <fieldset>
                        <legend>
                            <asp:Label ID="lblShowQueryHeader" runat="server" Text="查詢條件" meta:resourcekey="lblShowQueryHeaderResource1"></asp:Label></legend>
                        <asp:Label ID="lblAbsDate" runat="server" Text="請假日期：" meta:resourcekey="Label1Resource1"></asp:Label>
                        <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                            meta:resourcekey="adateResource1">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                ViewSelectorText="x">
                            </Calendar>
                            <DateInput Skin="" DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                                DisplayText="" LabelWidth="64px" Width="">
                            </DateInput>
                            <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                            ErrorMessage="日期格式錯誤！" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="至" meta:resourcekey="Label2Resource1"></asp:Label>
                        <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                            meta:resourcekey="ddateResource1">
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
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        SkinID="Yahoo" OnPageIndexChanging="GridView2_PageIndexChanging" meta:resourcekey="GridView2Resource1"
                        OnRowDataBound="GridView2_RowDataBound" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" Visible="False"
                                meta:resourcekey="BoundFieldResource11" />
                            <asp:BoundField DataField="NAME_C" HeaderText="員工" SortExpression="NAME_C" meta:resourcekey="BoundFieldResource12" />
                            <asp:BoundField DataField="NAME_E" HeaderText="英文名" meta:resourcekey="BoundFieldResource25" />
                            <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" SortExpression="JOB_NAME" meta:resourcekey="BoundFieldResource13" />
                            <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" Visible="False"
                                meta:resourcekey="BoundFieldResource14" />
                            <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="請假日期"
                                HtmlEncode="False" SortExpression="BDATE" meta:resourcekey="BoundFieldResource15" />
                            <asp:BoundField DataField="BTIME" HeaderText="開始時間" SortExpression="BTIME" meta:resourcekey="BoundFieldResource16" />
                            <asp:BoundField DataField="ETIME" HeaderText="結束時間" SortExpression="ETIME" meta:resourcekey="BoundFieldResource17" />
                            <asp:BoundField DataField="H_CODE" HeaderText="H_CODE" SortExpression="H_CODE" Visible="False"
                                meta:resourcekey="BoundFieldResource18" />
                            <asp:BoundField DataField="H_NAME" HeaderText="假別" SortExpression="H_NAME" meta:resourcekey="BoundFieldResource19" />
                            <asp:BoundField DataField="UNIT" HeaderText="單位" SortExpression="UNIT" meta:resourcekey="BoundFieldResource20" />
                            <asp:BoundField DataField="TOL_HOURS" HeaderText="請假時數" SortExpression="TOL_HOURS"
                                meta:resourcekey="BoundFieldResource21" />
                            <asp:BoundField DataField="NOTE" HeaderText="備註" SortExpression="NOTE" meta:resourcekey="BoundFieldResource23" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                                meta:resourcekey="lb_emptyResource1"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Button ID="btnSummurySearch" runat="server" OnClick="btnSummurySearch_Click"
                        Text="查詢" meta:resourcekey="btnSummurySearchResource1" />
                    <asp:Button ID="Button3" runat="server" meta:resourcekey="Button2Resource1" OnClick="Button3_Click"
                        Text="匯出Excel" />
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" meta:resourcekey="GridView2Resource1">
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
            <br />
            <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
            <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C,NAME_AD, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
                <asp:Label ID="lblNote" runat="server" Text="程式說明" meta:resourcekey="lblNoteResource1"></asp:Label></span>
            <span class="SHRight"></span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="Label1" runat="server" Text="1.主管查詢員工請假資料(不含在途中時數)！" 
                meta:resourcekey="Label1Resource2"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="2.『部門資料』分三個選項：" meta:resourcekey="Label3Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="Label4" runat="server" Text="-員工：單一查詢每一個員工的相關資料" meta:resourcekey="Label4Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="Label5" runat="server" Text="-部門：查詢所選定的部門，所有員工的相關資料" meta:resourcekey="Label5Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="Label6" runat="server" Text="-含子部門：查詢所選定的部門及子部門，所有員工的相關資料" meta:resourcekey="Label6Resource1"></asp:Label><br />
            <asp:Label ID="Label7" runat="server" Text="3.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！"
                meta:resourcekey="Label7Resource1"></asp:Label><br />
            <asp:Label ID="Label8" runat="server" Text="4.輸入日期格式為西元年！例 2008/12/31 ,也可點選欄位『日曆 圖案』可直接點選！"
                meta:resourcekey="Label8Resource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
