using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace AlbumListUnitProject.Models
{
    public class AlbumContext : DbContext
    {
        public AlbumContext(DbContextOptions<AlbumContext> options)
        : base(options)
        { }

        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreID = 1, GenreName = "Rap" },
                new Genre { GenreID = 2, GenreName = "RnB" },
                new Genre { GenreID = 3, GenreName = "Rock" },
                new Genre { GenreID = 4, GenreName = "EDM" },
                new Genre { GenreID = 5, GenreName = "Pop" },
                new Genre { GenreID = 6, GenreName = "Country" }
            );
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistID = 1, ArtistName = "Mac Miller" },
                new Artist { ArtistID = 2, ArtistName = "SZA" },
                new Artist { ArtistID = 3, ArtistName = "Arctic Monkeys" }
            );
            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    AlbumId = 2,
                    ArtistID = 2,
                    AlbumName = "SOS",
                    AlbumDescription = "I havn't listened to the whole album, but I love alot of the tracks on this album",
                    AlbumRating = 8,
                    GenreID = 2
                },
                new Album
                {
                    AlbumId = 1,
                    ArtistID = 1,
                    AlbumName = "Swimming",
                    AlbumDescription = "The last album made before his untimley death. It talked about his mental health from when his career started to now",
                    AlbumRating = 9,
                    GenreID = 1
                },
                new Album
                {
                    AlbumId = 3,
                    ArtistID = 3,
                    AlbumName = "AM",
                    AlbumDescription = "I love all the tracks in this one, but do I wanna know takes the cake.",
                    AlbumRating = 10,
                    GenreID = 3
                }
            );
        }
    }
}
