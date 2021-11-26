using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR
{
	public class CDataLog
	{
		private CDataLog() { }

		public static void Save(string prg_name, string key_man, DateTime key_date, DataTable dt)
		{
			if (dt == null) return;
			if (dt.Rows.Count == 0) return;

			MainDS.U_TTSDataTable U_TTSDataTable = new MainDS.U_TTSDataTable();
			MainDSTableAdapters.U_TTSTableAdapter U_TTSTableAdapter = new JBHR.MainDSTableAdapters.U_TTSTableAdapter();

			foreach (DataRow row in dt.Rows)
			{
				if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified || row.RowState == DataRowState.Deleted)
				{
					MainDS.U_TTSRow U_TTSRow = U_TTSDataTable.NewU_TTSRow();
					U_TTSRow.PRG_NAME = prg_name;
					U_TTSRow.KEY_MAN = key_man;
					U_TTSRow.KEY_DATE = key_date;
					U_TTSRow.KEY_TIME = key_date.ToString("HH:mm:ss");

					string cont1 = "";
					string cont2 = "";
					switch (row.RowState)
					{
						case DataRowState.Added:
							U_TTSRow.OP_CODE = 1;
							cont1 = "";
							foreach (DataColumn col in dt.Columns)
							{
								if (cont1 != "") cont1 += ",";
								if (row.IsNull(col))
								{
									cont1 += "NULL";
								}
								else
								{
									cont1 += row[col.ColumnName].ToString();
								}
							}
							cont1 = "[ADD] " + cont1;
							break;
						case DataRowState.Modified:
							U_TTSRow.OP_CODE = 2;
							cont1 = "";
							foreach (DataColumn col in dt.Columns)
							{
								if (cont1 != "") cont1 += ",";
								if (row.IsNull(col,DataRowVersion.Original))
								{
									cont1 += "NULL";
								}
								else
								{
									cont1 += row[col.ColumnName, DataRowVersion.Original];
								}
							}
							cont1 = "[MODIFY] Original: " + cont1;
							cont2 = "[MODIFY] Current: " + cont2;
							foreach (DataColumn col in dt.Columns)
							{
								if (cont2 != "") cont2 += ",";
								if (row.IsNull(col, DataRowVersion.Current))
								{
									cont2 += "NULL";
								}
								else
								{
									cont2 += row[col.ColumnName, DataRowVersion.Current];
								}
							}
							break;
						case DataRowState.Deleted:
							U_TTSRow.OP_CODE = 3;							
							row.RejectChanges();
							cont1 = "";
							foreach (DataColumn col in dt.Columns)
							{
								if (cont1 != "") cont1 += ",";
								if (row.IsNull(col))
								{
									cont1 += "NULL";
								}
								else
								{
									cont1 += row[col.ColumnName].ToString();
								}
							}
							cont1 = "[DEL] " + cont1;
							row.Delete();
							break;
					}

					U_TTSRow.CONT = cont1;
					if (cont2 != "")
					{
						U_TTSRow.CONT += "\n" + cont2;
					}

					U_TTSDataTable.AddU_TTSRow(U_TTSRow);
				}
			}

			try
			{
				U_TTSTableAdapter.Update(U_TTSDataTable);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
