using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA.Interfaces;

namespace UPC.PiggySave.DA
{
    public class UsuarioDA : IUsuarioDA
    {
        private readonly dbPiggySaveDataContext dc;
        public UsuarioDA()
        {
            dc = new dbPiggySaveDataContext(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
        }

        public Usuario Buscar(int id)
        {
            try
            {
                var query = (from usu in dc.Usuarios
                            where usu.idUsuario.Equals(id)
                            select usu).Single();

                return query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var usuario = (from usu in dc.Usuarios
                               where usu.idUsuario.Equals(id)
                               select usu).Single();

                dc.Usuarios.DeleteOnSubmit(usuario);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(Usuario objUsuario)
        {
            try
            {
                var usuario = (from usu in dc.Usuarios
                               where usu.idUsuario.Equals(objUsuario.idUsuario)
                               select usu).Single();

                usuario.nombre = objUsuario.nombre;
                usuario.apellido = objUsuario.apellido;
                usuario.contrasena = objUsuario.contrasena;
                usuario.email = objUsuario.email;
                usuario.fechaModifico = DateTime.Now;
                usuario.idUsuarioModifico = objUsuario.idUsuarioModifico;
                usuario.activo = objUsuario.activo;

                dc.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Registrar(Usuario objUsuario)
        {
            try
            {
                dc.Usuarios.InsertOnSubmit(objUsuario);
                dc.SubmitChanges(); //Aqui es cuando la base de datos asigna el id al objeto usuario

                return objUsuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
