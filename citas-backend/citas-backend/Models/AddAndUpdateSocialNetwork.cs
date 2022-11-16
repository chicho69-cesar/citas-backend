namespace citas_backend.Models {
    public class AddAndUpdateSocialNetwork {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public int IdUser { get; set; }
    }
}
