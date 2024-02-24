using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoelHiltonMovies.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Categories Category { get; set;}

        public string Title { get; set; }

        [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1888.")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public int Edited { get; set; }
        public string? LentTo { get; set; }
        public int CopiedToPlex { get; set; }
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}