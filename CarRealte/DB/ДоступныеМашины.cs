using System;
using System.Collections.Generic;

namespace CarRealte.DB;

public partial class ДоступныеМашины
{
    public string? LicensePlate { get; set; }

    public bool? Availability { get; set; }

    public string? ModelName { get; set; }

    public string? BrandName { get; set; }

    public string? BodyTypeName { get; set; }

    public string? TransmissionType { get; set; }

    public string? ColorName { get; set; }
}
