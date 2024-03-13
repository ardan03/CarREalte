using System;
using System.Collections.Generic;

namespace CarRealte.DB;

public partial class Пользователи
{
    public int IdПользователя { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public virtual ICollection<Аренда> Арендаs { get; set; } = new List<Аренда>();

    public virtual ICollection<Клиенты> Клиентыs { get; set; } = new List<Клиенты>();

    public virtual ICollection<Сотрудник> Сотрудникs { get; set; } = new List<Сотрудник>();
}
