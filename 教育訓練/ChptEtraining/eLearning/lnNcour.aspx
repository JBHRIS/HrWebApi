﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mpLearningFront.master" AutoEventWireup="true" CodeFile="lnNcour.aspx.cs" Inherits="eLearning_lnNcour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="news">
	<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>

		<h4>最新課程</h4>
		<table style="width: 100%">
			<tr>
				<td>程式設計
				<span>-</span> C#.net
				<span>-</span> 基礎認知</td>
				<td>2011/01/08</td>
				<td class="g"><a href=""></a></td>
				<td><a href="">加入最愛</a></td>
			</tr>
			<tr>
				<td>企業管理
				<span>-</span> 專案管理
				<span>-</span> 專案管理程序</td>
				<td>2011/01/05</td>
				<td class="g"><a href=""></a></td>
				<td style="color:red">已加入</td>
			</tr>
			<tr>
				<td>人力資源
				<span>-</span> 勞動法令
				<span>-</span> 勞基法</td>
				<td>2010/12/19</td>
				<td class="g"><a href=""></a></td>
				<td><a href="">加入最愛</a></td>
			</tr>
						<tr>
				<td>程式設計
				<span>-</span> C#.net
				<span>-</span> 基礎認知</td>
				<td>2011/01/08</td>
				<td class="g"><a href=""></a></td>
				<td><a href="">加入最愛</a></td>
			</tr>
			<tr>
				<td>企業管理
				<span>-</span> 專案管理
				<span>-</span> 專案管理程序</td>
				<td>2011/01/05</td>
				<td class="g"><a href=""></a></td>
				<td><a href="">加入最愛</a></td>
			</tr>
			<tr>
				<td>人力資源
				<span>-</span> 勞動法令
				<span>-</span> 勞基法</td>
				<td>2010/12/19</td>
				<td class="g"><a href=""></a></td>
				<td><a href="">加入最愛</a></td>
			</tr>

		</table>
          <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
          
    	
		<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>

</div>

</asp:Content>

