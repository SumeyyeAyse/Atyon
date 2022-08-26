using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblAtik")]
    [Index("AtikTipKod", Name = "ix_TblAtikKod")]
    [Index("AtikKod", Name = "uk_TblAtikKod", IsUnique = true)]
    public partial class TblAtik
    {
        public TblAtik()
        {
            TblAtikStokHarekets = new HashSet<TblAtikStokHareket>();
        }

        [Key]
        public int AtikId { get; set; }
        [Required]
        public int? AtikKod { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? AtikAd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayitTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }
        public int AtikTipKod { get; set; }

        public virtual TblAtikTip AtikTipKodNavigation { get; set; } = null!;
        public virtual ICollection<TblAtikStokHareket> TblAtikStokHarekets { get; set; }
    }
}
