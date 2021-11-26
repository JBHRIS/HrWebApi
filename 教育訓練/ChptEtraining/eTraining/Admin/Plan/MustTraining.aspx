<%@ Page Title="設定必訓" Language="C#" MasterPageFile="~/mpTraining.master" AutoEventWireup="true" CodeFile="MustTraining.aspx.cs" Inherits="eTraining_Admin_Plan_MustTraining" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

    </telerik:RadCodeBlock>
    <h2>設定必訓</h2>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Windows7">
    </telerik:RadAjaxLoadingPanel>

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        width="100%" HorizontalAlign="NotSet" 
        LoadingPanelID="RadAjaxLoadingPanel1">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <asp:Label ID="lblCode" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMode" runat="server" Text="v" Visible="False"></asp:Label>
        <asp:Label ID="lblCategory" runat="server" Visible="False"></asp:Label>
            <br />
           <telerik:RadButton ID="btnBackCat" runat="server" 
        Text="回類別設定" onclick="btnBackCat_Click">
    </telerik:RadButton>
&nbsp;<telerik:RadButton ID="btnBackCo" runat="server" 
        Text="回課程設定" onclick="btnBackCo_Click">
    </telerik:RadButton>
    <asp:Panel ID="pnView" runat="server">
        <telerik:RadButton ID="btnAdd" runat="server" Text="新增" onclick="btnAdd_Click">
        </telerik:RadButton>
        <br />
        <telerik:RadGrid ID="gv" runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellSpacing="0" DataSourceID="sdsGv" 
            GridLines="None" Skin="WebBlue" Width="70%">
            <MasterTableView allowautomaticdeletes="True" datakeynames="iAutoKey" 
                datasourceid="sdsGv">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                        ConfirmDialogType="RadWindow" ConfirmText="是否刪除?" 
                        FilterControlAltText="Filter column column" UniqueName="column">
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="D_NAME" 
                        FilterControlAltText="Filter D_NAME column" HeaderText="部門" 
                        SortExpression="D_NAME" UniqueName="D_NAME">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_NAME" 
                        FilterControlAltText="Filter JOB_NAME column" HeaderText="職稱" 
                        SortExpression="JOB_NAME" UniqueName="JOB_NAME">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_WebBlue">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnEdit" runat="server">
        <table border="1" cellpadding="1" cellspacing="1" width="70%" class="tbGreen">
        <tr>
            <th>
                部門
            </th>
            <th>
                職稱
            </th>
        </tr>
        <tr>
            <td width="50%" align="left" valign="top">
                <telerik:RadTreeView ID="tvDept" runat="server" CheckBoxes="True" CheckChildNodes="True"
                    MultipleSelect="True">
                </telerik:RadTreeView>
            </td>
            <td width="50%" align="left" valign="top">
                <telerik:RadTreeView ID="tvJob" runat="server" CheckBoxes="True" 
                    MultipleSelect="True" CheckChildNodes="True">
                    <expandanimation type="OutQuad" />
                </telerik:RadTreeView>
            </td>
        </tr>
    </table>

    <br />
    <telerik:RadButton ID="btnSave" runat="server" Text="儲存" onclick="btnSave_Click">
    </telerik:RadButton>
&nbsp;&nbsp;&nbsp;&nbsp;
    <telerik:RadButton ID="btnCancel" runat="server" Text="取消" 
        onclick="btnCancel_Click">
    </telerik:RadButton>
    </asp:Panel>
    <br />
    <asp:SqlDataSource ID="sdsGv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eLearningConnectionString %>" 
        DeleteCommand="DELETE FROM [trTrainingPlanRequiredUnit] WHERE [iAutoKey] = @iAutoKey" 
        InsertCommand="INSERT INTO [trTrainingPlanRequiredUnit] ([planAutoKey], [iYear], [iSession], [trCourse_sCode], [sCategory], [dept_sCode], [job_sCode], [jobL_sCode]) VALUES (@planAutoKey, @iYear, @iSession, @trCourse_sCode, @sCategory, @dept_sCode, @job_sCode, @jobL_sCode)" 
        SelectCommand="SELECT u.iAutoKey, u.planAutoKey, u.iYear, u.iSession, u.sMode, u.sCode, u.dept_sCode, u.job_sCode as job_sCode, u.jobL_sCode as jobL_sCode, j.JOB, j.JOB_NAME, j.JOB_ENAME, d.D_NO, d.D_NAME FROM trTrainingPlanRequiredUnit as u INNER JOIN DEPT d ON u.dept_sCode = d.D_NO INNER JOIN JOB as j ON u.job_sCode = j.JOB WHERE (u.sCode = @sCode) and (u.sMode=@sMode)" 
        
        
        UpdateCommand="UPDATE [trTrainingPlanRequiredUnit] SET [planAutoKey] = @planAutoKey, [iYear] = @iYear, [iSession] = @iSession, [trCourse_sCode] = @trCourse_sCode, [sCategory] = @sCategory, [dept_sCode] = @dept_sCode, [job_sCode] = @job_sCode, [jobL_sCode] = @jobL_sCode WHERE [iAutoKey] = @iAutoKey">
        <DeleteParameters>
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="planAutoKey" Type="Int32" />
            <asp:Parameter Name="iYear" Type="Int32" />
            <asp:Parameter Name="iSession" Type="Int32" />
            <asp:Parameter Name="trCourse_sCode" Type="String" />
            <asp:Parameter Name="sCategory" Type="String" />
            <asp:Parameter Name="dept_sCode" Type="String" />
            <asp:Parameter Name="job_sCode" Type="String" />
            <asp:Parameter Name="jobL_sCode" Type="String" />
        </InsertParameters>
        <SelectParameters>
<asp:ControlParameter ControlID="lblCode" PropertyName="Text" DefaultValue="0" Name="sCode"></asp:ControlParameter>
            <asp:ControlParameter ControlID="lblCategory" DefaultValue="0" Name="sMode" 
                PropertyName="Text" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="planAutoKey" Type="Int32" />
            <asp:Parameter Name="iYear" Type="Int32" />
            <asp:Parameter Name="iSession" Type="Int32" />
            <asp:Parameter Name="trCourse_sCode" Type="String" />
            <asp:Parameter Name="sCategory" Type="String" />
            <asp:Parameter Name="dept_sCode" Type="String" />
            <asp:Parameter Name="job_sCode" Type="String" />
            <asp:Parameter Name="jobL_sCode" Type="String" />
            <asp:Parameter Name="iAutoKey" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    </telerik:RadAjaxPanel>

 
    
    </asp:Content>

