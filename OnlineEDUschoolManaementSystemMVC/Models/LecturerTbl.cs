//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineEDUschoolManaementSystemMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LecturerTbl
    {
        public LecturerTbl()
        {
            this.CourseTbls = new HashSet<CourseTbl>();
        }
    
        public int lecturerId { get; set; }
        public string lecturerName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    
        public virtual ICollection<CourseTbl> CourseTbls { get; set; }
    }
}
