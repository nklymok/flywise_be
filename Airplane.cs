﻿using System;
using System.Collections.Generic;

namespace FlyWiseBackendDbFirst;

public partial class Airplane
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
