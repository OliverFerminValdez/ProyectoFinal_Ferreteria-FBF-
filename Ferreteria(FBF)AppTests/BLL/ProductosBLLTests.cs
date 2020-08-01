using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Productos producto = new Productos();
            bool paso = false;

            producto.ProductoId = 0;
            producto.Descripción = "Martillo";
            producto.Unidad = "Unidades";
            producto.MarcaId = 1;
            producto.PrecioUnitario = 500;
            producto.Inventario = 0;
            producto.ValorInventario = 0;
            producto.UsuarioId = 1;


            paso = ProductosBLL.Guardar(producto);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = ProductosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Productos producto = new Productos();
            bool paso = false;

            producto.ProductoId = 0;
            producto.Descripción = "Martillo";
            producto.Unidad = "Unidades";
            producto.MarcaId = 1;
            producto.PrecioUnitario = 500;
            producto.Inventario = 0;
            producto.ValorInventario = 0;
            producto.UsuarioId = 1;

            paso = ProductosBLL.Insertar(producto);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Productos producto = new Productos();
            bool paso = false;

            producto.ProductoId = 3;
            producto.Descripción = "Martillo";
            producto.Unidad = "Unidades";
            producto.MarcaId = 1;
            producto.PrecioUnitario = 500;
            producto.Inventario = 0;
            producto.ValorInventario = 0;
            producto.UsuarioId = 1;

            paso = ProductosBLL.Modificar(producto);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Productos producto = new Productos();
            bool paso = false;

            producto = ProductosBLL.Buscar(1);

            if (producto != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = ProductosBLL.Eliminar(2);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Productos> lista = ProductosBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}