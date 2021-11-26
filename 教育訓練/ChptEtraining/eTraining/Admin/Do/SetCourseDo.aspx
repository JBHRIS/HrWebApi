<%@ Page Title="" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true"
    CodeFile="SetCourseDo.aspx.cs" Inherits="eTraining_Admin_Design_SetCourseDo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <script type="text/javascript">
        //<![CDATA[
                //Standard Window.confirm
                function StandardConfirm(sender, args) {
                    args.set_cancel(!window.confirm("確認是否取消發佈?"));
                }
                        
        //]]>
    </script>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" Width="100%">

            <div>
        <h2>
            <asp:Label ID="lblClassCode" runat="server"></asp:Label>-<asp:Label ID="lblClassName" runat="server"></asp:Label>
            &nbsp;<telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="True">
                <Windows>
                    <telerik:RadWindow ID="UserListDialog" runat="server" Height="450px" Modal="true"
                        ReloadOnShow="true" ShowContentDuringLoad="false" Title="Editing record" Width="400px" />
                    <telerik:RadWindow ID="UserListDialog2" runat="server" EnableShadow="True" Height="550px"
                        Modal="True" Style="display: none;" Width="650px">
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
            <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" 
                Skin="Windows7" />
        </h2>

                       <div style="text-align: right">
            <asp:HyperLink ID="hlBack" runat="server" Style="text-align: right" NavigateUrl="~/eTraining/Admin/Do/DoCourseList.aspx"
                Font-Size="Medium" CssClass="Button1">回執行狀況清單</asp:HyperLink>
        </div>
        <br />
        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
            SelectedIndex="8" Width="100%" OnTabClick="RadTabStrip1_TabClick" 
                    ShowBaseLine="True" Skin="Vista">
            <Tabs>
                <telerik:RadTab runat="server" Text="課程資訊" PageViewID="pvContent" 
                    Value="~/eTraining/Admin/Do/ClassInfo.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pvContent" Text="訓練名單" 
                    Value="~/eTraining/Admin/Do/Students.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="教育中心確認出席名單" 
                    PageViewID="pvContent" Value="~/eTraining/Admin/Do/SignInSheet.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pvContent" Text="課程檔案" 
                    Value="~/eTraining/Admin/Do/ClassUpload.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pvContent" Text="教材上傳" 
                    Value="~/eTraining/Admin/Do/TeachingMaterial.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pvContent" Text="實支實付" 
                    Value="~/eTraining/Admin/Do/ActualAMT.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="問卷管理" PageViewID="pvContent" 
                    Value="~/eTraining/Admin/Do/QuestionaryManage.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="設定結訓條件" 
                    PageViewID="pvContent" 
                    Value="~/eTraining/Admin/Do/SetStudentKnotTeaches.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="寄件通知" PageViewID="pvContent" 
                    Value="~/eTraining/Admin/Do/SetMail.aspx" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pvContent" Text="講師費用分攤" 
                    Value="~/eTraining/Admin/Do/TeacherCost.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="pvContent" Text="簽到表" 
                    Value="~/eTraining/Reports/Do/SignForClass.aspx">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Owner="RadTabStrip1" Text="例外狀況">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" Height="800px" 
            style="margin-bottom: 0px" Width="100%" SelectedIndex="0" ScrollBars="Both">
            <telerik:RadPageView ID="pvContent" Runat="server" 
    Width="100%" Height="100%" Selected="True"></telerik:RadPageView>
            <telerik:RadPageView ID="pvClassExceptionProcess" runat="server">
                <div>
                    <h2>
                        課程異常處理</h2>
                    <telerik:RadButton ID="btnAlterCourse" runat="server" 
                        onclick="btnAlterCourse_Click" Text="修改已開課資料" Width="100px">
                    </telerik:RadButton>
                    <br />
                    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                    <br />
                    <br />
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
    <div style="text-align: right;position: fixed;right:6px;bottom: 3px;">
        <telerik:RadButton ID="btnNextStep1" runat="server" OnClick="btnNextStep1_Click"
            Text="下一步" Skin="Windows7">
        </telerik:RadButton>           
    </div>
            <table style="width:100%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            </telerik:RadAjaxPanel>
</asp:Content>
