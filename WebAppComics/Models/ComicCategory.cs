using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class ComicCategory
{
    public Guid ComicId { get; set; }

    public int CategoryId { get; set; }

    public string? Note { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Comic Comic { get; set; } = null!;
}
