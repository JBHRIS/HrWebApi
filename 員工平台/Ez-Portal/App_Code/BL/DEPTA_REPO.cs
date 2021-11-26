using System;
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
    public class DEPTA_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public DEPTA_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public DEPTA_REPO()
        {
            dc = new JBHRModelDataContext();
        }


        public DEPTA GetByID(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DEPTA
                        where c.D_NO == id
                        select c).FirstOrDefault();
            }
        }

        public DEPTA GetByID(string id, List<DEPTA> list)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in list
                        where c.D_NO == id
                        select c).FirstOrDefault();
            }
        }

        public  List<DEPTA> GetChildByID(string id)
        {
            DateTime datetime = DateTime.Now.Date;
            return (from c in dc.DEPTA
                     where c.DEPT_GROUP == id
                     && c.ADATE <= datetime && c.DDATE>= datetime
                     select c).ToList();            
        }

        public TreeNode GetDeptaTreeNode(TreeNode node)
        {
            DEPTA_REPO depta_repo = new DEPTA_REPO();
            string id = node.Value;
            List<DEPTA> deptas = depta_repo.GetChildByID(id);

            foreach (DEPTA d in deptas)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = d.D_NAME;
                newNode.Value = d.D_NO;
                GetDeptaTreeNode(newNode);
                node.ChildNodes.Add(newNode);
            }
            return node;
        }

        public TreeNode GetDeptaTreeNode(TreeNode node, List<string> AaddedDeptList)
        {
            DEPTA_REPO depta_repo = new DEPTA_REPO();
            string id = node.Value;

            //已有新增過就不新增
            if (AaddedDeptList.Contains(id))
                return node;


            List<DEPTA> depts = depta_repo.GetChildByID(id);

            foreach (DEPTA d in depts)
            {
                //已有新增過就不新增
                if (AaddedDeptList.Contains(d.D_NO))
                    continue;

                TreeNode newNode = new TreeNode();
                newNode.Text = d.D_NAME;
                newNode.Value = d.D_NO;
                GetDeptaTreeNode(newNode, AaddedDeptList);
                node.ChildNodes.Add(newNode);
            }

            AaddedDeptList.Add(id);
            return node;
        }


        public List<DEPTA> GetByNobr(string id)
        {
            DateTime datetime = DateTime.Now.Date;
            return (from c in dc.DEPTA
                    where c.NOBR == id
                    && datetime >= c.ADATE.Value && datetime <= c.DDATE.Value
                    select c).ToList();
        }


        public List<DEPTA> GetRoot()
        {
            return (from c in dc.DEPTA
                    where c.DEPT_GROUP ==""
                    select c).ToList();
        }


        public List<DEPTA> GetAll()
        {
            return (from c in dc.DEPTA
                    select c).ToList();
        }

        public List<DEPTA> GetValidAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {                
                DateTime datetime = DateTime.Now.Date;
                return (from c in ldc.DEPTA
                        where (c.ADATE.HasValue && c.DDATE.HasValue)
                        && datetime>= c.ADATE.Value && datetime <= c.DDATE.Value
                        select c).ToList();
            }
        }
    }
}