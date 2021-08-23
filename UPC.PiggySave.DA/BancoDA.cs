using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.BE;

namespace UPC.PiggySave.DA
{
    interface IBancoDA {
        int Registrar(BancoBE.Entidad objBancoBE);
        bool Modificar(BancoBE.Entidad objBancoBE);
        BancoBE.Entidad Buscar(int idBanco);
        bool Eliminar(int idBanco);
    }
    class BancoDA : IBancoDA
    {
        dbPiggySaveDataContext dc;
        public BancoDA()
        {
            dc = new dbPiggySaveDataContext();
        }

        public BancoBE.Entidad Buscar(int idBanco)
        {
            var objBancoBE = new BancoBE.Entidad();
            try
            {
                var objBanco = (from banco in dc.Bancos
                                where banco.idBanco.Equals(idBanco)
                                select banco).Single();

                objBancoBE.idBanco = objBanco.idBanco;
                objBancoBE.nombre = objBanco.nombre;
                objBancoBE.abreviatura = objBanco.abreviatura;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objBancoBE;
        }

        public bool Eliminar(int idBanco)
        {
            bool exito;
            try
            {
                var objBanco = (from banco in dc.Bancos
                                where banco.idBanco.Equals(idBanco)
                                select banco).Single();

                dc.Bancos.DeleteOnSubmit(objBanco);
                dc.SubmitChanges();

                exito = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return exito;
        }

        public bool Modificar(BancoBE.Entidad objBancoBE)
        {
            bool exito;
            try
            {
                var objBanco = (from banco in dc.Bancos
                               where banco.idBanco.Equals(objBancoBE.idBanco)
                               select banco).Single();

                objBanco.nombre = objBancoBE.nombre;
                objBanco.abreviatura = objBancoBE.abreviatura;
                objBanco.fechaModifico = DateTime.Now;
                objBanco.idUsuarioModifico = objBancoBE.idUsuarioRegistro;

                dc.SubmitChanges();
                exito = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return exito;
        }

        public int Registrar(BancoBE.Entidad objBancoBE)
        {
            int id;
            try
            {
                Banco objBanco = new Banco { 
                    nombre = objBancoBE.nombre,
                    abreviatura = objBancoBE.abreviatura,
                    fechaRegistro = objBancoBE.fechaRegistro,
                    idUsuarioRegistro = objBancoBE.idUsuarioRegistro,
                    activo = true
                };

                dc.Bancos.InsertOnSubmit(objBanco);
                dc.SubmitChanges();

                id = objBanco.idBanco;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return id;
        }
    }
}
