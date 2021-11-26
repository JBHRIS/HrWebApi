<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="ApplyUpdateBase.aspx.cs" Inherits="HR_UpBaseCon" Title="修改通訊資料" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Namespace="Safi.UI" TagPrefix="SafiUI" %>
<%@ Register Src="EmpTtsInfo.ascx" TagName="EmpTtsInfo" TagPrefix="uc4" %>
<%@ Register Src="EmployeeContact.ascx" TagName="EmployeeContact" TagPrefix="uc2" %>
<%@ Register Src="EmployeeContactPeople.ascx" TagName="EmployeeContactPeople" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <%--<div class="GreenForm" runat="server" id="mangDiv">--%>
                <h3>
                    <asp:Label ID="lblInfo" runat="server" Text="修改通訊資料" meta:resourcekey="lblInfoResource1"></asp:Label>
                </h3>
                <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" DefaultMode="Edit"
                    OnItemUpdating="FormView1_ItemUpdating" OnPageIndexChanging="FormView1_PageIndexChanging"
                    meta:resourcekey="FormView1Resource1">
                    <EditItemTemplate>
                        <fieldset>
                            <legend>
                                <asp:Label ID="lblContact" runat="server" Text="通訊資料" meta:resourcekey="lblContactResource1"></asp:Label></legend>
                            <table width="100%">
                                <tr>
                                    <td style="width: 28%" valign="top">
                                        <asp:Label ID="Label1" runat="server" Text="手機" SkinID="Notice" ForeColor="Blue"
                                            meta:resourcekey="Label1Resource1"></asp:Label>
                                    </td>
                                    <td style="width: 72%" valign="top">
                                        <asp:TextBox ID="up_gsm" runat="server" MaxLength="15" Width="90px" Text='<%# Bind("GSM") %>'
                                            meta:resourcekey="up_gsmResource1"></asp:TextBox>
                                        <asp:Label ID="Label2" runat="server" ForeColor="Blue" meta:resourcekey="Label2Resource1"
                                            SkinID="Notice" Text="E-Mail" Visible="False"></asp:Label>
                                        <asp:TextBox ID="up_email" runat="server" meta:resourcekey="up_emailResource1" Text='<%# Bind("EMAIL") %>'
                                            Visible="False" Width="295px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 81px">
                                        <asp:Label ID="Label3" runat="server" Text="戶籍電話" SkinID="Notice" ForeColor="Blue"
                                            meta:resourcekey="Label3Resource1"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="up_tel1" runat="server" Width="90px" Text='<%# Bind("TEL2") %>'
                                            meta:resourcekey="up_tel1Resource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 81px">
                                        <asp:Label ID="Label4" runat="server" Text="通訊電話" SkinID="Notice" ForeColor="Red"
                                            meta:resourcekey="Label4Resource1"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="up_tel2" runat="server" Width="90px" Text='<%# Bind("TEL1") %>'
                                            meta:resourcekey="up_tel2Resource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 81px">
                                        <asp:Label ID="Label7" runat="server" ForeColor="Blue" meta:resourcekey="Label7Resource1"
                                            SkinID="Notice" Text="通訊地址區號" Width="90px"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="up_postcode1" runat="server" MaxLength="5" Width="50px" Text='<%# Bind("POSTCODE1") %>'
                                            meta:resourcekey="up_postcode1Resource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 81px">
                                        <asp:Label ID="Label8" runat="server" ForeColor="Blue" meta:resourcekey="Label8Resource1"
                                            SkinID="Notice" Text="通訊地址"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="up_addr1" runat="server" Width="295px" Text='<%# Bind("ADDR1") %>'
                                            meta:resourcekey="up_addr1Resource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 81px">
                                        <asp:Label ID="Label5" runat="server" ForeColor="Blue" meta:resourcekey="Label5Resource1"
                                            SkinID="Notice" Text="戶籍郵政區號" Width="89px"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="up_postcode2" runat="server" MaxLength="5" Width="50px" Text='<%# Bind("POSTCODE2") %>'
                                            meta:resourcekey="up_postcode2Resource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 81px">
                                        <asp:Label ID="Label6" runat="server" ForeColor="Blue" meta:resourcekey="Label6Resource1"
                                            SkinID="Notice" Text="戶籍地址"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="up_addr2" runat="server" Width="295px" Text='<%# Bind("ADDR2") %>'
                                            meta:resourcekey="up_addr2Resource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 81px">
                                        <asp:Label ID="Label9" runat="server" Text="戶籍地" SkinID="Notice" ForeColor="Blue"
                                            Visible="False" meta:resourcekey="Label9Resource1"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="up_province" runat="server" Width="100px" Text='<%# Bind("PROVINCE") %>'
                                            Visible="False" meta:resourcekey="up_provinceResource1"></asp:TextBox>
                                        <asp:Label ID="Label10" runat="server" ForeColor="Blue" meta:resourcekey="Label10Resource1"
                                            SkinID="Notice" Text="出生地" Visible="False"></asp:Label>
                                        <asp:TextBox ID="up_born_addr" runat="server" meta:resourcekey="up_born_addrResource1"
                                            Text='<%# Bind("BORN_ADDR") %>' Visible="False" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 81px">
                                        <asp:Label ID="Label19" runat="server" ForeColor="Blue" meta:resourcekey="Label6Resource1"
                                            SkinID="Notice" Text="公司分機"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="TextBox1" runat="server" Width="295px" Text='<%# Bind("SUBTEL") %>'
                                            meta:resourcekey="up_addr2Resource1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset>
                            <legend>
                                <asp:Label ID="lblContactMan1" runat="server" Text="連絡人1" meta:resourcekey="lblContactMan1Resource1"></asp:Label></legend>
                            <table width="100%">
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        <asp:Label ID="Label11" runat="server" Text="姓名" SkinID="Notice" ForeColor="Blue"
                                            meta:resourcekey="Label11Resource1"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="CONT_MAN" runat="server" MaxLength="15" Width="90px" Text='<%# Bind("CONT_MAN") %>'
                                            meta:resourcekey="CONT_MANResource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        <asp:Label ID="Label12" runat="server" Text="關係" SkinID="Notice" ForeColor="Blue"
                                            meta:resourcekey="Label12Resource1"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <SafiUI:ExtendedDropDownList ID="CONT_REL1" runat="server" DataSourceID="RESqlDataSource1" DataTextField="REL_NAME"
                                            DataValueField="REL_CODE" SelectedValue='<%# Bind("CONT_REL1") %>' OnDataBound="CONT_REL1_DataBound"
                                            meta:resourcekey="CONT_REL1Resource1" AppendDataBoundItems="true" ObsoleteValueText="Item archived">
                                            <asp:ListItem Value="">(--Select One--)</asp:ListItem>
                                        </SafiUI:ExtendedDropDownList>
                                        <asp:SqlDataSource ID="RESqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                                            SelectCommand="SELECT REL_CODE, REL_NAME FROM RELCODE"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        <asp:Label ID="Label13" runat="server" Text="電話" SkinID="Notice" ForeColor="Blue"
                                            meta:resourcekey="Label13Resource1"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="CONT_TEL" runat="server" MaxLength="15" Width="90px" Text='<%# Bind("CONT_TEL") %>'
                                            meta:resourcekey="CONT_TELResource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 81px" valign="top">
                                        <asp:Label ID="Label14" runat="server" Text="行動電話" SkinID="Notice" ForeColor="Blue"
                                            meta:resourcekey="Label14Resource1"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:TextBox ID="CONT_GSM" runat="server" MaxLength="15" Width="90px" Text='<%# Bind("CONT_GSM") %>'
                                            meta:resourcekey="CONT_GSMResource1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <asp:Label ID="lblContace2" runat="server" Text="連絡人2" meta:resourcekey="lblContace2Resource1"
                            Visible="False"></asp:Label></legend>
                        <asp:Label ID="Label15" runat="server" Text="姓名" SkinID="Notice" ForeColor="Blue"
                            meta:resourcekey="Label15Resource1" Visible="False"></asp:Label>
                        <asp:TextBox ID="CONT_MAN2" runat="server" MaxLength="15" Width="90px" Text='<%# Bind("CONT_MAN2") %>'
                            meta:resourcekey="CONT_MAN2Resource1" Visible="False"></asp:TextBox>
                        <asp:Label ID="Label16" runat="server" Text="關係" SkinID="Notice" ForeColor="Blue"
                            meta:resourcekey="Label16Resource1" Visible="False"></asp:Label>
                        <SafiUI:ExtendedDropDownList ID="CONT_REL2" runat="server" DataSourceID="RESqlDataSource1" DataTextField="REL_NAME"
                            DataValueField="REL_CODE" SelectedValue='<%# Bind("CONT_REL2") %>' OnDataBound="CONT_REL1_DataBound"
                            meta:resourcekey="CONT_REL2Resource1" AppendDataBoundItems="true" ObsoleteValueText="Item archived"
                            Visible="False">
                            <asp:ListItem Value="">(--Select One--)</asp:ListItem>
                        </SafiUI:ExtendedDropDownList>
                        <asp:Label ID="Label17" runat="server" Text="電話" SkinID="Notice" ForeColor="Blue"
                            meta:resourcekey="Label17Resource1" Visible="False"></asp:Label>
                        <asp:TextBox ID="CONT_TEL2" runat="server" MaxLength="15" Width="90px" Text='<%# Bind("CONT_TEL2") %>'
                            meta:resourcekey="CONT_TEL2Resource1" Visible="False"></asp:TextBox>
                        <asp:Label ID="Label18" runat="server" Text="行動電話" SkinID="Notice" ForeColor="Blue"
                            meta:resourcekey="Label18Resource1" Visible="False"></asp:Label>
                        <asp:TextBox ID="CONT_GSM2" runat="server" MaxLength="15" Width="90px" Text='<%# Bind("CONT_GSM2") %>'
                            meta:resourcekey="CONT_GSM2Resource1" Visible="False"></asp:TextBox>
                        <br />
                        &nbsp;
                        <asp:Button ID="UpButton" runat="server" Text="更新" OnClick="UpButton_Click" CommandName="Update"
                            ValidationGroup="gcheck" meta:resourcekey="UpButtonResource1" />
                        <asp:Label ID="lb_nobr" runat="server" Text='<%# Bind("NOBR") %>' Visible="False"
                            meta:resourcekey="lb_nobrResource2"></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        NOBR:
                        <asp:TextBox ID="NOBRTextBox" runat="server" Text='<%# Bind("NOBR") %>' meta:resourcekey="NOBRTextBoxResource1"></asp:TextBox><br />
                        ADDR1:
                        <asp:TextBox ID="ADDR1TextBox" runat="server" Text='<%# Bind("ADDR1") %>' meta:resourcekey="ADDR1TextBoxResource1"></asp:TextBox><br />
                        ADDR2:
                        <asp:TextBox ID="ADDR2TextBox" runat="server" Text='<%# Bind("ADDR2") %>' meta:resourcekey="ADDR2TextBoxResource1"></asp:TextBox><br />
                        TEL1:
                        <asp:TextBox ID="TEL1TextBox" runat="server" Text='<%# Bind("TEL1") %>' meta:resourcekey="TEL1TextBoxResource1"></asp:TextBox><br />
                        TEL2:
                        <asp:TextBox ID="TEL2TextBox" runat="server" Text='<%# Bind("TEL2") %>' meta:resourcekey="TEL2TextBoxResource1"></asp:TextBox><br />
                        BBCALL:
                        <asp:TextBox ID="BBCALLTextBox" runat="server" Text='<%# Bind("BBCALL") %>' meta:resourcekey="BBCALLTextBoxResource1"></asp:TextBox><br />
                        EMAIL:
                        <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%# Bind("EMAIL") %>' meta:resourcekey="EMAILTextBoxResource1"></asp:TextBox><br />
                        GSM:
                        <asp:TextBox ID="GSMTextBox" runat="server" Text='<%# Bind("GSM") %>' meta:resourcekey="GSMTextBoxResource1"></asp:TextBox><br />
                        POSTCODE1:
                        <asp:TextBox ID="POSTCODE1TextBox" runat="server" Text='<%# Bind("POSTCODE1") %>'
                            meta:resourcekey="POSTCODE1TextBoxResource1"></asp:TextBox><br />
                        POSTCODE2:
                        <asp:TextBox ID="POSTCODE2TextBox" runat="server" Text='<%# Bind("POSTCODE2") %>'
                            meta:resourcekey="POSTCODE2TextBoxResource1"></asp:TextBox><br />
                        BORN_ADDR:
                        <asp:TextBox ID="BORN_ADDRTextBox" runat="server" Text='<%# Bind("BORN_ADDR") %>'
                            meta:resourcekey="BORN_ADDRTextBoxResource1"></asp:TextBox><br />
                        PROVINCE:
                        <asp:TextBox ID="PROVINCETextBox" runat="server" Text='<%# Bind("PROVINCE") %>' meta:resourcekey="PROVINCETextBoxResource1"></asp:TextBox><br />
                        <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="插入" meta:resourcekey="InsertButtonResource1"></asp:LinkButton>
                        <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="取消" meta:resourcekey="InsertCancelButtonResource1"></asp:LinkButton>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        NOBR:
                        <asp:Label ID="NOBRLabel" runat="server" Text='<%# Bind("NOBR") %>' meta:resourcekey="NOBRLabelResource1"></asp:Label><br />
                        ADDR1:
                        <asp:Label ID="ADDR1Label" runat="server" Text='<%# Bind("ADDR1") %>' meta:resourcekey="ADDR1LabelResource1"></asp:Label><br />
                        ADDR2:
                        <asp:Label ID="ADDR2Label" runat="server" Text='<%# Bind("ADDR2") %>' meta:resourcekey="ADDR2LabelResource1"></asp:Label><br />
                        TEL1:
                        <asp:Label ID="TEL1Label" runat="server" Text='<%# Bind("TEL1") %>' meta:resourcekey="TEL1LabelResource1"></asp:Label><br />
                        TEL2:
                        <asp:Label ID="TEL2Label" runat="server" Text='<%# Bind("TEL2") %>' meta:resourcekey="TEL2LabelResource1"></asp:Label><br />
                        BBCALL:
                        <asp:Label ID="BBCALLLabel" runat="server" Text='<%# Bind("BBCALL") %>' meta:resourcekey="BBCALLLabelResource1"></asp:Label><br />
                        EMAIL:
                        <asp:Label ID="EMAILLabel" runat="server" Text='<%# Bind("EMAIL") %>' meta:resourcekey="EMAILLabelResource1"></asp:Label><br />
                        GSM:
                        <asp:Label ID="GSMLabel" runat="server" Text='<%# Bind("GSM") %>' meta:resourcekey="GSMLabelResource1"></asp:Label><br />
                        POSTCODE1:
                        <asp:Label ID="POSTCODE1Label" runat="server" Text='<%# Bind("POSTCODE1") %>' meta:resourcekey="POSTCODE1LabelResource1"></asp:Label><br />
                        POSTCODE2:
                        <asp:Label ID="POSTCODE2Label" runat="server" Text='<%# Bind("POSTCODE2") %>' meta:resourcekey="POSTCODE2LabelResource1"></asp:Label><br />
                        BORN_ADDR:
                        <asp:Label ID="BORN_ADDRLabel" runat="server" Text='<%# Bind("BORN_ADDR") %>' meta:resourcekey="BORN_ADDRLabelResource1"></asp:Label><br />
                        PROVINCE:
                        <asp:Label ID="PROVINCELabel" runat="server" Text='<%# Bind("PROVINCE") %>' meta:resourcekey="PROVINCELabelResource1"></asp:Label><br />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="編輯" meta:resourcekey="EditButtonResource1"></asp:LinkButton>
                        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="刪除" meta:resourcekey="DeleteButtonResource1"></asp:LinkButton>
                        <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                            Text="新增" meta:resourcekey="NewButtonResource1"></asp:LinkButton>
                    </ItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                    DeleteCommand="DELETE FROM [base] WHERE [Nobr] = @Nobr" InsertCommand="INSERT INTO [base] ([Nobr], [addr1], [addr2], [tel1], [tel2], [bbcall], [email], [gsm], [postcode1], [postcode2], [born_addr], [province]) VALUES (@Nobr, @addr1, @addr2, @tel1, @tel2, @bbcall, @email, @gsm, @postcode1, @postcode2, @born_addr, @province)"
                    SelectCommand="SELECT NOBR, RTRIM(ADDR1) AS ADDR1, RTRIM(ADDR2) AS ADDR2, RTRIM(TEL1) AS TEL1, RTRIM(TEL2) AS TEL2, RTRIM(BBCALL) AS BBCALL, RTRIM(EMAIL) AS EMAIL, RTRIM(GSM) AS GSM, RTRIM(POSTCODE1) AS POSTCODE1, RTRIM(POSTCODE2) AS POSTCODE2, RTRIM(BORN_ADDR) AS BORN_ADDR, RTRIM(PROVINCE) AS PROVINCE, CONT_MAN, CONT_TEL, CONT_GSM, CONT_MAN2, CONT_TEL2, CONT_GSM2, CONT_REL1, CONT_REL2,SUBTEL FROM BASE WHERE (NOBR = @Nobr)">
                    <DeleteParameters>
                        <asp:Parameter Name="Nobr" Type="String" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lb_nobr" Name="Nobr" PropertyName="Text" Type="String" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Nobr" Type="String" />
                        <asp:Parameter Name="addr1" Type="String" />
                        <asp:Parameter Name="addr2" Type="String" />
                        <asp:Parameter Name="tel1" Type="String" />
                        <asp:Parameter Name="tel2" Type="String" />
                        <asp:Parameter Name="bbcall" Type="String" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="gsm" Type="String" />
                        <asp:Parameter Name="postcode1" Type="String" />
                        <asp:Parameter Name="postcode2" Type="String" />
                        <asp:Parameter Name="born_addr" Type="String" />
                        <asp:Parameter Name="province" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1_bak" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                    DeleteCommand="DELETE FROM [base] WHERE [Nobr] = @Nobr" InsertCommand="INSERT INTO [base] ([Nobr], [addr1], [addr2], [tel1], [tel2], [bbcall], [email], [gsm], [postcode1], [postcode2], [born_addr], [province]) VALUES (@Nobr, @addr1, @addr2, @tel1, @tel2, @bbcall, @email, @gsm, @postcode1, @postcode2, @born_addr, @province)"
                    SelectCommand="SELECT NOBR, RTRIM(ADDR1) AS ADDR1, RTRIM(ADDR2) AS ADDR2, RTRIM(TEL1) AS TEL1, RTRIM(TEL2) AS TEL2, RTRIM(BBCALL) AS BBCALL, RTRIM(EMAIL) AS EMAIL, RTRIM(GSM) AS GSM, RTRIM(POSTCODE1) AS POSTCODE1, RTRIM(POSTCODE2) AS POSTCODE2, RTRIM(BORN_ADDR) AS BORN_ADDR, RTRIM(PROVINCE) AS PROVINCE, CONT_MAN, CONT_TEL, CONT_GSM, CONT_MAN2, CONT_TEL2, CONT_GSM2, CONT_REL1, CONT_REL2 FROM BASE WHERE (NOBR = @Nobr)"
                    UpdateCommand="UPDATE BASE SET ADDR1 = @addr1, ADDR2 = @addr2, TEL1 = @tel1, TEL2 = @tel2, EMAIL = @email, GSM = @gsm, POSTCODE1 = @postcode1, POSTCODE2 = @postcode2, CONT_MAN = @CONT_MAN, CONT_TEL = @CONT_TEL, CONT_GSM = @CONT_GSM, CONT_MAN2 = @CONT_MAN2, CONT_TEL2 = @CONT_TEL2, CONT_GSM2 = @CONT_GSM2, CONT_REL1 = @CONT_REL1, CONT_REL2 = @CONT_REL2 WHERE (NOBR = @Nobr)">
                    <DeleteParameters>
                        <asp:Parameter Name="Nobr" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="addr1" Type="String" />
                        <asp:Parameter Name="addr2" Type="String" />
                        <asp:Parameter Name="tel1" Type="String" />
                        <asp:Parameter Name="tel2" Type="String" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="gsm" Type="String" />
                        <asp:Parameter Name="postcode1" Type="String" />
                        <asp:Parameter Name="postcode2" Type="String" />
                        <asp:Parameter Name="CONT_MAN" />
                        <asp:Parameter Name="CONT_TEL" />
                        <asp:Parameter Name="CONT_GSM" />
                        <asp:Parameter Name="CONT_MAN2" />
                        <asp:Parameter Name="CONT_TEL2" />
                        <asp:Parameter Name="CONT_GSM2" />
                        <asp:Parameter Name="CONT_REL1" />
                        <asp:Parameter Name="CONT_REL2" />
                        <asp:Parameter Name="Nobr" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lb_nobr" Name="Nobr" PropertyName="Text" Type="String" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Nobr" Type="String" />
                        <asp:Parameter Name="addr1" Type="String" />
                        <asp:Parameter Name="addr2" Type="String" />
                        <asp:Parameter Name="tel1" Type="String" />
                        <asp:Parameter Name="tel2" Type="String" />
                        <asp:Parameter Name="bbcall" Type="String" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="gsm" Type="String" />
                        <asp:Parameter Name="postcode1" Type="String" />
                        <asp:Parameter Name="postcode2" Type="String" />
                        <asp:Parameter Name="born_addr" Type="String" />
                        <asp:Parameter Name="province" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                    InsertCommand="INSERT INTO UpBaseRecord(nobr, name_c, updescr, key_date) VALUES (@nobr, @name_c, @updescr, GETDATE())"
                    SelectCommand="SELECT nobr FROM UpBaseRecord">
                    <InsertParameters>
                        <asp:Parameter Name="nobr" />
                        <asp:Parameter Name="name_c" />
                        <asp:Parameter Name="updescr" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                <%--          <div class="SilverForm">
                            <div class="SilverFormHeader">
                                <span class="SHLeft"></span><span class="SHeader">
                                    <asp:Label ID="lblNote" runat="server" Text="程式說明" meta:resourcekey="lblNoteResource1"></asp:Label></span>
                                <span class="SHRight"></span>
                            </div>
                            <div class="SilverFormContent" style="color: red">
                                <asp:Label ID="lblNoteDetail1" runat="server" Text="1.如員工通訊資料有異動，可自行修改！" meta:resourcekey="lblNoteDetail1Resource1"></asp:Label>
                                <br />
                                <asp:Label ID="lblNoteDetail2" runat="server" Text="2.修改完資料後，請按下『更新』這樣才算完成修改程序！"
                                    meta:resourcekey="lblNoteDetail2Resource1"></asp:Label><br />
                                <asp:Label ID="lblNoteDetail3" runat="server" Text="3.每一次異動修改資料後，經HR確認過，才會轉入人事系統!"
                                    meta:resourcekey="lblNoteDetail3Resource1"></asp:Label><br />
                                <asp:Label ID="lblNoteDetail4" runat="server" Text="4.如戶籍地址更新，請影印變更後身分證，送交人資部更新存查！"
                                    meta:resourcekey="lblNoteDetail4Resource1"></asp:Label><br />
                            </div>
                            <div class="SilverFormFooter">
                                <span class="SFLeft"></span><span class="SFRight"></span>
                            </div>
                        </div>
                        <asp:Label ID="lb_updescr" runat="server" Text='<%# Bind("NOBR") %>' Visible="False"
                            meta:resourcekey="lb_updescrResource1"></asp:Label>
                        
                    </div>
                    <div class="GreenFormFooter">
                        <span class="GFLeft">&nbsp;</span><span class="GFRight"></span>&nbsp;&nbsp;
                    </div>
                </div>
                --%>
            </td>
        </tr>
    </table>
</asp:Content>
