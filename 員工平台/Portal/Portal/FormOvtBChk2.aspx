<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsChk.master" AutoEventWireup="true" CodeBehind="FormOvtBChk2.aspx.cs" Inherits="Portal.FormOvtBChk2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvAppS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plChangeTime" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plChangeTime" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="ibox">
        <div class="ibox-content">
            <telerik:RadLabel ID="lblNotifyMsg" runat="server" Style="color: red;" Text=""></telerik:RadLabel>
            <telerik:RadAjaxPanel ID="plInfo" runat="server">
                <telerik:RadListView ID="gvAppS" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="gvAppS_NeedDataSource" OnItemDataBound="gvAppS_ItemDataBound">
                    <LayoutTemplate>
                        <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                            <thead>
                            </thead>
                            <tbody id="Container" runat="server">
                            </tbody>
                            <tfoot>
                            </tfoot>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="keyin keyin-border">
                            <div class="row">
                                <div class="col-md-2 m-t-xs">
                                    <h3>
                                        <telerik:RadLabel ID="lblEmpName" runat="server" Text='<%# Eval("EmpName") %>'></telerik:RadLabel>,
                                        <telerik:RadLabel ID="lblEmpId" runat="server" Text='<%# Eval("EmpId") %>'></telerik:RadLabel>
                                        <%--<%# Eval("EmpName") %>,
                                    <%# Eval("EmpId") %>--%>
                                    </h3>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col col-xs-6">
                                            <span><telerik:RadLabel runat="server" ID="lblBeginDateDic" Text="開始日期"></telerik:RadLabel>：<telerik:RadLabel ID="lblDateB" runat="server" Text='<%# Eval("DateB","{0:yyyy/MM/dd}") %>'></telerik:RadLabel></span><br>
                                            <span><telerik:RadLabel runat="server" ID="lblBeginTimeDic" Text="開始時間"></telerik:RadLabel>：<telerik:RadLabel ID="lblTimeB" runat="server" Text='<%# Eval("TimeB") %>'></telerik:RadLabel></span><br>
                                            <%--<span>開始日期：<%# Eval("DateB","{0:yyyy/MM/dd}") %></span><br>
                                            <span>開始時間：<%# Eval("TimeB") %></span>--%>
                                        </div>

                                        <div class="col col-xs-6">
                                            <span><telerik:RadLabel runat="server" ID="lblEndDateDic" Text="結束日期"></telerik:RadLabel>：<telerik:RadLabel ID="lblDateE" runat="server" Text='<%# Eval("DateE","{0:yyyy/MM/dd}") %>'></telerik:RadLabel></span><br>
                                            <span><telerik:RadLabel runat="server" ID="lblEndTimeDic" Text="結束時間"></telerik:RadLabel>：<telerik:RadLabel ID="lblTimeE" runat="server" Text='<%# Eval("TimeE") %>'></telerik:RadLabel></span><br>
                                            <%--<span>結束日期：<%# Eval("DateE","{0:yyyy/MM/dd}") %></span><br>
                                            <span>結束時間：<%# Eval("TimeE") %></span>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col col-xs-4">
                                            <span><telerik:RadLabel runat="server" ID="lblOverTimeClassDic" Text="加班班別"></telerik:RadLabel>：<%# Eval("RoteName") %></span><br>
                                            <span><telerik:RadLabel runat="server" ID="lblReasonDic" Text="加班原因"></telerik:RadLabel>：<%# Eval("OtrcdName") %></span>
                                        </div>

                                        <div class="col col-xs-4">
                                            <span><telerik:RadLabel runat="server" ID="lblOtHourDic" Text="申請時數"></telerik:RadLabel>：<%# Eval("Use") %></span><br>
                                            <span><telerik:RadLabel runat="server" ID="lblUnitDic" Text="單位"></telerik:RadLabel>：<%# Eval("UnitCode") %></span>
                                        </div>
                                        <div class="col col-xs-4">
                                            <span><telerik:RadLabel runat="server" ID="lblOtPaymentDic" Text="給付方式"></telerik:RadLabel>：<%# Eval("OtCateName") %></span><br>
                                            <span style="word-break: break-all;"><telerik:RadLabel runat="server" ID="lblNoteDic" Text="備註"></telerik:RadLabel>：<%# Eval("Note") %></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <telerik:RadButton ID="btnChangeTime" runat="server" Text="修改" CssClass="btn btn-w-m btn-warning" OnClick="btnChangeTime_Click" ToolTip='<%# Eval("AutoKey") %>' data-toggle="modal" data-target="#myModal"></telerik:RadButton>
                                    <telerik:RadRadioButtonList runat="server" ID="btnCheck" FeatureGroupID='<%# Eval("AutoKey") %>' ToolTip='<%# Eval("SignState") %>' OnSelectedIndexChanged="btnCheck_SelectedIndexChanged">
                                        <Items>
                                            <telerik:ButtonListItem Text="核准" Value="1" Selected="true" />
                                            <telerik:ButtonListItem Text="駁回" Value="2" />
                                        </Items>
                                    </telerik:RadRadioButtonList>
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
                        出現異常，請通知HR
                    </EmptyDataTemplate>
                </telerik:RadListView>
                
            </telerik:RadAjaxPanel>
            <div class="row">
                <div class="col-lg-12">
                    <label class=" col-form-label "><telerik:RadLabel runat="server" ID="lblOpinionDic" Text="意見"></telerik:RadLabel></label>
                    <telerik:RadTextBox ID="txtNote" runat="server" Skin="Bootstrap"
                        Height="50px" TextMode="MultiLine" Width="100%">
                    </telerik:RadTextBox>
                </div>
            </div>
            <div class="hr-line-dashed"></div>
            <div class="row">
                <div class="col-lg-12">
                    <h5><telerik:RadLabel runat="server" ID="lblSignPathDic" Text="簽核過程"></telerik:RadLabel></h5>
                    <div>
                        <telerik:RadListView ID="lvSignM" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container" OnNeedDataSource="lvSignM_NeedDataSource">
                            <LayoutTemplate>
                                <table id="footableTaken" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                                    <thead>
                                        <%-- <tr>
                                            <td colspan="2" style="text-align: center">動作</td>
                                            
                                            <th>時間</th>
                                            <th>假別</th>
                                            <th>使用</th>
                                            <th>單位</th>
                                            <th>代理人</th>
                                        </tr>--%>
                                        <th><telerik:RadLabel runat="server" ID="lblSignManagerDic" Text="簽核主管"></telerik:RadLabel></th>
                                        <th><telerik:RadLabel runat="server" ID="lblSignDeptDic" Text="簽核部門"></telerik:RadLabel></th>
                                        <th><telerik:RadLabel runat="server" ID="lblSignDateDIc" Text="簽核日期"></telerik:RadLabel></th>
                                        <th><telerik:RadLabel runat="server" ID="lblOpinionDic1" Text="意見"></telerik:RadLabel></th>
                                    </thead>
                                    <tbody id="Container" runat="server">
                                        <tr>
                                            <td>test
                                            </td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="3">
                                                <ul class="pagination float-right"></ul>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr class="gradeX">
                                    <td><%# Eval("EmpName") %>,<%# Eval("EmpId") %></td>
                                    <td><%# Eval("DeptName") %></td>
                                    <td><%# Eval("InsertDate") %></td>
                                    <td><%# Eval("SignNote") %></td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                尚未有主管簽核紀錄
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                    </div>
                </div>
            </div>

            <div class="hr-line-dashed"></div>
        </div>
    </div>

    <div style="display: none">
        <telerik:RadLabel ID="lblProcessID" runat="server" Visible="false"></telerik:RadLabel>
    </div>

    <div class="modal inmodal" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content animated bounceInRight">

                <telerik:RadAjaxPanel ID="plChangeTime" runat="server">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <i class="fa fa-laptop modal-icon"></i>
                        <h4 class="modal-title">修改時數</h4>
                    </div>
                    <div class="modal-body">
                        <div class="wrapper wrapper-content animated fadeIn">
                            <div class="row">

                                <div class="col-lg-12">
                                    <div class="ibox ">
                                        <div class="ibox-title">
                                            <h5></h5>
                                            <div class="ibox-tools">
                                                <a class="collapse-link">
                                                    <i class="fa fa-chevron-up"></i>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="ibox-content">
                                            <%--<telerik:RadListView ID="lvChangeTime" runat="server" RenderMode="Lightweight" Skin="" ItemPlaceholderID="Container2">
                                            <LayoutTemplate>
                                                <table id="footableTaken2" class="footable table table-stripped" data-page-size="10" data-filter="#filterTaken">
                                                    <thead>
                                                    </thead>
                                                    <tbody id="Container2" runat="server">
                                                    </tbody>
                                                    <tfoot>
                                                    </tfoot>
                                                </table>
                                            </LayoutTemplate>
                                            <ItemTemplate>
                                                <div class="keyin keyin-border">
                                                    <div class="row">
                                                        <div class="col-md-2 m-t-xs">
                                                            <h3>
                                                            </h3>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="row">
                                                                <div class="col col-xs-12">
                                                                    <span>工號：<%# Eval("DateB","{0:yyyy/MM/dd}") %></span><br>
                                                                    <span>姓名：<%# Eval("TimeB") %></span><br>
                                                                    <span>日期：<%# Eval("DateB","{0:yyyy/MM/dd}") %></span><br>
                                                                    <span>刷卡時間：<telerik:RadLabel ID="lblCardTime" runat="server"></telerik:RadLabel>
                                                                    </span>
                                                                    <br>
                                                                    <span>開始時間：<telerik:RadMaskedTextBox ID="txtTimeB" runat="server" Mask="####" Width="50px" Skin="Bootstrap">
                                                                    </telerik:RadMaskedTextBox>
                                                                    </span>
                                                                    <br>
                                                                    <span>結束時間：<telerik:RadMaskedTextBox ID="txtTimeE" runat="server" Mask="####" Width="50px" Skin="Bootstrap">
                                                                    </telerik:RadMaskedTextBox>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                出現異常，請通知HR
                                            </EmptyDataTemplate>
                                        </telerik:RadListView>--%>
                                            <div class="form-group row">
                                                <div class="col-md-3">
                                                    <label class=" col-form-label">工號：</label>
                                                    <telerik:RadLabel ID="lblNobr" runat="server" Skin="Bootstrap"></telerik:RadLabel>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-md-3">
                                                    <label class=" col-form-label">姓名：</label>
                                                    <telerik:RadLabel ID="lblName" runat="server" Skin="Bootstrap"></telerik:RadLabel>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-md-3">
                                                    <label class=" col-form-label">日期：</label>
                                                    <telerik:RadLabel ID="lblDate" runat="server" Skin="Bootstrap"></telerik:RadLabel>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-md-3">
                                                    <label class=" col-form-label">刷卡時間：</label>
                                                    <telerik:RadLabel ID="lblCardTime" runat="server" Skin="Bootstrap"></telerik:RadLabel>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-md-3">
                                                    <label class=" col-form-label">開始時間：</label>
                                                    <telerik:RadMaskedTextBox ID="txtTimeB" runat="server" Mask="####" Width="200px" Skin="Bootstrap">
                                                    </telerik:RadMaskedTextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-md-3">
                                                    <label class=" col-form-label">結束時間：</label>
                                                    <telerik:RadMaskedTextBox ID="txtTimeE" runat="server" Mask="####" Width="200px" Skin="Bootstrap">
                                                    </telerik:RadMaskedTextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <div class="col-md-3">
                                                    <telerik:RadButton ID="btnConfirm" runat="server" Text="確認" CssClass="btn btn-w-m btn-primary" OnClick="btnConfirm_Click"></telerik:RadButton>
                                                    <telerik:RadLabel ID="lblAutokey" runat="server" Visible="false" ></telerik:RadLabel>
                                                    <telerik:RadLabel ID="lblErrorMsg" runat="server" Style="color: red;"></telerik:RadLabel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <label class=" col-form-label">修改完畢字樣出現後才可關閉視窗</label>
                        <button type="button" class="btn btn-white" data-dismiss="modal">關閉</button>
                    </div>
                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" runat="server">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.footable').footable();
            $('.footableTaken').footable();
        });
    </script>
</asp:Content>
