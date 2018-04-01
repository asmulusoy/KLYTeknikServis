using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.DAL
{
    public class MyContext:IdentityDbContext<ApplicationUser>
    {
        public MyContext():base("name=mycon")
        {

        }

        public DbSet<Anket> Anketler { get; set; }
        public DbSet<Soru> Sorular { get; set; }
        public DbSet<Cevap> Cevaplar { get; set; }
        public DbSet<Ariza> Arizalar { get; set; }
        public DbSet<Fotograf> Fotograflar { get; set; }
        public DbSet<ArizaDurum> ArizaDurumlari { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }


    }
}
