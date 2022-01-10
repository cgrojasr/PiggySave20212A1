using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.BL
{
    public interface IUsuarioBL {
        Usuario Registrar(Usuario objUsuario);
    }

    public class UsuarioBL : IUsuarioBL
    {
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
