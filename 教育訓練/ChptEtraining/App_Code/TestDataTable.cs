using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// TestData 的摘要描述
/// </summary>
public class TestDataTable
{
    const String colName = "A";
    private int _col;
    private Dictionary<int, string> colNameDic = new Dictionary<int,string>();
    public int col
    {
        set
        {
            _col = value;
            setTypeListDefault();
        }
        get { return _col; }
    }

    public int row { get; set; }
    private List<System.Type> typeList = new List<System.Type>();
    private DataTable dt;
	public TestDataTable()
	{        
        col = 1;
        row = 1;
        setTypeListDefault();
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public void setTypeList(int col, System.Type type)
    {
        typeList[col] = type;
    }

    public void setColName(int col, String colName)
    {
        colNameDic.Add(col, colName);
    }

    private void setTypeListDefault()
    {
        typeList.Clear();
        for (int i = 0; i < col; i++)
        {
            typeList.Add(typeof(string));
        }
    }

    public DataTable getData()
    {
        
        setData();
        return dt;
    }

    private void setData()
    {
        dt = new DataTable();

        for (int i = 0; i < col; i++)
        {
            if (colNameDic.ContainsKey(i))
            {
                dt.Columns.Add(colNameDic[i].ToString(), typeList[i]);
            }
            else
            {
                dt.Columns.Add(colName + i.ToString(), typeList[i]);
            }
        }

        for(int i=0;i<row;i++)
        {
            DataRow dt_row = dt.NewRow();
            for (int c = 0; c < col; c++)
            {
                if (typeList[c] == typeof(int))
                {
                    dt_row[c] = i;
                }
                else if (typeList[c] == typeof(String))
                {
                    dt_row[c] = i.ToString();
                }
                else if (typeList[c] == typeof(DateTime))
                {
                    dt_row[c] = DateTime.Now;
                }
                else if (typeList[c] == typeof(Boolean))
                {
                    dt_row[c] = true;
                }
            }

            dt.Rows.Add(dt_row);
        }
    }






}