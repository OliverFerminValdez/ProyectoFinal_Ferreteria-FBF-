using Ferreteria_FBF_App.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto _contexto;
        public RepositorioBase()
        {
            _contexto = new Contexto();
        }
        public T Buscar(int id)
        {
            T entity;

            try
            {
                entity = _contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            T entity;

            try
            {
                entity = _contexto.Set<T>().Find(id);

                if (entity != null)
                {
                    _contexto.Set<T>().Remove(entity);
                    paso = (_contexto.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Existe(int id)
        {
            T entity;
            bool encontrado = false;

            try
            {
                entity = _contexto.Set<T>().Find(id);

                if (entity != null)
                    encontrado = true;
            }
            catch (Exception)
            {
                throw;
            }

            return encontrado;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> lista = new List<T>();

            try
            {
                lista = _contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public bool Guardar(T entity, int id)
        {
            if (!Existe(id))
                return Insertar(entity);
            else
                return Modificar(entity);
        }

        public bool Insertar(T entity)
        {
            bool paso = false;

            try
            {
                _contexto.Set<T>().Add(entity);
                paso = (_contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Modificar(T entity)
        {
            bool paso = false;

            try
            {
                _contexto.Entry(entity).State = EntityState.Modified;
                paso = (_contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
    }
}
