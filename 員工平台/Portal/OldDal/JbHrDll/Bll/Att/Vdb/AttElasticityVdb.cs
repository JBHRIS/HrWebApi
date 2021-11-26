using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class AttElasticityVdb
    {
       public List<AttElasticityRow> AttElasticityData { set; get; }
    }

    public class AttElasticityRow
    {
        public string Nobr { set; get; }
        public DateTime DateA { set; get; }
        public int Minutes { set; get; }
    }
}