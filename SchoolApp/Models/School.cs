using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class School : IdentityUser
    {
        public School(): base("name=DefaultConnection")
        {
        }
        public static School Create()
        {
            return new School();
        }
        public DbSet<Student> Students { get; set; }
    }
}