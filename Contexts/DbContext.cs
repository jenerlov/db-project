using Microsoft.EntityFrameworkCore;
using dbproject.Models.Entities;

namespace dbproject.Contexts;

    internal class DataContext : DbContext
    {
        public DbSet<CaseEntity> Cases {get; set;} = null!;
        public DbSet<UserEntity> Users {get; set;} = null!;
        public DbSet<StatusTypeEntity> Statuses {get; set;} = null!;
        public DbSet<CommentEntity> Comments {get; set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost;Database=DataContectDb;Trusted_Connection=True;");
        }
        
        

    }
