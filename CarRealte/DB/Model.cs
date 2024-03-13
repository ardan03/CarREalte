using System;
using System.Collections.Generic;

namespace CarRealte.DB;

public partial class Model
{
    public int ModelId { get; set; }

    public string? ModelName { get; set; }

    public int? BrandId { get; set; }

    public int? BodyTypeId { get; set; }

    public virtual BodyType? BodyType { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
