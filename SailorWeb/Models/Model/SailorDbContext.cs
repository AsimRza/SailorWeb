namespace SailorWeb.Models.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SailorDbContext : DbContext
    {
        public SailorDbContext()
            : base("name=SailorDbContext")
        {
        }

        public virtual DbSet<About_TBL> About_TBL { get; set; }
        public virtual DbSet<Blog_TBL> Blog_TBL { get; set; }
        public virtual DbSet<BlogAndTag> BlogAndTag { get; set; }
        public virtual DbSet<BlogCategory_TBL> BlogCategory_TBL { get; set; }
        public virtual DbSet<Comment_TBL> Comment_TBL { get; set; }
        public virtual DbSet<Contact_TBL> Contact_TBL { get; set; }
        public virtual DbSet<Faq_TBL> Faq_TBL { get; set; }
        public virtual DbSet<PageIdentity_TBL> PageIdentity_TBL { get; set; }
        public virtual DbSet<Partner_TBL> Partner_TBL { get; set; }
        public virtual DbSet<Portfolio_TBL> Portfolio_TBL { get; set; }
        public virtual DbSet<PortfolioCategory_TBL> PortfolioCategory_TBL { get; set; }
        public virtual DbSet<PortfolioImg_TBL> PortfolioImg_TBL { get; set; }
        public virtual DbSet<Services_TBL> Services_TBL { get; set; }
        public virtual DbSet<Skills_TBL> Skills_TBL { get; set; }
        public virtual DbSet<Slider_TBL> Slider_TBL { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tag_TBL> Tag_TBL { get; set; }
        public virtual DbSet<Team_TBL> Team_TBL { get; set; }
        public virtual DbSet<Testimionals_TBL> Testimionals_TBL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog_TBL>()
                .HasMany(e => e.BlogAndTag)
                .WithRequired(e => e.Blog_TBL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Blog_TBL>()
                .HasMany(e => e.Comment_TBL)
                .WithRequired(e => e.Blog_TBL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BlogCategory_TBL>()
                .HasMany(e => e.Blog_TBL)
                .WithRequired(e => e.BlogCategory_TBL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Portfolio_TBL>()
                .HasMany(e => e.PortfolioImg_TBL)
                .WithRequired(e => e.Portfolio_TBL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PortfolioCategory_TBL>()
                .HasMany(e => e.Portfolio_TBL)
                .WithRequired(e => e.PortfolioCategory_TBL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag_TBL>()
                .HasMany(e => e.BlogAndTag)
                .WithRequired(e => e.Tag_TBL)
                .WillCascadeOnDelete(false);
        }
    }
}
