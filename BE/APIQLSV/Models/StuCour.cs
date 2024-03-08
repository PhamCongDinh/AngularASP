using System;
using System.Collections.Generic;

namespace APIQLSV.Models;

public partial class StuCour
{
    public int IdStudent { get; set; }

    public int IdCourses { get; set; }

    public double? PointProcess { get; set; }

    public double? PointTest { get; set; }

    public int Number { get; set; }

    public virtual Course IdCoursesNavigation { get; set; }

    public virtual Student IdStudentNavigation { get; set; }
}
