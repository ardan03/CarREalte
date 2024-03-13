using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class ПользователиИИнформация
{
    public int IdПользователя { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public int? Должность { get; set; }

    public string? НомерТелефона { get; set; }

    public string? ВодительскоеУдостоверение { get; set; }
}
