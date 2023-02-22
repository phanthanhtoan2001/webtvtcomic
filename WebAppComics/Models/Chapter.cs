using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class Chapter
{
    public Guid ChapterId { get; set; }

    public string? ChapterName { get; set; }

    public int? View { get; set; }

    public DateTime? UpdateDay { get; set; }

    public Guid? ComicId { get; set; }

    public virtual Comic? Comic { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Image> Images { get; } = new List<Image>();
}
