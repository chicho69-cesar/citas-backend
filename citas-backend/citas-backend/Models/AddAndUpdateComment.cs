namespace citas_backend.Models {
    public class AddAndUpdateComment {
        public int Id { get; set; }
        public string? Comment1 { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        public int IdPost { get; set; }
    }
}
