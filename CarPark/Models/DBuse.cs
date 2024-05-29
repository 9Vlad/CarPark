using System;
using System.Collections.Generic;

namespace CarPark.Models;

public partial class DBuse
{
    public int BusId { get; set; }

    public string? Brand { get; set; }

    public int? Years { get; set; }

    public string? Numer { get; set; }

    public int? State { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<TFlight> TFlights { get; set; } = new List<TFlight>();

    public virtual ICollection<TTrackingsBu> TTrackingsBus { get; set; } = new List<TTrackingsBu>();
}
