using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Performance.Scripts
{
    public class CallJavaScript: System.Web.UI.Page
    {
        public string ScriptPerformanceBaseRowCellsSumTotalIntegrateTextChanged
        {
            get
            {
                var Script = "";
                if (ViewState["ScriptJuniorSalaryEduTypeEduTypeModeSelectedIndexChanged"] == null)
                {
                    try
                    {
                        FileStream fs = new FileStream(Server.MapPath("Scripts/ScriptPerformanceBaseRowCellsSumTotalIntegrateTextChanged.js"), FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("big5"));
                        Script = sr.ReadToEnd();
                        sr.Close();
                        fs.Close();
                    }
                    catch { }

                    ViewState["ScriptPerformanceBaseRowCellsSumTotalIntegrateTextChanged"] = Script;
                }
                else
                    Script = ViewState["ScriptPerformanceBaseRowCellsSumTotalIntegrateTextChanged"].ToString();

                return Script;
            }
        }

        public string ScriptPerformanceBaseRowCellsSumBonusRealTextChanged
        {
            get
            {
                var Script = "";
                if (ViewState["ScriptPerformanceBaseRowCellsSumBonusRealTextChanged"] == null)
                {
                    try
                    {
                        FileStream fs = new FileStream(Server.MapPath("Scripts/ScriptPerformanceBaseRowCellsSumBonusRealTextChanged.js"), FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("big5"));
                        Script = sr.ReadToEnd();
                        sr.Close();
                        fs.Close();
                    }
                    catch { }

                    ViewState["ScriptPerformanceBaseRowCellsSumBonusRealTextChanged"] = Script;
                }
                else
                    Script = ViewState["ScriptPerformanceBaseRowCellsSumBonusRealTextChanged"].ToString();

                return Script;
            }
        }

        public string ScriptPerformanceBaseRatingSelectedItem
        {
            get
            {
                var Script = "";
                if (ViewState["ScriptPerformanceBaseRatingSelectedItem"] == null)
                {
                    try
                    {
                        FileStream fs = new FileStream(Server.MapPath("Scripts/ScriptPerformanceBaseRatingSelectedItem.js"), FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("big5"));
                        Script = sr.ReadToEnd();
                        sr.Close();
                        fs.Close();
                    }
                    catch { }

                    ViewState["ScriptPerformanceBaseRatingSelectedItem"] = Script;
                }
                else
                    Script = ViewState["ScriptPerformanceBaseRatingSelectedItem"].ToString();

                return Script;
            }
        }

        public string ScriptPerformanceBaseRatingSelectedIndexChanged
        {
            get
            {
                var Script = "";
                if (ViewState["ScriptPerformanceBaseRatingSelectedIndexChanged"] == null)
                {
                    try
                    {
                        FileStream fs = new FileStream(Server.MapPath("Scripts/ScriptPerformanceBaseRatingSelectedIndexChanged.js"), FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("big5"));
                        Script = sr.ReadToEnd();
                        sr.Close();
                        fs.Close();
                    }
                    catch { }

                    ViewState["ScriptPerformanceBaseRatingSelectedIndexChanged"] = Script;
                }
                else
                    Script = ViewState["ScriptPerformanceBaseRatingSelectedIndexChanged"].ToString();

                return Script;
            }
        }
    }
}