using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class CharacterInGame
{
    public string RoomId { get; set; } = null!;

    public string CharacterId { get; set; } = null!;

    public string? PlayerId { get; set; }

    public virtual Character Character { get; set; } = null!;

    public virtual Player? Player { get; set; }

    public virtual GameRoom Room { get; set; } = null!;
}
