using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UPC.PiggySave.BL;
using UPC.PiggySave.DA;
using UPC.PiggySave.REST.Models;

namespace UPC.PiggySave.REST.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("buscar/{idUsuario}")]
        public IHttpActionResult Buscar(int idUsuario) {
            var response = new Response<UsuarioModel>();
            try
            {
                var objUsuarioBL = new UsuarioBL();
                var objUsuario = objUsuarioBL.Buscar(idUsuario);
                var objUsuarioModel = new UsuarioModel {
                    idUsuario = objUsuario.idUsuario,
                    nombre = objUsuario.nombre,
                    apellido = objUsuario.apellido,
                    email = objUsuario.email,
                    contrasena = objUsuario.contrasena,
                    activo = objUsuario.activo
                };
                response.value = objUsuarioModel;
            }
            catch (Exception ex)
            {
                response.error = true;
                response.errorMessage = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("registrar")]
        public IHttpActionResult Registrar(UsuarioModel objUsuarioModel) {
            var response = new Response<UsuarioModel>();
            try
            {
                var objUsuarioBL = new UsuarioBL();
                var objUsuario = new Usuario {
                    nombre = objUsuarioModel.nombre,
                    apellido = objUsuarioModel.apellido,
                    email=objUsuarioModel.email,
                    contrasena = objUsuarioModel.contrasena,
                    activo = objUsuarioModel.activo,
                    idUsuarioRegistro = objUsuarioModel.idUsuarioRegitro
                };
                objUsuario = objUsuarioBL.Registrar(objUsuario);
                objUsuarioModel.idUsuario = objUsuario.idUsuario;
                response.value = objUsuarioModel;
            }
            catch (Exception ex)
            {
                response.error = true;
                response.errorMessage = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("modificar")]
        public IHttpActionResult Modificar(UsuarioModel objUsuarioModel) {
            var response = new Response<bool>();
            try
            {
                var objUsuarioBL = new UsuarioBL();
                var objUsuario = new Usuario
                {
                    idUsuario = objUsuarioModel.idUsuario,
                    nombre = objUsuarioModel.nombre,
                    apellido = objUsuarioModel.apellido,
                    email = objUsuarioModel.email,
                    contrasena = objUsuarioModel.contrasena,
                    activo = objUsuarioModel.activo,
                    idUsuarioModifico = objUsuarioModel.idUsuarioRegitro
                };
                response.value = objUsuarioBL.Modificar(objUsuario);
            }
            catch (Exception ex)
            {
                response.error = true;
                response.errorMessage = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminar/{idUsuario}")]
        public IHttpActionResult Eliminar(int idUsuario)
        {
            var response = new Response<bool>();
            try
            {
                var objUsuarioBL = new UsuarioBL();
                response.value = objUsuarioBL.Eliminar(idUsuario);
            }
            catch (Exception ex)
            {
                response.error = true;
                response.errorMessage = ex.Message;
            }

            return Ok(response);
        }
    }
}
