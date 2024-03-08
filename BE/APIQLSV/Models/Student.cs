using System;
using System.Collections.Generic;

namespace APIQLSV.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? Town { get; set; }

    public int IdClasses { get; set; }

    public virtual Class? IdClassesNavigation { get; set; }

    public virtual ICollection<StuCour> StuCours { get; } = new List<StuCour>();
}
