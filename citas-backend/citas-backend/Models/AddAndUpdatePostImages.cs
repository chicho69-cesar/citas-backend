namespace citas_backend.Models {
    public class AddAndUpdatePostImages {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int IdPost { get; set; }
    }
}