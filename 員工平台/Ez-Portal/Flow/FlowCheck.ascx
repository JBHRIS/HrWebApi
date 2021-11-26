<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlowCheck.ascx.cs" Inherits="Flow_FlowCheck" %>
<div class="BlueForm">
    <div class="BlueFormHeader">
        <span class="BHLeft"></span><span class="GHeader">
            <asp:Label ID="lblHeader" runat="server" Text="表單代辦事項" 
            meta:resourcekey="lblHeaderResource1"></asp:Label></span> <span class="BHRight">
        </span>

    

    </div>
    <div class="BlueFormContent">
        <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
            OnRowCommand="grdMain_RowCommand" OnRowDataBound="grdMain_RowDataBound" 
            Width="100%" meta:resourcekey="grdMainResource1">
            <Columns>
                <asp:TemplateField ShowHeader="False" meta:resourcekey="TemplateFieldResource1">
                    <HeaderStyle Width="1%" />
                    <ItemTemplate>
                        <asp:Button ID="bnCheck" runat="server" CausesValidation="False" CommandName="Check"
                            Text="處理" meta:resourcekey="bnCheckResource1" />&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProcessFlow_id" HeaderText="流程序" 
                    SortExpression="ProcessFlow_id" meta:resourcekey="BoundFieldResource1">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="Emp_name_Start" HeaderText="申請人" 
                    SortExpression="Emp_name_Start" meta:resourcekey="BoundFieldResource2">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="adate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="申請時間"
                    HtmlEncode="False" SortExpression="adate" 
                    meta:resourcekey="BoundFieldResource3">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="FlowTree_name" HeaderText="流程名稱" 
                    SortExpression="FlowTree_name" meta:resourcekey="BoundFieldResource4">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="FlowNode_name" HeaderText="處理方式" 
                    SortExpression="FlowNode_name" meta:resourcekey="BoundFieldResource5">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="25%" />
                </asp:BoundField>
                <asp:BoundField DataField="Emp_name_Agent" HeaderText="代理人" 
                    SortExpression="Emp_name_Agent" meta:resourcekey="BoundFieldResource6">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="狀態" meta:resourcekey="TemplateFieldResource2">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Label ID="lbStatus" runat="server" meta:resourcekey="lbStatusResource1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              
                <br />
                <asp:Label ID="lblEmptyMsn" runat="server" Text="您好！目前沒有待處理的工作。謝謝！" 
                    meta:resourcekey="lblEmptyMsnResource1"></asp:Label>
                <br />
              
            </EmptyDataTemplate>
            <EmptyDataRowStyle BorderStyle="None" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetData" TypeName="ezClientDSTableAdapters.WorkListTableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="emp_id" Name="Emp_id" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <div class="BlueFormFooter">
        <span class="BFLeft"></span><span class="BFRight"></span>
    </div>
</div>
<asp:Label ID="emp_id" runat="server" Visible="False" 
    meta:resourcekey="emp_idResource1"></asp:Label>
