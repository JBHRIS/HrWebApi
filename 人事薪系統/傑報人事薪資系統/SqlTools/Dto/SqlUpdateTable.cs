using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace SQLController.SqlTools.Dto
{
    //[global::System.Data.Linq.Mapping.DatabaseAttribute(Name = "waferhr")]
    public partial class SqlAutoUpdateDataContext : System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        #region 擴充性方法定義
        partial void OnCreated();
        #endregion

        //public SqlAutoUpdateDataContext(string connection) :
        //        base(connection)
        //{
        //    OnCreated();
        //}

        public SqlAutoUpdateDataContext(string connection) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public SqlAutoUpdateDataContext(System.Data.IDbConnection connection) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public SqlAutoUpdateDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public SqlAutoUpdateDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
                base(connection, mappingSource)
        {
            OnCreated();
        }

        public System.Data.Linq.Table<SqlUpdateTable> SqlUpdateTable
        {
            get
            {
                return this.GetTable<SqlUpdateTable>();
            }
        }
    }

    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.SqlUpdateTable")]
    public partial class SqlUpdateTable
    {
        private int _AutoKey;
        private string _FileName;
        private string _USERID;
        private System.DateTime _TIMEB;
        private System.DateTime _TIMEE;
        private string _NOTE;

        public SqlUpdateTable()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_AutoKey", DbType = "int", CanBeNull = false, IsDbGenerated = true, IsPrimaryKey = true)]
        public int AutoKey
        {
            get
            {
                return this._AutoKey;
            }
            set
            {
                if ((this._AutoKey != value))
                {
                    this._AutoKey = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_FileName", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                if ((this._FileName != value))
                {
                    this._FileName = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_USERID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string USERID
        {
            get
            {
                return this._USERID;
            }
            set
            {
                if ((this._USERID != value))
                {
                    this._USERID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TIMEB", DbType = "DateTime",CanBeNull =true)]
        public System.DateTime TIMEB
        {
            get
            {
                return this._TIMEB;
            }
            set
            {
                if ((this._TIMEB != value))
                {
                    this._TIMEB = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TIMEE", DbType = "DateTime", CanBeNull = true)]
        public System.DateTime TIMEE
        {
            get
            {
                return this._TIMEE;
            }
            set
            {
                if ((this._TIMEE != value))
                {
                    this._TIMEE = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_NOTE", DbType = "NVarChar(50) NOT NULL", CanBeNull = true)]
        public string NOTE
        {
            get
            {
                return this._NOTE;
            }
            set
            {
                if ((this._NOTE != value))
                {
                    this._NOTE = value;
                }
            }
        }
    }
}
