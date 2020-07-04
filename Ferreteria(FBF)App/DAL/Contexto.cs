using Ferreteria_FBF_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

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
            dbContext.UseSqlite(@"Data Source = DATA\FerreteriaFBF2.db");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Ventas>().HasData(new Ventas
            {
                VentaId = 1,
                Fecha = Convert.ToDateTime("4-6-2020"),
                ClienteId = 1,
                Total = 100,
                ITBIS = 100 * .18,
                TotalGeneral = 200,
                Tipo = "Credito",
                Descuentos = 0,
                UsuarioId = 1,
                CantidadProductos = 2
            });

            model.Entity<Ventas>().HasData(new Ventas
            {
                VentaId = 2,
                Fecha = Convert.ToDateTime("25-6-2020"),
                ClienteId = 1,
                Total = 100,
                ITBIS = 100 * .18,
                TotalGeneral = 200,
                Tipo = "Credito",
                Descuentos = 0,
                UsuarioId = 1,
                CantidadProductos = 2
            });

            model.Entity<Ventas>().HasData(new Ventas
            {
                VentaId = 3,
                Fecha = DateTime.Now,
                ClienteId = 2,
                Total = 100,
                ITBIS = 100 * .18,
                TotalGeneral = 200,
                Tipo = "Credito",
                Descuentos = 0,
                UsuarioId = 1,
                CantidadProductos = 2
            });

            model.Entity<Clientes>().HasData(new Clientes
            {
                ClienteId = 1,
                Nombre = "Oliver",
                Apellido = "Fermin",
                Cedula = "00000000000",
                LimiteCredito = 5000,
                Balance = 2000,
                Email = "Correo.com",
                Dirección = "Castillo",
                Telefono = "0000000000",
                UsuarioId = 1
            });

            model.Entity<Clientes>().HasData(new Clientes
            {
                ClienteId = 2,
                Nombre = "Antonio",
                Apellido = "Rodriguez",
                Cedula = "00000000000",
                LimiteCredito = 5000,
                Balance = 2000,
                Email = "Correo.com",
                Dirección = "Castillo",
                Telefono = "0000000000",
                UsuarioId = 1
            });
        }
    }
}
