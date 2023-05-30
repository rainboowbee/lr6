using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Organizer
{
    public int IdOrganizer { get; set; }

    public string OrgName { get; set; } = null!;

    public string OrgEmail { get; set; } = null!;

    public string OrgPhone { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
