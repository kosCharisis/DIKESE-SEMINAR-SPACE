using DIKESE.Data.Enums;
using DIKESE.Data.Static;
using DIKESE.Models;
using Microsoft.AspNetCore.Identity;


namespace DIKESE.Data
{
    public class DikeseDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DikeseDbContext>();

                context.Database.EnsureCreated();

                //Rooms
                if (!context.Rooms.Any())
                {
                    context.Rooms.AddRange(new List<Room>()
                    {
                        new Room()
                        {
                            Name = "Auditorium 1",
                            Logo = "https://picsum.photos/id/87/1280/960",
                            Description = "Name of the first room"
                        },
                        new Room()
                        {
                            Name = "Auditorium 2",
                            Logo = "https://picsum.photos/id/84/1280/848",
                            Description = "Name of the second room"
                        },
                        new Room()
                        {
                            Name = "Auditorium 3",
                            Logo = "https://picsum.photos/id/85/1280/774",
                            Description = "Name of the third room"
                        },
                        new Room()
                        {
                            Name = "Auditorium 4",
                            Logo = "https://picsum.photos/id/88/1280/1707",
                            Description = "Name of the forth room"
                        },
                        new  Room()
                        {
                            Name = "Auditorium 5",
                            Logo = "https://picsum.photos/id/81/5000/3250",
                            Description = "Name of the fifth room"
                        },
                    });
                    context.SaveChanges();
                }
                //Speakers
                if (!context.Speakers.Any())
                {
                    context.Speakers.AddRange(new List<Speaker>()
                    {
                        new Speaker()
                        {
                            FullName = "Speaker 1",
                            Bio = "This is the Bio of the first Speaker",
                            ProfilePictureURL = "https://picsum.photos/id/64/4326/2884"

                        },
                        new Speaker()
                        {
                            FullName = "Speaker 2",
                            Bio = "This is the Bio of the second Speaker",
                            ProfilePictureURL = "https://picsum.photos/id/91/3504/2336"
                        },
                        new Speaker()
                        {
                            FullName = "Speaker 3",
                            Bio = "This is the Bio of the third Speaker",
                            ProfilePictureURL = "https://picsum.photos/id/103/2592/1936"
                        },
                        new Speaker()
                        {
                            FullName = "Speaker 4",
                            Bio = "This is the Bio of the forth Speaker",
                            ProfilePictureURL = "https://picsum.photos/id/281/4928/3264"
                        },
                        new Speaker()
                        {
                            FullName = "Speaker 5",
                            Bio = "This is the Bio of the firth Speaker",
                            ProfilePictureURL = "https://picsum.photos/id/331/3648/2432"
                        }
                    });
                    context.SaveChanges();
                }
                //Sponsors
                if (!context.Sponsors.Any())
                {
                    context.Sponsors.AddRange(new List<Sponsor>()
                    {
                        new Sponsor()
                        {
                            FullName = "Sponsor 1",
                            Bio = "This is the Detail of the first Sponsor",
                            ProfilePictureURL = "https://picsum.photos/id/122/4147/2756"

                        },
                        new Sponsor()
                        {
                            FullName = "Sponsor 2",
                            Bio = "This is the Detail of the second Sponsor",
                            ProfilePictureURL = "https://picsum.photos/id/142/4272/2848"
                        },
                        new Sponsor()
                        {
                            FullName = "Sponsor 3",
                            Bio = "This is the Detail of the third Sponsor",
                            ProfilePictureURL = "https://picsum.photos/id/164/1200/800"
                        },
                        new Sponsor()
                        {
                            FullName = "Sponsor 4",
                            Bio = "This is the Detail of the forth Sponsor",
                            ProfilePictureURL = "https://picsum.photos/id/193/3578/2451"
                        },
                        new Sponsor()
                        {
                            FullName = "Sponsor 5",
                            Bio = "This is the Detail of the fifth Sponsor",
                            ProfilePictureURL = "https://picsum.photos/id/234/2048/2048"
                        }
                    });
                    context.SaveChanges();
                }
                //Seminars
                if (!context.Seminars.Any())
                {
                    context.Seminars.AddRange(new List<Seminar>()
                    {
                        new Seminar()
                        {
                            Name = "Advance Math",
                            Description = "This is the Advance Math description",
                            Price = 10.00,
                            ImageURL = "https://picsum.photos/id/163/2000/1333",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            RoomId = 1,
                            SponsorId = 1,
                            SeminarCategory = SeminarCategory.Academic
                        },
                        new Seminar()
                        {
                            Name = "Finance",
                            Description = "This is the Finance description",
                            Price = 20.00,
                            ImageURL = "https://picsum.photos/id/180/2400/1600",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            RoomId = 2,
                            SponsorId = 2,
                            SeminarCategory = SeminarCategory.Corporate
                        },
                        new Seminar()
                        {
                            Name = "Drilling",
                            Description = "This is the Drilling description",
                            Price = 30.00,
                            ImageURL = "https://picsum.photos/id/315/2100/1500",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            RoomId = 3,
                            SponsorId = 3,
                            SeminarCategory = SeminarCategory.Technical
                        },
                        new Seminar()
                        {
                            Name = "Ethics",
                            Description = "This is the Ethics description",
                            Price = 40.00,
                            ImageURL = "https://picsum.photos/id/367/4928/3264",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            RoomId = 4,
                            SponsorId = 4,
                            SeminarCategory = SeminarCategory.Corporate
                        },
                        new Seminar()
                        {
                            Name = "Well Being",
                            Description = "This is the Well Being description",
                            Price = 50.00,
                            ImageURL = "https://picsum.photos/id/305/4928/3264",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            RoomId = 5,
                            SponsorId = 5,
                            SeminarCategory = SeminarCategory.Motinational
                        },
                        new Seminar()
                        {
                            Name = "Home Improvement",
                            Description = "This is the Home Improvement description",
                            Price = 10.00,
                            ImageURL = "https://picsum.photos/id/76/4912/3264",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            RoomId = 1,
                            SponsorId = 3,
                            SeminarCategory = SeminarCategory.Workshop
                        }
                    });
                    context.SaveChanges();
                }
                //Speakers Seminars
                if (!context.Speakers_Seminars.Any())
                {
                    context.Speakers_Seminars.AddRange(new List<Speaker_Seminar>()
                    {
                        new Speaker_Seminar()
                        {
                            SpeakerId = 1,
                            SeminarId = 1
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 2,
                            SeminarId = 1
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 3,
                            SeminarId = 1
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 2,
                            SeminarId = 2
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 3,
                            SeminarId = 2
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 4,
                            SeminarId = 2
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 5,
                            SeminarId = 2
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 1,
                            SeminarId = 2
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 2,
                            SeminarId = 3
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 3,
                            SeminarId = 3
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 4,
                            SeminarId = 3
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 5,
                            SeminarId = 3
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 1,
                            SeminarId = 4
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 3,
                            SeminarId = 4
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 5,
                            SeminarId = 4
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 4,
                            SeminarId = 4
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 1,
                            SeminarId = 5
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 3,
                            SeminarId = 5
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 4,
                            SeminarId = 5
                        },

                        new Speaker_Seminar()
                        {
                            SpeakerId = 5,
                            SeminarId = 5
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@dikese.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Dikese1!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@dikese.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Dikese1!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}