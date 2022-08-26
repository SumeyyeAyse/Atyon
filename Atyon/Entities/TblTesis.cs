using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblTesis")]
    [Index("IlceKod", Name = "ix_Tbl_Tesis_ilce")]
    [Index("TesisKod", Name = "uk_Tbl_Tesis_kod", IsUnique = true)]
    public partial class TblTesis
    {
        public TblTesis()
        {
            TblAtikStokHarekets = new HashSet<TblAtikStokHareket>();
            TblTesisNitelikTips = new HashSet<TblTesisNitelikTip>();
            TblUretims = new HashSet<TblUretim>();
        }

        [Key]
        public int TesisId { get; set; }
        public int TesisKod { get; set; }
        public int FirmaKod { get; set; }
        public int IlceKod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayitTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }

        public virtual TblFirma FirmaKodNavigation { get; set; } = null!;
        public virtual TblIlce IlceKodNavigation { get; set; } = null!;
        public virtual ICollection<TblAtikStokHareket> TblAtikStokHarekets { get; set; }
        public virtual ICollection<TblTesisNitelikTip> TblTesisNitelikTips { get; set; }
        public virtual ICollection<TblUretim> TblUretims { get; set; }
    }
}
