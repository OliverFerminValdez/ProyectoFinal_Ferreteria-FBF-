using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class CategoriasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Categorias categoria = new Categorias();
            bool paso = false;

            categoria.CategoriaId = 0;
            categoria.Descripcion = "Hogar";
            categoria.UsuarioId = 1;

            paso = CategoriasBLL.Guardar(categoria);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = CategoriasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Categorias categoria = new Categorias();
            bool paso = false;

            categoria.CategoriaId = 0;
            categoria.Descripcion = "Hogar";
            categoria.UsuarioId = 1;

            paso = CategoriasBLL.Insertar(categoria);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Categorias categoria = new Categorias();
            bool paso = false;

            categoria.CategoriaId = 1;
            categoria.Descripcion = "Construccion";
            categoria.UsuarioId = 1;

            paso = CategoriasBLL.Modificar(categoria);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Categorias categoria = new Categorias();
            bool paso = false;

            categoria = CategoriasBLL.Buscar(1);

            if (categoria != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = CategoriasBLL.Eliminar(3);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Categorias> lista = CategoriasBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}