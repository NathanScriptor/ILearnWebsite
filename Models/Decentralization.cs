using System;
using System.Collections.Generic;

namespace ILEARN.Models;

public partial class Decentralization
{
    public int AccountId { get; set; }

    public int FunctionId { get; set; }

    public string? Description { get; set; }

    public virtual FunctionT Function { get; set; } = null!;
}
