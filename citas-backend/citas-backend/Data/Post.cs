using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            PostImages = new HashSet<PostImage>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int Likes { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
