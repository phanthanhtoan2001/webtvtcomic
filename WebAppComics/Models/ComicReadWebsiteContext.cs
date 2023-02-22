using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppComics.Models;

public partial class ComicReadWebsiteContext : DbContext
{
    public ComicReadWebsiteContext()
    {
    }

    public ComicReadWebsiteContext(DbContextOptions<ComicReadWebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorDetail> AuthorDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryAccount> CategoryAccounts { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Comic> Comics { get; set; }

    public virtual DbSet<ComicCategory> ComicCategories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Posting> Postings { get; set; }

    public virtual DbSet<WordDetail> WordDetails { get; set; }

    public virtual DbSet<WordToxic> WordToxics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-2T7I2UGR\\LOCAL;Database=Comic_Read_Website;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("pk_Account");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.AccountImage)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.AccountName).HasMaxLength(40);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PassWord)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoryAcc).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CategoryAccId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__Categor__4D94879B");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("pk_Author");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AuthorName).HasMaxLength(50);
        });

        modelBuilder.Entity<AuthorDetail>(entity =>
        {
            entity.HasKey(e => new { e.ComicId, e.AuthorId }).HasName("pk_AuthorDetail");

            entity.ToTable("AuthorDetail");

            entity.Property(e => e.ComicId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ComicID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

            entity.HasOne(d => d.Author).WithMany(p => p.AuthorDetails)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AuthorDet__Autho__49C3F6B7");

            entity.HasOne(d => d.Comic).WithMany(p => p.AuthorDetails)
                .HasForeignKey(d => d.ComicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AuthorDet__Comic__46E78A0C");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("pk_Category");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<CategoryAccount>(entity =>
        {
            entity.HasKey(e => e.CategoryAccId).HasName("pk_CategoryAccount");

            entity.ToTable("CategoryAccount");

            entity.Property(e => e.CategoryAccName).HasMaxLength(50);
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.HasKey(e => e.ChapterId).HasName("pk_Chapter");

            entity.ToTable("Chapter");

            entity.Property(e => e.ChapterId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ChapterID");
            entity.Property(e => e.ChapterName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ComicId).HasColumnName("ComicID");
            entity.Property(e => e.UpdateDay).HasColumnType("datetime");

            entity.HasOne(d => d.Comic).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.ComicId)
                .HasConstraintName("FK__Chapter__ComicID__44FF419A");
        });

        modelBuilder.Entity<Comic>(entity =>
        {
            entity.HasKey(e => e.ComicId).HasName("pk_Comics");

            entity.Property(e => e.ComicId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ComicID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.ComicBanner).IsUnicode(false);
            entity.Property(e => e.ComicName).HasMaxLength(100);
            entity.Property(e => e.ComicStatus).HasMaxLength(25);
            entity.Property(e => e.DateSummitted).HasColumnType("datetime");
            entity.Property(e => e.Describe).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.Comics)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comics__AccountI__440B1D61");
        });

        modelBuilder.Entity<ComicCategory>(entity =>
        {
            entity.HasKey(e => new { e.ComicId, e.CategoryId }).HasName("pk_Comic-Category");

            entity.ToTable("ComicCategory");

            entity.Property(e => e.ComicId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ComicID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Note)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.ComicCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comic-Cat__Categ__4AB81AF0");

            entity.HasOne(d => d.Comic).WithMany(p => p.ComicCategories)
                .HasForeignKey(d => d.ComicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comic-Cat__Comic__45F365D3");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommnentId).HasName("pk_Comment");

            entity.ToTable("Comment");

            entity.Property(e => e.CommnentId).HasColumnName("CommnentID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");
            entity.Property(e => e.CommnentContent).HasMaxLength(200);
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__Account__4222D4EF");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK__Comment__Chapter__47DBAE45");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Image__3CAB4D397AFBC96A");

            entity.ToTable("Image");

            entity.Property(e => e.ImageId).HasColumnName("Image_ID");
            entity.Property(e => e.ChapterId).HasColumnName("ChapterID");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("Image_URL");

            entity.HasOne(d => d.Chapter).WithMany(p => p.Images)
                .HasForeignKey(d => d.ChapterId)
                .HasConstraintName("FK__Image__ChapterID__6754599E");
        });

        modelBuilder.Entity<Posting>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("pk_Posting");

            entity.ToTable("Posting");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.PostContent).HasMaxLength(300);

            entity.HasOne(d => d.Account).WithMany(p => p.Postings)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posting__Account__4316F928");
        });

        modelBuilder.Entity<WordDetail>(entity =>
        {
            entity.HasKey(e => new { e.WordToxicId, e.CommnentId }).HasName("pk_WordDetails");

            entity.Property(e => e.WordToxicId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("WordToxicID");
            entity.Property(e => e.CommnentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CommnentID");
            entity.Property(e => e.Content).HasMaxLength(200);

            entity.HasOne(d => d.Commnent).WithMany(p => p.WordDetails)
                .HasForeignKey(d => d.CommnentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WordDetai__Commn__4BAC3F29");

            entity.HasOne(d => d.WordToxic).WithMany(p => p.WordDetails)
                .HasForeignKey(d => d.WordToxicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WordDetai__WordT__4CA06362");
        });

        modelBuilder.Entity<WordToxic>(entity =>
        {
            entity.HasKey(e => e.WordToxicId).HasName("pk_WordToxic");

            entity.ToTable("WordToxic");

            entity.Property(e => e.WordToxicId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("WordToxicID");
            entity.Property(e => e.WordToxicName).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
