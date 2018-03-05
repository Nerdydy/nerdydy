using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;

namespace nerdydy.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            // Add test user
            var passwordHasher = new PasswordHasher();
            string testPassword = passwordHasher.HashPassword("test");

            db.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "test@benutzer.test",
                Email = "test@benutzer.test",
                PasswordHash = testPassword,
                SecurityStamp = Guid.NewGuid().ToString()
            });

            db.SaveChanges();

            // Add test Games
            db.Game.AddOrUpdate(new Game { Name = "Rainbow Six Siege", Description = "Tom Clancy’s Rainbow Six Siege ist ein taktischer Ego-Shooter, der zur Computerspielserie Rainbow Six gehört. Das Spiel wurde von Ubisoft Montreal entwickelt und von Ubisoft veröffentlicht." });
            db.Game.AddOrUpdate(new Game { Name = "Rocket League", Description = "Rocket League ist ein Computerspiel, das von Psyonix entwickelt und veröffentlicht wurde. Das Spielprinzip ähnelt am ehesten einem Autoballspiel, in dem die Spieler versuchen, einen etwas größeren Ball mit Hilfe von Autos in das gegnerische Tor zu befördern. Es besitzt Elemente von Fußball und Stockcar." });

            db.SaveChanges();

            // Add test MediaTypes
            db.MediaType.AddOrUpdate(new MediaType { Name = "Video" });
            db.MediaType.AddOrUpdate(new MediaType { Name = "Screenshot" });

            db.SaveChanges();

            // Add test Data
            // Info > GameId: 0 = R6 / 1 = RL // MediaType: 0 = Video / 1 = Screenshot 
            // -> Videos
            // --> R6
            db.GameMedia.AddOrUpdate(new GameMedia { Name = "Bandit ace on Hereford", Description = "Did some casual on us servers. Solo-queing!", Date = new DateTime(2017, 12, 3), GameId = 0, MediaTypeId = 0, Filepath = "" });
            db.GameMedia.AddOrUpdate(new GameMedia { Name = "Sick smoke play", Description = "Edit from my smoke gameplay.", Date = new DateTime(2017, 12, 4), GameId = 0, MediaTypeId = 0 });
            // --> RL
            db.GameMedia.AddOrUpdate(new GameMedia { Name = "Safe of the Day", Description = "3v3 casual play.", Date = new DateTime(2017, 12, 3), GameId = 1, MediaTypeId = 0 });
            db.GameMedia.AddOrUpdate(new GameMedia { Name = "Private matchmaking", Description = "Played with some friends", Date = new DateTime(2017, 12, 3), GameId = 1, MediaTypeId = 0 });
            // -> Screenshots
            // --> R6
            db.GameMedia.AddOrUpdate(new GameMedia { Name = "Okeh", Description = "Lorem Ipsum.", Date = new DateTime(2017, 12, 3), GameId = 0, MediaTypeId = 1 });
            db.GameMedia.AddOrUpdate(new GameMedia { Name = "Okeh 2", Description = "Lorem Ipsum tooooooooo.", Date = new DateTime(2017, 12, 3), GameId = 0, MediaTypeId = 1 });
            // --> RL
            db.GameMedia.AddOrUpdate(new GameMedia { Name = "MVP", Description = "Guess whos first.", Date = new DateTime(2017, 12, 3), GameId = 1, MediaTypeId = 1 });
            db.GameMedia.AddOrUpdate(new GameMedia { Name = "MVP 2", Description = "Guess whos second.", Date = new DateTime(2017, 12, 3), GameId = 1, MediaTypeId = 1 });

            db.SaveChanges();

        }
    }
}