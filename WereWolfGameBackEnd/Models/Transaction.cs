using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class Transaction
{
    public string TransactionId { get; set; } = null!;

    public string? WalletId { get; set; }

    public string ActivityId { get; set; } = null!;

    public virtual Activity Activity { get; set; } = null!;

    public virtual Wallet? Wallet { get; set; }
}
