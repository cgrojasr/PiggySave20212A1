using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BL.Tools;
using UPC.PiggySave.DA;
using UPC.PiggySave.DA.Tools;

namespace UPC.PiggySave.BL
{
    interface IBancoBL {
        Banco Registrar(Banco objBanco);
        bool Modificar(Banco objBanco);
        Banco Buscar(int idBanco);
        bool Eliminar(int idBanco);
        IEnumerable<Banco> ListarPorActivo(bool activo);
    }

    public class BancoBL : IBancoBL
    {
        BancoDA objBancoDA;
        public BancoBL()
        {
            objBancoDA = new BancoDA();
        }

        public Banco Buscar(int idBanco)
        {
            try
            {
                return objBancoDA.Buscar(idBanco);
            }
            catch (DAException DAex)
            {
                throw new PiggySaveException(DAex.Message);
            }
            catch (Exception ex)
            {
                var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                throw new PiggySaveException(objBLException.Message);
            }
        }

        public bool Eliminar(int idBanco)
        {
            try
            {
                return objBancoDA.Eliminar(idBanco);
            }
            catch (DAException DAex)
            {
                throw new PiggySaveException(DAex.Message);
            }
            catch (Exception ex)
            {
                var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                throw new PiggySaveException(objBLException.Message);
            }
        }

        public IEnumerable<Banco> ListarPorActivo(bool activo)
        {
            try
            {
                return objBancoDA.ListarPorActivo(activo);
            }
            catch (DAException DAex)
            {
                throw new PiggySaveException(DAex.Message);
            }
            catch (Exception ex)
            {
                var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                throw new PiggySaveException(objBLException.Message);
            }
        }

        public bool Modificar(Banco objBanco)
        {
            try
            {
                objBanco.fechaModifico = DateTime.Now;
                return objBancoDA.Modificar(objBanco);
            }
            catch(DAException DAex)
            {
                throw new PiggySaveException(DAex.Message);
            }
            catch (Exception ex)
            {
                var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                throw new PiggySaveException(objBLException.Message);
            }
        }

        public Banco Registrar(Banco objBanco)
        {
            try
            {
                objBanco.fechaRegistro = DateTime.Now;
                return objBancoDA.Registrar(objBanco);
            }
            catch (DAException DAex)
            {
                throw new PiggySaveException(DAex.Message);
            }
            catch (Exception ex)
            {
                var objBLException = new BLException(BLConstants.ExceptionMessage, ex);
                throw new PiggySaveException(objBLException.Message);
            }
        }
    }
}
