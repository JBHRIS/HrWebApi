<%@ Page Title="" Language="C#" MasterPageFile="~/Main_PR.Master" AutoEventWireup="true" CodeBehind="ProblemReturn.aspx.cs" Inherits="Portal.ProblemReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ibox">
        <div class="ibox-content">
            <div class="row">
                <div class="col-lg-7 b-r">
                    <div class="alert alert-warning">
                        <i class="fa fa-exclamation-circle"></i>本問題回報服務需3個工作天
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-2 col-form-label">標題</label>
                        <div class="col-lg-10">
                            <telerik:RadTextBox ID="txtTitle" runat="server" EmptyMessage="請輸入標題..." Skin="Bootstrap" Width="100%"/>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-2 col-form-label">回報類型</label>
                        <div class="col-lg-10">
                            <telerik:RadComboBox ID="txtReturnS" runat="server" Skin="Bootstrap"  Width="100%">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-2 col-form-label">內容</label>
                        <div class="col-lg-10">
                            <telerik:RadTextBox ID="txtContent" runat="server" EmptyMessage="請填寫您想回報的內容..."
                                TextMode="MultiLine" Width="100%" Skin="Bootstrap" Rows="3">
                            </telerik:RadTextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-lg-2 col-form-label">附件</label>
                        <div class="col-lg-10 col-form-label">上傳附件</div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <telerik:RadButton ID="btnAdd" runat="server" Text="送出" CssClass="btn btn-primary btn-md" />
                             &emsp;<span class="m-t-xs">IP：<telerik:RadLabel ID="lblIP" runat="server"  /></span>
                        </div>
                    </div>

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
