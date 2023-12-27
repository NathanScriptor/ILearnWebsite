using OnlineEDUschoolManaementSystemMVC.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace OnlineEDUschoolManaementSystemMVC.Models
{
    public class Common
    {
        WebsiteDBEntities db = new WebsiteDBEntities();
        public static string GetLecturerNameFromCourse(Course course)
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                var gv = db.Lecturers.FirstOrDefault(p => p.ID == course.lecturerID);
                return gv.lecturerName;
            }
        }

        public static Lecturer GetLecturerFromID(Course course)
        {
            using(WebsiteDBEntities db = new WebsiteDBEntities())
            {
                return db.Lecturers.FirstOrDefault(p => p.ID == course.lecturerID);
            }
        }

        public static int GetCourseTeachedNumber(Lecturer lecturer)
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                int count = db.Courses.Count(m => m.lecturerID == lecturer.ID);
                return count;
            }
        }

        public static List<Course> GetCourseTeachedByLecturer(Lecturer lecturer)
        {
            using (WebsiteDBEntities db = new WebsiteDBEntities())
            {
                List<Course> courseList = (List<Course>)db.Courses.Where(p => p.lecturerID == lecturer.ID).OrderBy(p=>p.courseName).ToList();
                return courseList;
            }
        }
    }
}