<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.master" AutoEventWireup="true" CodeBehind="FormAbs1Std.aspx.cs" Inherits="Portal.FormAbs1Std" %>

<%@ Register Src="~/UserControls/UC_FileManage.ascx" TagPrefix="uc" TagName="FileManage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link href="Templates/Inspinia/css/plugins/dropzone/basic.css" rel="stylesheet">
    <link href="Templates/Inspinia/css/plugins/dropzone/dropzone.css" rel="stylesheet">

    <style>
        .form-control[type=file]:not(:disabled):not([readonly]) {
            cursor: pointer;
            padding: 0;
            height: 30px;
        }

        .form-control[type=file] {
            overflow: hidden;
        }

        .form-control:disabled, .form-control[readonly] {
            background-color: #e8f6f3;
            opacity: 1;
        }

        /*form_icon*/
        .form_icon {
            color: #1ab394;
        }

        /*Select2 */
        .select2-container--bootstrap4 .select2-selection {
            border-radius: 0;
            border: 1px solid #e5e6e7;
        }

        .select2-container--bootstrap4.select2-container--focus .select2-selection {
            -webkit-box-shadow: none;
            box-shadow: none;
            border-color: #1ab394;
        }

        .select2-container--bootstrap4 .select2-selection--single .select2-selection__arrow b {
            border-color: #1ab394 transparent transparent;
        }

        .select2-container--bootstrap4 .select2-results__option--highlighted, .select2-container--bootstrap4 .select2-results__option--highlighted.select2-results__option[aria-selected=true] {
            background-color: #1ab394;
        }

        .keyin {
            padding: .75rem 1.25rem;
            margin-bottom: 1rem;
            border: 1px solid transparent;
        }

        .keyin-border {
            color: #676A6C;
            background-color: #FFFFFF;
            border-color: #e7eaec;
            box-shadow: #e8f6f3 3px 3px 1px;
        }

        @media only screen and (min-width: 375px) and (max-width:480px) {
            .col {
                padding-right: 0 !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvAppS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />

                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="ibox-content">
        <telerik:RadAjaxPanel ID="plInfo" runat="server">
            <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="gvAppS_NeedDataSource" OnDataBound="gvAppS_DataBound" OnItemCommand="gvAppS_ItemCommand">
                <LayoutTemplate>
                    <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                        <thead>
                            <%-- <tr>
                                            <td colspan="2" style="text-align: center">動作</td>
                                            <th>工號</th>
                                            <th>姓名</th>
                                            <th>開始日期</th>
                                            <th>結束日期</th>
                                            <th>時間</th>
                                            <th>假別</th>
                                            <th>使用</th>
                                            <th>單位</th>
                                            <th>代理人</th>
                                        </tr>--%>
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

                            <div class="col-md-8">
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
                                        <telerik:RadLabel runat="server" ID="lblEndTimeDic" Text="開始時間"></telerik:RadLabel>：<%# Eval("TimeE") %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblAbsenceNameDic" Text="假別"></telerik:RadLabel>：<%# Eval("HolidayName") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblAgentDic" Text="代理人"></telerik:RadLabel>：<%# Eval("AgentEmpName") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblAbsenceHourDic" Text="請假時數"></telerik:RadLabel>：<%# Eval("Use") %>
                                    </div>
                                    <div class="col-6 col-lg-3">
                                        <telerik:RadLabel runat="server" ID="lblUnitDic" Text="單位"></telerik:RadLabel>：<%# Eval("UnitCode") %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <telerik:RadLabel runat="server" ID="lblReasonDic" Text="原因"></telerik:RadLabel>：<%# Eval("Note") %>
                                    </div>
                                    <div class="col-lg-6">
                                        <telerik:RadLabel runat="server" ID="lblAgentNoteDic" Text="交辦事項"></telerik:RadLabel>：<%# Eval("AgentNote") %>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-2">

                                <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn btn-outline btn-danger" OnClientClicking="Clicking"
                                    CommandName="Del" Text="刪除">
                                </telerik:RadButton>

                                <telerik:RadButton ID="btnUpload" runat="server" CssClass="btn btn-outline btn-warning" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Upload" data-toggle="modal" data-target="#myModal" Text="附件" OnClick="btnUpload_Click">
                                </telerik:RadButton>
                                <%--<telerik:RadButton ID="btnUpload" runat="server" CssClass="btn btn-outline btn-warning" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Upload" data-toggle="modal" data-target="#myModal" Text="附件">
                                </telerik:RadButton>--%>
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
                    <telerik:RadLabel runat="server" ID="lblAbs1EmptyMessageDic" Text="尚未新增公出資料"></telerik:RadLabel>
                </EmptyDataTemplate>
            </telerik:RadListView>
            <telerik:RadLabel ID="lblNotifyMsg" runat="server" Style="color: red;" Text=""></telerik:RadLabel>
        </telerik:RadAjaxPanel>
    </div>
    <div class="ibox" style="padding: 20px 0px 0px 0px">
        <div class="ibox-title">
            <h5>申請資訊</h5>
            <div class="ibox-tools">
                <a class="collapse-link">
                    <i class="fa fa-chevron-up"></i>
                </a>
            </div>
        </div>
        <div class="ibox-content">
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                <div class="form-group row">
                    <asp:panel runat="server" ID="plName" CssClass="col-md-3">
                        <label class=" col-form-label">被申請人姓名</label>
                        <telerik:RadComboBox ID="txtNameAppS" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                            AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                            LoadingMessage="載入中…" Width="100%" OnDataBound="txtNameAppS_DataBound"
                            OnSelectedIndexChanged="txtNameAppS_SelectedIndexChanged" OnTextChanged="txtNameAppS_TextChanged">
                        </telerik:RadComboBox>
                    </asp:panel>

                    <asp:panel runat="server" ID="plAgent" CssClass="col-md-3">
                        <label class=" col-form-label">代理人</label>
                        <telerik:RadComboBox ID="txtNameAgent1" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                            AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                            LoadingMessage="載入中…" Width="100%" OnDataBound="txtNameAgent1_DataBound" OnSelectedIndexChanged="txtNameAgent1_SelectedIndexChanged"
                            OnTextChanged="txtNameAgent1_TextChanged">
                        </telerik:RadComboBox>
                    </asp:panel>

                    <div class="col-md-6">
                        <label class="col-form-label">請假類別</label>
                        <telerik:RadComboBox ID="txtHcode" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                            ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="txtHcode_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <telerik:RadLabel ID="lblBalance" runat="server" Text="剩餘"></telerik:RadLabel>
                        <telerik:RadLabel ID="lblBalanceUnit" runat="server" Text="單位"></telerik:RadLabel>
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
                        <telerik:RadDatePicker ID="txtDateE" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
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
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class=" col-form-label">原因</label>
                            <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="請輸入您的原因..."
                                TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                            </telerik:RadTextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label class=" col-form-label">交辦事項</label>
                            <telerik:RadTextBox ID="txtAgent" runat="server" EmptyMessage="請填寫您的交辦事項..."
                                TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-12">
                        <label class=" col-form-label">備註事項：</label>
                        <telerik:RadLabel ID="lblFormNoteStd" runat="server" class="form-control"></telerik:RadLabel>
                    </div>
                </div>
                <div class="hr-line-dashed"></div>

                <div class="row">
                    <div class="col-sm-1">
                        <telerik:RadButton ID="btnAdd" runat="server" Text="新增" CssClass="btn btn-outline btn-primary" OnClick="btnAdd_Click" />
                    </div>
                    <div class="col-md-8">
                         <h3>
                            <telerik:RadLabel ID="lblErrorMsg" runat="server" Text="" CssClass="text-danger"></telerik:RadLabel>
                        </h3>
                    </div>
                </div>
            </telerik:RadAjaxPanel>
            <%--<div class="form-group row">
                                <label class="col-sm-2 col-form-label">原因</label>
                                <div class="col-sm-10 col-form-label">
                                    <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="請輸入您的原因..."
                                        TextMode="MultiLine" Width="85%" Skin="Bootstrap">
                                    </telerik:RadTextBox>
                                </div>
                            </div>--%>
            <%--<div class="form-group row">
                                <label class="col-sm-2 col-form-label">員工工號</label>
                                <div class="col-sm-4 col-form-label">
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>--%>
            <%--<label class="col-sm-2 col-form-label ">已新增資料</label>--%>
        </div>
    </div>
    <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal" >
                            Launch demo modal
                        </button>--%>
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
    <asp:Label ID="lblNobrAgent1" runat="server" Visible="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
