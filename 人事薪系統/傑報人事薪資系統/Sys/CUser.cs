using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Sys
{
	class CUser
	{
		/// <summary>
		/// 使用者代號
		/// </summary>
		public string USER_ID = "";
		/// <summary>
		/// 使用者姓名
		/// </summary>
		public string USER_NAME = "";
		/// <summary>
		/// 資料群組
		/// </summary>
		public string WORKADR = "";
		/// <summary>
		/// 可計算全部薪資
		/// </summary>
		public bool PROCSUPER = false;
		/// <summary>
		/// 可取得全部薪資
		/// </summary>
		public bool MANGSUPER = false;
		/// <summary>
		/// 全部作業
		/// </summary>
		public bool SUPER = false;
		/// <summary>
		/// 系統
		/// </summary>
		public string SYSTEM = "";


		private CUser() { }

		public CUser(string user_id)
		{
			SysDS.U_USERDataTable U_USERDataTable = new SysDSTableAdapters.U_USERTableAdapter().GetDataByUSERID(user_id);
			if (U_USERDataTable.Count > 0)
			{
				USER_ID = U_USERDataTable[0].USER_ID.Trim();
				USER_NAME = U_USERDataTable[0].NAME.Trim();
				WORKADR = U_USERDataTable[0].WORKADR.Trim();
				PROCSUPER = U_USERDataTable[0].PROCSUPER;
				MANGSUPER = U_USERDataTable[0].MANGSUPER;
				SUPER = U_USERDataTable[0].SUPER;

				foreach (var row in U_USERDataTable)
				{
					if (SYSTEM.Trim().Length == 0) SYSTEM = row.SYSTEM.Trim();
					else SYSTEM += row.SYSTEM.Trim();
				}
			}
		}
	}
}
