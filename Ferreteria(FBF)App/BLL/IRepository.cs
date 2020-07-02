    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.BLL
{
    public interface IRepository<T> where T: class
    {
        List<T> GetList(Expression<Func<T, bool>> expression);
        bool Guardar(T entity, int id);
        bool Eliminar(int id);
        bool Modificar(T entity);
        bool Insertar(T entity);
        bool Existe(int id);
        T Buscar(int id);
    }
}
