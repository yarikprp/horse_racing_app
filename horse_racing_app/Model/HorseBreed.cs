using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class HorseBreed
{
    public int BreedId { get; set; }

    public string BreedName { get; set; } = null!;

    public virtual ICollection<Horse> Horses { get; set; } = new List<Horse>();
}
