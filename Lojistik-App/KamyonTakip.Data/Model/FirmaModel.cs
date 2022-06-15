using KamyonTakip.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KamyonTakip.Data.Model
{
    public class FirmaModel:ModelBase
    {
        public string FirmaAd { get; set; }
        public string VergiDairesi { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Required, Index(IsUnique = true)]
        public string VergiNumarasi { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Yetkili { get; set; }
        public FirmaTip Tip { get; set; }

    }
}
