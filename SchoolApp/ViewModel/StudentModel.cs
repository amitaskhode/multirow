using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.ViewModel
{
    public class StudentModel: IEntity
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public Nullable<int> StudentState { get; set; }
        public Nullable<int> StudentCity { get; set; }
        public int StudentMarkes { get; set; }
        public Nullable<decimal> StudentPercentage { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastModifiedOn { get; set; }
    }
}