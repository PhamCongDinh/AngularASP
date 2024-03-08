using System;
using System.Collections.Generic;

namespace APIQLSV.Models;

public partial class Course
{
    public int Id { get; set; }

    public string CoursesName { get; set; } = null!;

    public virtual ICollection<StuCour> StuCours { get; } = new List<StuCour>();
}
