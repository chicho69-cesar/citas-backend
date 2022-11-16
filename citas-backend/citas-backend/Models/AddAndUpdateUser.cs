namespace citas_backend.Models {
    public class AddAndUpdateUser {
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
    }
}
