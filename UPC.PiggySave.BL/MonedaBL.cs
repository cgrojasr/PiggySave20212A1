using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA;

namespace UPC.PiggySave.BL
{
    public interface IMonedaBL {
        Moneda Registrar(Moneda objMoneda);
        Moneda Buscar(int id);
        bool Eliminar(int id);
        bool Modificar(Moneda objMoneda);
        IEnumerable<Moneda> Listar();
    }
    public class MonedaBL : IMonedaBL
    {
        private readonly MonedaDA objMonedaDA;

        public MonedaBL()
        {
            objMonedaDA = new MonedaDA();
        }

        public Moneda Buscar(int id)
        {
            try
            {
                return objMonedaDA.Buscar(id);
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
                return objMonedaDA.Eliminar(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Moneda> Listar()
        {
            try
            {
                return objMonedaDA.Listar();
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
                return objMonedaDA.Modificar(objMoneda);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Moneda Registrar(Moneda objMoneda)
        {
            try
            {
                return objMonedaDA.Registrar(objMoneda);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
