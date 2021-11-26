<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectEmp.ascx.cs" Inherits="Templet_SelectEmp" %>
<h3>
        <asp:Label ID="lblEmp" runat="server" meta:resourcekey="lblEmpResource1" 
            Text="員工"></asp:Label>
            </h3>
            <asp:CheckBox ID="cbIncludeEmpLeaving" runat="server" AutoPostBack="True" OnCheckedChanged="cbIncludeEmpLeaving_CheckedChanged"
                Text="含離職人員" />
        <asp:GridView ID="gv" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" DataKeyNames="NOBR" 
            DataSourceID="HR_Portal_EmpInfoSqlDataSource" 
            meta:resourcekey="GridView1Resource1" 
            onselectedindexchanged="gv_SelectedIndexChanged" ShowHeader="False" 
            SkinID="Yahoo" ondatabound="gv_DataBound" onrowdatabound="gv_RowDataBound">
            <Columns>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Select" meta:resourcekey="LinkButton1Resource1" 
                            Text='<%# Eval("NAME_C").ToString() %>' 
                            Font-Size="X-Small"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NOBR" HeaderText="員工工號" 
                    meta:resourcekey="BoundFieldResource1" SortExpression="NOBR" Visible="False" />
                <asp:BoundField DataField="NAME_C" HeaderText="員工姓名" 
                    meta:resourcekey="BoundFieldResource2" SortExpression="NAME_C" 
                    Visible="False" />
                <asp:BoundField DataField="INDT" DataFormatString="{0:yyyy/MM/dd}" 
                    HeaderText="到職日" HtmlEncode="False" meta:resourcekey="BoundFieldResource3" 
                    SortExpression="INDT" Visible="False" />
                <asp:BoundField DataField="DEPT" HeaderText="部門" 
                    meta:resourcekey="BoundFieldResource4" SortExpression="DEPT" Visible="False" />
                <asp:BoundField DataField="D_NAME" HeaderText="部門名稱" 
                    meta:resourcekey="BoundFieldResource5" SortExpression="D_NAME" 
                    Visible="False" />
                <asp:BoundField DataField="JOB" HeaderText="JOB" 
                    meta:resourcekey="BoundFieldResource6" SortExpression="JOB" Visible="False" />
                <asp:BoundField DataField="JOB_NAME" HeaderText="職稱" 
                    meta:resourcekey="BoundFieldResource7" SortExpression="JOB_NAME" 
                    Visible="False" />
                <asp:BoundField DataField="EMPCD" HeaderText="EMPCD" 
                    meta:resourcekey="BoundFieldResource8" SortExpression="EMPCD" Visible="False" />
                <asp:BoundField DataField="EMPDESCR" HeaderText="員別" 
                    meta:resourcekey="BoundFieldResource9" SortExpression="EMPDESCR" 
                    Visible="False" />
                <asp:CheckBoxField DataField="MANG" HeaderText="主管職" 
                    meta:resourcekey="CheckBoxFieldResource1" SortExpression="MANG" 
                    Visible="False" />
                <asp:BoundField DataField="DI" HeaderText="直間接" 
                    meta:resourcekey="BoundFieldResource10" SortExpression="DI" Visible="False" />
            </Columns>
        </asp:GridView>
    <asp:SqlDataSource ID="HR_Portal_EmpInfoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        
    SelectCommand="SELECT NOBR, NAME_C,NAME_AD, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo WHERE (DEPT = @Dept) ORDER BY INDT" 
    onselecting="HR_Portal_EmpInfoSqlDataSource_Selecting">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblDept" Name="Dept" PropertyName="Text" 
                DefaultValue=" " />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="HR_Portal_EmpInfo_LeSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HRSqlServer %>"
        
    SelectCommand="SELECT NOBR, NAME_C, NAME_AD,INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo_Le WHERE (DEPT = @Dept) ORDER BY INDT">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblDept" Name="Dept" PropertyName="Text" 
                DefaultValue=" " />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label>

    