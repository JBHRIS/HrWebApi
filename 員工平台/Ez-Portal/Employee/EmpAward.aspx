<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAward.aspx.cs" Inherits="Employee_EmpAward" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        <asp:Label ID="lblAward" runat="server" Text="員工獎懲資料" meta:resourcekey="lblAwardResource1"></asp:Label>
    </h3>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
        AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1" meta:resourcekey="GridView2Resource1"
        Width="100%">
        <Columns>
            <asp:BoundField DataField="nobr" HeaderText="員工編號" meta:resourcekey="BoundFieldResource1" />
            <asp:BoundField DataField="name_c" HeaderText="員工姓名" meta:resourcekey="BoundFieldResource2" />
            <asp:BoundField DataField="adate" DataFormatString="{0:d}" HeaderText="獎懲日期" HtmlEncode="False"
                meta:resourcekey="BoundFieldResource3" />
            <asp:BoundField DataField="descr" HeaderText="獎懲原因" meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="award1" HeaderText="大功" meta:resourcekey="BoundFieldResource5" />
            <asp:BoundField DataField="award2" HeaderText="小功" meta:resourcekey="BoundFieldResource6" />
            <asp:BoundField DataField="award3" HeaderText="嘉獎" meta:resourcekey="BoundFieldResource7" />
            <asp:BoundField DataField="award4" HeaderText="嘉獎" meta:resourcekey="BoundFieldResource8" />
            <asp:BoundField DataField="award5" HeaderText="晋級" meta:resourcekey="BoundFieldResource9"
                Visible="False" />
            <asp:BoundField DataField="fault1" HeaderText="大過" meta:resourcekey="BoundFieldResource10" />
            <asp:BoundField DataField="fault2" HeaderText="小過" meta:resourcekey="BoundFieldResource11" />
            <asp:BoundField DataField="fault3" HeaderText="申誡" meta:resourcekey="BoundFieldResource12" />
            <asp:BoundField DataField="note" HeaderText="備註" meta:resourcekey="BoundFieldResource13" />
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="＊無相關資料！！"
                meta:resourcekey="lb_emptyResource1"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        SelectCommand="SELECT AWARD.NOBR, HR_Portal_EmpInfo.NAME_C, AWARD.ADATE, AWARDCD.DESCR, AWARD.AWARD1, AWARD.AWARD2, AWARD.AWARD3, AWARD.AWARD4, AWARD.AWARD5, AWARD.FAULT1, AWARD.FAULT2, AWARD.FAULT3, AWARD.NOTE FROM AWARD INNER JOIN HR_Portal_EmpInfo ON AWARD.NOBR = HR_Portal_EmpInfo.NOBR LEFT OUTER JOIN AWARDCD ON AWARD.AWARD_CODE = AWARDCD.AWARD_CODE WHERE (AWARD.NOBR = @nobr) ORDER BY AWARD.ADATE DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="lb_nobr" Name="nobr" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lb_nobr" runat="server" Visible="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader"><asp:Label ID="lblNote" runat="server" Text="程式說明" meta:resourcekey="lblNoteResource1"></asp:Label></span></span> <span class="SHRight">
            </span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="lblNoteDetail" runat="server" Text="1.查詢員工獎懲資料！" meta:resourcekey="lblNoteDetailResource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
