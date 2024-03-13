using System;
using System.Collections.Generic;

namespace CarRealte.DB;

public partial class ПредставлениеАренда
{
    public int IdАренды { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public decimal? ЦенаАренды { get; set; }

    public string? Марка { get; set; }

    public string? Модель { get; set; }

    public string? НазваниеАренды { get; set; }

    public string? Описание { get; set; }
}
