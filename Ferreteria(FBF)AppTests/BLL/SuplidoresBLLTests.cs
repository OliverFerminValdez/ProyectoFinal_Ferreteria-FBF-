using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Suplidores suplidor = new Suplidores();
            bool paso = false;

            suplidor.SuplidorId = 0;
            suplidor.Nombre = "Ochoa";
            suplidor.UsuarioId = 1;

            paso = SuplidoresBLL.Guardar(suplidor);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = SuplidoresBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Suplidores suplidor = new Suplidores();
            bool paso = false;

            suplidor.SuplidorId = 0;
            suplidor.Nombre = "Ochoa";
            suplidor.UsuarioId = 1;

            paso = SuplidoresBLL.Insertar(suplidor);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Suplidores suplidor = new Suplidores();
            bool paso = false;

            suplidor.SuplidorId = 1;
            suplidor.Nombre = "Americana";
            suplidor.UsuarioId = 1;

            paso = SuplidoresBLL.Modificar(suplidor);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Suplidores suplidor = new Suplidores();
            bool paso = false;

            suplidor = SuplidoresBLL.Buscar(1);

            if (suplidor != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = SuplidoresBLL.Eliminar(3);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Suplidores> lista = SuplidoresBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}