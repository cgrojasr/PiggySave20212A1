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
    [RoutePrefix("api/moneda")]
    public class MonedaController : ApiController
    {
        private readonly MonedaBL objMonedaBL;

        public MonedaController()
        {
            objMonedaBL = new MonedaBL();
        }

        [HttpGet]
        [Route("listar")]
        public IHttpActionResult Listar() {
            var response = new Response<List<MonedaModel>>();
            try
            {
                var lstMonedas = objMonedaBL.Listar();
                var lstMonedasModel = new List<MonedaModel>();

                foreach (var moneda in lstMonedas) {
                    var monedaModel = new MonedaModel
                    {
                        idMoneda = moneda.idMoneda,
                        nombre = moneda.nombre,
                        abreviatura = moneda.abreviatura
                    };

                    lstMonedasModel.Add(monedaModel);
                }

                response.value = lstMonedasModel;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar/{idMoneda}")]
        public IHttpActionResult Buscar(int idMoneda) {
            var response = new Response<MonedaModel>();
            try
            {
                var moneda = objMonedaBL.Buscar(idMoneda);
                var monedaModel = new MonedaModel {
                    idMoneda = moneda.idMoneda,
                    nombre = moneda.nombre,
                    abreviatura = moneda.abreviatura
                };

                response.value = monedaModel;
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
        public IHttpActionResult Registrar(MonedaModel objMonedaModel) {
            var response = new Response<MonedaModel>();
            try
            {
                var objMoneda = new Moneda
                {
                    nombre = objMonedaModel.nombre,
                    abreviatura = objMonedaModel.abreviatura,
                    idUsuarioRegistro = objMonedaModel.idUsuarioRegistro,
                    activo = objMonedaModel.activo
                };
                
                objMoneda = objMonedaBL.Registrar(objMoneda);
                objMonedaModel.idMoneda = objMoneda.idMoneda;
                response.value = objMonedaModel;
            }
            catch (Exception ex)
            {
                response.error =true;
                response.errorMessage = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("modificar")]
        public IHttpActionResult Modificar(MonedaModel objMonedaModel)
        {
            var response = new Response<bool>();
            try
            {
                var objMoneda = new Moneda
                {
                    idMoneda = objMonedaModel.idMoneda,
                    nombre = objMonedaModel.nombre,
                    abreviatura = objMonedaModel.abreviatura,
                    activo =objMonedaModel.activo,
                    idUsuarioModifico = objMonedaModel.idUsuarioRegistro
                };

                response.value = objMonedaBL.Modificar(objMoneda);
            }
            catch (Exception ex)
            {
                response.error = true;
                response.errorMessage = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("eliminar/{idMoneda}")]
        public IHttpActionResult Eliminar(int idMoneda)
        {
            var response = new Response<bool>();
            try
            {
                response.value = objMonedaBL.Eliminar(idMoneda);
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
