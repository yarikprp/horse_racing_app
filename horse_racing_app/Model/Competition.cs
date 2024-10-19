using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class Competition
{
    public int CompetitionId { get; set; }

    public DateOnly CompetitionDate { get; set; }

    public string CompetitionName { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
