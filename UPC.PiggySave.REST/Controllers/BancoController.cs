using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UPC.PiggySave.BL;
using UPC.PiggySave.BL.Tools;
using UPC.PiggySave.DA;
using UPC.PiggySave.REST.Models;

namespace UPC.PiggySave.REST.Controllers
{
    [RoutePrefix("api/banco")]
    public class BancoController : ApiController
    {

        private readonly BancoBL objBancoBL;
        public BancoController()
        {
            objBancoBL = new BancoBL();
        }

        [HttpGet]
        [Route("{idBanco}")]
        public IHttpActionResult Buscar(int idBanco)
        {
            try
            {
                var response = new Response<BancoModel.Registro>();
                try
                {
                    var objBanco = objBancoBL.Buscar(idBanco);
                    var objBancoModel = new BancoModel.Registro()
                    {
                        idBanco = objBanco.idBanco,
                        nombre = objBanco.nombre,
                        abreviatura = objBanco.abreviatura
                    };
                    response.value = objBancoModel;
                }
                catch (PiggySaveException PSex)
                {
                    response.error = true;
                    response.errorMessage = PSex.Message;
                }
                
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult Modificar(BancoModel.Registro objBancoModel)
        {
            try
            {
                var response = new Response<bool>();
                try
                {
                    var objBanco = new Banco()
                    {
                        idBanco = objBancoModel.idBanco,
                        nombre = objBancoModel.nombre,
                        abreviatura = objBancoModel.abreviatura,
                        idUsuarioModifico = objBancoModel.idUsuarioRegistro,
                        activo = objBancoModel.activo
                    };

                    response.value = objBancoBL.Modificar(objBanco);
                }
                catch (PiggySaveException PSex)
                {
                    response.error = true;
                    response.errorMessage = PSex.Message;
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{idBanco}")]
        public IHttpActionResult Eliminar(int idBanco)
        {
            try
            {
                var response = new Response<bool>();
                try
                {
                    response.value = objBancoBL.Eliminar(idBanco);
                }
                catch (PiggySaveException PSex)
                {
                    response.error = true;
                    response.errorMessage = PSex.Message;
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult Registrar(BancoModel.Registro objBancoModel)
        {
            try
            {
                var response = new Response<BancoModel.Registro>();
                try
                {
                    var objBanco = new Banco()
                    {
                        nombre = objBancoModel.nombre,
                        abreviatura = objBancoModel.abreviatura,
                        idUsuarioModifico = objBancoModel.idUsuarioRegistro,
                        activo = objBancoModel.activo
                    };

                    objBanco = objBancoBL.Registrar(objBanco);
                    objBancoModel.idBanco = objBanco.idBanco;
                    response.value = objBancoModel;
                }
                catch (PiggySaveException PSex)
                {
                    response.error = true;
                    response.errorMessage = PSex.Message;
                }

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
