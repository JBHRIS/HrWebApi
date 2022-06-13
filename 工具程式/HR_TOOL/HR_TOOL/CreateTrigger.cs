using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Deployment.Application;
using System.Configuration;
using System.Data.SqlClient;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.HSSF.Util;

namespace HR_TOOL
{
    public partial class CreateTrigger : Form
    {
        public CreateTrigger()
        {
            InitializeComponent();
            //this.conncetionString = conncetionString;

        }
        #region 宣告
        bool isCreate, isDelete, isError;
        string conncetionString, Server, DataBase, Id, Pwd, Dir, FileName, FullName, saveFullName, errorString;
        DataSet ds, save_ds;
        DataTable dt, save_dt;
        SqlConnection cn;
        HrDBDataContext db;
        IWorkbook workbook;
        ISheet sheet;
        int errorRow, errorCell, successNum;

        #endregion
        private void CreateTrigger_Load(object sender, EventArgs e)
        {
            //txtDB.Text = "CHPTHR";
            //txtDS.Text = "JB-VSTS";
            txtDB.Text = "";
            txtDS.Text = "";
            isCreate = false;
            isDelete = false;
            progressBar1.Visible = false;
            setConnection();
            db = new HrDBDataContext();
        }

        private void bnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                isCreate = true;
                runApp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                endApp();
            }
        }

        private void bnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("刪除後即無法恢復，確定刪除嗎？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    isDelete = true;
                    runApp();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                endApp();
            }
        }
        void readExcel()
        {
            //Dir = Directory.GetCurrentDirectory();
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            Dir = Directory.GetCurrentDirectory();

            FileName = "所有代碼的關聯表.xlsx";
            //FullName = Dir + @"\" + FileName;
            string createPath = @"C:\temp\HR_TOOL";
            string sysFullName = Dir + @"\Resources\" + FileName;
            FullName = @"C:\temp\HR_TOOL\" + FileName;
            CopyFile(sysFullName, FullName, createPath);
            if (!File.Exists(FullName))
            {
                MessageBox.Show(string.Format("找不到檔案({0})", FullName));
                return;
            }
            ds = new DataSet();
            dt = new DataTable();
            ds = JBModule.Data.CNPOI.ReadExcelToDataSet(FullName, JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn);
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i != 0 && dt.Rows[i][0] == "") dt.Rows[i][0] = dt.Rows[i - 1][0];
            }
        }

        void setConnection()
        {
            HrDBDataContext db = new HrDBDataContext();
            cn = new SqlConnection();
            cn.ConnectionString = db.Connection.ConnectionString;
            conncetionString = cn.ConnectionString;
            Server = txtDS.Text;
            DataBase = txtDB.Text;
            try
            {
                //#region 讀取JBHR的connectionString
                //string conn = "";
                //try
                //{
                //    //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //    string strPath = @"temp\App.Config";
                //    bool isFound = false;
                //    string[] drives = Directory.GetLogicalDrives();
                //    foreach (string drive in drives)
                //    {
                //        if (File.Exists(drive + strPath))
                //        {
                //            StreamReader sr = File.OpenText(drive + strPath);
                //            string readStr = sr.ReadToEnd();
                //            sr.Close();
                //            string[] pp = readStr.Split(new string[] { "connectionString=\"", "\" />" }, StringSplitOptions.RemoveEmptyEntries);

                //            foreach (var item in pp)
                //            {
                //                if (item.Substring(0, 12) == "Data Source=")
                //                {
                //                    conn = JBModule.Data.CDecryp.ConnectString(item);
                //                    isFound = true;
                //                    break;
                //                }
                //            }
                //            break;
                //        }
                //    }
                //    if (isFound)
                //    {
                //        this.conncetionString = conn;
                //    }
                //    else
                //    {
                //        MessageBox.Show("找不到相關程式連線字串");
                //        return;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("找不到相關程式連線字串");
                //    return;
                //}

                //#endregion
                //#region 讀取dotNet的connectionString
                //if (conn.Length == 0)
                //{
                //    try
                //    {
                //        //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //        bool isFound = false;
                //        string[] drives = Directory.GetLogicalDrives();
                //        foreach (string drive in drives)
                //        {
                //            if (File.Exists(drive + "JBHR.CONNECTION.STR"))
                //            {
                //                StreamReader sr = File.OpenText(drive + "JBHR.CONNECTION.STR");
                //                string readStr = JBModule.Data.CDecryp.Text(sr.ReadLine());
                //                sr.Close();
                //                string[] pp = readStr.Split(new string[] { "[=]" }, StringSplitOptions.RemoveEmptyEntries);
                //                if (pp.Length == 2)
                //                {
                //                    conn = pp[1];
                //                    isFound = true;
                //                    break;
                //                }
                //            }
                //        }
                //        if (!isFound)
                //        {
                //            foreach (string drive in drives)
                //            {
                //                if (!File.Exists(drive + "JBHR.CONNECTION.STR"))
                //                {
                //                    try
                //                    {
                //                        File.Copy(Directory.GetCurrentDirectory() + "JBHR.CONNECTION.STR", drive + "JBHR.CONNECTION.STR");
                //                    }
                //                    catch (Exception ex)
                //                    {
                //                        continue;
                //                    }

                //                    StreamReader sr = File.OpenText(drive + "JBHR.CONNECTION.STR");
                //                    string readStr = JBModule.Data.CDecryp.Text(sr.ReadLine());
                //                    sr.Close();
                //                    string[] pp = readStr.Split(new string[] { "[=]" }, StringSplitOptions.RemoveEmptyEntries);
                //                    if (pp.Length == 2)
                //                    {
                //                        conn = pp[1];
                //                        isFound = true;
                //                        break;
                //                    }
                //                }
                //            }
                //        }
                //        if (isFound)
                //        {
                            
                //        }
                //        else
                //        {
                //            MessageBox.Show("找不到相關程式連線字串");
                //            return;
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("找不到相關程式連線字串");
                //        return;
                //    }
                //}
                //#endregion
                //if (txtDB.Text != "" && txtDS.Text != "")
                //{
                //    //cn.ConnectionString = JBModule.Data.CDecryp.ConnectString(ConfigurationManager.ConnectionStrings["恆勁科技"].ConnectionString.ToString());
                //    cn.ConnectionString = "Data Source=" + Server + ";Initial Catalog=" + DataBase + ";Persist Security Info=True;User ID=jb;Password=JB8421";
                //    if (cn.State == System.Data.ConnectionState.Closed) cn.Open();
                //}
                if (conncetionString.Length != 0)
                {

                    cn.ConnectionString = conncetionString;
                    if (cn.State == System.Data.ConnectionState.Closed)
                    {
                        cn.Open();
                        cn.Close();
                    }
                    txtDS.Text = cn.DataSource;
                    txtDB.Text = cn.Database;
                    Server = cn.DataSource;
                    DataBase = cn.Database;
                }
                else
                {
                    MessageBox.Show("無連線資訊！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("連線資訊錯誤！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }


        void deleteTrigger(DataRow it, object[] ob)
        {
            try
            {
                if (ckDelete.Checked)
                {
                    string firstUp = it[2].ToString().Substring(0, 1).ToUpper() + it[2].ToString().Substring(1).ToLower();

                    string DeleteCode = "";
                    DeleteCode += "IF EXISTS (SELECT * FROM sysobjects WHERE xtype='TR' AND name='trg_" + firstUp + "_Delete')";
                    DeleteCode += "\n" + "DROP TRIGGER trg_" + firstUp + "_Delete";
                    db.ExecuteCommand(DeleteCode, ob);


                }
                if (ckUpdate.Checked)
                {
                    string firstUp = it[2].ToString().Substring(0, 1).ToUpper() + it[2].ToString().Substring(1).ToLower();
                    string UpdateCode = "";
                    UpdateCode += "IF EXISTS (SELECT * FROM sysobjects WHERE xtype='TR' AND name='trg_" + firstUp + "_Update')";
                    UpdateCode += "\n" + "DROP TRIGGER trg_" + firstUp + "_Update";
                    db.ExecuteCommand(UpdateCode, ob);
                }
            }
            catch
            {

            }
        }

        void createTrigger(DataRow it, object[] ob)
        {
            try
            {
                if (ckDelete.Checked)
                {
                    string firstUp = it[2].ToString().Substring(0, 1).ToUpper() + it[2].ToString().Substring(1).ToLower();

                    string DeleteCode = "";

                    DeleteCode += "select 1 from information_schema.tables WHERE TABLE_TYPE='BASE TABLE' and table_name = '{2}'";
                    string sqlcmd = string.Format(DeleteCode, ob);
                    if (db.ExecuteQuery<DbType>(sqlcmd).Any())
                    {
                        DeleteCode = "";
                        DeleteCode += "Create Trigger dbo.trg_" + firstUp + "_Delete on {2}";
                        //DeleteCode += "\n" + "Create Trigger dbo.trg_Awordcd_Delete on AWORDCD";
                        DeleteCode += "\n" + "after delete";
                        DeleteCode += "\n" + "as";
                        DeleteCode += "\n" + "declare @{2} nvarchar(50)";
                        DeleteCode += "\n" + "declare @back bit";
                        DeleteCode += "\n" + "select @{2}={3} from deleted";
                        int index = 4;//關聯表的起始位置
                        while (index < it.ItemArray.Count() && it[index] != "")
                        {
                            int code = index + 1;
                            string[] pp = it[code].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            DeleteCode += "\n" + "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = '{" + index + "}')";
                            DeleteCode += "\n" + "BEGIN";
                            DeleteCode += "\n" + "if(exists(select 1 from {" + index + "} where ";
                            for (int j = 0; j < pp.Count(); j++)
                            {
                                if (j != 0) DeleteCode += " or ";
                                DeleteCode += pp[j] + "=@{2}";
                            }
                            DeleteCode += "))";
                            DeleteCode += "\n" + "BEGIN";
                            DeleteCode += "\n" + "RAISERROR('使用中的{1}不可刪除({" + index + "})',16,10)";
                            DeleteCode += "\n" + "set @back = 1";
                            DeleteCode += "\n" + "END";
                            DeleteCode += "\n" + "END";

                            index += 2;
                        }
                        DeleteCode += "\n" + "if(@back = 1)";
                        DeleteCode += "\n" + "BEGIN";
                        DeleteCode += "\n" + "ROLLBACK";
                        DeleteCode += "\n" + "END";
                        string sqlcmd2 = string.Format(DeleteCode, ob);
                        db.ExecuteCommand(sqlcmd2);
                    }

                }
                if (ckUpdate.Checked)
                {


                    string firstUp = it[2].ToString().Substring(0, 1).ToUpper() + it[2].ToString().Substring(1).ToLower();
                    string UpdateCode = "";
                    UpdateCode += "select 1 from information_schema.tables WHERE TABLE_TYPE='BASE TABLE' and table_name = '{2}'";
                    string sqlcmd = string.Format(UpdateCode, ob);
                    if (db.ExecuteQuery<DbType>(sqlcmd).Any())
                    {
                        UpdateCode = "";
                        UpdateCode += "Create TRIGGER dbo.trg_" + firstUp + "_Update on {2}";
                        UpdateCode += "\n" + "after UPDATE";
                        UpdateCode += "\n" + "as";
                        UpdateCode += "\n" + "declare @{2} nvarchar(50)";
                        UpdateCode += "\n" + "declare @{2}1 nvarchar(50)";
                        UpdateCode += "\n" + "declare @back bit";
                        UpdateCode += "\n" + "select @{2}={3} from deleted";
                        UpdateCode += "\n" + "select @{2}1={3} from inserted";
                        UpdateCode += "\n" + "if(@{2}!=@{2}1)";
                        UpdateCode += "\n" + "begin";
                        int index = 4;//關聯表的起始位置
                        while (index < it.ItemArray.Count() && it[index] != "")
                        {
                            int code = index + 1;
                            string[] pp = it[code].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            UpdateCode += "\n" + "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = '{" + index + "}')";
                            UpdateCode += "\n" + "BEGIN";
                            UpdateCode += "\n" + "if(exists(select 1 from {" + index + "} where ";
                            for (int j = 0; j < pp.Count(); j++)
                            {
                                if (j != 0) UpdateCode += " or ";
                                UpdateCode += pp[j] + "=@{2}";
                            }
                            UpdateCode += "))";
                            UpdateCode += "\n" + "BEGIN";
                            UpdateCode += "\n" + "RAISERROR('使用中的{1}不可修改({" + index + "})',16,10)";
                            UpdateCode += "\n" + "set @back = 1";
                            UpdateCode += "\n" + "END";
                            UpdateCode += "\n" + "END";
                            index += 2;
                        }
                        UpdateCode += "\n" + "if(@back = 1)";
                        UpdateCode += "\n" + "BEGIN";
                        UpdateCode += "\n" + "ROLLBACK";
                        UpdateCode += "\n" + "END";
                        UpdateCode += "\n" + "end";
                        string sqlcmd2 = string.Format(UpdateCode, ob);
                        db.ExecuteCommand(sqlcmd2);
                    }
                }
                successNum++;
            }
            catch (Exception ex)
            {
                isError = true;
                sheet.CreateRow(errorRow);
                for (int i = 0; i < it.ItemArray.Count(); i++)
                {
                    sheet.GetRow(errorRow).CreateCell(i).SetCellValue(it[i].ToString());
                }
                sheet.GetRow(errorRow).CreateCell(errorCell).SetCellValue(ex.Message);
                errorRow++;
            }
        }

        void endApp()
        {
            try
            {
                cn.Close();
                isCreate = false;
                isDelete = false;
                progressBar1.Visible = false;
            }
            catch { }
        }

        void runApp()
        {
            
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = 1;
            StatusMsg.Text = "準備資料中...";
            this.Refresh();
            if (!ckDelete.Checked && !ckUpdate.Checked)
            {
                MessageBox.Show("尚未勾選執行項目");
                return;
            }
            if (cn.State == ConnectionState.Closed) cn.Open();
            readExcel();
            progressBar1.Maximum = dt.Rows.Count;
            setErrorToExcel();
            successNum = 0;
            foreach (DataRow it in dt.Rows)
            {
                progressBar1.Value++;
                StatusMsg.Text = "處理：" + it[1].ToString() + "...";
                this.Refresh();
                object[] ob = new object[it.ItemArray.Count()];
                for (int i = 0; i < ob.Length; i++)
                {
                    ob[i] = it[i];
                }
                if (isCreate || isDelete)
                    deleteTrigger(it, ob);
                if (isCreate)
                    createTrigger(it, ob);
            }

            if (isError)
            {
                isError = false;
                for (int i = 0; i <= errorCell; i++)
                {
                    sheet.AutoSizeColumn(i);
                }

                string path = @"C:\temp\" + "Trigger建置 (" + DateTime.Now.Date.ToString("yyyy_MM_dd") + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ").xls";
                FileStream file = new FileStream(path, System.IO.FileMode.Create);
                workbook.Write(file);
                file.Close();
                MessageBox.Show("已將錯誤訊息存放在：" + path + "中。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            progressBar1.PerformStep();
            StatusMsg.Text = "處理完畢";
            this.Refresh();
            if (isCreate)
            {
                customerManager();
                MessageBox.Show("Trigger建置成功:" + successNum + ", 失敗:" + (errorRow - 1) + ".");
            }
            if (isDelete)
                MessageBox.Show("所有Trigger刪除完畢");
        }

        void setErrorToExcel()
        {
            isError = false;
            errorRow = 1;
            errorCell = dt.Rows[0].ItemArray.Count();
            workbook = new HSSFWorkbook();
            sheet = workbook.CreateSheet();
            sheet.CreateRow(0);
            for (int i = 0; i < dt.Rows[0].ItemArray.Count(); i++)
            {
                sheet.GetRow(0).CreateCell(i).SetCellValue(dt.Rows[0][i].ToString());
            }
            sheet.GetRow(0).CreateCell(errorCell).SetCellValue("錯誤訊息");
        }

        void customerManager()
        {
            bool delete_Ok = false;
            bool update_Ok = false;
            Dir = Directory.GetCurrentDirectory();
            FileName = "已處理的客戶.xls";
            string createPath = @"C:\temp\HR_TOOL";
            string sysFullName = Dir + @"\Resources\" + FileName;
            FullName = @"C:\temp\HR_TOOL\" + FileName;
            CopyFile(sysFullName, FullName, createPath);
            if (!File.Exists(FullName)) return;
            //saveFullName = Directory.GetParent(Directory.GetParent(Dir).ToString()).ToString() + @"\" + FileName;
            saveFullName = FullName;
            save_ds = new DataSet();
            save_dt = new DataTable();
            save_ds = JBModule.Data.CNPOI.ReadExcelToDataSet(FullName, JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn);
            save_dt = save_ds.Tables[0];
            foreach (DataRow it in save_dt.Rows)
            {
                if (!delete_Ok)
                {
                    if (ckDelete.Checked)
                    {
                        if (it[0].ToString() == DataBase && it[1].ToString() == "Delete_trigger")
                        {
                            it[2] = successNum;
                            it[3] = errorRow - 1;
                            it[4] = DateTime.Now;
                            delete_Ok = true;
                        }
                    }
                    else
                    {
                        delete_Ok = true;
                    }
                }
                if (!update_Ok)
                {
                    if (ckUpdate.Checked)
                    {
                        if (it[0].ToString() == DataBase && it[1].ToString() == "Update_trigger")
                        {
                            it[2] = successNum;
                            it[3] = errorRow - 1;
                            it[4] = DateTime.Now;
                            update_Ok = true;
                        }
                    }
                    else
                    {
                        update_Ok = true;
                    }
                }
                if (delete_Ok && update_Ok) break;
            }
            if (!delete_Ok)
            {
                DataRow dr = save_dt.NewRow();
                dr[0] = DataBase;
                dr[1] = "Delete_trigger";
                dr[2] = successNum;
                dr[3] = errorRow - 1;
                dr[4] = DateTime.Now;
                save_dt.Rows.Add(dr);
            }
            if (!update_Ok)
            {
                DataRow dr = save_dt.NewRow();
                dr[0] = DataBase;
                dr[1] = "Update_trigger";
                dr[2] = successNum;
                dr[3] = errorRow - 1;
                dr[4] = DateTime.Now;
                save_dt.Rows.Add(dr);
            }
            DataTable tempDT = save_dt.Copy();
            save_dt.Clear();
            foreach (DataRow dr in tempDT.Select("1=1", "建立時間 asc"))
            {
                save_dt.ImportRow(dr);
            }
            save_ds.AcceptChanges();

            if (File.Exists(FullName)) JBModule.Data.CNPOI.SaveDataSetToExcel(save_ds, FullName);
            if (File.Exists(saveFullName)) JBModule.Data.CNPOI.SaveDataSetToExcel(save_ds, saveFullName);
        }
        void CopyFile(string fromPath, string toPath, string createPath)
        {
            if (File.Exists(toPath)) return;
            if (!File.Exists(fromPath)) return;
            if (!File.Exists(createPath)) System.IO.Directory.CreateDirectory(createPath);
            File.Copy(fromPath, toPath, true);
        }
    }
}
