<%@ Page Language="C#" MasterPageFile="~/MasterPage_OnlyContent.master" AutoEventWireup="true" CodeFile="hrMang.aspx.cs" Inherits="hrMang" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/hrBase.aspx">員工基本資料</asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/hrDeptm.aspx">簽核部門</asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/hrJob.aspx">職稱</asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/hrHcode.aspx">假別</asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/hrRote.aspx">班別</asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/hrHoliday.aspx">行事曆</asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/hrAmountHoliday.aspx">產生特休</asp:LinkButton><br />
    <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="~/hrAbs.aspx">請假資料</asp:LinkButton>
</asp:Content>

