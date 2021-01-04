using SchoolApp.Core;
using SchoolApp.Models;
using SchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Services
{
    public class StudentService : IRepository<StudentModel>
    {
        ResultModel result = new ResultModel();

        public ResultModel Add(StudentModel entity)
        {
            try
            {
                Student paObj = new Student();
                using (SchoolDb db = new SchoolDb())
                {
                    entity.MapToModelObject(paObj, new List<string> { "StudentID", "LastModifiedBy", "LastModifiedOn" });
                    paObj.CreatedOn = DateTime.Now;                    
                    db.Students.Add(paObj);
                    db.SaveChanges();

                    var v = (from v1 in db.Students where v1.StudentID == paObj.StudentID select v1);
                    v.MapToModelObject(entity);
                    entity.StudentID = paObj.StudentID;
                }
                result.Result = iResultType.iSuccess;
                result.Message = Common.DbInsertInfo;
                result.Data = entity.StudentID;
            }
            catch (Exception e1)
            {
                result = e1.GetHTMLException();
            }
            return result;
        }

        public ResultModel Delete(StudentModel entity)
        {
            try
            {
                using (SchoolDb db = new SchoolDb())
                {
                    if (entity.StudentID != 0)
                    {
                        var v = (from v1 in db.Students where v1.StudentID == entity.StudentID select v1);

                        if (v != null)
                        {
                            db.Students.RemoveRange(v);
                            db.SaveChanges();

                            result.Result = iResultType.iSuccess;
                            result.Message = Common.DbDeleteInfo;
                            result.Data = null;
                        }
                        else
                        {
                            result.Result = iResultType.iNoRecordFound;
                            result.Message = Common.NO_DATA_FOUND;
                            result.Data = null;
                        }
                    }
                    else
                    {
                        result.Result = iResultType.iEmptyModel;
                        result.Message = "Before calling this method set Student ID";
                        result.Data = null;
                    }
                }
            }
            catch (Exception e1)
            {
                result = e1.GetHTMLException();
            }
            return result;
        }

        public Tuple<ResultModel, IEnumerable<StudentModel>> ExecuteQuery(string sql, params object[] parameters)
        {
            var x = DataExecuter<StudentModel>.ExecuteQuery(sql, parameters);
            return x;
        }

        public Tuple<ResultModel, IEnumerable<StudentModel>> GetByForeignKey(StudentModel entity)
        {
            ResultModel result = new ResultModel();
            List<StudentModel> list = new List<StudentModel>();
            try
            {
                if (entity.StudentID != 0)
                {
                    using (SchoolDb db = new SchoolDb())
                    {
                        var v = (from v1 in db.Students orderby v1.StudentID ascending select v1).ToList();
                        foreach (Student it in v)
                        {
                            StudentModel model = new StudentModel();
                            it.MapToModelObject(model);
                            list.Add(model);
                        }
                    }
                    result.Result = iResultType.iSuccess;
                    result.Message = string.Empty;
                    result.Data = null;
                }
                else
                {
                    result.Result = iResultType.iError;
                    result.Message = "Set Student ID before calling this method.";
                    result.Data = null;
                }
            }
            catch (Exception e1)
            {
                result = e1.GetHTMLException();
            }
            return new Tuple<ResultModel, IEnumerable<StudentModel>>(result, list);
            //throw new NotImplementedException();
        }

        public Tuple<ResultModel, StudentModel> GetByKey(int primaryKey)
        {
            StudentModel model = new StudentModel();
            try
            {
                using (SchoolDb db = new SchoolDb())
                {
                    var v = (from v1 in db.Students where v1.StudentID == primaryKey select v1).First();
                    v.MapToModelObject(model);
                }

                result.Result = iResultType.iSuccess;
                result.Message = string.Empty;
                result.Data = null;
            }
            catch (Exception e1)
            {
                result = e1.GetHTMLException();
            }
            return new Tuple<ResultModel, StudentModel>(result, model);
        }

        public Tuple<ResultModel, StudentVM> GetData()
        {
            throw new NotImplementedException();
        }

        public Tuple<ResultModel, IEnumerable<StudentModel>> List()
        {
            List<StudentModel> list = new List<StudentModel>();
            try
            {
                using (SchoolDb db = new SchoolDb())
                {
                    var v = (from v1 in db.Students orderby v1.StudentID ascending select v1).ToList();
                    if (v.Any())
                    {
                        foreach (Student it in v)
                        {
                            StudentModel model = new StudentModel();
                            it.MapToModelObject(model);
                            list.Add(model);
                        }
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
            }
            catch (Exception e1)
            {
                result = e1.GetHTMLException();
            }
            return new Tuple<ResultModel, IEnumerable<StudentModel>>(result, list);
        }

        public ResultModel Update(StudentModel entity)
        {
            try
            {
                using (SchoolDb db = new SchoolDb())
                {
                    if (entity.StudentID != 0)
                    {
                        var v = (from v1 in db.Students where v1.StudentID == entity.StudentID select v1).FirstOrDefault();

                        if (v != null)
                        {
                            entity.MapToModelObject(v, new List<string> { "StudentID",  "CreatedOn" });                            
                            v.LastModifiedOn = DateTime.Now;
                            db.SaveChanges();

                            var CityM = (from CM in db.Students where CM.StudentID == entity.StudentID select CM);
                            CityM.MapToModelObject(entity);

                            result.Result = iResultType.iSuccess;
                            result.Message = Common.DbUpdateInfo;
                            result.Data = entity;
                        }
                        else
                        {
                            result.Result = iResultType.iNoRecordFound;
                            result.Message = Common.NO_DATA_FOUND;
                            result.Data = null;
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                result = e1.GetHTMLException();
            }
            return result;
        }
    }
}