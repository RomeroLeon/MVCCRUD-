using System;
using System.Collections.Generic;

namespace MVCCRUD_.Models;

public partial class EstadosEquipo
{
    public int IdEstadosEquipo { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }
}
