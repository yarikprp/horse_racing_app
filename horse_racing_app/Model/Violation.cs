using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class Violation
{
    public int ViolationId { get; set; }

    public int? ParticipantId { get; set; }

    public string? ViolationDescription { get; set; }

    public DateTime? ViolationTime { get; set; }

    public virtual Participant? Participant { get; set; }
}
