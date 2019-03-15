using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Models
{
    public class Studentcontext:DbContext
    {
        public Studentcontext(DbContextOptions<Studentcontext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
