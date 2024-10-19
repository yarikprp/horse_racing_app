using System;
using System.Collections.Generic;

namespace horse_racing_app.Model;

public partial class Horse
{
    public int HorseId { get; set; }

    public string Nickname { get; set; } = null!;

    public int BirthYear { get; set; }

    public int? GenderId { get; set; }

    public int? BreedId { get; set; }

    public string? TrainerFullName { get; set; }

    public string? Owner { get; set; }

    public virtual HorseBreed? Breed { get; set; }

    public virtual HorseGender? Gender { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
