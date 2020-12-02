using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Blog.Core.Model
{
    public partial class InMemoryBlogContext : DbContext
    {
        public InMemoryBlogContext()
        {
        }

        public InMemoryBlogContext(DbContextOptions<InMemoryBlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogComment> BlogComments { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Database.EnsureCreated();
           
            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__BlogComment_CommentID");

                entity.ToTable("BlogComment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.BlogPostId).HasColumnName("BlogPostID");

                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.CommentedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.BlogPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogComment_Blog");
            });

            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.Property(e => e.BlogPostId).HasColumnName("BlogPostID");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.PublishedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BlogPost>().HasData(CreatePost(1), CreatePost(2), CreatePost(3));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private BlogPost CreatePost(int index)
        {
            return new BlogPost
            {
                BlogPostId = index,
                Title = $"Post {index} title",
                Body = $"Post {index} body",
                PublishedOn = new DateTime(2020, index, index),
                //BlogComments = Enumerable.Range(1, index).Select(commentIndex => CreateComment(index, commentIndex)).ToList()
            };
        }

        private BlogComment CreateComment(int postId, int index)
        {
            return new BlogComment
            {
                CommentId = index,
                BlogPostId = postId,
                CommentedOn = new DateTime(2020, index, index),
                Comment = $"Comment {index}"
            };
        }
    }
}
