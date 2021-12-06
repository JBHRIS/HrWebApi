using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;

namespace ezEngineServices
{
    public class CImage
    {
        private dcFlowDataContext dcFlow;
        private string _ConnectionString;

        public CImage()
        {
            dcFlow = new dcFlowDataContext();
            _ConnectionString = dcFlow.Connection.ConnectionString;
        }

        /// <summary>
        /// CImage
        /// </summary>
        /// <param name="conn"></param>
        public CImage(IDbConnection conn)
        {
            _ConnectionString = conn.ConnectionString;
            dcFlow = new dcFlowDataContext(conn);
        }

        /// <summary>
        /// CData
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CImage(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            dcFlow = new dcFlowDataContext(ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public CImage(dcFlowDataContext dcFlow)
        {
            _ConnectionString = dcFlow.Connection.ConnectionString;
            this.dcFlow = dcFlow;
        }

        /// <summary>
        /// 取得流程圖
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns>Image</returns>
        public Image FlowImage(int idProcess)
        {
            CData oCData = new CData(dcFlow);

            Image oImage = null;

            List<int> lsProcess = new List<int>();
            lsProcess.Add(idProcess);

            var rProcessData = oCData.GetProcessData(lsProcess).FirstOrDefault();

            if (rProcessData != null)
            {
                oImage = new Bitmap(550, 3 * 60);
                Graphics g = Graphics.FromImage(oImage);
                Bitmap imgNode;
                int x = 50, y = 10;

                if (rProcessData.lsProcessSignRow != null)
                {
                    oImage = new Bitmap(550, (rProcessData.lsProcessSignRow.Count + 3) * 60);
                    g.Clear(Color.White);

                    g.DrawString("◎" + rProcessData.FlowTreeName + "◎", new Font("細明體", 12, FontStyle.Bold), new SolidBrush(Color.Green), x - 5, y);

                    y += 30;

                    imgNode = new Bitmap(rProcessData.ProcessNodeFormImg);
                    g.DrawImage(imgNode, x, y);

                    string dateStr = rProcessData.ProcessEmpName + " 於 " + rProcessData.DateTimeA.ToString("yyyy-MM-dd HH:mm") + " 完成表單填寫並送出";
                    g.DrawString(dateStr, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Black), x + 36, y + 8);

                    y += 60;

                    foreach (var rProcessSignRow in rProcessData.lsProcessSignRow.OrderBy(p => p.ProcessNodeDate).ToList())
                    {
                        DrawLineWithCap(g, new Point(x + 16, y - 60 + 32), new Point(x + 16, y));

                        imgNode = rProcessSignRow.ProcessNodeImg;

                        string actionStr = "";
                        switch (rProcessSignRow.ProcessNodeType)
                        {
                            case "3":
                                actionStr = "審核";
                                break;
                            case "4":
                                actionStr = "確認";
                                break;
                            case "5":
                                actionStr = "處理";
                                break;
                            case "6":
                                actionStr = "處理";
                                break;
                            case "7":
                                actionStr = "處理";
                                break;
                            case "8":
                                actionStr = "確認";
                                break;
                            case "9":
                                g.DrawString("進行會簽流程", new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Blue), x + 36, y + 8);
                                break;
                        }

                        g.DrawImage(imgNode, x, y);

                        dateStr = "";
                        if (rProcessSignRow.ProcessNodeFinish)
                        {
                            dateStr = "(" + rProcessSignRow.ProcessNodeName + ") " + rProcessSignRow.Emp_NameReal + " 於 " + rProcessSignRow.ProcessCheckDate.ToString("yyyy-MM-dd HH:mm") + " 完成" + actionStr;
                            g.DrawString(dateStr, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Blue), x + 36, y + 8);
                        }
                        else
                        {
                            dateStr = "(" + rProcessSignRow.ProcessNodeName + ") 目前表單等待 " + rProcessSignRow.Emp_NameDefault + " " + actionStr;
                            g.DrawString(dateStr, new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Red), x + 36, y + 8);
                        }

                        y += 60;
                    }
                }

                if (rProcessData.ProcessFinish)
                {
                    DrawLineWithCap(g, new Point(x + 16, y - 60 + 32), new Point(x + 16, y));
                    imgNode = new Bitmap(rProcessData.ProcessNodeFlowEndImg);
                    g.DrawImage(imgNode, x, y);
                    g.DrawString("流程結束", new Font("細明體", 10, FontStyle.Bold), new SolidBrush(Color.Black), x + 36, y + 8);
                }
            }

