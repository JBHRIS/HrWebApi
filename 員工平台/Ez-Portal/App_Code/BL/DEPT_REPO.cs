using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;
using System.Data.Linq;
using Telerik.Web.UI;


namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class DEPT_REPO
    {
        private static readonly Object syncObj = new Object();
        public const string CacheName = "DEPT_RepoCache";
        public JBHRModelDataContext dc { get; set; }
        public DEPT_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public DEPT_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public DEPT GetByID(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DEPT
                        where c.D_NO == id
                        select c).FirstOrDefault();
            }
        }

        public DEPT GetByID(string id,List<DEPT> list)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                var a= (from c in list
                        where c.D_NO == id
                        select c).FirstOrDefault();
                return a;
            }
        }

        public  List<DEPT> GetChildByID(string id)
        {
            DateTime datetime = DateTime.Now.Date;

            return (from c in dc.DEPT
                     where c.DEPT_GROUP == id
                     && c.ADATE<=datetime && c.DDATE >= datetime
                     select c).ToList();            
        }

        public TreeNode GetDeptTreeNode(TreeNode node)
        {
            DEPT_REPO dept_repo = new DEPT_REPO();
            string id = node.Value;
            List<DEPT> depts = dept_repo.GetChildByID(id);

            foreach (DEPT d in depts)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = d.D_NAME;
                newNode.Value = d.D_NO;
                GetDeptTreeNode(newNode);
                node.ChildNodes.Add(newNode);
            }
            return node;
        }

        public RadTreeNode GetDeptTreeNode(RadTreeNode node)
        {
            DEPT_REPO dept_repo = new DEPT_REPO();
            string id = node.Value;
            List<DEPT> depts = dept_repo.GetChildByID(id);

            foreach (DEPT d in depts)
            {
                RadTreeNode newNode = new RadTreeNode();
                newNode.Text = d.D_NAME;
                newNode.Value = d.D_NO;
                GetDeptTreeNode(newNode);
                node.Nodes.Add(newNode);
            }
            return node;
        }

        public RadMenuItem GetDeptItem(RadMenuItem item)
        {
            DEPT_REPO dept_repo = new DEPT_REPO();
            List<DEPT> depts = dept_repo.GetChildByID(item.Value);

            foreach (DEPT d in depts)
            {
                RadMenuItem citem = new RadMenuItem();
                citem.Text = d.D_NAME;
                citem.Value = d.D_NO;
                GetDeptItem(citem);
                item.Items.Add(citem);
            }
            return item;
        }


        public TreeNode GetDeptTreeNode(TreeNode node,List<string> AaddedDeptList)
        {
            DEPT_REPO dept_repo = new DEPT_REPO();
            string id = node.Value;

            //已有新增過就不新增
            if (AaddedDeptList.Contains(id))
                return node;


            List<DEPT> depts = dept_repo.GetChildByID(id);

            foreach (DEPT d in depts)
            {
                //已有新增過就不新增
                if (AaddedDeptList.Contains(d.D_NO))
                    continue;

                TreeNode newNode = new TreeNode();
                newNode.Text = d.D_NAME;
                newNode.Value = d.D_NO;
                GetDeptTreeNode(newNode, AaddedDeptList);
                node.ChildNodes.Add(newNode);
            }

            AaddedDeptList.Add(id);
            return node;
        }



        public List<DEPT> GetByNobr(string id)
        {
            DateTime datetime = DateTime.Now.Date;
            return (from c in dc.DEPT
                    where c.NOBR == id && c.ADATE <= datetime && c.DDATE >= datetime
                    select c).ToList();
        }


        public List<DEPT> GetRoot()
        {
            DateTime datetime = DateTime.Now.Date;
            return (from c in dc.DEPT
                    where c.DEPT_GROUP ==""
                    && c.ADATE <= datetime && c.DDATE >= datetime
                    select c).ToList();
        }


        public List<DEPT> GetAll()
        {
            return (from c in dc.DEPT
                    select c).ToList();
        }

        public List<DEPT> GetAll_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DEPT
                        select c).ToList();
            }
        }

        /// <summary>
        /// 取得指定公司別的所有部門代碼
        /// </summary>
        /// <param name="Comp">公司代碼</param>
        /// <returns></returns>
        public List<DEPT> GetDeptListByCompany(string comp)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                var sql = from a in ldc.DEPT where ldc.GetCodeFilter("DEPT", a.D_NO, "", comp, true).Value select a;
                return sql.ToList();
            }
        }


        public static List<DEPT> GetInstance()
        {
            List<DEPT> list = HttpContext.Current.Cache[CacheName] as List<DEPT>;
            if (list == null)
            {
                lock (syncObj)
                {
                    list = HttpContext.Current.Cache[CacheName] as List<DEPT>;
                    if (list == null)
                    {
                        DEPT_REPO dRepo = new DEPT_REPO();
                        list = dRepo.GetAll();
                        HttpContext.Current.Cache[CacheName] = list;
                    }
                }
            }

            return list;
        }
    }
}