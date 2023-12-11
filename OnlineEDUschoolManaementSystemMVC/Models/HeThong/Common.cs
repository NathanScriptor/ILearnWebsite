using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace OnlineEDUschoolManaementSystemMVC.Models
{
    public class MapCourses
    {
        DBEntities db = new DBEntities();
        //1. Danh sach
        public List<CourseTbl> CourseTbls()
        {
            try 
            {
                var listCourse = db.CourseTbls.ToList();
                return listCourse;
            }
            catch 
            {
                return new List<CourseTbl>();
            }
        }   
        //2. Chi tiet
        public CourseTbl ChiTiet(int courseid)
        {
            try
            {
                return db.CourseTbls.Find(courseid);
            }
            catch
            {
                return new CourseTbl();
            }
        }
        //3. Them moi
        public int ThemMoi(CourseTbl newModel)
        {
            try
            {
                db.CourseTbls.Add(newModel);
                db.SaveChanges();
                return newModel.courseId;
            }
            catch
            {
                return 0;
            }
        }
        //4. Cap nhat
        public bool CapNhat(CourseTbl updateModel) 
        {
            try
            {
                // 1. Tim doi tuong can cap nhat
                var khoaHoc = db.CourseTbls.Find(updateModel.courseId);
                khoaHoc.courseId = updateModel.courseId;
                khoaHoc.courseName = updateModel.courseName;
                khoaHoc.coursePrice = updateModel.coursePrice;
                khoaHoc.description = updateModel.description;
                khoaHoc.discount = updateModel.discount;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //5. Xoa
        public bool Xoa(int maKhoaHoc)
        {
            try
            {
                var khoaHoc = db.CourseTbls.Find(maKhoaHoc);
                db.CourseTbls.Remove(khoaHoc);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}