<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeptUserShift.ascx.cs" Inherits="Utli_DeptUserShift" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<fieldset>
    <legend>
        <asp:Label ID="lblSearch" runat="server" Text="查詢條件" 
            meta:resourcekey="lblSearchResource1"></asp:Label></legend>
    <br />
    <table width="100%">
        <tr>
            <td>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="Chinese (Taiwan)" 
                    meta:resourcekey="adateResource1">
                    <DateInput Skin="">
                    </DateInput>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                    ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblTo" runat="server" Text="至" 
                    meta:resourcekey="lblToResource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="Chinese (Taiwan)" 
                    meta:resourcekey="ddateResource1">
                    <DateInput Skin="">
                    </DateInput>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    Display="Dynamic" ErrorMessage="日期格式錯誤！" Font-Size="X-Small" 
                    ValidationGroup="group_date" 
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查詢" 
                    meta:resourcekey="Button1Resource1" />
                <asp:Button ID="btnExportExcel" runat="server" Text="匯出excel" 
                  onclick="btnExportExcel_Click" meta:resourcekey="btnExportExcelResource1" />
                <asp:Label ID="lblDept" runat="server" Visible="False" 
                    meta:resourcekey="lblDeptResource1"></asp:Label>
                </td>
        </tr>
    </table>
</fieldset>
            <asp:GridView ID="gvEmpRote" runat="server" ShowFooter="True" 
      Font-Size="X-Small" meta:resourcekey="gvEmpRoteResource1" Width="100%">
                <RowStyle HorizontalAlign="Center" />
                <FooterStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
            </asp:GridView>