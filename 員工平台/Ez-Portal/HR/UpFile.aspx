<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpFile.aspx.cs" Inherits="WebTemplet_UpFile" Title="Untitled Page" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadProgressManager ID="RadProgressManager1" runat="server" />
    <table border="0" width="754">
        <tr>
            <td style="vertical-align: top">
                <telerik:RadUpload ID="RadUpload1" runat="server" OverwriteExistingFiles="false"
                    Skin="Web20" TargetFolder="~/File" ControlObjectsVisibility="None" />
                <telerik:RadProgressArea ID="progressArea1" runat="server">
                </telerik:RadProgressArea>
                &nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /></td>
            <td style="vertical-align: top">
                <div class="module" style="margin-top: 5px; float: right; overflow: auto; width: 280px;
                    height: 143px">
                    <asp:Label ID="labelNoResults" runat="server" Visible="True">No uploaded files yet</asp:Label>
                    <asp:Repeater ID="repeaterResults" runat="server" Visible="False">
                        <HeaderTemplate>
                            Uploaded files in the target folder:<br />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "FileName")%>
                            <%#DataBinder.Eval(Container.DataItem, "ContentLength").ToString() + " bytes"%>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

