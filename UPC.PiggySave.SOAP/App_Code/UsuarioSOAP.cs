using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.PiggySave.BL;
using UPC.PiggySave.DA;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsuarioSOAP" in code, svc and config file together.
public class UsuarioSOAP : IUsuarioSOAP
{
    public Response<bool> Actualizar(UsuarioModel objUsuarioModel)
    {
        var response = new Response<bool>();
        var objUsuarioBL = new UsuarioBL();
        try
        {
            var objUsuario = new Usuario
            {
                idUsuario = objUsuarioModel.IdUsuario,
                nombre = objUsuarioModel.Nombre,
                apellido = objUsuarioModel.Apellido,
                email = objUsuarioModel.Email,
                contrasena = objUsuarioModel.Contrasena,
                idUsuarioModifico = objUsuarioModel.IdUsuarioRegistro
            };

            response.value = objUsuarioBL.Modificar(objUsuario);
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }
        return response;
    }

    public Response<UsuarioModel> Buscar(int idUsuario)
    {
        var response = new Response<UsuarioModel>();
        var objUsuarioBL = new UsuarioBL();
        try
        {
            var objUsuario = objUsuarioBL.Buscar(idUsuario);
            var objUsuarioModel = new UsuarioModel {
                IdUsuario = objUsuario.idUsuario,
                Nombre = objUsuario.nombre,
                Apellido = objUsuario.apellido,
                Email = objUsuario.email,
                Contrasena = objUsuario.contrasena
            };

            response.value = objUsuarioModel;
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }
        return response;
    }

    public Response<bool> Eliminar(int idUsuario)
    {
        var response = new Response<bool>();
        var objUsuarioBL = new UsuarioBL();
        try
        {
            response.value = objUsuarioBL.Eliminar(idUsuario);
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }
        return response;
    }

    public Response<UsuarioModel> Regitrar(UsuarioModel objUsuarioModel)
    {
        var response = new Response<UsuarioModel>();
        var objUsuarioBL = new UsuarioBL();
        try
        {
            var objUsuario = new Usuario
            {
                nombre = objUsuarioModel.Nombre,
                apellido = objUsuarioModel.Apellido,
                email = objUsuarioModel.Email,
                contrasena = objUsuarioModel.Contrasena,
                idUsuarioRegistro = objUsuarioModel.IdUsuarioRegistro
            };

            objUsuario = objUsuarioBL.Registrar(objUsuario);
            objUsuarioModel.IdUsuario = objUsuario.idUsuario;
            response.value = objUsuarioModel;
        }
        catch (Exception ex)
        {
            response.error = true;
            response.errorMessage = ex.Message;
        }
        return response;
    }
}
