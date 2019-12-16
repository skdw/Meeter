using System;
using Microsoft.EntityFrameworkCore;

namespace Meeter.Models
{
    public class MeeterDbContext : DbContext
    {
        public MeeterDbContext(DbContextOptions<MeeterDbContext> options) : base(options) { }

        
    }
}
