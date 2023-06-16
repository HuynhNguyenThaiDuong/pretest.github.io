using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class Character
{
    public string CharacterId { get; set; } = null!;

    public string? CharacterName { get; set; }

    public string? Description { get; set; }

    public string? CharacterTypeId { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<CharacterInGame> CharacterInGames { get; set; } = new List<CharacterInGame>();

    public virtual CharacterType? CharacterType { get; set; }
}
