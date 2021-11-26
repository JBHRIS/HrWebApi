<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetMail.aspx.cs" Inherits="eTraining_Admin_Do_SetMail" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                Skin="Office2007" IsSticky="True">
                <asp:Label ID="Label1" runat="server" Text="請稍候......" Font-Size="X-Large" 
                    ForeColor="#3366FF"></asp:Label>
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
                HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" width="100%">
                   <div style="float: left; width: 35%">
            <div class="field">
                <fieldset style="background-color: #EEF5FC; width: 250px">
                    <legend>寄送人員</legend>
                    <asp:RadioButtonList ID="rbl" runat="server" Font-Size="Small" Width="230px" 
                        AutoPostBack="True" onselectedindexchanged="rbl_SelectedIndexChanged">
                        <asp:ListItem Value="1">講師</asp:ListItem>
                        <asp:ListItem Value="2">所有學員</asp:ListItem>
                        <asp:ListItem Value="3">上課出席學員</asp:ListItem>
                        <asp:ListItem Value="4">上課出席學員及該部門主管</asp:ListItem>
                        <asp:ListItem Value="5">上課出席學員及上層主管</asp:ListItem>
                        <asp:ListItem Value="6">上課出席學員及上兩層主管</asp:ListItem>
                    </asp:RadioButtonList>
                                        <asp:RadioButtonList ID="rblStudentProperty" runat="server" 
                        Visible="False" BorderColor="#CC6699" BorderStyle="Groove" ForeColor="Red">
                                            <asp:ListItem Selected="True" Value="1">無</asp:ListItem>
                                            <asp:ListItem Value="2">心得未填寫</asp:ListItem>
                                            <asp:ListItem Value="3">問卷未填寫</asp:ListItem>
                    </asp:RadioButtonList>
                </fieldset>
            </div>
            <br />
            郵件<telerik:RadComboBox ID="cbxMail" runat="server" DataSourceID="sdsCbx" DataTextField="sName"
                DataValueField="iAutoKey">
            </telerik:RadComboBox>
            &nbsp;
            <telerik:RadButton ID="btnView" runat="server" Text="預覽" 
                OnClick="btnSend_Click">
            </telerik:RadButton>
            <br />
            <asp:SqlDataSource ID="sdsCbx" runat="server" ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>"
                SelectCommand="SELECT * FROM [trMailTemplate]"></asp:SqlDataSource>
            <br />
            <telerik:RadButton ID="btnSend" runat="server" Text="寄送" 
                onclick="btnSend_Click">
            </telerik:RadButton>
            <br />
            <br />
            <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
        </div>
        <div style="float: left; width: 64%">
            <asp:Panel ID="pnView" runat="server" Height="376px" Visible="False">
                <br />
                <table border="1" style="width: 100%; background-color: #EEF5FC;">
                    <tr>
                        <td>
                            信件標題
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMailSubject" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            信件內容
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMailBody" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
            </telerik:RadAjaxPanel>

    </div>
    </form>
</body>
</html>
