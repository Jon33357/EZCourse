namespace MyEZCourse.Model
{
    public class Contact
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Url]
        public string Site { get; set; }

        [Range(0,100)]
        public int? Age { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }
    }
}
