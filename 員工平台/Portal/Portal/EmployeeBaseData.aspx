<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeBaseData.aspx.cs" Inherits="Portal.EmployeeBaseData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Templates/Inspinia/css/plugins/footable/footable.core.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlEmp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>條件</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">員工工號</label>
                                <div class="col-sm-10 row">
                                    <%--                                    <telerik:RadMultiSelect runat="server" Skin="Bootstrap"
                                        Placeholder="請選擇..."
                                        AutoClose="false"
                                        TagMode="Multiple"
                                        Width="100%"
                                        ID="ddlEmp"            />--%>
                                    <telerik:RadComboBox runat="server" Skin="Bootstrap" AutoPostBack="true"
                                        Placeholder="請選擇..." OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged"
                                        AutoClose="false"
                                        TagMode="Single"
                                        Width="100%"
                                        ID="ddlEmp"
                                        AllowCustomText="True" EnableVirtualScrolling="True" ItemsPerRequest="10" Filter="Contains" LoadingMessage="載入中…">
                                    </telerik:RadComboBox>
                                    <telerik:RadLabel ID="lblMsg" runat="server" />

                                </div>
                            </div>

                        </telerik:RadAjaxPanel>
                    </div>
                </div>
                <div class="ibox">
                    <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                        <div class="ibox-title">
                            <h5>內容</h5>
                            <div class="ibox-tools">
                                <a class="fullscreen-link">
                                    <i class="fa fa-expand"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="row">
                                <div class="col-lg-8">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>基本資料</h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <asp:Image runat="server" ID="ImgPhoto" ImageUrl="images/images.png" style="width: 100%"/>
                                                </div>
                                                <div class="col-sm-9 m-t-sm">
                                                    <div class="row">
                                                        <div class="col-sm-6">
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">員工工號</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpId" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">中文姓名</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpName" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">英文姓名</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpEnglishName" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">性別</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpSex" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">生日</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpBirthday" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">星座</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblConstellation" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">年齡</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblAge" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <%--<div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">身分證</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpMasked" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>--%>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">血型</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpBlood" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label">婚姻狀況</label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpMarried" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-4">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>在職資訊</h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">狀態</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblState" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">日期</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblWorkDate" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">年資</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSalary" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>人事資料</h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">部門</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblDeptName" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">成本部門</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblDeptA" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>

                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">職稱</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblJobName" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>


                                <div class="col-lg-8">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>聯絡人資料</h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">姓名</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactName" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">關係</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactRelationship" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">電話</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactPhone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">手機</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactCellphone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-lg-6">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">姓名</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactName1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">關係</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactRelationship1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">電話</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactPhone1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">手機</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactCellphone1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-7">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>學歷資料</h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">教育程度</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEducationLevel" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">學校名稱</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSchoolName" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">科系</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSubject" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">入學日</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEntryDate" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">畢業日</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblGraduatedDate" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">是否畢業</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblIsGraguated" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">教育程度</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEducationLevel1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">學校名稱</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSchoolName1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">科系</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSubject1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">入學日</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEntryDate1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">畢業日</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblGraduatedDate1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">是否畢業</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblIsGraguated1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-5">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>通訊資料</h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">手機</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblCellphone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">信箱</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEMail" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">通訊電話</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblCommunicationPhone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">戶籍電話</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblResidencePhone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>

                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">通訊地址</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadTextBox Width="100%" Rows="2" TextMode="MultiLine" runat="server" ID="lblCommunicationAddress" CssClass="form-control"></telerik:RadTextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label">戶籍地址</label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadTextBox Width="100%" Rows="2" TextMode="MultiLine" runat="server" ID="lblResidenceAddress" CssClass="form-control"></telerik:RadTextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>



                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="ibox">
                                        <div class="ibox-title">
                                            <h5>眷屬資料</h5>

                                        </div>
                                        <telerik:RadListView runat="server" ID="lvFamily" ItemPlaceholderID="Container">
                                            <LayoutTemplate>
                                                <div class="ibox-content">
                                                    <div id="Container" runat="server">
                                                    </div>
                                                </div>
                                            </LayoutTemplate>
                                            <ItemTemplate>
                                                <div class="row m-t-sm">
                                                    <div class="col-lg-4 row">
                                                        <label class="col-sm-3 col-form-label">關係</label>
                                                        <div class="col-sm-9">
                                                            <telerik:RadLabel runat="server" Text='<%#Eval("Relationship") %>' CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 row">
                                                        <label class="col-sm-3 col-form-label">姓名</label>
                                                        <div class="col-sm-9">
                                                            <telerik:RadLabel runat="server" Text='<%#Eval("FamilyName") %>' CssClass="form-control" Width="100%"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 row">
                                                        <label class="col-sm-3 col-form-label">出生日期</label>
                                                        <div class="col-sm-9">
                                                            <telerik:RadLabel runat="server" Text='<%#Eval("FamilyBirthday","{0:yyyy-MM-dd}") %>' CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                            <EmptyItemTemplate>
                                                無眷屬資料
                                            </EmptyItemTemplate>
                                        </telerik:RadListView>

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="ibox-footer">
                            <div class="animated fadeInRight">
                                <telerik:RadButton runat="server" ID="btnEdit" Text="編輯" ButtonType="LinkButton" CssClass="btn btn-primary" NavigateUrl="EmployeeBaseDataEdit.aspx"></telerik:RadButton>
                            </div>
                        </div>
                    </telerik:RadAjaxPanel>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
