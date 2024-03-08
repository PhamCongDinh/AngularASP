using System;
using System.Collections.Generic;

namespace APIQLSV.Models;

public partial class Class
{
    public int Id { get; set; }

    public string NameClass { get; set; } = null!;

    public int IdDepart { get; set; }

    public virtual Department? IdDepartNavigation { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
