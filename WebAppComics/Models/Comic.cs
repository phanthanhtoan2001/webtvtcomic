using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class Comic
{
    public Guid ComicId { get; set; }

    public string? ComicName { get; set; }

    public string Describe { get; set; } = null!;

    public string? ComicBanner { get; set; }

    public DateTime? DateSummitted { get; set; }

    public int? Rating { get; set; }

    public string? ComicStatus { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<AuthorDetail> AuthorDetails { get; } = new List<AuthorDetail>();

    public virtual ICollection<Chapter> Chapters { get; } = new List<Chapter>();

    public virtual ICollection<ComicCategory> ComicCategories { get; } = new List<ComicCategory>();
}
