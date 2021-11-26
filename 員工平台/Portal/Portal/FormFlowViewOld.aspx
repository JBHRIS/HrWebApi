<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormFlowViewOld.aspx.cs" Inherits="Portal.FormFlowViewOld" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox">
                    <div class="control control-style2">
                        <telerik:RadAjaxPanel runat="server">
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label class="col-form-label">開始申請日期</label>
                                    <telerik:RadDatePicker ID="txtDateB" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>
                                <div class="col-sm-3">
                                    <label class=" col-form-label">結束申請日期</label>
                                    <telerik:RadDatePicker ID="txtDateE" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                                    </telerik:RadDatePicker>
                                </div>

                                <div class="col-sm-6 form-inline m-t-lg">
                                    <div class="col-sm-2">
                                        <label>
                                            <telerik:RadCheckBox runat="server" ID="isFinish"></telerik:RadCheckBox>
                                            結案</label>
                                    </div>
                                    <div class="col-sm-4">
                                        <telerik:RadButton runat="server" ID="btnSearch" CssClass="btn btn-primary" Text="查詢" OnClick="btnSearch_Click"></telerik:RadButton>
                                    </div>
                                </div>
                                <%--<asp:Image ID="img" runat="server" />--%>
                                <telerik:RadLabel runat="server" ID="lblMsg" CssClass="badge animated shake "></telerik:RadLabel>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                    <%--<div class="control control-style2">
                        <div class="form-group row">
                            <div class="col-sm-3">
                                <label class="col-form-label">部門名稱</label>
                                <select class="select2_demo_1 form-control float-right" style="width: 100%">
                                    <option value="1" selected="">人才服務部</option>
                                    <option value="2">外勞事業部</option>
                                </select>
                            </div>
                            <div class="col-sm-3">
                                <label class="col-form-label">表單名稱</label>
                                <select class="select2_demo_1 form-control float-right" style="width: 100%">
                                    <option value="1" selected="">請假單</option>
                                    <option value="2">加班單</option>
                                </select>
                            </div>
                            <div class="col-sm-3">
                                <label class="col-form-label">開始申請日期</label>
                                <div class="input-group date">
                                    <input type="text" class="form-control" value="2021/2/17">
                                    <span class="input-group-addon"><i class="fa fa-calendar form_icon"></i></span>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <label class=" col-form-label">結束申請日期</label>
                                <div class="input-group date">
                                    <input type="text" class="form-control" value="2021/2/17">
                                    <span class="input-group-addon"><i class="fa fa-calendar form_icon"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3">
                                <label class="col-form-label">狀態</label>
                                <select class="select2_demo_1 form-control float-right" style="width: 100%">
                                    <option value="1" selected="">進行中</option>
                                    <option value="2">已完成</option>
                                    <option value="3">已駁回</option>
                                    <option value="4">已抽單</option>
                                </select>
                            </div>
                            <div class="col-sm-2">
                                <div class="col-form-label">&nbsp;</div>
                                <button type="button" class="btn btn-primary">查詢</button>
                            </div>
                        </div>
                    </div>

                    <div class="control control-style2">
                        <div class="form-group row">
                            <div class="col-sm-2">
                                <label class="col-form-label">部門名稱</label>
                                <select class="select2_demo_1 form-control float-right" style="width: 100%">
                                    <option value="1" selected="">人才服務部</option>
                                    <option value="2">外勞事業部</option>
                                </select>
                            </div>
                            <div class="col-sm-2">
                                <label class="col-form-label">表單名稱</label>
                                <select class="select2_demo_1 form-control float-right" style="width: 100%">
                                    <option value="1" selected="">請假單</option>
                                    <option value="2">加班單</option>
                                </select>
                            </div>
                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label class="col-form-label" for="product_name">流程序號</label>
                                    <input type="text" id="product_name" name="product_name" value="" placeholder="" class="form-control">
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class="col-form-label" for="price">員工姓名</label>
                                    <input type="text" id="price" name="price" value="" placeholder="" class="form-control">
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <label class="col-form-label">開始申請日期</label>
                                <div class="input-group date">
                                    <input type="text" class="form-control" value="2021/2/17">
                                    <span class="input-group-addon"><i class="fa fa-calendar form_icon"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-3">
                                <label class="col-form-label">結束申請日期</label>
                                <div class="input-group date">
                                    <input type="text" class="form-control" value="2021/2/17">
                                    <span class="input-group-addon"><i class="fa fa-calendar form_icon"></i></span>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <label class="col-form-label">角色</label>
                                <select class="select2_demo_1 form-control float-right" style="width: 100%">
                                    <option value="1" selected="">申請者</option>
                                    <option value="2">被申請者</option>
                                    <option value="3">審核者</option>
                                </select>
                            </div>
                            <div class="col-sm-3">
                                <label class="col-form-label">狀態</label>
                                <select class="select2_demo_1 form-control float-right" style="width: 100%">
                                    <option value="1" selected="">進行中</option>
                                    <option value="2">已完成</option>
                                    <option value="3">已駁回</option>
                                    <option value="4">已抽單</option>
                                </select>
                            </div>
                            <div class="col-sm-3 form-inline m-t-lg">
                                <div class="col-sm-4">
                                    <label>
                                        <input type="checkbox" value="">
                                        結案</label>
                                </div>
                                <div class="col-sm-4">
                                    <button type="button" class="btn btn-primary">查詢</button>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row m-t-lg">
                            <div class="col-sm-9 form-inline">

                                <div class="col-sm-2">
                                    <label class="float-left">
                                        <input type="checkbox" value="">
                                        全選</label>
                                </div>

                                <div class="col-sm-5">
                                    <div class="form-group">
                                        <select class="select2_demo_1 form-control float-right" style="width: 100%">
                                            <option value="1">起點從送流程</option>
                                            <option value="2">作廢</option>
                                            <option value="3">駁回</option>
                                            <option value="4">核准存入</option>
                                        </select>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <button type="button" class="btn btn-primary">確認</button>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <telerik:RadAjaxPanel runat="server" ID="plMain" LoadingPanelID="RadAjaxLoadingPanel1">

                        <div class="ibox-title">
                            <h5>流程資訊</h5>
                        </div>
                        <div class="ibox-content">

                            <telerik:RadListView runat="server" CssClass="col-12" ID="lvMain" ItemPlaceholderID="Container" OnItemCommand="lvMain_ItemCommand">
                                <LayoutTemplate>
                                    <table class="footable table" data-page-size="10">
                                        <tbody id="Container" runat="server">
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td colspan="1">
                                                    <ul class="pagination float-right"></ul>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="keyin keyin-border">
                                                <div class="row">
                                                    <div class="col-sm-10">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="row m-t-xs">
                                                                    <div class="col col-xs-6">
                                                                        <span>流程序號：<%#Eval("ProcessId") %></span><br>
                                                                        <span>表單名稱：<%#Eval("FlowName") %></span>
                                                                    </div>
                                                                    <div class="col col-xs-6">
                                                                        <span>被申請人：<%#Eval("Application") %></span><br>
                                                                        <span>申請日期：<%#Eval("ADate","{0:yyyy/MM/dd}") %></span>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="row m-t-xs">
                                                                    <div class="col col-xs-6">
                                                                        <span>開始時間：<%#Eval("DateB","{0:yyyy/MM/dd HH:mm}") %>　</span>
                                                                        <br>
                                                                        <span>結束時間：<%#Eval("DateE","{0:yyyy/MM/dd HH:mm}") %>　</span>
                                                                    </div>

                                                                    <div class="col col-xs-6">
                                                                        <%--<span>共計：<%#Eval("Use") %><%#Eval("Unit") %></span><br>
                                                            <span>代理人：<%#Eval("Agent") %></span>--%>
                                                                        <span>表單狀態:<%#Eval("FormState") %></span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-1 m-t-xs">
                                                        <telerik:RadButton ID="btnView" runat="server" CssClass="btn btn-outline btn-success" Text="檢視" CommandArgument='<%#Eval("FlowId") %>' CommandName='<%#Eval("FlowCode") %>'></telerik:RadButton>
                                                        <telerik:RadButton ID="btnViewImage" runat="server" CssClass="btn btn-outline btn-info" Text="流程" CommandArgument='<%#Eval("ProcessId") %>' CommandName="ViewImage"></telerik:RadButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>

                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    無流程資料
                                </EmptyDataTemplate>
                            </telerik:RadListView>
                        </div>
                    </telerik:RadAjaxPanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.footable').footable();
        });
    </script>
</asp:Content>
