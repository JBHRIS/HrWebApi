<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowTask.aspx.cs" Inherits="Utli_ShowTask" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="GreenForm">
            <div class="GreenFormHeader">
                <span class="GHLeft"></span><span class="GHeader">待辦事項內容</span> <span class="GHRight">
                </span>
            </div>
            <div class="GreenFormContent">
               <table width="55%">
                <tr>
                <td style="height: 21px"> 申請人員工編號:
                    <asp:TextBox ID="app_nobr" runat="server" MaxLength="10"
                         Width="80px" Enabled="False"></asp:TextBox>&nbsp;
                    <asp:Label ID="app_name" runat="server" Width="80px"></asp:Label>&nbsp;&nbsp;
                </td>
                </tr>
                <tr>
                <td style="height: 18px"> 執行者員工編號:
                    <asp:TextBox ID="exe_nobr" runat="server" 
                        Width="80px" MaxLength="10" Enabled="False"></asp:TextBox>&nbsp;
                    <asp:Label ID="exe_name" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;
                </td>
                </tr>
                <tr>
                <td>待辦事項:
                    <asp:TextBox ID="tasks" runat="server"  Width="325px" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                <td> 重要優先順序：<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" >
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:RadioButtonList></td>
                </tr>
                <tr>
                <td> 預計完成日：<telerik:RadDatePicker ID="ExpireDate" runat="server" Culture="Chinese (Taiwan)"  Enabled="False">
                    <DateInput Skin="">
                    </DateInput>
                    </telerik:RadDatePicker></td>
                </tr>
                <tr>
                <td>
                    提醒天數：幾<asp:TextBox ID="Reminday" runat="server" MaxLength="3" Width="40px"  Enabled="False"></asp:TextBox>天前</td>
                </tr>
                    <tr>
                        <td>
                            執行進度：<asp:TextBox ID="Schedule" runat="server" MaxLength="5" Width="50px" Enabled="False" ></asp:TextBox>%</td>
                    </tr>
                 <tr>
                <td>
                    內容:
                    <br />
                    <textarea id="Descs" style="width: 400px; height: 150px" runat="server"></textarea></td>
                </tr>
                    <tr>
                        <td>
                           附件檔案：
                            <asp:LinkButton ID="File_name" runat="server" OnClick="File_name_Click"></asp:LinkButton>
                            <asp:Label ID="La_Upfilename" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                </table>
                </div>
            <div class="GreenFormFooter">
                <span class="GFLeft"></span><span class="GFRight"></span>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
