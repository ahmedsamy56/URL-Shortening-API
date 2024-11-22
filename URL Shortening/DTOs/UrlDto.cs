namespace URL_Shortening.DTOs
{
    public class UrlDto
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortCode { get; set; }
        public DateTime createdAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
    }
}
