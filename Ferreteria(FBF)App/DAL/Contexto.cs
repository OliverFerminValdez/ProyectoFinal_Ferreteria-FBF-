using Ferreteria_FBF_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Cobros> Cobros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
        {
            dbContext.UseSqlite(@"Data Source = DATA\FerreteriaFBF.db");
        }
    }
}
