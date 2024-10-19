using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class ParticipantTime
{
    public int TimeId { get; set; }

    public int? ParticipantId { get; set; }

    public decimal TimeTaken { get; set; }

    public virtual Participant? Participant { get; set; }
}
