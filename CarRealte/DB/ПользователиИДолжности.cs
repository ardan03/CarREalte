using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class ПользователиИДолжности
{
    public int IdПользователя { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public string? Должность { get; set; }

    public decimal? Зарплата { get; set; }
}
