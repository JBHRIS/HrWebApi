<%@ Page Title="" Language="C#" MasterPageFile="~/MainFlowFormsStd.master" AutoEventWireup="true" CodeBehind="FormAppointStd.aspx.cs" Inherits="Portal.FormAppointStd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCondition" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblCheckMsg" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>

    </telerik:RadAjaxManagerProxy>
    <div class="ibox-content">
        <telerik:RadAjaxPanel runat="server" ID="plAppS">
            <div class="row form-group">
                <div class="col-md-6">
                    <label class="col-form-label" style="width: 100%">申請人員</label>
                    <telerik:RadComboBox ID="txtNameAppS" runat="server" Culture="zh-TW" AllowCustomText="True" Skin="Bootstrap"
                        AutoPostBack="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                        LoadingMessage="載入中…" Width="100%" OnDataBound="txtNameAppS_DataBound"
                        OnSelectedIndexChanged="txtNameAppS_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </div>
                <div class="col-md-6">
                    <label class="col-form-label" style="width: 100%">調任申請</label>
                    <telerik:RadComboBox ID="ddlChangeItem" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                        ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlChangeItem_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </div>
            </div>



            <div class="row form-group">
                <div class="col-md-3">
                    <label class="col-form-label">員工姓名</label>
                    <telerik:RadLabel ID="lblName" CssClass="form-control" runat="server" />
                </div>

                <div class="col-md-3">
                    <label class="col-form-label">學歷</label>
                    <telerik:RadLabel ID="lblEducation" CssClass="form-control" runat="server" />
                </div>

                <div class="col-md-3">
                    <label class=" col-form-label">出生日期</label>
                    <telerik:RadLabel ID="lblBirthday" CssClass="form-control" runat="server" />
                </div>

                <div class="col-md-3">
                    <label class=" col-form-label">到職日期</label>
                    <telerik:RadLabel ID="lblDateIn" CssClass="form-control" runat="server" />
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                    <label class=" col-form-label">部門</label>
                    <telerik:RadLabel ID="lblDept" CssClass="form-control" runat="server" />
                </div>

                <div class="col-md-1">
                    <label class=" col-form-label">職等</label>
                    <telerik:RadLabel ID="lblJobl" CssClass="form-control" runat="server" />
                </div>

                <div class="col-md-2">
                    <label class=" col-form-label">職稱</label>
                    <telerik:RadLabel ID="lblJob" CssClass="form-control" runat="server" />
                </div>

                <div class="col-md-3">
                    <label class=" col-form-label">任職日期</label>
                    <telerik:RadLabel ID="lblDateA" CssClass="form-control" runat="server" />
                </div>

                <div class="col-md-3">
                    <label class=" col-form-label">簽核部門</label>
                    <telerik:RadLabel ID="lblDepta" CssClass="form-control" runat="server" />
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                    <label class=" col-form-label">調動部門</label>
                    <telerik:RadComboBox ID="ddlDept" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                        ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%">
                    </telerik:RadComboBox>
                </div>

                <div class="col-md-1">
                    <label class=" col-form-label">調動職等</label>
                    <telerik:RadComboBox ID="ddlJobl" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                        ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%">
                    </telerik:RadComboBox>
                </div>


                <div class="col-md-2">
                    <label class=" col-form-label">調動職稱</label>
                    <telerik:RadComboBox ID="ddlJob" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                        ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%">
                    </telerik:RadComboBox>
                </div>


                <div class="col-md-3">
                    <label class=" col-form-label">調動任職日期</label>
                    <div class="input-group date">
                        <telerik:RadDatePicker ID="txtDateAppoint" RenderMode="Lightweight" runat="server" Skin="Bootstrap" Width="100%" />
                    </div>
                </div>

                <div class="col-md-3">
                    <label class=" col-form-label">調動簽核部門</label>
                    <telerik:RadComboBox ID="ddlDepta" runat="server" Culture="zh-TW" EnableVirtualScrolling="True" Skin="Bootstrap"
                        ItemsPerRequest="10" LoadingMessage="載入中…" AutoPostBack="True" Width="100%">
                    </telerik:RadComboBox>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6">
                    <label class=" col-form-label">異動原因</label>
                    <telerik:RadTextBox ID="txtReasonChange" runat="server" Skin="Bootstrap" EmptyMessage="請填寫說明原因..." Rows="3" TextMode="MultiLine" Width="100%" />
                </div>
                <div class="col-md-6">

                    <label class="col-form-label">考績紀錄</label>

                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>年度</th>
                                <th>
                                    <telerik:RadLabel ID="lblyear1" runat="server" Text="105" />
                                </th>
                                <th>
                                    <telerik:RadLabel ID="lblyear2" runat="server" Text="106" />
                                </th>
                                <th>
                                    <telerik:RadLabel ID="lblyear3" runat="server" Text="107" />
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>考績</td>
                                <td>
                                    <telerik:RadLabel ID="lblPerformance1" runat="server" />
                                </td>
                                <td>
                                    <telerik:RadLabel ID="lblPerformance2" runat="server" />
                                </td>
                                <td>
                                    <telerik:RadLabel ID="lblPerformance3" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>
            </div>
            <asp:Panel runat="server" ID="plPromotion">
                <div class="hr-line-dashed"></div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="bg-muted p-xs b-r-sm  m-b-md">人事晉升復核表</div>

                        <div class="form-group row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class=" col-form-label">現任職務執行情形之考評</label>
                                    <telerik:RadTextBox ID="txtPerformance1" runat="server" Skin="Bootstrap" EmptyMessage="請具體記述擬晉升人對現任職務之執行情形是否達於優良水準,並列述認定之理由..." Rows="12" TextMode="MultiLine" Width="100%"/>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class=" col-form-label">適任性之判斷</label>
                                    <telerik:RadTextBox ID="txtPerformance2" runat="server" Skin="Bootstrap" EmptyMessage="請記述擬晉升人能否勝任擬晉升之職務,及判斷之理由..." Rows="12" TextMode="MultiLine" Width="100%"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="hr-line-dashed"></div>

            <div class="col-sm-2 m-t-sm">
                <telerik:RadButton ID="btnConfirm" CssClass="btn-outline btn-primary" runat="server" OnClick="btnConfirm_Click" Text="確認" />
            </div>

        </telerik:RadAjaxPanel>
        <telerik:RadLabel runat="server" ID="lblCheckMsg" CssClass="badge badge-danger"></telerik:RadLabel>
        <telerik:RadLabel runat="server" ID="lblProcessID" Visible="false"></telerik:RadLabel>
        <telerik:RadLabel runat="server" ID="lblFlowTreeID" Visible="false"></telerik:RadLabel>
        <asp:Label ID="lblNobrAppS" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblNameAppM" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblNobrAppM" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblRoleAppM" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblDeptNameAppM" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblDeptCodeAppM" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblDeptaCodeAppM" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblJobNameAppM" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblJobCodeAppM" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblJoblCodeAppM" runat="server" Visible="False"></asp:Label>

    </div>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
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

