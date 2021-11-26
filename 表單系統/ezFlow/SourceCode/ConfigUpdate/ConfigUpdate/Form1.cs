using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace ConfigUpdate {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void bnUpdate_Click(object sender, EventArgs e) {
			DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
			FileInfo[] filesInfo = dirInfo.GetFiles("*.config", SearchOption.AllDirectories);
			foreach(FileInfo fileInfo in filesInfo) {
				if(File.Exists(fileInfo.FullName + ".bak")) File.Delete(fileInfo.FullName + ".bak");
				File.Move(fileInfo.FullName, fileInfo.FullName + ".bak");

				//Xml 讀取器
				XmlReader reader = XmlReader.Create(fileInfo.FullName + ".bak");

				//Xml 寫入設定
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				xmlWriterSettings.Indent = true;
				xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
				xmlWriterSettings.IndentChars = "   ";
				xmlWriterSettings.NewLineChars = "\r\n";
				xmlWriterSettings.NewLineHandling = NewLineHandling.None;
				xmlWriterSettings.NewLineOnAttributes = false;				

				//Xml 寫入器
				XmlWriter writer = XmlWriter.Create(fileInfo.FullName, xmlWriterSettings);

				writer.WriteStartDocument();	
			
				while(reader.Read()) {
					switch(reader.NodeType) {
						case XmlNodeType.Element:
							writer.WriteStartElement(reader.LocalName);							
							if(reader.HasAttributes) {
								while(reader.MoveToNextAttribute()) {
									if(reader.Name.ToLower() == "connectionstring") {
										string[] items = reader.Value.Split(new char[] { ';' });
										Hashtable cnItems = new Hashtable();
										foreach(string item in items) {
											string[] keyValue = item.Split(new char[] { '=' });
											if(keyValue.Length == 2) {
												if(keyValue[0].Trim().Length > 0) {
													string key = keyValue[0].Trim().ToLower();
													if(!cnItems.ContainsKey(key)) {
														if(keyValue[0].Trim().ToLower() == "user id") key = "uid";
														else if(keyValue[0].Trim().ToLower() == "password") key = "pwd";
														cnItems.Add(key, keyValue[1].Trim().ToLower());
													}
													if(key == "data source")
														cnItems[key] = txtSource.Text.Trim().ToLower();
													if (key == "initial catalog")
														cnItems[key] = txtDB.Text.Trim().ToLower();
													if(key == "uid")
														cnItems[key] = txtUid.Text.Trim().ToLower();
													if(key == "pwd")
														cnItems[key] = txtPwd.Text.Trim().ToLower();
												}
											}
										}
										if(!cnItems.ContainsKey("pwd")) cnItems.Add("pwd", txtPwd.Text.Trim().ToLower());
										string connectionString = "";
										foreach(object key in cnItems.Keys) {
											connectionString += key.ToString() + "=" + cnItems[key].ToString() + ";";
										}
										writer.WriteAttributeString(reader.Name, connectionString);
									}
									else writer.WriteAttributeString(reader.Name, reader.Value);									
								}
							}
							reader.MoveToElement();
							//if(reader.LocalName.Trim().ToLower() == "add") writer.WriteEndElement();							
							if(reader.IsEmptyElement) writer.WriteEndElement();
							break;
						case XmlNodeType.EndElement:
							writer.WriteFullEndElement();
							break;
					}
				}				
				writer.Close();
				reader.Close();
				if(!ckSubFolder.Checked) break;
			}

			if(ckDelBackup.Checked) {
				filesInfo = dirInfo.GetFiles("*.config.bak", SearchOption.AllDirectories);
				foreach(FileInfo fileInfo in filesInfo) {
					if(File.Exists(fileInfo.FullName)) File.Delete(fileInfo.FullName);
				}
			}

			MessageBox.Show("更新完成");
		}
	}
}