<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpApplyFormSelect_hr.aspx.cs" Inherits="EmpApplyFormSelect_hr" Title="Untitled Page"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../Templet/SelectEmp.ascx" TagName="SelectEmp" TagPrefix="uc1" %>
<%@ Register Src="../../Templet/SelectEmpHr.ascx" TagName="SelectEmpHr" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <%--</div>--%><%--
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
        <%--<div id="mainContent">--%>
        <div style="float:left;width:1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
        </div>
            <h3>
                <asp:Label ID="lblEmpAbs" runat="server" Text="���u������" 
                    meta:resourcekey="lblEmpAbsResource1"></asp:Label>
            </h3>
            <fieldset>
                <legend>
                    <asp:Label ID="lblSearch" runat="server" Text="�d�߱���" meta:resourcekey="lblSearchResource1"></asp:Label></legend>
                <asp:Label ID="Label1" runat="server" Text="�а�����G" meta:resourcekey="Label1Resource1"></asp:Label>
                <telerik:RadDatePicker ID="adate" runat="server" 
                    meta:resourcekey="adateResource1" Culture="(Default)">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="adate"
                    ErrorMessage="����榡���~�I" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="��" meta:resourcekey="Label2Resource1"></asp:Label>
                <telerik:RadDatePicker ID="ddate" runat="server" 
                    meta:resourcekey="ddateResource1" Culture="(Default)">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy" DisplayText="" LabelWidth="40%" 
                        type="text" value="" Width=""></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl="" CssClass=""></DatePopupButton>
                </telerik:RadDatePicker>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddate"
                    ErrorMessage="����榡���~�I" ValidationGroup="group_date" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblCat" runat="server" Text="�d�����O�G" meta:resourcekey="Label1Resource1"></asp:Label>
                <asp:DropDownList ID="ddlCat" runat="server" meta:resourcekey="ddlCatResource1">
                    <asp:ListItem Selected="True" Value="0" meta:resourcekey="ListItemResource1">����</asp:ListItem>
                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource2">�а�</asp:ListItem>
                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource3">���X</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="�d��" ValidationGroup="group_date"
                    meta:resourcekey="Button1Resource2" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="�ץX" meta:resourcekey="Button2Resource1" />
                <asp:Label ID="lb_nobr" runat="server" Visible="False" meta:resourcekey="lb_nobrResource1"></asp:Label>
                <br />
            </fieldset>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                SkinID="Yahoo" OnPageIndexChanging="GridView2_PageIndexChanging" meta:resourcekey="GridView2Resource1"
                OnRowDataBound="GridView2_RowDataBound" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbDelete" runat="server" ToolTip='<%# Bind("ProcessID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnView" runat="server" 
                                PostBackUrl='<%# Bind("ViewUrl") %>'>View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nobr" HeaderText="Nobr" SortExpression="Nobr" Visible="False"
                        meta:resourcekey="BoundFieldResource11" />
                    <asp:BoundField DataField="NameC" HeaderText="���u" SortExpression="NameC" meta:resourcekey="BoundFieldResource12" />
                    <asp:BoundField DataField="NameE" HeaderText="�^��W" meta:resourcekey="BoundFieldResource25" />
                    <asp:BoundField DataField="DateB" DataFormatString="{0:yyyy/MM/dd}" HeaderText="�а��_�l���"
                        SortExpression="DateB" meta:resourcekey="BoundFieldResource15" />
                    <asp:BoundField DataField="DateE" HeaderText="�а��������" 
                        DataFormatString="{0:yyyy/MM/dd}" meta:resourcekey="BoundFieldResource3" />
                    <asp:BoundField DataField="TimeB" HeaderText="�}�l�ɶ�" SortExpression="TimeB" meta:resourcekey="BoundFieldResource16" />
                    <asp:BoundField DataField="TimeE" HeaderText="�����ɶ�" SortExpression="TimeE" meta:resourcekey="BoundFieldResource17" />
                    <asp:BoundField DataField="Hcode" HeaderText="sHcode" SortExpression="Hcode" Visible="False"
                        meta:resourcekey="BoundFieldResource18" />
                    <asp:BoundField DataField="HcodeName" HeaderText="���O" SortExpression="HcodeName"
                        meta:resourcekey="BoundFieldResource19" />
                    <asp:BoundField DataField="Unit" HeaderText="���" SortExpression="Unit" meta:resourcekey="BoundFieldResource20" />
                    <asp:BoundField DataField="TotalHour" HeaderText="�а��p�p" SortExpression="TotalHour"
                        meta:resourcekey="BoundFieldResource21" />
                    <asp:BoundField DataField="TotalDay" HeaderText="�а��Ѽ�" SortExpression="TotalDay"
                        meta:resourcekey="BoundFieldResource22" Visible="False" />
                    <asp:BoundField DataField="Note" HeaderText="�Ƶ�" SortExpression="Note" meta:resourcekey="BoundFieldResource23" />
                    <asp:BoundField DataField="YYMM" HeaderText="�p�~�~��" SortExpression="YYMM" meta:resourcekey="BoundFieldResource24" />
                    <asp:BoundField DataField="State" HeaderText="���A" SortExpression="State" 
                        meta:resourcekey="BoundFieldResource4" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="lb_empty" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="Red" Text="���L������ơI�I"
                        meta:resourcekey="lb_emptyResource1"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
                <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
        Text="Delete" onclientclick="return confirm('�z�T�w�n�R���ܡH')" />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    <asp:Label ID="lb_dept" runat="server" Visible="False" meta:resourcekey="lb_deptResource1"></asp:Label>
            </div>
       <%-- </div>--%>
        <%--</div>--%>

        <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
            SelectCommand="SELECT NOBR, NAME_C, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT">
            <SelectParameters>
                <asp:ControlParameter ControlID="lb_dept" Name="Dept" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
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
