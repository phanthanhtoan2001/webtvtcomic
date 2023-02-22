using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<ComicCategory> ComicCategories { get; } = new List<ComicCategory>();
}
