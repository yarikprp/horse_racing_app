using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class RaceType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
