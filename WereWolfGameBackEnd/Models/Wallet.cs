using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class Wallet
{
    public string WalletId { get; set; } = null!;

    public string? CurrencyType { get; set; }

    public int? Amount { get; set; }

    public string PlayerId { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
