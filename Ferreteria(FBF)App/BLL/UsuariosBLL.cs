using Ferreteria_FBF_App.DAL;
using Ferreteria_FBF_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ferreteria_FBF_App.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.UsuarioId))
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Usuarios.Any(u => u.UsuarioId == id);
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

        public static bool Insertar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                usuario.Contraseña = Usuarios.Encriptar(usuario.Contraseña);
                contexto.Usuarios.Add(usuario);
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

        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                usuario.Contraseña = Usuarios.Encriptar(usuario.Contraseña);
                contexto.Entry(usuario).State = EntityState.Modified;
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

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuario;

            try
            {
                usuario = contexto.Usuarios.Find(id);

                if(usuario != null)
                    usuario.Contraseña = Usuarios.DesEncriptar(usuario.Contraseña);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return usuario;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var usuario = contexto.Usuarios.Find(id);

                if (usuario != null)
                {
                    contexto.Usuarios.Remove(usuario);
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

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> listaUsuarios = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                listaUsuarios = contexto.Usuarios.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaUsuarios;
        }

        public static bool ComprobarUsuario(string Usuario, string contraseña)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            string Contraseña = Usuarios.Encriptar(contraseña);

            try
            {
                if (contexto.Usuarios.Any(U => U.Usuario == Usuario && U.Contraseña == (Contraseña)))
                    paso = true;
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

        public static string GetNivelAcceso(string Usuario)
        {
            string nivel = "Empleado";
            Contexto contexto = new Contexto();

            try
            {
                nivel = contexto.Usuarios.Where(U => U.Usuario.Equals(Usuario)).Select(U => U.NivelAcceso).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return nivel;
        }

        public static Usuarios Buscar(string usuario)
        {
            Usuarios Usuario;
            Contexto contexto = new Contexto();

            try
            {
                Usuario = contexto.Usuarios.Where(U => U.Usuario == usuario).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Usuario;
        }
    }
}
