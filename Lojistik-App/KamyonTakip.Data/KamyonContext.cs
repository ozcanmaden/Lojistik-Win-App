using KamyonTakip.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamyonTakip.Data
{
    public class KamyonContext : DbContext
    {

        public KamyonContext()
        {

        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<TakipModel> Takips { get; set; }

        public DbSet<FirmaModel> Firmas { get; set; }

        public DbSet<AracModel> Aracs { get; set; }

    }
}
