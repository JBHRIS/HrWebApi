using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repo;
/// <summary>
/// BASERepository 的摘要描述
/// </summary>
public class BASERepository: Repository<BASE>, IBASERepository    
{
    public BASERepository(IDataContextFactory dataContextFactory) : base(dataContextFactory)
    {
    }


    #region IBASERepository 成員



    #endregion
}