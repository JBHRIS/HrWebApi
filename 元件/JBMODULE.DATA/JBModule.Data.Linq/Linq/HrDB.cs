namespace JBModule.Data.Linq
{
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    using System.ComponentModel;
    using System;
    using System.Data.SqlClient;
    using Dapper;

    public partial class HrDBDataContext : System.Data.Linq.DataContext
    {
        partial void OnCreated()
        {
            CommandTimeout = 5 * 60;
        }

        public void BulkInsertAll<T>(IEnumerable<T> entities, System.Data.Common.DbConnection dbConnection, System.Data.Common.DbTransaction dbTransaction)
        {
            //using (var conn = new SqlConnection(Connection.ConnectionString))
            //{
            if (dbConnection.State == ConnectionState.Closed) dbConnection.Open();

            Type t = typeof(T);

            var tableAttribute = (TableAttribute)t.GetCustomAttributes(
                typeof(TableAttribute), false).Single();
            var bulkCopy = new SqlBulkCopy((SqlConnection)dbConnection, SqlBulkCopyOptions.Default, (SqlTransaction)dbTransaction)
            {
                DestinationTableName = tableAttribute.Name
            };

            var properties = t.GetProperties().Where(EventTypeFilter).ToArray();
            var table = new DataTable();

            foreach (var property in properties)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.IsGenericType &&
                    propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propertyType = Nullable.GetUnderlyingType(propertyType);
                }

                table.Columns.Add(new DataColumn(property.Name, propertyType));
            }

            foreach (var entity in entities)
            {
                table.Rows.Add(
                    properties.Select(
                    property => property.GetValue(entity, null) ?? DBNull.Value
                    ).ToArray());
            }

            bulkCopy.WriteToServer(table);
            //}
        }

        private bool EventTypeFilter(System.Reflection.PropertyInfo p)
        {
            var attribute = Attribute.GetCustomAttribute(p,
                typeof(AssociationAttribute)) as AssociationAttribute;

            if (attribute == null) return true;
            if (attribute.IsForeignKey == false) return true;

            return false;
        }

        public bool BulkInsertWithDelete<T>(HrDBDataContext db, IEnumerable<T> entities,string deleteSql,object param,string errMsg)
        {
            System.Data.Common.DbConnection DbConnection = db.Connection;
            bool result = true;
            try
            {
                if (DbConnection.State == ConnectionState.Closed) DbConnection.Open();
                System.Data.Common.DbTransaction DbTransaction = DbConnection.BeginTransaction();

                try
                {
                    db.Transaction = DbTransaction;
                    db.Connection.Execute(deleteSql, param, DbTransaction, 120);
                    db.BulkInsertAll(entities, DbConnection, DbTransaction);
                    DbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    JBModule.Message.TextLog.WriteLog(string.Format("{0}¡G{1}", errMsg, ex.Message));
                    DbTransaction.Rollback();
                    result = false;
                }
            }
            finally
            {
                DbConnection.Close();
            }
            return result;
        }
        
    }
}

