using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class CarDetail
{
    public string LicensePlate { get; set; } = null!;

    public string? BrandName { get; set; }

    public string? ModelName { get; set; }

    public string? BodyTypeName { get; set; }

    public string? TransmissionType { get; set; }

    public string? ColorName { get; set; }

    public bool? Availability { get; set; }
}
