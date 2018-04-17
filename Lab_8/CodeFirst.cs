using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Lab_8
{
    public class CodeFirst :  DbContext
    {
        public DbSet<Words> Words { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersWords> UsersWords { get; set; }
        public CodeFirst()
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersWords>()
                .HasKey(t => new { t.UserId, t.WordId });

            modelBuilder.Entity<UsersWords>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UsersWord)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UsersWords>()
                .HasOne(pt => pt.Word)
                .WithMany(t => t.UsersWord)
                .HasForeignKey(pt => pt.WordId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Lab_8(New);Trusted_Connection=True;multipleactiveresultsets=True");
            base.OnConfiguring(builder);
        }   
    }
}