            return oImage;
        }

        /// <summary>
        /// 取得流程圖
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="x">水平起始位置</param>
        /// <param name="y">垂直起始位置</param>
        /// <param name="iWidth">圖片寬度</param>
        /// <param name="iHeight">圖片高度</param>
        /// <param name="bHeader">是否要表頭</param>
        /// <returns>Image</returns>
        public Image FlowImage(int idProcess, int x = 0, int y = 0, int iWidth = 600, int iHeight = 0, bool bHeader = true)
        {
            CData oCData = new CData(dcFlow);

            DateTime dDateDefault = new DateTime(1900, 1, 1).Date;

            Image oImage = null;

            List<int> lsProcess = new List<int>();
            lsProcess.Add(idProcess);

            var rProcessData = oCData.GetProcessData(lsProcess).FirstOrDefault();

            if (rProcessData != null)
            {
                if (iHeight == 0)
                {
                    iHeight = 3 * 22;

                    if (rProcessData.lsProcessSignRow != null)
                    {
                        iHeight = (rProcessData.lsProcessSignRow.Count + 3) * 22;
                        foreach (var rProcessSignRow in rProcessData.lsProcessSignRow.OrderBy(p => p.ProcessNodeDate).ToList())
                            if (rProcessSignRow.ProcessNodeType == "9")
                                foreach (var rProcessDataRow in rProcessSignRow.lsProcessDataRow)
                                    iHeight = iHeight + ((rProcessDataRow.lsProcessSignRow.Count + 3) * 22);
                    }
                }

                //int iHeight = (rProcessData.lsProcessSignRow.Count + 3) * 30;
                oImage = new Bitmap(iWidth, iHeight);
                Graphics g = Graphics.FromImage(oImage);
                g.Clear(Color.White);

                int iNo = 1;
                int iImageSize = 15;    //圖片大小

                Bitmap imgNode;

                Font fHeader = new Font("Times New Roman", 12, FontStyle.Bold);
                Font fRow = new Font("Times New Roman", 10);
                Font fFooter = new Font("Times New Roman", 10, FontStyle.Bold);

                SolidBrush sbRowBlack = new SolidBrush(Color.Black);
                SolidBrush sbRowBlue = new SolidBrush(Color.Blue);
                SolidBrush sbRowRed = new SolidBrush(Color.Red);

                Pen pLine = new Pen(Color.Black, 2);

                //六個欄位開始點
                int xNo = x + 0, xNodeImage = x + 20, xNode = x + 40, xReviewer = x + 150, xInitDate = x + 300, xReceiveDate = x + 450, xReceiveDateResult = x + 600;

                if (bHeader)
                {
                    //表頭
                    g.DrawString("No.", fHeader, sbRowBlack, xNo, y);
                    g.DrawString("Node", fHeader, sbRowBlack, xNode, y);
                    g.DrawString("Reviewer", fHeader, sbRowBlack, xReviewer, y);
                    g.DrawString("Init Date", fHeader, sbRowBlack, xInitDate, y);
                    g.DrawString("Receive Date", fHeader, sbRowBlack, xReceiveDate, y);
                    //g.DrawString("Note", fHeader, sbRowBlack, xReceiveDateResult, y);

                    y += 20;
                }
                else
                    y += 10;

                g.DrawLine(pLine, x, y, iWidth, y); //畫線

                y += 5;

                g.DrawString(iNo.ToString().PadLeft(2, '0') + ".", fRow, sbRowBlack, xNo, y);
                imgNode = new Bitmap(rProcessData.ProcessNodeFormImg, iImageSize, iImageSize);
                g.DrawImage(imgNode, xNodeImage, y);
                g.DrawString(rProcessData.ProcessNodeFormName, fRow, sbRowBlack, xNode, y); //流程開始的字樣
                g.DrawString(rProcessData.ProcessEmpName, fRow, sbRowBlack, xReviewer, y);
                g.DrawString(dDateDefault == rProcessData.DateTimeA.Date ? "" : rProcessData.DateTimeA.ToString("yyyy-MM-dd HH:mm"), fRow, sbRowBlack, xInitDate, y);
                //g.DrawString("Receive Date", fRow, sbRowBlack, xReceiveDate, y);
                //g.DrawString("Receive Date Result", fRow, sbRowBlack, xReceiveDateResult, y);

                y += 20;
                iNo++;

                if (rProcessData.lsProcessSignRow != null)
                {
                    foreach (var rProcessSignRow in rProcessData.lsProcessSignRow.OrderBy(p => p.ProcessNodeDate).ToList())
                    {
                        SolidBrush sbRow = rProcessSignRow.ProcessNodeFinish ? sbRowBlue : sbRowRed;

                        g.DrawString(iNo.ToString().PadLeft(2, '0') + ".", fRow, sbRow, xNo, y);
                        imgNode = new Bitmap(rProcessSignRow.ProcessNodeImg, iImageSize, iImageSize);
                        g.DrawImage(imgNode, xNodeImage, y);
                        g.DrawString(rProcessSignRow.ProcessNodeName, fRow, sbRow, xNode, y);
                        g.DrawString(rProcessSignRow.Emp_NameDefault, fRow, sbRow, xReviewer, y);
                        g.DrawString(dDateDefault == rProcessSignRow.ProcessNodeDate.Date ? "" : rProcessSignRow.ProcessNodeDate.ToString("yyyy-MM-dd HH:mm"), fRow, sbRow, xInitDate, y);
                        g.DrawString(dDateDefault == rProcessSignRow.ProcessCheckDate.Date ? "" : rProcessSignRow.ProcessCheckDate.ToString("yyyy-MM-dd HH:mm"), fRow, sbRow, xReceiveDate, y);
                        //g.DrawString(rProcessSignRow.Emp_NameReal, fRow, sbRow, xReceiveDateResult, y);

                        y += 20;

                        iNo++;

                        //會簽再加入
                        if (rProcessSignRow.ProcessNodeType == "9")
                        {
                            int h = 0;
                            foreach (var rProcessDataRow in rProcessSignRow.lsProcessDataRow)
                            {
                                //iHeight = (rProcessDataRow.lsProcessSignRow.Count + 3) * 20;

                                Image img = FlowImage(rProcessDataRow.idProcess, 0, 0, iWidth - 20, 0, h == 0);
                                g.DrawImage(img, x + 20, y);

                                y = y + img.Height;

                                h++;
                            }
                        }
                    }
                }

                if (rProcessData.ProcessFinish)
                {
                    g.DrawLine(pLine, x, y, iWidth, y); //畫線

                    y += 5;

                    //g.DrawString(iNo.ToString().PadLeft(2, '0'), fFooter, sbRowBlack, xNo, y);
                    imgNode = new Bitmap(rProcessData.ProcessNodeFlowEndImg, iImageSize, iImageSize);
                    g.DrawImage(imgNode, xNodeImage, y);
                    g.DrawString(rProcessData.ProcessNodeFlowEndName, fFooter, sbRowBlack, xNode, y);   //流程結束的字樣
                    //g.DrawString(rProcessSignRow.Emp_NameDefault, fFooter, sbRowBlack, xReviewer, y);
                    //g.DrawString(rProcessSignRow.ProcessNodeDate.ToString("yyyy-MM-dd HH:mm"), fFooter, sbRowBlack, xInitDate, y);
                    //g.DrawString(rProcessData.DateTimeD.ToString("yyyy-MM-dd HH:mm"), fFooter, sbRowBlack, xReceiveDate, y);
                    //g.DrawString(rProcessSignRow.Emp_NameReal, fRow, sbRowBlack, xReceiveDateResult, y);
                }
            }

            return oImage;
        }

        /// <summary>
        /// 畫線
        /// </summary>
        /// <param name="g"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void DrawLineWithCap(Graphics g, Point start, Point end)
        {
            GraphicsPath hPath = new GraphicsPath();
            hPath.AddLine(new Point(0, -3), new Point(2, -8));
            hPath.AddLine(new Point(0, -6), new Point(2, -8));
            hPath.AddLine(new Point(0, -3), new Point(-2, -8));
            hPath.AddLine(new Point(0, -6), new Point(-2, -8));
            CustomLineCap HookCap = new CustomLineCap(null, hPath);
            Pen customCapPen = new Pen(Color.Gold, 2);
            customCapPen.CustomEndCap = HookCap;
            g.DrawLine(customCapPen, start, end);
        }

        /// <summary>
        /// 將 Image 轉換為 Byte 陣列。
        /// </summary>
        /// <param name="image">Image 。</param>
        /// <param name="imageFormat">指定影像格式。</param>        
        public static byte[] ImageToBuffer(Image image, ImageFormat imageFormat)
        {
            if (image == null) { return null; }
            byte[] data = null;
            using (MemoryStream oMemoryStream = new MemoryStream())
            {
                //建立副本
                using (Bitmap oBitmap = new Bitmap(image))
                {
                    //儲存圖片到 MemoryStream 物件，並且指定儲存影像之格式
                    oBitmap.Save(oMemoryStream, imageFormat);
                    //設定資料流位置
                    oMemoryStream.Position = 0;
                    //設定 buffer 長度
                    data = new byte[oMemoryStream.Length];
                    //將資料寫入 buffer
                    oMemoryStream.Read(data, 0, Convert.ToInt32(oMemoryStream.Length));
                    //將所有緩衝區的資料寫入資料流
                    oMemoryStream.Flush();
                }
            }
            return data;
        }

        /// <summary>
        /// 將 Byte 陣列轉換為 Image。
        /// </summary>
        /// <param name="Buffer">Byte 陣列。</param>        
        public static Image BufferToImage(byte[] Buffer)
        {
            if (Buffer == null || Buffer.Length == 0) { return null; }
            byte[] data = null;
            Image oImage = null;
            Bitmap oBitmap = null;
            //建立副本
            data = (byte[])Buffer.Clone();
            try
            {
                MemoryStream oMemoryStream = new MemoryStream(Buffer);
                //設定資料流位置
                oMemoryStream.Position = 0;
                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                //建立副本
                oBitmap = new Bitmap(oImage);
            }
            catch
            {
                throw;
            }
            //return oImage;
            return oBitmap;
        }
    }
}