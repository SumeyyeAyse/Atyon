using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblAtikTip")]
    [Index("AtikTipKod", Name = "uk_TblAtikTip_", IsUnique = true)]
    public partial class TblAtikTip
    {
        public TblAtikTip()
        {
            TblAtiks = new HashSet<TblAtik>();
        }

        [Key]
        public int AtikTipId { get; set; }
        public int AtikTipKod { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? AtikTipAd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayıtTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }

        [ForeignKey("AtikTipKod")]
        [InverseProperty("InverseAtikTipKodNavigation")]
        public virtual TblAtikTip AtikTipKodNavigation { get; set; } = null!;
        [InverseProperty("AtikTipKodNavigation")]
        public virtual TblAtikTip InverseAtikTipKodNavigation { get; set; } = null!;
        public virtual ICollection<TblAtik> TblAtiks { get; set; }
    }
}
