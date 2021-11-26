<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAbsSelect_hr.aspx.cs" Inherits="Mang_EmpAbsSelect_hr" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Templet/SelectEmp.ascx" TagName="SelectEmp" TagPrefix="uc1" %>
<%@ Register Src="../../Templet/SelectEmpHr.ascx" TagName="SelectEmpHr" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>

            <h3>
                <asp:Label ID="lblEmpAbs" runat="server" Text="���u�а����" meta:resourcekey="lblEmpAbsResource1"></asp:Label>
            </h3>
            <fieldset>
                <legend>
                    <asp:Label ID="lblSearch" runat="server" Text="�d�߱���" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                <asp:Label ID="Label1" runat="server" Text="�а�����G" meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                    meta:resourcekey="adateResource2">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                    <DateInput Skin="" DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                        LabelWidth="64px" Width="">
                    </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    ErrorMessage="����榡���~�I" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="��" meta:resourcekey="Label2Resource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                    meta:resourcekey="ddateResource2">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                    <DateInput Skin="" DateFormat="MM/dd/yyyy" DisplayDateFormat="MM/dd/yyyy" 
                        LabelWidth="64px" Width="">
                    </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    ErrorMessage="����榡���~�I" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="�d��" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource2" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                <br />
                <asp:Localize ID="Localize1" runat="server" 
                    meta:resourcekey="Localize1Resource1" Text="���O�G"></asp:Localize>
                <asp:DropDownList ID="ddlHcode" runat="server" 
                    meta:resourcekey="ddlHcodeResource1">
                </asp:DropDownList>
            </fieldset>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                SkinID="Yahoo" OnPageIndexChanging="GridView2_PageIndexChanging" 
            meta:resourcekey="GridView2Resource1" Width="100%">
                <Columns>
                    <asp:BoundField DataField="NOBR" HeaderText="NOBR" SortExpression="NOBR" Visible="False"
                        meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="NAME_C" HeaderText="���u" SortExpression="NAME_C" meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="NAME_E" HeaderText="���u�^" meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="JOB_NAME" HeaderText="¾��" SortExpression="JOB_NAME" meta:resourcekey="BoundFieldResource14" />
                    <asp:BoundField DataField="D_NAME" HeaderText="D_NAME" SortExpression="D_NAME" Visible="False"
                        meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="BDATE" DataFormatString="{0:yyyy/MM/dd}" HeaderText="�а����"
                        HtmlEncode="False" SortExpression="BDATE" meta:resourcekey="BoundFieldResource16" />
                    <asp:BoundField DataField="BTIME" HeaderText="�}�l�ɶ�" SortExpression="BTIME" meta:resourcekey="BoundFieldResource17" />
                    <asp:BoundField DataField="ETIME" HeaderText="�����ɶ�" SortExpression="ETIME" meta:resourcekey="BoundFieldResource18" />
                    <asp:BoundField DataField="H_CODE" HeaderText="H_CODE" SortExpression="H_CODE" Visible="False"
                        meta:resourcekey="BoundFieldResource19" />
                    <asp:BoundField DataField="H_NAME" HeaderText="���O" SortExpression="H_NAME" meta:resourcekey="BoundFieldResource20" />
                    <asp:BoundField DataField="UNIT" HeaderText="���" SortExpression="UNIT" meta:resourcekey="BoundFieldResource21" />
                    <asp:BoundField DataField="TOL_HOURS" HeaderText="�а��ɼ�" SortExpression="TOL_HOURS"
                        meta:resourcekey="BoundFieldResource22" />
                    <asp:BoundField DataField="TOL_DAY" HeaderText="�а��Ѽ�" SortExpression="TOL_DAY" meta:resourcekey="BoundFieldResource23" />
                    <asp:BoundField DataField="NOTE" HeaderText="�Ƶ�" SortExpression="NOTE" meta:resourcekey="BoundFieldResource24" />
                    <asp:BoundField DataField="YYMM" HeaderText="�p�~�~��" SortExpression="YYMM" meta:resourcekey="BoundFieldResource25" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="���L������ơI�I"
                        meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>

    <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
    <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        SelectCommand="SELECT NOBR, NAME_C, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
        <SelectParameters>
            <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
                <asp:Label ID="lblNote" runat="server" Text="�{������" meta:resourcekey="lblNoteResource1"></asp:Label></span>
            <span class="SHRight"></span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="lblDetail1" runat="server" Text="1.�D�ެd�߭��u�а���ơI" meta:resourcekey="lblDetail1Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail2" runat="server" Text="2.�y������ơz���T�ӿﶵ�G" meta:resourcekey="lblDetail2Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="lblDetail3" runat="server" Text="-���u�G��@�d�ߨC�@�ӭ��u���������" meta:resourcekey="lblDetail3Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="lblDetail4" runat="server" Text="-�����G�d�ߩҿ�w�������A�Ҧ����u���������" meta:resourcekey="lblDetail4Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="lblDetail5" runat="server" Text="-�t�l�����G�d�ߩҿ�w�������Τl�����A�Ҧ����u���������" meta:resourcekey="lblDetail5Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail6" runat="server" Text="3.�y�d�߱���z���u�i�H����󤤿�J�϶�����A�� 2008/01/01 �� 2008/12/31 ��J��������A�Ы��U�y�d�ߡz��A�N�i�d�߭��u������ơI"
                meta:resourcekey="lblDetail6Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail7" runat="server" Text="4.��J����榡���褸�~�I�� 2008/12/31,�]�i�I�����y��� �Ϯסz�i�����I��I"
                meta:resourcekey="lblDetail7Resource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
