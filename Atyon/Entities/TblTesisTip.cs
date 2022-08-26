using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atyon.Entities
{
    [Table("TblTesisTip")]
    [Index("TesisTipKod", Name = "uk_Tbl_TesisTip_kod", IsUnique = true)]
    public partial class TblTesisTip
    {
        public TblTesisTip()
        {
            TblTesisNitelikTips = new HashSet<TblTesisNitelikTip>();
        }

        [Key]
        public int TesisTipId { get; set; }
        public int TesisTipKod { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? TesisTipAd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TesisTipKayıtTarih { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TesisTipGuncelTarih { get; set; }

        public virtual ICollection<TblTesisNitelikTip> TblTesisNitelikTips { get; set; }
    }
}
