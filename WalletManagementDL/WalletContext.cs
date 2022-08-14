using Microsoft.EntityFrameworkCore;
using System;
using WalletManagementEntity;

namespace WalletManagementDL
{
    public class WalletContext : DbContext
    {
        //Map table to the database
        public DbSet<User> UserModels { get; set; }
        public DbSet<Card> CardModels { get; set; }

        public WalletContext(DbContextOptions options) : base(options)
        {

        }
        public WalletContext()
        {

        }

    }
}
