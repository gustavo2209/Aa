using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Aa
{
    public partial class ModelAa : DbContext
    {
        public ModelAa()
            : base("name=ModelAa")
        {
        }

        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usuarios>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.autorizacion)
                .IsUnicode(false);
        }
    }
}
