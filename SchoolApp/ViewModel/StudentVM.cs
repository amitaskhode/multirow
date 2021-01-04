using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.ViewModel
{
    public class StudentVM : IEntity
    {
        public StudentModel Student { get; set; }
        public List<StudentModel> StudentList { get; set; }
    }
}