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
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobro)
        {
            if (!Existe(cobro.CobroId))
                return Insertar(cobro);
            else
                return Modificar(cobro);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Cobros.Any(c => c.CobroId == id);
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

        public static bool Insertar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Clientes cliente = ClientesBLL.Buscar(cobro.ClienteId);

            try
            {
                if (cobro != null)
                {
                    cliente.Balance -= cobro.Monto;
                    ClientesBLL.Modificar(cliente);
                }
                contexto.Cobros.Add(cobro);
                paso = contexto.SaveChanges() > 0;
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

        public static bool Modificar(Cobros cobro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var anterior = CobrosBLL.Buscar(cobro.CobroId);
            var MontoAnterior = anterior.Monto;
            Clientes cliente = ClientesBLL.Buscar(anterior.ClienteId);
            Clientes NuevoCliente = ClientesBLL.Buscar(cobro.ClienteId);

            try
            {
                if (anterior.ClienteId == cobro.ClienteId)
                {
                    cliente.Balance += anterior.Monto - cobro.Monto;
                    ClientesBLL.Modificar(cliente);
                }
                else
                {
                    NuevoCliente.Balance = cobro.Monto;
                    ClientesBLL.Modificar(NuevoCliente);

                    cliente.Balance -= cobro.Monto;
                    ClientesBLL.Modificar(cliente);
                }
                   
                contexto.Entry(cobro).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
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

        public static Cobros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cobros cobro;

            try
            {
                cobro = contexto.Cobros.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return cobro;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Cobros cobro = CobrosBLL.Buscar(id);

            try
            {
                if (cobro != null)
                {
                    Clientes cliente = ClientesBLL.Buscar(cobro.ClienteId);
                    cliente.Balance += cobro.Monto;
                    ClientesBLL.Modificar(cliente);
                }

                var cobrodelete = contexto.Cobros.Find(id);

                if (cobrodelete != null)
                {
                    contexto.Cobros.Remove(cobrodelete);
                    paso = contexto.SaveChanges() > 0;
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

        public static List<Cobros> GetList(Expression<Func<Cobros, bool>> criterio)
        {
            List<Cobros> listaCobros = new List<Cobros>();
            Contexto contexto = new Contexto();

            try
            {
                listaCobros = contexto.Cobros.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaCobros;
        }
    }
}
