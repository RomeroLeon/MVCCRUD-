using System;
using System.Collections.Generic;

namespace MVCCRUD_.Models;

public partial class Equipo
{
    public int IdMarcas { get; set; }

    public string? NombreMarca { get; set; }

    public string? Estados { get; set; }
}
