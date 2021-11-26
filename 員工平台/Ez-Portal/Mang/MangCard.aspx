<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="MangCard.aspx.cs" Inherits="Mang_MangCard" Title="��d���" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>

            <h3>
                <asp:Label ID="lblStaffSwipe" runat="server" Text="���u��d���" meta:resourcekey="lblStaffSwipeResource1"></asp:Label></h3>
            <fieldset>
                <legend>
                    <asp:Label ID="lblSearch" runat="server" Text="�d�߱���" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                <asp:Label ID="Label1" runat="server" Text="����G" meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                    meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                    </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    ErrorMessage="����榡���~�I" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="��" meta:resourcekey="Label2Resource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                    meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                    </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    ErrorMessage="����榡���~�I" ValidationGroup="group_date" Display="Dynamic" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="�d��" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource2" />&nbsp;<asp:Button ID="ExportExcel" runat="server"
                        OnClick="ExportExcel_Click" Text="�ץXExcel" meta:resourcekey="ExportExcelResource1" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>&nbsp;
            </fieldset>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" SkinID="Yahoo"
                AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView2_PageIndexChanging"
                meta:resourcekey="GridView2Resource1" Width="100%">
                <Columns>
                    <asp:BoundField DataField="nobr" HeaderText="���u�s��" meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="name_c" HeaderText="���u�m�W" meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="NAME_E" HeaderText="�^��W" meta:resourcekey="BoundFieldResource13" />
                    <asp:BoundField DataField="adate" DataFormatString="{0:d}" HeaderText="��d���" HtmlEncode="False"
                        meta:resourcekey="BoundFieldResource14" />
                    <asp:BoundField DataField="ontime" HeaderText="��d�ɶ�" meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="not_tran" HeaderText="���ഫ" meta:resourcekey="BoundFieldResource16"
                        Visible="False" />
                    <asp:BoundField DataField="cardno" HeaderText="��d���X" meta:resourcekey="BoundFieldResource17" />
                    <asp:BoundField DataField="code" HeaderText="�ӷ�" meta:resourcekey="BoundFieldResource18"
                        Visible="False" />
                    <asp:BoundField DataField="IPADD" HeaderText="�q�l��dIP" meta:resourcekey="BoundFieldResource19"
                        Visible="False" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="���L������ơI�I"
                        meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
            <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
                SelectCommand="SELECT NOBR, NAME_C,NAME_AD, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <div class="SilverForm">
        <div class="SilverFormHeader">
            <span class="SHLeft"></span><span class="SHeader">
                <asp:Label ID="lblNote" runat="server" Text="�{������" meta:resourcekey="lblNoteResource1"></asp:Label></span>
            <span class="SHRight"></span>
        </div>
        <div class="SilverFormContent" style="color: red">
            <asp:Label ID="Label3" runat="server" Text="1.�D�ެd�߭��u��d��ơI" meta:resourcekey="Label3Resource1"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="2.�y������ơz���T�ӿﶵ�G" meta:resourcekey="Label4Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="Label5" runat="server" Text="-���u�G��@�d�ߨC�@�ӭ��u���������" meta:resourcekey="Label5Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="Label6" runat="server" Text="-�����G�d�ߩҿ�w�������A�Ҧ����u���������" meta:resourcekey="Label6Resource1"></asp:Label><br />
            &nbsp; &nbsp;
            <asp:Label ID="Label7" runat="server" Text="-�t�l�����G�d�ߩҿ�w�������Τl�����A�Ҧ����u���������" meta:resourcekey="Label7Resource1"></asp:Label><br />
            <asp:Label ID="Label8" runat="server" Text="3.�y�d�߱���z���u�i�H����󤤿�J�϶�����A�� 2008/01/01 �� 2008/12/31 ��J��������A�Ы��U�y�d�ߡz��A�N�i�d�߭��u������ơI"
                meta:resourcekey="Label8Resource1"></asp:Label><br />
            <asp:Label ID="Label9" runat="server" Text="4.��J����榡���褸�~�I�� 2008/12/31 ,�]�i�I�����y��� �Ϯסz�i�����I��I"
                meta:resourcekey="Label9Resource1"></asp:Label><br />
        </div>
        <div class="SilverFormFooter">
            <span class="SFLeft"></span><span class="SFRight"></span>
        </div>
    </div>--%>
</asp:Content>
