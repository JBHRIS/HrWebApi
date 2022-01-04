<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.master" AutoEventWireup="true" CodeBehind="FormOtStd.aspx.cs" Inherits="Portal.FormOtStd" %>

<%@ Register Src="~/UserControls/UC_FileManage.ascx" TagPrefix="uc" TagName="FileManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="ibox-content">
        <telerik:RadAjaxPanel ID="plInfo" runat="server">
            <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="gvAppS_NeedDataSource" OnItemCommand="gvAppS_ItemCommand">
                <%--OnNeedDataSource="gvAppS_NeedDataSource" OnDataBound="gvAppS_DataBound" --%>
                <LayoutTemplate>
                    <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                        <thead>
                        </thead>
                        <tbody id="Container" runat="server">
                        </tbody>
                        <tfoot>
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
                                    <%# Eval("EmpName") %>,
                                    <%# Eval("EmpId") %>
                                </h3>
                            </div>
                            <div class="col-md-9">
                                <div class="row">
                                    <div class="col-6 col-lg-3">
                                        開始日期：<%# Eval("DateB","{0:yyyy/MM/dd}") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        開始時間：<%# Eval("TimeB") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        結束日期：<%# Eval("DateE","{0:yyyy/MM/dd}") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        結束時間：<%# Eval("TimeE") %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-lg-3">
                                        給付方式：<%# Eval("OtCateName") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        加班原因：<%# Eval("OtrcdName") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        申請時數：<%# Eval("Use") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        單位：<%# Eval("UnitCode") %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        加班班別：<%# Eval("RoteName") %>
                                    </div>
                                    <div class="col-lg-6">
                                        備註：<%# Eval("Note") %>
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
                    尚未新增加班資料
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
                        <h5>申請資訊</h5>
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
                                    <label class=" col-form-label">被申請人姓名</label>
                                    <telerik:RadComboBox ID="txtNameAppS" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                                        LoadingMessage="載入中…" Width="100%" OnDataBound="txtNameAppS_DataBound"
                                        OnSelectedIndexChanged="txtNameAppS_SelectedIndexChanged" OnTextChanged="txtNameAppS_TextChanged">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-md-3">
                                    <label class="col-form-label">加班班別</label>
                                    <telerik:RadComboBox ID="ddlRote" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" Width="100%" Skin="Bootstrap">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-md-3">
                                    <label class="col-form-label">申請原因</label>
                                    <telerik:RadComboBox ID="ddlOtrcd" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" Width="100%" Skin="Bootstrap">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-md-3">
                                    <label class="col-form-label">加班部門</label>
                                    <telerik:RadComboBox ID="ddlDepts" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" Width="100%" Skin="Bootstrap">
                                    </telerik:RadComboBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-3" id="data_1">
                                    <label class=" col-form-label">開始日期</label>
                                    <telerik:RadDatePicker ID="txtDateB" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%"
                                        OnSelectedDateChanged="txtDateB_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </div>

                                <div class="col-md-3" id="data_2">
                                    <label class=" col-form-label">結束日期</label>
                                    <telerik:RadDatePicker ID="txtDateE" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%"
                                        OnSelectedDateChanged="txtDateE_SelectedDateChanged">
                                    </telerik:RadDatePicker>
                                </div>

                                <div class="col-md-3">
                                    <label class=" col-form-label">開始時間</label>
                                    <telerik:RadMaskedTextBox ID="txtTimeB" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                                    </telerik:RadMaskedTextBox>

                                </div>

                                <div class="col-md-3">
                                    <label class=" col-form-label">結束時間</label>
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
                                <div class="col-md-3">
                                    <label class=" col-form-label">給付方式</label>
                                    <telerik:RadComboBox ID="ddlOtCat" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" ItemsPerRequest="10" LoadingMessage="載入中…" Width="100%" Skin="Bootstrap">
                                    </telerik:RadComboBox>
                                </div>
                                <div class="col-md-3">
                                    <label class=" col-form-label">出勤刷卡時間</label><br>
                                    <asp:Label ID="lblCardTime" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class=" col-form-label">備註</label>
                                        <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="請輸入您的原因..."
                                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                            </div>

                            <asp:Panel runat="server" ID="plOtInfo">
                                <div class="form-group row">
                                    <div class="col-md-6">
                                        <h5>加班資訊</h5>
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
                                    <label class=" col-form-label">備註事項：</label>
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
