namespace nerdydy.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class nerdydyModels : DbContext
    {
        public nerdydyModels()
            : base("name=nerdydyModels")
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameMedia> GameMedia { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
