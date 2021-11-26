<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormAppointFlow.aspx.cs" Inherits="Portal.FormAppointFlow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlEmp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="AbsType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsg" />
                    <telerik:AjaxUpdatedControl ControlID="plMain1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">

            <div class="col-lg-12">
                <div id="iboxContent" class="ibox">
                    <div class="ibox-title">
                        <h5>待審核資訊</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="fullscreen-link">
                                <i class="fa fa-expand"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadListView runat="server" ID="lvAppointView" OnNeedDataSource="lvAppointView_NeedDataSource" OnItemCommand="lvAppointView_ItemCommand" RenderMode="Lightweight" ItemPlaceholderID="Container">
                            <LayoutTemplate>
                                <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">

                                    <tbody id="Container" runat="server">
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="11">
                                                <ul class="pagination float-right"></ul>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="keyin keyin-border">
                                    <div class="row">
                                        <div class="col-md-10 m-t-sm">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    流程序號：<telerik:RadLabel ID="lblAutoKey" runat="server" Text='<%#Eval("ProcessId") %>' />
                                                </div>
                                                <div class="col-md-3">
                                                    表單名稱：<telerik:RadLabel ID="lblForm" runat="server" Text="從業人員晉升申請單" />
                                                </div>
                                                <div class="col-md-3">
                                                    被申請人：<telerik:RadLabel ID="lblEmpName" runat="server" Text='<%#Eval("EmpName") %>' />
                                                </div>
                                                <div class="col-md-3">
                                                    申請日期：<telerik:RadLabel ID="lblDate" runat="server" Text='<%#Eval("InsertDate","{0:yyyy/MM/dd}") %>' />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <telerik:RadButton ID="btnConfirm" CssClass="btn-primary" CommandArgument='<%#Eval("ProcessApParm") %>' runat="server" Text="編輯" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                目前並無任何加班資料
                            </EmptyDataTemplate>
                        </telerik:RadListView>

                    </div>
                </div>
            </div>
        </div>
        <telerik:RadLabel runat="server" ID="TotalTime" Visible="false"></telerik:RadLabel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- FooTable -->
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
    <script type="text/javascript">
        document.getElementById("ctl00_ContentPlaceHolder1_btnSearch").onclick = function () { Jump() };

        function Jump() {
            //window.location.href = "#iboxContent";
            document.getElementById("iboxContent").scrollIntoView();
        }
    </script>
    <script>
        $(document).ready(function () {
            $('.footableTaken').footable();
            $('.footableEntitle').footable();
        });
    </script>
</asp:Content>
