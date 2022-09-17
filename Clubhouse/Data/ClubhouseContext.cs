using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clubhouse.Models;

namespace Clubhouse.Data
{
    public class ClubhouseContext : DbContext
    {
        public ClubhouseContext (DbContextOptions<ClubhouseContext> options)
            : base(options)
        {
        }

        public DbSet<Clubhouse.Models.User> User { get; set; } = default!;
    }
}
