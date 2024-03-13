using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class Сотрудник
{
    public int IdСотрудника { get; set; }

    public int? IdПользователя { get; set; }

    public int? Должность { get; set; }

    public virtual Пользователи? IdПользователяNavigation { get; set; }

    public virtual Должность? ДолжностьNavigation { get; set; }
}
