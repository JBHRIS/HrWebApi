using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using System.Collections;

/// <summary>
/// EntityToDataTable 的摘要描述
/// </summary>
public class EntityToDataTable
{
    public EntityToDataTable()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }


    /// <summary>
    /// Gets the entity to data table schema.
    /// </summary>
    /// <param name="entityType">Type of the entity.</param>
    /// <returns>對應Entity屬性型別的DataTable</returns>
    public static DataTable GetEntityToDataTableSchema(Type entityType)
    {

        var result = new DataTable();

        var properties = entityType.GetProperties();

        foreach (var property in properties)
        {

            var columnType = property.PropertyType;



            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {

                //兩種寫法都可以，透過Nullable.GetUnderlyingType()比較簡潔。

                //columnType = property.PropertyType.GetGenericArguments()[0];

                columnType = Nullable.GetUnderlyingType(property.PropertyType);
            }

            var column = new DataColumn(property.Name, columnType);
            result.Columns.Add(column);
        }

        return result;

    }


    /// <summary>
    /// 將entities直接轉成DataTable
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entities">entity集合</param>
    /// <returns>將Entity的值轉為DataTable</returns>

    public static DataTable Entity2DataTable<T>(IEnumerable<T> entities)
    {

        var result = GetEntityToDataTableSchema(typeof(T));

        if (entities.Count() == 0)
        {
            return result;
        }

        var properties = typeof(T).GetProperties();

        foreach (var entity in entities)
        {
            var dr = result.NewRow();

            foreach (var property in properties)
            {
                dr[property.Name] = property.GetValue(entity, null).NullToDbNull();
            }

            result.Rows.Add(dr);
        }

        return result;
    }   
}
