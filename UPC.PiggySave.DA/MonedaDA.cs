using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA.Interfaces;

namespace UPC.PiggySave.DA
{
    public class MonedaDA : IMonedaDA
    {
        private readonly dbPiggySaveDataContext dc;

        public MonedaDA()
        {
            //dc = new dbPiggySaveDataContext(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
            dc = new dbPiggySaveDataContext("Data Source=rds-upcaad01.cwytqgl1psxt.us-east-2.rds.amazonaws.com;Initial Catalog=dbPiggySave;Persist Security Info=True;User ID=admin;Password=password");
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                //Control de excepcion 
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                //Control de la excepcion
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
