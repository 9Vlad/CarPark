using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPark.Models;

public partial class TBill
{
    public int BillId { get; set; }

    public int FlightsId { get; set; }

    [ForeignKey("Client")]
    public string? ClientId { get; set; }

    public virtual TClient? Client { get; set; } = null!;

    public virtual TFlight Flights { get; set; } = null!;
}
