using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ferreteria_FBF_App.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Ferreteria_FBF_App.Models;

namespace Ferreteria_FBF_App.BLL.Tests
{
    [TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Ventas venta = new Ventas();
            VentasDetalle ventasDetalle = new VentasDetalle();

            venta.VentaId = 0;
            venta.ClienteId = 1;
            venta.Fecha = DateTime.Now;
            venta.Comentario = "Primera venta a este cliente";
            venta.Descuentos = 0;
            venta.Fecha = DateTime.Now;
            venta.Total = 500;
            venta.TotalGeneral = 590;
            venta.ITBIS = 90;
            venta.Tipo = "Credito";
            venta.UsuarioId = 1;

            ventasDetalle.VentasDetalleId = 0;
            ventasDetalle.VentaId = 0;
            ventasDetalle.Precio = 500;
            ventasDetalle.ProductoId = 1;
            ventasDetalle.Cantidad = 1;

            venta.VentasDetalle.Add(ventasDetalle);

            paso = VentasBLL.Guardar(venta);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = VentasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso = false;
            Ventas venta = new Ventas();
            VentasDetalle ventasDetalle = new VentasDetalle();

            venta.VentaId = 0;
            venta.ClienteId = 1;
            venta.Fecha = DateTime.Now;
            venta.Comentario = "Primera venta a este cliente";
            venta.Descuentos = 0;
            venta.Fecha = DateTime.Now;
            venta.Total = 500;
            venta.TotalGeneral = 590;
            venta.ITBIS = 90;
            venta.Tipo = "Credito";
            venta.UsuarioId = 1;

            ventasDetalle.VentasDetalleId = 0;
            ventasDetalle.VentaId = 0;
            ventasDetalle.Precio = 500;
            ventasDetalle.ProductoId = 1;
            ventasDetalle.Cantidad = 1;

            venta.VentasDetalle.Add(ventasDetalle);

            paso = VentasBLL.Insertar(venta);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Ventas venta = new Ventas();
            VentasDetalle ventasDetalle = new VentasDetalle();

            venta.VentaId = 1;
            venta.ClienteId = 1;
            venta.Fecha = DateTime.Now;
            venta.Comentario = "Primera venta a este cliente";
            venta.Descuentos = 0;
            venta.Fecha = DateTime.Now;
            venta.Total = 500;
            venta.TotalGeneral = 590;
            venta.ITBIS = 90;
            venta.Tipo = "Credito";
            venta.UsuarioId = 1;

            ventasDetalle.VentasDetalleId = 1;
            ventasDetalle.VentaId = 1;
            ventasDetalle.Precio = 500;
            ventasDetalle.ProductoId = 1;
            ventasDetalle.Cantidad = 1;

            venta.VentasDetalle.Add(ventasDetalle);

            paso = VentasBLL.Modificar(venta);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ventas venta = new Ventas();
            bool paso = false;

            venta = VentasBLL.Buscar(1);

            if (venta != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = VentasBLL.Eliminar(2);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;

            List<Ventas> lista = VentasBLL.GetList(l => true);

            if (lista != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}