using System;
using System.Collections.Generic;

namespace QualaAPI.Models;

public partial class MonedaPru
{
    public int IdMoneda { get; set; }

    public string AbrevMoneda { get; set; } = null!;

    public string NomMoneda { get; set; } = null!;
}
