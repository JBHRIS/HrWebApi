<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpPicture.aspx.cs" Inherits="Account_UpPicture" Title="上傳員工照片" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="GreenForm">
        <div class="GreenFormHeader">
            <span class="GHLeft"></span><span class="GHeader">上傳員工照片</span> <span class="GHRight">
            </span>
        </div>
        <div class="GreenFormContent">
    <table border="0" width="754">
        <tr>
            <td style="vertical-align: top">
            上傳照片路徑<telerik:radprogressmanager ID="RadProgressManager1" runat="server" />
            
                <telerik:radupload ID="RadUpload1" runat="server" OverwriteExistingFiles="false"
                    Skin="Web20" TargetFolder="~/File" ControlObjectsVisibility="None" />
                <telerik:radprogressarea ID="progressArea1" runat="server">
                </telerik:radprogressarea>
                &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上傳" />
            <asp:Label ID="Label1" runat="server" SkinID="Notice" Text="*上傳圖不可大於700K！"></asp:Label></td>
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
            &nbsp;
            <br />
            <br />
        </div>
        <div class="GreenFormFooter">
            <span class="GFLeft"></span><span class="GFRight"></span>
        </div>
    </div>
</asp:Content>

