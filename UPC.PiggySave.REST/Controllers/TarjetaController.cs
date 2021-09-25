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
    [RoutePrefix("api/tarjeta")]
    public class TarjetaController : ApiController
    {
        TarjetaBL objTarjetaBL;
        public TarjetaController()
        {
            objTarjetaBL = new TarjetaBL();
        }

        [HttpGet]
        [Route("BuscarPorUsuario/{idTarjeta}/{idUsuario}")]
        public IHttpActionResult BuscarPorUsuario(int idTarjeta, int idUsuario) {
            var response = new Response<Tarjeta_BuscarPorUsuario>();
            try
            {
                var value = objTarjetaBL.BuscarPorUsuario(idTarjeta, idUsuario);
                var tarjeta = new Tarjeta_BuscarPorUsuario { 
                    idTarjeta = value.idTarjeta,
                    diaCierre = value.diaCierre,
                    nombre = value.Tarjeta.nombre,
                    nombreBanco = value.Tarjeta.Banco.nombre
                };

                response.value = tarjeta;
            }
            catch (PiggySaveException psex) {
                response.error = true;
                response.errorMessage = psex.Message;
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("ListarPorBanco/{idBanco}")]
        public IHttpActionResult ListarPorBanco(int idBanco)
        {
            var response = new Response<IEnumerable<Tarjeta>>();
            try
            {
                response.value = objTarjetaBL.ListarPorBanco(idBanco);
            }
            catch (PiggySaveException psex)
            {
                response.error = true;
                response.errorMessage = psex.Message;
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("ListarPorUsuario/{idUsuario}")]
        public IHttpActionResult ListarPorUsuario(int idUsuario)
        {
            var response = new Response<IEnumerable<TarjetaXUsuario>>();
            try
            {
                response.value = objTarjetaBL.ListarPorUsuario(idUsuario);
            }
            catch (PiggySaveException psex)
            {
                response.error = true;
                response.errorMessage = psex.Message;
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
