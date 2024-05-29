using System;
using System.Collections.Generic;

namespace CarPark.Models;

public partial class TTrackingsBu
{
    public int TrackingId { get; set; }

    public int BusId { get; set; }

    public DateTime? Bdate { get; set; }

    public DateTime? Edate { get; set; }

    public decimal? Price { get; set; }

    public string? Notes { get; set; }

    public virtual DBuse Bus { get; set; } = null!;
}
