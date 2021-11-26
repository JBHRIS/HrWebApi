<%@ Page Title="" Language="C#" MasterPageFile="~/mpLearningFront.master" AutoEventWireup="true" CodeFile="lnArt.aspx.cs" Inherits="eLearning_lnArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="news">
		<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>

		<h4>文章交流</h4>
		<div>
			<form method="post">文章類型
				<select name="Select1" style="width: 100px">
				<option>全部</option>
				<option>程式設計</option> 
				<option>人力資源</option>
				<option>經營管理</option>
				<option>個人成長</option>
				<option>生活小品</option>
				<option>其他</option>
				</select>&nbsp;&nbsp; 關鍵字<input name="Text1" type="text" /><input name="Button1" type="button" value="確定" /></form>
		</div>
			<table style="width: 100%">
							<tr style="background-color:#CCCCCC;color:#FFFFFF">
								<td>文章名稱</td>
								<td>文章類型</td>
								<td>張貼者</td>
								<td>張貼日期</td>
								<td>人氣指數</td>
								<td>回應篇數</td>
							</tr>
							<tr>
								<td><a href="">工程師不可不知的一百件事</a></td>
								<td>程式設計</td>
								<td>張阿美</td>
								<td>2011/01/08</td>
								<td>21</td>
								<td>5</td>
							</tr>
							<tr>
								<td><a href="">勞動基準法新法上路</a></td>
								<td>人力資源</td>
								<td>李小英</td>
								<td>2011/01/03</td>
								<td>15</td>
								<td>3</td>
							</tr>
							<tr>
								<td><a href="">簡單好生活，生活好簡單</a></td>
								<td>其他</td>
								<td>王先生</td>
								<td>2010/11/28</td>
								<td>34</td>
								<td>12</td>
							</tr>
							<tr>
								<td>
                                    &nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td style="height: 21px"></td>
								<td style="height: 21px"></td>
								<td style="height: 21px"></td>
								<td style="height: 21px"></td>
								<td style="height: 21px"></td>
								<td style="height: 21px"></td>
							</tr>
						</table>
		
			<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>

</div>

</asp:Content>

