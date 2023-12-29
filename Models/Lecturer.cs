using System;
using System.Collections.Generic;

namespace ILEARN.Models;

public partial class Lecturer
{
    public int Id { get; set; }

    public string LecturerName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
