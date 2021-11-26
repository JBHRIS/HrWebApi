using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL
{
    public interface IRepository<T, T1>
    {
        bool Insert(T instance, out string Msg);
        bool Update(T instance, out string Msg);
        bool Delete(T instance, out string Msg);
        T GetInstanceByID(object id);
        List<T> GetDataByCondition(T1 condition);
    }
}
