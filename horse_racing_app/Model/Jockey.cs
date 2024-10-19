using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class Jockey
{
    public int JockeyId { get; set; }

    public string PersonalCode { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public decimal? Weight { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
