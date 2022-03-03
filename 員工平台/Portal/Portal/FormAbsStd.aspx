<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.master" AutoEventWireup="true" CodeBehind="FormAbsStd.aspx.cs" Inherits="Portal.FormAbsStd" %>

<%@ Register Src="~/UserControls/UC_FileManage.ascx" TagPrefix="uc" TagName="FileManage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvAppS">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblErrorMsg" />
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
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-6 col-lg-3"><telerik:RadLabel runat="server" ID="lblBeginDateDic" Text="開始日期"></telerik:RadLabel>：<%# Eval("DateB","{0:yyyy/MM/dd}") %></div>
                                    <div class="col-6 col-lg-3"><telerik:RadLabel runat="server" ID="lblBeginTimeDic" Text="開始時間"></telerik:RadLabel>：<%# Eval("TimeB") %></div>
                                    <div class="col-6 col-lg-3"><telerik:RadLabel runat="server" ID="lblEndDateDic" Text="結束日期"></telerik:RadLabel>：<%# Eval("DateE","{0:yyyy/MM/dd}") %></div>
                                    <div class="col-6 col-lg-3"><telerik:RadLabel runat="server" ID="lblEndTimeDic" Text="結束時間"></telerik:RadLabel>：<%# Eval("TimeE") %></div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-lg-3"><telerik:RadLabel runat="server" ID="lblAbsenceNameDic" Text="假別"></telerik:RadLabel>：<%# Eval("HolidayName") %></div>
                                    <div class="col-6 col-lg-3"><telerik:RadLabel runat="server" ID="lblAgentDic" Text="代理人"></telerik:RadLabel>：<%# Eval("AgentEmpName") %></div>
                                    <div class="col-6 col-lg-3"><telerik:RadLabel runat="server" ID="lblAbsenceHourDic" Text="請假時數"></telerik:RadLabel>：<%# Eval("Use") %></div>
                                    <div class="col-6 col-lg-3"><telerik:RadLabel runat="server" ID="lblUnitDic" Text="單位"></telerik:RadLabel>：<%# Eval("UnitCode") %></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6"><telerik:RadLabel runat="server" ID="lblReasonDic" Text="原因"></telerik:RadLabel>：<%# Eval("Note") %></div>
                                    <div class="col-md-6"><telerik:RadLabel runat="server" ID="lblAgentNoteDic" Text="交辦事項"></telerik:RadLabel>：<%# Eval("AgentNote") %></div>
                                </div>
                          
                            </div>                            
                            <div class="col-sm-2">
                                <telerik:RadButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn btn-outline btn-danger" OnClientClicking="Clicking"
                                    CommandName="Del" Text="刪除">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnUpload" runat="server" CssClass="btn btn-outline btn-warning" CommandArgument='<%# Eval("AutoKey") %>' CommandName="Upload" data-toggle="modal" data-target="#myModal" Text="附件" OnClick="btnUpload_Click">
                                </telerik:RadButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <telerik:RadLabel runat="server" ID="lblAbsEmptyMessageDic" Text="尚未新增請假資料"></telerik:RadLabel>
                </EmptyDataTemplate>
                
            </telerik:RadListView>
            <telerik:RadLabel ID="lblNotifyMsg" runat="server" CssClass="text-danger" Text=""></telerik:RadLabel>
        </telerik:RadAjaxPanel>
    </div>
    <div class="ibox" style="padding: 20px 0px 0px 0px">
        <div class="ibox-title">
            <h5><telerik:RadLabel runat="server" ID="lblApplicationInfoDic" Text="申請資訊"></telerik:RadLabel></h5>
            <div class="ibox-tools">
                <a class="collapse-link">
                    <i class="fa fa-chevron-up"></i>
                </a>
            </div>
        </div>
        <div class="ibox-content">
            <telerik:RadAjaxPanel ID="plAppS" runat="server">
                <div class="form-group row">
                    <asp:Panel runat="server" ID="plName" CssClass="col-md-3">
                        <label class=" col-form-label" style="width: 100%"><telerik:RadLabel runat="server" ID="lblRespondentNameDic" Text="被申請人姓名"></telerik:RadLabel></label>
                        <telerik:RadComboBox ID="txtNameAppS" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                            AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                            LoadingMessage="載入中…" Width="100%" OnDataBound="txtNameAppS_DataBound"
                            OnSelectedIndexChanged="txtNameAppS_SelectedIndexChanged" OnTextChanged="txtNameAppS_TextChanged">
                        </telerik:RadComboBox>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="plAgent" CssClass="col-md-3">
                        <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblAgentDic" Text="代理人"></telerik:RadLabel></label>
                        <telerik:RadComboBox ID="txtNameAgent1" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                            AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                            LoadingMessage="載入中…" Width="100%" OnDataBound="txtNameAgent1_DataBound" OnSelectedIndexChanged="txtNameAgent1_SelectedIndexChanged"
                            OnTextChanged="txtNameAgent1_TextChanged">
                        </telerik:RadComboBox>
                    </asp:Panel>
                    <div class="col-md-6">
                        <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblAbsenceTypeDic" Text="請假類別"></telerik:RadLabel></label>
                        <telerik:RadComboBox ID="txtHcode" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                            ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="txtHcode_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <telerik:RadLabel ID="lblBalanceDic" runat="server" Text="剩餘"></telerik:RadLabel>
                        <telerik:RadLabel ID="lblUnitDic" runat="server" Text="單位"></telerik:RadLabel>
                    </div>
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
                        <telerik:RadDatePicker ID="txtDateE" runat="server" AutoPostBack="True" Skin="Bootstrap" Width="100%">
                        </telerik:RadDatePicker>
                    </div>
                    <div class="col-md-3">
                        <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblBeginTimeDic" Text="開始時間"></telerik:RadLabel></label>
                        <telerik:RadMaskedTextBox ID="txtTimeB" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                        </telerik:RadMaskedTextBox>
                    </div>
                    <div class="col-md-3">
                        <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblEndTimeDic" Text="結束時間"></telerik:RadLabel></label>
                        <%--<div class="input-group clockpicker" data-autoclose="true">
                                        <telerik:RadLabel type="text" class="form-control" value="17:30">
                                        <span class="input-group-addon">
                                            <span class="fa fa-clock-o form_icon"></span>
                                        </span>
                            		</div>--%>
                        <telerik:RadMaskedTextBox ID="txtTimeE" runat="server" Mask="####" Width="100%" Skin="Bootstrap">
                        </telerik:RadMaskedTextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblReasonDic" Text="原因"></telerik:RadLabel></label>
                            <telerik:RadTextBox ID="txtNote" runat="server" EmptyMessage="請輸入您的原因..."
                                TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class=" col-form-label"><telerik:RadLabel runat="server" ID="lblAgentNoteDic" Text="交辦事項"></telerik:RadLabel></label>
                            <telerik:RadTextBox ID="txtAgent" runat="server" EmptyMessage="請填寫您的交辦事項..."
                                TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                </div>



                <div class="row">
                    <div class="col-md-12">
                        <label class="col-form-label"><telerik:RadLabel runat="server" ID="lblNoteDic" Text="備註事項"></telerik:RadLabel>：</label>
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
                            <telerik:RadLabel ID="lblMsg" runat="server" Text="" CssClass="text-danger"></telerik:RadLabel>
                        </h3>
                    </div>
                </div>

               

                
                
                
            </telerik:RadAjaxPanel>
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
    <script src="Templates/Inspinia/js/plugins/dropzone/dropzone.js"></script>
    <script type="text/javascript">
        DropzoneInit();
        function DropzoneInit(sender, eventArgs) {
            Dropzone.autoDiscover = false;
            //Simple Dropzonejs 
            $("#dZUpload").dropzone({
                //指定上传图片的路径
                url: "HandlerFileUploadDropzone.ashx",
                //method: "post",
                //添加上传取消和删除预览图片的链接，默认不添加
                addRemoveLinks: true,
                //关闭自动上传功能，默认会true会自动上传
                //也就是添加一张图片向服务器发送一次请求
                autoProcessQueue: true,
                //允许上传多个照片
                uploadMultiple: false,
                //每次上传的最多文件数，经测试默认为2，坑啊
                //记得修改web.config 限制上传文件大小的节
                parallelUploads: 1, //手动触发时一次最大可以上传多少个文件
                maxFiles: 1, //一次上传的量
                maxFilesize: 5,   //M为单位
                acceptedFiles: ".jpg,.jpeg,.doc,.docx,.ppt,.pptx,.txt,.avi,.pdf,.mp3,.zip,.pdf,.png",//可接受的上传类型
                dictDefaultMessage: "點擊或拖入要上傳的文件",      //上传框默认显示文字
                dictMaxFilesExceeded: "一次只能上傳1個檔案",
                dictResponseError: "上傳失敗",
                dictInvalidFileType: "此檔案類型不能上傳",
                dictFallbackMessage: "瀏覽器不支援",
                dictFileTooBig: "檔案大小超過限制(5MB)",
                success: function (file, response) {
                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgName);

                    //this.removeAllFiles();
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });
        }
    </script>
</asp:Content>
