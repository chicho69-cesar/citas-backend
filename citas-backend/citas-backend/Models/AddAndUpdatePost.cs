namespace citas_backend.Models {
    public class AddAndUpdatePost {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int Likes { get; set; }
        public int IdUser { get; set; }
    }
}
