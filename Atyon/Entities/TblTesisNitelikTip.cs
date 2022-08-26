using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblTesisNitelikTip")]
    public partial class TblTesisNitelikTip
    {
        [Key]
        public int TesisNitelikTipId { get; set; }
        public int TesisKod { get; set; }
        public int TesisTipKod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? KayıtTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GuncellemeTarih { get; set; }

        public virtual TblTesis TesisKodNavigation { get; set; } = null!;
        public virtual TblTesisTip TesisTipKodNavigation { get; set; } = null!;
    }
}
