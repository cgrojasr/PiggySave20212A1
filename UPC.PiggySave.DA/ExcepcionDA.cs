using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.DA
{
    interface IExcepcionDA
    {
        void Registro(Excepcion objExcepcion);
    }

    public class ExcepcionDA : IExcepcionDA
    {
        dbPiggySaveDataContext dc;
        public ExcepcionDA()
        {
            dc = new dbPiggySaveDataContext();
        }

        public void Registro(Excepcion objExcepcion)
        {
            dc.Excepcions.InsertOnSubmit(objExcepcion);
            dc.SubmitChanges();
        }
    }
}
