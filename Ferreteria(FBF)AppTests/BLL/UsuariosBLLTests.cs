using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios usuario = new Usuarios();
            bool paso = false;

            usuario.UsuarioId = 0;
            usuario.Nombre = "Oliver";
            usuario.Apellido = "Fermin Valdez";
            usuario.Telefono = "8095478963";
            usuario.NivelAcceso = "Empleado";
            usuario.Email = "martinsitobd@gmail.com";
            usuario.Contraseña = ("Admin123456789");
            usuario.Usuario = "User";

            paso = UsuariosBLL.Guardar(usuario);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = UsuariosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Usuarios usuario = new Usuarios();
            bool paso = false;

            usuario.UsuarioId = 0;
            usuario.Nombre = "Oliver";
            usuario.Apellido = "Fermin Valdez";
            usuario.Telefono = "8095478963";
            usuario.NivelAcceso = "Empleado";
            usuario.Email = "martinsitobd@gmail.com";
            usuario.Contraseña = ("SolucionesFB020202003");
            usuario.Usuario = "Admin";

            paso = UsuariosBLL.Insertar(usuario);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Usuarios usuario = new Usuarios();
            bool paso = false;

            usuario.UsuarioId = 1;
            usuario.Nombre = "Oliver";
            usuario.Apellido = "Fermin Valdez";
            usuario.Telefono = "8095478963";
            usuario.NivelAcceso = "Empleado";
            usuario.Email = "martinsitobd@gmail.com";
            usuario.Contraseña = ("Admin123456789");
            usuario.Usuario = "User";

            paso = UsuariosBLL.Modificar(usuario);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Usuarios usuario = new Usuarios();
            bool paso = false;

            usuario = UsuariosBLL.Buscar(1);

            if (usuario != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = UsuariosBLL.Eliminar(3);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Usuarios> lista = UsuariosBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ComprobarUsuarioTest()
        {
            bool paso = false;
            
            paso = UsuariosBLL.ComprobarUsuario("Admin", "SolucionesFB020202003");

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetNivelAccesoTest()
        {
            string usuario;
            bool paso = false;

            usuario = UsuariosBLL.GetNivelAcceso("Admin");

            foreach (var item in UsuariosBLL.GetList(u => true))
            {
                if (item.NivelAcceso == usuario)
                {
                    paso = true;
                    break;
                }
            }

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest1()
        {
            Usuarios usuario = new Usuarios();
            bool paso = false;

            usuario = UsuariosBLL.Buscar("Admin");

            if (usuario != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}