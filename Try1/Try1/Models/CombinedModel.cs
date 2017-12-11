using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Try1.Models
{
    public class CombinedModel
    {
        public List<Course> ViewListCourse { get; set; }
        public List<Student> ViewListStudent { get; set; }
        public List<Installment> ViewListInstallment { get; set; }
        public List<Enroll> ViewListEnroll { get; set; }


        public Course ViewCourse { get; set; }
        public Student  ViewStudent { get; set; }
        public Installment  ViewInstallment { get; set; }
        public Enroll ViewEnroll { get; set; }
    }
}