using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JBHR
{
    public class Pseudocode
    {
        string codeName = "";
        string dir = "";
        FileStream fs;
        StreamWriter sw;
        List<int> loopList;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodeName">虛擬碼名稱，也是虛擬碼檔案檔名</param>
        public Pseudocode(string CodeName)
        {
            this.codeName = CodeName;
            Delete();
            fs = new FileStream(FullName, FileMode.CreateNew);
            sw = new StreamWriter(fs);
            loopList = new List<int>();
        }

        public void Write(string comment)
        {
            sw.WriteLine(comment);
        }
        public void Write(string comment,int loop)
        {
            if (loopList.Contains(loop)) return;//如果代碼已存在，代表是迴圈
            loopList.Add(loop);
            sw.WriteLine(comment);
        }
        public void Finish()
        {
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        public string Dir
        {
            get
            {
                if (dir.Trim().Length > 0) return dir;
                else return Directory.GetCurrentDirectory();
            }
            set
            {
                dir = value;
            }
        }
        public string FullName
        {
            get { return Dir + @"\" + codeName + ".txt"; }
        }
        void Delete()
        {
            if (File.Exists(FullName)) File.Delete(FullName);
        }
    }
}
