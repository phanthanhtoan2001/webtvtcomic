using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? AccountName { get; set; }

    public string? Email { get; set; }

    public string? PassWord { get; set; }

    public int? Phone { get; set; }

    public DateTime? Date { get; set; }

    public string? AccountImage { get; set; }

    public int CategoryAccId { get; set; }

    public virtual CategoryAccount CategoryAcc { get; set; } = null!;

    public virtual ICollection<Comic> Comics { get; } = new List<Comic>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Posting> Postings { get; } = new List<Posting>();
}
