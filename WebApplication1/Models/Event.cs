using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Event
{
    public int IdEvent { get; set; }

    public string Name { get; set; } = null!;

    public int IdType { get; set; }

    public int IdOrganizer { get; set; }

    public DateOnly DataStart { get; set; }

    public TimeOnly TimeStart { get; set; }

    public DateOnly DataEnd { get; set; }

    public TimeOnly TimeEnd { get; set; }

    public int IdPlace { get; set; }

    public string Note { get; set; } = null!;

    public int IdTicket { get; set; }

    public int IdUser { get; set; }

    public virtual Organizer IdOrganizerNavigation { get; set; } = null!;

    public virtual Place IdPlaceNavigation { get; set; } = null!;

    public virtual Ticket IdTicketNavigation { get; set; } = null!;

    public virtual TypeEvent IdTypeNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
