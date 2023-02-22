using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class Comment
{
    public int CommnentId { get; set; }

    public string? CommnentContent { get; set; }

    public DateTime? Date { get; set; }

    public Guid? ChapterId { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Chapter? Chapter { get; set; }

    public virtual ICollection<WordDetail> WordDetails { get; } = new List<WordDetail>();
}
