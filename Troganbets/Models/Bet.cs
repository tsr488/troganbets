namespace Troganbets.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Bet
    {
        public static readonly string EntryA = "Aggressive";
        public static readonly string EntryB = "By-the-Book";

        public int Id { get; set; }

        public Guid GameId { get; set; }

        public bool OnHomeTeam { get; set; }

        public decimal? Points { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#}")]
        public short Odds { get; set; }

        [StringLength(50)]
        public string Entry { get; set; }

        public virtual Game Game { get; set; }
    }
}
