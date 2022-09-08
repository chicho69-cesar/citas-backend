using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            DateIdUserFirstNavigations = new HashSet<Date>();
            DateIdUserSecondNavigations = new HashSet<Date>();
            MessageIdUserRecieveNavigations = new HashSet<Message>();
            MessageIdUserSendNavigations = new HashSet<Message>();
            Posts = new HashSet<Post>();
            SocialNetworks = new HashSet<SocialNetwork>();
            UserHobbies = new HashSet<UserHobby>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Token { get; set; }
        public string Email { get; set; } = null!;
        public string NormalizedEmail { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string NormalizedUserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? ImageProfile { get; set; }
        public int IdDegree { get; set; }

        public virtual Degree IdDegreeNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Date> DateIdUserFirstNavigations { get; set; }
        public virtual ICollection<Date> DateIdUserSecondNavigations { get; set; }
        public virtual ICollection<Message> MessageIdUserRecieveNavigations { get; set; }
        public virtual ICollection<Message> MessageIdUserSendNavigations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<SocialNetwork> SocialNetworks { get; set; }
        public virtual ICollection<UserHobby> UserHobbies { get; set; }
    }
}
