using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblUretim")]
    [Index("TesisKod", Name = "TblUretim__IDX")]
    [Index("UrunKod", Name = "TblUretim__IDXv1")]
    public partial class TblUretim
    {
        [Key]
        public int UretimId { get; set; }
        public int TesisKod { get; set; }
        public int UrunKod { get; set; }
        [Column(TypeName = "date")]
        public DateTime? UretimTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayıtTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }

        public virtual TblTesis TesisKodNavigation { get; set; } = null!;
        public virtual TblUrun UrunKodNavigation { get; set; } = null!;
    }
}
