namespace ILEARN.Models
{
    public class Common
    {
        public static string GetLecturerNameFromCourse(Course course)
        {
            using IlearnDbContext db = new();
            var gv = db.Lecturers.First(p => p.Id == course.LecturerId);
            return gv.LecturerName;
        }

        public static Lecturer GetLecturerFromID(Course course)
        {
            using IlearnDbContext db = new IlearnDbContext();
            return db.Lecturers.First(p => p.Id == course.LecturerId);
        }

        public static int GetCourseTeachedNumber(Lecturer lecturer)
        {
            using IlearnDbContext db = new();
            int count = db.Courses.Count(m => m.LecturerId == lecturer.Id);
            return count;
        }

        public static List<Course> GetCourseTeachedByLecturer(Lecturer lecturer)
        {
            using IlearnDbContext db = new();
            List<Course> courseList = db.Courses.Where(p => p.LecturerId == lecturer.Id).OrderBy(p => p.CourseName).ToList();
            return courseList;
        }
    }
}
