using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class Activity
{
    public string ActivityId { get; set; } = null!;

    public string? ActivityDescription { get; set; }

    public string? ActivityType { get; set; }

    public string? CharacterId { get; set; }

    public virtual Character? Character { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
