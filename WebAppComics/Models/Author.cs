using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<AuthorDetail> AuthorDetails { get; } = new List<AuthorDetail>();
}
