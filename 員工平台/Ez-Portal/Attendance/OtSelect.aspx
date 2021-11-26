<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtSelect.aspx.cs" Inherits="Attendance_OtSelect" Title="e-HR" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
                <asp:Label ID="lblShowHeader" runat="server" Text="加班資料" 
                meta:resourcekey="lblShowHeaderResource1"></asp:Label></h3>
        <fieldset>
            <legend><asp:Label ID="lblShowInquiryCondition" runat="server" Text="查詢條件" 
                    meta:resourcekey="lblShowInquiryConditionResource1"></asp:Label></legend>
            <asp:Label ID="Label1" runat="server" Text="加班日期：" 
                meta:resourcekey="Label1Resource1"></asp:Label>
            <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                Skin="Web20">
            </telerik:RadDatePicker>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                ValidationGroup="group_date" 
                meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
            <asp:Label ID="Label2" runat="server" Text="至" 
                meta:resourcekey="Label2Resource1"></asp:Label>&nbsp;
            <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                 Skin="Web20">
            </telerik:RadDatePicker>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                ValidationGroup="group_date" 
                meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                ValidationGroup="group_date" meta:resourcekey="Button1Resource1" />&nbsp;
            <asp:Label ID="lb_nobr" runat="server" Visible="False" 
                meta:resourcekey="lb_nobrResource1"></asp:Label></fieldset>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="HR_Portal_Ot_SqlDataSource"
                SkinID="Yahoo" AllowPaging="True" AllowSorting="True" 
                meta:resourcekey="GridView1Resource1" 
                onrowdatabound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" 
                        Visible="False" meta:resourcekey="BoundFieldResource1" />
                    <asp:BoundField DataField="NAME_C" HeaderText="NAME_C" SortExpression="NAME_C" 
                        Visible="False" meta:resourcekey="BoundFieldResource2" />
                    <asp:BoundField DataField="JOB_NAME" HeaderText="JOB_NAME" SortExpression="JOB_NAME"
                        Visible="False" meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" 
                        Visible="False" meta:resourcekey="BoundFieldResource4" />
                    <asp:BoundField DataField="BDATE" HeaderText="加班日期" SortExpression="BDATE" 
                        DataFormatString="{0:yyyy/MM/dd}" HtmlEncode="False" 
                        meta:resourcekey="BoundFieldResource5" />
                    <asp:BoundField DataField="BTIME" HeaderText="開始時間" SortExpression="BTIME" 
                        meta:resourcekey="BoundFieldResource6" />
                    <asp:BoundField DataField="ETIME" HeaderText="結束時間" SortExpression="ETIME" 
                        meta:resourcekey="BoundFieldResource7" />
                    <asp:BoundField DataField="TOT_HOURS" HeaderText="總時數" 
                        SortExpression="TOT_HOURS" meta:resourcekey="BoundFieldResource8" />
                    <asp:BoundField DataField="OT_HRS" HeaderText="加班時數" SortExpression="OT_HRS" 
                        meta:resourcekey="BoundFieldResource9" />
                    <asp:BoundField DataField="REST_HRS" HeaderText="補休時數" 
                        SortExpression="REST_HRS" meta:resourcekey="BoundFieldResource10" />
                    <asp:BoundField DataField="OTRNAME" HeaderText="加班原因" SortExpression="OTRNAME" 
                        meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="NOTE" HeaderText="備註" SortExpression="NOTE" 
                        meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="YYMM" HeaderText="計薪年月" SortExpression="YYMM" 
                        meta:resourcekey="BoundFieldResource13" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" 
                        Text="＊無相關資料！！" meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="HR_Portal_Ot_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                
        SelectCommand="SELECT NOBR, NAME_C, JOB_NAME, D_NAME, BDATE, BTIME, ETIME, TOT_HOURS, OT_HRS, REST_HRS, OTRNAME, NOTE, YYMM FROM HR_Portal_Ot WHERE (NOBR = @nobr) AND (CONVERT (char(10), BDATE, 111) BETWEEN CONVERT (char(10), @adate, 111) AND CONVERT (char(10), @ddate, 111)) ORDER BY BDATE desc">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
                    <asp:ControlParameter ControlID="adate" Name="adate" PropertyName="SelectedDate" />
                    <asp:ControlParameter ControlID="ddate" Name="ddate" PropertyName="SelectedDate" />
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
            <asp:TextBox ID="TextBox1" runat="server" meta:resourcekey="TextBox1Resource1" 
                ReadOnly="True" Rows="10" TextMode="MultiLine" Width="100%">1.查詢員工加班資料！
2.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之後，請按下『查詢』鍵，就可查詢員工相關資料！
3.輸入日期格式為西元年！例 2008/12/31&nbsp; ,也可點選欄位『日曆 圖案』可直接點選！</asp:TextBox>
            <br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>

