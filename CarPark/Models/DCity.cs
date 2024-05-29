using System;
using System.Collections.Generic;

namespace CarPark.Models;

public partial class DCity
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<DRoute> DRouteBcityNavigations { get; set; } = new List<DRoute>();

    public virtual ICollection<DRoute> DRouteEcityNavigations { get; set; } = new List<DRoute>();
}
