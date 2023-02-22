using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public string? ImageUrl { get; set; }

    public Guid? ChapterId { get; set; }

    public virtual Chapter? Chapter { get; set; }
}
