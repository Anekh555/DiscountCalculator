using System;
using DiscountCalculator.Model;
using Microsoft.EntityFrameworkCore;

namespace DiscountCalculator.EFLayer
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            AddDefaultUsers();
        }
        public DbSet<User> Users { get; set; }

        private void AddDefaultUsers()
        {
            var user1 = new User
            {
                Id = Guid.NewGuid(),
                username = "User1",
                password = "User1"
            };

            var user2 = new User
            {
                Id = Guid.NewGuid(),
                username = "User2",
                password = "User2"
            };

            var user3 = new User
            {
                Id = Guid.NewGuid(),
                username = "User3",
                password = "User3"
            };           
            Users.AddRange(user1, user2, user3);
            this.SaveChangesAsync();
        }
    }
}
