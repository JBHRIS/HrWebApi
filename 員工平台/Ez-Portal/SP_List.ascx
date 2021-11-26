<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SP_List.ascx.cs" Inherits="SP_List" %>
<fieldset id="FIELDSET1" runat="server">
    <legend>
        程式清單
    </legend>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Attendance/SP_Rote.aspx"
        Target="_self">調班資料維護</asp:HyperLink><br>
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Attendance/SP_Card.aspx"
        Target="_self">刷卡資料維護</asp:HyperLink><br>
      
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Attendance/AttendCardList.aspx"
        Target="_self">出勤異常表</asp:HyperLink><br>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Attendance/ImportRote.aspx"
        Target="_self">員工班表匯入</asp:HyperLink><br>
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Mang/EmpAttendSelect_ma.aspx"
        Target="_self">外勞出勤資料查詢</asp:HyperLink><br>
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/FEFC/FL_ABS.aspx"
        Target="_self">外勞請假作業</asp:HyperLink><br>
        
        
        </fieldset>