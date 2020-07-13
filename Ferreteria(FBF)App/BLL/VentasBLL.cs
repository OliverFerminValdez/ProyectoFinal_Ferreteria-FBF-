using Ferreteria_FBF_App.DAL;
using Ferreteria_FBF_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas venta)
        {
            if (!Existe(venta.VentaId))
                return Insertar(venta);
            else
                return Modificar(venta);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ventas.Any(v => v.VentaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        public static bool Insertar(Ventas venta)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Clientes cliente = ClientesBLL.Buscar(venta.ClienteId);

            try
            {
                if (venta != null) //Afecta el balance del cliente
                {
                    cliente.Balance += venta.TotalGeneral;
                    ClientesBLL.Modificar(cliente);
                }

                foreach (var item in venta.VentasDetalle) //Afecta el inventario
                {
                    var Producto = ProductosBLL.Buscar(item.ProductoId);
                    Producto.Inventario -= item.Cantidad;
                    ProductosBLL.Modificar(Producto);
                }
                contexto.Ventas.Add(venta);
                paso = (contexto.SaveChanges() > 0);
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Ventas venta)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            var anterior = Buscar(venta.VentaId);
            Clientes cliente = ClientesBLL.Buscar(anterior.ClienteId);
            Clientes NuevoCliente = ClientesBLL.Buscar(venta.ClienteId);

            try
            {
                if (anterior.ClienteId == venta.ClienteId)
                {
                    cliente.Balance += anterior.TotalGeneral - venta.TotalGeneral;
                    ClientesBLL.Modificar(cliente);
                }
                else
                {
                    NuevoCliente.Balance = venta.TotalGeneral;
                    ClientesBLL.Modificar(NuevoCliente);

                    cliente.Balance -= venta.TotalGeneral;
                    ClientesBLL.Modificar(cliente);
                }

                foreach (var item in anterior.VentasDetalle)
                {
                    if(!venta.VentasDetalle.Exists(o => o.VentasDetalleId == item.VentasDetalleId))
                    {
                        var producto = ProductosBLL.Buscar(item.ProductoId);
                        producto.Inventario += item.Cantidad;
                        ProductosBLL.Modificar(producto);
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in venta.VentasDetalle)
                {
                    if(item.VentasDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        var producto = ProductosBLL.Buscar(item.ProductoId);
                        producto.Inventario += item.Cantidad;
                        ProductosBLL.Modificar(producto);
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;  
                        var Producto = ProductosBLL.Buscar(item.ProductoId);
                        Producto.Inventario -= item.Cantidad;
                        ProductosBLL.Modificar(Producto);

                    }
                }

                contexto.Entry(venta).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas venta;

            try
            {
                venta = contexto.Ventas
                    .Where(v => v.VentaId == id)
                    .Include(v => v.VentasDetalle)
                    .FirstOrDefault();

                venta = contexto.Ventas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return venta;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {   
                var venta = contexto.Ventas.Find(id);
                Clientes cliente = ClientesBLL.Buscar(venta.ClienteId);

                if (venta != null) //Afecta el balance del cliente
                {
                    cliente.Balance += venta.TotalGeneral;
                    ClientesBLL.Modificar(cliente);
                }


                if (venta != null)
                {
                    foreach (var item in venta.VentasDetalle) //Afecta el inventario
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                        var Producto = ProductosBLL.Buscar(item.ProductoId);
                        Producto.Inventario -= item.Cantidad;
                    }
                    contexto.Ventas.Remove(venta);
                    paso = (contexto.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            List<Ventas> listaVentas = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                listaVentas = contexto.Ventas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaVentas;
        }
    }
}
