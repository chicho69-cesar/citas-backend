using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace citas_backend.Data {
    public partial class citasContext : DbContext {
        public citasContext() { }

        public citasContext(DbContextOptions<citasContext> options) : base(options) { }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Date> Dates { get; set; } = null!;
        public virtual DbSet<Degree> Degrees { get; set; } = null!;
        public virtual DbSet<Hobby> Hobbies { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostImage> PostImages { get; set; } = null!;
        public virtual DbSet<SocialNetwork> SocialNetworks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserHobby> UserHobbies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Server=LAPTOP-B73G68IV; Database=citas; Trusted_Connection=True; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Comment>(entity => {
                entity.Property(e => e.Comment1)
                    .HasMaxLength(550)
                    .IsUnicode(false)
                    .HasColumnName("Comment");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__IdPost__2D27B809");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__IdUser__2C3393D0");
            });

            modelBuilder.Entity<Date>(entity => {
                entity.Property(e => e.Date1)
                    .HasColumnType("datetime")
                    .HasColumnName("Date");

                entity.Property(e => e.Description)
                    .HasMaxLength(550)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserFirstNavigation)
                    .WithMany(p => p.DateIdUserFirstNavigations)
                    .HasForeignKey(d => d.IdUserFirst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dates__IdUserFir__3F466844");

                entity.HasOne(d => d.IdUserSecondNavigation)
                    .WithMany(p => p.DateIdUserSecondNavigations)
                    .HasForeignKey(d => d.IdUserSecond)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dates__IdUserSec__403A8C7D");
            });

            modelBuilder.Entity<Degree>(entity => {
                entity.ToTable("Degree");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hobby>(entity => {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity => {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Message1)
                    .HasMaxLength(1200)
                    .IsUnicode(false)
                    .HasColumnName("Message");

                entity.HasOne(d => d.IdUserRecieveNavigation)
                    .WithMany(p => p.MessageIdUserRecieveNavigations)
                    .HasForeignKey(d => d.IdUserRecieve)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__IdUser__3C69FB99");

                entity.HasOne(d => d.IdUserSendNavigation)
                    .WithMany(p => p.MessageIdUserSendNavigations)
                    .HasForeignKey(d => d.IdUserSend)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__IdUser__3B75D760");
            });

            modelBuilder.Entity<Post>(entity => {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(550)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__IdUser__29572725");
            });

            modelBuilder.Entity<PostImage>(entity => {
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.PostImages)
                    .HasForeignKey(d => d.IdPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PostImage__IdPos__35BCFE0A");
            });

            modelBuilder.Entity<SocialNetwork>(entity => {
                entity.Property(e => e.Link)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.SocialNetworks)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SocialNet__IdUse__38996AB5");
            });

            modelBuilder.Entity<User>(entity => {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(550)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImageProfile)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDegreeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdDegree)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__IdDegree__267ABA7A");
            });

            modelBuilder.Entity<UserHobby>(entity => {
                entity.HasOne(d => d.IdHobbieNavigation)
                    .WithMany(p => p.UserHobbies)
                    .HasForeignKey(d => d.IdHobbie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserHobbi__IdHob__32E0915F");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserHobbies)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserHobbi__IdUse__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}