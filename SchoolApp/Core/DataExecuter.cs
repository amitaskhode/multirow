using SchoolApp.Models;
using SchoolApp.Services;
using SchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace SchoolApp.Core
{
    public static class DataExecuter<T> where T : IEntity
    {
        public static Tuple<ResultModel, IEnumerable<T>> ExecuteQuery(string sql, params object[] parameters)
        {
            Tuple<ResultModel, IEnumerable<T>> r;
            using (SchoolDb db = new SchoolDb())
            {
                DbRawSqlQuery<T> data;
                if (parameters != null)
                    data = db.Database.SqlQuery<T>(sql, parameters);
                else
                    data = db.Database.SqlQuery<T>(sql);
                ResultModel result = new ResultModel();
                result.Result = iResultType.iSuccess;
                result.Message = "Executed successfully";
                r = new Tuple<ResultModel, IEnumerable<T>>(result, data.ToList<T>());
            }
            return r;
        }
    }
}