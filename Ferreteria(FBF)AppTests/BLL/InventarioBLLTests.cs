using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;
using System.Drawing.Printing;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class InventarioBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Inventario inventario = new Inventario();
            bool paso = false;

            inventario.InventarioId = 0;
            inventario.Fecha = DateTime.Now;
            inventario.SuplidorId = 1;
            inventario.TotalInventario = 1000;

            InventarioDetalle detalle = new InventarioDetalle();
            detalle.InventarioDetalleId = 0;
            detalle.InventarioId = 0;
            detalle.ProductoId = 1;
            detalle.costo = 100;
            detalle.Inventario = 10;
            detalle.ValorInventario = 1000;

            inventario.Productos.Add(detalle);

            paso = InventarioBLL.Guardar(inventario);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = InventarioBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Inventario inventario = new Inventario();
            bool paso = false;

            inventario.InventarioId = 0;
            inventario.Fecha = DateTime.Now;
            inventario.SuplidorId = 1;
            inventario.TotalInventario = 1000;

            InventarioDetalle detalle = new InventarioDetalle();
            detalle.InventarioDetalleId = 0;
            detalle.InventarioId = 0;
            detalle.ProductoId = 1;
            detalle.costo = 100;
            detalle.Inventario = 10;
            detalle.ValorInventario = 1000;

            inventario.Productos.Add(detalle);

            paso = InventarioBLL.Insertar(inventario);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Inventario inventario = new Inventario();
            bool paso = false;

            inventario.InventarioId = 1;
            inventario.Fecha = DateTime.Now;
            inventario.SuplidorId = 2;
            inventario.TotalInventario = 1000;

            InventarioDetalle detalle = new InventarioDetalle();
            detalle.InventarioDetalleId = 1;
            detalle.InventarioId = 1;
            detalle.ProductoId = 1;
            detalle.costo = 100;
            detalle.Inventario = 10;
            detalle.ValorInventario = 1000;

            inventario.Productos.Add(detalle);

            paso = InventarioBLL.Modificar(inventario);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inventario inventario = new Inventario();
            bool paso = false;

            inventario = InventarioBLL.Buscar(1);

            if (inventario != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = InventarioBLL.Eliminar(2);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Inventario> lista = InventarioBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}