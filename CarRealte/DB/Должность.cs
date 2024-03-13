using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class Должность
{
    public int IdДолжности { get; set; }

    public string? Должность1 { get; set; }

    public decimal? Зарплата { get; set; }

    public virtual ICollection<Сотрудник> Сотрудникs { get; set; } = new List<Сотрудник>();
}
