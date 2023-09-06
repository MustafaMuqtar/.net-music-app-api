using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using musicApp.Data.Entities;
using PodcastAPI.Data.Enums;
using PodcastAPI.Models;

namespace PodcastAPI.Data
{
    public class AppInitializer
    {

        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateAsyncScope())
            {
                var _dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();


                await _dbContext.Database.EnsureCreatedAsync();
                if (!await _dbContext.Contents.AnyAsync())
                {
                    await _dbContext.Contents.AddRangeAsync(new List<Content>()

                    {
                        new Content

                        {
                          Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",


                        },
                         new Content

                        {
                          Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",


                        },

                          new Content

                        {
                          Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",


                        },

                           new Content

                        {
                          Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",


                        },

                            new Content

                        {
                         Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",


                        },

                             new Content

                        {
                          Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",


                        },

                              new Content

                        {
                          Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",


                        },

                               new Content

                        {
                         Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",


                        },

                                new Content

                        {
                          Title= "Blinding Lights",
                          Gengre= "R&B",
                          Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          DateAdded= DateTime.Now,
                          CoverImageURl="https://www.rollingstone.com/wp-content/uploads/2020/02/TheWeeknd.jpg",
                          AudioPlayerURL="https://cached-images.bonnier.news/gcs/bilder/dn-mly/47d3fe09-c049-4714-97da-084403f5e8f2.jpeg",

                        },
                    });





                    await _dbContext.SaveChangesAsync();
                }


            }
        }




        public static async Task SeedUserManager(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateAsyncScope())
            {
                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();



                if (!_userManager.Users.Any())
                {
                    var user = new User
                    {
                        UserName = "mustafa",
                        Email = "mustafa@gmail.com"
                    };

                    await _userManager.CreateAsync(user, "mustafa123");
                    await _userManager.AddToRoleAsync(user, "Member");

                    var admin = new User
                    {
                        UserName = "admin",
                        Email = "admin@gmail.com"
                    };

                    await _userManager.CreateAsync(admin, "mustafa123");
                    await _userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
                }
            }
        }

    }
}


