namespace Troganbets.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            Bets = new HashSet<Bet>();
        }

        public Guid Id { get; set; }

        public DateTime UtcDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string AwayTeam { get; set; }

        [Required]
        [StringLength(50)]
        public string HomeTeam { get; set; }

        public int AwayScore { get; set; }

        public int HomeScore { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string Situation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
