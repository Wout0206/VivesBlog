using Microsoft.EntityFrameworkCore;
using VivesBlog.Ui.Mvc.Models;

namespace VivesBlog.Ui.Mvc.Core
{
    public class VivesBlogDbContext: DbContext
    {
        public VivesBlogDbContext(DbContextOptions<VivesBlogDbContext> options): base(options)
        {
            
        }

        public DbSet<Article> Articles => Set<Article>();

        public void Seed()
        {
            for (int i = 1; i <= 10; i++)
            {
                Articles.Add(new Article
                {
                    Id = i,
                    Title = $"Article title {i}",
                    Description = $"This is about article {i}",
                    Content = $"The full content of article {i}",
                    Author = $"Bavo{i} Ketels{i}",
                    CreatedDate = DateTime.UtcNow.AddHours(-i)
                });
            }

            SaveChanges();
        }
    }
}
