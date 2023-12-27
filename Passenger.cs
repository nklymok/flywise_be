using System;
using System.Collections.Generic;

namespace FlyWiseBackendDbFirst;

public partial class Passenger
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int? AirplaneId { get; set; }

    public virtual Airplane? Airplane { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
