using System;
using System.Collections.Generic;

namespace CarRealte.DB;

public partial class BodyType
{
    public int BodyTypeId { get; set; }

    public string? BodyTypeName { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
