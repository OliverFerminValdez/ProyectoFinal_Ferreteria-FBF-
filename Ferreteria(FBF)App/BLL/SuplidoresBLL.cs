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
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores Suplidor)
        {
            if (!Existe(Suplidor.SuplidorId))
                return Insertar(Suplidor);
            else
                return Modificar(Suplidor);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Suplidores.Any(m => m.SuplidorId == id);
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

        public static bool Insertar(Suplidores Suplidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Suplidores.Add(Suplidor);
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

        public static bool Modificar(Suplidores Suplidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Suplidor).State = EntityState.Modified;
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

        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores Suplidor;

            try
            {
                Suplidor = contexto.Suplidores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Suplidor;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var Suplidor = contexto.Suplidores.Find(id);

                if (Suplidor != null)
                {
                    contexto.Suplidores.Remove(Suplidor);
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

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> listaSuplidores = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                listaSuplidores = contexto.Suplidores.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaSuplidores;
        }
    }
}
