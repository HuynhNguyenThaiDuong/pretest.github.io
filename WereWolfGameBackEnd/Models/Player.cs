using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class Player
{
    public string PlayerId { get; set; } = null!;

    public string PlayerName { get; set; } = null!;

    public string PlayerPassword { get; set; } = null!;

    public string PlayerEmail { get; set; } = null!;

    public int PlayerExp { get; set; }

    public virtual ICollection<CharacterInGame> CharacterInGames { get; set; } = new List<CharacterInGame>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
