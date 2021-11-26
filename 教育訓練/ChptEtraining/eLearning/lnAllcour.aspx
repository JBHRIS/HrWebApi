<%@ Page Title="" Language="C#" MasterPageFile="~/mpLearningFront.master" AutoEventWireup="true" CodeFile="lnAllcour.aspx.cs" Inherits="eLearning_lnAllcour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="news">
		<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>
		<h4>課程總覽</h4>
		<div>
			<form method="post">
				<select name="Select1" style="width: 100px">
				<option>請選擇科別</option>
				<option>程式設計</option> 
				</select> <select name="Select2" style="width: 100px">
				<option>請選擇科目</option>
				<option>C#.net</option>
				<option>PHP</option>
				</select> <select name="Select3" style="width: 100px">
				<option>請選擇課程</option>
				<option>基礎認知</option>
				<option>進階認知</option>
				</select> </form>
		</div>
			<table style="width: 100%;margin:10px 0 0 0">
						
							<tr style="background-color:#B1E7F3">
								<th>科別</th>
								<th>科目</th>
								<th>課程</th>
								<th>修課時數</th>
								<th>課程難度</th>
							</tr>
							<tr>
								<td>程式設計</td>
								<td>C#.net</td>
								<td>基礎認知</td>
								<td>2HR</td>
								<td class="h"></td>
								<td><a href=""><img alt="29" src="../IMAGES/play.png" width="20" height="20"/></a></td>
								<td><a href="">加入最愛</a></td>
							</tr>
							<tr>
								<td>程式設計</td>
								<td>C#.net</td>
								<td>進階認知</td>
								<td>2.5HR</td>
								<td class="h"></td>
								<td><a href=""><img alt="29" src="../IMAGES/play.png" width="20" height="20"/></a></td>
								<td><a href="">加入最愛</a></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
						</table>
		
			
			<span style="background-color:#ffffff;height:10px;width:575px;display:block"></span>
</div>

</asp:Content>

