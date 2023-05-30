using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class TypeEvent
{
    public int IdType { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
