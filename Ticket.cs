using System;
using System.Collections.Generic;

namespace FlyWiseBackendDbFirst;

public partial class Ticket
{
    public int Id { get; set; }

    public int AirplaneId { get; set; }

    public int PassengerId { get; set; }

    public decimal Price { get; set; }

    public virtual Airplane Airplane { get; set; } = null!;

    public virtual Passenger Passenger { get; set; } = null!;
}
