<%@ Page Language="C#" MasterPageFile="~/NoteMasterPage.master" AutoEventWireup="true"
    CodeFile="EmpInfo.aspx.cs" Inherits="Mang_EmpInfo" Title="Untitled Page" Culture="auto"
    meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="../Employee/EmpTtsInfoByUser.ascx" TagName="EmpTtsInfo" TagPrefix="uc4" %>
<%@ Register Src="../Employee/EmployeeContactPeopleByUser.ascx" TagName="EmployeeContactPeople"
    TagPrefix="uc5" %>
<%@ Register Src="../Employee/EmpFamilyInfoByUser.ascx" TagName="EmpFamilyInfo" TagPrefix="uc6" %>
<%@ Register Src="../Employee/EmpInfoStateByUser.ascx" TagName="EmpInfoState" TagPrefix="uc2" %>
<%@ Register Src="../Utli/DeptTree.ascx" TagName="DeptTree" TagPrefix="uc1" %>
<%@ Register Src="EmpBaseByUser.ascx" TagName="EmpBase" TagPrefix="uc8" %>
<%@ Register Src="EmployeeContactByUser.ascx" TagName="EmployeeContact" TagPrefix="uc9" %>
<%@ Register Src="../Templet/EmployeeSecretarySetting.ascx" TagName="EmployeeSecretarySetting"
    TagPrefix="uc10" %>
<%@ Register Src="~/templet/empdeptqs.ascx" TagPrefix="uc" TagName="EmpDeptQS" %>
<%@ Register Src="../AbsList.ascx" TagName="AbsList" TagPrefix="uc11" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

<style type="text/css">
        .MyGridClass .rgDataDiv
        {
            height: auto !important;
        }
    </style>

    <%--<style type="text/css">
body {
-moz-user-select : none;
-webkit-user-select: none;
}
</style>
<script type="text/javascript">
    function iEsc() { return false; }
    function iRec() { return true; }
    function DisableKeys() {
        if (event.ctrlKey || event.shiftKey || event.altKey) {
            window.event.returnValue = false;
            iEsc();
        }
    }
    document.ondragstart = iEsc;
    document.onkeydown = DisableKeys;
    document.oncontextmenu = iEsc;
    if (typeof document.onselectstart != "undefined")
        document.onselectstart = iEsc;
    else {
        document.onmousedown = iEsc;
        document.onmouseup = iRec;
    }
    function DisableRightClick(qsyzDOTnet) {
        if (window.Event) {
            if (qsyzDOTnet.which == 2 || qsyzDOTnet.which == 3)
                iEsc();
        }
        else
            if (event.button == 2 || event.button == 3) {
                event.cancelBubble = true
                event.returnValue = false;
                iEsc();
            }
    }
</script>--%>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="100%" 
        Width="100%" LoadingPanelID="RadAjaxLoadingPanel1">
    
    <div style="float: left; width: 1000px">
        <uc:EmpDeptQS runat="server" ID="ucEmpDeptQS" />
    </div>
    <h3>
        <asp:Label ID="lblEmpBase" runat="server" Text="員工基本資料" meta:resourcekey="lblEmpBaseResource1"></asp:Label></h3>
    <telerik:RadGrid ID="gv" runat="server" AutoGenerateColumns="False" CellSpacing="0"
        Culture="zh-TW" GridLines="None" OnNeedDataSource="gv_NeedDataSource" 
        Width="1000px" onitemcommand="gv_ItemCommand" 
            onselectedindexchanged="gv_SelectedIndexChanged">
        <ClientSettings>
           <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false" FrozenColumnsCount="2"></Scrolling>
        </ClientSettings>
        <MasterTableView DataKeyNames="Nobr">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="Nobr" 
                    FilterControlAltText="Filter Nobr column" HeaderText="工號" 
                    UniqueName="Nobr">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NameC" 
                    FilterControlAltText="Filter NameC column" HeaderText="姓名" 
                    UniqueName="NameC">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NameE" 
                    FilterControlAltText="Filter NameE column" HeaderText="英文名" 
                    UniqueName="NameE">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DeptName" 
                    FilterControlAltText="Filter DeptName column" HeaderText="部門" 
                    UniqueName="DeptName">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Gender" 
                    FilterControlAltText="Filter Gender column" HeaderText="性別" 
                    UniqueName="Gender">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="BirthDate" 
                    FilterControlAltText="Filter BirthDate column" HeaderText="生日" 
                    UniqueName="BirthDate" DataFormatString="{0:yyyy/MM/dd}">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JobTitle" 
                    FilterControlAltText="Filter JobTitle column" HeaderText="職稱" 
                    UniqueName="JobTitle">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JoblName" 
                    FilterControlAltText="Filter JoblName column" HeaderText="職等" 
                    UniqueName="JoblName">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JoboName" 
                    FilterControlAltText="Filter JoboName column" HeaderText="職級" 
                    UniqueName="JoboName">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Indt" DataFormatString="{0:yyyy/MM/dd}" 
                    FilterControlAltText="Filter Indt column" HeaderText="到職日" 
                    UniqueName="Indt">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Seniority" 
                    FilterControlAltText="Filter Seniority column" HeaderText="年資" 
                    UniqueName="Seniority" DataFormatString="{0:N1}">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PhoneNumber" 
                    FilterControlAltText="Filter PhoneNumber column" HeaderText="電話" 
                    UniqueName="PhoneNumber">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MobileNumber" 
                    FilterControlAltText="Filter MobileNumber column" HeaderText="行動電話" 
                    UniqueName="MobileNumber">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TopSchoolName" 
                    FilterControlAltText="Filter TopSchoolName column" HeaderText="學歷" 
                    UniqueName="TopSchoolName">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TopSchoolMajorName" 
                    FilterControlAltText="Filter TopSchoolMajorName column" HeaderText="科系" 
                    UniqueName="TopSchoolMajorName">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Addr1" 
                    FilterControlAltText="Filter Addr1 column" HeaderText="住址" UniqueName="Addr1">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </telerik:GridBoundColumn>
                <telerik:GridButtonColumn CommandName="Select" 
                    FilterControlAltText="Filter cmdSelect column" Text="人員異動查詢(1)" 
                    UniqueName="cmdSelect">
                    <ItemStyle Wrap="False" />
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
        <telerik:RadWindow ID="win" runat="server" Height="700px" Modal="True" 
            Width="1000px">
            <ContentTemplate>
                <telerik:RadGrid ID="gv2" runat="server" onneeddatasource="gv2_NeedDataSource" 
                    AutoGenerateColumns="False" CellSpacing="0" Culture="zh-TW" GridLines="None">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                            Visible="True">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                            Visible="True">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="nobr" 
                                FilterControlAltText="Filter nobr column" HeaderText="工號" UniqueName="nobr">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="name" 
                                FilterControlAltText="Filter name column" HeaderText="姓名" UniqueName="name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="cate" 
                                FilterControlAltText="Filter cate column" HeaderText="類別" UniqueName="cate">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="itme" 
                                FilterControlAltText="Filter itme column" HeaderText="資料" UniqueName="itme">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="old_itme" 
                                FilterControlAltText="Filter old_itme column" HeaderText="舊資料" 
                                UniqueName="old_itme">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="adate" 
                                FilterControlAltText="Filter adate column" HeaderText="日期" UniqueName="adate">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="note" 
                                FilterControlAltText="Filter note column" HeaderText="註記" UniqueName="note">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </ContentTemplate>
        </telerik:RadWindow>
    </telerik:RadAjaxPanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
