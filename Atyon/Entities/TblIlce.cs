using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblIlce")]
    [Index("IlKod", Name = "ix_Tbl_Ilce_lkod")]
    [Index("IlceKod", Name = "uk_Tbl_Ilce_kod", IsUnique = true)]
    [Index("IlKod", Name = "un_Tbl_IlceKod", IsUnique = true)]
    public partial class TblIlce
    {
        public TblIlce()
        {
            TblTesis = new HashSet<TblTesis>();
        }

        [Key]
        public int IlceId { get; set; }
        /// <summary>
        /// mernis kodu
        /// </summary>
        [Required]
        public int? IlceKod { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? Ad { get; set; }
        public int IlKod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayitTarihi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }

        public virtual TblIl IlKodNavigation { get; set; } = null!;
        public virtual ICollection<TblTesis> TblTesis { get; set; }
    }
}
