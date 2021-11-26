<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="ExpReport.aspx.cs" Inherits="eTraining_Staff_ExpReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>心得報告</h2>
    <h2>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
    </h2>
<table class="Basic">
    <tr>
        <td>
            課程名稱
        </td>
        <td>
            <asp:Label ID="lblClassName" runat="server"></asp:Label>
        </td>
        <td>
            上課日期
        </td>
        <td>
            <asp:Label ID="lblClassDate" runat="server"></asp:Label>
        </td>
        &nbsp;
        <td>
            講師評分
        </td>
        <td>
            <telerik:RadNumericTextBox ID="tbScore" Runat="server" Enabled="False">
<NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
            </telerik:RadNumericTextBox>
        </td>
    </tr>
    <tr>
        <td>
            講師姓名
        </td>
        <td>
            <asp:Label ID="lblTeacher" runat="server"></asp:Label>
        </td>
        <td>
            上課時間
        </td>
        <td>
            <asp:Label ID="lblClassTime" runat="server"></asp:Label>
        </td>
        <td>
            上課地點
        </td>
        <td>
            <asp:Label ID="lblClassPlace" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            學員姓名
        </td>
        <td>
            <asp:Label ID="lblUserName" runat="server"></asp:Label>
        </td>
        <td>
            學員職務
        </td>
        <td>
            <asp:Label ID="lblJobName" runat="server"></asp:Label>
        </td>
        <td>
        </td>
                <td>
        </td>
    </tr>
                    <tr>
                        <td colspan="6">
                            <telerik:RadEditor ID="edtStudent" Runat="server" EditModes="Design, Preview" 
                                Width="100%" BorderWidth="1px" EnableResize="False" 
                                ToolbarMode="ShowOnFocus" ToolsFile="~/Editor/RadEditor/BasicTools.xml" 
                                CssClass="lineHeight" Font-Size="Medium">
                            </telerik:RadEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="6">
                            &nbsp;&nbsp;
                            <telerik:RadButton ID="btnSave" runat="server" Text="存檔送出" Skin="Windows7" 
                                onclick="btnSave_Click">
                            </telerik:RadButton>
        <telerik:RadButton ID="btnBack" runat="server" Text="回上頁" onclick="btnBack_Click">
        </telerik:RadButton>
                            <telerik:RadButton ID="btnSaveTemp" runat="server" onclick="btnSaveTemp_Click" 
                                Text="暫存心得">
                            </telerik:RadButton>
                            <br />
            <hr />
                            <br />
                                        講師評語<telerik:RadEditor ID="edtTeacher" runat="server" EditModes="Preview"
                Width="100%" BorderWidth="1px" EnableResize="False" 
                ToolsFile="~/Editor/RadEditor/BasicTools.xml" CssClass="lineHeight" 
                Font-Size="Medium">
                <Content>
</Content>
                <TrackChangesSettings CanAcceptTrackChanges="False" />
            </telerik:RadEditor>
                        </td>
                    </tr>
                </table>
</asp:Content>

