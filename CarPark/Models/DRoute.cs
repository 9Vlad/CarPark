using System;
using System.Collections.Generic;

namespace CarPark.Models;

public partial class DRoute
{
    public int RouteId { get; set; }

    public int Bcity { get; set; }

    public int Ecity { get; set; }

    public int? RouteLen { get; set; }

    public int? RouteTime { get; set; }

    public bool IsWork { get; set; }

    public string? Notes { get; set; }

    public virtual DCity BcityNavigation { get; set; } = null!;

    public virtual DCity EcityNavigation { get; set; } = null!;

    public virtual ICollection<TFlight> TFlights { get; set; } = new List<TFlight>();
}
