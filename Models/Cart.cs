using System;
using System.Collections.Generic;

namespace ILEARN.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int OrderId { get; set; }

    public decimal? Total { get; set; }

    public virtual OrderDetail Order { get; set; } = null!;
}
