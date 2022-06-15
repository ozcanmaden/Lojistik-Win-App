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
    public class UserModel : ModelBase
    {
        public string AdSoyad { get; set; }
        private string kullaniciAdi;
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Required,Index(IsUnique = true)]
        public string KullaniciAdi
        {
            get { return kullaniciAdi; }
            set { kullaniciAdi = value; OnChanged(); }
        }

        private string parola;
        [Required]
        public string Parola
        {
            get { return parola; }
            set { parola = value; OnChanged(); }
        }
        public bool IsAdmin { get; set; }
    }
}
