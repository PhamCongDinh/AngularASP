using System;
using System.Collections.Generic;

namespace APIQLSV.Models;

public partial class Department
{
    public int Id { get; set; }

    public string NameDepart { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; } = new List<Class>();
}
