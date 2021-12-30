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
                        <h5><telerik:RadLabel runat="server" ID="lblConditionDic" Text="條件"></telerik:RadLabel></h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpDic" Text="員工工號"></telerik:RadLabel></label>
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
                            <h5><telerik:RadLabel runat="server" ID="lblContentDic" Text="內容"></telerik:RadLabel></h5>
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
                                            <h5><telerik:RadLabel runat="server" ID="lblEmployeeBaseData" Text="基本資料"></telerik:RadLabel></h5>
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
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpDic1" Text="員工工號"></telerik:RadLabel></label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpId" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpNameDic" Text="中文姓名"></telerik:RadLabel></label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpName" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpEnglishNameDic" Text="英文姓名"></telerik:RadLabel></label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpEnglishName" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpSexDic" Text="性別"></telerik:RadLabel></label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpSex" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpBirthdayDic" Text="生日"></telerik:RadLabel></label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpBirthday" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblConstellationDic" Text="星座"></telerik:RadLabel></label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblConstellation" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblAgeDic" Text="年齡"></telerik:RadLabel></label>
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
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpBloodDic" Text="血型"></telerik:RadLabel></label>
                                                                <div class="col-sm-8">
                                                                    <telerik:RadLabel runat="server" ID="lblEmpBlood" CssClass="form-control"></telerik:RadLabel>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row">
                                                                <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEmpMarriedDic" Text="婚姻狀態"></telerik:RadLabel></label>
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
                                            <h5><telerik:RadLabel runat="server" ID="lblJobStateDic" Text="在職資訊"></telerik:RadLabel></h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblStateDic" Text="狀態"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblState" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblWorkDateDic" Text="日期"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblWorkDate" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblSalaryDic" Text="年資"></telerik:RadLabel></label>
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
                                            <h5><telerik:RadLabel runat="server" ID="lblPersonnelDataDic" Text="人事資料"></telerik:RadLabel></h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblDeptNameDic" Text="部門"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblDeptName" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblDeptSDic" Text="成本部門"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblDeptS" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>

                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblJobNameDic" Text="職稱"></telerik:RadLabel></label>
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
                                            <h5><telerik:RadLabel runat="server" ID="lblContactDataDic" Text="聯絡人資料"></telerik:RadLabel></h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblContactNameDic" Text="姓名"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactName" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblContactRelationshipDic" Text="關係"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactRelationship" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblContactPhoneDic" Text="電話"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactPhone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblContactCellphoneDic" Text="手機"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactCellphone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-lg-6">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblContactNameDic1" Text="姓名"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactName1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblContactRelationshipDic1" Text="關係"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactRelationship1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblContactPhoneDic1" Text="電話"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblContactPhone1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblContactCellphoneDic1" Text="手機"></telerik:RadLabel></label>
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
                                            <h5><telerik:RadLabel runat="server" ID="lblEducationDic" Text="學歷資料"></telerik:RadLabel></h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEducationLevelDic" Text="教育程度"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEducationLevel" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblSchoolNameDic" Text="學校名稱"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSchoolName" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblSubjectDic" Text="科系"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSubject" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEntryDateDic" Text="入學日"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEntryDate" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblGraduatedDateDic" Text="畢業日"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblGraduatedDate" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblIsGraduatedDic" Text="是否畢業"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblIsGraduated" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEducationLevelDic1" Text="教育程度"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEducationLevel1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblSchoolNameDic1" Text="學校名稱"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSchoolName1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblSubjectDic1" Text="科系"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblSubject1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEntryDateDic1" Text="入學日"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEntryDate1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblGraduatedDateDic1" Text="畢業日"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblGraduatedDate1" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblIsGraduatedDic1" Text="是否畢業"></telerik:RadLabel></label>
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
                                            <h5><telerik:RadLabel runat="server" ID="lblCommunicateInfoDic" Text="通訊資料"></telerik:RadLabel></h5>
                                        </div>
                                        <div class="ibox-content">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblCellphoneDic" Text="手機"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblCellphone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblEmailDic" Text="信箱"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblEMail" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblCommunicationPhoneDic" Text="通訊電話"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblCommunicationPhone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblResidencePhoneDic" Text="戶籍電話"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadLabel runat="server" ID="lblResidencePhone" CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>

                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblCommunicationAddressDic" Text="通訊地址"></telerik:RadLabel></label>
                                                        <div class="col-sm-8">
                                                            <telerik:RadTextBox Width="100%" Rows="2" TextMode="MultiLine" runat="server" ID="lblCommunicationAddress" CssClass="form-control"></telerik:RadTextBox>
                                                        </div>
                                                    </div>

                                                    <div class="form-group row">
                                                        <label class="col-sm-4 col-form-label"><telerik:RadLabel runat="server" ID="lblResidenceAddressDic" Text="戶籍地址"></telerik:RadLabel></label>
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
                                            <h5><telerik:RadLabel runat="server" ID="lblFamilyDataDic" Text="眷屬資料"></telerik:RadLabel></h5>

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
                                                        <label class="col-sm-3 col-form-label"><telerik:RadLabel runat="server" ID="lblRelationshipDic" Text="關係"></telerik:RadLabel></label>
                                                        <div class="col-sm-9">
                                                            <telerik:RadLabel runat="server" Text='<%#Eval("Relationship") %>' CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 row">
                                                        <label class="col-sm-3 col-form-label"><telerik:RadLabel runat="server" ID="lblFamilyNameDic" Text="姓名"></telerik:RadLabel></label>
                                                        <div class="col-sm-9">
                                                            <telerik:RadLabel runat="server" Text='<%#Eval("FamilyName") %>' CssClass="form-control" Width="100%"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 row">
                                                        <label class="col-sm-3 col-form-label"><telerik:RadLabel runat="server" ID="lblFamilyBirthdayDic" Text="出生日期"></telerik:RadLabel></label>
                                                        <div class="col-sm-9">
                                                            <telerik:RadLabel runat="server" Text='<%#Eval("FamilyBirthday","{0:yyyy-MM-dd}") %>' CssClass="form-control"></telerik:RadLabel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                            <EmptyItemTemplate>
                                                <telerik:RadLabel runat="server" ID="lblFamilyDefaultMessageDic" Text="無眷屬資料"></telerik:RadLabel>
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
