using System;
using System.Collections.Generic;

namespace CarRealte.DB;

public partial class Transmission
{
    public int TransmissionId { get; set; }

    public string? TransmissionType { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
