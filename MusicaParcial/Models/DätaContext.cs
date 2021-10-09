using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicaParcial.Models;

namespace MusicaParcial.Models
{
    public class DätaContext:DbContext
    {
        public DätaContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }

        public DbSet<MusicaParcial.Models.Cancion> Cancion { get; set; }
    }
}
