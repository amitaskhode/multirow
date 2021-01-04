using SchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace SchoolApp.Core
{
    public static class Common
    {
        public const string DbInsertInfo = "Data saved successfully.";
        public const string DbUpdateInfo = "Data updated successfully.";
        public const string DbDeleteInfo = "Data deleted successfully.";
        public const string OperationCompleteInfo = "Operation completed successfully.";
        public const string NO_DATA_FOUND = "No Data Found for this entry";

        public static object MapToModelObject(this object sourceObject, object targetObject)
        {
            ResultModel result = new ResultModel();
            try
            {
                foreach (System.Reflection.PropertyInfo v in sourceObject.GetType().GetProperties())
                {
                    if (targetObject.GetType().GetProperties().Any(prop => prop.Name == v.Name))
                        try
                        {
                            targetObject.GetType().GetProperty(v.Name).SetValue(targetObject, v.GetValue(sourceObject));
                        }
                        catch (Exception e1)
                        {
                            throw e1;
                        }
                }
            }
            catch (Exception e1)
            {
                result = e1.GetHTMLException();
            }
            return targetObject;
        }

        public static object MapToModelObject(this object sourceObject, object targetObject, List<string> ExcludeProperties)
        {
            try
            {
                foreach (System.Reflection.PropertyInfo v in sourceObject.GetType().GetProperties().Where(i => !ExcludeProperties.Any(e => i.Name.Equals(e))).ToArray())
                {

                    if (targetObject.GetType().GetProperties().Any(prop => prop.Name == v.Name))
                        try
                        {
                            targetObject.GetType().GetProperty(v.Name).SetValue(targetObject, v.GetValue(sourceObject));
                        }
#pragma warning disable CS0168 // The variable 'e1' is declared but never used
                        catch (Exception e1)
#pragma warning restore CS0168 // The variable 'e1' is declared but never used
                        {
                            throw e1;
                        }
                }
            }
#pragma warning disable CS0168 // The variable 'e1' is declared but never used
            catch (Exception e1)
#pragma warning restore CS0168 // The variable 'e1' is declared but never used
            {
                throw e1;
            }
            return targetObject;
        }
        public static ResultModel GetHTMLException(this Exception exception)
        {
            ResultModel result = new ResultModel();
            result.Result = iResultType.iError;
            var sqlException = exception.GetBaseException() as SqlException;
            StringBuilder sb = new StringBuilder();
            if (sqlException != null)
            {
                foreach (SqlError v in sqlException.Errors)
                {
                    sb.AppendLine("<dl>");
                    sb.AppendLine($"<dt><i class='ion-alert-circled'></i>{v.Number}</dt>");
                    sb.AppendLine($"<dd>{v.Message}</dd>");
                    sb.AppendLine("</dl><br/>");
                    Dictionary<string, object> ex = new Dictionary<string, object>();
                    ex.Add(v.Number.ToString(), v);
                }
            }
            else
            {
                sb.AppendLine("<dl>");
                sb.AppendLine($"<dt><i class='ion-alert-circled'></i>{exception.HResult}</dt>");
                sb.AppendLine($"<dd>{exception.Message}</dd>");
                sb.AppendLine($"<dd id='exception_details' style='display:none;'> ");
                if (exception.InnerException != null)
                {
                    sb.AppendLine(exception.InnerException.Message);
                    if (exception.InnerException.InnerException != null)
                    {
                        sb.AppendLine(exception.InnerException.InnerException.Message);
                    }
                }
                sb.AppendLine($"</dd>");
                //sb.AppendLine($"<dd id='exception_details' style='display:none;'>{exception.InnerException.InnerException.Message}</dd>");
                sb.AppendLine("</dl><br/>");
                Dictionary<string, object> ex = new Dictionary<string, object>();
                ex.Add(exception.HResult.ToString(), exception);
            }
            result.Message = sb.ToString();
            return result;
        }
    }
}