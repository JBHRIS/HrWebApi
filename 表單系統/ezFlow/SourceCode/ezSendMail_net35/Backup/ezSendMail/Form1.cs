using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace ezSendMail {
	public partial class Form1 : Form {
		MainDSTableAdapters.EmpTableAdapter adEmp = new ezSendMail.MainDSTableAdapters.EmpTableAdapter();
		MainDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezSendMail.MainDSTableAdapters.ProcessFlowTableAdapter();
		MainDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezSendMail.MainDSTableAdapters.ProcessNodeTableAdapter();
		MainDSTableAdapters.RoleTableAdapter adRole = new ezSendMail.MainDSTableAdapters.RoleTableAdapter();
		MainDSTableAdapters.SendMailParmTableAdapter adSendMailParm = new ezSendMail.MainDSTableAdapters.SendMailParmTableAdapter();
		MainDSTableAdapters.SendMailLogTableAdapter adSendMailLog = new ezSendMail.MainDSTableAdapters.SendMailLogTableAdapter();
		MainDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezSendMail.MainDSTableAdapters.ProcessCheckTableAdapter();
		MainDSTableAdapters.SysVarTableAdapter adSysVar = new ezSendMail.MainDSTableAdapters.SysVarTableAdapter();
		MainDSTableAdapters.ProcessApParmTableAdapter adProcessApParm = new ezSendMail.MainDSTableAdapters.ProcessApParmTableAdapter();
		MainDSTableAdapters.ProcessFlowShareTableAdapter adProcessFlowShare = new ezSendMail.MainDSTableAdapters.ProcessFlowShareTableAdapter();
		MainDSTableAdapters.CheckAgentAlwaysTableAdapter adCheckAgentAlways = new ezSendMail.MainDSTableAdapters.CheckAgentAlwaysTableAdapter();
		MainDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezSendMail.MainDSTableAdapters.CheckAgentDefaultTableAdapter();
		MainDSTableAdapters.CheckAgentPowerMTableAdapter adCheckAgentPowerM = new ezSendMail.MainDSTableAdapters.CheckAgentPowerMTableAdapter();
		MainDSTableAdapters.CheckAgentPowerDTableAdapter adCheckAgentPowerD = new ezSendMail.MainDSTableAdapters.CheckAgentPowerDTableAdapter();
		MainDSTableAdapters.DeptTableAdapter adDept = new ezSendMail.MainDSTableAdapters.DeptTableAdapter();
		MainDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezSendMail.MainDSTableAdapters.FlowTreeTableAdapter();

		public enum AgentType { None, Always, Default, Other };

		public class CMan {
			public string idRole = "";
			public string idEmp = "";
			public AgentType agentType = AgentType.None;
		}

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			MainDS.SendMailParmDataTable dtSendMailParm = adSendMailParm.GetData();
			if(dtSendMailParm.Count > 0) {
				txtTrigger.Value = dtSendMailParm[0].triggerTimer;
				txtSpanTime.Value = dtSendMailParm[0].mailSpantime;
				txtMaxCount.Value = dtSendMailParm[0].mailMaxCount;
				ckAutoFix.Checked = dtSendMailParm[0].autofix;
				ckMailMang.Checked = dtSendMailParm[0].mailMang;
				ckMailCustom.Checked = dtSendMailParm[0].mailCustom;
				txtToAddress.Text = dtSendMailParm[0].customEmail;
			}
			else { //如果資料庫沒有資料，則先帶預設值
				txtTrigger.Value = 10;
				txtSpanTime.Value = 24;
				txtMaxCount.Value = 3;
				ckAutoFix.Checked = true;
				ckMailMang.Checked = true;
				ckMailCustom.Checked = false;
				txtToAddress.Text = "";
			}

			if(txtTrigger.Value > 0) {
				lbRunTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
				lbNextRunTime.Text = Convert.ToDateTime(lbRunTime.Text).AddMinutes(Convert.ToDouble(txtTrigger.Value)).ToString("yyyy/MM/dd HH:mm:ss");
				timer.Interval = Convert.ToInt32(txtTrigger.Value) * 60 * 1000;
				timer.Enabled = true;
				lbStatus.Text = "服務已啟動…";
			}
			else {
				timer.Enabled = false;
				lbStatus.Text = "服務已停止…";
			}
		}

		private void bnSave_Click(object sender, EventArgs e) {
			MainDS.SendMailParmDataTable dtSendMailParm = adSendMailParm.GetData();
			MainDS.SendMailParmRow rowSendMailParm = null;
			if(dtSendMailParm.Count == 0) {
				rowSendMailParm = dtSendMailParm.NewSendMailParmRow();
			}
			else rowSendMailParm = dtSendMailParm[0];
			rowSendMailParm.triggerTimer = Convert.ToInt32(txtTrigger.Value);
			rowSendMailParm.mailSpantime = Convert.ToInt32(txtSpanTime.Value);
			rowSendMailParm.mailMaxCount = Convert.ToInt32(txtMaxCount.Value);
			rowSendMailParm.autofix = ckAutoFix.Checked;
			rowSendMailParm.mailMang = ckMailMang.Checked;
			rowSendMailParm.mailCustom = ckMailCustom.Checked;
			rowSendMailParm.customEmail = txtToAddress.Text;
			if(dtSendMailParm.Count == 0) dtSendMailParm.AddSendMailParmRow(rowSendMailParm);

			adSendMailParm.Update(dtSendMailParm);

			MessageBox.Show("參數儲存完畢", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void timer_Tick(object sender, EventArgs e) {
			timer.Enabled = false;

			MainDS.SysVarDataTable dtSysVar = adSysVar.GetData();
			if(dtSysVar.Count == 0) return;

			//抓取全部未簽的
			MainDS.ProcessCheckDataTable dtProcessCheck = adProcessCheck.GetData();
			foreach(MainDS.ProcessCheckRow rowProcessCheck in dtProcessCheck.Rows) {
				string Emp_id = rowProcessCheck.Emp_idDefault;
				string Role_id = rowProcessCheck.Role_idDefault;
				//確認角色正確
				MainDS.RoleDataTable dtRole = adRole.GetDataByIdAndEmp(Role_id, Emp_id);
				if(dtRole.Count > 0) {
					string Emp_idAgent = rowProcessCheck.Emp_idAgent;
					string Role_idAgent = rowProcessCheck.Role_idAgent;
					//檢查是否由代理人簽核
					if(Role_id.Trim().Length > 0 && Emp_idAgent.Trim().Length > 0) {
						//確認代理角色正確
						dtRole = adRole.GetDataByIdAndEmp(Role_idAgent, Emp_idAgent);
						if(dtRole.Count > 0) {
							//檢查是否需要另找合適的人
							MainDS.EmpDataTable dtEmp = adEmp.GetDataById(Emp_idAgent);
							if(dtEmp.Count > 0) {
								if(dtEmp[0].isNeedAgent && DateTime.Now >= dtEmp[0].dateB && DateTime.Now <= dtEmp[0].dateE) {
									MainDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByAuto(rowProcessCheck.ProcessNode_auto);
									if(dtProcessNode.Count > 0) {
										CMan Man = GetAgent(dtProcessNode[0].ProcessFlow_id, rowProcessCheck.Role_idDefault, rowProcessCheck.Emp_idDefault);
										if(Man != null) {
											rowProcessCheck.Role_idAgent = Man.idRole;
											rowProcessCheck.Emp_idAgent = Man.idEmp;
											adProcessCheck.Update(dtProcessCheck);

											Emp_idAgent = rowProcessCheck.Emp_idAgent;
											Role_idAgent = rowProcessCheck.Role_idAgent;

											dtEmp = adEmp.GetDataById(Emp_idAgent);
										}
									}
								}

								MainDS.SendMailLogDataTable dtSendMailLog = adSendMailLog.GetDataByEmpID(Emp_idAgent);
								MainDS.SendMailLogRow rowSendMailLog = null;
								bool isNew = false;
								if(dtSendMailLog.Count == 0) {
									rowSendMailLog = dtSendMailLog.NewSendMailLogRow();
									rowSendMailLog.Emp_id = Emp_idAgent;
									rowSendMailLog.counter = 1;
									rowSendMailLog.adate = DateTime.Now;
									dtSendMailLog.AddSendMailLogRow(rowSendMailLog);
									isNew = true;
								}
								else rowSendMailLog = dtSendMailLog[0];

								if(isNew) { //馬上通知
									if(dtEmp.Count > 0 && !dtEmp[0].IsemailNull() && dtEmp[0].email.Trim().Length > 0) {
										string toAddress = dtEmp[0].email.Trim();
										string toName = dtEmp[0].name;
										string subject = "流程激催簽核通知(代核)";
										string body = dtEmp[0].name + ",您好...<br><br>" +
											"這封信，是由 ezFlow System 所發出的。<br>" +
											"系統偵測到在流程中，有您的待辦事項需要完成，請您抽空前往處理。謝謝！<br><br>" +
											"<a href='" + dtSysVar[0].urlRoot + "/ezClient/default.aspx'>ezFlow Personal Web Site</a>";
										SendMail(toAddress, toName, subject, body);
									}
								}
								else { //大於激催間隔後才發
									if(!dtEmp[0].IsemailNull() && dtEmp[0].email.Trim().Length > 0) {
										TimeSpan timeSpan = DateTime.Now - rowSendMailLog.adate;
										if(timeSpan.TotalHours >= Convert.ToInt32(txtSpanTime.Value)) {
											if(rowSendMailLog.counter < Convert.ToInt32(txtMaxCount.Value)) {
												rowSendMailLog.counter += 1;
												rowSendMailLog.adate = DateTime.Now;

												string toAddress = dtEmp[0].email.Trim();
												string toName = dtEmp[0].name;
												string subject = "流程激催簽核通知(代核)";
												string body = dtEmp[0].name + ",您好...<br><br>" +
													"這封信，是由 ezFlow System 所發出的。<br>" +
													"系統偵測到在流程中，有您的待辦事項需要完成，請您抽空前往處理。謝謝！<br><br>" +
													"<a href='" + dtSysVar[0].urlRoot + "/ezClient/default.aspx'>ezFlow Personal Web Site</a>";
												SendMail(toAddress, toName, subject, body);
											}
											else {
												if(ckMailMang.Checked) {
													MainDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByAuto(rowProcessCheck.ProcessNode_auto);
													if(dtProcessNode.Count > 0) {
														CMan Man = GetManager(dtProcessNode[0].ProcessFlow_id, rowProcessCheck.Role_idDefault);
														MainDS.EmpDataTable dtEmp_Top = adEmp.GetDataById(Man.idEmp);
														if(dtEmp_Top.Count > 0 && !dtEmp_Top[0].IsemailNull() && dtEmp_Top[0].email.Trim().Length > 0) {
															MainDS.SendMailLogDataTable dtSendMail_Mang = adSendMailLog.GetDataByEmpID(dtEmp_Top[0].id);
															if(dtSendMail_Mang.Count == 0) {
																MainDS.SendMailLogRow rowSendMail_Mang = dtSendMail_Mang.NewSendMailLogRow();
																rowSendMail_Mang.Emp_id = dtEmp_Top[0].id;
																rowSendMail_Mang.adate = DateTime.Now;
																rowSendMail_Mang.counter += 1;
																dtSendMail_Mang.AddSendMailLogRow(rowSendMail_Mang);
																adSendMailLog.Update(dtSendMail_Mang);
																string subject = "請您幫忙激催流程簽核";
																string body = dtEmp_Top[0].name + ",您好...<br><br>" +
																	"這封信，是由 ezFlow System 所發出的。<br>" +
																	"系統偵測到'" + dtEmp[0].name + "'有未處理的待辦事項。<br><br>" +
																	"資料參考：<br>" +
																	"激催次數：" + txtMaxCount.Value.ToString() + " 次<br>";
																SendMail(dtEmp_Top[0].email, dtEmp_Top[0].name, subject, body);
															}
															else {
																timeSpan = DateTime.Now - dtSendMail_Mang[0].adate;
																if(timeSpan.TotalHours >= Convert.ToInt32(txtSpanTime.Value)) {
																	dtSendMail_Mang[0].adate = DateTime.Now;
																	adSendMailLog.Update(dtSendMail_Mang);
																	string subject = "請您幫忙激催流程簽核";
																	string body = dtEmp_Top[0].name + ",您好...<br><br>" +
																		"這封信，是由 ezFlow System 所發出的。<br>" +
																		"系統偵測到'" + dtEmp[0].name + "'有未處理的待辦事項。<br><br>" +
																		"資料參考：<br>" +
																		"激催次數：" + txtMaxCount.Value.ToString() + " 次<br>";
																	SendMail(dtEmp_Top[0].email, dtEmp_Top[0].name, subject, body);
																}
															}
														}
													}
												}
											}
										}
									}
								}

								//更新通知記錄
								adSendMailLog.Update(rowSendMailLog);
							}
						}
						else { //代理角色有誤必須自動修復
							string subject = "流程問題無法修復";
							string body = "您好…<br><br>" +
								"這封信，是由 ezFlow System 所發出的。<br>" +
								"系統偵測到在流程中，簽核角色可能已經不在有效。<br><br>" +
								"下列資料供您參考以便解決問題：<br>" +
								"ProcessCheck=" + rowProcessCheck.auto.ToString() + "<br>" +
								"預設角色代碼=" + rowProcessCheck.Role_idDefault + "<br>" +
								"預設成員代碼=" + rowProcessCheck.Emp_idDefault + "<br>" +
								"代理角色代碼=" + rowProcessCheck.Role_idAgent + "<br>" +
								"代理成員代碼=" + rowProcessCheck.Emp_idAgent + "<br>";

							if(ckAutoFix.Checked) {
								if(!AutoFix(rowProcessCheck.auto)) {
									if(ckMailCustom.Checked) {
										SendMail(txtToAddress.Text, txtToAddress.Text, subject, body);
									}
								}
							}
							else {
								if(ckMailCustom.Checked) {
									SendMail(txtToAddress.Text, txtToAddress.Text, subject, body);
								}
							}
						}
					}
					else { //由本人簽核
						//檢查是否需要另找合適的人
						MainDS.EmpDataTable dtEmp = adEmp.GetDataById(Emp_id);
						if(dtEmp.Count > 0) {
							if(dtEmp[0].isNeedAgent && DateTime.Now >= dtEmp[0].dateB && DateTime.Now <= dtEmp[0].dateE) {
								MainDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByAuto(rowProcessCheck.ProcessNode_auto);
								if(dtProcessNode.Count > 0) {
									CMan Man = GetAgent(dtProcessNode[0].ProcessFlow_id, rowProcessCheck.Role_idDefault, rowProcessCheck.Emp_idDefault);
									if(Man != null) {
										rowProcessCheck.Role_idAgent = Man.idRole;
										rowProcessCheck.Emp_idAgent = Man.idEmp;
										adProcessCheck.Update(dtProcessCheck);

										Emp_id = rowProcessCheck.Emp_idAgent;
										Role_id = rowProcessCheck.Role_idAgent;

										dtEmp = adEmp.GetDataById(Emp_id);
									}
								}
							}

							MainDS.SendMailLogDataTable dtSendMailLog = adSendMailLog.GetDataByEmpID(Emp_id);
							MainDS.SendMailLogRow rowSendMailLog = null;
							bool isNew = false;
							if(dtSendMailLog.Count == 0) {
								rowSendMailLog = dtSendMailLog.NewSendMailLogRow();
								rowSendMailLog.Emp_id = Emp_id;
								rowSendMailLog.counter = 1;
								rowSendMailLog.adate = DateTime.Now;
								dtSendMailLog.AddSendMailLogRow(rowSendMailLog);
								isNew = true;
							}
							else rowSendMailLog = dtSendMailLog[0];

							if(isNew) { //馬上通知									
								if(dtEmp.Count > 0 && !dtEmp[0].IsemailNull() && dtEmp[0].email.Trim().Length > 0) {
									string toAddress = dtEmp[0].email.Trim();
									string toName = dtEmp[0].name;
									string subject = "流程激催簽核通知";
									string body = dtEmp[0].name + ",您好...<br><br>" +
										"這封信，是由 ezFlow System 所發出的。<br>" +
										"系統偵測到在流程中，有您的待辦事項需要完成，請您抽空前往處理。謝謝！<br><br>" +
										"<a href='" + dtSysVar[0].urlRoot + "/ezClient/default.aspx'>ezFlow Personal Web Site</a>";
									SendMail(toAddress, toName, subject, body);
								}
							}
							else { //大於激催間隔後才發
								if(dtEmp.Count > 0 && !dtEmp[0].IsemailNull() && dtEmp[0].email.Trim().Length > 0) {
									TimeSpan timeSpan = DateTime.Now - rowSendMailLog.adate;									
									if(timeSpan.TotalHours >= Convert.ToInt32(txtSpanTime.Value)) {
										if(rowSendMailLog.counter < Convert.ToInt32(txtMaxCount.Value)) {
											rowSendMailLog.counter += 1;
											rowSendMailLog.adate = DateTime.Now;

											string toAddress = dtEmp[0].email.Trim();
											string toName = dtEmp[0].name;
											string subject = "流程激催簽核通知";
											string body = dtEmp[0].name + ",您好...<br><br>" +
												"這封信，是由 ezFlow System 所發出的。<br>" +
												"系統偵測到在流程中，有您的待辦事項需要完成，請您抽空前往處理。謝謝！<br><br>" +
												"<a href='" + dtSysVar[0].urlRoot + "/ezClient/default.aspx'>ezFlow Personal Web Site</a>";
											SendMail(toAddress, toName, subject, body);
										}
										else {
											if(ckMailMang.Checked) {
												MainDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByAuto(rowProcessCheck.ProcessNode_auto);
												if(dtProcessNode.Count > 0) {
													CMan Man = GetManager(dtProcessNode[0].ProcessFlow_id, rowProcessCheck.Role_idDefault);
													MainDS.EmpDataTable dtEmp_Top = adEmp.GetDataById(Man.idEmp);
													if(dtEmp_Top.Count > 0 && !dtEmp_Top[0].IsemailNull() && dtEmp_Top[0].email.Trim().Length > 0) {
														string subject = "請您幫忙激催";
														string body = dtEmp_Top[0].name + ",您好...<br><br>" +
															"非常抱歉打擾您，這封信是由 ezFlow System 所發出的。<br>" +
															"系統偵測到'" + dtEmp[0].name + "'有未處理的待辦事項。<br>" +
															"為了使電子表單運作得以順暢，請您代為提醒。謝謝！<br><br>" +
															"資料參考：<br>" +
															"激催次數：" + txtMaxCount.Value.ToString() + " 次<br>";
														SendMail(dtEmp_Top[0].email, dtEmp_Top[0].name, subject, body);
													}
												}
											}
										}
									}
								}
							}

							//更新通知記錄
							adSendMailLog.Update(rowSendMailLog);
						}
					}
				}
				else { //角色有誤必須自動修復
					string subject = "流程問題無法修復";
					string body = "您好…<br>" +
						"這封信，是由 ezFlow System 所發出的。<br>" +
						"系統偵測到在流程中，簽核角色可能已經不在有效。<br><br>" +
						"下列資料供您參考以便解決問題：<br>" +
						"ProcessCheck=" + rowProcessCheck.auto.ToString() + "<br>" +
						"預設角色代碼=" + rowProcessCheck.Role_idDefault + "<br>" +
						"預設成員代碼=" + rowProcessCheck.Emp_idDefault + "<br>" +
						"代理角色代碼=" + rowProcessCheck.Role_idAgent + "<br>" +
						"代理成員代碼=" + rowProcessCheck.Emp_idAgent + "<br>";

					if(ckAutoFix.Checked) {
						if(!AutoFix(rowProcessCheck.auto)) {
							if(ckMailCustom.Checked) {
								SendMail(txtToAddress.Text, txtToAddress.Text, subject, body);
							}
						}
					}
					else {
						if(ckMailCustom.Checked) {
							SendMail(txtToAddress.Text, txtToAddress.Text, subject, body);
						}
					}
				}
			}

			lbRunTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
			lbNextRunTime.Text = Convert.ToDateTime(lbRunTime.Text).AddMinutes(Convert.ToDouble(txtTrigger.Value)).ToString("yyyy/MM/dd HH:mm:ss");

			timer.Interval = Convert.ToInt32(txtTrigger.Value) * 60 * 1000;
			timer.Enabled = true;
		}

		void SendMail(string toAddress, string toName, string subject, string body) {
			MainDS.SysVarDataTable dtSysVar = adSysVar.GetData();
			if(dtSysVar.Count > 0) {
				try {
					string mailServerName = dtSysVar[0].mailServer;
					string fromAddress = dtSysVar[0].senderMail;
					string fromName = dtSysVar[0].senderName;

					bool isUseDefaultCredentials = true;
					string strFrom = "", strFromPass = "";
					if(dtSysVar[0].mailID.Trim().Length > 0) {
						strFrom = dtSysVar[0].mailID;
						strFromPass = dtSysVar[0].mailPW;
						isUseDefaultCredentials = false;
					}

					MailMessage message = new MailMessage();
					message.From = new MailAddress(fromAddress, fromName, Encoding.Default);
					message.To.Add(new MailAddress(toAddress, toName, Encoding.Default));
					message.Subject = subject;
					message.Body = body;
					message.IsBodyHtml = true;
					message.Priority = MailPriority.High;
					message.BodyEncoding = System.Text.Encoding.Default;
					message.SubjectEncoding = System.Text.Encoding.Default;

					SmtpClient mailClient = new SmtpClient(mailServerName);
					mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

					if(isUseDefaultCredentials) mailClient.UseDefaultCredentials = true;
					else {
						mailClient.UseDefaultCredentials = false;
						mailClient.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
					}

					mailClient.Send(message);
				}
				catch {
					return;
				}
			}
		}

		private void bnRun_Click(object sender, EventArgs e) {
			adSendMailLog.DeleteQuery();
			timer_Tick(null, null);
		}

		bool AutoFix(int ProcessCheck_auto) {
			try {
				MainDS.ProcessCheckDataTable dtProcessCheck_Error = adProcessCheck.GetDataByAuto(ProcessCheck_auto);
				foreach(MainDS.ProcessCheckRow rowProcessCheck_Error in dtProcessCheck_Error.Rows) {
					MainDS.ProcessNodeDataTable dtProcessNode_Error = adProcessNode.GetDataByAuto(rowProcessCheck_Error.ProcessNode_auto);
					if(dtProcessNode_Error.Count > 0) {
						if(dtProcessNode_Error[0].ProcessNode_idPrior != 0) {
							MainDS.ProcessNodeDataTable dtProcessNode_Prior = adProcessNode.GetDataByAuto(dtProcessNode_Error[0].ProcessNode_idPrior);
							if(dtProcessNode_Prior.Count > 0) {
								int ProcessNode_idPrior = dtProcessNode_Prior[0].auto;

								//將錯誤的 ProcessNode,ProcessCheck,ProcessApParm 刪除
								dtProcessNode_Error[0].Delete();
								adProcessNode.Update(dtProcessNode_Error);

								rowProcessCheck_Error.Delete();
								adProcessCheck.Update(dtProcessCheck_Error);

								MainDS.ProcessApParmDataTable dtProcessApParm_Error = adProcessApParm.GetDataByKeys(dtProcessNode_Error[0].ProcessFlow_id, dtProcessNode_Error[0].auto, ProcessCheck_auto);
								for(int i = 0; i < dtProcessApParm_Error.Count; i++) dtProcessApParm_Error[i].Delete();
								adProcessApParm.Update(dtProcessApParm_Error);

								//修復
								dtProcessNode_Prior[0].isFinish = false;
								adProcessNode.Update(dtProcessNode_Prior);

								MainDS.ProcessCheckDataTable dtProcessCheck_Prior = adProcessCheck.GetDataByProcessNode(ProcessNode_idPrior);
								foreach(MainDS.ProcessCheckRow rowProcessCheck_Prior in dtProcessCheck_Prior.Rows) {
									MainDS.ProcessApParmDataTable dtProcessApParm_Prior = adProcessApParm.GetDataByKeys(dtProcessNode_Prior[0].ProcessFlow_id, ProcessNode_idPrior, rowProcessCheck_Prior.auto);
									if(dtProcessApParm_Prior.Count > 0) {
										localhost.Service srvEngine = new ezSendMail.localhost.Service();
										srvEngine.WorkFinish(dtProcessApParm_Prior[0].auto);
									}
								}
							}
						}
						else {
							MainDS.ProcessFlowDataTable dtProcessFlow_Source = adProcessFlow.GetDataById(dtProcessNode_Error[0].ProcessFlow_id);
							if(dtProcessFlow_Source.Count > 0) {
								int idProcess = dtProcessFlow_Source[0].id;
								string idFlowTree = dtProcessFlow_Source[0].FlowTree_id;
								string idRole_Start = dtProcessFlow_Source[0].Role_id;
								string idEmp_Start = dtProcessFlow_Source[0].Emp_id;

								MainDS.ProcessFlowShareDataTable dtProcessFlowShare = adProcessFlowShare.GetDataByOne(dtProcessFlow_Source[0].Role_id, dtProcessFlow_Source[0].Emp_id, dtProcessFlow_Source[0].id);
								if(dtProcessFlowShare.Count > 0) dtProcessFlowShare[0].Delete();
								adProcessFlowShare.Update(dtProcessFlowShare);

								dtProcessNode_Error[0].Delete();
								adProcessNode.Update(dtProcessNode_Error);

								rowProcessCheck_Error.Delete();
								adProcessCheck.Update(dtProcessCheck_Error);

								dtProcessFlow_Source[0].Delete();
								adProcessFlow.Update(dtProcessFlow_Source);

								localhost.Service srvEngine = new ezSendMail.localhost.Service();
								srvEngine.FlowStart(idProcess, idFlowTree, idRole_Start, idEmp_Start, "", "");
							}
						}
					}
				}
				return true;
			}
			catch { return false; }
		}

		private void button1_Click(object sender, EventArgs e) {
			DataSet1TableAdapters.ProcessFlowTableAdapter adProcess = new ezSendMail.DataSet1TableAdapters.ProcessFlowTableAdapter();
			DataSet1TableAdapters.ProcessNodeTableAdapter adProcessNode = new ezSendMail.DataSet1TableAdapters.ProcessNodeTableAdapter();

			DataSet1.ProcessFlowDataTable dtProcess = adProcess.GetData();
			foreach(DataSet1.ProcessFlowRow rowProcessFlow in dtProcess.Rows) {
				DataSet1.ProcessNodeDataTable dtProcessNode = adProcessNode.GetData(rowProcessFlow.id);
				bool firstRec = true;
				int NodeID = 0;
				foreach(DataSet1.ProcessNodeRow rowProcessNode in dtProcessNode.Rows) {
					if(firstRec) {
						firstRec = false;
						NodeID = rowProcessNode.auto;
						rowProcessNode.ProcessNode_idPrior = 0;
					}
					else {
						rowProcessNode.ProcessNode_idPrior = NodeID;
						NodeID = rowProcessNode.auto;
					}
				}
				adProcessNode.Update(dtProcessNode);
			}

			MessageBox.Show("資料庫升級處理完畢", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public CMan GetManager(int idProcess, string Role_idMinion) {
			MainDS.RoleDataTable dtRole_Minion = adRole.GetDataById(Role_idMinion);
			CMan Man = null;
			MainDS.RoleDataTable dtRole_Manager = new MainDS.RoleDataTable();
			if(dtRole_Minion[0].idParent.Trim().Length > 0) {
				dtRole_Manager = adRole.GetDataById(dtRole_Minion[0].idParent);
			}
			else {
				MainDS.DeptDataTable dtDept_Minion = adDept.GetDataById(dtRole_Minion[0].Dept_id);
				dtRole_Manager = adRole.GetDataOfDeptMang(dtDept_Minion[0].idParent);
			}

			MainDS.RoleRow rowRole_Manager = null;
			for(int i = 0; i < dtRole_Manager.Count; i++) {
				rowRole_Manager = dtRole_Manager[i];
				//不抓虛擬角色
				if(!dtRole_Manager[i].IsEmp_idNull() && dtRole_Manager[i].Emp_id.Trim().Length > 0) {
					rowRole_Manager = dtRole_Manager[i];
					MainDS.EmpDataTable dtEmp_Manager = adEmp.GetDataById(dtRole_Manager[i].Emp_id);
					//以取得沒請假的主管為主
					if(dtEmp_Manager.Count > 0 && !(dtEmp_Manager[0].isNeedAgent && DateTime.Now.Date >= dtEmp_Manager[0].dateB && DateTime.Now.Date <= dtEmp_Manager[0].dateE)) {
						Man = new CMan();
						Man.idRole = dtRole_Manager[i].id;
						Man.idEmp = dtRole_Manager[i].Emp_id;
						break;
					}
				}
			}

			//如果是虛擬角色，則抓取可替代人選
			if(Man == null) {
				Man = GetAgent(idProcess, rowRole_Manager.id, rowRole_Manager.Emp_id);
				//如果抓不到虛擬角色的代理人，則抓虛擬角色的主管
				//而且這裡形成遞回，所以必定往上抓到主管為止
				if(Man == null) {
					Man = GetManager(idProcess, rowRole_Manager.id);
				}
			}

			return Man;
		}

		public CMan GetAgent(int idProcess, string Role_idSource, string Emp_idSource) {
			//如果傳進來的是子流程，則找出主流程序
			MainDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(idProcess);
			string FlowTree_id = dtProcessFlow[0].FlowTree_id;
			while(dtProcessFlow[0].ProcessNode_auto != 0) {
				MainDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByAuto(dtProcessFlow[0].ProcessNode_auto);
				dtProcessFlow = adProcessFlow.GetDataById(dtProcessNode[0].ProcessFlow_id);
				if(dtProcessFlow[0].ProcessNode_auto == 0) FlowTree_id = dtProcessFlow[0].FlowTree_id;
			}

			//資料宣告
			CMan Man = null;
			//先檢查有沒有設定常態性代理人
			bool isAlwaysAgent = false;
			MainDS.CheckAgentAlwaysDataTable dtCheckAgentAlways;
			//如果有工號，則精準抓出代理人，如果沒有工號，則抓此角色的代理人
			if(Emp_idSource.Trim().Length > 0)
				dtCheckAgentAlways = adCheckAgentAlways.GetDataByIdSource(Role_idSource, Emp_idSource);
			else
				dtCheckAgentAlways = adCheckAgentAlways.GetDataByIdRoleSource(Role_idSource);

			if(dtCheckAgentAlways.Count > 0) {
				foreach(DataRow drCheckAgentAlways in dtCheckAgentAlways.Rows) {
					MainDS.CheckAgentAlwaysRow rowCheckAgentAlways = (MainDS.CheckAgentAlwaysRow)drCheckAgentAlways;

					//所指定的代理人是否正確的存在角色檔中，如果不存在，則刪除此代理人
					MainDS.RoleDataTable dtRole_Target = adRole.GetDataByIdAndEmp(rowCheckAgentAlways.Role_idTarget, rowCheckAgentAlways.Emp_idTarget);
					if(dtRole_Target.Count == 0) {
						rowCheckAgentAlways.Delete();
						continue;
					}

					//檢查常態性代理人是否請假了
					MainDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(rowCheckAgentAlways.Emp_idTarget);
					if(dtEmp_Target.Count > 0 && dtEmp_Target[0].isNeedAgent && DateTime.Now.Date >= dtEmp_Target[0].dateB && DateTime.Now.Date <= dtEmp_Target[0].dateE) continue;

					//檢查常態性代理人，是否有可簽部門限制
					MainDS.CheckAgentPowerMDataTable dtCheckAgentPowerM = adCheckAgentPowerM.GetDataByCheckAgentAlways(rowCheckAgentAlways.auto);
					foreach(DataRow drCheckAgentPowerM in dtCheckAgentPowerM.Rows) {
						MainDS.CheckAgentPowerMRow rowCheckAgentPowerM = (MainDS.CheckAgentPowerMRow)drCheckAgentPowerM;

						//先檢查部門是否仍存在於資料庫，不存在的話，就刪除該筆資料
						MainDS.DeptDataTable dtDept_Criteria = adDept.GetDataById(rowCheckAgentPowerM.Dept_id);
						if(dtDept_Criteria.Count == 0) {
							rowCheckAgentPowerM.Delete();
							continue;
						}

						bool isRightDept = false;
						if(rowCheckAgentPowerM.isAllSub) {
							MainDS.DeptDataTable dtDept_Target = adDept.GetDataById(dtRole_Target[0].Dept_id);
							if(dtDept_Target[0].path.IndexOf(dtDept_Criteria[0].path) != -1) isRightDept = true;
						}
						else {
							if(dtRole_Target[0].Dept_id == rowCheckAgentPowerM.Dept_id) isRightDept = true;
						}

						if(!isRightDept) continue;

						//檢查常態性代理人，是否有可簽流程限制
						if(FlowTree_id.Trim().Length > 0) {
							MainDS.CheckAgentPowerDDataTable dtCheckAgentPowerD = adCheckAgentPowerD.GetDataByCheckAgentPowerM(rowCheckAgentPowerM.auto);
							if(dtCheckAgentPowerD.Count > 0) {
								bool isRightFlow = false;
								foreach(DataRow drCheckAgentPowerD in dtCheckAgentPowerD.Rows) {
									MainDS.CheckAgentPowerDRow rowCheckAgentPowerD = (MainDS.CheckAgentPowerDRow)drCheckAgentPowerD;
									MainDS.FlowTreeDataTable dtFlowTreeCheck = adFlowTree.GetDataById(rowCheckAgentPowerD.FlowTree_id);
									if(dtFlowTreeCheck.Count == 0) {
										drCheckAgentPowerD.Delete();
										continue;
									}
									if(FlowTree_id == rowCheckAgentPowerD.FlowTree_id) {
										isRightFlow = true;
										break;
									}
								}
								adCheckAgentPowerD.Update(dtCheckAgentPowerD);
								if(!isRightFlow) continue;
							}
						}
						isAlwaysAgent = true;
						break;
					}
					adCheckAgentPowerM.Update(dtCheckAgentPowerM);

					//常態性代理人可以沒有流程的限制，但不可以沒有部門的限制
					if(isAlwaysAgent) {
						Man = new CMan();
						Man.idRole = rowCheckAgentAlways.Role_idTarget;
						Man.idEmp = rowCheckAgentAlways.Emp_idTarget;
						Man.agentType = AgentType.Always;
					}
				}
			}
			adCheckAgentAlways.Update(dtCheckAgentAlways);

			if(isAlwaysAgent) return Man;

			//如果沒有常態性代理人，則找預設代理人
			bool isDefaultAgent = false;

			MainDS.EmpDataTable dtEmp_Source = null;
			MainDS.CheckAgentDefaultDataTable dtCheckAgentDefault = null;

			if(Emp_idSource.Trim().Length > 0) {
				dtEmp_Source = adEmp.GetDataById(Emp_idSource);
				dtCheckAgentDefault = adCheckAgentDefault.GetDataByIdSource(Role_idSource, Emp_idSource);
			}
			else {
				dtCheckAgentDefault = adCheckAgentDefault.GetDataByIdRoleSource(Role_idSource);
			}

			if(dtEmp_Source.Count > 0 && (Emp_idSource.Trim().Length == 0 || (dtEmp_Source[0].isNeedAgent &&
				DateTime.Now.Date >= dtEmp_Source[0].dateB && DateTime.Now.Date <= dtEmp_Source[0].dateE))) {

				MainDS.RoleDataTable dtRole_Target;

				//確認代理人符合組織資料
				dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget1, dtCheckAgentDefault[0].Emp_idTarget1);
				if(dtRole_Target.Count == 0) {
					dtCheckAgentDefault[0].Role_idTarget1 = "";
					dtCheckAgentDefault[0].Emp_idTarget1 = "";
				}
				else {
					MainDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget1);
					if(dtEmp_Target.Count > 0 && !(dtEmp_Target[0].isNeedAgent && DateTime.Now.Date >= dtEmp_Target[0].dateB && DateTime.Now.Date <= dtEmp_Target[0].dateE)) {
						Man = new CMan();
						Man.idRole = dtCheckAgentDefault[0].Role_idTarget1;
						Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget1;
						Man.agentType = AgentType.Default;
						isDefaultAgent = true;
					}
				}
				//抓取第二順位代理人
				if(!isDefaultAgent) {
					//確認代理人符合組織資料
					dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget2, dtCheckAgentDefault[0].Emp_idTarget2);
					if(dtRole_Target.Count == 0) {
						dtCheckAgentDefault[0].Role_idTarget2 = "";
						dtCheckAgentDefault[0].Emp_idTarget2 = "";
					}
					else {
						MainDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget2);
						if(dtEmp_Target.Count > 0 && !(dtEmp_Target[0].isNeedAgent && DateTime.Now.Date >= dtEmp_Target[0].dateB && DateTime.Now.Date <= dtEmp_Target[0].dateE)) {
							Man = new CMan();
							Man.idRole = dtCheckAgentDefault[0].Role_idTarget2;
							Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget2;
							Man.agentType = AgentType.Default;
							isDefaultAgent = true;
						}
					}
				}
				//抓取第三順位代理人
				if(!isDefaultAgent) {
					//確認代理人符合組織資料
					dtRole_Target = adRole.GetDataByIdAndEmp(dtCheckAgentDefault[0].Role_idTarget3, dtCheckAgentDefault[0].Emp_idTarget3);
					if(dtRole_Target.Count == 0) {
						dtCheckAgentDefault[0].Role_idTarget3 = "";
						dtCheckAgentDefault[0].Emp_idTarget3 = "";
					}
					else {
						MainDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtCheckAgentDefault[0].Emp_idTarget3);
						if(dtEmp_Target.Count > 0 && !(dtEmp_Target[0].isNeedAgent && DateTime.Now.Date >= dtEmp_Target[0].dateB && DateTime.Now.Date <= dtEmp_Target[0].dateE)) {
							Man = new CMan();
							Man.idRole = dtCheckAgentDefault[0].Role_idTarget3;
							Man.idEmp = dtCheckAgentDefault[0].Emp_idTarget3;
							Man.agentType = AgentType.Default;
							isDefaultAgent = true;
						}
					}
				}

				if(dtCheckAgentDefault[0].Role_idTarget1.Trim().Length == 0) {
					dtCheckAgentDefault[0].Role_idTarget1 = dtCheckAgentDefault[0].Role_idTarget2;
					dtCheckAgentDefault[0].Emp_idTarget1 = dtCheckAgentDefault[0].Emp_idTarget2;
					dtCheckAgentDefault[0].Role_idTarget2 = "";
					dtCheckAgentDefault[0].Emp_idTarget2 = "";
				}

				if(dtCheckAgentDefault[0].Role_idTarget2.Trim().Length == 0) {
					dtCheckAgentDefault[0].Role_idTarget2 = dtCheckAgentDefault[0].Role_idTarget3;
					dtCheckAgentDefault[0].Emp_idTarget2 = dtCheckAgentDefault[0].Emp_idTarget3;
					dtCheckAgentDefault[0].Role_idTarget3 = "";
					dtCheckAgentDefault[0].Emp_idTarget3 = "";
				}
			}
			adCheckAgentDefault.Update(dtCheckAgentDefault);

			if(isDefaultAgent) return Man;

			bool isAgent = false;
			//如果沒有常態性代理&預設代理，則嘗試尋找同角色
			if(dtEmp_Source.Count > 0 && dtEmp_Source[0].isNeedAgent && DateTime.Now.Date >= dtEmp_Source[0].dateB && DateTime.Now.Date <= dtEmp_Source[0].dateE) {
				MainDS.RoleDataTable dtRole_Agent = adRole.GetDataBySortEmpID(Role_idSource);
				for(int i = 0; i < dtRole_Agent.Count; i++) {
					if(!dtRole_Agent[i].IsEmp_idNull() && dtRole_Agent[i].Emp_id.Trim().Length > 0) {
						if(Emp_idSource.Trim().Length > 0) {
							if(dtRole_Agent[i].Emp_id == Emp_idSource) {
								if(i + 1 < dtRole_Agent.Count) {
									MainDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtRole_Agent[i + 1].Emp_id);
									if(dtEmp_Target.Count > 0 && !(dtEmp_Target[0].isNeedAgent && DateTime.Now.Date >= dtEmp_Target[0].dateB && DateTime.Now.Date <= dtEmp_Target[0].dateE)) {
										Man = new CMan();
										Man.idRole = dtRole_Agent[i + 1].id;
										Man.idEmp = dtRole_Agent[i + 1].Emp_id;
										Man.agentType = AgentType.Other;
										isAgent = true;
									}
								}

								if(!isAgent) {
									for(int j = i - 1; j >= 0; j--) {
										MainDS.EmpDataTable dtEmp_Target = adEmp.GetDataById(dtRole_Agent[j].Emp_id);
										if(dtEmp_Target.Count > 0 && !(dtEmp_Target[0].isNeedAgent && DateTime.Now.Date >= dtEmp_Target[0].dateB && DateTime.Now.Date <= dtEmp_Target[0].dateE)) {
											Man = new CMan();
											Man.idRole = dtRole_Agent[j].id;
											Man.idEmp = dtRole_Agent[j].Emp_id;
											Man.agentType = AgentType.Other;
											isAgent = true;
											break;
										}
									}
								}
								break;
							}
						}
						else {
							Man = new CMan();
							Man.idRole = dtRole_Agent[i].id;
							Man.idEmp = dtRole_Agent[i].Emp_id;
							Man.agentType = AgentType.Other;
							isAgent = true;
							break;
						}
					}
				}
			}
			if(isAgent) return Man;
			else return null;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			if(MessageBox.Show("您確定要關閉服務嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				e.Cancel = false;
			else e.Cancel = true;
		}
	}
}