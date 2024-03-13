using System;
using System.Collections.Generic;

namespace CarRealte;

public partial class Аренда
{
    public int IdАренды { get; set; }

    public string? Автомобиль { get; set; }

    public int? Пользователь { get; set; }

    public int? Тариф { get; set; }

    public virtual Car? АвтомобильNavigation { get; set; }

    public virtual Пользователи? ПользовательNavigation { get; set; }

    public virtual Тарифы? ТарифNavigation { get; set; }
}
