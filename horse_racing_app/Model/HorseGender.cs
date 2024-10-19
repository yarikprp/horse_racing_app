using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class HorseGender
{
    public int GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<Horse> Horses { get; set; } = new List<Horse>();
}
