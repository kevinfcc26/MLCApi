using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MLCApi.Mappers;
using MLCApi.Models;
using MLCApi.Models.ApiModels;
using MLCApi.Services;

namespace MLCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentasService _ventasService;

        public VentasController(IVentasService ventasService)
        {
            _ventasService = ventasService;
        }
        
        /// <summary>
        /// Get Ventas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Ventas = await _ventasService.GetVentas(id);

            return Ok(Ventas);
        } 

        [HttpGet]
        [Produces("application/json", Type = typeof(List<Ventas>))]
        public async Task<IActionResult> GetAll()
        {
            var Ventas = await _ventasService.GetAllVentas();

            return Ok(Ventas);
        }


        /// <summary>
        /// Agrega un nuevo Vendedor
        /// </summary>
        /// <param name="ventas"></param>
        /// <returns>Vendedor</returns>
        [ProducesResponseType(200)] 
        [ProducesResponseType(500)] 
        [ProducesResponseType(401)] 
        [Produces("application/json",Type=typeof(Ventas))] 

        // POST: api/Values
        [HttpPost]
        public async Task<IActionResult> AddVentas([FromBody]Ventas ventas)
        {
            var name = await _ventasService.AddVentas(VentasMapper.Map(ventas));

            return Ok(name);
        }

        /// <summary>
        /// Actualiza un Vendedor
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        // PUT: api/Values/5
        [HttpPut]
        public async Task<IActionResult> UpdateVentas([FromBody]Ventas ventas)
        {
            var name = await _ventasService.UpdateVentas(VentasMapper.Map(ventas));

            return Ok(name);
        }
        /// <summary>
        /// Borra un Vendedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentas(int id)
        {
            await _ventasService.DeleteVentas(id);

            return Ok();
        }
    }
}
