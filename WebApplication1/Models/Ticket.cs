using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public string CountTickets { get; set; } = null!;

    public string UnsoldTickets { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
