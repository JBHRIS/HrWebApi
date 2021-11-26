<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpAbs1Select_mang.aspx.cs" Inherits="Mang_EmpAbs1Select_mang" Title="���X�d��"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
    <%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Templet/SelectEmp.ascx" TagName="SelectEmp" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
        <asp:Label ID="lblEmpAbs" runat="server" Text="���u���X���" meta:resourcekey="lblEmpAbsResource1"></asp:Label>
        <fieldset>
            <legend>
                <asp:Label ID="lblSearch" runat="server" Text="�d�߱���" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
            <asp:Label ID="Label1" runat="server" Text="�d�ߤ���G" meta:resourcekey="Label1Resource1"></asp:Label>
            <telerik:RadDatePicker ID="adate" runat="server" Culture="(Default)" 
                meta:resourcekey="adateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput Skin="" LabelWidth="64px" Width="" DateFormat="MM/dd/yyyy" 
                    DisplayDateFormat="MM/dd/yyyy">
                </DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
            </telerik:RadDatePicker>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                ErrorMessage="����榡���~�I" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
            <asp:Label ID="Label2" runat="server" Text="��" meta:resourcekey="Label2Resource1"></asp:Label>
            <telerik:RadDatePicker ID="ddate" runat="server" Culture="(Default)" 
                meta:resourcekey="ddateResource1">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                <DateInput Skin="" LabelWidth="64px" Width="" DateFormat="MM/dd/yyyy" 
                    DisplayDateFormat="MM/dd/yyyy">
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
        </fieldset>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            SkinID="Yahoo" OnPageIndexChanging="GridView2_PageIndexChanging" 
            meta:resourcekey="GridView2Resource1" Width="100%">
            <Columns>
                <asp:BoundField DataField="Nobr" HeaderText="NOBR" SortExpression="Nobr" Visible="False"
                    meta:resourcekey="BoundFieldResource11" />
                <asp:BoundField DataField="NameC" HeaderText="���u" SortExpression="NameC" meta:resourcekey="BoundFieldResource12" />
                <asp:BoundField DataField="NameE" HeaderText="�^��W�r" meta:resourcekey="BoundFieldResource13" />
                <asp:BoundField DataField="JobName" HeaderText="¾��" SortExpression="JobName" meta:resourcekey="BoundFieldResource14" />
                <asp:BoundField DataField="DeptName" HeaderText="����" SortExpression="DeptName" meta:resourcekey="BoundFieldResource15" />
                <asp:BoundField DataField="AbsDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="�а����"
                    HtmlEncode="False" SortExpression="AbsDate" meta:resourcekey="BoundFieldResource16" />
                <asp:BoundField DataField="AbsBtime" HeaderText="�}�l�ɶ�" SortExpression="AbsBtime"
                    meta:resourcekey="BoundFieldResource17" />
                <asp:BoundField DataField="AbsEtime" HeaderText="�����ɶ�" SortExpression="AbsEtime"
                    meta:resourcekey="BoundFieldResource18" />
                <asp:BoundField DataField="H_Code" HeaderText="H_CODE" SortExpression="H_Code" Visible="False"
                    meta:resourcekey="BoundFieldResource19" />
                <asp:BoundField DataField="H_CodeName" HeaderText="���O" SortExpression="H_CodeName"
                    meta:resourcekey="BoundFieldResource20" />
                <asp:BoundField DataField="H_CodeUnit" HeaderText="���" SortExpression="H_CodeUnit"
                    meta:resourcekey="BoundFieldResource21" />
                <asp:BoundField DataField="TOL_HOURS" HeaderText="�а��ɼ�" SortExpression="TOL_HOURS"
                    meta:resourcekey="BoundFieldResource22" />
                <asp:BoundField DataField="Reason" HeaderText="��]" SortExpression="Reason" meta:resourcekey="BoundFieldResource24"
                    Visible="False" />
                <asp:BoundField DataField="NOTE" HeaderText="�Ƶ�" 
                    meta:resourcekey="BoundFieldResource3" />
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
    
    <%--            <asp:Label ID="lblDetail1" runat="server" Text="1.�D�ެd�߭��u���X��ơI" 
                meta:resourcekey="lblDetail1Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail2" runat="server" Text="2.�y������ơz���T�ӿﶵ�G" 
                meta:resourcekey="lblDetail2Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail3" runat="server" Text="-���u�G��@�d�ߨC�@�ӭ��u���������" 
                meta:resourcekey="lblDetail3Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail4" runat="server" Text="-�����G�d�ߩҿ�w�������A�Ҧ����u���������" 
                meta:resourcekey="lblDetail4Resource1"></asp:Label><br />
            &nbsp; &nbsp; 
            <asp:Label ID="lblDetail5" runat="server" Text="-�t�l�����G�d�ߩҿ�w�������Τl�����A�Ҧ����u���������" 
                meta:resourcekey="lblDetail5Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail6" runat="server" 
                Text="3.�y�d�߱���z���u�i�H����󤤿�J�϶�����A�� 2008/01/01 �� 2008/12/31 ��J��������A�Ы��U�y�d�ߡz��A�N�i�d�߭��u������ơI" 
                meta:resourcekey="lblDetail6Resource1"></asp:Label><br />
            <asp:Label ID="lblDetail7" runat="server" 
                Text="4.��J����榡���褸�~�I�� 2008/12/31,�]�i�I�����y��� �Ϯסz�i�����I��I" 
                meta:resourcekey="lblDetail7Resource1"></asp:Label><br />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
