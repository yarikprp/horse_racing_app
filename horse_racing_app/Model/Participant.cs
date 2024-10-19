using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class Participant
{
    public int ParticipantId { get; set; }

    public int? JockeyId { get; set; }

    public int? HorseId { get; set; }

    public int? RaceId { get; set; }

    public bool? Disqualified { get; set; }

    public string? ViolationDetails { get; set; }

    public virtual Horse? Horse { get; set; }

    public virtual Jockey? Jockey { get; set; }

    public virtual ICollection<ParticipantTime> ParticipantTimes { get; set; } = new List<ParticipantTime>();

    public virtual Race? Race { get; set; }

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
