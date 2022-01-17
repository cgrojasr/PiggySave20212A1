using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.BL
{
    public interface IUsuarioBL
    {
        Usuario Registrar(Usuario objUsuario);
        bool Modificar(Usuario objUsuario);
        bool Eliminar(int idUsuario);
        Usuario Buscar(int idUsuario);
    }

    public class UsuarioBL : IUsuarioBL
    {
        public Usuario Buscar(int idUsuario)
        {
            var objUsuarioDA = new UsuarioDA();
            try
            {
                return objUsuarioDA.Buscar(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idUsuario)
        {
            var objUsuarioDA = new UsuarioDA();
            try
            {
                return objUsuarioDA.Eliminar(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(Usuario objUsuario)
        {
            var objUsuarioDA = new UsuarioDA();
            try
            {
                return objUsuarioDA.Modificar(objUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Registrar(Usuario objUsuario)
        {
            var objUsuarioDA = new UsuarioDA();
            try
            {
                return objUsuarioDA.Registrar(objUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
