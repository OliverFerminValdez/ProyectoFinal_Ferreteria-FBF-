using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class CobrosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Cobros cobro = new Cobros();
            bool paso = false;

            cobro.CobroId = 0;
            cobro.ClienteId = 1;
            cobro.Balance = 0;
            cobro.Monto = 500;
            cobro.Fecha = DateTime.Now;
            cobro.UsuarioId = 1;

            paso = CobrosBLL.Guardar(cobro);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = CobrosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Cobros cobro = new Cobros();
            bool paso = false;

            cobro.CobroId = 0;
            cobro.ClienteId = 1;
            cobro.Balance = 0;
            cobro.Monto = 500;
            cobro.Fecha = DateTime.Now;
            cobro.UsuarioId = 1;

            paso = CobrosBLL.Insertar(cobro);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Cobros cobro = new Cobros();
            bool paso = false;

            cobro.CobroId = 1;
            cobro.ClienteId = 1;
            cobro.Balance = 0;
            cobro.Monto = 500;
            cobro.Fecha = DateTime.Now;
            cobro.UsuarioId = 1;

            paso = CobrosBLL.Modificar(cobro);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Cobros cobro = new Cobros();
            bool paso = false;

            cobro = CobrosBLL.Buscar(1);

            if (cobro != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = CobrosBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Cobros> lista = CobrosBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}