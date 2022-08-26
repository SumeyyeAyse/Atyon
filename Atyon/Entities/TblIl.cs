using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblIl")]
    [Index("IlKod", Name = "Tbl_Il_kod", IsUnique = true)]
    public partial class TblIl
    {
        [Key]
        public int IlId { get; set; }
        [Required]
        public int? IlKod { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? IlAd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayitTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }

        public virtual TblIlce TblIlce { get; set; } = null!;
    }
}
