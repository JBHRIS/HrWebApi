using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// ObjectExtension 的摘要描述
/// </summary>
public static class ObjectExtension
{
    ///
    /// Clone properties from an original object to a destination object.
    /// 

    /// 
    /// 
    ///
    ///
    public static void CloneProperties<T>(this T origin, T destination)
    {
        // Instantiate if necessary
        if (destination == null) throw new ArgumentNullException("destination", "Destination object must first be instantiated.");
        // Loop through each property in the destination
        foreach (var destinationProperty in destination.GetType().GetProperties())
        {
            // find and set val if we can find a matching property name and matching type in the origin with the origin's value
            if (origin != null && destinationProperty.CanWrite)
            {
                origin.GetType().GetProperties().Where(x => x.CanRead && (x.Name == destinationProperty.Name && x.PropertyType == destinationProperty.PropertyType))
                    .ToList()
                    .ForEach(x => destinationProperty.SetValue(destination, x.GetValue(origin, null), null));
            }
        }
    }


    /// <summary>
    /// 將 IEnumerable 轉為 DataTable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection">The collection.</param>
    /// <returns></returns>

    public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
    {
        var dtReturn = new DataTable();
        // column names
        var oProps = typeof(T).GetProperties();
        foreach ( var pi in oProps )
        {
            var colType = pi.PropertyType;
            if ( (colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)) )
            {
                colType = colType.GetGenericArguments()[0];
            }
            dtReturn.Columns.Add(new DataColumn(pi.Name , colType));
        }
        // Could add a check to verify that there is an element 0
        foreach ( var rec in collection )
        {
            var dr = dtReturn.NewRow();
            foreach ( var pi in oProps )
            {
                dr[pi.Name] = pi.GetValue(rec , null) ?? DBNull.Value;
            }
            dtReturn.Rows.Add(dr);
        }
        return (dtReturn);
    }


    public static int FindIndex<T>(this IEnumerable<T> items , Func<T , bool> predicate)
    {
        var itemsWithIndices = items.Select((item , index) => new
        {
            Item = item ,
            Index = index
        });
        var matchingIndices =
            from itemWithIndex in itemsWithIndices
            where predicate(itemWithIndex.Item)
            select (int?) itemWithIndex.Index;

        return matchingIndices.FirstOrDefault() ?? -1;
    }
}