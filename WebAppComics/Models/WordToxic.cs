using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class WordToxic
{
    public Guid WordToxicId { get; set; }

    public string? WordToxicName { get; set; }

    public virtual ICollection<WordDetail> WordDetails { get; } = new List<WordDetail>();
}
