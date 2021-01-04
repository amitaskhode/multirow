using SchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services
{
    public interface IEntity
    {
    }

    public interface IRepository<T> where T : IEntity
    {
        Tuple<ResultModel, IEnumerable<T>> List();
        ResultModel Add(T entity);
        ResultModel Delete(T entity);
        ResultModel Update(T entity);
        Tuple<ResultModel, T> GetByKey(int primaryKey);
        Tuple<ResultModel, StudentVM> GetData();
        Tuple<ResultModel, IEnumerable<T>> GetByForeignKey(T entity);        

        Tuple<ResultModel, IEnumerable<T>> ExecuteQuery(string sql, params object[] parameters);

    }
}
