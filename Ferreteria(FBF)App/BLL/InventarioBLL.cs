using Ferreteria_FBF_App.DAL;
using Ferreteria_FBF_App.Models;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.BLL
{
    public class InventarioBLL
    {

        public static bool Guardar(Inventario inventario)
        {
            if (!Existe(inventario.InventarioId))
                return Insertar(inventario);
            else
                return Modificar(inventario);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Inventarios.Any(v => v.InventarioId== id);
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
        public static bool Insertar(Inventario inventario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Clientes cliente = ClientesBLL.Buscar(inventario.InventarioId);

            try
            {
                foreach (var item in inventario.Productos) //Afecta el inventario
                {
                    var Producto = ProductosBLL.Buscar(item.ProductoId);
                    Producto.Inventario += item.Inventario;
                    ProductosBLL.Modificar(Producto);
                }
                contexto.Inventarios.Add(inventario);
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

        public static bool Modificar(Inventario inventario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            var invAnterior = Buscar(inventario.InventarioId);

            try
            {

                foreach (var item in invAnterior.Productos)
                {
                    if (!invAnterior.Productos.Exists(o => o.InventarioDetalleId == item.InventarioDetalleId))
                    {
                        var producto = ProductosBLL.Buscar(item.ProductoId);
                        producto.Inventario -= item.Inventario;
                        ProductosBLL.Modificar(producto);
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in inventario.Productos)
                {
                    if (item.InventarioDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        var producto = ProductosBLL.Buscar(item.ProductoId);
                        producto.Inventario -= item.Inventario;
                        ProductosBLL.Modificar(producto);
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                        var Producto = ProductosBLL.Buscar(item.ProductoId);
                        Producto.Inventario += item.Inventario;
                        ProductosBLL.Modificar(Producto);

                    }
                }

                contexto.Entry(inventario).State = EntityState.Modified;
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

        public static Inventario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Inventario inventario;

            try
            {
                inventario = contexto.Inventarios
                    .Where(v => v.InventarioId == id)
                    .Include(v => v.Productos)
                    .FirstOrDefault();

                inventario = contexto.Inventarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return inventario;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Inventario venta = InventarioBLL.Buscar(id);

                foreach (var item in venta.Productos) //Afecta el inventario
                {
                    var Producto = ProductosBLL.Buscar(item.ProductoId);
                    Producto.Inventario += item.Inventario;
                    ProductosBLL.Modificar(Producto);
                }

                contexto.Inventarios.Remove(venta);
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

        public static List<Inventario> GetList(Expression<Func<Inventario, bool>> criterio)
        {
            List<Inventario> listaInventarios = new List<Inventario>();
            Contexto contexto = new Contexto();

            try
            {
                listaInventarios = contexto.Inventarios.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaInventarios;
        }
    }
}
