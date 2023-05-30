using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int IdRole { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
