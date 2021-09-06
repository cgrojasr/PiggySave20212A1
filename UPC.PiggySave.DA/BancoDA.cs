﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.PiggySave.DA.Tools;

namespace UPC.PiggySave.DA
{
    interface IBancoDA {
        IEnumerable<Banco> ListarPorActivo(bool activo);
        Banco Registrar(Banco objBancoBE);
        bool Modificar(Banco objBancoBE);
        Banco Buscar(int idBanco);
        bool Eliminar(int idBanco);
    }
    public class BancoDA : IBancoDA
    {
        dbPiggySaveDataContext dc;
        public BancoDA()
        {
            dc = new dbPiggySaveDataContext();
        }

        public Banco Buscar(int idBanco)
        {
            try
            {
                try
                {
                    var banco = (from ban in dc.Bancos
                             where ban.idBanco.Equals(idBanco)
                             select ban).Single();

                    return banco;
                }
                catch (InvalidOperationException)
                {
                    throw new DAException(string.Format("No se encontro registros con id: {0}", idBanco));
                }
            }
            catch (DAException daex)
            {
                throw daex;
            }
            catch (Exception ex)
            {
                throw new DAException(DAConstants.ExceptionMessage, ex);
            }
        }

        public bool Eliminar(int idBanco)
        {
            try
            {
                var objBanco = (from banco in dc.Bancos
                                where banco.idBanco.Equals(idBanco)
                                select banco).Single();

                dc.Bancos.DeleteOnSubmit(objBanco);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new DAException(DAConstants.ExceptionMessage, ex);
            }
        }

        public IEnumerable<Banco> ListarPorActivo(bool activo)
        {
            try
            {
                try
                {
                    var lista = from ban in dc.Bancos
                                where ban.activo.Equals(activo)
                                select ban;

                    return lista;
                }
                catch (InvalidOperationException)
                {
                    throw new DAException("No se encontro registros con el parametro ingresado");
                }
            }
            catch (DAException daex)
            {
                throw daex;
            }
            catch (Exception ex)
            {
                throw new DAException(DAConstants.ExceptionMessage, ex);
            }
        }

        public bool Modificar(Banco objBanco)
        {
            bool exito;
            try
            {
                var query = (from banco in dc.Bancos
                             where banco.idBanco.Equals(objBanco.idBanco)
                             select banco).Single();

                query.nombre = objBanco.nombre;
                query.abreviatura = objBanco.abreviatura;
                query.fechaModifico = DateTime.Now;
                query.idUsuarioModifico = objBanco.idUsuarioRegistro;

                dc.SubmitChanges();
                exito = true;
            }
            catch (Exception ex)
            {
                throw new DAException(DAConstants.ExceptionMessage, ex);
            }

            return exito;
        }

        public Banco Registrar(Banco objBanco)
        {
            try
            {
                dc.Bancos.InsertOnSubmit(objBanco);
                dc.SubmitChanges();

                return objBanco;
            }
            catch (Exception ex)
            {
                throw new DAException(DAConstants.ExceptionMessage, ex);
            }
        }
    }
}
