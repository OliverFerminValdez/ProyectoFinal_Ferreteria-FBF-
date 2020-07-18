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
            dbContext.UseSqlite(@"Data Source = DATA\FerreteriaFBF.db");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Usuarios>().HasData(new Usuarios {
                UsuarioId = 1,
                Nombre = "Soluciones",
                Apellido = "FB",
                Usuario = "Admin",
                Contraseña = Encriptar("123456789"),
                Email = "FerreteriaFBF@gmail.com",
                NivelAcceso = "Administrador",
                Telefono = "8095883505"
            }); 
            
        }

        public static string Encriptar(string contraseña)//Esta función encripta la cadena que se le pasa por parámentro
        {
            string resultado = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(contraseña);
            resultado = Convert.ToBase64String(encryted);
            return resultado;
        }
    }
}
