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
    public class MarcasBLL
    {
        public static bool Guardar(Marcas marca)
        {
            if (!Existe(marca.MarcaId))
                return Insertar(marca);
            else
                return Modificar(marca);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Marcas.Any(m => m.MarcaId == id);
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

        public static bool Insertar(Marcas marca)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Marcas.Add(marca);
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

        public static bool Modificar(Marcas marca)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(marca).State = EntityState.Modified;
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

        public static Marcas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Marcas marca;

            try
            {
                marca = contexto.Marcas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return marca;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var marca = contexto.Marcas.Find(id);

                if (marca != null)
                {
                    contexto.Marcas.Remove(marca);
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

        public static List<Marcas> GetList(Expression<Func<Marcas, bool>> criterio)
        {
            List<Marcas> listaMarcas = new List<Marcas>();
            Contexto contexto = new Contexto();

            try
            {
                listaMarcas = contexto.Marcas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaMarcas;
        }
    }
}
