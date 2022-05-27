<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturn.aspx.cs" Inherits="Portal.ProblemReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblAddStatus" />

                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
       
    </telerik:RadAjaxManager>
    <div class="ibox">

        <div class="ibox-content">
            <div class="row">
                <div class="col-lg-12">
                    <div class="alert alert-warning">
                        <i class="fa fa-exclamation-circle"></i> 本問題回報服務需3個工作天
                    </div>
                    <div class="form-group">
                        <label>標題 <small id="titlelength" class="text-navy">(0/30)</small></label>

                        <telerik:RadTextBox ID="txtTitle" runat="server" EmptyMessage="請輸入標題..." Skin="Bootstrap" Width="100%" />
                    </div>
                    <div class="form-group">
                        <label id="testlbl">回報類型</label>
                        <telerik:RadComboBox ID="txtReturnS" runat="server" Skin="Bootstrap" AllowCustomText="True"
                            AutoPostBack="false" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains"
                            LoadingMessage="載入中…" Width="100%">
                        </telerik:RadComboBox>
                    </div>
                    <div class="form-group">
                        <label>內容 <small class="text-navy" id="contentlength">(0/500)</small></label>
                        <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                            TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="4">
                        </telerik:RadTextBox>
                    </div>
                    <%--<div class="form-group row">
                        <label class="col-lg-2 col-form-label">附件</label>
                        <div class="col-lg-10 col-form-label">
                             <telerik:RadButton ID="btnUpload" runat="server" Text="上傳附件" CssClass="btn btn-primary btn-md" OnClick="btnUpload_Click" />

                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label>附件<span class="text-navy"> *單次僅能上傳一個檔案；檔案大小限制為10MB</span></label>
                        <div id="dZUpload" class="dropzone" style="border: 1px solid #e5e6e7;">
                            <div class="dz-default dz-message text-center m-t-md">
                                <i class="fa fa-cloud-upload fa-2x text-primary"></i>
                                <br />
                                請點此選擇上傳的檔案
                            </div>
                        </div>
                    </div>
                       <telerik:RadAjaxPanel ID="plUpload" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                    <div class="form-group">
                     
                            <div class="row">
                                <div class="col-4 col-sm-2">
                                    <telerik:RadButton ID="btnUpload" runat="server" Text="上傳檔案" CssClass="btn btn-primary btn-outline" OnClick="btnUpload_Click" />
                                </div>
                                <div class="col-8 col-sm-8">
                                    <telerik:RadLabel ID="lblMsg" runat="server" />
                                    <telerik:RadLabel ID="lblKey" runat="server" Visible="false" />
                                </div>
                            </div>
                     
                    </div>
                    <div id="iboxContent" class="ibox">
                        <div class="ibox-title">
                            <h5>附件</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <telerik:RadAjaxPanel ID="RadAjaxPanel4" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                                <telerik:RadListView ID="DataUpload" runat="server" ItemPlaceholderID="Container" RenderMode="Lightweight" OnNeedDataSource="DataUpload_NeedDataSource">
                                    <LayoutTemplate>
                                        <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                            <thead>
                                                <tr>
                                                    <th>檔名</th>
                                                    <th data-hide="phone,tablet">大小</th>
                                                    <th>動作</th>
                                                </tr>
                                            </thead>
                                            <tbody id="Container" runat="server">
                                            </tbody>
                                            <!--<tfoot>
                                                <tr>
                                                    <td colspan="5">
                                                        <ul class="pagination float-right"></ul>
                                                    </td>
                                                </tr>
                                            </tfoot>-->
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr class="gradeX">
                                            <td data-th="檔名"><%#Eval("UploadName") %></td>
                                            <td data-th="大小"><%#Eval("Size") %></td>
                                            <td data-th="動作">
                                                <asp:Button ID="btnDownload" runat="server" CommandArgument='<%#Eval("AutoKey") %>' Width="60%" OnClientClick='<%#"download(\""+Eval("AutoKey")+"\");" %>' CommandName="Download" Text="下載" CssClass="btn-white btn btn-xs" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        目前並無上傳任何檔案
                                    </EmptyDataTemplate>
                                </telerik:RadListView>
                            </telerik:RadAjaxPanel>
                        </div>
                    </div>
                   </telerik:RadAjaxPanel>
                    <div class="hr-line-dashed"></div>
                    <div class="row">
                        <div class="col-5 col-lg-2">
                            <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-md" OnClick="btnAdd_Click" />
                        </div>
                        <div class="col-7 col-lg-6 form-inline text-danger">
                            <label runat="server" id="lblAddStatus"></label>
                        </div>
                        <div class="col-12 col-lg-4 text-right"><span class="m-t-xs">IP：<telerik:RadLabel ID="lblIP" runat="server" /></span></div>




                    </div>
                    <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
                     <asp:Label ID="lblEmpEmail" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>
                </div>

                <!--<div class="col-lg-5">
                    <h2>你可能還想知道....</h2>
                    <span class="keyword_tag">特殊假別</span>
                    <span class="keyword_tag">Scroll navbar</span>
                    <span class="keyword_tag">Scroll navbar</span>
                    <span class="keyword_tag">Scroll navbar</span>

                    <div class="row col-lg-12 m-t-md">
                        <div class="keyword_font">特殊假別相關問題</div>
                    </div>
                    <div class="row col-lg-12">
                        <span class="keyword_font">特殊假別相關問題</span>
                    </div>
                </div>-->

            </div>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>
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
                maxFilesize: 10,   //M为单位
                acceptedFiles: ".jpg,.jpeg,.doc,.docx,.ppt,.pptx,.txt,.pdf,.mp3,.zip,.png,.xls,.xlsx",//可接受的上传类型
                dictDefaultMessage: "點擊或拖入要上傳的文件",      //上传框默认显示文字
                dictMaxFilesExceeded: "一次只能上傳1個檔案",
                dictResponseError: "上傳失敗",
                dictInvalidFileType: "此檔案類型不能上傳",
                dictFallbackMessage: "瀏覽器不支援",
                dictFileTooBig: "檔案大小超過限制(10MB)",
                success: function (file, response) {
                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgName);

                    //this.removeAllFiles();
                },
                error: function (file, response) {                
                    $(file.previewElement).addClass("dz-error").find('.dz-error-message').text("請檢查檔案類型及大小，或已達上傳上限");
                }
            });
        }
        function download(FileId) {

            //檔案下載網址
            var url = "Download.ashx?openExternalBrowser=1";

            //產生 form
            var form = document.createElement("form");

            form.method = "GET";
            form.action = url;

            //如果想要另開視窗可加上target
            //form.target = "_blank";

            //index為要下載的檔案編號，存入hidden跟表單一起送出
            var input = document.createElement("input");
            input.type = "hidden";
            input.name = "index";
            input.value = FileId;
            form.appendChild(input);

            //送出表單並移除 form
            var body = document.getElementsByTagName("body")[0];
            body.appendChild(form);
            form.submit();
            form.remove();
        };

    </script>

    <script>
        $(document).ready(function () {
            $('.footable').footable();
            var isPostBack = <%=this.IsPostBack.ToString().ToLower()%>;
            if (isPostBack) {
                $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                isTyping = false;
                if ($('#ctl00_ContentPlaceHolder1_txtContent').val().length > 500) {
                    $('#contentlength').css('color', 'red')

                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/500)')
                    isTyping = false;
                }
                else {
                    $('#contentlength').css('color', '#1ab394')
                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/500)')
                    isTyping = false;
                }
                if ($('#ctl00_ContentPlaceHolder1_txtTitle').val().length > 30) {
                    $('#titlelength').css('color', 'red')
                    $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                    isTyping = false;
                }
                else {
                    $('#titlelength').css('color', '#1ab394')
                    $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                    isTyping = false;
                }
            }
            else {
                $('#titlelength').text('(0/30)')
                $('#contentlength').text('(0/500)')
                isTyping = false;

            }
        });
        var isTyping

        $('#ctl00_ContentPlaceHolder1_txtTitle').on('keyup', function () {

            $('#ctl00_ContentPlaceHolder1_txtTitle').on('compositionstart', function (e) {
                isTyping = true;
            });
            $('#ctl00_ContentPlaceHolder1_txtTitle').on('compositionend', function (e) {
                isTyping = false;
            });
            if (!isTyping) {
                if ($('#ctl00_ContentPlaceHolder1_txtTitle').val().length > 30) {
                    $('#titlelength').css('color', 'red')
                    $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                    isTyping = false;
                }
                else {
                    $('#titlelength').css('color', '#1ab394')
                    $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')

                    isTyping = false;

                }

            }


        });
        $('#ctl00_ContentPlaceHolder1_txtContent').on('keyup', function () {

            $('#ctl00_ContentPlaceHolder1_txtContent').on('compositionstart', function (e) {
                isTyping = true;
            });
            $('#ctl00_ContentPlaceHolder1_txtContent').on('compositionend', function (e) {
                isTyping = false;
            });
            if (!isTyping) {
                if ($('#ctl00_ContentPlaceHolder1_txtContent').val().length > 500) {
                    $('#contentlength').css('color', 'red')

                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/500)')
                    isTyping = false;
                }
                else {
                    $('#contentlength').css('color', '#1ab394')
                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/500)')
                    isTyping = false;

                }

            }


        });


    </script>

</asp:Content>
