using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class Клиенты
{
    public int IdКлиента { get; set; }

    public int? IdПользователя { get; set; }

    public string? НомерТелефона { get; set; }

    public string? ВодительскоеУдостоверение { get; set; }

    public virtual Пользователи? IdПользователяNavigation { get; set; }
}
