using KamyonTakip.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamyonTakip.Data.Model
{
    public class AracModel:ModelBase
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required, Index(IsUnique = true)]
        public string Plaka { get; set; }
        public AracTip AracTip { get; set; }
        public string SoforAdi { get; set; }
        public string SoforTel { get; set; }
    }
}
