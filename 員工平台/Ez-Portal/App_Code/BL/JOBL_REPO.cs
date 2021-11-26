﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;


namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class JOBL_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        public JOBL_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public JOBL_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<JOBL> GetAll()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.JOBL
                        select c).ToList();
            }
        }
    }
    

}