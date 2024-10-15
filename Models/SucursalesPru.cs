using System;
using System.Collections.Generic;

namespace QualaAPI.Models;

public partial class SucursalesPru
{
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public int Moneda { get; set; }
}
