<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeSecretarySetting.ascx.cs"
    Inherits="Templet_EmployeeSecretarySetting" %>
<h3>
    <asp:Localize ID="Localize1" runat="server">助理權限</asp:Localize>
</h3>
<asp:CheckBox ID="ckSecretary" runat="server" Text="是否有助理權限" 
    Font-Size="Small" />
<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="存檔" />
<asp:Label ID="lb_nobr" runat="server" Visible="False" Font-Size="Small"></asp:Label>
