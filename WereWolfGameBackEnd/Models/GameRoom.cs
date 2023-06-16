using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class GameRoom
{
    public string RoomId { get; set; } = null!;

    public bool RoomState { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<CharacterInGame> CharacterInGames { get; set; } = new List<CharacterInGame>();
}
