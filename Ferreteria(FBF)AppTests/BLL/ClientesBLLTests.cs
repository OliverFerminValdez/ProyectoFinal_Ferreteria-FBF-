using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Clientes cliente = new Clientes();
            bool paso = false;

            cliente.ClienteId = 0;
            cliente.Nombre = "Martinsito";
            cliente.Apellido = "Brito Diaz";
            cliente.Cedula = "05633030523";
            cliente.Telefono = "8095847013";
            cliente.Dirección = "Nagua";
            cliente.Email = "MartinsitoBD@gmail.com";
            cliente.LimiteCredito = 4000;
            cliente.UsuarioId = 1;

            paso = ClientesBLL.Guardar(cliente);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = ClientesBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Clientes cliente = new Clientes();
            bool paso = false;

            cliente.ClienteId = 0;
            cliente.Nombre = "Martin";
            cliente.Apellido = "Brito Gabriel";
            cliente.Cedula = "05633030523";
            cliente.Telefono = "8095847013";
            cliente.Dirección = "Nagua";
            cliente.Email = "MartinsitoBD@gmail.com";
            cliente.LimiteCredito = 4000;
            cliente.UsuarioId = 1;

            paso = ClientesBLL.Insertar(cliente);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Clientes cliente = new Clientes();
            bool paso = false;

            cliente.ClienteId = 3;
            cliente.Nombre = "Oliver";
            cliente.Apellido = "Fermin Valdez";
            cliente.Cedula = "05633030523";
            cliente.Telefono = "8095847013";
            cliente.Dirección = "Castillo";
            cliente.Email = "OliverJF@gmail.com";
            cliente.LimiteCredito = 4000;
            cliente.UsuarioId = 1;

            paso = ClientesBLL.Modificar(cliente);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Clientes cliente = new Clientes();
            bool paso = false;

            cliente = ClientesBLL.Buscar(1);

            if (cliente != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = ClientesBLL.Eliminar(3);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Clientes> lista = ClientesBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}