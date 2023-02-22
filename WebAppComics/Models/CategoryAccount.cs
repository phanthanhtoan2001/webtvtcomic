using System;
using System.Collections.Generic;

namespace WebAppComics.Models;

public partial class CategoryAccount
{
    public int CategoryAccId { get; set; }

    public string? CategoryAccName { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
