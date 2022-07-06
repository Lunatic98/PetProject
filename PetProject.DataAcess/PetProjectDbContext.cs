using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetProject.Domain.Entity;

namespace PetProject.DataAcess
{
    public class PetProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
