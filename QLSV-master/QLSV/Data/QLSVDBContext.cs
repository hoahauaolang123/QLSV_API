using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace QLSV.Data
{
    public class QLSVDBContext :DbContext
    {
        public QLSVDBContext(DbContextOptions<QLSVDBContext>options):base(options)
        {

        }
        public DbSet<GiaoVien> GiaoVien { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiaoVien>()
                .HasKey(o => o.IdGV);
        /*    //modelBuilder.Entity<GiaoVien>()
            //    .HasKey(o => o.MaGV);*/



        }
    }
}
