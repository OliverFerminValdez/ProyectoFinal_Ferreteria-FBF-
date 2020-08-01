using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class MarcasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Marcas marca = new Marcas();
            bool paso = false;

            marca.MarcaId = 0;
            marca.Descripcion = "Titanium";
            marca.UsuarioId = 1;

            paso = MarcasBLL.Guardar(marca);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = MarcasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Marcas marca = new Marcas();
            bool paso = false;

            marca.MarcaId = 0;
            marca.Descripcion = "Titanium";
            marca.UsuarioId = 1;

            paso = MarcasBLL.Insertar(marca);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Marcas marca = new Marcas();
            bool paso = false;

            marca.MarcaId = 2;
            marca.Descripcion = "Titanium";
            marca.UsuarioId = 1;

            paso = MarcasBLL.Modificar(marca);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Marcas marca = new Marcas();
            bool paso = false;

            marca = MarcasBLL.Buscar(1);

            if (marca != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = MarcasBLL.Eliminar(3);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Marcas> lista = MarcasBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}
