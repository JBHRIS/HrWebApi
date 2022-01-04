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
                <div class="col-lg-7 b-r">
                    <div class="alert alert-warning">
                        <i class="fa fa-exclamation-circle"></i>本問題回報服務需3個工作天
                    </div>
                    <div class="form-group">
                        <label>標題 <small id="titlelength" style="color: #1ab394">(0/30)</small> <label runat="server" id="lblAddStatus" style="color: red;"></label></label>
                       
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
                        <label>內容 <small id="contentlength" style="color: #1ab394">(0/200)</small></label>
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
                        <label>附件
                            <br />
                            <span class="text-danger"><i class="fa fa-info-circle"></i>檔案大小限制為10MB;一次最多上傳三個附件</span></label>
                        <div id="dZUpload" class="dropzone" style="border: 1px solid #e5e6e7;">
                            <div class="dz-default dz-message text-center m-t-md">
                                <i class="fa fa-cloud-upload fa-2x text-primary"></i>
                                <br />
                                請按這裡上傳檔案
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <telerik:RadAjaxPanel ID="plUpload" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="row">
                                <div class="col-sm-2 col-sm-offset-2">
                                    <telerik:RadButton ID="btnUpload" runat="server" Text="上傳檔案" CssClass="btn btn-primary btn-outline" OnClick="btnUpload_Click" />
                                </div>
                                <div class="col-sm-8">
                                    <telerik:RadLabel ID="lblMsg" runat="server" />
                                    <telerik:RadLabel ID="lblKey" runat="server" Visible="false" />
                                </div>
                            </div>
                        </telerik:RadAjaxPanel>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="row">
                        <div class="col-lg-12">
                            <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-md" OnClick="btnAdd_Click" />
                            <span class="m-t-xs">IP：<telerik:RadLabel ID="lblIP" runat="server" /></span>


                        </div>

                    </div>
                    <asp:Label ID="lblUserCode" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblEmpID" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblCompanyId" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblEmpName" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblRoleKey" runat="server" Visible="False"></asp:Label>
                </div>

                <div class="col-lg-5">
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
                </div>
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
                uploadMultiple: true,
                //每次上传的最多文件数，经测试默认为2，坑啊
                //记得修改web.config 限制上传文件大小的节
                parallelUploads: 3, //手动触发时一次最大可以上传多少个文件
                maxFiles: 3, //一次上传的量
                maxFilesize: 10,   //M为单位
                acceptedFiles: ".jpg,.jpeg,.doc,.docx,.ppt,.pptx,.txt,.pdf,.mp3,.zip,.png,.xls,.xlsx",//可接受的上传类型
                dictDefaultMessage: "點擊或拖入要上傳的文件",      //上传框默认显示文字
                dictMaxFilesExceeded: "一次只能上傳3個檔案",
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
                    file.previewElement.classList.add("dz-error");
                }
            });
        }


    </script>

    <script>
        $(document).ready(function () {
            $('.footable').footable();
            var isPostBack = <%=this.IsPostBack.ToString().ToLower()%>;
            if (isPostBack) {
                $('#titlelength').text('(' + $('#ctl00_ContentPlaceHolder1_txtTitle').val().length + '/30)')
                isTyping = false;
                if ($('#ctl00_ContentPlaceHolder1_txtContent').val().length > 200) {
                    $('#contentlength').css('color', 'red')

                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/200)')
                    isTyping = false;
                }
                else {
                    $('#contentlength').css('color', '#1ab394')
                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/200)')
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
                $('#contentlength').text('(0/200)')
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
                if ($('#ctl00_ContentPlaceHolder1_txtContent').val().length > 200) {
                    $('#contentlength').css('color', 'red')

                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/200)')
                    isTyping = false;
                }
                else {
                    $('#contentlength').css('color', '#1ab394')
                    $('#contentlength').text('(' + $('#ctl00_ContentPlaceHolder1_txtContent').val().length + '/200)')
                    isTyping = false;
                  
                }

            }


        });


    </script>

</asp:Content>
