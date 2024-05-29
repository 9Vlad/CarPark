using System;
using System.Collections.Generic;

namespace CarPark.Models;

public partial class TFlight
{
    public int FlightsId { get; set; }

    public int RouteId { get; set; }

    public int BusId { get; set; }

    public int DriverId { get; set; }

    public DateTime? BdateRoute { get; set; }


    public DateTime? EdateRoute { get; set; }


    public bool IsEnd { get; set; }

    public bool IsCanselet { get; set; }

    public virtual DBuse Bus { get; set; } = null!;

    public virtual DDriver Driver { get; set; } = null!;

    public virtual DRoute Route { get; set; } = null!;

    public virtual TBill? TBill { get; set; }
}
