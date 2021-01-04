using SchoolApp.Core;
using SchoolApp.Models;
using SchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Services
{
    public class StudentVMService : IRepository<StudentVM>
    {
        ResultModel result = new ResultModel();

        public ResultModel Add(StudentVM entity)
        {
            throw new NotImplementedException();
        }

        public ResultModel Delete(StudentVM entity)
        {
            throw new NotImplementedException();
        }

        public Tuple<ResultModel, IEnumerable<StudentVM>> ExecuteQuery(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Tuple<ResultModel, IEnumerable<StudentVM>> GetByForeignKey(StudentVM entity)
        {
            throw new NotImplementedException();
        }

        public Tuple<ResultModel, StudentVM> GetByKey(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public Tuple<ResultModel, StudentVM> GetData()
        {
            StudentVM model = new StudentVM();
            IRepository<StudentModel> invRepo = new StudentService();
            try
            {
                var sList = invRepo.List();
                if(sList.Item1.Result == iResultType.iSuccess)
                {
                    model.StudentList = sList.Item2.ToList();
                    model.Student = new StudentModel();
                    result.Result = iResultType.iSuccess;
                    result.Message = string.Empty;
                    result.Data = null;
                }
                else
                {
                    result.Result = iResultType.iNoRecordFound;
                    result.Message = Common.NO_DATA_FOUND;
                    result.Data = null;
                }
                
            }
            catch (Exception e1)
            {
                result = e1.GetHTMLException();
            }
            return new Tuple<ResultModel, StudentVM>(result, model);
        }

        public ResultModel Update(StudentVM entity)
        {
            throw new NotImplementedException();
        }

        Tuple<ResultModel, IEnumerable<StudentVM>> IRepository<StudentVM>.List()
        {
            throw new NotImplementedException();
        }
    }
}