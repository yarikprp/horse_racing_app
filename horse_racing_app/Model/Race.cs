using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class Race
{
    public int RaceId { get; set; }

    public int? CompetitionId { get; set; }

    public string RaceName { get; set; } = null!;

    public int? RaceTypeId { get; set; }

    public int Distance { get; set; }

    public string? Restrictions { get; set; }

    public decimal? PrizeFund { get; set; }

    public TimeOnly StartTime { get; set; }

    public int RaceNumber { get; set; }

    public virtual Competition? Competition { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual RaceType? RaceType { get; set; }
}
