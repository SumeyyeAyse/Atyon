using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblUrun")]
    [Index("UrunKod", Name = "uk_Tbl_Urunler_kod", IsUnique = true)]
    public partial class TblUrun
    {
        public TblUrun()
        {
            TblUretims = new HashSet<TblUretim>();
        }

        [Key]
        public int UrunId { get; set; }
        [Required]
        public int? UrunKod { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? UrunAd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayitTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }

        public virtual ICollection<TblUretim> TblUretims { get; set; }
    }
}
