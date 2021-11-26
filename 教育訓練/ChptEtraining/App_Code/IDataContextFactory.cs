public interface IDataContextFactory
{
    System.Data.Linq.DataContext Context { get; }
    void SaveAll();
}
public class DataContext : IDataContextFactory
{
    #region IDataContextFactory Members

    private System.Data.Linq.DataContext dt;

    public System.Data.Linq.DataContext Context
    {
        get
        {
            if (dt == null)
                dt = new dcTrainingDataContext();
            return dt;
        }
    }

    public void SaveAll()
    {
        dt.SubmitChanges();
    }

    #endregion
}