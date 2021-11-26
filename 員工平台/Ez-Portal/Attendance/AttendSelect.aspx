<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttendSelect.aspx.cs" Inherits="Attendance_AttendSelect" Title="e-HR" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register Src="../Account/AccountPictureBind.ascx" TagName="AccountPicture1" TagPrefix="uc2" %>
<%@ Register Src="../Account/AccountPicture.ascx" TagName="AccountPicture" TagPrefix="uc1" %>
<%@ Register src="RoteList.ascx" tagname="RoteList" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc3:RoteList ID="RoteList1" runat="server" />
<%--            
            <h3>
            <asp:Label ID="lblShowPageComment" runat="server"
                Text="程式說明" meta:resourcekey="lblShowPageCommentResource1"></asp:Label>
            </h3>
--%>
<%--        <div class="SilverFormContent" style="color: red">
            <asp:TextBox ID="TextBox1" runat="server" ForeColor="#FF3300" 
                meta:resourcekey="TextBox1Resource1" Rows="10" TextMode="MultiLine" 
                Width="100%">1.查詢員工出勤資料！
2.『查詢條件』員工可以於條件中輸入區間日期，例 2008/01/01 至 2008/12/31 輸入完成之 後，請按下『查詢』鍵，就可查詢員工相關資料！
3.輸入日期格式為西元年！例 2008/12/31&nbsp; ,也可點選欄位『日曆 圖案』可直接點選！</asp:TextBox>
            &nbsp;<asp:Label ID="Label1" 
                runat="server" Text="出勤日期：" Visible="False" 
                meta:resourcekey="Label1Resource1"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="adate" Display="Dynamic" ErrorMessage="日期格式錯誤！" 
                Font-Size="X-Small" ValidationGroup="group_date" Visible="False" 
                meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
            &nbsp;<br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>--%>
</asp:Content>

