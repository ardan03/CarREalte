using System;
using System.Collections.Generic;

namespace CarRealte.DB;

public partial class Тарифы
{
    public int IdТарифа { get; set; }

    public string? Название { get; set; }

    public string? Описание { get; set; }

    public decimal? Стоимость { get; set; }

    public virtual ICollection<Аренда> Арендаs { get; set; } = new List<Аренда>();
}
