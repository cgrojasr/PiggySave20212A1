using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.PiggySave.BL;
using UPC.PiggySave.BL.Tools;
using UPC.PiggySave.DA;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BancoSOAP" in code, svc and config file together.
public class BancoSOAP : IBancoSOAP
{
    private readonly BancoBL objBancoBL;

    public BancoSOAP()
    {
        objBancoBL = new BancoBL();
    }

    /// <summary>
    /// Servicio para buscar los datos de un banco segun el identity enviado por el usuario
    /// </summary>
    /// <param name="idBanco">Identity del banco</param>
    /// <returns>Objeto con los datos del banco</returns>
    public Response<BancoModel> Buscar(int idBanco)
    {
        var response = new Response<BancoModel>();
        try
        {
            var objBanco = objBancoBL.Buscar(idBanco);
            var objBancoModel = new BancoModel()
            {
                idBanco = objBanco.idBanco,
                nombre = objBanco.nombre,
                abreviatura = objBanco.abreviatura,
                activo = objBanco.activo
            };
            response.value = objBancoModel;
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }

        return response;
    }

    /// <summary>
    /// Servicio para eliminar los datos de un banco segun el identity enviado por el usuario
    /// </summary>
    /// <param name="idBanco">Identity del banco</param>
    /// <returns>booleano que indica si el banco fue eliminado con exito o no</returns>
    public Response<bool> Eliminar(int idBanco)
    {
        var response = new Response<bool>();
        try
        {
            response.value = objBancoBL.Eliminar(idBanco);
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }

        return response;
    }

    /// <summary>
    /// Servicio para listar todos los bancos segun su flag de activo
    /// </summary>
    /// <param name="activo">boleano true si esta activo y false si no</param>
    /// <returns>Lista de bancos segun su flag de activo</returns>
    public Response<List<BancoModel>> ListarPorActivo(bool activo)
    {
        var response = new Response<List<BancoModel>>();
        try
        {
            var bancos = objBancoBL.ListarPorActivo(activo);
            var lstBancosModel = new List<BancoModel>();
            foreach(var banco in bancos)
            {
                var objBancoModel = new BancoModel()
                {
                    idBanco = banco.idBanco,
                    nombre = banco.nombre,
                    abreviatura = banco.abreviatura,
                    activo = banco.activo
                };
                lstBancosModel.Add(objBancoModel);
            }
            
            response.value = lstBancosModel;
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }

        return response;
    }

    /// <summary>
    /// Servicio para modificar la informacion de un banco
    /// </summary>
    /// <param name="objBancoModel">objeto banco con los datos a modificar</param>
    /// <returns>booleano con true si logro modificar y falso si no</returns>
    public Response<bool> Modificar(BancoModel objBancoModel)
    {
        var response = new Response<bool>();
        try
        {
            var objBanco = new Banco()
            {
                idBanco = objBancoModel.idBanco,
                nombre = objBancoModel.nombre,
                abreviatura = objBancoModel.abreviatura,
                idUsuarioModifico = objBancoModel.idUsuarioRegistro
            };

            response.value = objBancoBL.Modificar(objBanco);
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }

        return response;
    }

    /// <summary>
    /// Servicio para registrar un nuevo banco en el sistema
    /// </summary>
    /// <param name="objBancoModel">objeto banco con los datos a registrar</param>
    /// <returns>objeto banco con los datos registrados</returns>
    public Response<BancoModel> Registrar(BancoModel objBancoModel)
    {
        var response = new Response<BancoModel>();
        try
        {
            var objBanco = new Banco()
            {
                nombre = objBancoModel.nombre,
                abreviatura = objBancoModel.abreviatura,
                idUsuarioRegistro = objBancoModel.idUsuarioRegistro
            };

            objBanco = objBancoBL.Registrar(objBanco);
            objBancoModel.idBanco = objBanco.idBanco;
            objBancoModel.activo = objBanco.activo;

            response.value = objBancoModel;
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }

        return response;
    }
}
