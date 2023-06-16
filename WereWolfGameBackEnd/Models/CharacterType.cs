using System;
using System.Collections.Generic;

namespace WereWolfGameBackEnd.Models;

public partial class CharacterType
{
    public string CharacterTypeId { get; set; } = null!;

    public string? CharacterTypeName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
