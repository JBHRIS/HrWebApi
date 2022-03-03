<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.master" AutoEventWireup="true" CodeBehind="FormOtStd.aspx.cs" Inherits="Portal.FormOtStd" %>

<%@ Register Src="~/UserControls/UC_FileManage.ascx" TagPrefix="uc" TagName="FileManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="ibox-content">
        <telerik:RadAjaxPanel ID="plInfo" runat="server">
            <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="gvAppS_NeedDataSource" OnItemCommand="gvAppS_ItemCommand" OnDataBound="gvAppS_DataBound">
                <%--OnNeedDataSource="gvAppS_NeedDataSource" OnDataBound="gvAppS_DataBound" --%>
                <LayoutTemplate>
                    <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                        <thead>
                        </thead>
                        <tbody id="Container" runat="server">
                        </tbody>
                        <tfoot>
                        <div>總共新增：<strong><telerik:RadLabel ID="lblCount" runat="server"  /></strong> 筆資料</div>
                            <tr>
                                <td colspan="5">
                                    <ul class="pagination float-right"></ul>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="keyin keyin-border">
                        <div class="row">
                            <div class="col-md-2">
                                <h3>
                                    <span class="label label-primary m-r-sm"><telerik:RadLabel ID="lblListNumber" runat="server"  /></span>
                                    <%# Eval("EmpName") %>,
                                    <%# Eval("EmpId") %>
                                </h3>
                            </div>
                            <div class="col-md-9">
                                <div class="row">
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblBeginDateDic" Text="開始日期"></telerik:RadLabel>：<%# Eval("DateB","{0:yyyy/MM/dd}") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblBeginTimeDic" Text="開始時間"></telerik:RadLabel>：<%# Eval("TimeB") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblEndDateDic" Text="結束日期"></telerik:RadLabel>：<%# Eval("DateE","{0:yyyy/MM/dd}") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblEndTimeDic" Text="結束時間"></telerik:RadLabel>：<%# Eval("TimeE") %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblOtPaymentDic" Text="給付方式"></telerik:RadLabel> ：<%# Eval("OtCateName") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblReasonDic" Text="加班原因"></telerik:RadLabel> ：<%# Eval("OtrcdName") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblOtHourDic" Text="申請時數"></telerik:RadLabel> ：<%# Eval("Use") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblUnitDic" Text="單位"></telerik:RadLabel>：<%# Eval("UnitCode") %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <telerik:RadLabel runat="server" ID="lblOverTimeClassDic" Text="加班班別"></telerik:RadLabel>：<%# Eval("RoteName") %>
                                    </div>
                                    <div class="col-lg-6">
                                        <telerik:RadLabel runat="server" ID="lblNoteDic" Text="備註"></telerik:RadLabel>：<%# Eval("Note") %>
                                    </div>
                                </div>
                            </div>

                            <%--<div class="col-sm-1">
                                <div class="row">
                                    <span>給付方式：<%# Eval("OtCateName") %></span><br>
                                    <span>備註：<%# Eval("Note") %></span>
                                </div>
                            </div>--%>
                            <div class="col-md-1">

                                <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn btn-outline btn-danger" OnClientClicking="Clicking"
                                    CommandName="Del" Text="刪除">
                                </telerik:RadButton>
                            </div>
                        </div>
                    </div>
                    <%--<tr class="gradeX">
                                    <td>
                                        <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn btn-w-m btn-danger"
                                            CommandName="Del" Text="刪除">
                                        </telerik:RadButton>
                                    </td>
                                    <td>
                                        <telerik:RadButton ID="btnUpload" runat="server" CssClass="btn btn-primary" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Upload" data-toggle="modal" data-target="#myModal" Text="附件上傳">
                                        </telerik:RadButton>
                                    </td>
                                    <td><%# Eval("EmpId") %></td>
                                    <td><%# Eval("EmpName") %></td>
                                    <td><%# Eval("DateB") %></td>
                                    <td><%# Eval("DateE") %></td>
                                    <td><%# Eval("TimeE") %></td>
                                    <td><%# Eval("HolidayName") %></td>
                                    <td><%# Eval("Use") %></td>
                                    <td><%# Eval("UnitCode") %></td>
                                    <td><%# Eval("AgentEmpName") %></td>
                                    <td>
                                        <telerik:RadLabel ID="lblGuid" runat="server" Visible="false" Text='<%# Eval("Code") %>'></telerik:RadLabel>
                                    </td>
                                    <td>
                                        <telerik:RadLabel ID="lbliAutoKey" runat="server" Visible="false" Text='<%# Eval("AutoKey") %>'></telerik:RadLabel>
                                    </td>
                                </tr>--%>
                </ItemTemplate>
                <EmptyDataTemplate>
                     <telerik:RadLabel runat="server" ID="lblOtEmptyMessageDic" Text="尚未新增加班資料"></telerik:RadLabel>
                </EmptyDataTemplate>
            </telerik:RadListView>
            <telerik:RadLabel ID="lblNotifyMsg" runat="server" CssClass="text-danger" Text=""></telerik:RadLabel>
        </telerik:RadAjaxPanel>
    </div>
    <div style="padding: 20px 0px 0px 0px">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox" style="margin-bottom: 0px">
                    <div class="ibox-title">
                        <h5><telerik:RadLabel runat="server" ID="lblApplicationInfoDic" Text="申請資訊"></telerik:RadLabel></h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content" style="border-bottom-color: white">
                        <telerik:RadAjaxPanel ID="plAppS" runat="server">
                            <div class="form-group row">
                                <div class="col-md-3">
                                    <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblRespondentNameDic" Text="被申請人姓名"></telerik:RadLabel></label>
                                    <telerik:RadComboBox ID="txtNameAppS" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                                        LoadingMessage="載入中…" Width="100%" OnDataBound="txtNameAppS_DataBound"
                                        OnSelectedIndexChanged="txtNameAppS_SelectedIndexChanged" OnTextChanged="txtNameAppS_TextChanged">
                                    </telerik:RadComboBox>
                                </div>
                                <asp:Panel runat="server" ID="plOtClass" CssClass="col-md-3" Visible="false">
                                        <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblOverTimeClassDic1" Text="加班班別"></telerik:RadLabel></label>
                                        <telerik:RadComboBox ID="ddlRote" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" Width="100%" Skin="Bootstrap">
                                        </telerik:RadComboBox>
                                </asp:Panel>
                                <asp:Panel CssClass="col-md-3" id="OtReason" runat="server">
                                    <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblReasonDic1" Text="加班原因"></telerik:RadLabel></label>
                                    <telerik:RadComboBox ID="ddlOtrcd" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" Width="100%" Skin="Bootstrap">
                                    </telerik:RadComboBox>
                                </asp:Panel>
                                <asp:Panel CssClass="col-md-3" id="OtDept" runat="server">
                                    <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblOtDeptDic" Text="加班部門"></telerik:RadLabel></label>
                                    <telerik:RadComboBox ID="ddlDepts" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" Width="100%" Skin="Bootstrap">
                                    </telerik:RadComboBox>
                                </asp:Panel>
                                <%-- 修正開始 --%><asp:Panel CssClass="col-md-3" id="OtPayment" runat="server">
                                    <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblOtPaymentDic1" Text="給付方式"></telerik:RadLabel></label>
                                    <telerik:RadComboBox ID="ddlOtCat" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" Width="100%" Skin="Bootstrap">
                                    </telerik:RadComboBox>
                                </asp:Panel>
                                <%-- 修正結束 --%>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-3" id="data_1">
                                    <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblBeginDateDic" Text="開始日期"></telerik:RadLabel></label>
                                    <telerik:RadDatePicker ID="txtDateB" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%"
                                        OnSelectedDateChanged="txtDateB_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </div>

                                <div class="col-md-3" id="data_2">
                                    <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblEndDateDic" Text="結束日期"></telerik:RadLabel></label>
                                    <telerik:RadDatePicker ID="txtDateE" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%"
                                        OnSelectedDateChanged="txtDateE_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </div>

                                <%-- 修正開始 --%>
                                <div class="col-md-3">
                                    <%-- 修正結束 --%>
                                    <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblBeginTimeDic" Text="開始時間"></telerik:RadLabel></label>
                                    <telerik:RadMaskedTextBox ID="txtTimeB" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                                    </telerik:RadMaskedTextBox>
                                </div>
                                <%-- 修正開始 --%><div class="col-md-3">
                                    <%-- 修正結束 --%>
                                    <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblEndTimeDic" Text="結束時間"></telerik:RadLabel></label>
                                    <%--<div class="input-group clockpicker" data-autoclose="true">
                                        <telerik:RadLabel type="text" class="form-control" value="17:30">
                                        <span class="input-group-addon">
                                            <span class="fa fa-clock-o form_icon"></span>
                                        </span>
                            		</div>     --%>
                                    <telerik:RadMaskedTextBox ID="txtTimeE" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                                    </telerik:RadMaskedTextBox>
                                </div>

                            </div>
                            <div class="form-group row">
                                <div class="col-md-6">
                                    <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblCardTimeDic" Text="刷卡時間"></telerik:RadLabel></label>
                                    <div class="box">
                                        <asp:Label ID="lblCardTime" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblNoteDic1" Text="備註"></telerik:RadLabel></label>
                                        <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="請輸入您的原因..."
                                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                            </div>

                            <asp:Panel runat="server" ID="plOtInfo">
                                <div class="form-group row">
                                    <div class="col-md-6">
                                        <h5><telerik:RadLabel runat="server" ID="lblOtInfoDic" Text="加班資訊"></telerik:RadLabel></h5>
                                        <div class="form-group">
                                            <table class="table table-bordered text-center">
                                                <thead>
                                                    <tr>
                                                        <th>本月加班時數</th>
                                                        <th>進行中申報加班時數</th>
                                                        <%--<th>本月已核准加班時數</th>--%>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <telerik:RadLabel ID="lblTotalOtHours" runat="server" Text="0.0" Skin="Bootstrap"></telerik:RadLabel>
                                                        </td>
                                                        <td>
                                                            <telerik:RadLabel ID="lblTotalOtGFlowHours" runat="server" Text="0.0" Skin="Bootstrap"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group row">
                                <div class="col-md-12">
                                    <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblNoteDic2" Text="備註事項"></telerik:RadLabel>：</label>
                                    <telerik:RadLabel ID="lblFormNoteStd" runat="server"></telerik:RadLabel>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>

                            <div class="row">
                                <div class="col-md-1">
                                    <telerik:RadButton ID="btnAdd" runat="server" Text="新增" CssClass="btn btn-outline btn-primary" OnClick="btnAdd_Click" />

                                </div>
                                <div class="col-md-8">
                                    <h3>
                                        <telerik:RadLabel ID="lblErrorMsg" runat="server" Text="" CssClass="text-danger"></telerik:RadLabel>
                                    </h3>
                                </div>
                            </div>


                        </telerik:RadAjaxPanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc:FileManage ID="ucFileManage" runat="server" />
    <asp:Label ID="lblNobrAppS" runat="server" Skin="Bootstrap" Visible="false"></asp:Label>
    <asp:Label ID="lblNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDeptNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblDeptCodeAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblJobNameAppM" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblProcessID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblFlowTreeID" runat="server" Visible="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
