using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? BrandName { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
