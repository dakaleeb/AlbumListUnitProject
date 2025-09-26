using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AlbumListUnitProject.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        [Required(ErrorMessage = "Please enter a album name.")]
        public string AlbumName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter album description.")]
        public string AlbumDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int AlbumRating { get; set; }
        [Required(ErrorMessage = "Please enter a aritst name.")]
        public int ArtistID { get; set; }
        [ValidateNever]
        public Artist Artist { get; set; } = null!;
        [Required(ErrorMessage = "Please enter a genre.")]
        public int GenreID { get; set; }
        [ValidateNever]
        public Genre Genre { get; set; } = null!;

    }
}
