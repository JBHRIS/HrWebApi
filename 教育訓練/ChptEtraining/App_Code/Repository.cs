using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T> : IRepository<T> 
    where T : class
{
    protected IDataContextFactory _dataContextFactory;

    /// <summary>
    /// Return all instances of type T.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> All()
    {
        return GetTable;
    }

    /// <summary>
    /// Return all instances of type T that match the expression exp.
    /// </summary>
    /// <param name="exp"></param>
    /// <returns></returns>
    public IEnumerable<T> FindAll(Func<T, bool> exp)
    {
        return GetTable.Where<T>(exp);
    }

    /// <summary>See _vertexRepository.</summary>
    /// <param name="exp"></param><returns></returns>
    public T Single(Func<T, bool> exp)
    {
        return GetTable.Single(exp);
    }

    /// <summary>See _vertexRepository.</summary>
    /// <param name="exp"></param><returns></returns>
    public T First(Func<T, bool> exp)
    {
        return GetTable.First(exp);        
    }

    /// <summary>See _vertexRepository.</summary>
    /// <param name="exp"></param><returns></returns>
    public T FirstOrDefault(Func<T, bool> exp)
    {
        return GetTable.FirstOrDefault(exp);
    }

    /// <summary>See _vertexRepository.</summary>
    /// <param name="entity"></param>
    public virtual void MarkForDeletion(T entity)
    {
        _dataContextFactory.Context.GetTable<T>().DeleteOnSubmit(entity);        
    }

    /// <summary>
    /// Create a new instance of type T.
    /// </summary>
    /// <returns></returns>
    public virtual T CreateInstance()
    {
        T entity = Activator.CreateInstance<T>();
        GetTable.InsertOnSubmit(entity);
        return entity;
    }

    /// <summary>See _vertexRepository.</summary>
    public void SaveAll()
    {
        _dataContextFactory.SaveAll();
    }

    public Repository(IDataContextFactory dataContextFactory)
    {
        _dataContextFactory = dataContextFactory;
    }
    
    #region Properties

    private string PrimaryKeyName
    {
        get { return TableMetadata.RowType.IdentityMembers[0].Name; }
    }

    private System.Data.Linq.Table<T> GetTable
    {
        get { return _dataContextFactory.Context.GetTable<T>(); }
    }

    private System.Data.Linq.Mapping.MetaTable TableMetadata
    {
        get { return _dataContextFactory.Context.Mapping.GetTable(typeof(T)); }
    }

    private System.Data.Linq.Mapping.MetaType ClassMetadata
    {
        get { return _dataContextFactory.Context.Mapping.GetMetaType(typeof(T)); }
    }

    #endregion
}