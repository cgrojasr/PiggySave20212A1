using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA.Interfaces;
using UPC.PiggySave.DA.Tools;

namespace UPC.PiggySave.DA
{
    public class MonedaDA : IMonedaDA
    {
        private readonly dbPiggySaveDataContext dc;

        public MonedaDA()
        {
            dc = new dbPiggySaveDataContext(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
        }

        public Moneda Buscar(int id)
        {
            try
            {
                var query = (from mon in dc.Monedas
                            where mon.idMoneda.Equals(id)
                            select mon).Single();

                return query;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var query = (from mon in dc.Monedas
                             where mon.idMoneda.Equals(id)
                             select mon).Single();

                dc.Monedas.DeleteOnSubmit(query);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                return false;
            }
        }

        public IEnumerable<Moneda> Listar()
        {
            try
            {
                var query = from mon in dc.Monedas
                            select mon;

                return query;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }
        }

        public bool Modificar(Moneda objMoneda)
        {
            try
            {
                var query = (from mon in dc.Monedas
                             where mon.idMoneda.Equals(objMoneda.idMoneda)
                             select mon).Single();

                query.nombre = objMoneda.nombre;
                query.abreviatura = objMoneda.abreviatura;
                query.idUsuarioModifico = objMoneda.idUsuarioModifico;
                query.fechaModifico = DateTime.Now;

                dc.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                return false;
            }
        }

        public Moneda Registrar(Moneda objMoneda)
        {
            try
            {
                objMoneda.fechaRegistro = DateTime.Now;
                dc.Monedas.InsertOnSubmit(objMoneda);
                dc.SubmitChanges();

                return objMoneda;
            }
            catch (Exception ex)
            {
                var objException = new DAException(DAConstants.ExceptionMessage, ex);
                throw objException;
            }
        }
    }
}
