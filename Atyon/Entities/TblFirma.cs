using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblFirma")]
    [Index("FirmaKod", Name = "ix_Tbl_NakliyeKod")]
    [Index("FirmaKod", Name = "uk_TblNakliye_firma", IsUnique = true)]
    public partial class TblFirma
    {
        public TblFirma()
        {
            TblTesis = new HashSet<TblTesis>();
        }

        [Key]
        public int FirmaId { get; set; }
        public int FirmaKod { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Ad { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? VergiNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayitTarihi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }

        public virtual ICollection<TblTesis> TblTesis { get; set; }
    }
}
