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
    public class CategoriasBLL
    {
        public static bool Guardar(Categorias Categoria)
        {
            if (!Existe(Categoria.CategoriaId))
                return Insertar(Categoria);
            else
                return Modificar(Categoria);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Categorias.Any(m => m.CategoriaId == id);
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

        public static bool Insertar(Categorias Categoria)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Categorias.Add(Categoria);
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

        public static bool Modificar(Categorias Categoria)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Categoria).State = EntityState.Modified;
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

        public static Categorias Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Categorias Categoria;

            try
            {
                Categoria = contexto.Categorias.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Categoria;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var Categoria = contexto.Categorias.Find(id);

                if (Categoria != null)
                {
                    contexto.Categorias.Remove(Categoria);
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

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> criterio)
        {
            List<Categorias> listaCategorias = new List<Categorias>();
            Contexto contexto = new Contexto();

            try
            {
                listaCategorias = contexto.Categorias.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaCategorias;
        }
    }
}
