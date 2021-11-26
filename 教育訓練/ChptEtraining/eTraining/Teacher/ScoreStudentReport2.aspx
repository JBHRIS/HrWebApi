<%@ Page Title="學員心得評分" Language="C#" MasterPageFile="~/mpEdit.master" AutoEventWireup="true"
    CodeFile="ScoreStudentReport2.aspx.cs" Inherits="eTraining_Teacher_ScoreStudentReport2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .RadInput_Default { font: 12px "segoe ui" ,arial,sans-serif; }
        
        .RadInput { vertical-align: middle; }
        
        .RadInput textarea { vertical-align: bottom; overflow: auto; resize: none; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        學員心得評分<asp:Label ID="lblTsmId" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblClassMsg" runat="server" ForeColor="Red"></asp:Label>
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">
        <script type="text/javascript">
        //<![CDATA[

            //Standard Window.confirm
            function StandardConfirm(sender, args) {
                args.set_cancel(!window.confirm("確認是否退件?"));
            }
            function CloseAndRebind(args) {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow)
                    oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog               
                else if (window.frameElement.radWindow)
                    oWindow = window.frameElement.radWindow;
                //IE (and Moz as well)                
                return oWindow;
            }
            function CancelEdit() {
                GetRadWindow().close();
            }       
        //]]>
        </script>
        <table class="tableBlue" style="border: 1px solid #cccccc">
            <tr>
                <th>
                    階層
                </th>
                <td>
                    <asp:Label ID="lblCate" runat="server"></asp:Label>
                </td>
                <th>
                    課程
                </th>
                <td>
                    <asp:Label ID="lblCourse" runat="server"></asp:Label>
                </td>
                <th>
                    上課日期
                </th>
                <td>
                    <asp:Label ID="lblClassDate" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlWrite" runat="server">
            <table width="85%" class="Basic">
                <tr>
                    <td>
                        學員
                    </td>
                    <td>
                        <asp:Label ID="lb_Name" runat="server"></asp:Label>
                    </td>
                    <td>
                        心得分數：<telerik:RadNumericTextBox ID="ntbScore" runat="server" MaxValue="100" MinValue="0">
                            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                        </telerik:RadNumericTextBox>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
                    </td>
                    <td>
                        <telerik:RadButton ID="btnSend" runat="server" OnClick="btnSend_Click" Text="存檔">
                        </telerik:RadButton>
                    </td>
                    <td>
                        <telerik:RadButton ID="btnRejection" runat="server" Text="退件" ForeColor="Red" OnClick="btnRejection_Click"
                            OnClientClicking="StandardConfirm">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
            <br />
            學員心得<br />
            <telerik:RadEditor ID="edtStudent" runat="server" EditModes="Preview" Width="100%"
                BorderWidth="1px" ContentAreaMode="Div" EnableResize="False" Skin="Telerik" ToolbarMode="ShowOnFocus"
                ToolsFile="~/Editor/RadEditor/FullSetOfTools.xml" CssClass="lineHeight" Font-Size="Medium">
            </telerik:RadEditor>
            <br />
            <hr />
            <br />
            講師評語<telerik:RadEditor ID="edtTeacher" runat="server" EditModes="Design, Preview"
                Width="100%" BorderWidth="1px" EnableResize="False" ToolsFile="~/Editor/RadEditor/BasicTools.xml"
                CssClass="lineHeight" Font-Size="Medium">
                <Content>
                </Content>
                <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
        </asp:Panel>
    </telerik:RadAjaxPanel>
    <br />
</asp:Content>
