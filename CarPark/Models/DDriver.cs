using System;
using System.Collections.Generic;

namespace CarPark.Models;

public partial class DDriver
{
    public int DriverId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public decimal? Experience { get; set; }

    public virtual ICollection<TFlight> TFlights { get; set; } = new List<TFlight>();
}
