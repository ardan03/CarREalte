using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class Car
{
    public string LicensePlate { get; set; } = null!;

    public int? ModelId { get; set; }

    public int? TransmissionId { get; set; }

    public int? ColorId { get; set; }

    public bool? Availability { get; set; }

    public virtual Color? Color { get; set; }

    public virtual Model? Model { get; set; }

    public virtual Transmission? Transmission { get; set; }

    public virtual ICollection<Аренда> Арендаs { get; set; } = new List<Аренда>();
}
