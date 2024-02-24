using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Hall.Models
{
    public class Entry
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "You must enter a title")]
        public string Title { get; set; }
        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public string Year { get; set; }
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; }
        [Range(0, 25)]
        public string? Notes { get; set; }

    }
}
