using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CarPark.Models;

public partial class TClient : IdentityUser
{
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<TBill> TBills { get; set; } = new List<TBill>();
}
