using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblAtikStokHareket")]
    [Index("TesisKod", Name = "ix_TblTransferTesis")]
    [Index("GuncellemeTarih", Name = "ix_TblTransfer_tariha")]
    public partial class TblAtikStokHareket
    {
        [Key]
        public int AtikStokHareketId { get; set; }
        /// <summary>
        /// 1 Çıkıiş
        /// 2 Giriş
        /// 3 Üretim
        /// 4 Geri Dönüşüm
        /// </summary>
        public int? AtikStokHareketTip { get; set; }
        public int TesisKod { get; set; }
        public int AtikKod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Miktar { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayitTarihi { get; set; }

        public virtual TblAtik AtikKodNavigation { get; set; } = null!;
        public virtual TblTesis TesisKodNavigation { get; set; } = null!;
    }
}
