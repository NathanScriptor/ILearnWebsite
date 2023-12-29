using System;
using System.Collections.Generic;

namespace ILEARN.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Course Course { get; set; } = null!;
}
