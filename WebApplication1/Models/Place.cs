using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Place
{
    public int IdPlace { get; set; }

    public string PlaceName { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string NumberHouse { get; set; } = null!;

    public string RentalCost { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
